using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Command for showing menu.
    /// </summary>
    /// <seealso cref="MMLib.ConsoleApp.CommandBase" />
    internal class MenuShowCommand : CommandBase
    {
        private readonly bool _isSubMenu;
        private readonly Menu _menu;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuShowCommand" /> class.
        /// </summary>
        /// <param name="menu">The menu.</param>
        /// <param name="isSubMenu">if set to <c>true</c> [is sub menu].</param>
        /// <exception cref="System.ArgumentNullException">menu</exception>
        public MenuShowCommand(Menu menu, bool isSubMenu)
        {
            _menu = menu ?? throw new ArgumentNullException(nameof(menu));
            _isSubMenu = isSubMenu;
        }

        /// <summary>
        /// Show menu.
        /// </summary>
        public override void Execute()
        {
            var canContinue = true;

            while (canContinue)
            {
                PrintMenu();

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Backspace)
                {
                    canContinue = false;
                }
                else
                {
                    Console.Clear();

                    var menuItem = _menu.Items.FirstOrDefault(p => p.Key == key.Key);
                    if (menuItem != null)
                    {
                        menuItem.Command.Execute();
                    }
                }
            }
        }

        private void PrintMenu()
        {
            Console.Clear();
            var actualForeground = Console.ForegroundColor;
            Console.ForegroundColor = _menu.Foreground;

            foreach (var item in _menu.Items)
            {
                Console.ForegroundColor = item.Foreground;
                Console.WriteLine($"{KeyToString(item.Key)}: {item.Command.Header}");
            }

            PrintEndChoice();

            Console.WriteLine();
            Console.Write("Your choice:");

            Console.ForegroundColor = actualForeground;
        }

        private void PrintEndChoice()
        {
            Console.WriteLine("...");
            if (_isSubMenu)
            {
                Console.WriteLine($"{ConsoleKey.Backspace}: Back to main menu");
            }
            else
            {
                Console.WriteLine($"{ConsoleKey.Escape}: Exit app");
            }
        }

        private string KeyToString(ConsoleKey key)
        {
            if (key >= ConsoleKey.NumPad0 && key <= ConsoleKey.NumPad9)
            {
                return key.ToString().Replace("NumPad", string.Empty);
            }
            else
            {
                return key.ToString();
            }
        }
    }
}
