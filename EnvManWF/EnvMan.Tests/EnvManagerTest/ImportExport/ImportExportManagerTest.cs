//------------------------------------------------------------------------
// <copyright file="ImportExportManagerTest.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.Tests.ImportExport
{
    using System.IO;

    using global::SFC.EnvMan.ImportExport;
    using NUnit.Framework;

    /// <summary>
    /// Test Import Export Manager
    /// </summary>
    [TestFixture]
    public class ImportExportManagerTest
    {
        /// <summary>
        /// temp file name
        /// </summary>
        private const string FileName = @"C:\EnvVarTest.env";

        /// <summary>
        /// Import Export Manager class
        /// </summary>
        private ImportExportManager importExportManager
            = new ImportExportManager();

        /// <summary>
        /// Environment Variable
        /// </summary>
        private EnvironmentVariable envVar = new EnvironmentVariable();

        /// <summary>
        /// Finalizes an instance of the <see cref="ImportExportManagerTest"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ImportExportManagerTest"/> is reclaimed by garbage collection.
        /// </summary>
        ~ImportExportManagerTest()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }

        /// <summary>
        /// Sets up tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.envVar.VarName = "TestVar";
            this.envVar.VarValues = "Val1;Val2;Val3";
        }

        /// <summary>
        /// Tests the save.
        /// </summary>
        [Test]
        public void TestSave()
        {
            this.importExportManager.EnvVariable = this.envVar;
            this.importExportManager.Save(FileName);
            Assert.IsTrue(File.Exists(FileName));
        }

        /// <summary>
        /// Tests the load.
        /// </summary>
        [Test]
        public void TestLoad()
        {
            this.TestSave();
            this.importExportManager.Load(FileName);
            Assert.AreEqual(
                this.envVar.VarName, 
                this.importExportManager.EnvVariable.VarName);
            Assert.AreEqual(
                this.envVar.VarValuesList[0],
                this.importExportManager.EnvVariable.VarValuesList[0]);
            Assert.AreEqual(
                this.envVar.VarValuesList[1],
                this.importExportManager.EnvVariable.VarValuesList[1]);
            Assert.AreEqual(
                this.envVar.VarValuesList[2],
                this.importExportManager.EnvVariable.VarValuesList[2]);
        }
    }
}
