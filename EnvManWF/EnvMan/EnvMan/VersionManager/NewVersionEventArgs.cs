//------------------------------------------------------------------------
// <copyright file="NewVersionEventArgs.cs" company="SETCHIN Freelance Consulting">
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
    using SFC.EnvMan.VersionManager.VersionInformation;

    /// <summary>
    /// New Version Event Arguments
    /// </summary>
    public class NewVersionEventArgs : EventArgs
    {
        /// <summary>
        /// Indicates if new version
        /// </summary>
        private bool newVersion = false;

        /// <summary>
        /// Version Information
        /// </summary>
        private VersionInfo versionInfo;
        
        /// <summary>
        /// Gets or sets a value indicating whether [new version].
        /// </summary>
        /// <value><c>true</c> if [new version]; otherwise, <c>false</c>.</value>
        public bool NewVersion
        {
            get
            {
                return this.newVersion;
            }

            set
            {
                this.newVersion = value;
            }            
        }
                
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
    }
}
