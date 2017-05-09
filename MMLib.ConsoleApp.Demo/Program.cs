using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMLib.ConsoleApp;
using System.Net.NetworkInformation;

namespace MMLib.ConsoleApp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = Menu.Builder
                .SetDefaultForeground(ConsoleColor.DarkYellow)
                .AddItem(ConsoleKey.NumPad1, "Hello world", () =>
                {
                    Console.WriteLine("Hello world");
                    ConsoleHelper.PromptForContinue();
                })
                .AddItem(ConsoleKey.NumPad2, new PingCommand())
                .AddItem(ConsoleKey.NumPad3, "Item with subMenu",
                    Menu.Builder
                    .AddItem(ConsoleKey.NumPad1, "SubMenu item 1", () =>
                    {
                        Console.WriteLine("I'm SubMenu item 1");
                        ConsoleHelper.PromptForContinue();
                    })
                    .AddItem(ConsoleKey.NumPad2, "SubMenu item 2", () =>
                    {
                        Console.WriteLine("I'm SubMenu item 2");
                        ConsoleHelper.PromptForContinue();
                    })
                    .Build())
                .Build();

            var app = new ConsoleApp(menu);

            app.Start();
        }
    }

    public class PingCommand : CommandBase
    {
        public PingCommand()
        {
            this.Header = "Ping test";
        }

        public override void Execute()
        {
            Console.WriteLine("Ping test");
            Console.WriteLine();

            var url = ConsoleHelper.ReadString("Write url or IP address");
            Console.Clear();

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();            
            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(url, timeout, buffer, options);            
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }

            Console.WriteLine();
            ConsoleHelper.PromptForContinue();
        }
    }
}
