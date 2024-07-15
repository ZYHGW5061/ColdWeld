
namespace VisionGUI
{
    partial class VisualMatchControlGUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.RingLightBar = new System.Windows.Forms.TrackBar();
            this.RingLightlabel = new System.Windows.Forms.Label();
            this.DirectLightlabel = new System.Windows.Forms.Label();
            this.DirectLightBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.QualityBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.AngleBar = new System.Windows.Forms.TrackBar();
            this.RoiGroupBox = new System.Windows.Forms.GroupBox();
            this.VisualRoiTab = new System.Windows.Forms.TabControl();
            this.TemplatePage = new System.Windows.Forms.TabPage();
            this.SetBenchmarkBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BenchmarkYtextBox = new System.Windows.Forms.TextBox();
            this.BenchmarkXtextBox = new System.Windows.Forms.TextBox();
            this.TemplateResizeBtn = new DevExpress.XtraEditors.CheckButton();
            this.TemplateMoveBtn = new DevExpress.XtraEditors.CheckButton();
            this.TemplateRoiShowBtn = new System.Windows.Forms.CheckBox();
            this.SearchAreaPage = new System.Windows.Forms.TabPage();
            this.SearchAreaResizeBtn = new DevExpress.XtraEditors.CheckButton();
            this.SearchAreaMoveBtn = new DevExpress.XtraEditors.CheckButton();
            this.SearchAreaRoiShowBtn = new System.Windows.Forms.CheckBox();
            this.MatchPage = new System.Windows.Forms.TabPage();
            this.OutlineRotateBtn = new DevExpress.XtraEditors.CheckButton();
            this.OutlineMoveBtn = new DevExpress.XtraEditors.CheckButton();
            this.OutlineShowBtn = new System.Windows.Forms.CheckBox();
            this.TemplateBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.CameraWindowClearBtn = new System.Windows.Forms.Button();
            this.RingLightNumlabel = new System.Windows.Forms.Label();
            this.DirectLightNumlabel = new System.Windows.Forms.Label();
            this.MinimunqualityNumlabel = new System.Windows.Forms.Label();
            this.AngleDeviationNumlabel = new System.Windows.Forms.Label();
            this.panelStepOperate = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.RingLightBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DirectLightBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleBar)).BeginInit();
            this.RoiGroupBox.SuspendLayout();
            this.VisualRoiTab.SuspendLayout();
            this.TemplatePage.SuspendLayout();
            this.SearchAreaPage.SuspendLayout();
            this.MatchPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelStepOperate)).BeginInit();
            this.panelStepOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // RingLightBar
            // 
            this.RingLightBar.Location = new System.Drawing.Point(17, 30);
            this.RingLightBar.Maximum = 254;
            this.RingLightBar.Name = "RingLightBar";
            this.RingLightBar.Size = new System.Drawing.Size(312, 45);
            this.RingLightBar.TabIndex = 0;
            this.RingLightBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RingLightBar.Scroll += new System.EventHandler(this.RingLightBar_Scroll);
            // 
            // RingLightlabel
            // 
            this.RingLightlabel.AutoSize = true;
            this.RingLightlabel.Location = new System.Drawing.Point(15, 9);
            this.RingLightlabel.Name = "RingLightlabel";
            this.RingLightlabel.Size = new System.Drawing.Size(43, 14);
            this.RingLightlabel.TabIndex = 1;
            this.RingLightlabel.Text = "环光源";
            // 
            // DirectLightlabel
            // 
            this.DirectLightlabel.AutoSize = true;
            this.DirectLightlabel.Location = new System.Drawing.Point(15, 64);
            this.DirectLightlabel.Name = "DirectLightlabel";
            this.DirectLightlabel.Size = new System.Drawing.Size(43, 14);
            this.DirectLightlabel.TabIndex = 3;
            this.DirectLightlabel.Text = "点光源";
            // 
            // DirectLightBar
            // 
            this.DirectLightBar.Location = new System.Drawing.Point(17, 84);
            this.DirectLightBar.Maximum = 254;
            this.DirectLightBar.Name = "DirectLightBar";
            this.DirectLightBar.Size = new System.Drawing.Size(312, 45);
            this.DirectLightBar.TabIndex = 2;
            this.DirectLightBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DirectLightBar.Scroll += new System.EventHandler(this.DirectLightBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "分数阈值";
            // 
            // QualityBar
            // 
            this.QualityBar.Location = new System.Drawing.Point(17, 143);
            this.QualityBar.Maximum = 100;
            this.QualityBar.Name = "QualityBar";
            this.QualityBar.Size = new System.Drawing.Size(312, 45);
            this.QualityBar.TabIndex = 4;
            this.QualityBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.QualityBar.Value = 90;
            this.QualityBar.Scroll += new System.EventHandler(this.QualityBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "角度范围";
            // 
            // AngleBar
            // 
            this.AngleBar.Location = new System.Drawing.Point(17, 198);
            this.AngleBar.Maximum = 180;
            this.AngleBar.Name = "AngleBar";
            this.AngleBar.Size = new System.Drawing.Size(312, 45);
            this.AngleBar.TabIndex = 6;
            this.AngleBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AngleBar.Value = 15;
            this.AngleBar.Scroll += new System.EventHandler(this.AngleBar_Scroll);
            // 
            // RoiGroupBox
            // 
            this.RoiGroupBox.Controls.Add(this.VisualRoiTab);
            this.RoiGroupBox.Location = new System.Drawing.Point(21, 226);
            this.RoiGroupBox.Name = "RoiGroupBox";
            this.RoiGroupBox.Size = new System.Drawing.Size(308, 187);
            this.RoiGroupBox.TabIndex = 8;
            this.RoiGroupBox.TabStop = false;
            this.RoiGroupBox.Text = "ROI";
            // 
            // VisualRoiTab
            // 
            this.VisualRoiTab.Controls.Add(this.TemplatePage);
            this.VisualRoiTab.Controls.Add(this.SearchAreaPage);
            this.VisualRoiTab.Controls.Add(this.MatchPage);
            this.VisualRoiTab.Location = new System.Drawing.Point(8, 24);
            this.VisualRoiTab.Name = "VisualRoiTab";
            this.VisualRoiTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VisualRoiTab.SelectedIndex = 0;
            this.VisualRoiTab.Size = new System.Drawing.Size(293, 155);
            this.VisualRoiTab.TabIndex = 0;
            this.VisualRoiTab.SelectedIndexChanged += new System.EventHandler(this.VisualRoiTab_SelectedIndexChanged);
            this.VisualRoiTab.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VisualRoiTab_KeyDown);
            // 
            // TemplatePage
            // 
            this.TemplatePage.Controls.Add(this.SetBenchmarkBtn);
            this.TemplatePage.Controls.Add(this.label4);
            this.TemplatePage.Controls.Add(this.label2);
            this.TemplatePage.Controls.Add(this.BenchmarkYtextBox);
            this.TemplatePage.Controls.Add(this.BenchmarkXtextBox);
            this.TemplatePage.Controls.Add(this.TemplateResizeBtn);
            this.TemplatePage.Controls.Add(this.TemplateMoveBtn);
            this.TemplatePage.Controls.Add(this.TemplateRoiShowBtn);
            this.TemplatePage.Location = new System.Drawing.Point(4, 23);
            this.TemplatePage.Name = "TemplatePage";
            this.TemplatePage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.TemplatePage.Size = new System.Drawing.Size(285, 128);
            this.TemplatePage.TabIndex = 0;
            this.TemplatePage.Text = "轮廓区域";
            this.TemplatePage.UseVisualStyleBackColor = true;
            // 
            // SetBenchmarkBtn
            // 
            this.SetBenchmarkBtn.Location = new System.Drawing.Point(210, 26);
            this.SetBenchmarkBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetBenchmarkBtn.Name = "SetBenchmarkBtn";
            this.SetBenchmarkBtn.Size = new System.Drawing.Size(66, 23);
            this.SetBenchmarkBtn.TabIndex = 7;
            this.SetBenchmarkBtn.Text = "设置";
            this.SetBenchmarkBtn.UseVisualStyleBackColor = true;
            this.SetBenchmarkBtn.Click += new System.EventHandler(this.SetBenchmarkBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "基准点:  X";
            // 
            // BenchmarkYtextBox
            // 
            this.BenchmarkYtextBox.Location = new System.Drawing.Point(158, 29);
            this.BenchmarkYtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BenchmarkYtextBox.Name = "BenchmarkYtextBox";
            this.BenchmarkYtextBox.Size = new System.Drawing.Size(42, 22);
            this.BenchmarkYtextBox.TabIndex = 4;
            this.BenchmarkYtextBox.Text = "-1";
            this.BenchmarkYtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BenchmarkXtextBox
            // 
            this.BenchmarkXtextBox.Location = new System.Drawing.Point(84, 29);
            this.BenchmarkXtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BenchmarkXtextBox.Name = "BenchmarkXtextBox";
            this.BenchmarkXtextBox.Size = new System.Drawing.Size(42, 22);
            this.BenchmarkXtextBox.TabIndex = 3;
            this.BenchmarkXtextBox.Text = "-1";
            this.BenchmarkXtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TemplateResizeBtn
            // 
            this.TemplateResizeBtn.Location = new System.Drawing.Point(150, 54);
            this.TemplateResizeBtn.Name = "TemplateResizeBtn";
            this.TemplateResizeBtn.Size = new System.Drawing.Size(126, 62);
            this.TemplateResizeBtn.TabIndex = 2;
            this.TemplateResizeBtn.Text = "Resize";
            this.TemplateResizeBtn.CheckedChanged += new System.EventHandler(this.TemplateResizeBtn_CheckedChanged);
            // 
            // TemplateMoveBtn
            // 
            this.TemplateMoveBtn.Location = new System.Drawing.Point(8, 54);
            this.TemplateMoveBtn.Name = "TemplateMoveBtn";
            this.TemplateMoveBtn.Size = new System.Drawing.Size(126, 62);
            this.TemplateMoveBtn.TabIndex = 1;
            this.TemplateMoveBtn.Text = "Move";
            this.TemplateMoveBtn.CheckedChanged += new System.EventHandler(this.TemplateMoveBtn_CheckedChanged);
            // 
            // TemplateRoiShowBtn
            // 
            this.TemplateRoiShowBtn.AutoSize = true;
            this.TemplateRoiShowBtn.Location = new System.Drawing.Point(8, 7);
            this.TemplateRoiShowBtn.Name = "TemplateRoiShowBtn";
            this.TemplateRoiShowBtn.Size = new System.Drawing.Size(73, 18);
            this.TemplateRoiShowBtn.TabIndex = 0;
            this.TemplateRoiShowBtn.Text = "RoiShow";
            this.TemplateRoiShowBtn.UseVisualStyleBackColor = true;
            this.TemplateRoiShowBtn.CheckedChanged += new System.EventHandler(this.TemplateRoiShowBtn_CheckedChanged);
            // 
            // SearchAreaPage
            // 
            this.SearchAreaPage.Controls.Add(this.SearchAreaResizeBtn);
            this.SearchAreaPage.Controls.Add(this.SearchAreaMoveBtn);
            this.SearchAreaPage.Controls.Add(this.SearchAreaRoiShowBtn);
            this.SearchAreaPage.Location = new System.Drawing.Point(4, 23);
            this.SearchAreaPage.Name = "SearchAreaPage";
            this.SearchAreaPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.SearchAreaPage.Size = new System.Drawing.Size(285, 128);
            this.SearchAreaPage.TabIndex = 1;
            this.SearchAreaPage.Text = "搜索区域";
            this.SearchAreaPage.UseVisualStyleBackColor = true;
            // 
            // SearchAreaResizeBtn
            // 
            this.SearchAreaResizeBtn.Location = new System.Drawing.Point(150, 54);
            this.SearchAreaResizeBtn.Name = "SearchAreaResizeBtn";
            this.SearchAreaResizeBtn.Size = new System.Drawing.Size(126, 62);
            this.SearchAreaResizeBtn.TabIndex = 5;
            this.SearchAreaResizeBtn.Text = "Resize";
            this.SearchAreaResizeBtn.CheckedChanged += new System.EventHandler(this.SearchAreaResizeBtn_CheckedChanged);
            // 
            // SearchAreaMoveBtn
            // 
            this.SearchAreaMoveBtn.Location = new System.Drawing.Point(8, 54);
            this.SearchAreaMoveBtn.Name = "SearchAreaMoveBtn";
            this.SearchAreaMoveBtn.Size = new System.Drawing.Size(126, 62);
            this.SearchAreaMoveBtn.TabIndex = 4;
            this.SearchAreaMoveBtn.Text = "Move";
            this.SearchAreaMoveBtn.CheckedChanged += new System.EventHandler(this.SearchAreaMoveBtn_CheckedChanged);
            // 
            // SearchAreaRoiShowBtn
            // 
            this.SearchAreaRoiShowBtn.AutoSize = true;
            this.SearchAreaRoiShowBtn.Location = new System.Drawing.Point(8, 7);
            this.SearchAreaRoiShowBtn.Name = "SearchAreaRoiShowBtn";
            this.SearchAreaRoiShowBtn.Size = new System.Drawing.Size(73, 18);
            this.SearchAreaRoiShowBtn.TabIndex = 3;
            this.SearchAreaRoiShowBtn.Text = "RoiShow";
            this.SearchAreaRoiShowBtn.UseVisualStyleBackColor = true;
            this.SearchAreaRoiShowBtn.CheckedChanged += new System.EventHandler(this.SearchAreaRoiShowBtn_CheckedChanged);
            // 
            // MatchPage
            // 
            this.MatchPage.Controls.Add(this.OutlineRotateBtn);
            this.MatchPage.Controls.Add(this.OutlineMoveBtn);
            this.MatchPage.Controls.Add(this.OutlineShowBtn);
            this.MatchPage.Location = new System.Drawing.Point(4, 23);
            this.MatchPage.Name = "MatchPage";
            this.MatchPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.MatchPage.Size = new System.Drawing.Size(285, 128);
            this.MatchPage.TabIndex = 2;
            this.MatchPage.Text = "轮廓匹配";
            this.MatchPage.UseVisualStyleBackColor = true;
            // 
            // OutlineRotateBtn
            // 
            this.OutlineRotateBtn.Location = new System.Drawing.Point(150, 54);
            this.OutlineRotateBtn.Name = "OutlineRotateBtn";
            this.OutlineRotateBtn.Size = new System.Drawing.Size(126, 62);
            this.OutlineRotateBtn.TabIndex = 7;
            this.OutlineRotateBtn.Text = "Rotate";
            // 
            // OutlineMoveBtn
            // 
            this.OutlineMoveBtn.Location = new System.Drawing.Point(8, 54);
            this.OutlineMoveBtn.Name = "OutlineMoveBtn";
            this.OutlineMoveBtn.Size = new System.Drawing.Size(126, 62);
            this.OutlineMoveBtn.TabIndex = 6;
            this.OutlineMoveBtn.Text = "Move";
            // 
            // OutlineShowBtn
            // 
            this.OutlineShowBtn.AutoSize = true;
            this.OutlineShowBtn.Location = new System.Drawing.Point(8, 7);
            this.OutlineShowBtn.Name = "OutlineShowBtn";
            this.OutlineShowBtn.Size = new System.Drawing.Size(65, 18);
            this.OutlineShowBtn.TabIndex = 4;
            this.OutlineShowBtn.Text = "Outline";
            this.OutlineShowBtn.UseVisualStyleBackColor = true;
            this.OutlineShowBtn.CheckedChanged += new System.EventHandler(this.OutlineShowBtn_CheckedChanged);
            // 
            // TemplateBtn
            // 
            this.TemplateBtn.Location = new System.Drawing.Point(26, 419);
            this.TemplateBtn.Name = "TemplateBtn";
            this.TemplateBtn.Size = new System.Drawing.Size(300, 36);
            this.TemplateBtn.TabIndex = 9;
            this.TemplateBtn.Text = "Template";
            this.TemplateBtn.UseVisualStyleBackColor = true;
            this.TemplateBtn.Click += new System.EventHandler(this.TemplateBtn_ClickAsync);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(26, 465);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(300, 36);
            this.SearchBtn.TabIndex = 10;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // CameraWindowClearBtn
            // 
            this.CameraWindowClearBtn.Location = new System.Drawing.Point(26, 512);
            this.CameraWindowClearBtn.Name = "CameraWindowClearBtn";
            this.CameraWindowClearBtn.Size = new System.Drawing.Size(300, 36);
            this.CameraWindowClearBtn.TabIndex = 11;
            this.CameraWindowClearBtn.Text = "Clear";
            this.CameraWindowClearBtn.UseVisualStyleBackColor = true;
            this.CameraWindowClearBtn.Click += new System.EventHandler(this.CameraWindowClearBtn_Click);
            // 
            // RingLightNumlabel
            // 
            this.RingLightNumlabel.AutoSize = true;
            this.RingLightNumlabel.Location = new System.Drawing.Point(302, 9);
            this.RingLightNumlabel.Name = "RingLightNumlabel";
            this.RingLightNumlabel.Size = new System.Drawing.Size(14, 14);
            this.RingLightNumlabel.TabIndex = 12;
            this.RingLightNumlabel.Text = "0";
            // 
            // DirectLightNumlabel
            // 
            this.DirectLightNumlabel.AutoSize = true;
            this.DirectLightNumlabel.Location = new System.Drawing.Point(302, 64);
            this.DirectLightNumlabel.Name = "DirectLightNumlabel";
            this.DirectLightNumlabel.Size = new System.Drawing.Size(14, 14);
            this.DirectLightNumlabel.TabIndex = 13;
            this.DirectLightNumlabel.Text = "0";
            // 
            // MinimunqualityNumlabel
            // 
            this.MinimunqualityNumlabel.AutoSize = true;
            this.MinimunqualityNumlabel.Location = new System.Drawing.Point(302, 125);
            this.MinimunqualityNumlabel.Name = "MinimunqualityNumlabel";
            this.MinimunqualityNumlabel.Size = new System.Drawing.Size(25, 14);
            this.MinimunqualityNumlabel.TabIndex = 14;
            this.MinimunqualityNumlabel.Text = "0.9";
            // 
            // AngleDeviationNumlabel
            // 
            this.AngleDeviationNumlabel.AutoSize = true;
            this.AngleDeviationNumlabel.Location = new System.Drawing.Point(302, 181);
            this.AngleDeviationNumlabel.Name = "AngleDeviationNumlabel";
            this.AngleDeviationNumlabel.Size = new System.Drawing.Size(21, 14);
            this.AngleDeviationNumlabel.TabIndex = 15;
            this.AngleDeviationNumlabel.Text = "15";
            // 
            // panelStepOperate
            // 
            this.panelStepOperate.Controls.Add(this.AngleDeviationNumlabel);
            this.panelStepOperate.Controls.Add(this.RingLightlabel);
            this.panelStepOperate.Controls.Add(this.MinimunqualityNumlabel);
            this.panelStepOperate.Controls.Add(this.DirectLightNumlabel);
            this.panelStepOperate.Controls.Add(this.DirectLightlabel);
            this.panelStepOperate.Controls.Add(this.RingLightNumlabel);
            this.panelStepOperate.Controls.Add(this.CameraWindowClearBtn);
            this.panelStepOperate.Controls.Add(this.label3);
            this.panelStepOperate.Controls.Add(this.SearchBtn);
            this.panelStepOperate.Controls.Add(this.TemplateBtn);
            this.panelStepOperate.Controls.Add(this.label1);
            this.panelStepOperate.Controls.Add(this.RoiGroupBox);
            this.panelStepOperate.Controls.Add(this.RingLightBar);
            this.panelStepOperate.Controls.Add(this.DirectLightBar);
            this.panelStepOperate.Controls.Add(this.QualityBar);
            this.panelStepOperate.Controls.Add(this.AngleBar);
            this.panelStepOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStepOperate.Location = new System.Drawing.Point(0, 0);
            this.panelStepOperate.Name = "panelStepOperate";
            this.panelStepOperate.Size = new System.Drawing.Size(344, 558);
            this.panelStepOperate.TabIndex = 39;
            // 
            // VisualMatchControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelStepOperate);
            this.Name = "VisualMatchControlGUI";
            this.Size = new System.Drawing.Size(344, 558);
            ((System.ComponentModel.ISupportInitialize)(this.RingLightBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DirectLightBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleBar)).EndInit();
            this.RoiGroupBox.ResumeLayout(false);
            this.VisualRoiTab.ResumeLayout(false);
            this.TemplatePage.ResumeLayout(false);
            this.TemplatePage.PerformLayout();
            this.SearchAreaPage.ResumeLayout(false);
            this.SearchAreaPage.PerformLayout();
            this.MatchPage.ResumeLayout(false);
            this.MatchPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelStepOperate)).EndInit();
            this.panelStepOperate.ResumeLayout(false);
            this.panelStepOperate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar RingLightBar;
        private System.Windows.Forms.Label RingLightlabel;
        private System.Windows.Forms.Label DirectLightlabel;
        private System.Windows.Forms.TrackBar DirectLightBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar QualityBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar AngleBar;
        private System.Windows.Forms.GroupBox RoiGroupBox;
        private System.Windows.Forms.TabControl VisualRoiTab;
        private System.Windows.Forms.TabPage TemplatePage;
        private System.Windows.Forms.TabPage SearchAreaPage;
        private DevExpress.XtraEditors.CheckButton TemplateMoveBtn;
        private System.Windows.Forms.CheckBox TemplateRoiShowBtn;
        private DevExpress.XtraEditors.CheckButton TemplateResizeBtn;
        private DevExpress.XtraEditors.CheckButton SearchAreaResizeBtn;
        private DevExpress.XtraEditors.CheckButton SearchAreaMoveBtn;
        private System.Windows.Forms.CheckBox SearchAreaRoiShowBtn;
        private System.Windows.Forms.Button TemplateBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button CameraWindowClearBtn;
        private System.Windows.Forms.TabPage MatchPage;
        private System.Windows.Forms.CheckBox OutlineShowBtn;
        private DevExpress.XtraEditors.CheckButton OutlineRotateBtn;
        private DevExpress.XtraEditors.CheckButton OutlineMoveBtn;
        private System.Windows.Forms.Label RingLightNumlabel;
        private System.Windows.Forms.Label DirectLightNumlabel;
        private System.Windows.Forms.Label MinimunqualityNumlabel;
        private System.Windows.Forms.Label AngleDeviationNumlabel;
        private DevExpress.XtraEditors.PanelControl panelStepOperate;
        private System.Windows.Forms.TextBox BenchmarkXtextBox;
        private System.Windows.Forms.TextBox BenchmarkYtextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SetBenchmarkBtn;
    }
}
