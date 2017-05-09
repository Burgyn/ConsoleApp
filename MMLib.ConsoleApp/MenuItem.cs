using System;
using System.Collections.Generic;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Class, which describe menu item.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the key, which describe command.
        /// </summary>
        public ConsoleKey Key { get; set; }

        /// <summary>
        /// Gets or sets the foreground.
        /// </summary>
        public ConsoleColor Foreground { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public ICommand Command { get; set; }
    }
}
