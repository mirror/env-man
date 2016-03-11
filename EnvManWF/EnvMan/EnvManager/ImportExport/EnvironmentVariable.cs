//------------------------------------------------------------------------
// <copyright file="EnvironmentVariable.cs" company="SETCHIN Freelance Consulting">
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

namespace SFC.EnvMan.ImportExport
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Environment Variable
    /// </summary>
    [Serializable]
    public class EnvironmentVariable
    {
        /// <summary>
        /// Variable Values Separator
        /// </summary>
        private const char Separator = ';';

        /// <summary>
        /// Variable Name
        /// </summary>
        private string varName;

        /// <summary>
        /// Variable Values
        /// </summary>
        private List<string> varValues = new List<string>();

        /// <summary>
        /// Gets or sets the name of the environment variable.
        /// </summary>
        /// <value>The name of the variable.</value>
        public string VarName
        {
            get { return this.varName; }

            set { this.varName = value; }
        }

        /// <summary>
        /// Gets or sets the variable values list.
        /// </summary>
        /// <value>
        /// The variable values list.
        /// </value>
        [XmlArray("VariableValues")]
        [XmlArrayItem("Value", typeof(string))]
        public List<string> VarValuesList
        {
            get
            {
                return this.varValues;
            }

            set
            {
                this.varValues.Clear();
                this.varValues = value;
            }
        }

        /// <summary>
        /// Sets the variable values.
        /// </summary>
        /// <value>
        /// The variable values.
        /// </value>
        [XmlIgnore]
        public string VarValues
        {
            set
            {
                string[] values = value.Split(Separator);

                this.varValues.AddRange(values);
            }
        }
    }
}
