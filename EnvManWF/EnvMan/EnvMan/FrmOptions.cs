//------------------------------------------------------------------------
// <copyright file="FrmOptions.cs" company="SETCHIN Freelance Consulting">
// Copyright (C) 2006-2013 SETCHIN Freelance Consulting
// </copyright>
// <author>
// Vlad Setchin
// </author>
//------------------------------------------------------------------------

// EnvMan - The Open-Source Windows Environment Variables Manager
// Copyright (C) 2006-2013 SETCHIN Freelance Consulting 
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

namespace Envman
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using Envman.Properties;

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
        /// Handles the CheckedChanged event of the CbUseProxy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CbUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            LblAddress.Enabled = CbUseProxy.Checked;
            TxtAddress.Enabled = CbUseProxy.Checked;
            LblPassword.Enabled = CbUseProxy.Checked;
            TxtPassword.Enabled = CbUseProxy.Checked;
            LblPasswordOptional.Enabled = CbUseProxy.Checked;
            LblPort.Enabled = CbUseProxy.Checked;
            TxtPort.Enabled = CbUseProxy.Checked;
            LblUserName.Enabled = CbUseProxy.Checked;
            TxtUserName.Enabled = CbUseProxy.Checked;
            LblUserNameOptional.Enabled = CbUseProxy.Checked;

            if (!CbUseProxy.Checked)
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
            this.mainFormSettings.OnlyOneInstance = CbOneInstance.Checked;

            // Proxy settings
            this.proxySettings.UseProxy = CbUseProxy.Checked;
            this.proxySettings.ServerAddress = TxtAddress.Text;
            this.proxySettings.ServerPort = TxtPort.Text;
            this.proxySettings.ServerUserName = TxtUserName.Text;
            this.proxySettings.ServerPassword = TxtPassword.Text;
            this.proxySettings.Save();
        }

        /// <summary>
        /// Handles the Click event of the BtnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validate controls
            CancelEventArgs cancelEvent = new CancelEventArgs();
            this.TxtValidating(TxtAddress, cancelEvent);

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
                if (sender.Equals(TxtAddress))
                {
                    if (string.IsNullOrEmpty(TxtAddress.Text))
                    {
                        errorProvider.SetError(TxtAddress, "Address Cannot be Empty");
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider.Clear();
                    }
                }
                else if (sender.Equals(TxtPort))
                {
                    if (string.IsNullOrEmpty(TxtPort.Text))
                    {
                        errorProvider.SetError(TxtPort, "Server Port cannot be empty");
                        e.Cancel = true;
                    }
                }
            }
        }
        #endregion Private Functions
    }
}
