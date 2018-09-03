namespace RobotGeneratorWizard
{
    partial class ImportModelForm
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
            this.txtModelPath = new System.Windows.Forms.TextBox();
            this.lblModelPath = new System.Windows.Forms.Label();
            this.btnChooseModelPath = new System.Windows.Forms.Button();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.lblModelName = new System.Windows.Forms.Label();
            this.btnModel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAxisNumber = new System.Windows.Forms.TextBox();
            this.txtReach = new System.Windows.Forms.TextBox();
            this.txtPayLoad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPayLoad = new System.Windows.Forms.CheckBox();
            this.cbReach = new System.Windows.Forms.CheckBox();
            this.cbAxisNumber = new System.Windows.Forms.CheckBox();
            this.txtNewApplicationType = new System.Windows.Forms.TextBox();
            this.btnAddNewApplicationType = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.grdvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.cbApplicationType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtApplicationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvApplicationTypes)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModelPath
            // 
            this.txtModelPath.Location = new System.Drawing.Point(32, 62);
            this.txtModelPath.Name = "txtModelPath";
            this.txtModelPath.Size = new System.Drawing.Size(206, 20);
            this.txtModelPath.TabIndex = 0;
            // 
            // lblModelPath
            // 
            this.lblModelPath.AutoSize = true;
            this.lblModelPath.Location = new System.Drawing.Point(29, 46);
            this.lblModelPath.Name = "lblModelPath";
            this.lblModelPath.Size = new System.Drawing.Size(125, 13);
            this.lblModelPath.TabIndex = 1;
            this.lblModelPath.Text = "Folder zawierający model";
            // 
            // btnChooseModelPath
            // 
            this.btnChooseModelPath.Location = new System.Drawing.Point(244, 59);
            this.btnChooseModelPath.Name = "btnChooseModelPath";
            this.btnChooseModelPath.Size = new System.Drawing.Size(75, 25);
            this.btnChooseModelPath.TabIndex = 2;
            this.btnChooseModelPath.Text = "Wybierz";
            this.btnChooseModelPath.UseVisualStyleBackColor = true;
            this.btnChooseModelPath.Click += new System.EventHandler(this.btnChooseModelPath_Click);
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(32, 112);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(206, 20);
            this.txtModelName.TabIndex = 3;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(32, 96);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(36, 13);
            this.lblModelName.TabIndex = 4;
            this.lblModelName.Text = "Model";
            // 
            // btnModel
            // 
            this.btnModel.Location = new System.Drawing.Point(244, 107);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(75, 25);
            this.btnModel.TabIndex = 5;
            this.btnModel.Text = "Wybierz";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.btnModel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Liczba osi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Obciążenie [ kg ]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Zasięg [ m ]";
            // 
            // txtAxisNumber
            // 
            this.txtAxisNumber.Location = new System.Drawing.Point(30, 48);
            this.txtAxisNumber.Name = "txtAxisNumber";
            this.txtAxisNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAxisNumber.TabIndex = 13;
            // 
            // txtReach
            // 
            this.txtReach.Location = new System.Drawing.Point(30, 87);
            this.txtReach.Name = "txtReach";
            this.txtReach.Size = new System.Drawing.Size(100, 20);
            this.txtReach.TabIndex = 14;
            // 
            // txtPayLoad
            // 
            this.txtPayLoad.Location = new System.Drawing.Point(30, 126);
            this.txtPayLoad.Name = "txtPayLoad";
            this.txtPayLoad.Size = new System.Drawing.Size(100, 20);
            this.txtPayLoad.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbPayLoad);
            this.panel1.Controls.Add(this.cbReach);
            this.panel1.Controls.Add(this.cbAxisNumber);
            this.panel1.Controls.Add(this.txtNewApplicationType);
            this.panel1.Controls.Add(this.btnAddNewApplicationType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.grdvApplicationTypes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtReach);
            this.panel1.Controls.Add(this.txtPayLoad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAxisNumber);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(3, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 243);
            this.panel1.TabIndex = 16;
            // 
            // cbPayLoad
            // 
            this.cbPayLoad.AutoSize = true;
            this.cbPayLoad.Checked = true;
            this.cbPayLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPayLoad.Location = new System.Drawing.Point(136, 132);
            this.cbPayLoad.Name = "cbPayLoad";
            this.cbPayLoad.Size = new System.Drawing.Size(15, 14);
            this.cbPayLoad.TabIndex = 23;
            this.cbPayLoad.UseVisualStyleBackColor = true;
            this.cbPayLoad.CheckedChanged += new System.EventHandler(this.cbPayLoad_CheckedChanged);
            // 
            // cbReach
            // 
            this.cbReach.AutoSize = true;
            this.cbReach.Checked = true;
            this.cbReach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReach.Location = new System.Drawing.Point(136, 93);
            this.cbReach.Name = "cbReach";
            this.cbReach.Size = new System.Drawing.Size(15, 14);
            this.cbReach.TabIndex = 22;
            this.cbReach.UseVisualStyleBackColor = true;
            this.cbReach.CheckedChanged += new System.EventHandler(this.cbReach_CheckedChanged);
            // 
            // cbAxisNumber
            // 
            this.cbAxisNumber.AutoSize = true;
            this.cbAxisNumber.Checked = true;
            this.cbAxisNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAxisNumber.Location = new System.Drawing.Point(136, 54);
            this.cbAxisNumber.Name = "cbAxisNumber";
            this.cbAxisNumber.Size = new System.Drawing.Size(15, 14);
            this.cbAxisNumber.TabIndex = 21;
            this.cbAxisNumber.UseVisualStyleBackColor = true;
            this.cbAxisNumber.CheckedChanged += new System.EventHandler(this.cbAxisNumber_CheckedChanged);
            // 
            // txtNewApplicationType
            // 
            this.txtNewApplicationType.Location = new System.Drawing.Point(178, 206);
            this.txtNewApplicationType.Name = "txtNewApplicationType";
            this.txtNewApplicationType.Size = new System.Drawing.Size(177, 20);
            this.txtNewApplicationType.TabIndex = 20;
            // 
            // btnAddNewApplicationType
            // 
            this.btnAddNewApplicationType.Location = new System.Drawing.Point(361, 204);
            this.btnAddNewApplicationType.Name = "btnAddNewApplicationType";
            this.btnAddNewApplicationType.Size = new System.Drawing.Size(101, 23);
            this.btnAddNewApplicationType.TabIndex = 19;
            this.btnAddNewApplicationType.Text = "Dodaj typ aplikacji";
            this.btnAddNewApplicationType.UseVisualStyleBackColor = true;
            this.btnAddNewApplicationType.Click += new System.EventHandler(this.btnAddNewApplicationType_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Typy aplikacji";
            // 
            // grdvApplicationTypes
            // 
            this.grdvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvApplicationTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbApplicationType,
            this.txtApplicationType});
            this.grdvApplicationTypes.Location = new System.Drawing.Point(178, 48);
            this.grdvApplicationTypes.Name = "grdvApplicationTypes";
            this.grdvApplicationTypes.Size = new System.Drawing.Size(345, 150);
            this.grdvApplicationTypes.TabIndex = 17;
            // 
            // cbApplicationType
            // 
            this.cbApplicationType.HeaderText = "";
            this.cbApplicationType.Name = "cbApplicationType";
            // 
            // txtApplicationType
            // 
            this.txtApplicationType.DataPropertyName = "Name";
            this.txtApplicationType.HeaderText = "Typ aplikacji";
            this.txtApplicationType.Name = "txtApplicationType";
            this.txtApplicationType.ReadOnly = true;
            this.txtApplicationType.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Parametry";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(390, 559);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 17;
            this.btnImport.Text = "Zaimportuj";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(474, 559);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtFactory);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 168);
            this.panel2.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Dane dodatkowe";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(28, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(287, 37);
            this.txtDescription.TabIndex = 25;
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(28, 135);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(287, 20);
            this.txtFactory.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Opis manipulatora";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Firma manipulatora";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Nazwa modelu";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(28, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(287, 20);
            this.txtName.TabIndex = 29;
            // 
            // ImportModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 588);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnModel);
            this.Controls.Add(this.lblModelName);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.btnChooseModelPath);
            this.Controls.Add(this.lblModelPath);
            this.Controls.Add(this.txtModelPath);
            this.Name = "ImportModelForm";
            this.Text = "Zaimportuj model";
            this.Load += new System.EventHandler(this.ImportModelForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvApplicationTypes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtModelPath;
        private System.Windows.Forms.Label lblModelPath;
        private System.Windows.Forms.Button btnChooseModelPath;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAxisNumber;
        private System.Windows.Forms.TextBox txtReach;
        private System.Windows.Forms.TextBox txtPayLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdvApplicationTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewApplicationType;
        private System.Windows.Forms.TextBox txtNewApplicationType;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbPayLoad;
        private System.Windows.Forms.CheckBox cbReach;
        private System.Windows.Forms.CheckBox cbAxisNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbApplicationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtApplicationType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtName;
    }
}