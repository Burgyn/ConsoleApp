using System;
using System.Collections.Generic;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Base command.
    /// </summary>
    /// <seealso cref="MMLib.ConsoleApp.ICommand" />
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// Gets or sets the command header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Executes this command.
        /// </summary>
        public abstract void Execute();
    }
}
