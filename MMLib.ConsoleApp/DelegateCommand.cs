using System;
using System.Collections.Generic;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Command, which execute delegate function which get from constructor.
    /// </summary>
    /// <seealso cref="MMLib.ConsoleApp.CommandBase" />
    public class DelegateCommand : CommandBase
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="action">The action for executing.</param>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public DelegateCommand(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Executes this command.
        /// </summary>
        public override void Execute()
        {
            _action();
        }
    }
}
