//------------------------------------------------------------------------
// <copyright file="FrmMain.Designer.cs" company="SETCHIN Freelance Consulting">
// Copyright (C) 2006-2016 SETCHIN Freelance Consulting
// </copyright>
// <author>
// Vlad Setchin
// </author>
//------------------------------------------------------------------------

// EnvMan - The Open-Source Environment Variables Manager
// Copyright (C) 2006-2016 SETCHIN Freelance Consulting 
// <http://www.setchinfc.com.au>
// EnvMan Development Group: <mailto:envman-dev@googlegroups.com>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace SFC.EnvMan
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.TsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiProjectiWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiForum = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiJoinForum = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAskAQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiForumWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiPostFeedbackOrBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiNewVersionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.envManager = new EnvManager();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            //
            // msMain
            //
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiFile,
            this.TsmiHelp,
            this.TsmiNewVersionInfo});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(369, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            //
            // TsmiFile
            //
            this.TsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiSettings,
            this.toolStripMenuItem3,
            this.TsmiExit});
            this.TsmiFile.Name = "TsmiFile";
            this.TsmiFile.Size = new System.Drawing.Size(37, 20);
            this.TsmiFile.Text = "&File";
            //
            // TsmiSettings
            //
            this.TsmiSettings.Name = "TsmiSettings";
            this.TsmiSettings.Size = new System.Drawing.Size(133, 22);
            this.TsmiSettings.Text = "Settings...";
            this.TsmiSettings.Click += new System.EventHandler(this.TsmiClick);
            //
            // toolStripMenuItem3
            //
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(130, 6);
            //
            // TsmiExit
            //
            this.TsmiExit.Image = global::SFC.EnvMan.Properties.Resources.ShutDown;
            this.TsmiExit.Name = "TsmiExit";
            this.TsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.TsmiExit.Size = new System.Drawing.Size(133, 22);
            this.TsmiExit.Text = "E&xit";
            this.TsmiExit.ToolTipText = "Close Application";
            this.TsmiExit.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiHelp
            //
            this.TsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiProjectiWebsite,
            this.TsmiForum,
            this.TsmiDonate,
            this.TsmiPostFeedbackOrBugReport,
            this.toolStripMenuItem2,
            this.TsmiLanguage,
            this.TsmiCheckForUpdates,
            this.toolStripMenuItem1,
            this.TsmiAbout});
            this.TsmiHelp.Name = "TsmiHelp";
            this.TsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.TsmiHelp.Text = "&Help";
            this.TsmiHelp.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiProjectiWebsite
            //
            this.TsmiProjectiWebsite.Image = global::SFC.EnvMan.Properties.Resources.Website;
            this.TsmiProjectiWebsite.Name = "TsmiProjectiWebsite";
            this.TsmiProjectiWebsite.Size = new System.Drawing.Size(233, 22);
            this.TsmiProjectiWebsite.Text = "EnvMan &Project Website...";
            this.TsmiProjectiWebsite.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiForum
            //
            this.TsmiForum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiJoinForum,
            this.TsmiAskAQuestion,
            this.TsmiForumWebsite});
            this.TsmiForum.Image = global::SFC.EnvMan.Properties.Resources.News;
            this.TsmiForum.Name = "TsmiForum";
            this.TsmiForum.Size = new System.Drawing.Size(233, 22);
            this.TsmiForum.Text = "EnvMan &Forum...";
            //
            // TsmiJoinForum
            //
            this.TsmiJoinForum.Image = global::SFC.EnvMan.Properties.Resources.Members;
            this.TsmiJoinForum.Name = "TsmiJoinForum";
            this.TsmiJoinForum.Size = new System.Drawing.Size(163, 22);
            this.TsmiJoinForum.Text = "&Join Forum...";
            this.TsmiJoinForum.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiAskAQuestion
            //
            this.TsmiAskAQuestion.Image = global::SFC.EnvMan.Properties.Resources.Mail;
            this.TsmiAskAQuestion.Name = "TsmiAskAQuestion";
            this.TsmiAskAQuestion.Size = new System.Drawing.Size(163, 22);
            this.TsmiAskAQuestion.Text = "Ask a &Question...";
            this.TsmiAskAQuestion.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiForumWebsite
            //
            this.TsmiForumWebsite.Image = global::SFC.EnvMan.Properties.Resources.Forum;
            this.TsmiForumWebsite.Name = "TsmiForumWebsite";
            this.TsmiForumWebsite.Size = new System.Drawing.Size(163, 22);
            this.TsmiForumWebsite.Text = "Forum Website...";
            this.TsmiForumWebsite.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiDonate
            //
            this.TsmiDonate.Image = global::SFC.EnvMan.Properties.Resources.SupportProject;
            this.TsmiDonate.Name = "TsmiDonate";
            this.TsmiDonate.Size = new System.Drawing.Size(233, 22);
            this.TsmiDonate.Text = "&Support this Project...";
            this.TsmiDonate.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiPostFeedbackOrBugReport
            //
            this.TsmiPostFeedbackOrBugReport.Image = global::SFC.EnvMan.Properties.Resources.SendFeedback;
            this.TsmiPostFeedbackOrBugReport.Name = "TsmiPostFeedbackOrBugReport";
            this.TsmiPostFeedbackOrBugReport.Size = new System.Drawing.Size(233, 22);
            this.TsmiPostFeedbackOrBugReport.Text = "Post feedback or bug report ...";
            this.TsmiPostFeedbackOrBugReport.Click += new System.EventHandler(this.TsmiClick);
            //
            // toolStripMenuItem2
            //
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(230, 6);
            //
            // TsmiLanguage
            //
            this.TsmiLanguage.Image = global::SFC.EnvMan.Properties.Resources.Language;
            this.TsmiLanguage.Name = "TsmiLanguage";
            this.TsmiLanguage.Size = new System.Drawing.Size(233, 22);
            this.TsmiLanguage.Text = "&Language";
            this.TsmiLanguage.Visible = false;
            //
            // TsmiCheckForUpdates
            //
            this.TsmiCheckForUpdates.Image = global::SFC.EnvMan.Properties.Resources.Updates;
            this.TsmiCheckForUpdates.Name = "TsmiCheckForUpdates";
            this.TsmiCheckForUpdates.Size = new System.Drawing.Size(233, 22);
            this.TsmiCheckForUpdates.Text = "Check for &Updates...";
            this.TsmiCheckForUpdates.Click += new System.EventHandler(this.TsmiClick);
            //
            // toolStripMenuItem1
            //
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(230, 6);
            //
            // TsmiAbout
            //
            this.TsmiAbout.Image = global::SFC.EnvMan.Properties.Resources.EnvManAbout;
            this.TsmiAbout.Name = "TsmiAbout";
            this.TsmiAbout.Size = new System.Drawing.Size(233, 22);
            this.TsmiAbout.Text = "&About";
            this.TsmiAbout.Click += new System.EventHandler(this.TsmiClick);
            //
            // TsmiNewVersionInfo
            //
            this.TsmiNewVersionInfo.Image = global::SFC.EnvMan.Properties.Resources.Updates;
            this.TsmiNewVersionInfo.Name = "TsmiNewVersionInfo";
            this.TsmiNewVersionInfo.Size = new System.Drawing.Size(101, 20);
            this.TsmiNewVersionInfo.Text = " Version Info";
            this.TsmiNewVersionInfo.Visible = false;
            this.TsmiNewVersionInfo.Click += new System.EventHandler(this.TsmiClick);
            //
            // tsMain
            //
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus});
            this.tsMain.Location = new System.Drawing.Point(0, 392);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(369, 22);
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "statusStrip1";
            //
            // tslblStatus
            //
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(0, 17);
            //
            // envManager
            //
            this.envManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.envManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.envManager.Location = new System.Drawing.Point(2, 27);
            this.envManager.Name = "envManager";
            this.envManager.Size = new System.Drawing.Size(364, 362);
            this.envManager.TabIndex = 0;
            //
            // FrmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 414);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.envManager);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MainMenuStrip = this.msMain;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Environment Variables";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SFC.EnvMan.EnvManager envManager;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem TsmiFile;
        private System.Windows.Forms.ToolStripMenuItem TsmiExit;
        private System.Windows.Forms.ToolStripMenuItem TsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem TsmiAbout;
        private System.Windows.Forms.StatusStrip tsMain;
        private System.Windows.Forms.ToolStripMenuItem TsmiForum;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TsmiLanguage;
        private System.Windows.Forms.ToolStripMenuItem TsmiCheckForUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TsmiPostFeedbackOrBugReport;
        private System.Windows.Forms.ToolStripMenuItem TsmiDonate;
        private System.Windows.Forms.ToolStripMenuItem TsmiProjectiWebsite;
        private System.Windows.Forms.ToolStripMenuItem TsmiJoinForum;
        private System.Windows.Forms.ToolStripMenuItem TsmiAskAQuestion;
        private System.Windows.Forms.ToolStripMenuItem TsmiForumWebsite;
        private System.Windows.Forms.ToolStripMenuItem TsmiNewVersionInfo;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.ToolStripMenuItem TsmiSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}
