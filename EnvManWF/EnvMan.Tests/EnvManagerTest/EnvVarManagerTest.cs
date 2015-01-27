//------------------------------------------------------------------------
// <copyright file="EnvVarManagerTest.cs" company="SETCHIN Freelance Consulting">
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
    using System;
    using NUnit.Framework;
    using SFC.EnvMan;

    /// <summary>
    /// Environment Variable Manager Test Class
    /// </summary>
    [TestFixture]
    public class EnvVarManagerTest
    {
        /// <summary>
        /// Test User Variable 1
        /// </summary>
        private string testUserVarName = "TestUserVar1";

        /// <summary>
        /// Test User Variable Value
        /// </summary>
        private string testUserVarVal = @"%SystemRoot%\system32\cmd.exe";

        /// <summary>
        /// Test System Variable 1
        /// </summary>
        private string testSystemVarName = "TestSystemVar1";

        /// <summary>
        /// Test System Variable Value
        /// </summary>
        private string testSystemVarVal = @"%SystemRoot%\system32\cmd.exe";

        /// <summary>
        /// Environment Variable Manager
        /// </summary>
        private EnvVarManager variableManager = new EnvVarManager();

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.variableManager.SetEnvironmentVariable(
                this.testUserVarName,
                this.testUserVarVal, 
                EnvironmentVariableTarget.User);

            this.variableManager.SetEnvironmentVariable(
                this.testSystemVarName,
                this.testSystemVarVal,
                EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.variableManager.DeleteEnvironmentVariable(
                this.testUserVarName, EnvironmentVariableTarget.User);
            this.variableManager.DeleteEnvironmentVariable(
                this.testSystemVarName, EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        /// Tests the expand environment variable.
        /// </summary>
        [Test]
        public void TestExpandEnvironmentVariable()
        {
            string varVal = @"C:\Windows";
            this.variableManager.SetEnvironmentVariable(
                "TempDirVar", varVal, EnvironmentVariableTarget.User);

            this.variableManager.SetEnvironmentVariable(
                "TempExtandedDirVar", 
                @"%TempDirVar%\temp", 
                EnvironmentVariableTarget.User);

            string varExpandedVal 
                = this.variableManager.ExpandEnvironmentVariable(
                @"%TempDirVar%\temp");

            this.variableManager.DeleteEnvironmentVariable(
                "TempDirVar", EnvironmentVariableTarget.User);
            this.variableManager.DeleteEnvironmentVariable(
                "TempExtandedDirVar", EnvironmentVariableTarget.User);

            Assert.AreEqual(@"%TempDirVar%\temp", varExpandedVal);
        }

        /// <summary>
        /// Tests the get user environment variable.
        /// </summary>
        [Test]
        public void TestGetUserEnvironmentVariable()
        {
            string varVal 
                = this.variableManager.GetEnvironmentVariable(
                this.testUserVarName, EnvironmentVariableTarget.User);

            Assert.AreEqual(this.testUserVarVal, varVal);
        }

        /// <summary>
        /// Tests the name of the validate variables null var.
        /// </summary>
        [Test]
        [ExpectedException(ExpectedMessage = "Variable Name cannot be blank.")]
        public void TestValidateVariablesNullVarName()
        {
            ////this.variableManager.ValidateVariables(null, null);
        }

        /// <summary>
        /// Tests the validate variables empty variable value.
        /// </summary>
        [Test]
        [ExpectedException(ExpectedMessage = "Variable should have a value.")]
        public void TestValidateVariablesEmptyVarValue()
        {
            ////this.variableManager.ValidateVariables(
            ////    "TestVariable", string.Empty);
        }
    }
}
