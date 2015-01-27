//------------------------------------------------------------------------
// <copyright file="UndoRedoCommandListTest.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.Tests.Handlers
{
    using global::SFC.EnvMan.Handlers;
    using NUnit.Framework;

    /// <summary>
    /// Test of Undo Redo Command List
    /// </summary>
    [TestFixture]
    public class UndoRedoCommandListTest
    {
        #region Constants
        /// <summary>
        /// Redo label
        /// </summary>
        private const string RedoString = "Redo ";

        /// <summary>
        /// Undo Label
        /// </summary>
        private const string UndoString = "Undo ";

        /// <summary>
        /// First Command Name
        /// </summary>
        private const string CommandName1 = "Command1";

        /// <summary>
        /// Second Command Name
        /// </summary>
        private const string CommandName2 = "Command2";

        /// <summary>
        /// Third Command Name
        /// </summary>
        private const string CommandName3 = "Command3";
        #endregion Constants

        #region Variables
        /// <summary>
        /// List of Commands
        /// </summary>
        private UndoRedoCommandList commandsList = null;

        /// <summary>
        /// First Command
        /// </summary>
        private MockCommand command1 = null;

        /// <summary>
        /// Second Command
        /// </summary>
        private MockCommand command2 = null;

        /// <summary>
        /// Third Command
        /// </summary>
        private MockCommand command3 = null;
        #endregion Variables

        #region Setup Teardown
        /// <summary>
        /// Sets up tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.commandsList = new UndoRedoCommandList();

            this.command1 = new MockCommand();
            this.command1.CommandName = CommandName1;

            this.command2 = new MockCommand();
            this.command2.CommandName = CommandName2;

            this.command3 = new MockCommand();
            this.command3.CommandName = CommandName3;
        }
        #endregion Setup Teardown

        #region Tests
        /// <summary>
        /// Tests the add.
        /// </summary>
        [Test]
        public void TestAdd()
        {
            this.commandsList.Add(this.command1);

            Assert.IsTrue(this.commandsList.CanUndo);
            Assert.IsFalse(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.UndoMsg, UndoString + CommandName1);
        }

        /// <summary>
        /// Tests the add undo.
        /// </summary>
        [Test]
        public void TestAddUndo()
        {
            this.commandsList.Add(this.command1);
            this.UndoCommand(1);
            Assert.IsFalse(this.commandsList.CanUndo);
            Assert.IsTrue(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.RedoMsg, RedoString + CommandName1);
        }

        /// <summary>
        /// Tests the add undo add.
        /// </summary>
        [Test]
        public void TestAddUndoAdd()
        {
            this.commandsList.Add(this.command1);
            this.UndoCommand(1);
            this.commandsList.Add(this.command2);
            Assert.IsTrue(this.commandsList.CanUndo);
            Assert.IsFalse(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.UndoMsg, UndoString + CommandName2);
        }

        /// <summary>
        /// Tests the addx2 undo.
        /// </summary>
        [Test]
        public void TestAddx2Undo()
        {
            this.commandsList.Add(this.command1);
            this.commandsList.Add(this.command2);
            this.UndoCommand(1);
            Assert.IsTrue(this.commandsList.CanUndo);
            Assert.IsTrue(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.UndoMsg, UndoString + CommandName1);
            Assert.AreEqual(
                this.commandsList.RedoMsg, RedoString + CommandName2);
        }

        /// <summary>
        /// Tests the add x 2 undo add.
        /// </summary>
        [Test]
        public void TestAddx2UndoAdd()
        {
            this.commandsList.Add(this.command1);
            this.commandsList.Add(this.command2);
            this.UndoCommand(1);
            this.commandsList.Add(this.command3);
            Assert.IsTrue(this.commandsList.CanUndo);
            Assert.IsFalse(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.UndoMsg, UndoString + CommandName3);
        }

        /// <summary>
        /// Tests the add x 3 undo x 3.
        /// </summary>
        [Test]
        public void TestAddx3Undox3()
        {
            this.commandsList.Add(this.command1);
            this.commandsList.Add(this.command2);
            this.commandsList.Add(this.command3);
            this.UndoCommand(3);
            Assert.IsFalse(this.commandsList.CanUndo);
            Assert.IsTrue(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.RedoMsg, RedoString + CommandName1);
        }

        /// <summary>
        /// Tests the add x 3 undo x 3 redo x 3.
        /// </summary>
        [Test]
        public void TestAddx3Undox3Redox3()
        {
            this.commandsList.Add(this.command1);
            this.commandsList.Add(this.command2);
            this.commandsList.Add(this.command3);
            this.UndoCommand(3);
            this.RedoCommand(3);
            Assert.IsTrue(this.commandsList.CanUndo);
            Assert.IsFalse(this.commandsList.CanRedo);
            Assert.AreEqual(
                this.commandsList.UndoMsg, UndoString + CommandName3);
        } 
        #endregion Tests

        #region Tool functions
        /// <summary>
        /// Undoes the command.
        /// </summary>
        /// <param name="numActions">The num actions.</param>
        private void UndoCommand(int numActions)
        {
            for (int i = 0; i < numActions; i++)
            {
                this.commandsList.Undo();
            }
        }

        /// <summary>
        /// Redoes the command.
        /// </summary>
        /// <param name="numActions">The num actions.</param>
        private void RedoCommand(int numActions)
        {
            for (int i = 0; i < numActions; i++)
            {
                this.commandsList.Redo();
            }
        }
        #endregion Tool functions
    }
}
