namespace NBTExplorer.Windows
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.settingTabControl = new System.Windows.Forms.TabControl();
            this.generalSettingTabPage = new System.Windows.Forms.TabPage();
            this.graphicsSettingsTabPage = new System.Windows.Forms.TabPage();
            this.settingTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingTabControl
            // 
            this.settingTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.settingTabControl.Controls.Add(this.generalSettingTabPage);
            this.settingTabControl.Controls.Add(this.graphicsSettingsTabPage);
            this.settingTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingTabControl.Location = new System.Drawing.Point(0, 0);
            this.settingTabControl.Multiline = true;
            this.settingTabControl.Name = "settingTabControl";
            this.settingTabControl.SelectedIndex = 0;
            this.settingTabControl.Size = new System.Drawing.Size(434, 436);
            this.settingTabControl.TabIndex = 1;
            // 
            // generalSettingTabPage
            // 
            this.generalSettingTabPage.Location = new System.Drawing.Point(25, 4);
            this.generalSettingTabPage.Name = "generalSettingTabPage";
            this.generalSettingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalSettingTabPage.Size = new System.Drawing.Size(405, 428);
            this.generalSettingTabPage.TabIndex = 0;
            this.generalSettingTabPage.Text = "General";
            this.generalSettingTabPage.UseVisualStyleBackColor = true;
            // 
            // graphicsSettingsTabPage
            // 
            this.graphicsSettingsTabPage.Location = new System.Drawing.Point(25, 4);
            this.graphicsSettingsTabPage.Name = "graphicsSettingsTabPage";
            this.graphicsSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.graphicsSettingsTabPage.Size = new System.Drawing.Size(405, 428);
            this.graphicsSettingsTabPage.TabIndex = 1;
            this.graphicsSettingsTabPage.Text = "Graphics";
            this.graphicsSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 436);
            this.Controls.Add(this.settingTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings - NBTExplorer 2.0";
            this.settingTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl settingTabControl;
        private System.Windows.Forms.TabPage generalSettingTabPage;
        private System.Windows.Forms.TabPage graphicsSettingsTabPage;
    }
}