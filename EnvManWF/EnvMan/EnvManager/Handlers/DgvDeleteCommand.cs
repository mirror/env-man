//------------------------------------------------------------------------
// <copyright file="DgvDeleteCommand.cs" company="SETCHIN Freelance Consulting">
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
    using System.Windows.Forms;

    /// <summary>
    /// Data Grid View Delete Command
    /// </summary>
    public class DgvDeleteCommand : DgvCommand
    {
        /// <summary>
        /// Command Name
        /// </summary>
        private const string DgvCommandName = "Delete Value";

        /// <summary>
        /// Data Grid View Row
        /// </summary>
        private DataGridViewRow row = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DgvDeleteCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        public DgvDeleteCommand(DgvHandler dgvHandler)
            : base(dgvHandler, DgvCommandName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DgvDeleteCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        /// <param name="row">The data grid view row.</param>
        public DgvDeleteCommand(DgvHandler dgvHandler, DataGridViewRow row)
            : base(dgvHandler, DgvCommandName)
        {
            this.row = row;
            this.CurrentRowIndex = row.Index;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            // execute only when row is not set, i.e. not deleted
            if (this.row == null)
            {
                this.CurrentRowIndex = this.Handler.CurrentRowIndex;
                this.row = this.Handler.CurrentRow(this.CurrentRowIndex);
                this.Redo();
            }
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public override void Undo()
        {
            this.Handler.InsertRow(this.CurrentRowIndex, this.row);
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public override void Redo()
        {
            this.Handler.DeleteRow(this.CurrentRowIndex);
        }
    }
}
