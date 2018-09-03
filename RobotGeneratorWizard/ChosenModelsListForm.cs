using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotGeneratorWizard
{
    public partial class ChosenModelsListForm : Form
    {
        public event EventHandler<RobotModelChosenEventArgs> OnRobotModelChosen;

        DataTable chosenRobotModels;

        public ChosenModelsListForm(DataTable chosenRobotModels)
        {
            InitializeComponent();
            this.chosenRobotModels = chosenRobotModels;
        }

        private void ChosenModelsListForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = chosenRobotModels;
        }

        private void ChooseRobotModel(object sender, DataGridViewCellEventArgs e)
        {
            if (OnRobotModelChosen != null)
	        {
                OnRobotModelChosen(sender, new RobotModelChosenEventArgs(chosenRobotModels, e.ColumnIndex, e.RowIndex, this));
	        }
        }
    }

    public class RobotModelChosenEventArgs : EventArgs
    {
        public RobotModelChosenEventArgs(DataTable chosenRobotModels, int columnIndex, int rowIndex, ChosenModelsListForm chosenModelsListForm)
        {
            ChosenRobotModels = chosenRobotModels;
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
            ChosenModelsListForm = chosenModelsListForm;
        }

        public DataTable ChosenRobotModels { get; set; }

        public int ColumnIndex { get; set; }

        public int RowIndex { get; set; }

        public ChosenModelsListForm ChosenModelsListForm { get; set; }
    }
}
