//------------------------------------------------------------------------
// <copyright file="VarImportCommand.cs" company="SETCHIN Freelance Consulting">
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
    using global::SFC.EnvMan.ImportExport;

    /// <summary>
    /// Variable Import Command class
    /// Responsible for performing import of Environment Variables from file
    /// and undoing this action to previous state.
    /// </summary>
    public class VarImportCommand : ICommand
    {
        #region Variables
        /// <summary>
        /// Current Last Row
        /// </summary>
        private int currentLastRow;

        /// <summary>
        /// Text Box for Variable Name
        /// </summary>
        private TextBox txtVarName;

        /// <summary>
        /// Indicates if this is a new Variable
        /// </summary>
        private bool isNewVariable;

        /// <summary>
        /// Current Values of the Variable
        /// </summary>
        private string currentVarValues;

        /// <summary>
        /// New Variable Values
        /// </summary>
        private string newVarValues;

        /// <summary>
        /// Indicates of able to import
        /// </summary>
        private bool isAbleToImport;

        /// <summary>
        /// Data Grid View Handler
        /// </summary>
        private DgvHandler dgvHandler;

        /// <summary>
        /// Import Export  Manager
        /// </summary>
        private ImportExportManager importExportManager;

        /// <summary>
        /// Command Name
        /// </summary>
        private string commandName = "Import";
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="VarImportCommand"/> class.
        /// </summary>
        /// <param name="txtVarName">Name of the TXT variable.</param>
        /// <param name="currentVarValues">The current variable values.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="dgvHandler">The DGV handler.</param>
        public VarImportCommand(
            TextBox txtVarName,
            string currentVarValues,
            string fileName,
            DgvHandler dgvHandler)
        {
            this.txtVarName = txtVarName;
            this.currentVarValues = currentVarValues;
            this.importExportManager = new ImportExportManager();
            this.importExportManager.EnvVariable = new EnvironmentVariable();
            this.importExportManager.Load(fileName);
            this.dgvHandler = dgvHandler;

            this.GetValuesToImport();
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// Gets a value indicating whether this instance is able to import.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is able to import; otherwise, <c>false</c>.
        /// </value>
        public bool IsAbleToImport
        {
            get
            {
                return this.isAbleToImport;
            }
        }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        public string CommandName
        {
            get
            {
                return this.commandName;
            }
        }
        #endregion Properties

        #region Public Functions
        /// <summary>
        /// Performs Execute action. Remembers a current state
        /// and calls Redo function.
        /// </summary>
        public void Execute()
        {
            this.currentLastRow = this.dgvHandler.BottomRowIndex;

            if (this.isAbleToImport)
            {
                this.Redo();
                MessageBox.Show(
                    "Import successfully completed!",
                    "Import Success!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Performs Undo action.
        /// </summary>
        public void Undo()
        {
            int maxRows = this.dgvHandler.BottomRowIndex;
            for (int i = maxRows; i >= this.currentLastRow + 1; i--)
            {
                this.dgvHandler.DeleteRow(i);
            }

            if (this.isNewVariable)
            {
                this.txtVarName.Text = string.Empty;
            }
        }

        /// <summary>
        /// Performs Redo action.
        /// </summary>
        public void Redo()
        {
            if (this.txtVarName.Text.Length == 0)
            {
                this.isNewVariable = true;
                this.txtVarName.Text
                    = this.importExportManager.EnvVariable.VarName;
            }

            this.dgvHandler.AddRows(this.newVarValues, true);
        }
        #endregion Public Functions

        #region Private Functions
        /// <summary>
        /// Gets the values to import.
        /// </summary>
        private void GetValuesToImport()
        {
            // Compare Variable Names in Uppercase
            if (this.txtVarName.Text.Length == 0
                || this.txtVarName.Text.ToUpper().CompareTo(
                this.importExportManager.EnvVariable.VarName.ToUpper()) == 0)
            {   // Do prepare for import
                foreach (string varValue
                    in this.importExportManager.EnvVariable.VarValuesList)
                {
                    if (this.currentVarValues.IndexOf(varValue) == -1)
                    {
                        this.newVarValues += (this.newVarValues.Length != 0
                            ? ";" : string.Empty) + varValue;
                    }
                }

                if (this.newVarValues.Length != 0)
                {
                    this.isAbleToImport = true;
                }
                else
                {
                    MessageBox.Show(
                        "There are no values to import.",
                        "Nothing to import",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {   // Variable names are not the same
                MessageBox.Show(
                    "Cannot import values from different variable.",
                    "Variable names are not the same",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion Private Functions
    }
}
