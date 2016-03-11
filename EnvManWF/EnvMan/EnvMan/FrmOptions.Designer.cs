//------------------------------------------------------------------------
// <copyright file="FrmMain.Designer.cs" company="SETCHIN Freelance Consulting">
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
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.TctrlSettings = new System.Windows.Forms.TabControl();
            this.TpGeneral = new System.Windows.Forms.TabPage();
            this.CbOneInstance = new System.Windows.Forms.CheckBox();
            this.TpUpdateChecker = new System.Windows.Forms.TabPage();
            this.LblPasswordOptional = new System.Windows.Forms.Label();
            this.LblUserNameOptional = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.LblPort = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblUserName = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.LblAddress = new System.Windows.Forms.Label();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.CbUseProxy = new System.Windows.Forms.CheckBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TctrlSettings.SuspendLayout();
            this.TpGeneral.SuspendLayout();
            this.TpUpdateChecker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            //
            // TctrlSettings
            //
            this.TctrlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TctrlSettings.Controls.Add(this.TpGeneral);
            this.TctrlSettings.Controls.Add(this.TpUpdateChecker);
            this.TctrlSettings.Location = new System.Drawing.Point(2, 3);
            this.TctrlSettings.Name = "TctrlSettings";
            this.TctrlSettings.SelectedIndex = 0;
            this.TctrlSettings.Size = new System.Drawing.Size(302, 165);
            this.TctrlSettings.TabIndex = 0;
            //
            // TpGeneral
            //
            this.TpGeneral.Controls.Add(this.CbOneInstance);
            this.TpGeneral.Location = new System.Drawing.Point(4, 22);
            this.TpGeneral.Name = "TpGeneral";
            this.TpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TpGeneral.Size = new System.Drawing.Size(294, 139);
            this.TpGeneral.TabIndex = 0;
            this.TpGeneral.Text = "General";
            this.TpGeneral.UseVisualStyleBackColor = true;
            //
            // CbOneInstance
            //
            this.CbOneInstance.AutoSize = true;
            this.CbOneInstance.Checked = true;
            this.CbOneInstance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbOneInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CbOneInstance.Location = new System.Drawing.Point(16, 18);
            this.CbOneInstance.Name = "CbOneInstance";
            this.CbOneInstance.Size = new System.Drawing.Size(165, 17);
            this.CbOneInstance.TabIndex = 0;
            this.CbOneInstance.Text = "&Allow Only One Instance";
            this.CbOneInstance.UseVisualStyleBackColor = true;
            //
            // TpUpdateChecker
            //
            this.TpUpdateChecker.Controls.Add(this.LblPasswordOptional);
            this.TpUpdateChecker.Controls.Add(this.LblUserNameOptional);
            this.TpUpdateChecker.Controls.Add(this.TxtPort);
            this.TpUpdateChecker.Controls.Add(this.LblPort);
            this.TpUpdateChecker.Controls.Add(this.LblPassword);
            this.TpUpdateChecker.Controls.Add(this.TxtPassword);
            this.TpUpdateChecker.Controls.Add(this.LblUserName);
            this.TpUpdateChecker.Controls.Add(this.TxtUserName);
            this.TpUpdateChecker.Controls.Add(this.LblAddress);
            this.TpUpdateChecker.Controls.Add(this.TxtAddress);
            this.TpUpdateChecker.Controls.Add(this.CbUseProxy);
            this.TpUpdateChecker.Location = new System.Drawing.Point(4, 22);
            this.TpUpdateChecker.Name = "TpUpdateChecker";
            this.TpUpdateChecker.Padding = new System.Windows.Forms.Padding(3);
            this.TpUpdateChecker.Size = new System.Drawing.Size(294, 139);
            this.TpUpdateChecker.TabIndex = 1;
            this.TpUpdateChecker.Text = "Release Checker";
            this.TpUpdateChecker.UseVisualStyleBackColor = true;
            //
            // LblPasswordOptional
            //
            this.LblPasswordOptional.AutoSize = true;
            this.LblPasswordOptional.Enabled = false;
            this.LblPasswordOptional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPasswordOptional.Location = new System.Drawing.Point(194, 100);
            this.LblPasswordOptional.Name = "LblPasswordOptional";
            this.LblPasswordOptional.Size = new System.Drawing.Size(62, 13);
            this.LblPasswordOptional.TabIndex = 10;
            this.LblPasswordOptional.Text = "(Optional)";
            //
            // LblUserNameOptional
            //
            this.LblUserNameOptional.AutoSize = true;
            this.LblUserNameOptional.Enabled = false;
            this.LblUserNameOptional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblUserNameOptional.Location = new System.Drawing.Point(194, 74);
            this.LblUserNameOptional.Name = "LblUserNameOptional";
            this.LblUserNameOptional.Size = new System.Drawing.Size(62, 13);
            this.LblUserNameOptional.TabIndex = 9;
            this.LblUserNameOptional.Text = "(Optional)";
            //
            // TxtPort
            //
            this.TxtPort.Enabled = false;
            this.TxtPort.Location = new System.Drawing.Point(232, 45);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(48, 20);
            this.TxtPort.TabIndex = 8;
            this.TxtPort.Text = "80";
            this.TxtPort.Validating += new System.ComponentModel.CancelEventHandler(this.TxtValidating);
            //
            // LblPort
            //
            this.LblPort.AutoSize = true;
            this.LblPort.Enabled = false;
            this.LblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPort.Location = new System.Drawing.Point(203, 48);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(30, 13);
            this.LblPort.TabIndex = 7;
            this.LblPort.Text = "Port";
            this.LblPort.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // LblPassword
            //
            this.LblPassword.AutoSize = true;
            this.LblPassword.Enabled = false;
            this.LblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPassword.Location = new System.Drawing.Point(18, 100);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(61, 13);
            this.LblPassword.TabIndex = 6;
            this.LblPassword.Text = "&Password";
            //
            // TxtPassword
            //
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Location = new System.Drawing.Point(88, 97);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(100, 20);
            this.TxtPassword.TabIndex = 5;
            //
            // LblUserName
            //
            this.LblUserName.AutoSize = true;
            this.LblUserName.Enabled = false;
            this.LblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblUserName.Location = new System.Drawing.Point(18, 74);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(69, 13);
            this.LblUserName.TabIndex = 4;
            this.LblUserName.Text = "User &Name";
            //
            // TxtUserName
            //
            this.TxtUserName.Enabled = false;
            this.TxtUserName.Location = new System.Drawing.Point(88, 71);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(100, 20);
            this.TxtUserName.TabIndex = 3;
            //
            // LblAddress
            //
            this.LblAddress.AutoSize = true;
            this.LblAddress.Enabled = false;
            this.LblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblAddress.Location = new System.Drawing.Point(18, 48);
            this.LblAddress.Name = "LblAddress";
            this.LblAddress.Size = new System.Drawing.Size(52, 13);
            this.LblAddress.TabIndex = 2;
            this.LblAddress.Text = "&Address";
            //
            // TxtAddress
            //
            this.TxtAddress.Enabled = false;
            this.TxtAddress.Location = new System.Drawing.Point(88, 45);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(100, 20);
            this.TxtAddress.TabIndex = 1;
            this.TxtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.TxtValidating);
            //
            // CbUseProxy
            //
            this.CbUseProxy.AutoSize = true;
            this.CbUseProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CbUseProxy.Location = new System.Drawing.Point(16, 16);
            this.CbUseProxy.Name = "CbUseProxy";
            this.CbUseProxy.Size = new System.Drawing.Size(83, 17);
            this.CbUseProxy.TabIndex = 0;
            this.CbUseProxy.Text = "&Use Proxy";
            this.CbUseProxy.UseVisualStyleBackColor = true;
            this.CbUseProxy.CheckedChanged += new System.EventHandler(this.CbUseProxy_CheckedChanged);
            //
            // BtnOK
            //
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOK.Location = new System.Drawing.Point(144, 177);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "&Save";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            //
            // BtnCancel
            //
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnCancel.Location = new System.Drawing.Point(225, 177);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            //
            // errorProvider
            //
            this.errorProvider.ContainerControl = this;
            //
            // FrmOptions
            //
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(304, 209);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TctrlSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TctrlSettings.ResumeLayout(false);
            this.TpGeneral.ResumeLayout(false);
            this.TpGeneral.PerformLayout();
            this.TpUpdateChecker.ResumeLayout(false);
            this.TpUpdateChecker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TctrlSettings;
        private System.Windows.Forms.TabPage TpGeneral;
        private System.Windows.Forms.TabPage TpUpdateChecker;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox CbOneInstance;
        private System.Windows.Forms.Label LblAddress;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.CheckBox CbUseProxy;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.Label LblPasswordOptional;
        private System.Windows.Forms.Label LblUserNameOptional;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
