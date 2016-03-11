//------------------------------------------------------------------------
// <copyright file="FrmAbout.cs" company="SETCHIN Freelance Consulting">
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
    using System.Reflection;
    using System.Windows.Forms;
    using SFC.EnvMan.VersionManager.VersionInformation;

    /// <summary>
    /// About Form
    /// </summary>
    public partial class FrmAbout : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAbout"/> class.
        /// </summary>
        public FrmAbout()
        {
            this.InitializeComponent();

            this.Text = string.Format("About {0}", this.AssemblyTitle);
            this.lblProductName.Text = this.AssemblyProduct;
            this.lblVersion.Text
                = string.Format(
                "Version {0} (Build {1})",
                this.PackageVersion,
                this.AssemblyVersion);
            this.lblCopyright.Text = this.AssemblyCopyright;
            this.txtDescription.Text = this.AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        /// <summary>
        /// Gets the assembly title.
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

                    // If it is not an empty string, return it
                    if (!string.IsNullOrEmpty(titleAttribute.Title))
                    {
                        return titleAttribute.Title;
                    }
                }

                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Gets the package version.
        /// </summary>
        public string PackageVersion
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;

                return VersionInfo.VersionFormatter(version);
            }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public Version AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// Gets the assembly description.
        /// </summary>
        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes
                    = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyDescriptionAttribute), false);

                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the assembly file version.
        /// </summary>
        /// <value>The assembly file version.</value>
        public string AssemblyFileVersion
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);

                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Description attribute, return its value
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }

        /// <summary>
        /// Gets the assembly informational version.
        /// </summary>
        /// <value>The assembly informational version.</value>
        public string AssemblyInformationalVersion
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);

                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Description attribute, return its value
                return ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
            }
        }

        /// <summary>
        /// Gets the assembly product.
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the assembly copyright.
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Gets the assembly company.
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }

                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}