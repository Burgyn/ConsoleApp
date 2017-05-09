using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Class, describe console menu.
    /// </summary>
    /// <seealso cref="MMLib.ConsoleApp.MenuItem" />
    public class Menu : MenuItem
    {
        private List<MenuItem> _items = new List<MenuItem>();

        /// <summary>
        /// Create insntace with <seealso cref="MenuBuilder"/>
        /// </summary>
        private Menu()
        {
        }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        public IEnumerable<MenuItem> Items => _items;

        private void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Gets the menu builder.
        /// </summary>
        public static MenuBuilder Builder => new MenuBuilder();

        public class MenuBuilder
        {
            private Menu _menu = new Menu();

            internal MenuBuilder()
            {

            }

            /// <summary>
            /// Adds the menu item.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="foreground">The foreground.</param>
            /// <param name="command">The command.</param>
            /// <exception cref="System.ArgumentNullException">command</exception>
            public MenuBuilder AddItem(ConsoleKey key, ICommand command)
            {
                if (command == null) throw new ArgumentNullException(nameof(command));

                _menu.AddItem(new MenuItem() { Key = key, Command = command });

                return this;
            }

            /// <summary>
            /// Adds the item with sub items.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="text">The text.</param>
            /// <param name="subMenu">The sub menu.</param>
            /// <returns></returns>
            public MenuBuilder AddItem(ConsoleKey key, string text, Menu subMenu) =>
                this.AddItem(key, new MenuShowCommand(subMenu, true) { Header = text });

            /// <summary>
            /// Adds the item.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="text">The text.</param>
            /// <param name="foreground">The foreground.</param>
            /// <param name="action">The action.</param>
            public MenuBuilder AddItem(ConsoleKey key, string text, Action action) =>
                this.AddItem(key, new DelegateCommand(action) { Header = text });

            /// <summary>
            /// Sets the default foreground.
            /// </summary>
            /// <param name="defaultForeground">The default foreground.</param>            
            public MenuBuilder SetDefaultForeground(ConsoleColor defaultForeground)
            {
                _menu.Foreground = defaultForeground;

                return this;
            }

            public Menu Build()
            {
                SetDefaultForeground();

                return _menu;
            }

            private void SetDefaultForeground()
            {
                foreach (var item in _menu.Items.Where(p => p.Foreground == ConsoleColor.White))
                {
                    item.Foreground = _menu.Foreground;
                }
            }
        }
    }
}
