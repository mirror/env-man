//------------------------------------------------------------------------
// <copyright file="VersionInfoManagerTest.cs" company="SETCHIN Freelance Consulting">
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

namespace Envman.Tests.VersionManager.VersionInformation
{
    using System;
    using System.IO;
    using SFC.EnvMan.VersionManager.VersionInformation;
    using NUnit.Framework;

    /// <summary>
    /// Version Information Manager Tests
    /// </summary>
    [TestFixture]
    public class VersionInfoManagerTest
    {
        /// <summary>
        /// Version Information
        /// </summary>
        private VersionInfo versionInfo = null;

        /// <summary>
        /// Version Information Manager
        /// </summary>
        private VersionInfoManager versionInfoManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionInfoManagerTest"/> class.
        /// </summary>
        public VersionInfoManagerTest()
        {
            this.versionInfoManager = new VersionInfoManager();
            this.versionInfo = new VersionInfo();
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.versionInfo.AssemblyVersion = new Version(1, 3);
            this.versionInfo.DownloadWebpageAddress 
                = "http://env-man.blogspot.com/2007/04/envman-user-guide.html";
        }

        /// <summary>
        /// Tests the save version info.
        /// </summary>
        [Test]
        public void TestSaveVersionInfo()
        {
            // TODO: Change to save into temp file and dir
            this.versionInfoManager.VersionInformation = this.versionInfo;
            string fileName 
                = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData) 
                + "\\Anastasia_Corporation\\VersionInfo.aum";
            this.versionInfoManager.Save(fileName);

            Assert.IsTrue(File.Exists(fileName));
            File.Delete(fileName);
        }
    }
}
