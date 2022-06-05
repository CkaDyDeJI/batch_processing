﻿namespace batch_processing
{
    partial class MainForm
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.firstProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.fileStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.secondProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbModuleChoice = new System.Windows.Forms.ToolStripComboBox();
            this.workingDirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.stackedLayout = new batch_processing.StackedLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.stackedLayout);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(800, 401);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(800, 450);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.firstProgress,
            this.fileStatusLabel,
            this.secondProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // firstProgress
            // 
            this.firstProgress.Name = "firstProgress";
            this.firstProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // fileStatusLabel
            // 
            this.fileStatusLabel.Name = "fileStatusLabel";
            this.fileStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // secondProgress
            // 
            this.secondProgress.Name = "secondProgress";
            this.secondProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runMenuItem,
            this.cbModuleChoice,
            this.workingDirMenu,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runMenuItem
            // 
            this.runMenuItem.Name = "runMenuItem";
            this.runMenuItem.Size = new System.Drawing.Size(74, 23);
            this.runMenuItem.Text = "Запустить";
            this.runMenuItem.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // cbModuleChoice
            // 
            this.cbModuleChoice.Items.AddRange(new object[] {
            "Стартовый",
            "Изображения",
            "Видео",
            "Аудио",
            "Документы"});
            this.cbModuleChoice.Name = "cbModuleChoice";
            this.cbModuleChoice.Size = new System.Drawing.Size(121, 23);
            this.cbModuleChoice.SelectedIndexChanged += new System.EventHandler(this.cbModuleChoice_SelectedIndexChanged);
            // 
            // workingDirMenu
            // 
            this.workingDirMenu.Name = "workingDirMenu";
            this.workingDirMenu.Size = new System.Drawing.Size(205, 23);
            this.workingDirMenu.Text = "Установить рабочую директорию";
            this.workingDirMenu.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 23);
            this.toolStripMenuItem1.Text = "about";
            // 
            // stackedLayout
            // 
            this.stackedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackedLayout.Location = new System.Drawing.Point(0, 0);
            this.stackedLayout.Name = "stackedLayout";
            this.stackedLayout.Size = new System.Drawing.Size(800, 401);
            this.stackedLayout.TabIndex = 0;
            this.stackedLayout.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.stackedLayout_PreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox cbModuleChoice;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private StackedLayout stackedLayout;
        private System.Windows.Forms.ToolStripMenuItem runMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workingDirMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar firstProgress;
        private System.Windows.Forms.ToolStripProgressBar secondProgress;
        private System.Windows.Forms.ToolStripStatusLabel fileStatusLabel;
    }
}

