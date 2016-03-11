//------------------------------------------------------------------------
// <copyright file="EnvVarValueValidator.cs" company="SETCHIN Freelance Consulting">
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
    using System.Text.RegularExpressions;
    using global::SFC.EnvMan.Handlers;

    /// <summary>
    /// Specifies types of Environment Values
    /// </summary>
    public enum EnvironmentValueType
    {
        /// <summary>
        /// Number Variable type
        /// </summary>
        Number,

        /// <summary>
        /// String Variable Type
        /// </summary>
        String,

        /// <summary>
        ///  Folder Variable Type
        /// </summary>
        Folder,

        /// <summary>
        /// File Variable Type
        /// </summary>
        File,

        /// <summary>
        /// Error Variable Type
        /// </summary>
        Error
    }

    /// <summary>
    /// Validates Environment Variable Value
    /// </summary>
    public class EnvVarValueValidator
    {
        /// <summary>
        /// Check the type of the Environment Variable.
        /// </summary>
        /// <param name="varValue">The Variable Value.</param>
        /// <returns>Variable Type</returns>
        public EnvironmentValueType ValueType(string varValue)
        {
            EnvironmentValueType type = EnvironmentValueType.String;

            if (this.IsNumber(varValue))
            {
                type = EnvironmentValueType.Number;
            }
            else if (varValue.Length >= 3
                && varValue.Substring(0, 3).Contains(@":\"))
            {
                // Make sure that path starts with "C:\" where "C" is a drive letter
                if (System.IO.File.Exists(varValue))
                {
                    type = EnvironmentValueType.File;
                }
                else if (System.IO.Directory.Exists(varValue))
                {
                    type = EnvironmentValueType.Folder;
                }
                else
                {
                    type = EnvironmentValueType.Error;
                }
            }

            return type;
        }

        //// Function to test whether the string is valid number or not

        /// <summary>
        /// Validates the specified variable value.
        /// </summary>
        /// <param name="varValue">The variable value.</param>
        /// <returns>True if valid and False if not</returns>
        public bool Validate(string varValue)
        {
            bool result = true;

            string[] values = varValue.Split(DgvHandler.Separator);
            string value = string.Empty;

            foreach (string currentValue in values)
            {
                value = Environment.ExpandEnvironmentVariables(currentValue);
                if (this.ValueType(value) == EnvironmentValueType.Error)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified string is number.
        /// </summary>
        /// <param name="strNumber">The string to check.</param>
        /// <returns>
        ///     <c>true</c> if the specified string is number; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            string strValidRealPattern
                = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            string strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern
                = new Regex(
                    "(" + strValidRealPattern + ")|("
                    + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }
    }
}
