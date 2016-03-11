//------------------------------------------------------------------------
// <copyright file="EditVarNameCommandTest.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.Tests
{
    using System.Windows.Forms;
    using NUnit.Framework;
    using global::SFC.EnvMan.Handlers;

    /// <summary>
    /// Test Edit Environment Variable Command
    /// </summary>
    [TestFixture]
    public class EditVarNameCommandTest
    {
        /// <summary>
        /// Name of the variable
        /// </summary>
        private const string VariableName = "Variable Name";

        /// <summary>
        /// Name of the new Variable Name
        /// </summary>
        private const string NewVarName = "New Variable Name";

        /// <summary>
        /// Text Box Control
        /// </summary>
        private TextBox txtBox = null;

        /// <summary>
        /// Command to run to edit
        /// </summary>
        private EditVarNameCommand editVarNameCommand = null;

        /// <summary>
        /// Sets up tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.txtBox = new TextBox();
            this.txtBox.Text = VariableName;
            this.editVarNameCommand = new EditVarNameCommand(this.txtBox);
        }

        /// <summary>
        /// Tears down tests.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.txtBox.Dispose();
        }

        /// <summary>
        /// Tests the undo edit.
        /// </summary>
        [Test]
        public void TestUndoEdit()
        {
            this.txtBox.Text = NewVarName;
            this.editVarNameCommand.NewVarName = NewVarName;
            Assert.AreNotEqual(
                this.editVarNameCommand.CurrentVariableName, this.txtBox.Text);
            this.editVarNameCommand.Undo();
            Assert.AreEqual(
                this.editVarNameCommand.CurrentVariableName, this.txtBox.Text);
        }

        /// <summary>
        /// Tests the undo redo edit.
        /// </summary>
        [Test]
        public void TestUndoRedoEdit()
        {
            this.txtBox.Text = NewVarName;
            this.editVarNameCommand.NewVarName = NewVarName;
            Assert.AreNotEqual(
                this.editVarNameCommand.CurrentVariableName, this.txtBox.Text);
            this.editVarNameCommand.Undo();
            Assert.AreEqual(
                this.editVarNameCommand.CurrentVariableName, this.txtBox.Text);
            this.editVarNameCommand.Redo();
            Assert.AreNotEqual(
                this.editVarNameCommand.CurrentVariableName, this.txtBox.Text);
        }
    }
}
