//------------------------------------------------------------------------
// <copyright file="DgvEditCommand.cs" company="SETCHIN Freelance Consulting">
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
    /// Data Grid View Edit Command
    /// </summary>
    public class DgvEditCommand : DgvModifyValueCommand
    {
        /// <summary>
        /// Data Grid View Command Name
        /// </summary>
        private const string DgvCommandName = "New Value";

        /// <summary>
        /// Initializes a new instance of the <see cref="DgvEditCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        public DgvEditCommand(DgvHandler dgvHandler)
            : base(dgvHandler, DgvCommandName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DgvEditCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        /// <param name="row">The data grid view row.</param>
        public DgvEditCommand(DgvHandler dgvHandler, DataGridViewRow row)
            : base(dgvHandler, DgvCommandName)
        {
            this.CurrentRow = this.CloneRow(row);
            this.CurrentRowIndex = row.Index;
        }
    }
}
