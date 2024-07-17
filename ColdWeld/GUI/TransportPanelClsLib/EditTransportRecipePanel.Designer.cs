
namespace TransportPanelClsLib
{
    partial class EditTransportRecipePanel
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
            this.TransportTab = new System.Windows.Forms.TabControl();
            this.MaterialboxTabPage = new System.Windows.Forms.TabPage();
            this.MaterialTabPage = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TransportTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TransportTab
            // 
            this.TransportTab.Controls.Add(this.MaterialboxTabPage);
            this.TransportTab.Controls.Add(this.MaterialTabPage);
            this.TransportTab.Location = new System.Drawing.Point(3, 98);
            this.TransportTab.Name = "TransportTab";
            this.TransportTab.Padding = new System.Drawing.Point(320, 3);
            this.TransportTab.SelectedIndex = 0;
            this.TransportTab.Size = new System.Drawing.Size(1438, 775);
            this.TransportTab.TabIndex = 0;
            // 
            // MaterialboxTabPage
            // 
            this.MaterialboxTabPage.Location = new System.Drawing.Point(4, 25);
            this.MaterialboxTabPage.Name = "MaterialboxTabPage";
            this.MaterialboxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MaterialboxTabPage.Size = new System.Drawing.Size(1430, 746);
            this.MaterialboxTabPage.TabIndex = 0;
            this.MaterialboxTabPage.Text = "料盒搬送";
            this.MaterialboxTabPage.UseVisualStyleBackColor = true;
            // 
            // MaterialTabPage
            // 
            this.MaterialTabPage.Location = new System.Drawing.Point(4, 25);
            this.MaterialTabPage.Name = "MaterialTabPage";
            this.MaterialTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MaterialTabPage.Size = new System.Drawing.Size(1430, 746);
            this.MaterialTabPage.TabIndex = 1;
            this.MaterialTabPage.Text = "物料搬送";
            this.MaterialTabPage.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 25);
            this.textBox1.TabIndex = 1;
            // 
            // EditTransportRecipePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TransportTab);
            this.Name = "EditTransportRecipePanel";
            this.Size = new System.Drawing.Size(1444, 876);
            this.TransportTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage MaterialboxTabPage;
        private System.Windows.Forms.TabPage MaterialTabPage;
        private System.Windows.Forms.TabControl TransportTab;
        private System.Windows.Forms.TextBox textBox1;
    }
}
