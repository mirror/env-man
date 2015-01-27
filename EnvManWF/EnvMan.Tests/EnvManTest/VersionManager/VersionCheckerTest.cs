//------------------------------------------------------------------------
// <copyright file="VersionCheckerTest.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.Tests.VersionManager
{
    using System;

    using SFC.EnvMan.VersionManager;
    using SFC.EnvMan.VersionManager.VersionInformation;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Version Checker
    /// </summary>
    [TestFixture]
    public class VersionCheckerTest
    {
        #region Variables
        /// <summary>
        /// Version Checker
        /// </summary>
        private VersionChecker versionChecker = null;

        /// <summary>
        /// Version Information
        /// </summary>
        private VersionInfo versionInfo = new VersionInfo();
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionCheckerTest"/> class.
        /// </summary>
        public VersionCheckerTest()
        {
            this.versionChecker = new VersionChecker(
                Properties.Resources.ProgramICO);
        }
        #endregion Constructor

        #region Public Functions
        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.versionInfo.AssemblyVersion = new Version(1, 3, 0, 0);
            this.versionInfo.DownloadWebpageAddress = string.Empty;
            this.versionChecker.VersionChecked
                += new EventHandler<NewVersionEventArgs>(
                    this.VersionChecker_VersionChecked);
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.versionChecker.VersionChecked
                += new EventHandler<NewVersionEventArgs>(
                    this.VersionChecker_VersionChecked);
        }

        /// <summary>
        /// Tests the download file.
        /// </summary>
        [Test]
        public void TestDownloadFile()
        {
            Uri address
                = new Uri("http://env-man.sourceforge.net/img/FrmMain.JPG");
            string localFileNamePath = "MainForm.jpg";
            Assert.IsTrue(
                this.versionChecker.DownloadFile(address, localFileNamePath));
        }

        //// TODO: work with these tests

        /// <summary>
        /// Tests the Auto Check for a new version.
        /// </summary>
        [Test]
        public void TestCheckVersionAutoNew()
        {
            this.versionInfo.AssemblyVersion = new Version(1, 2, 0, 0);
            this.versionChecker.CheckVersion(this.versionInfo);
        }

        /// <summary>
        /// Tests the Auto Check for latest (current) version.
        /// </summary>
        [Test]
        public void TestCheckVersionAutoLatest()
        {
            this.versionChecker.CheckVersion(this.versionInfo);
        }

        /// <summary>
        /// Tests the manual check for latest (current) version.
        /// </summary>
        [Test]
        public void TestCheckVersionManualLatest()
        {
            this.versionChecker.CheckVersion(this.versionInfo);
        }

        /// <summary>
        /// Tests the manual check for new version.
        /// </summary>
        [Test]
        public void TestCheckVersionManualNew()
        {
            this.versionChecker.CheckVersion(this.versionInfo);
        }      
        #endregion Public Functions

        #region Private Functions
        /// <summary>
        /// Handles the VersionChecked event of the versionChecker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SFC.EnvMan.VersionManager.NewVersionEventArgs"/> instance containing the event data.</param>
        private void VersionChecker_VersionChecked(
            object sender, NewVersionEventArgs e)
        {
        }
        #endregion Private Functions
    }
}
