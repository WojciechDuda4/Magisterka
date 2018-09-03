namespace RobotGeneratorWizard
{
    partial class ChosenModelsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RobotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfAxisColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayloadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReachColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnColumn,
            this.RobotName,
            this.Company,
            this.ApplicationType,
            this.NumberOfAxisColumn,
            this.PayloadColumn,
            this.ReachColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 176);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChooseRobotModel);
            // 
            // btnColumn
            // 
            this.btnColumn.HeaderText = "";
            this.btnColumn.Name = "btnColumn";
            this.btnColumn.Text = "Wybierz";
            this.btnColumn.ToolTipText = "Wybierz robota";
            this.btnColumn.UseColumnTextForButtonValue = true;
            // 
            // RobotName
            // 
            this.RobotName.DataPropertyName = "Name";
            this.RobotName.HeaderText = "Nazwa robota";
            this.RobotName.Name = "RobotName";
            this.RobotName.ReadOnly = true;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "Company";
            this.Company.HeaderText = "Firma";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            // 
            // ApplicationType
            // 
            this.ApplicationType.DataPropertyName = "Name1";
            this.ApplicationType.HeaderText = "Typ aplikacji";
            this.ApplicationType.Name = "ApplicationType";
            this.ApplicationType.ReadOnly = true;
            // 
            // NumberOfAxisColumn
            // 
            this.NumberOfAxisColumn.DataPropertyName = "NumberOfAxis";
            this.NumberOfAxisColumn.HeaderText = "Liczba osi";
            this.NumberOfAxisColumn.Name = "NumberOfAxisColumn";
            this.NumberOfAxisColumn.ReadOnly = true;
            // 
            // PayloadColumn
            // 
            this.PayloadColumn.DataPropertyName = "Payload";
            this.PayloadColumn.HeaderText = "Obciążenie";
            this.PayloadColumn.Name = "PayloadColumn";
            this.PayloadColumn.ReadOnly = true;
            // 
            // ReachColumn
            // 
            this.ReachColumn.DataPropertyName = "Reach";
            this.ReachColumn.HeaderText = "Zasięg";
            this.ReachColumn.Name = "ReachColumn";
            this.ReachColumn.ReadOnly = true;
            // 
            // ChosenModelsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 214);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ChosenModelsListForm";
            this.Text = "Wybór modelu robota";
            this.Load += new System.EventHandler(this.ChosenModelsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn btnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RobotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfAxisColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayloadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReachColumn;
    }
}