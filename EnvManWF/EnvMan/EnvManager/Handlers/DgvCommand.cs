//------------------------------------------------------------------------
// <copyright file="DgvCommand.cs" company="SETCHIN Freelance Consulting">
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
    /// <summary>
    /// Data Grid View Command
    /// </summary>
    public class DgvCommand : ICommand
    {
        /// <summary>
        /// Index of the current row
        /// </summary>
        private int currentRowIndex;

        /// <summary>
        /// Index of the new row
        /// </summary>
        private int newRowIndex;

        /// <summary>
        /// Data Grid View Handler
        /// </summary>
        private DgvHandler dgvHandler;

        /// <summary>
        /// Command Name
        /// </summary>
        private string commandName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DgvCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        /// <param name="commandName">Name of the command.</param>
        public DgvCommand(DgvHandler dgvHandler, string commandName)
        {
            this.dgvHandler = dgvHandler;
            this.commandName = commandName;
        }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        public virtual string CommandName
        {
            get
            {
                return this.commandName;
            }
        }

        /// <summary>
        /// Gets the handler.
        /// </summary>
        protected DgvHandler Handler
        {
            get
            {
                return this.dgvHandler;
            }
        }

        /// <summary>
        /// Gets or sets the new index of the row.
        /// </summary>
        /// <value>
        /// The new index of the row.
        /// </value>
        protected int NewRowIndex
        {
            get
            {
                return this.newRowIndex;
            }

            set
            {
                this.newRowIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the current row.
        /// </summary>
        /// <value>
        /// The index of the current row.
        /// </value>
        protected int CurrentRowIndex
        {
            get
            {
                return this.currentRowIndex;
            }

            set
            {
                this.currentRowIndex = value;
            }
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public virtual void Undo()
        {
            this.dgvHandler.MoveRow(this.newRowIndex, this.currentRowIndex);
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public virtual void Redo()
        {
            this.dgvHandler.MoveRow(this.currentRowIndex, this.newRowIndex);
        }
    }
}
