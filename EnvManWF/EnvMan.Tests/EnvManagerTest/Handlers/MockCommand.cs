//------------------------------------------------------------------------
// <copyright file="MockCommand.cs" company="SETCHIN Freelance Consulting">
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

    /// <summary>
    /// Mock Command for Testing
    /// </summary>
    public class MockCommand : ICommand
    {
        /// <summary>
        /// Command Name
        /// </summary>
        private string commandName;

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        public string CommandName
        {
            get { return this.commandName; }
            set { this.commandName = value; }
        }

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
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public void Redo()
        {
            // To be 100% in code coverage
            this.Execute();
        }
    }
}
