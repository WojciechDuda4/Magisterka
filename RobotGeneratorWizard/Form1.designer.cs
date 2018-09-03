namespace RobotGeneratorWizard
{
    partial class Form1
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
            this.ddlApplicationTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayload = new System.Windows.Forms.TextBox();
            this.txtNumberOfAxis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNumberOfAxisEnabled = new System.Windows.Forms.CheckBox();
            this.cbReachEnabled = new System.Windows.Forms.CheckBox();
            this.cbPayloadEnabled = new System.Windows.Forms.CheckBox();
            this.btnFindModel = new System.Windows.Forms.Button();
            this.btnImportModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlApplicationTypes
            // 
            this.ddlApplicationTypes.FormattingEnabled = true;
            this.ddlApplicationTypes.Location = new System.Drawing.Point(31, 39);
            this.ddlApplicationTypes.Name = "ddlApplicationTypes";
            this.ddlApplicationTypes.Size = new System.Drawing.Size(177, 21);
            this.ddlApplicationTypes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Typ aplikacji";
            // 
            // txtReach
            // 
            this.txtReach.Location = new System.Drawing.Point(31, 118);
            this.txtReach.Name = "txtReach";
            this.txtReach.Size = new System.Drawing.Size(177, 20);
            this.txtReach.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Obciążenie [ kg ]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zasięg [ m ]";
            // 
            // txtPayload
            // 
            this.txtPayload.Location = new System.Drawing.Point(31, 157);
            this.txtPayload.Name = "txtPayload";
            this.txtPayload.Size = new System.Drawing.Size(177, 20);
            this.txtPayload.TabIndex = 5;
            // 
            // txtNumberOfAxis
            // 
            this.txtNumberOfAxis.Location = new System.Drawing.Point(31, 79);
            this.txtNumberOfAxis.Name = "txtNumberOfAxis";
            this.txtNumberOfAxis.Size = new System.Drawing.Size(177, 20);
            this.txtNumberOfAxis.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Liczba osi";
            // 
            // cbNumberOfAxisEnabled
            // 
            this.cbNumberOfAxisEnabled.AutoSize = true;
            this.cbNumberOfAxisEnabled.Checked = true;
            this.cbNumberOfAxisEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNumberOfAxisEnabled.Location = new System.Drawing.Point(215, 81);
            this.cbNumberOfAxisEnabled.Name = "cbNumberOfAxisEnabled";
            this.cbNumberOfAxisEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbNumberOfAxisEnabled.TabIndex = 10;
            this.cbNumberOfAxisEnabled.UseVisualStyleBackColor = true;
            this.cbNumberOfAxisEnabled.CheckedChanged += new System.EventHandler(this.cbNumberOfAxisEnabled_CheckedChanged);
            // 
            // cbReachEnabled
            // 
            this.cbReachEnabled.AutoSize = true;
            this.cbReachEnabled.Checked = true;
            this.cbReachEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbReachEnabled.Location = new System.Drawing.Point(215, 120);
            this.cbReachEnabled.Name = "cbReachEnabled";
            this.cbReachEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbReachEnabled.TabIndex = 11;
            this.cbReachEnabled.UseVisualStyleBackColor = true;
            this.cbReachEnabled.CheckedChanged += new System.EventHandler(this.cbReachEnabled_CheckedChanged);
            // 
            // cbPayloadEnabled
            // 
            this.cbPayloadEnabled.AutoSize = true;
            this.cbPayloadEnabled.Checked = true;
            this.cbPayloadEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPayloadEnabled.Location = new System.Drawing.Point(215, 159);
            this.cbPayloadEnabled.Name = "cbPayloadEnabled";
            this.cbPayloadEnabled.Size = new System.Drawing.Size(15, 14);
            this.cbPayloadEnabled.TabIndex = 12;
            this.cbPayloadEnabled.UseVisualStyleBackColor = true;
            this.cbPayloadEnabled.CheckedChanged += new System.EventHandler(this.cbPayloadEnabled_CheckedChanged);
            // 
            // btnFindModel
            // 
            this.btnFindModel.Location = new System.Drawing.Point(140, 203);
            this.btnFindModel.Name = "btnFindModel";
            this.btnFindModel.Size = new System.Drawing.Size(90, 23);
            this.btnFindModel.TabIndex = 13;
            this.btnFindModel.Text = "Znajdź model";
            this.btnFindModel.UseVisualStyleBackColor = true;
            this.btnFindModel.Click += new System.EventHandler(this.btnFindModel_Click);
            // 
            // btnImportModel
            // 
            this.btnImportModel.Location = new System.Drawing.Point(31, 203);
            this.btnImportModel.Name = "btnImportModel";
            this.btnImportModel.Size = new System.Drawing.Size(90, 23);
            this.btnImportModel.TabIndex = 14;
            this.btnImportModel.Text = "Importuj model";
            this.btnImportModel.UseVisualStyleBackColor = true;
            this.btnImportModel.Click += new System.EventHandler(this.btnImportModel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 239);
            this.Controls.Add(this.btnImportModel);
            this.Controls.Add(this.btnFindModel);
            this.Controls.Add(this.cbPayloadEnabled);
            this.Controls.Add(this.cbReachEnabled);
            this.Controls.Add(this.cbNumberOfAxisEnabled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumberOfAxis);
            this.Controls.Add(this.ddlApplicationTypes);
            this.Controls.Add(this.txtReach);
            this.Controls.Add(this.txtPayload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator modeli manipulatorów";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlApplicationTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPayload;
        private System.Windows.Forms.TextBox txtNumberOfAxis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbNumberOfAxisEnabled;
        private System.Windows.Forms.CheckBox cbReachEnabled;
        private System.Windows.Forms.CheckBox cbPayloadEnabled;
        private System.Windows.Forms.Button btnFindModel;
        private System.Windows.Forms.Button btnImportModel;
    }
}

