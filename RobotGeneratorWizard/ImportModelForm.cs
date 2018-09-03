using RobotGeneratorWizard.Database;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotGeneratorWizard
{

    public partial class ImportModelForm : Form
    {
        DataTable applicationTypes;

        private string _outputDirectory
        {
            get
            {
                return @"C:\Program Files\Siemens\NX 10.0\UGII\Models_prt";
            }
        }

        private string _fullModelPath
        {
            get
            {
                return string.Format(@"{0}\{1}", txtModelPath.Text, txtModelName.Text);
            }
        }

        public ImportModelForm()
        {
            InitializeComponent();
        }

        private void ImportModelForm_Load(object sender, EventArgs e)
        {
            applicationTypes = DatabaseMethods.GetDataFromDatabase("GetAllApplicationTypes", CommandType.StoredProcedure, new Dictionary<string, object>());
            if (applicationTypes == null)
            {
                MessageBox.Show("Nie udało się pobrać typów apliacji z bazy");
                return;
            }

            grdvApplicationTypes.DataSource = applicationTypes;
        }

        private void btnChooseModelPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtModelPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Pliki PRT (*.prt)|*.prt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtModelName.Text = openFileDialog.SafeFileName;
            }
        }

        private void btnAddNewApplicationType_Click(object sender, EventArgs e)
        {
            if (applicationTypes.AsEnumerable().Any(row => row.Field<string>("Name") == txtNewApplicationType.Text))
            {
                MessageBox.Show("Podany typ aplikacji istnieje już w bazie.");
                return;
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string,object>();
                int rowsAffected;
                parameters.Add("@ApplicationType", txtNewApplicationType.Text);
                try
                {
                     rowsAffected = DatabaseMethods.InvokeNonQueryProcedure("AddNewApplicationType", CommandType.StoredProcedure, parameters);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Nie udało się dodać typu aplikacji do bazy. Treść błędu: " + ex.Message);
                    return;
                }

                if (rowsAffected != 1)
                {
                    MessageBox.Show("Nie udało się dodać typu aplikacji do bazy.");
                    return;
                }

                MessageBox.Show(string.Format("Pomyślnie dodano typ aplikacji: {0} do bazy", txtNewApplicationType.Text));
            }

            applicationTypes = DatabaseMethods.GetDataFromDatabase("GetAllApplicationTypes", CommandType.StoredProcedure, new Dictionary<string, object>());
            if (applicationTypes == null)
            {
                MessageBox.Show("Nie udało się pobrać typów apliacji z bazy");
                return;
            }

            grdvApplicationTypes.DataSource = applicationTypes;

            txtNewApplicationType.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!CheckModelDirectory())
            {
                return;
            }
            if (!CheckIfModelExists())
            {
                return;
            }
            if (!CheckChosenParameters())
            {
                return;
            }
            if (!CheckIfAtLeastOneApplicationTypeChosen())
            {
                return;
            }
            if (CheckIfModelExistsInDatabase())
            {
                return;
            }
            if (CheckIfModelExistsInModelsDirectory())
            {
                return;
            }

            try
            {
                CopyModelDirectory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się skopiować wybranych modeli do katalogu z modelami. Treść błędu: " + ex.Message);
                return;
            }

            try
            {
                AddRobotModelToDatabase();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nie udało się dodać modelu do bazy. Treść błędu: " + ex.Message);
                return;
            }

            MessageBox.Show("Pomyślnie zaimportowano model manipulatora.");
            this.Controls.Clear();
            this.InitializeComponent();
            applicationTypes = DatabaseMethods.GetDataFromDatabase("GetAllApplicationTypes", CommandType.StoredProcedure, new Dictionary<string, object>());
            if (applicationTypes == null)
            {
                MessageBox.Show("Nie udało się pobrać typów apliacji z bazy");
                return;
            }

            grdvApplicationTypes.DataSource = applicationTypes;
        }

        private void cbAxisNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtAxisNumber.Enabled = cbAxisNumber.Checked;
        }

        private void cbReach_CheckedChanged(object sender, EventArgs e)
        {
            txtReach.Enabled = cbReach.Checked;
        }

        private void cbPayLoad_CheckedChanged(object sender, EventArgs e)
        {
            txtPayLoad.Enabled = cbPayLoad.Checked;
        }

        private bool CheckModelDirectory()
        {
            if (string.IsNullOrEmpty(txtModelPath.Text))
            {
                MessageBox.Show("Proszę wybrać folder zawierający model manipulatora.");
                return false;
            }
            if (!Directory.Exists(txtModelPath.Text))
            {
                MessageBox.Show("Podany folder z modelem nie istnieje.");
                return false;
            }

            return true;
        }

        private bool CheckIfModelExists()
        {
            if (string.IsNullOrEmpty(txtModelName.Text))
            {
                MessageBox.Show("Należy wybrać model do importu.");
                return false;
            }
            if (!File.Exists(_fullModelPath))
            {
                MessageBox.Show("Wybrany plik modelu nie istnieje.");
                return false;
            }

            return true;
        }

        private bool CheckChosenParameters()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Proszę podać nazwę modelu manipulatora.");
                return false;
            }
            if (!cbAxisNumber.Checked && !cbPayLoad.Checked && !cbReach.Checked)
            {
                MessageBox.Show("Przynajmniej jeden parametr prócz typu aplikacji musi być podany.");
                return false;
            }
            if (cbAxisNumber.Checked)
            {
                int result;
                if (string.IsNullOrEmpty(txtAxisNumber.Text) && !int.TryParse(txtAxisNumber.Text, out result))
                {
                    MessageBox.Show("Błędna wartość w polu z liczbą osi.");
                    return false;
                }
            }
            if (cbPayLoad.Checked)
            {
                double result;
                if (string.IsNullOrEmpty(txtPayLoad.Text) && !double.TryParse(txtPayLoad.Text, out result))
                {
                    MessageBox.Show("Błędna wartość w polu z obciążeniem.");
                    return false;
                }
            }
            if (cbReach.Checked)
            {
                double result;
                if (string.IsNullOrEmpty(txtReach.Text) && !double.TryParse(txtReach.Text, out result))
                {
                    MessageBox.Show("Błędna wartość w polu z zasięgiem.");
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfAtLeastOneApplicationTypeChosen()
        {
            bool isAtLeastOneApplicationTypeChosen = false;

            foreach (DataGridViewRow row in grdvApplicationTypes.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    isAtLeastOneApplicationTypeChosen = true;
                    break;
                }
            }

            return isAtLeastOneApplicationTypeChosen;
        }

        private bool CheckIfModelExistsInDatabase()
        {
            Dictionary<string, object> parameters = new Dictionary<string,object>();
            parameters.Add("@ModelName", txtModelName.Text);
            try
            {
                if (DatabaseMethods.GetDataFromDatabase("CheckIfModelExits", CommandType.StoredProcedure, parameters).Rows.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nie udało się sprawdzić, czy dany model istnieje w bazie danych! Treść błędu: " + ex.Message);
                return true;
            }
        }

        private bool CheckIfModelExistsInModelsDirectory()
        {
            string directoryToCopyName = txtModelPath.Text.Substring(txtModelPath.Text.LastIndexOf('\\'));

            if (Directory.Exists(string.Format(@"{0}{1}", _outputDirectory, directoryToCopyName)))
            {
                MessageBox.Show("Folder z modelem o podanej nazwie istnieje już w folderze z robotami.");
                return true;
            }
            else if (File.Exists(string.Format(@"{0}{1}\{2}", _outputDirectory, directoryToCopyName, txtModelName.Text)))
            {
                MessageBox.Show("Model o takiej samej nazwie istnieje już w folderze z robotami.");
                return true;
            }

            return false;
        }

        private void CopyModelDirectory()
        {
            string newDirectory = string.Format("{0}{1}", _outputDirectory, txtModelPath.Text.Substring(txtModelPath.Text.LastIndexOf('\\')));
            
            Directory.CreateDirectory(newDirectory);

            foreach (string dirPath in Directory.GetDirectories(txtModelPath.Text, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(txtModelPath.Text, newDirectory));
            }

            foreach (string newPath in Directory.GetFiles(txtModelPath.Text, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(txtModelPath.Text, newDirectory), true);
            }
        }

        private int AddRobotModelToDatabase()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Name", txtName.Text);
            parameters.Add("@Description", txtDescription.Text);
            parameters.Add("@Company", txtFactory.Text);
            parameters.Add("@FilePath", txtModelName.Text);
            parameters.Add("@Payload", txtPayLoad.Text);
            parameters.Add("@Reach", txtReach.Text.Replace(',', '.'));
            parameters.Add("@NumberOfAxis", txtAxisNumber.Text);
            parameters.Add("@ApplicationTypes", GetModelSelectedApplicationTypes());

            int rowsAffected;

            try
            {
                rowsAffected = DatabaseMethods.InvokeNonQueryProcedure("AddNewRobotToDatabase", CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return rowsAffected;
        }

        private string GetModelSelectedApplicationTypes()
        {
            string applicationTypes = "";

            foreach (DataGridViewRow row in grdvApplicationTypes.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    applicationTypes += string.Format("\'{0}\',", row.Cells[1].Value.ToString());
                }
            }

            applicationTypes = applicationTypes.Remove(applicationTypes.LastIndexOf(','));

            return applicationTypes;
        }
    }
}

