using System;
using System.Collections.Generic;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Interface, which describe menu command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets or sets the command header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        string Header { get; set; }

        /// <summary>
        /// Executes this command.
        /// </summary>
        void Execute();
    }
}
