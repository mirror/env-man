//------------------------------------------------------------------------
// <copyright file="FrmMain.cs" company="SETCHIN Freelance Consulting">
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
    using SFC.EnvMan.VersionManager;
    using SFC.EnvMan.VersionManager.VersionInformation;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Main Form Class
    /// </summary>
    public partial class FrmMain : Form
    {
        #region Variables
        /// <summary>
        /// Background worker
        /// </summary>
        private BackgroundWorker worker = null;

        /// <summary>
        /// Version Checker
        /// </summary>
        private VersionChecker versionChecker = null;

        /// <summary>
        /// Version Information
        /// </summary>
        private VersionInfo versionInfo = null;

        /// <summary>
        /// Indicates if Form Version Information need to be shown
        /// </summary>
        private bool showFrmVersionInfo = false;

        /// <summary>
        /// About Form
        /// </summary>
        private FrmAbout frmAbout = null;

        /// <summary>
        /// Current Application Version Information
        /// </summary>
        private VersionInfo currentVersionInfo = new VersionInfo();

        /// <summary>
        /// Main Form Settings
        /// </summary>
        private Properties.FrmMainSettings settings
            = Properties.FrmMainSettings.Default;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMain"/> class.
        /// </summary>
        public FrmMain()
        {
            this.InitializeComponent();

            this.frmAbout = new FrmAbout();
            this.Text += " " + this.frmAbout.PackageVersion;
            this.MinimumSize = new Size(472, 504);

            this.versionChecker
                = new VersionChecker(Properties.Resources.EnvManICO);
            this.versionChecker.VersionChecked
                += new EventHandler<NewVersionEventArgs>(
                    this.VersionChecker_NewVersionChecked);

            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(this.WorkerDoWork);

            this.LoadSettings();
        }
        #endregion Constructor

        #region Private Functions
        /// <summary>
        /// Handles the DoWork event of the worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            this.showFrmVersionInfo = sender == null;

            this.currentVersionInfo.AssemblyVersion
                = this.frmAbout.AssemblyVersion;
            try
            {
                this.versionChecker.InitProxySettings();
                this.versionChecker.CheckVersion(this.currentVersionInfo);
            }
            catch (Exception ex)
            {
                this.tslblStatus.Text = ex.Message;

                // show error to user in MessageBox
                if (this.showFrmVersionInfo)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Network Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }

            if (e != null)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Version Checker Handler for version checks.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Envman.VersionManager.NewVersionEventArgs"/> instance containing the event data.</param>
        private void VersionChecker_NewVersionChecked(
            object sender, NewVersionEventArgs e)
        {
            string msg = string.Empty;

            if (e.NewVersion)
            {
                this.versionInfo = e.VersionInformation;
                msg = "New version " + VersionInfo.VersionFormatter(
                    this.versionInfo.AssemblyVersion) + " released";
                this.TsmiNewVersionInfo.Text = msg;
                this.TsmiNewVersionInfo.Visible = true;

                if (this.showFrmVersionInfo)
                {
                    FrmVersionInfo versionInfoForm = new FrmVersionInfo();
                    versionInfoForm.Icon = Properties.Resources.EnvManICO;
                    versionInfoForm.Message = msg;
                    if (versionInfoForm.ShowDialog() == DialogResult.OK)
                    {
                        this.TsmiClick(this.TsmiNewVersionInfo, null);
                    }
                }
            }
            else
            {
                msg = "You have the current version.";
                if (this.showFrmVersionInfo)
                {
                    MessageBox.Show(
                        msg,
                        "EnvMan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Handles the FormClosed event of the Form Main control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// Tool Strip Menu Item click Handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TsmiClick(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.TsmiExit))
                {
                    Application.Exit();
                }
                else if (sender.Equals(this.TsmiAbout))
                {
                    this.frmAbout.ShowDialog();
                }
                else if (sender.Equals(this.TsmiDonate))
                {
                    System.Diagnostics.Process.Start(
                        @"http://env-man.blogspot.com/2007/12/donate.html");
                }
                else if (sender.Equals(this.TsmiPostFeedbackOrBugReport))
                {
                    System.Diagnostics.Process.Start(
                        @"http://sourceforge.net/tracker/?group_id=193626");
                }
                else if (sender.Equals(this.TsmiProjectiWebsite))
                {
                    System.Diagnostics.Process.Start(
                @"http://env-man.blogspot.com/2007/04/envman-user-guide.html");
                }
                else if (sender.Equals(this.TsmiForumWebsite))
                {
                    System.Diagnostics.Process.Start(
                        @"http://groups.google.com/group/envman-bug");
                }
                else if (sender.Equals(this.TsmiDonate))
                {
                    System.Diagnostics.Process.Start(
                        @"http://env-man.blogspot.com/2007/12/donate.html");
                }
                else if (sender.Equals(this.TsmiPostFeedbackOrBugReport))
                {
                    System.Diagnostics.Process.Start(
                        @"http://sourceforge.net/tracker/?group_id=193626");
                }
                else if (sender.Equals(this.TsmiProjectiWebsite))
                {
                    System.Diagnostics.Process.Start(
            @"http://env-man.blogspot.com/2007/04/envman-user-guide.html");
                }
                else if (sender.Equals(this.TsmiJoinForum))
                {
                    System.Diagnostics.Process.Start(
                        "mailto:envman-subscribe@googlegroups.com");
                }
                else if (sender.Equals(this.TsmiAskAQuestion))
                {
                    System.Diagnostics.Process.Start(
                        "mailto:envman-dev@googlegroups.com");
                }
                else if (sender.Equals(this.TsmiCheckForUpdates))
                {
                    Application.DoEvents();
                    this.WorkerDoWork(null, null);
                }
                else if (sender.Equals(this.TsmiNewVersionInfo))
                {
                    System.Diagnostics.Process.Start(
                        this.versionInfo.DownloadWebpageAddress);
                }
                else if (sender.Equals(this.TsmiSettings))
                {
                    FrmOptions settingsForm = new FrmOptions();
                    settingsForm.ShowDialog();
                    settingsForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                //// TODO: Review what Exceptions could be raised in this method
                MessageBox.Show(
                    ex.Message,
                    "EnvMan ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Shown event of the Form Main control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            this.worker.RunWorkerAsync();
            Application.DoEvents();
        }

        #region Settings
        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (this.settings.FrmWindowState == FormWindowState.Normal)
                {
                    this.Location = this.settings.FrmWindowLocation;
                    this.Size = this.settings.FrmSize;
                }
                else
                {
                    this.WindowState = this.settings.FrmWindowState;
                }
            }
            catch (Exception)
            {
                // load default settings
                this.Location = new Point(10, 10);
                this.Size = new Size(377, 448);

                // save default settings
                this.SaveSettings();
            }

        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.settings.FrmWindowLocation = this.Location;
                this.settings.FrmSize = this.Size;
            }
            else
            {
                this.settings.FrmWindowState = this.WindowState;
            }

            this.settings.Save();
        }
        #endregion Settings
        #endregion Private Functions
    }
}
