//------------------------------------------------------------------------
// <copyright file="SingleProgramInstance.cs" company="SETCHIN Freelance Consulting">
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

// This code is borrowed from Code Project post by Michael Potter
// http://www.codeproject.com/KB/cs/cssingprocess.aspx
namespace SFC.EnvMan
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;

    /// <summary>
    /// SingleProgramInstance uses a mutex synchronization object
    /// to ensure that only one copy of process is running at
    /// a particular time.  It also allows for UI identification
    /// of the initial process by bring that window to the foreground.
    /// </summary>
    public class SingleProgramInstance : IDisposable
    {
        #region Constants
        /// <summary>
        /// Constant for Restoration
        /// </summary>
        private const int SWRestore = 9;
        #endregion Constants

        #region Variables
        /// <summary>
        /// Process Sync
        /// </summary>
        private Mutex processSync;

        /// <summary>
        /// Indicates if process is owned
        /// </summary>
        private bool owned = false;
        #endregion Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleProgramInstance"/> class.
        /// </summary>
        public SingleProgramInstance()
        {
            // Initialize a named mutex and attempt to
            // get ownership immediately
            this.processSync = new Mutex(
                true, // desire initial ownership
                Assembly.GetExecutingAssembly().GetName().Name,
                out this.owned);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleProgramInstance"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        public SingleProgramInstance(string identifier)
        {
            // Initialize a named mutex and attempt to
            // get ownership immediately.
            // Use an additional identifier to lower
            // our chances of another process creating
            // a mutex with the same name.
            this.processSync = new Mutex(
                true, // desire initial ownership
                Assembly.GetExecutingAssembly().GetName().Name + identifier,
                out this.owned);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SingleProgramInstance"/> class.
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="SingleProgramInstance"/> is reclaimed by garbage collection.
        /// </summary>
        ~SingleProgramInstance()
        {
            // Release mutex (if necessary)
            // This should have been accomplished using Dispose()
            this.Release();
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// Gets a value indicating whether this instance is single instance.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is single instance; otherwise, <c>false</c>.
        /// </value>
        public bool IsSingleInstance
        {
            // If we don't own the mutex than
            // we are not the first instance.
            get { return this.owned; }
        }

        /// <summary>
        /// Raises the other process.
        /// </summary>
        public void RaiseOtherProcess()
        {
            Process proc = Process.GetCurrentProcess();

            // Using Process.ProcessName does not function properly when
            // the name exceeds 15 characters. Using the assembly name
            // takes care of this problem and is more accurate than other
            // work around.
            string assemblyName
                = Assembly.GetExecutingAssembly().GetName().Name;
            foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
            {
                // ignore this process
                if (proc.Id != otherProc.Id)
                {
                    // Found a "same named process".
                    // Assume it is the one we want brought to the foreground.
                    // Use the Win32 API to bring it to the foreground.
                    IntPtr hWnd = otherProc.MainWindowHandle;
                    if (IsIconic(hWnd))
                    {
                        ShowWindowAsync(hWnd, SWRestore);
                    }

                    SetForegroundWindow(hWnd);
                    return;
                }
            }
        }
        #endregion Properties

        #region Public Functions
        #region Implementation of IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // release mutex (if necessary) and notify
            // the garbage collector to ignore the destructor
            this.Release();
            GC.SuppressFinalize(this);
        }
        #endregion Implementation of IDisposable
        #endregion Public Functions

        #region Private Functions
        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>true - if success, false - if not</returns>
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Shows the window async.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="ncmdShow">The NCMD show.</param>
        /// <returns>
        /// true - if success, false - if not
        /// </returns>
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int ncmdShow);

        /// <summary>
        /// Determines whether the specified h WND is iconic.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns>
        ///   <c>true</c> if the specified h WND is iconic; otherwise, <c>false</c>.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Releases this instance.
        /// </summary>
        private void Release()
        {
            if (this.owned)
            {
                // If we owne the mutex than release it so that
                // other "same" processes can now start.
                this.processSync.ReleaseMutex();
                this.owned = false;
            }
        }
        #endregion Private Functions
        //// Win32 API calls necessary to raise an unowned process main window
    }
}
