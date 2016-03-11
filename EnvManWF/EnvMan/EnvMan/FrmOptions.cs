//------------------------------------------------------------------------
// <copyright file="FrmOptions.cs" company="SETCHIN Freelance Consulting">
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
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using SFC.EnvMan.Properties;

    /// <summary>
    /// Options Form
    /// </summary>
    public partial class FrmOptions : Form
    {
        #region Constants
        /// <summary>
        /// Default port for a proxy
        /// </summary>
        private const string DefaultProxyPort = "80";
        #endregion Constants

        #region Variables
        /// <summary>
        /// Proxy settings
        /// </summary>
        private ProxySettings proxySettings = ProxySettings.Default;

        /// <summary>
        /// Settings for Main Form
        /// </summary>
        private FrmMainSettings mainFormSettings = FrmMainSettings.Default;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmOptions"/> class.
        /// </summary>
        public FrmOptions()
        {
            this.InitializeComponent();

            this.LoadSettings();
        }
        #endregion Constructor

        #region Private Functions
        /// <summary>
        /// Handles the CheckedChanged event of the Check Box Use Proxy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CbUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            LblAddress.Enabled = this.CbUseProxy.Checked;
            TxtAddress.Enabled = this.CbUseProxy.Checked;
            LblPassword.Enabled = this.CbUseProxy.Checked;
            TxtPassword.Enabled = this.CbUseProxy.Checked;
            LblPasswordOptional.Enabled = this.CbUseProxy.Checked;
            LblPort.Enabled = this.CbUseProxy.Checked;
            TxtPort.Enabled = this.CbUseProxy.Checked;
            LblUserName.Enabled = this.CbUseProxy.Checked;
            TxtUserName.Enabled = this.CbUseProxy.Checked;
            LblUserNameOptional.Enabled = this.CbUseProxy.Checked;

            if (!this.CbUseProxy.Checked)
            {
                this.InitProxySettings();
            }
            else
            {
                this.LoadProxySettings();
            }
        }

        /// <summary>
        /// Clears proxy settings.
        /// </summary>
        private void InitProxySettings()
        {
            TxtAddress.Text = string.Empty;
            TxtPort.Text = DefaultProxyPort;
            TxtUserName.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            this.CbOneInstance.Checked = this.mainFormSettings.OnlyOneInstance;
            this.CbUseProxy.Checked = this.proxySettings.UseProxy;
            if (this.proxySettings.UseProxy)
            {
                this.LoadProxySettings();
            }
        }

        /// <summary>
        /// Loads the proxy settings.
        /// </summary>
        private void LoadProxySettings()
        {
            TxtAddress.Text = this.proxySettings.ServerAddress;
            TxtPort.Text = string.Empty + this.proxySettings.ServerPort;
            TxtUserName.Text = this.proxySettings.ServerUserName;
            TxtPassword.Text = this.proxySettings.ServerPassword;
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            this.mainFormSettings.OnlyOneInstance = this.CbOneInstance.Checked;

            // Proxy settings
            this.proxySettings.UseProxy = this.CbUseProxy.Checked;
            this.proxySettings.ServerAddress = TxtAddress.Text;
            this.proxySettings.ServerPort = TxtPort.Text;
            this.proxySettings.ServerUserName = TxtUserName.Text;
            this.proxySettings.ServerPassword = TxtPassword.Text;
            this.proxySettings.Save();
        }

        /// <summary>
        /// Handles the Click event of the Button OK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validate controls
            CancelEventArgs cancelEvent = new CancelEventArgs();
            this.TxtValidating(this.TxtAddress, cancelEvent);

            if (!cancelEvent.Cancel)
            {
                this.SaveSettings();
                this.Close();
            }
        }

        /// <summary>
        /// Validating Text Boxes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void TxtValidating(object sender, CancelEventArgs e)
        {
            // Validate Proxy
            if (CbUseProxy.Checked)
            {
                if (sender.Equals(this.TxtAddress))
                {
                    if (string.IsNullOrEmpty(this.TxtAddress.Text))
                    {
                        errorProvider.SetError(this.TxtAddress, "Address Cannot be Empty");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.Clear();
                    }
                }
                else if (sender.Equals(this.TxtPort))
                {
                    if (string.IsNullOrEmpty(this.TxtPort.Text))
                    {
                        errorProvider.SetError(this.TxtPort, "Server Port cannot be empty");
                        e.Cancel = true;
                    }
                }
            }
        }
        #endregion Private Functions
    }
}
