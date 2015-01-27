//------------------------------------------------------------------------
// <copyright file="VersionInfoManager.cs" company="SETCHIN Freelance Consulting">
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
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Class for Saving and Loading Version Info from File
    /// </summary>
    public class VersionInfoManager
    {
        /// <summary>
        /// Version Information
        /// </summary>
        private VersionInfo versionInfo = new VersionInfo();

        /// <summary>
        /// Gets or sets the version information.
        /// </summary>
        /// <value>The version information.</value>
        public VersionInfo VersionInformation
        {
            get
            {
                return this.versionInfo;
            }

            set
            {
                this.versionInfo = value;
            }            
        }

        /// <summary>
        /// Saves VersionInfo into specified file.
        /// </summary>
        /// <param name="fileName">The filename.</param>
        public void Save(string fileName)
        {
            // Create a file stream object
            FileStream file = File.Create(fileName);

            // Start Serialization
            XmlSerializer xmlSerializer 
                = new XmlSerializer(this.versionInfo.GetType());
            xmlSerializer.Serialize(file, this.versionInfo);
            file.Close();
        }

        /// <summary>
        /// Loads VersionInfo from specified file.
        /// </summary>
        /// <param name="fileName">The filename.</param>
        public void Load(string fileName)
        {
            try
            {
                // Create a file stream object
                FileStream file = File.OpenRead(fileName);

                // Start Serialization
                XmlSerializer xmlSerializer
                    = new XmlSerializer(this.versionInfo.GetType());
                this.versionInfo 
                    = (VersionInfo)xmlSerializer.Deserialize(file);

                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
