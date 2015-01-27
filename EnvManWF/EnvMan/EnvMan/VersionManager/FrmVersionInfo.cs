//------------------------------------------------------------------------
// <copyright file="FrmVersionInfo.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.VersionManager
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Version Information Form
    /// </summary>
    public partial class FrmVersionInfo : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmVersionInfo"/> class.
        /// </summary>
        public FrmVersionInfo()
        {
            this.InitializeComponent();

            this.Text = "EnvMan - New version detected";
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            set { this.lblMessage.Text = value; }
        }

#if DEBUG
        /// <summary>
        /// Gets the OK Button.
        /// </summary>
        /// <value>The OK Button.</value>
        public Button BtnOk
        {
            get
            {
                return this.btnOK;
            }
        }

        /// <summary>
        /// Gets the Cancel Button.
        /// </summary>
        /// <value>The Cancel Button.</value>
        public Button BtnCancel
        {
            get
            {
                return this.btnCancel;
            }
        }
#endif

        /// <summary>
        /// BTNs the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
#if DEBUG
        public void BtnClick(object sender, EventArgs e)
#else
        private void BtnClick(object sender, EventArgs e)
#endif
        {
            if (sender.Equals(this.btnCancel))
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (sender.Equals(this.btnOK))
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Hide();
        }
    }
}