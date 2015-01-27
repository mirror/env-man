//------------------------------------------------------------------------
// <copyright file="VersionChecker.cs" company="SETCHIN Freelance Consulting">
// Copyright (C) 2006-2015 SETCHIN Freelance Consulting
// </copyright>
// <author>
// Vlad Setchin
// </author>
//------------------------------------------------------------------------

// EnvMan - The Open-Source Environment Variables Manager
// Copyright (C) 2006-2015 SETCHIN Freelance Consulting 
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

namespace SFC.EnvMan.VersionManager
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using SFC.EnvMan.VersionManager.VersionInformation;

    /// <summary>
    /// Version Checker Class
    /// </summary>
    public class VersionChecker
    {
        #region Variables
        /// <summary>
        /// Program Icon
        /// </summary>
        private Icon programIcon = null;

        /// <summary>
        /// Version Information Manager
        /// </summary>
        private VersionInfoManager versionInfoManager = null;

        /// <summary>
        /// Internet Web Client
        /// </summary>
        private WebClient webClient = null;

        /// <summary>
        /// Application Proxy Settings
        /// </summary>
        private Properties.ProxySettings proxySettings
            = Properties.ProxySettings.Default;

        /// <summary>
        /// Internet Web proxy
        /// </summary>
        private WebProxy proxy = null;

        /// <summary>
        /// Version Information
        /// </summary>
        private VersionInfo versionInfo = null;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionChecker"/> class.
        /// </summary>
        public VersionChecker()
        {
            this.InitVersionChecker();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionChecker"/> class.
        /// </summary>
        /// <param name="programIcon">The program icon.</param>
        public VersionChecker(Icon programIcon)
        {
            this.programIcon = programIcon;

            this.InitVersionChecker();
        }
        #endregion Constructor

        #region Events
        /// <summary>
        /// Occurs when [version checked].
        /// </summary>
        public event EventHandler<NewVersionEventArgs> VersionChecked;
        #endregion Events

        #region Public Functions
        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="fileWebAddress">The file web address.</param>
        /// <param name="localFilePath">The local file path.</param>
        /// <returns>True - File Downloaded, False - not downloaded</returns>
        public bool DownloadFile(Uri fileWebAddress, string localFilePath)
        {
            bool result = false;
            try
            {
                this.webClient.DownloadFile(
                    fileWebAddress, localFilePath);

                result = true;
            }
            catch (System.Net.WebException ex)
            {
                throw new WebException(
                    "Could not get new version info. "
                    + "Please check your network and proxy settings.", 
                    ex);
            }

            return result;
        }

        /// <summary>
        /// Checks the version.
        /// </summary>
        /// <param name="localVersionInfo">The local version info.</param>
        public void CheckVersion(VersionInfo localVersionInfo)
        {
            string webServer = "http://env-man.sourceforge.net/";
#if DEBUG
            string webFileName = "EnvMan.Debug";
#else
            string webFileName = "EnvMan.Release";
#endif
            string webFile = webServer + webFileName;

            this.CheckVersion(localVersionInfo, webFile);
        }

        /// <summary>
        /// Initialises the proxy settings.
        /// </summary>
        public void InitProxySettings()
        {
            try
            {   // Assign Proxy Server
                if (this.proxySettings.UseProxy)
                {
                    this.proxy 
                        = new WebProxy(
                            this.proxySettings.ServerAddress,
                            int.Parse(this.proxySettings.ServerPort));
                    this.webClient.Proxy = this.proxy;
                }
                else
                {
                    this.webClient.Proxy = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to set Proxy Server. " + ex.Message);
            }
        }
        #endregion Public Functions
        
        #region Private Functions
        /// <summary>
        /// Initialises the version checker.
        /// </summary>
        private void InitVersionChecker()
        {
            this.webClient = new WebClient();

            // InitProxySettings();
            this.versionInfoManager = new VersionInfoManager();
        }

        /// <summary>
        /// Checks the version.
        /// </summary>
        /// <param name="localVersionInfo">The local version info.</param>
        /// <param name="remoteFile">The remote file.</param>
#if DEBUG
        public void CheckVersion(VersionInfo localVersionInfo, string remoteFile)
#else
        private void CheckVersion(VersionInfo localVersionInfo, string remoteFile)
#endif
        {
            Uri webFile = new Uri(remoteFile);
            string localFile = System.IO.Path.GetTempFileName();

            if (this.DownloadFile(webFile, localFile))
            {
                string message = string.Empty;
                this.versionInfoManager.Load(localFile);
                this.versionInfo = this.versionInfoManager.VersionInformation;
                bool newVersion = false;

                if (localVersionInfo.AssemblyVersion
                    != this.versionInfo.AssemblyVersion)
                {
                    newVersion = true;
                }

                if (this.VersionChecked != null)
                {
                    NewVersionEventArgs e = new NewVersionEventArgs();
                    e.NewVersion = newVersion;
                    e.VersionInformation = this.versionInfo;
                    this.VersionChecked(this, e);
                }
            }

            File.Delete(localFile);
        }
        #endregion Private Functions
    }
}
