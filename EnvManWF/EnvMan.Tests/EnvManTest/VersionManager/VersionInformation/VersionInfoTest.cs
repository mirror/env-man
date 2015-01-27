//------------------------------------------------------------------------
// <copyright file="VersionInfoTest.cs" company="SETCHIN Freelance Consulting">
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

namespace Envman.Tests.VersionManager.VersionInformation
{
    using System;
    using SFC.EnvMan.VersionManager.VersionInformation;
    using NUnit.Framework;

    /// <summary>
    /// Version Information tests
    /// </summary>
    [TestFixture]
    public class VersionInfoTest
    {
        /// <summary>
        /// Tests the version formatter1_4 R c1.
        /// </summary>
        [Test]
        public void TestVersionFormatter1_4RC1()
        {
            string versionString 
                = VersionInfo.VersionFormatter(new Version(1, 4, 0, 1));

            Assert.AreEqual("V1.4 RC1", versionString);
        }

        /// <summary>
        /// Tests the version formatter1_4.
        /// </summary>
        [Test]
        public void TestVersionFormatter1_4()
        {
            string versionString 
                = VersionInfo.VersionFormatter(new Version(1, 4, 0, 0));

            Assert.AreEqual("V1.4", versionString);
        }
    }
}
