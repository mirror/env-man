//------------------------------------------------------------------------
// <copyright file="UndoRedoCommandList.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.Handlers
{
    using System.Collections.Generic;
    using global::SFC.EnvMan.Properties;

    /// <summary>
    /// Holds list of executed commands for Undo, Redo Functionality
    /// </summary>
    public class UndoRedoCommandList
    {
        #region Variables
        /// <summary>
        /// List of the Commands
        /// </summary>
        private List<ICommand> commandsList = null;

        /// <summary>
        /// Index of the current command
        /// </summary>
        private int currentCommandIndex = -1;   // -1 no command executed

        /// <summary>
        /// Undo Message
        /// </summary>
        private string undoMsg;

        /// <summary>
        /// Redo Message
        /// </summary>
        private string redoMsg;
        #endregion Variables

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCommandList"/> class.
        /// </summary>
        public UndoRedoCommandList()
        {
            this.commandsList = new List<ICommand>();
            this.SetUndoRedoMessages();
        }

        #region Properties
        /// <summary>
        /// Gets the undo MSG.
        /// </summary>
        public string UndoMsg
        {
            get { return this.undoMsg; }
        }

        /// <summary>
        /// Gets the redo MSG.
        /// </summary>
        public string RedoMsg
        {
            get { return this.redoMsg; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can undo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can undo; otherwise, <c>false</c>.
        /// </value>
        public bool CanUndo
        {
            get
            {
                return this.currentCommandIndex != -1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can redo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can redo; otherwise, <c>false</c>.
        /// </value>
        public bool CanRedo
        {
            get
            {
                return this.commandsList.Count > 0
                    && this.currentCommandIndex != this.commandsList.Count - 1;
            }
        }
        #endregion Properties

        #region Functions
        /// <summary>
        /// Executes Undo of the current command from the list.
        /// </summary>
        public void Undo()
        {
            ICommand command
                = this.commandsList[this.currentCommandIndex] as ICommand;
            command.Undo();
            this.currentCommandIndex -= 1;
            this.SetUndoRedoMessages();
        }

        /// <summary>
        /// Executes Undo of the next command from the list after current.
        /// </summary>
        public void Redo()
        {
            ICommand command
                = this.commandsList[++this.currentCommandIndex] as ICommand;
            command.Redo();
            this.SetUndoRedoMessages();
        }

        /// <summary>
        /// Adds the specified command to a list.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Add(ICommand command)
        {
            if (this.commandsList.Count > 0
                && this.currentCommandIndex != this.commandsList.Count - 1)
            {   // remove all the commands after current
                if (this.currentCommandIndex == -1)
                {
                    this.commandsList.RemoveRange(0, this.commandsList.Count);
                }
                else
                {
                    int currCommandIndex
                        = this.currentCommandIndex == -1
                            ? 0 : this.currentCommandIndex;
                    this.commandsList.RemoveRange(
                        this.currentCommandIndex + 1,
                        this.commandsList.Count - currCommandIndex - 1);
                }
            }

            // add command to a list and increment index
            this.commandsList.Add(command);
            this.currentCommandIndex += 1;
            this.SetUndoRedoMessages();
        }

        /// <summary>
        /// Clears list of commands.
        /// </summary>
        public void Clear()
        {
            this.commandsList.Clear();
            this.currentCommandIndex = -1;
        }

        /// <summary>
        /// Sets the undo redo messages.
        /// </summary>
        private void SetUndoRedoMessages()
        {
            this.undoMsg = this.CanUndo == true
                ? Resources.ToolTipUndo + " "
                + (this.commandsList[this.currentCommandIndex]
                    as ICommand).CommandName
                : Resources.ToolTipUndo;
            this.redoMsg = this.CanRedo == true
                ? Resources.ToolTipRedo
                + " "
                + (this.commandsList[this.currentCommandIndex + 1]
                    as ICommand).CommandName
                : Resources.ToolTipRedo;
        }
        #endregion Functions
    }
}
