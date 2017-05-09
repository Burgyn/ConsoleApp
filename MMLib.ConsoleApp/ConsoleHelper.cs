using System;
using System.Collections.Generic;
using System.Text;

namespace MMLib.ConsoleApp
{
    /// <summary>
    /// Helper class for manage console application.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Write prompts for continue.
        /// </summary>
        public static void PromptForContinue()
        {
            Console.Write(Properties.Resources.PressAnyKey);
            Console.ReadKey();
        }

        /// <summary>
        /// Reads the int value from console input.
        /// </summary>
        /// <returns>Int value if was write correct; otherwise throw exception.</returns>
        /// <exception cref="System.FormatException">Input string was not in a correct format.</exception>
        public static Int32 ReadInt() => Int32.Parse(Console.ReadLine());

        /// <summary>
        /// Reads the decimal value from console input.
        /// </summary>
        /// <returns>Decimal value if was write correct; otherwise throw exception.</returns>
        /// <exception cref="System.FormatException">Input string was not in a correct format.</exception>
        public static decimal ReadDecimal() => Decimal.Parse(Console.ReadLine());

        /// <summary>
        /// Reads the int value from console input.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>
        /// Int value if was write correct; otherwise throw exception.
        /// </returns>
        /// <exception cref="System.FormatException">Input string was not in a correct format.</exception>
        public static Int32 ReadInt(string prompt)
        {
            Console.Write($"{prompt }: ");
            return ReadInt();
        }

        /// <summary>
        /// Reads the decimal value from console input.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>
        /// Decimal value if was write correct; otherwise throw exception.
        /// </returns>
        /// <exception cref="System.FormatException">Input string was not in a correct format.</exception>
        public static decimal ReadDecimal(string prompt)
        {
            Console.Write($"{prompt }: ");
            return ReadDecimal();
        }

        /// <summary>
        /// Reads the string from console input.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>User string input.</returns>
        public static string ReadString(string prompt)
        {
            Console.Write($"{prompt }: ");
            return Console.ReadLine();
        }
    }
}
