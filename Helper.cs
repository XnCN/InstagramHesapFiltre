using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    class Helper
    {
        public static void CCBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public static void CCReset()
        {
            Console.ResetColor();
        }
        public static void CCError()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        public static void CCSuccess()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        public static void CCInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void SpamProtector()
        {
            Store.SpamProtectorIndex++;
            if (Store.SpamProtectorIndex == 150)
            {
                Message("Spam koruması 15 saniye", ConsoleColor.Cyan);
                Store.SpamProtectorIndex = 0;
                System.Threading.Thread.Sleep(30000);
            }
        }
        public static void AutoSave()
        {
            if (Store.BootComplateCount % 150 == 0)
            {
                Settings.SaveNewUserList();
            }
        }
        public static void SpamController()
        {
            Store.SpamControllerIndex++;
            if (Store.SpamControllerIndex >= 2)
            {
                Message("İnstagram tarafından engellendi,1 dakika bekleniyor...", ConsoleColor.Cyan);
                Store.SpamControllerIndex = 0;
                System.Threading.Thread.Sleep(60000);
            }
        }
        public static void Message(string message, ConsoleColor ForegroundColor)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.Write("\n");
            for (int i = 0; i < Console.WindowWidth; i++) Console.Write("-");
            if (Console.WindowWidth <= message.Length)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
                Console.WriteLine(message);
            }       
            for (int i = 0; i < Console.WindowWidth; i++) Console.Write("-");
            Console.Write("\n");
            CCReset();
        }
        public static void BotMessage(List<string> texts, ConsoleColor ForegroundColor, ConsoleColor Backgroundcolor)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = Backgroundcolor;
            for (int i = 0; i < Console.WindowWidth; i++) Console.Write("-");
            foreach (var message in texts)
            {
                Console.WriteLine(message);
            }
            for (int i = 0; i < Console.WindowWidth; i++) Console.Write("-");
            Store.BootComplateCount++;
            Console.WriteLine(Store.BootComplateCount);
            CCReset();
        }
    }
}
