//------------------------------------------------------------------------
// <copyright file="FrmEditEnvVar.cs" company="SETCHIN Freelance Consulting">
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
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using global::SFC.EnvMan.Handlers;
    using global::SFC.EnvMan.ImportExport;

    /// <summary>
    /// Edit Environment Variable Form
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("2C7B3D0D-379D-4B48-B371-C0AE56B66A8F")]
    public partial class FrmEditEnvVar : Form
    {
        #region Constants
        /// <summary>
        /// Extension for export files filter
        /// </summary>
        private const string DefaultFilterExtension = "*.env";

        /// <summary>
        /// File Dialog Filter String
        /// </summary>
        private const string FileFilter = "Env Files|*.env";
        #endregion Constants

        #region Variables
        /// <summary>
        /// Environment Variable Value Validator
        /// </summary>
        private EnvVarValueValidator validator = null;

        /// <summary>
        /// Sets if Variable Name was changed
        /// </summary>
        private bool isVarNameChanged = false;

        /// <summary>
        /// Variable Name
        /// </summary>
        private string variableName = string.Empty;

        #region DgvHandler Commands
        /// <summary>
        /// Data Grid View Handler
        /// </summary>
        private DgvHandler dgvHandler = null;

        /// <summary>
        /// List of Undo Redo Commands
        /// </summary>
        private UndoRedoCommandList commandsList = null;

        /// <summary>
        /// Edit Row Command
        /// </summary>
        private DgvEditCommand editRowCommand = null;

        /// <summary>
        /// Edit Variable Name Command
        /// </summary>
        private EditVarNameCommand editVarNameCommand = null;
        #endregion DgvHandler Commands

        /// <summary>
        /// Edit Environment Variable Settings Form
        /// </summary>
        private Properties.FrmEditEnvVarSettings settings
            = Properties.FrmEditEnvVarSettings.Default;

        /// <summary>
        /// Environment Variable Manager
        /// </summary>
        private EnvVarManager variableManager = new EnvVarManager();

        /// <summary>
        /// Environment Variable Target
        /// </summary>
        private EnvironmentVariableTarget variableType
            = EnvironmentVariableTarget.Machine;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmEditEnvVar"/> class.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        /// <param name="variableType">Type of the variable.</param>
        public FrmEditEnvVar(
            string variableName, EnvironmentVariableTarget variableType)
        {
            this.InitializeComponent();
            this.MinimumSize = new Size(327, 439);
            dgvValuesList.TabIndex = 0;
            this.LoadSettings();
            txtVariableName.CausesValidation = false;
            this.dgvHandler = new DgvHandler(ref dgvValuesList);

            // set default icon
            this.DgvValuesList_UserAddedRow(null, null);

            this.txtVariableName.Text = variableName;

            // remember current name
            this.variableName = variableName;
            this.variableType = variableType;
            this.validator = new EnvVarValueValidator();

            if (txtVariableName.Text.Length != 0)
            {
                // Check if we are editing variable
                this.LoadEnvironmentVariableValues();
            }

            // Set form title
            this.Text = (txtVariableName.Text.Length != 0
                ? "Edit" : "New") + " "
                + (this.variableType == EnvironmentVariableTarget.Machine
                ? "System" : "User") + " Variable";

            this.commandsList = new UndoRedoCommandList();
            this.dgvHandler.SetCurrentCell(0);
            this.editVarNameCommand = new EditVarNameCommand(txtVariableName);

            // disable buttons
            this.SetBtnState();
            txtVariableName.CausesValidation = true;
            this.isVarNameChanged = false;

            // Open/Save File dialogs
            openFileDialog.Filter = FileFilter;
            openFileDialog.DefaultExt = DefaultFilterExtension;
            saveFileDialog.Filter = FileFilter;
            saveFileDialog.DefaultExt = DefaultFilterExtension;
        }
        #endregion Constructor

        #region Events

        #endregion Events

        #region Properties

        #endregion Properties

        #region Public Functions

        #endregion Public Functions

        #region Internal Functions

        #endregion Internal Functions

        #region Protected Functions

        #endregion Protected Functions

        #region Private Functions
        #region Data Grid View
        /// <summary>
        /// Handles the UserAddedRow event of the Data Grid View Values List control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewRowEventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_UserAddedRow(
            object sender, DataGridViewRowEventArgs e)
        {
            dgvValuesList.Rows[dgvValuesList.Rows.Count - 1].Cells[0].Value
                = Properties.Resources.ValTypeNull;
        }

        /// <summary>
        /// Handles the CellValidating event of the Data Grid View Values List control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellValidatingEventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_CellValidating(
            object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex < dgv.Rows.Count - 1)
            {   // don't look at last row
                string dgvValue = string.Empty;

                if (e.ColumnIndex == 0)
                {
                    dgvValue
                        = (dgv[1, e.RowIndex].Value != null)
                        ? dgv[1, e.RowIndex].Value.ToString() : string.Empty;
                }
                else
                {
                    dgvValue = e.FormattedValue.ToString();
                }

                if (dgvValue == string.Empty)
                {
                    dgvValuesList.Rows[e.RowIndex].ErrorText
                        = "Value cannot be empty";
                    e.Cancel = true;
                }
                else if (dgvValue.Contains(";"))
                {
                    dgvValuesList.Rows[e.RowIndex].ErrorText
                        = "Value cannot contain ';'";
                    e.Cancel = true;
                }
                else
                {
                    this.dgvHandler.SetRowIcon(e.RowIndex, dgvValue);
                    this.dgvHandler.SetCellToolTip(e.RowIndex, dgvValue);
                }
            }
        }

        /// <summary>
        /// Handles the CellEndEdit event of the Data Grid View ValuesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_CellEndEdit(
            object sender, DataGridViewCellEventArgs e)
        {
            dgvValuesList.Rows[e.RowIndex].ErrorText = string.Empty;
            object dgvValue = dgvValuesList.Rows[e.RowIndex].Cells[1].Value;
            object editRowCommandValue
                = this.editRowCommand.CurrentRow
                == null ? null : this.editRowCommand.CurrentRow.Cells[1].Value;

            if (dgvValue != null
                && (editRowCommandValue == null
                || editRowCommandValue.ToString() != dgvValue.ToString()))
            {
                // dgvHandler.SetRowIcon(e.RowIndex, dgvValue.ToString());
                this.editRowCommand.NewRow
                    = this.dgvValuesList.Rows[e.RowIndex];
                this.AddCommand(this.editRowCommand);
            }
            else
            {
                if (editRowCommandValue != null)
                {   // New Value is null, restore the old value
                    this.dgvValuesList.Rows[e.RowIndex].Cells[1].Value
                        = editRowCommandValue;
                }

                this.SetBtnState();
            }
        }

        /// <summary>
        /// Handles the CellBeginEdit event of the Data Grid View ValuesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellCancelEventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_CellBeginEdit(
            object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvValuesList[e.ColumnIndex, e.RowIndex].Value != null)
            {
                this.editRowCommand
                    = new DgvEditCommand(
                        this.dgvHandler, dgvValuesList.Rows[e.RowIndex]);
            }
            else
            {
                this.editRowCommand = new DgvEditCommand(this.dgvHandler);
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the Data Grid View ValuesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_SelectionChanged(object sender, EventArgs e)
        {
            this.SetBtnState();
        }

        /// <summary>
        /// Handles the UserDeletingRow event of the Data Grid View ValuesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewRowCancelEventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_UserDeletingRow(
            object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;

            if (e == null || !e.Row.IsNewRow)
            {   // Don't show on deletion of new rows
                dialogResult = MessageBox.Show(
                    "Are you sure to delete value?",
                    "Delete Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }

            if (dialogResult == DialogResult.Yes)
            {
                ICommand command = null;
                if (e == null)
                {   // Deleted using delete button on form
                    command = new DgvDeleteCommand(this.dgvHandler);
                }
                else
                {   // Deleted using keyboard Delete key
                    command = new DgvDeleteCommand(this.dgvHandler, e.Row);
                }

                this.AddCommand(command);
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion Data Grid View

        #region Settings
        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            if (this.settings.FrmEditWindowState == FormWindowState.Normal)
            {
                this.Location = this.settings.FrmEditWindowLocation;
                this.Width = this.settings.FrmSize.Width;
                this.Height = this.settings.FrmSize.Height;
            }
            else
            {
                this.WindowState = this.settings.FrmEditWindowState;
            }
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.settings.FrmEditWindowLocation = this.Location;
                this.settings.FrmSize = this.Size;
            }
            else
            {
                this.settings.FrmEditWindowState = this.WindowState;
            }

            this.settings.Save();
        }
        #endregion Settings

        #region Environment Variables
        /// <summary>
        /// Exports the environment variable.
        /// </summary>
        private void ExportEnvironmentVariable()
        {
            try
            {
                saveFileDialog.InitialDirectory
                    = Environment.SpecialFolder.MyDocuments.ToString();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EnvironmentVariable envVar = new EnvironmentVariable();
                    envVar.VarName = txtVariableName.Text;
                    envVar.VarValues
                        = this.EnvironmentVariableValue().ToString();
                    ImportExportManager importExportManager
                        = new ImportExportManager();
                    importExportManager.EnvVariable = envVar;
                    importExportManager.Save(saveFileDialog.FileName);
                    MessageBox.Show(
                        "'" + txtVariableName.Text
                        + "' successfully exported to "
                        + saveFileDialog.FileName + " file.",
                        "Export Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        /// <summary>
        /// Imports the environment variable.
        /// </summary>
        private void ImportEnvironmentVariable()
        {
            try
            {
                openFileDialog.InitialDirectory
                    = Environment.SpecialFolder.MyDocuments.ToString();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    VarImportCommand importCommand
                        = new VarImportCommand(
                            txtVariableName,
                            this.EnvironmentVariableValue().ToString(),
                            openFileDialog.FileName,
                            this.dgvHandler);
                    if (importCommand.IsAbleToImport)
                    {
                        this.AddCommand(importCommand);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        /// <summary>
        /// Loads the environment variable values.
        /// </summary>
        private void LoadEnvironmentVariableValues()
        {
            string environmentVariableValue
                = this.variableManager.GetEnvironmentVariable(
                txtVariableName.Text, this.variableType);

            this.dgvHandler.AddRows(environmentVariableValue);
        }

        /// <summary>
        /// Saves the environment variable.
        /// </summary>
        private void SaveEnvironmentVariable()
        {
            try
            {
                StringBuilder envVarValue = this.EnvironmentVariableValue();

                if (this.variableName.Length != 0
                    && this.variableName != txtVariableName.Text)
                {
                    // name of the variable has changed
                    // remove variable with old name
                    this.variableManager.DeleteEnvironmentVariable(
                        this.variableName, this.variableType);
                }

                this.variableManager.SetEnvironmentVariable(
                    txtVariableName.Text,
                    envVarValue.ToString(),
                    this.variableType);

                // Set initial program state
                this.commandsList.Clear();
                this.variableName = txtVariableName.Text;
                this.SetBtnState();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
        #region Open in Windows Explorer

        // TODO: Test Open in Windows Explorer for Multiple Rows Actions
        ////PRANK!E code changes start here -->

        /// <summary>
        /// Handles the CellMouseDown event of the Data Grid View ValuesList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        private void DgvValuesList_CellMouseDown(
            object sender, DataGridViewCellMouseEventArgs e)
        {
            // If row not selected select it and unselect all others
            // TODO: Test it with multiple row actions
            if (e.Button == MouseButtons.Right
                && !dgvValuesList.Rows[e.RowIndex].Selected)
            {
                dgvValuesList.Rows[e.RowIndex].Selected = true;
            }
        }

        /// <summary>
        /// Locates the in windows explorer.
        /// </summary>
        private void LocateInWindowsExplorer()
        {
            EnvVarValueValidator validator = new EnvVarValueValidator();
            string varValue = string.Empty;

            foreach (DataGridViewRow row in dgvValuesList.SelectedRows)
            {
                if (row.Index != dgvValuesList.Rows.Count - 1)
                {
                    DataGridViewCell cell = row.Cells[1];
                    varValue
                        = cell.Value.ToString().Contains("%")
                        ? cell.ToolTipText : cell.Value.ToString();
                    switch (validator.ValueType(varValue))
                    {
                        case EnvironmentValueType.Folder:
                            {
                                // Open Folder in Windows Explorer
                                this.LocateInWindowsExplorer(varValue);
                            }

                            break;
                        case EnvironmentValueType.File:
                            {
                                // Select File in Windows Explorer
                                this.LocateInWindowsExplorer(
                                    "/select," + varValue);
                            }

                            break;
                        case EnvironmentValueType.Error:
                            {
                                // Select existing folder in the path
                                string parentDir
                                    = Path.GetDirectoryName(varValue);
                                while (!Directory.Exists(parentDir))
                                {
                                    parentDir
                                        = Path.GetDirectoryName(parentDir);
                                }

                                // Open Folder in Explorer
                                this.LocateInWindowsExplorer(parentDir);
                            }

                            break;
                        default:
                            {
                                // TODO: Remove for multiple rows
                                MessageBox.Show(
                                    "Nothing to locate in Windows Explorer",
                                    "Validation",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Locates the in windows explorer.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void LocateInWindowsExplorer(string parameters)
        {
            // Open Folder in new Windows Explorer window
            System.Diagnostics.Process.Start("Explorer", "/n," + parameters);
        }

        // PRANK!E code changes end here -->
        #endregion Open in Windows Explorer

#if DEBUG   // Testing
        /// <summary>
        /// Environments the variable value.
        /// </summary>
        /// <returns>List of Variable Values</returns>
        public StringBuilder EnvironmentVariableValue()
#else       // Release
        /// <summary>
        /// Environments the variable value.
        /// </summary>
        /// <returns>List of Variable Values</returns>
        private StringBuilder EnvironmentVariableValue()
#endif
        {
            StringBuilder envVarValue = new StringBuilder();

            foreach (DataGridViewRow row in dgvValuesList.Rows)
            {
                if (row.Index != dgvValuesList.Rows.Count - 1)
                {
                    envVarValue.Append(row.Cells[1].Value.ToString()
                        + (row.Index < dgvValuesList.Rows.Count - 2
                        ? ";" : string.Empty));
                    System.Diagnostics.Debug.WriteLine(envVarValue.ToString());
                }
            }

            return envVarValue;
        }
        #endregion Environment Variables
        #endregion Private Functions

        #region Form Functions

        /// <summary>
        /// Handles Control Click Events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnClick(object sender, EventArgs e)
        {
            ICommand currentCommand = null;

            if (sender.Equals(this.btnCancel))
            {
                this.Close();
            }
            else if (sender.Equals(this.btnUndo))
            {
                this.commandsList.Undo();
            }
            else if (sender.Equals(this.btnRedo))
            {
                this.commandsList.Redo();
            }
            else if (sender.Equals(this.btnSave))
            {
                this.SaveEnvironmentVariable();
            }
            else if (sender.Equals(this.btnExport))
            {
                this.ExportEnvironmentVariable();
            }
            else if (sender.Equals(this.btnImport))
            {
                this.ImportEnvironmentVariable();
            }

            if (sender.Equals(this.tsmiLocateInWindowsExplorer))
            {
                ////PRANK!E code changes start here -->
                this.LocateInWindowsExplorer();
                ////PRANK!E code changes end here -->
            }
            else
            {
                if (sender.Equals(this.btnDelete))
                {
                    this.DgvValuesList_UserDeletingRow(null, null);
                }
                else if (sender.Equals(this.btnBrowse))
                {
                    this.BrowseFolder();
                }
                else if (sender.Equals(this.btnMoveUp))
                {
                    currentCommand = new DgvMoveUpCommand(this.dgvHandler);
                }
                else if (sender.Equals(this.btnMoveTop))
                {
                    currentCommand = new DgvMoveToTopCommand(this.dgvHandler);
                }
                else if (sender.Equals(this.btnMoveDown))
                {
                    currentCommand = new DgvMoveDownCommand(this.dgvHandler);
                }
                else if (sender.Equals(this.btnMoveBottom))
                {
                    currentCommand
                        = new DgvMoveToBottomCommand(this.dgvHandler);
                }
            }

            if (!sender.Equals(this.btnCancel))
            {
                this.AddCommand(currentCommand);
            }
        }

        /// <summary>
        /// Adds the command to commands undo/redo list.
        /// </summary>
        /// <param name="command">The command.</param>
        private void AddCommand(ICommand command)
        {
            if (command != null)
            {
                command.Execute();
                this.commandsList.Add(command);
            }

            this.SetBtnState();
        }

        /// <summary>
        /// Browses the folder.
        /// </summary>
        private void BrowseFolder()
        {
            bool isBottomRow
                = dgvValuesList.CurrentCell.RowIndex
                == dgvValuesList.Rows.Count - 1;

            if (!isBottomRow
                && dgvValuesList.CurrentCell.Value != null)
            {
                string cellValue = dgvValuesList.CurrentCell.Value.ToString();
                if (Directory.Exists(cellValue))
                {
                    folderBrowserDialog.SelectedPath = cellValue;
                }
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DgvBrowseFolderCommand browseFolderCommand = null;
                int rowIndex = 0;
                string selectedPath = folderBrowserDialog.SelectedPath;

                if (isBottomRow)
                {
                    rowIndex = this.dgvHandler.AddRow(selectedPath);
                    browseFolderCommand
                        = new DgvBrowseFolderCommand(this.dgvHandler);
                }
                else
                {
                    rowIndex = dgvValuesList.CurrentCell.RowIndex;
                    object value
                        = dgvValuesList.Rows[rowIndex].Cells[1].Value;

                    if (value != null)
                    {
                        browseFolderCommand
                            = new DgvBrowseFolderCommand(
                                this.dgvHandler, dgvValuesList.Rows[rowIndex]);
                    }
                    else
                    {
                        browseFolderCommand
                            = new DgvBrowseFolderCommand(this.dgvHandler);
                    }

                    this.dgvHandler.SetRowValue(rowIndex, selectedPath);
                    this.dgvHandler.SetRowIcon(rowIndex, selectedPath);
                }

                browseFolderCommand.NewRow = dgvValuesList.Rows[rowIndex];
                this.AddCommand(browseFolderCommand);
            }
        }

        /// <summary>
        /// Sets the state of the Buttons.
        /// if rowIndex = -1 - disable all buttons
        /// </summary>
        private void SetBtnState()
        {
            int rowIndex = 0;
            if (dgvValuesList.CurrentRow != null)
            {
                rowIndex = this.dgvValuesList.CurrentRow.Index;
            }

            // Enabled if no a bottom row
            btnMoveDown.Enabled
                = btnMoveBottom.Enabled
                = rowIndex < dgvValuesList.Rows.Count - 2;

            // Enabled if not a top row
            btnMoveTop.Enabled
                = btnMoveUp.Enabled
                = rowIndex > 0 && rowIndex != dgvValuesList.Rows.Count - 1;

            // disable on new row
            btnDelete.Enabled = rowIndex != dgvValuesList.Rows.Count - 1;

            // Import / Export
            btnExport.Enabled = dgvValuesList.Rows.Count != 1
                && txtVariableName.Text.Length != 0;

            // set Undo/Redo
            btnUndo.Enabled = this.commandsList.CanUndo;
            btnRedo.Enabled = this.commandsList.CanRedo;
            toolTip.SetToolTip(this.btnUndo, this.commandsList.UndoMsg);
            toolTip.SetToolTip(this.btnRedo, this.commandsList.RedoMsg);
        }

        /// <summary>
        /// Handles the FormClosed event of the Form EditEnvironmentVariable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        private void FrmEditEnvVar_FormClosed(
            object sender, FormClosedEventArgs e)
        {
            this.SaveSettings();
        }

        /// <summary>
        /// Handles the FormClosing event of the Form EditEnvVariable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void FrmEditEnvVar_FormClosing(
            object sender, FormClosingEventArgs e)
        {
            if (btnUndo.Enabled || txtVariableName.Text != this.variableName)
            {
                DialogResult result
                    = MessageBox.Show(
                    "Would you like to save your changes?",
                    "Save?",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button3);

                switch (result)
                {
                    case DialogResult.Cancel:   // Don't save or close a form
                        {
                            e.Cancel = true;
                        }

                        break;
                    case DialogResult.Yes:  // Save changes and close
                        {
                            this.SaveEnvironmentVariable();
                        }

                        break;
                    default:    // No - just close a form
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Validated event of the txtVariableName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtVariableName_Validated(object sender, EventArgs e)
        {
            if (this.isVarNameChanged)
            {
                this.editVarNameCommand.NewVarName = txtVariableName.Text;
                this.AddCommand(this.editVarNameCommand);

                // create command with new variable name
                this.editVarNameCommand
                    = new EditVarNameCommand(txtVariableName);
                this.isVarNameChanged = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtVariableName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtVariableName_TextChanged(object sender, EventArgs e)
        {
            if (this.editVarNameCommand != null
                && txtVariableName.Text
                != this.editVarNameCommand.CurrentVariableName)
            {
                this.isVarNameChanged = true;
            }
            else
            {
                this.isVarNameChanged = false;
            }
        }
        #endregion Form Functions

#if DEBUG
        #region Testing
        /// <summary>
        /// Gets the DataGridView reference. Use only in DEBUG.
        /// </summary>
        /// <value>The DataGridView reference.</value>
        public DataGridView DgView
        {
            get { return this.dgvValuesList; }
        }

        /// <summary>
        /// Reloads grid with specified variable. Use only in DEBUG.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varType">Type of the variable.</param>
        public void LoadEnvironmentVariableValues(
            string varName, EnvironmentVariableTarget varType)
        {
            this.txtVariableName.Text = varName;
            this.variableType = varType;
            this.dgvValuesList.Rows.Clear();
            this.commandsList.Clear();
            this.LoadEnvironmentVariableValues();
        }
        #endregion Testing
#endif
    }
}
