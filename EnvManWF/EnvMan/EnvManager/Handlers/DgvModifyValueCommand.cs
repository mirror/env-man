//------------------------------------------------------------------------
// <copyright file="DgvModifyValueCommand.cs" company="SETCHIN Freelance Consulting">
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
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Data Grid View Modify Value Command
    /// </summary>
    public class DgvModifyValueCommand : DgvCommand
    {
        #region Variables
        /// <summary>
        /// Current Data Grid View Row
        /// </summary>
        private DataGridViewRow currentRow = null;

        /// <summary>
        /// New Data Grid View Row
        /// </summary>
        private DataGridViewRow newRow = null;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DgvModifyValueCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        /// <param name="commandName">Name of the command.</param>
        public DgvModifyValueCommand(DgvHandler dgvHandler, string commandName)
            : base(dgvHandler, commandName)
        {
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// Gets or sets the current row.
        /// </summary>
        /// <value>
        /// The current row.
        /// </value>
        public DataGridViewRow CurrentRow
        {
            get
            {
                return this.currentRow;
            }

            set
            {
                this.currentRow = value;
            }
        }

        /// <summary>
        /// Sets the new row.
        /// </summary>
        /// <value>
        /// The new row.
        /// </value>
        public DataGridViewRow NewRow
        {
            set
            {
                this.newRow = this.CloneRow(value);
                this.NewRowIndex = value.Index;
            }
        }
        #endregion Properties

        #region Public Functions
        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public override void Undo()
        {
            Console.WriteLine(
                "Undo New Row: " + this.newRow.Cells[1].Value.ToString());
            this.Handler.DeleteRow(this.NewRowIndex);
            if (this.currentRow != null)
            {
                Console.WriteLine(
                    "Write Old Row: "
                    + this.currentRow.Cells[1].Value.ToString());
                this.Handler.InsertRow(
                    this.CurrentRowIndex, this.CloneRow(this.currentRow));
            }
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public override void Redo()
        {
            if (this.currentRow != null)
            {
                this.Handler.DeleteRow(this.CurrentRowIndex);
            }

            this.Handler.InsertRow(
                this.NewRowIndex, this.CloneRow(this.newRow));
        }
        #endregion Public Functions

        #region Protected Functions
        /// <summary>
        /// Clones the row.
        /// </summary>
        /// <param name="row">The Data Grid View row.</param>
        /// <returns>Data Grid View Row</returns>
        protected DataGridViewRow CloneRow(DataGridViewRow row)
        {
            DataGridViewRow newRow = row.Clone() as DataGridViewRow;
            newRow.Cells[0].Value = new Bitmap(row.Cells[0].Value as Bitmap);
            newRow.Cells[1].Value = string.Copy(row.Cells[1].Value as string);

            return newRow;
        }
        #endregion Protected Functions
    }
}
