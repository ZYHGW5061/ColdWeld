
namespace ControlPanelClsLib
{
    partial class FrmTemperatureControlPanel
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
            this.labPassWord = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.seTargetTemp = new DevExpress.XtraEditors.SpinEdit();
            this.seHeatPreservationMinute = new DevExpress.XtraEditors.SpinEdit();
            this.seOverTemperatureThreshold = new DevExpress.XtraEditors.SpinEdit();
            this.btnHeat = new System.Windows.Forms.Button();
            this.btnStopHeat = new System.Windows.Forms.Button();
            this.btnSelfTuning = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.BOUpHeatPID_D = new DevExpress.XtraEditors.SpinEdit();
            this.BOUpHeatPID_I = new DevExpress.XtraEditors.SpinEdit();
            this.BOUpHeatPID_P = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl44 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl43 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.seTargetTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHeatPreservationMinute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seOverTemperatureThreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOUpHeatPID_D.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOUpHeatPID_I.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOUpHeatPID_P.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labPassWord
            // 
            this.labPassWord.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labPassWord.Location = new System.Drawing.Point(121, 73);
            this.labPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.labPassWord.Name = "labPassWord";
            this.labPassWord.Size = new System.Drawing.Size(87, 18);
            this.labPassWord.TabIndex = 1;
            this.labPassWord.Text = "目标温度/℃:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl1.Location = new System.Drawing.Point(107, 116);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "保温时间/分钟:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl2.Location = new System.Drawing.Point(91, 159);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "超温报警温度/℃:";
            // 
            // seTargetTemp
            // 
            this.seTargetTemp.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTargetTemp.Location = new System.Drawing.Point(216, 69);
            this.seTargetTemp.Margin = new System.Windows.Forms.Padding(4);
            this.seTargetTemp.Name = "seTargetTemp";
            this.seTargetTemp.Properties.AutoHeight = false;
            this.seTargetTemp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTargetTemp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seTargetTemp.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seTargetTemp.Properties.MaskSettings.Set("mask", "n0");
            this.seTargetTemp.Size = new System.Drawing.Size(98, 27);
            this.seTargetTemp.TabIndex = 41;
            // 
            // seHeatPreservationMinute
            // 
            this.seHeatPreservationMinute.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seHeatPreservationMinute.Location = new System.Drawing.Point(216, 112);
            this.seHeatPreservationMinute.Margin = new System.Windows.Forms.Padding(4);
            this.seHeatPreservationMinute.Name = "seHeatPreservationMinute";
            this.seHeatPreservationMinute.Properties.AutoHeight = false;
            this.seHeatPreservationMinute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seHeatPreservationMinute.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seHeatPreservationMinute.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seHeatPreservationMinute.Properties.MaskSettings.Set("mask", "n0");
            this.seHeatPreservationMinute.Size = new System.Drawing.Size(98, 27);
            this.seHeatPreservationMinute.TabIndex = 42;
            // 
            // seOverTemperatureThreshold
            // 
            this.seOverTemperatureThreshold.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seOverTemperatureThreshold.Location = new System.Drawing.Point(216, 155);
            this.seOverTemperatureThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.seOverTemperatureThreshold.Name = "seOverTemperatureThreshold";
            this.seOverTemperatureThreshold.Properties.AutoHeight = false;
            this.seOverTemperatureThreshold.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seOverTemperatureThreshold.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seOverTemperatureThreshold.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seOverTemperatureThreshold.Properties.MaskSettings.Set("mask", "n0");
            this.seOverTemperatureThreshold.Size = new System.Drawing.Size(98, 27);
            this.seOverTemperatureThreshold.TabIndex = 43;
            // 
            // btnHeat
            // 
            this.btnHeat.Location = new System.Drawing.Point(356, 65);
            this.btnHeat.Name = "btnHeat";
            this.btnHeat.Size = new System.Drawing.Size(82, 35);
            this.btnHeat.TabIndex = 44;
            this.btnHeat.Text = "加热";
            this.btnHeat.UseVisualStyleBackColor = true;
            this.btnHeat.Click += new System.EventHandler(this.btnHeat_Click);
            // 
            // btnStopHeat
            // 
            this.btnStopHeat.Location = new System.Drawing.Point(356, 108);
            this.btnStopHeat.Name = "btnStopHeat";
            this.btnStopHeat.Size = new System.Drawing.Size(82, 35);
            this.btnStopHeat.TabIndex = 45;
            this.btnStopHeat.Text = "停止加热";
            this.btnStopHeat.UseVisualStyleBackColor = true;
            this.btnStopHeat.Click += new System.EventHandler(this.btnStopHeat_Click);
            // 
            // btnSelfTuning
            // 
            this.btnSelfTuning.Location = new System.Drawing.Point(356, 151);
            this.btnSelfTuning.Name = "btnSelfTuning";
            this.btnSelfTuning.Size = new System.Drawing.Size(82, 35);
            this.btnSelfTuning.TabIndex = 46;
            this.btnSelfTuning.Text = "自整定";
            this.btnSelfTuning.UseVisualStyleBackColor = true;
            this.btnSelfTuning.Click += new System.EventHandler(this.btnSelfTuning_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 199);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 47;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(356, 192);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(82, 35);
            this.btnSet.TabIndex = 48;
            this.btnSet.Text = "写入";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(444, 192);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(82, 35);
            this.btnGet.TabIndex = 49;
            this.btnGet.Text = "读取";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(216, 196);
            this.spinEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.AutoHeight = false;
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.MaskSettings.Set("mask", "n0");
            this.spinEdit1.Size = new System.Drawing.Size(98, 27);
            this.spinEdit1.TabIndex = 50;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "烘箱1下加热板",
            "烘箱1上加热板",
            "烘箱2下加热板",
            "烘箱2上加热板"});
            this.comboBox2.Location = new System.Drawing.Point(216, 30);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 51;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl3.Location = new System.Drawing.Point(129, 31);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 18);
            this.labelControl3.TabIndex = 52;
            this.labelControl3.Text = "当前温控表:";
            // 
            // BOUpHeatPID_D
            // 
            this.BOUpHeatPID_D.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BOUpHeatPID_D.Location = new System.Drawing.Point(217, 322);
            this.BOUpHeatPID_D.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BOUpHeatPID_D.Name = "BOUpHeatPID_D";
            this.BOUpHeatPID_D.Properties.AutoHeight = false;
            this.BOUpHeatPID_D.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BOUpHeatPID_D.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BOUpHeatPID_D.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BOUpHeatPID_D.Properties.MaskSettings.Set("mask", "n0");
            this.BOUpHeatPID_D.Size = new System.Drawing.Size(98, 27);
            this.BOUpHeatPID_D.TabIndex = 65;
            // 
            // BOUpHeatPID_I
            // 
            this.BOUpHeatPID_I.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BOUpHeatPID_I.Location = new System.Drawing.Point(216, 278);
            this.BOUpHeatPID_I.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BOUpHeatPID_I.Name = "BOUpHeatPID_I";
            this.BOUpHeatPID_I.Properties.AutoHeight = false;
            this.BOUpHeatPID_I.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BOUpHeatPID_I.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BOUpHeatPID_I.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BOUpHeatPID_I.Properties.MaskSettings.Set("mask", "n0");
            this.BOUpHeatPID_I.Size = new System.Drawing.Size(98, 27);
            this.BOUpHeatPID_I.TabIndex = 64;
            // 
            // BOUpHeatPID_P
            // 
            this.BOUpHeatPID_P.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BOUpHeatPID_P.Location = new System.Drawing.Point(216, 236);
            this.BOUpHeatPID_P.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BOUpHeatPID_P.Name = "BOUpHeatPID_P";
            this.BOUpHeatPID_P.Properties.AutoHeight = false;
            this.BOUpHeatPID_P.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BOUpHeatPID_P.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BOUpHeatPID_P.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BOUpHeatPID_P.Properties.MaskSettings.Set("mask", "n0");
            this.BOUpHeatPID_P.Size = new System.Drawing.Size(98, 27);
            this.BOUpHeatPID_P.TabIndex = 63;
            // 
            // labelControl44
            // 
            this.labelControl44.Location = new System.Drawing.Point(193, 326);
            this.labelControl44.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl44.Name = "labelControl44";
            this.labelControl44.Size = new System.Drawing.Size(10, 18);
            this.labelControl44.TabIndex = 62;
            this.labelControl44.Text = "D";
            // 
            // labelControl43
            // 
            this.labelControl43.Location = new System.Drawing.Point(193, 282);
            this.labelControl43.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl43.Name = "labelControl43";
            this.labelControl43.Size = new System.Drawing.Size(6, 18);
            this.labelControl43.TabIndex = 61;
            this.labelControl43.Text = "I";
            // 
            // labelControl42
            // 
            this.labelControl42.Location = new System.Drawing.Point(193, 240);
            this.labelControl42.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(8, 18);
            this.labelControl42.TabIndex = 60;
            this.labelControl42.Text = "P";
            // 
            // FrmTemperatureControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 377);
            this.Controls.Add(this.BOUpHeatPID_D);
            this.Controls.Add(this.BOUpHeatPID_I);
            this.Controls.Add(this.BOUpHeatPID_P);
            this.Controls.Add(this.labelControl44);
            this.Controls.Add(this.labelControl43);
            this.Controls.Add(this.labelControl42);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSelfTuning);
            this.Controls.Add(this.btnStopHeat);
            this.Controls.Add(this.btnHeat);
            this.Controls.Add(this.seOverTemperatureThreshold);
            this.Controls.Add(this.seHeatPreservationMinute);
            this.Controls.Add(this.seTargetTemp);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labPassWord);
            this.Name = "FrmTemperatureControlPanel";
            this.Text = "温控表测试";
            ((System.ComponentModel.ISupportInitialize)(this.seTargetTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seHeatPreservationMinute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seOverTemperatureThreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOUpHeatPID_D.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOUpHeatPID_I.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOUpHeatPID_P.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labPassWord;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit seTargetTemp;
        private DevExpress.XtraEditors.SpinEdit seHeatPreservationMinute;
        private DevExpress.XtraEditors.SpinEdit seOverTemperatureThreshold;
        private System.Windows.Forms.Button btnHeat;
        private System.Windows.Forms.Button btnStopHeat;
        private System.Windows.Forms.Button btnSelfTuning;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnGet;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private System.Windows.Forms.ComboBox comboBox2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit BOUpHeatPID_D;
        private DevExpress.XtraEditors.SpinEdit BOUpHeatPID_I;
        private DevExpress.XtraEditors.SpinEdit BOUpHeatPID_P;
        private DevExpress.XtraEditors.LabelControl labelControl44;
        private DevExpress.XtraEditors.LabelControl labelControl43;
        private DevExpress.XtraEditors.LabelControl labelControl42;
    }
}