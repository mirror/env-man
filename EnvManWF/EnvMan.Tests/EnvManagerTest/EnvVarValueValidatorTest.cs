//------------------------------------------------------------------------
// <copyright file="EnvVarValueValidatorTest.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.Tests
{
    using System.IO;
    using NUnit.Framework;
    using SFC.EnvMan;

    /// <summary>
    /// Test Environment Variable Value Validator
    /// </summary>
    [TestFixture]
    public class EnvVarValueValidatorTest
    {
        /// <summary>
        /// Environment Variable Validator
        /// </summary>
        private EnvVarValueValidator validator = null;

        /// <summary>
        /// Sets up tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.validator = new EnvVarValueValidator();
        }

        #region Tests
        /// <summary>
        /// Tests the full type of the number.
        /// </summary>
        [Test]
        public void TestFullNumberType()
        {
            EnvironmentValueType type = this.validator.ValueType("10");

            Assert.AreEqual(EnvironmentValueType.Number, type);
        }

        /// <summary>
        /// Tests the type of the float number.
        /// </summary>
        [Test]
        public void TestFloatNumberType()
        {
            EnvironmentValueType type = this.validator.ValueType("10.50");

            Assert.AreEqual(EnvironmentValueType.Number, type);
        }

        /// <summary>
        /// Tests the type of the folder.
        /// </summary>
        [Test]
        public void TestFolderType()
        {
            EnvironmentValueType type 
                = this.validator.ValueType(@"C:\Windows");

            Assert.AreEqual(EnvironmentValueType.Folder, type);
        }

        /// <summary>
        /// Tests the type of the error.
        /// </summary>
        [Test]
        public void TestErrorType()
        {
            EnvironmentValueType type 
                = this.validator.ValueType(@"C:\12345");

            Assert.AreEqual(EnvironmentValueType.Error, type);
        }

        /// <summary>
        /// Tests the type of the string.
        /// </summary>
        [Test]
        public void TestStringType()
        {
            EnvironmentValueType type
                = this.validator.ValueType("This is a string value");

            Assert.AreEqual(EnvironmentValueType.String, type);
        }

        /// <summary>
        /// Tests the type of the file.
        /// </summary>
        [Test]
        public void TestFileType()
        {
            string fileName = @"C:\EnvMan.test";

            // create temp file for a test
            FileStream file = File.Create(fileName);
            file.Close();

            // Test
            EnvironmentValueType type = this.validator.ValueType(fileName);

            Assert.AreEqual(EnvironmentValueType.File, type);

            // remove temp file after completing a test
            File.Delete(fileName);            
        }
        #endregion Tests
    }
}
