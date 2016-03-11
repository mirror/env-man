//------------------------------------------------------------------------
// <copyright file="DgvMoveUpCommand.cs" company="SETCHIN Freelance Consulting">
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
    /// Data Grid View Move Up Command
    /// </summary>
    public class DgvMoveUpCommand : DgvCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DgvMoveUpCommand"/> class.
        /// </summary>
        /// <param name="dgvHandler">The DGV handler.</param>
        public DgvMoveUpCommand(DgvHandler dgvHandler)
            : base(dgvHandler, "Move Value Up")
        {
        }

        #region Actions
        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            this.CurrentRowIndex = this.Handler.CurrentRowIndex;
            this.NewRowIndex = this.CurrentRowIndex - 1;
            this.Redo();
        }
        #endregion Actions
    }
}
