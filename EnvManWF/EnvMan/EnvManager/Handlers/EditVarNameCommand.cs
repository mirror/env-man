//------------------------------------------------------------------------
// <copyright file="EditVarNameCommand.cs" company="SETCHIN Freelance Consulting">
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
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Edit Variable Name Command
    /// </summary>
    public class EditVarNameCommand : ICommand
    {
        #region Constants
        /// <summary>
        /// Name of the command
        /// </summary>
        private string commandName = "Edit Variable Name";
        #endregion Constants

        #region Variables
        /// <summary>
        /// Current Variable Name
        /// </summary>
        private string currentVariableName;

        /// <summary>
        /// Edited new Variable Name
        /// </summary>
        private string newVariableName;

        /// <summary>
        /// Text Box Control
        /// </summary>
        private TextBox txtBox;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EditVarNameCommand"/> class.
        /// </summary>
        /// <param name="txtBox">The TXT box.</param>
        public EditVarNameCommand(TextBox txtBox)
        {
            this.txtBox = txtBox;
            this.currentVariableName = string.Copy(this.txtBox.Text);
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// Gets the name of the current variable.
        /// </summary>
        /// <value>
        /// The name of the current variable.
        /// </value>
        public string CurrentVariableName
        {
            get { return this.currentVariableName; }
        }

        /// <summary>
        /// Sets the new name of the var.
        /// </summary>
        /// <value>
        /// The new name of the var.
        /// </value>
        public string NewVarName
        {
            set { this.newVariableName = value; }
        }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        public string CommandName
        {
            get { return this.commandName; }
        }
        #endregion Properties

        #region Public Functions
        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public void Undo()
        {
            this.txtBox.CausesValidation = false;
            this.txtBox.Text = string.Copy(this.currentVariableName);
            this.txtBox.CausesValidation = true;
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public void Redo()
        {
            this.txtBox.Text = string.Copy(this.newVariableName);
        }
        #endregion Public Functions
    }
}
