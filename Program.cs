using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Instagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome welcome = new Welcome();
            Settings settings = new Settings();
            Bot.BotStart();
            Console.ReadKey();
        }
    }
}
