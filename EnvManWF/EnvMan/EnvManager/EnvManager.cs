//------------------------------------------------------------------------
// <copyright file="EnvManager.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Environment Manager
    /// </summary>
    public partial class EnvManager : UserControl
    {
        #region Constants
        private const int SplitterDistance = 197;
        #endregion Constants

        #region Variables
        /// <summary>
        /// Variable Manager
        /// </summary>
        private EnvVarManager variableManger = new EnvVarManager();

        /// <summary>
        /// Edit Variable Form
        /// </summary>
        private FrmEditEnvVar frmEditVariable = null;

        /// <summary>
        /// Environment Manager Settings
        /// </summary>
        private Properties.EnvManagerSettings settings
            = Properties.EnvManagerSettings.Default;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvManager"/> class.
        /// </summary>
        public EnvManager()
        {
            this.InitializeComponent();

            gbUserVariables.Text += Environment.UserName;
            this.LoadEnvironmentVariables();

            this.HandleDestroyed
                += new EventHandler(this.EnvManager_HandleDestroyed);
        }
        #endregion Constructor

        #region Private Functions
        /// <summary>
        /// Handles the HandleDestroyed event of the EnvManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EnvManager_HandleDestroyed(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        #region Load Environment Variables
        /// <summary>
        /// Loads the environment variables.
        /// </summary>
        private void LoadEnvironmentVariables()
        {
            this.LoadEnvironmentVariables(
                this.dgvSystemVariables, EnvironmentVariableTarget.Machine);
            this.LoadEnvironmentVariables(
                this.dgvUserVariables, EnvironmentVariableTarget.User);
        }

        /// <summary>
        /// Loads the environment variables.
        /// </summary>
        /// <param name="dgv">The Data Grid View.</param>
        /// <param name="target">The target.</param>
        private void LoadEnvironmentVariables(
            DataGridView dgv, EnvironmentVariableTarget target)
        {
            EnvVarValueValidator validator = new EnvVarValueValidator();
            int currentRowIndex
                = dgv.CurrentRow != null ? dgv.CurrentRow.Index : 0;
            dgv.Rows.Clear();
            int rowIndex = 0;

            IDictionary environmentVariables
                = this.variableManger.GetEnvVariables(target);
            foreach (DictionaryEntry de in environmentVariables)
            {
                string[] row = { de.Key.ToString(), de.Value.ToString() };

                rowIndex = dgv.Rows.Add(row);

                // validate variable value and show row in red if invalid
                if (!validator.Validate(de.Value.ToString()))
                {
                    dgv.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Red;
                    dgv.Rows[rowIndex].Cells[1].Style.ForeColor = Color.Red;
                }
            }

            dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            try
            {
                dgv.CurrentCell = dgv[0, currentRowIndex];
                dgv.FirstDisplayedScrollingRowIndex = currentRowIndex;
            }
            catch
            {   // if row was deleted this will set it to first one
                // TODO: Implement this by searching for var name in the grid.
                // Catching Exceptions makes program slow
                if (dgv.Rows.Count != 0)
                {
                    dgv.CurrentCell = dgv[0, 0];
                    dgv.FirstDisplayedScrollingRowIndex = 0;
                }
            }
        }
        #endregion Load Environment Variables

        #region Controls Events
        /// <summary>
        /// BTNs the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnClick(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnEditUserVariable))
            {
                this.EditEnvVar(
                    this.dgvUserVariables, EnvironmentVariableTarget.User);
            }
            else if (sender.Equals(this.btnEditSystemVariable))
            {
                this.EditEnvVar(
                    this.dgvSystemVariables, EnvironmentVariableTarget.Machine);
            }
            else if (sender.Equals(this.btnNewUserVariable))
            {
                this.EditEnvVar(string.Empty, EnvironmentVariableTarget.User);
            }
            else if (sender.Equals(this.btnNewSystemVariable))
            {
                this.EditEnvVar(
                    string.Empty, EnvironmentVariableTarget.Machine);
            }
            else if (sender.Equals(this.btnDeleteSystemVariable))
            {
                this.DeleteEnvVar(
                    this.dgvSystemVariables, EnvironmentVariableTarget.Machine);
            }
            else if (sender.Equals(this.btnDeleteUserVariable))
            {
                this.DeleteEnvVar(
                    this.dgvUserVariables, EnvironmentVariableTarget.User);
            }

            this.LoadEnvironmentVariables();
        }

        /// <summary>
        /// DGVs the name of the variable.
        /// </summary>
        /// <param name="dgv">The Data Grid View.</param>
        /// <returns>Variable Name</returns>
        private string DgvVariableName(DataGridView dgv)
        {
            string varName = string.Empty;

            if (dgv.CurrentRow.Index != -1)
            {
                varName
                    = dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString();
            }

            return varName;
        }

        /// <summary>
        /// DGVs the cell mouse double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        private void DgvCellMouseDoubleClick(
            object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex > -1)
            {
                EnvironmentVariableTarget varTarget
                    = sender.Equals(dgvUserVariables)
                        ? EnvironmentVariableTarget.User
                        : EnvironmentVariableTarget.Machine;
                this.EditEnvVar(dgv, varTarget);
                this.LoadEnvironmentVariables();
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the SplitContainer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void SplitContainer_MouseDoubleClick(
            object sender, MouseEventArgs e)
        {
            this.splitContainer.SplitterDistance
                = splitContainer.Size.Height / 2;
        }
        #endregion Controls Events

        #region Edit Environment Variables
        /// <summary>
        /// Deletes the environment variable.
        /// </summary>
        /// <param name="dgv">The Data Grid View.</param>
        /// <param name="variableType">Type of the variable.</param>
        /// <returns>Dialog Result</returns>
        private DialogResult DeleteEnvVar(
            DataGridView dgv, EnvironmentVariableTarget variableType)
        {
            DialogResult dialogRresult = DialogResult.No;
            string varName = this.DgvVariableName(dgv);

            if (!string.IsNullOrEmpty(varName))
            {
                dialogRresult = MessageBox.Show(
                    "Are you sure to remove variable \"" + varName + "\"?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogRresult == DialogResult.Yes)
                {
                    try
                    {
                        this.variableManger.DeleteEnvironmentVariable(
                            varName, variableType);
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
            }

            return dialogRresult;
        }

        /// <summary>
        /// Edits the environment variable.
        /// </summary>
        /// <param name="dgv">The Data Grid View.</param>
        /// <param name="variableType">Type of the variable.</param>
        private void EditEnvVar(
            DataGridView dgv, EnvironmentVariableTarget variableType)
        {
            string varName = this.DgvVariableName(dgv);

            if (!string.IsNullOrEmpty(varName))
            {
                this.EditEnvVar(varName, variableType);
            }
        }

        /// <summary>
        /// Edits the environment variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varType">Type of the variable.</param>
        private void EditEnvVar(
            string varName, EnvironmentVariableTarget varType)
        {
            this.frmEditVariable = new FrmEditEnvVar(varName, varType);
            this.frmEditVariable.ShowDialog();
            this.frmEditVariable.Dispose();
        }
        #endregion Edit Environment Variables

        #region Settings
        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                this.splitContainer.SplitterDistance = this.settings.SpliterPosition;
            }
            catch (Exception)
            {
                // load default settings
                this.splitContainer.SplitterDistance = EnvManager.SplitterDistance;

                this.SaveSettings();
            }
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            this.settings.SpliterPosition
                = this.splitContainer.SplitterDistance;
            this.settings.Save();
        }

        /// <summary>
        /// Handles the Load event of the EnvManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void EnvManager_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }
        #endregion Settings

        /// <summary>
        /// DGVs the user deleting row.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewRowCancelEventArgs"/> instance containing the event data.</param>
        private void DgvUserDeletingRow(
            object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;

            if (sender.Equals(this.dgvSystemVariables))
            {
                dialogResult
                    = this.DeleteEnvVar(
                    this.dgvSystemVariables, EnvironmentVariableTarget.Machine);
            }
            else if (sender.Equals(this.dgvUserVariables))
            {
                dialogResult
                    = this.DeleteEnvVar(
                    this.dgvUserVariables, EnvironmentVariableTarget.User);
            }

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion Private Functions
    }
}
