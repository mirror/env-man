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

using SFC.EnvMan.Properties;

namespace SFC.EnvMan
{
    partial class EnvManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbUserVariables = new System.Windows.Forms.GroupBox();
            this.btnDeleteUserVariable = new System.Windows.Forms.Button();
            this.btnEditUserVariable = new System.Windows.Forms.Button();
            this.btnNewUserVariable = new System.Windows.Forms.Button();
            this.dgvUserVariables = new System.Windows.Forms.DataGridView();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSystemVariables = new System.Windows.Forms.GroupBox();
            this.btnDeleteSystemVariable = new System.Windows.Forms.Button();
            this.btnEditSystemVariable = new System.Windows.Forms.Button();
            this.btnNewSystemVariable = new System.Windows.Forms.Button();
            this.dgvSystemVariables = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbUserVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserVariables)).BeginInit();
            this.gbSystemVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemVariables)).BeginInit();
            this.SuspendLayout();
            //
            // splitContainer
            //
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainer.Panel1
            //
            this.splitContainer.Panel1.Controls.Add(this.gbUserVariables);
            //
            // splitContainer.Panel2
            //
            this.splitContainer.Panel2.Controls.Add(this.gbSystemVariables);
            this.splitContainer.Size = new System.Drawing.Size(359, 416);
            this.splitContainer.SplitterDistance = 197;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SplitContainer_MouseDoubleClick);
            //
            // gbUserVariables
            //
            this.gbUserVariables.Controls.Add(this.btnDeleteUserVariable);
            this.gbUserVariables.Controls.Add(this.btnEditUserVariable);
            this.gbUserVariables.Controls.Add(this.btnNewUserVariable);
            this.gbUserVariables.Controls.Add(this.dgvUserVariables);
            this.gbUserVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUserVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUserVariables.Location = new System.Drawing.Point(0, 0);
            this.gbUserVariables.Name = "gbUserVariables";
            this.gbUserVariables.Size = new System.Drawing.Size(359, 197);
            this.gbUserVariables.TabIndex = 4;
            this.gbUserVariables.TabStop = false;
            this.gbUserVariables.Text = "&User Variables for ";
            //
            // btnDeleteUserVariable
            //
            this.btnDeleteUserVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteUserVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUserVariable.Image = global::SFC.EnvMan.Properties.Resources.delete;
            this.btnDeleteUserVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUserVariable.Location = new System.Drawing.Point(268, 168);
            this.btnDeleteUserVariable.Name = "btnDeleteUserVariable";
            this.btnDeleteUserVariable.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteUserVariable.TabIndex = 7;
            this.btnDeleteUserVariable.Text = "&Delete";
            this.toolTip.SetToolTip(this.btnDeleteUserVariable, global::SFC.EnvMan.Properties.Resources.ToolTipDeleteVariable);
            this.btnDeleteUserVariable.UseVisualStyleBackColor = true;
            this.btnDeleteUserVariable.Click += new System.EventHandler(this.BtnClick);
            //
            // btnEditUserVariable
            //
            this.btnEditUserVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditUserVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUserVariable.Image = global::SFC.EnvMan.Properties.Resources.Edit;
            this.btnEditUserVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditUserVariable.Location = new System.Drawing.Point(178, 168);
            this.btnEditUserVariable.Name = "btnEditUserVariable";
            this.btnEditUserVariable.Size = new System.Drawing.Size(84, 23);
            this.btnEditUserVariable.TabIndex = 6;
            this.btnEditUserVariable.Text = "&Edit";
            this.toolTip.SetToolTip(this.btnEditUserVariable, global::SFC.EnvMan.Properties.Resources.ToolTipEditVariable);
            this.btnEditUserVariable.UseVisualStyleBackColor = true;
            this.btnEditUserVariable.Click += new System.EventHandler(this.BtnClick);
            //
            // btnNewUserVariable
            //
            this.btnNewUserVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewUserVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUserVariable.Image = global::SFC.EnvMan.Properties.Resources.NewRecord;
            this.btnNewUserVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewUserVariable.Location = new System.Drawing.Point(88, 168);
            this.btnNewUserVariable.Name = "btnNewUserVariable";
            this.btnNewUserVariable.Size = new System.Drawing.Size(84, 23);
            this.btnNewUserVariable.TabIndex = 5;
            this.btnNewUserVariable.Text = "&New";
            this.toolTip.SetToolTip(this.btnNewUserVariable, global::SFC.EnvMan.Properties.Resources.ToolTipCreateNewVariable);
            this.btnNewUserVariable.UseVisualStyleBackColor = true;
            this.btnNewUserVariable.Click += new System.EventHandler(this.BtnClick);
            //
            // dgvUserVariables
            //
            this.dgvUserVariables.AllowUserToAddRows = false;
            this.dgvUserVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.dgvUserVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUserVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.Value});
            this.dgvUserVariables.Location = new System.Drawing.Point(6, 20);
            this.dgvUserVariables.MultiSelect = false;
            this.dgvUserVariables.Name = "dgvUserVariables";
            this.dgvUserVariables.RowHeadersVisible = false;
            this.dgvUserVariables.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUserVariables.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserVariables.Size = new System.Drawing.Size(346, 142);
            this.dgvUserVariables.TabIndex = 4;
            this.dgvUserVariables.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvUserDeletingRow);
            this.dgvUserVariables.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCellMouseDoubleClick);
            //
            // Variable
            //
            this.Variable.HeaderText = "Variable";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            this.Variable.Width = 78;
            //
            // Value
            //
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 64;
            //
            // gbSystemVariables
            //
            this.gbSystemVariables.Controls.Add(this.btnDeleteSystemVariable);
            this.gbSystemVariables.Controls.Add(this.btnEditSystemVariable);
            this.gbSystemVariables.Controls.Add(this.btnNewSystemVariable);
            this.gbSystemVariables.Controls.Add(this.dgvSystemVariables);
            this.gbSystemVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSystemVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSystemVariables.Location = new System.Drawing.Point(0, 0);
            this.gbSystemVariables.Name = "gbSystemVariables";
            this.gbSystemVariables.Size = new System.Drawing.Size(359, 215);
            this.gbSystemVariables.TabIndex = 6;
            this.gbSystemVariables.TabStop = false;
            this.gbSystemVariables.Text = "&System variables";
            //
            // btnDeleteSystemVariable
            //
            this.btnDeleteSystemVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSystemVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSystemVariable.Image = global::SFC.EnvMan.Properties.Resources.delete;
            this.btnDeleteSystemVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSystemVariable.Location = new System.Drawing.Point(268, 184);
            this.btnDeleteSystemVariable.Name = "btnDeleteSystemVariable";
            this.btnDeleteSystemVariable.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteSystemVariable.TabIndex = 7;
            this.btnDeleteSystemVariable.Text = "De&lete";
            this.toolTip.SetToolTip(this.btnDeleteSystemVariable, global::SFC.EnvMan.Properties.Resources.ToolTipDeleteVariable);
            this.btnDeleteSystemVariable.UseVisualStyleBackColor = true;
            this.btnDeleteSystemVariable.Click += new System.EventHandler(this.BtnClick);
            //
            // btnEditSystemVariable
            //
            this.btnEditSystemVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSystemVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSystemVariable.Image = global::SFC.EnvMan.Properties.Resources.Edit;
            this.btnEditSystemVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditSystemVariable.Location = new System.Drawing.Point(178, 184);
            this.btnEditSystemVariable.Name = "btnEditSystemVariable";
            this.btnEditSystemVariable.Size = new System.Drawing.Size(84, 23);
            this.btnEditSystemVariable.TabIndex = 6;
            this.btnEditSystemVariable.Text = "Ed&it";
            this.toolTip.SetToolTip(this.btnEditSystemVariable, global::SFC.EnvMan.Properties.Resources.ToolTipEditVariable);
            this.btnEditSystemVariable.UseVisualStyleBackColor = true;
            this.btnEditSystemVariable.Click += new System.EventHandler(this.BtnClick);
            //
            // btnNewSystemVariable
            //
            this.btnNewSystemVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSystemVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSystemVariable.Image = global::SFC.EnvMan.Properties.Resources.NewRecord;
            this.btnNewSystemVariable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSystemVariable.Location = new System.Drawing.Point(88, 184);
            this.btnNewSystemVariable.Name = "btnNewSystemVariable";
            this.btnNewSystemVariable.Size = new System.Drawing.Size(84, 23);
            this.btnNewSystemVariable.TabIndex = 5;
            this.btnNewSystemVariable.Text = "Ne&w";
            this.toolTip.SetToolTip(this.btnNewSystemVariable, global::SFC.EnvMan.Properties.Resources.ToolTipCreateNewVariable);
            this.btnNewSystemVariable.UseVisualStyleBackColor = true;
            this.btnNewSystemVariable.Click += new System.EventHandler(this.BtnClick);
            //
            // dgvSystemVariables
            //
            this.dgvSystemVariables.AllowUserToAddRows = false;
            this.dgvSystemVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.dgvSystemVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSystemVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSystemVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSystemVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSystemVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSystemVariables.Location = new System.Drawing.Point(6, 20);
            this.dgvSystemVariables.MultiSelect = false;
            this.dgvSystemVariables.Name = "dgvSystemVariables";
            this.dgvSystemVariables.RowHeadersVisible = false;
            this.dgvSystemVariables.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSystemVariables.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSystemVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSystemVariables.Size = new System.Drawing.Size(346, 158);
            this.dgvSystemVariables.TabIndex = 4;
            this.dgvSystemVariables.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvUserDeletingRow);
            this.dgvSystemVariables.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvCellMouseDoubleClick);
            //
            // dataGridViewTextBoxColumn1
            //
            this.dataGridViewTextBoxColumn1.HeaderText = "Variable";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            //
            // dataGridViewTextBoxColumn2
            //
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 64;
            //
            // EnvManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "EnvManager";
            this.Size = new System.Drawing.Size(359, 416);
            this.Load += new System.EventHandler(this.EnvManager_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.gbUserVariables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserVariables)).EndInit();
            this.gbSystemVariables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemVariables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbUserVariables;
        private System.Windows.Forms.Button btnDeleteUserVariable;
        private System.Windows.Forms.Button btnEditUserVariable;
        private System.Windows.Forms.Button btnNewUserVariable;
        private System.Windows.Forms.DataGridView dgvUserVariables;
        private System.Windows.Forms.GroupBox gbSystemVariables;
        private System.Windows.Forms.Button btnDeleteSystemVariable;
        private System.Windows.Forms.Button btnEditSystemVariable;
        private System.Windows.Forms.Button btnNewSystemVariable;
        private System.Windows.Forms.DataGridView dgvSystemVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolTip toolTip;

    }
}
