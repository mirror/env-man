//------------------------------------------------------------------------
// <copyright file="VersionInfo.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.VersionManager.VersionInformation
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Version Information
    /// </summary>
    [Serializable]
    public class VersionInfo
    {
        #region Variables
        /// <summary>
        /// Web Page Address for program download
        /// </summary>
        private string downloadWebpageAddress = string.Empty;

        /// <summary>
        /// Major Version Number
        /// </summary>
        private int major = -1;

        /// <summary>
        /// Minor Version Number
        /// </summary>
        private int minor = -1;

        /// <summary>
        /// Build Version Number
        /// </summary>
        private int build = -1;

        /// <summary>
        /// Revision Version Number
        /// </summary>
        private int revision = -1;
        #endregion Variables

        #region Properties
        /// <summary>
        /// Gets or sets the download web page address.
        /// </summary>
        /// <value>The download web page address.</value>
        public string DownloadWebpageAddress
        {
            get { return this.downloadWebpageAddress; }
            set { this.downloadWebpageAddress = value; }
        }

        /// <summary>
        /// Gets or sets the major version number.
        /// </summary>
        /// <value>The major version number.</value>
        public int Major
        {
            get { return this.major; }
            set { this.major = value; }
        }
                
        /// <summary>
        /// Gets or sets the minor version number.
        /// </summary>
        /// <value>The minor.</value>
        public int Minor
        {
            get { return this.minor; }
            set { this.minor = value; }
        }

        /// <summary>
        /// Gets or sets the build version number.
        /// </summary>
        /// <value>The build version number.</value>
        public int Build
        {
            get { return this.build; }
            set { this.build = value; }
        }
        
        /// <summary>
        /// Gets or sets the revision version number.
        /// </summary>
        /// <value>The revision version number.</value>
        public int Revision
        {
            get { return this.revision; }
            set { this.revision = value; }
        }

        /// <summary>
        /// Gets or sets the assembly version.
        /// </summary>
        /// <value>
        /// The assembly version.
        /// </value>
        [XmlIgnore]
        public Version AssemblyVersion
        {
            get
            {
                return new Version(
                    this.major, this.minor, this.build, this.revision);
            }

            set
            {
                this.major = value.Major;
                this.minor = value.Minor;
                this.build = value.Build;
                this.revision = value.Revision;
            }
        }
        #endregion Properties

        #region Public Static Functions
        /// <summary>
        /// Formats Version Information for displaying.
        /// </summary>
        /// <param name="version">The version information to display.</param>
        /// <returns>formatted version info</returns>
        public static string VersionFormatter(Version version)
        {
            string versionSeperator = ".";

            string build = (version.Build == 0)
                    ? string.Empty : versionSeperator + version.Build;
            string revision = (version.Revision == 0) ? string.Empty
                : " RC" + version.Revision;
            string packageVersion = "V" + version.Major + versionSeperator
                + version.Minor + build + revision;

            return packageVersion;
        }
        #endregion Public Static Functions
    }
}
