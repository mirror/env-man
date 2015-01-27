//------------------------------------------------------------------------
// <copyright file="EnvironmentVariableTest.cs" company="SETCHIN Freelance Consulting">
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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using global::SFC.EnvMan.ImportExport;
    using NUnit.Framework;

    /// <summary>
    /// Test for Environment Variable Class
    /// </summary>
    [TestFixture]
    public class EnvironmentVariableTest
    {
        #region Constants
        /// <summary>
        /// Variable Name
        /// </summary>
        private const string VarName = "TestVarName";

        /// <summary>
        /// Variable One
        /// </summary>
        private const string Var1 = "Val1";

        /// <summary>
        /// Variable Two
        /// </summary>
        private const string Var2 = "Val2";

        /// <summary>
        /// Variable Three
        /// </summary>
        private const string Var3 = "Val3";
        #endregion Constants

        #region Variables
        /// <summary>
        /// List of Variable Values
        /// </summary>
        private string varValues = Var1 + ";" + Var2 + ";" + Var3;

        /// <summary>
        /// Environment Variables
        /// </summary>
        private EnvironmentVariable envVar = new EnvironmentVariable();
        #endregion Variables

        #region Public Functions
        /// <summary>
        /// Tests the name of the var.
        /// </summary>
        [Test]
        public void TestVarName()
        {
            this.envVar.VarName = VarName;
            Assert.AreEqual(VarName, this.envVar.VarName);
        }

        /// <summary>
        /// Tests the variable values.
        /// </summary>
        [Test]
        public void TestVarValues()
        {
            this.envVar.VarValues = this.varValues;
            List<string> varValuesList = this.envVar.VarValuesList;

            Assert.AreEqual(Var1, varValuesList[0]);
            Assert.AreEqual(Var2, varValuesList[1]);
            Assert.AreEqual(Var3, varValuesList[2]);
        }
        #endregion Public Functions
    }
}
