using System;
using System.Collections.Generic;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// ConsoleApp, class for starting console app with menu.
    /// </summary>
    public class ConsoleApp
    {
        private readonly Menu _menu;
        private MenuShowCommand _command;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleApp"/> class.
        /// </summary>
        /// <param name="menu">The menu.</param>
        /// <exception cref="System.ArgumentNullException">menu</exception>
        public ConsoleApp(Menu menu)
        {
            _menu = menu ?? throw new ArgumentNullException(nameof(menu));
            _command = new MenuShowCommand(_menu, false);
        }

        /// <summary>
        /// Starts this menu console app.
        /// </summary>
        public void Start()
        {
            _command.Execute();
        }
    }
}
