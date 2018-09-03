using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotGeneratorWizard.Database;
using RobotGeneratorWizard.Parameters;
using RobotGeneratorWizard.Enums;
using RobotGeneratorWizard.Exceptions;
using RobotGeneratorWizard.RobotModel;

namespace RobotGeneratorWizard
{
    public partial class Form1 : Form
    {
        public event EventHandler<ModelRobotPathSetEventArgs> OnRobotModelPathSet;

        DataTable robotModels;

        ChosenModelsListForm chosenModelsListForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindApplicationTypesDropDownList();

            txtNumberOfAxis.Enabled = cbNumberOfAxisEnabled.Checked;
            txtPayload.Enabled = cbPayloadEnabled.Checked;
            txtReach.Enabled = cbReachEnabled.Checked;

        }

        private void BindApplicationTypesDropDownList()
        {
            DataTable applicationTypes = null;
            string applicationTypeStoredProcedureName = "getApplicationTypes";

            try
            {
                applicationTypes = DatabaseMethods.GetDataFromDatabase(applicationTypeStoredProcedureName, CommandType.StoredProcedure, new Dictionary<string, object>());
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(string.Format("Nie udało się pobrać typów aplikacji z bazy danych. Treść wyjątku: {0}", sqlException.Message));
            }

            ddlApplicationTypes.DataSource = applicationTypes;
            ddlApplicationTypes.DisplayMember = "Name";
            ddlApplicationTypes.ValueMember = "Name";
        }

        private void btnRefreshApplicationTypes_Click(object sender, EventArgs e)
        {
            BindApplicationTypesDropDownList();
        }

        private void cbNumberOfAxisEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtNumberOfAxis.Enabled = cbNumberOfAxisEnabled.Checked;
        }

        private void cbReachEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtReach.Enabled = cbReachEnabled.Checked;
        }

        private void cbPayloadEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtPayload.Enabled = cbPayloadEnabled.Checked;
        }

        private void btnFindModel_Click(object sender, EventArgs e)
        {
            DataTable robotModels;
            IRobotModelsHandler robotModelsHandler;
            IList<TextBox> parametersTextBoxes = new List<TextBox> { txtNumberOfAxis, txtReach, txtPayload };
            ParametersHandler parametersHandler = new ParametersHandler(parametersTextBoxes);
            RobotModelType robotModelType = parametersHandler.GetRobotModelType();
            IList<Parameter> parameters = null;

            try
            {
                parameters = parametersHandler.GetParameters();
            }
            catch (ParameterTextBoxNotFilledException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (ParameterTextBoxInvalidValue exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            robotModelsHandler = RobotModelFactory.GetRobotModelHandler(robotModelType, parameters, ddlApplicationTypes.SelectedValue.ToString());
            robotModels = robotModelsHandler.GetChosenRobotModels();

            if (robotModels == null)
            {
                MessageBox.Show("Nie udało się pobrać modeli z bazy.");
                return;
            }

            ChosenModelsListForm chosenModelsListForm = new ChosenModelsListForm(robotModels);
            chosenModelsListForm.OnRobotModelChosen += chosenModelsListForm_OnRobotModelChosen;
            chosenModelsListForm.ShowDialog();
        }

        void chosenModelsListForm_OnRobotModelChosen(object sender, RobotModelChosenEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string fileToShowPath = e.ChosenRobotModels.Rows[e.RowIndex]["FilePath"].ToString();

                if (OnRobotModelPathSet != null)
                {
                    OnRobotModelPathSet(this, new ModelRobotPathSetEventArgs(fileToShowPath));
                    e.ChosenModelsListForm.Close();
                }
            }
        }

        private void btnImportModel_Click(object sender, EventArgs e)
        {
            ImportModelForm importModelForm = new ImportModelForm();
            importModelForm.ShowDialog();
        }
    }

    public class ModelRobotPathSetEventArgs : EventArgs
    {
        public ModelRobotPathSetEventArgs(string robotModelPath)
        {
            RobotModelPath = robotModelPath;
        }

        public string RobotModelPath { get; set; }
    }
}
