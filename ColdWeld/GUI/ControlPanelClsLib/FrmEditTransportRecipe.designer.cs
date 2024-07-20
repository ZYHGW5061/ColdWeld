namespace ControlPanelClsLib
{
    partial class FrmEditTransportRecipe
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
            this.labName = new DevExpress.XtraEditors.LabelControl();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TransportTab = new System.Windows.Forms.TabControl();
            this.MaterialboxTabPage = new System.Windows.Forms.TabPage();
            this.MaterialTabPage = new System.Windows.Forms.TabPage();
            this.ParamPage = new System.Windows.Forms.TabPage();
            this.MaterialboxgroupBox = new System.Windows.Forms.GroupBox();
            this.MaterialgroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            this.TransportTab.SuspendLayout();
            this.ParamPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labName.Location = new System.Drawing.Point(13, 13);
            this.labName.Margin = new System.Windows.Forms.Padding(4);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(35, 18);
            this.labName.TabIndex = 0;
            this.labName.Text = "名称:";
            // 
            // teName
            // 
            this.teName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.teName.Location = new System.Drawing.Point(56, 7);
            this.teName.Margin = new System.Windows.Forms.Padding(4);
            this.teName.Name = "teName";
            this.teName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.teName.Properties.Appearance.Options.UseBackColor = true;
            this.teName.Properties.AutoHeight = false;
            this.teName.Size = new System.Drawing.Size(218, 31);
            this.teName.TabIndex = 1;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Add.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btn_Add.Appearance.Options.UseBackColor = true;
            this.btn_Add.Location = new System.Drawing.Point(144, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 36);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "保存";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Edit.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btn_Edit.Appearance.Options.UseBackColor = true;
            this.btn_Edit.Location = new System.Drawing.Point(144, 6);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 36);
            this.btn_Edit.TabIndex = 0;
            this.btn_Edit.Text = "保存";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(616, 892);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(274, 61);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // TransportTab
            // 
            this.TransportTab.Controls.Add(this.ParamPage);
            this.TransportTab.Controls.Add(this.MaterialboxTabPage);
            this.TransportTab.Controls.Add(this.MaterialTabPage);
            this.TransportTab.Location = new System.Drawing.Point(12, 67);
            this.TransportTab.Name = "TransportTab";
            this.TransportTab.Padding = new System.Drawing.Point(118, 3);
            this.TransportTab.SelectedIndex = 0;
            this.TransportTab.Size = new System.Drawing.Size(901, 818);
            this.TransportTab.TabIndex = 3;
            // 
            // MaterialboxTabPage
            // 
            this.MaterialboxTabPage.Location = new System.Drawing.Point(4, 27);
            this.MaterialboxTabPage.Name = "MaterialboxTabPage";
            this.MaterialboxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MaterialboxTabPage.Size = new System.Drawing.Size(893, 669);
            this.MaterialboxTabPage.TabIndex = 0;
            this.MaterialboxTabPage.Text = "料盒搬送";
            this.MaterialboxTabPage.UseVisualStyleBackColor = true;
            // 
            // MaterialTabPage
            // 
            this.MaterialTabPage.Location = new System.Drawing.Point(4, 27);
            this.MaterialTabPage.Name = "MaterialTabPage";
            this.MaterialTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MaterialTabPage.Size = new System.Drawing.Size(893, 669);
            this.MaterialTabPage.TabIndex = 1;
            this.MaterialTabPage.Text = "物料搬送";
            this.MaterialTabPage.UseVisualStyleBackColor = true;
            // 
            // ParamPage
            // 
            this.ParamPage.Controls.Add(this.MaterialgroupBox);
            this.ParamPage.Controls.Add(this.MaterialboxgroupBox);
            this.ParamPage.Location = new System.Drawing.Point(4, 27);
            this.ParamPage.Name = "ParamPage";
            this.ParamPage.Padding = new System.Windows.Forms.Padding(3);
            this.ParamPage.Size = new System.Drawing.Size(893, 787);
            this.ParamPage.TabIndex = 2;
            this.ParamPage.Text = "参数";
            this.ParamPage.UseVisualStyleBackColor = true;
            // 
            // MaterialboxgroupBox
            // 
            this.MaterialboxgroupBox.Location = new System.Drawing.Point(6, 7);
            this.MaterialboxgroupBox.Name = "MaterialboxgroupBox";
            this.MaterialboxgroupBox.Size = new System.Drawing.Size(881, 360);
            this.MaterialboxgroupBox.TabIndex = 0;
            this.MaterialboxgroupBox.TabStop = false;
            this.MaterialboxgroupBox.Text = "料盘参数";
            // 
            // MaterialgroupBox
            // 
            this.MaterialgroupBox.Location = new System.Drawing.Point(6, 373);
            this.MaterialgroupBox.Name = "MaterialgroupBox";
            this.MaterialgroupBox.Size = new System.Drawing.Size(881, 360);
            this.MaterialgroupBox.TabIndex = 1;
            this.MaterialgroupBox.TabStop = false;
            this.MaterialgroupBox.Text = "物料参数";
            // 
            // FrmEditTransportRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(925, 966);
            this.Controls.Add(this.TransportTab);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.teName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditTransportRecipe";
            this.Text = "传送配方";
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            this.TransportTab.ResumeLayout(false);
            this.ParamPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labName;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl TransportTab;
        private System.Windows.Forms.TabPage ParamPage;
        private System.Windows.Forms.TabPage MaterialboxTabPage;
        private System.Windows.Forms.TabPage MaterialTabPage;
        private System.Windows.Forms.GroupBox MaterialboxgroupBox;
        private System.Windows.Forms.GroupBox MaterialgroupBox;
    }
}