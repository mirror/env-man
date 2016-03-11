//------------------------------------------------------------------------
// <copyright file="EnvVarManager.cs" company="SETCHIN Freelance Consulting">
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
    using System.Runtime.InteropServices;
    using IWshRuntimeLibrary;

    /// <summary>
    /// Environment Variables Manager
    /// </summary>
    public class EnvVarManager
    {
        #region Constants
        /// <summary>
        /// HWND BROADCAST
        /// </summary>
        public const int HwndBroadcast = 0xffff;

        /// <summary>
        /// WM SETTINGCHANGE
        /// </summary>
        public const int WMSettingChange = 0x001A;

        /// <summary>
        /// SMTO NORMAL
        /// </summary>
        public const int SmtoNormal = 0x0000;

        /// <summary>
        /// SMTO BLOCK
        /// </summary>
        public const int SmtoBlock = 0x0001;

        /// <summary>
        /// SMTO ABORTIFHUNG
        /// </summary>
        public const int SmtoAbortIfHung = 0x0002;

        /// <summary>
        /// SMTO NOTIMEOUTIFNOTHUNG
        /// </summary>
        public const int SmtoNoTimeoutIfNothing = 0x0008;

        /// <summary>
        /// Registry Key for User Keys
        /// </summary>
        private const string UserRegistryKey
            = @"HKEY_CURRENT_USER\Environment\";

        /// <summary>
        /// System Registry Keys
        /// </summary>
        private const string SystemRegistryKey
            = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet"
            + @"\Control\Session Manager\Environment\";
        #endregion Constants

        #region Variables
        /// <summary>
        /// Shell Extensions
        /// </summary>
        private WshShell shell = new WshShell();
        #endregion Variables

        #region Constructor

        #endregion Constructor

        #region Events

        #endregion Events

        #region Properties

        #endregion Properties

        #region Public Functions
        /// <summary>
        /// Gets all environment variables for given variable type.
        /// </summary>
        /// <param name="varType">Type of the variable.</param>
        /// <returns>List of Environment Variables</returns>
        public IDictionary GetEnvVariables(EnvironmentVariableTarget varType)
        {
            return Environment.GetEnvironmentVariables(varType);
        }

        /// <summary>
        /// Expands the environment variable.
        /// </summary>
        /// <param name="variableName">Name of the variable.</param>
        /// <returns>Expended Variable String</returns>
        public string ExpandEnvironmentVariable(string variableName)
        {
            string varValue = Environment.ExpandEnvironmentVariables(variableName);

            return varValue;
        }

        /// <summary>
        /// Gets the environment variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="variableType">Type of the variable.</param>
        /// <returns>Environment Variable</returns>
        public string GetEnvironmentVariable(
            string varName, EnvironmentVariableTarget variableType)
        {
            object objValue
                = this.shell.RegRead(this.RegistryKey(variableType) + varName);

            return objValue.ToString();
        }

        /// <summary>
        /// Sets the environment variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="variableValue">The variable value.</param>
        /// <param name="varType">Type of the variable.</param>
        public void SetEnvironmentVariable(
            string varName, string variableValue, EnvironmentVariableTarget varType)
        {
            this.ValidateVariables(varName, variableValue);

            bool isRegExpandSz = variableValue.Contains("%");

            this.SetVariable(
                this.RegistryKey(varType) + varName, variableValue, isRegExpandSz);
        }

        /// <summary>
        /// Deletes the environment variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="variableType">Type of the variable.</param>
        public void DeleteEnvironmentVariable(
            string varName, EnvironmentVariableTarget variableType)
        {
            Environment.SetEnvironmentVariable(varName, null, variableType);
        }
        #endregion Public Functions

        #region Internal Functions

        #endregion Internal Functions

        #region Protected Functions

        #endregion Protected Functions

        #region Private Functions
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SendMessageTimeout(
            IntPtr hWnd,
            int msg,
            int wParam,
            string lParam,
            int fuFlags,
            int uTimeout,
            out int lpdwResult);

        #region Validation
        /// <summary>
        /// Validates the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="varValue">The variable value.</param>
#if DEBUG
        public void ValidateVariables(string varName, string varValue)
#else
        private void ValidateVariables(string varName, string varValue)
#endif
        {
            if (string.IsNullOrEmpty(varName))
            {
                throw new Exception("Variable Name cannot be blank.");
            }

            if (string.IsNullOrEmpty(varValue))
            {
                throw new Exception("Variable should have a value.");
            }
        }
        #endregion Validation

        /// <summary>
        /// Gets the registry key for variable type.
        /// </summary>
        /// <param name="varType">Type of the variable.</param>
        /// <returns>Registry key by Variable Type</returns>
        private string RegistryKey(EnvironmentVariableTarget varType)
        {
            return (varType == EnvironmentVariableTarget.User)
                ? UserRegistryKey : SystemRegistryKey;
        }

        ////
        //// Thank you Greg Houston for a good solution
        //// http://ghouston.blogspot.com/2005/08/how-to-create-and-change-environment.html

        /// <summary>
        /// Sets the variable.
        /// </summary>
        /// <param name="fullpath">The full path.</param>
        /// <param name="value">The value.</param>
        /// <param name="isRegExpandSz">if set to <c>true</c> [is registry expand variable].</param>
        private void SetVariable(
            string fullpath, string value, bool isRegExpandSz)
        {
            object objValue = value;
            object objType = isRegExpandSz ? "REG_EXPAND_SZ" : "REG_SZ";

            this.shell.RegWrite(fullpath, ref objValue, ref objType);

            int result;
            SendMessageTimeout(
                (System.IntPtr)HwndBroadcast,
                WMSettingChange,
                0,
                "Environment",
                SmtoBlock | SmtoAbortIfHung | SmtoNoTimeoutIfNothing,
                5000,
                out result);
        }
        #endregion Private Functions
    }
}
