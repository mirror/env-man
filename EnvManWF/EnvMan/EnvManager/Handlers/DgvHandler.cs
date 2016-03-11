//------------------------------------------------------------------------
// <copyright file="DgvHandler.cs" company="SETCHIN Freelance Consulting">
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
    /// Data Grid View Handler
    /// </summary>
    public class DgvHandler
    {
        #region Constants
        /// <summary>
        /// Variable Value Separator
        /// </summary>
        public const char Separator = ';';
        #endregion Constants

        #region Variables
        /// <summary>
        /// Marks class as added
        /// </summary>
        private bool markAsAdded = false;

        /// <summary>
        /// Environment Variable Value Validator
        /// </summary>
        private EnvVarValueValidator validator = new EnvVarValueValidator();

        /// <summary>
        /// Data Grid View
        /// </summary>
        private DataGridView dgv = null;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DgvHandler"/> class.
        /// </summary>
        /// <param name="dgv">The Data Grid View.</param>
        public DgvHandler(ref DataGridView dgv)
        {
            this.dgv = dgv;
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// Gets the index of the current row.
        /// </summary>
        /// <value>
        /// The index of the current row.
        /// </value>
        public int CurrentRowIndex
        {
            get { return this.dgv.CurrentRow.Index; }
        }

        /// <summary>
        /// Gets the index of the bottom row.
        /// </summary>
        /// <value>
        /// The index of the bottom row.
        /// </value>
        public int BottomRowIndex
        {
            get
            {
                return this.dgv.Rows.Count - 2; ////(dgv.Rows.Count == 1 ? 0 : dgv.Rows.Count - 2);
            }
        }
        #endregion Properties

        #region Public Functions
        /// <summary>
        /// Currents the row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns>Data Grid View Row</returns>
        public DataGridViewRow CurrentRow(int rowIndex)
        {
            return this.dgv.Rows[rowIndex];
        }

        /// <summary>
        /// Moves the row.
        /// </summary>
        /// <param name="currentRowIndex">Index of the current row.</param>
        /// <param name="destinationRowIndex">Index of the destination row.</param>
        public void MoveRow(int currentRowIndex, int destinationRowIndex)
        {
            DataGridViewRow rowToMove = this.CurrentRow(currentRowIndex);

            this.DeleteRow(currentRowIndex);
            this.InsertRow(destinationRowIndex, rowToMove);
        }

        /// <summary>
        /// Inserts the row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="row">The Data Grid View Row.</param>
        public void InsertRow(int rowIndex, DataGridViewRow row)
        {
            this.dgv.Rows.Insert(rowIndex, row);
            this.SetCurrentCell(rowIndex);
        }

        /// <summary>
        /// Sets the current cell.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        public void SetCurrentCell(int rowIndex)
        {
            this.dgv.CurrentCell = this.dgv[0, rowIndex];
        }

        /// <summary>
        /// Deletes the row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        public void DeleteRow(int rowIndex)
        {
            try
            {
                this.dgv.Rows.RemoveAt(rowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets the icon to the row.
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="variableValue">The variable value.</param>
        public void SetRowIcon(int rowIndex, string variableValue)
        {
            string value = Environment.ExpandEnvironmentVariables(variableValue);
            string toolTipMsg = string.Empty;
            DataGridViewCell cell = this.dgv.Rows[rowIndex].Cells[0];
            cell.Value = this.IconValueType(value, ref toolTipMsg);
            cell.ToolTipText = toolTipMsg;
        }

        /// <summary>
        /// Sets the string value to row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="variableValue">The variable value.</param>
        public void SetRowValue(int rowIndex, string variableValue)
        {
            DataGridViewCell cell = this.dgv.Rows[rowIndex].Cells[1];
            cell.Value = variableValue;
        }

        /// <summary>
        /// Sets the cell tool tip.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="variableValue">The variable value.</param>
        public void SetCellToolTip(int rowIndex, string variableValue)
        {
            if (variableValue.Contains("%"))
            {
                DataGridViewCell cell = this.dgv.Rows[rowIndex].Cells[1];
                cell.ToolTipText = Environment.ExpandEnvironmentVariables(variableValue);
            }
        }

        /// <summary>
        /// Adds a new row to grid.
        /// </summary>
        /// <param name="variableValue">The variable value.</param>
        /// <returns>index of the added row</returns>
        public int AddRow(string variableValue)
        {
            int rowIndex = this.dgv.Rows.Add();

            this.SetRowValue(rowIndex, variableValue);
            this.SetRowIcon(rowIndex, variableValue);
            this.SetCellToolTip(rowIndex, variableValue);

            return rowIndex;
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="variableValues">The variable values.</param>
        public void AddRows(string variableValues)
        {
            string[] values = variableValues.Split(Separator);

            foreach (string value in values)
            {
                this.AddRow(value);
            }
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="varValues">The variable values.</param>
        /// <param name="markAsAdded">if set to <c>true</c> [mark as added].</param>
        public void AddRows(string varValues, bool markAsAdded)
        {
            this.markAsAdded = markAsAdded;
            this.AddRows(varValues);
        }
        #endregion Public Functions

        #region Private Functions
        /// <summary>
        /// Returns Icon corresponding the type of the variable
        /// Added by Mariusz Ficek
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        /// <param name="toolTipMsg">The tool tip MSG.</param>
        /// <returns>
        /// Icon Bitmap
        /// </returns>
        private Bitmap IconValueType(string varValue, ref string toolTipMsg)
        {
            Bitmap icon;

            switch (this.validator.ValueType(varValue))
            {
                case EnvironmentValueType.Number:
                    icon
                        = this.markAsAdded
                        ? Properties.Resources.ValTypeNumberAdd
                        : Properties.Resources.ValTypeNumber;
                    toolTipMsg = "Number";
                    break;
                case EnvironmentValueType.String:
                    icon
                        = this.markAsAdded
                        ? Properties.Resources.ValTypeStringAdd
                        : Properties.Resources.ValTypeString;
                    toolTipMsg = "Word";
                    break;
                case EnvironmentValueType.Folder:
                    icon
                        = this.markAsAdded
                        ? Properties.Resources.ValTypeFolderAdd
                        : Properties.Resources.ValTypeFolder;
                    toolTipMsg = "Folder";
                    break;
                case EnvironmentValueType.File:
                    icon
                        = this.markAsAdded
                        ? Properties.Resources.ValTypeFileAdd
                        : Properties.Resources.ValTypeFile;
                    toolTipMsg = "File";
                    break;
                default:  // Error
                    icon
                        = this.markAsAdded
                        ? Properties.Resources.ValTypeErrorAdd
                        : Properties.Resources.ValTypeError;
                    toolTipMsg = "No File or Folder found";
                    break;
            }

            return icon;
        }
        #endregion Private Functions
    }
}
