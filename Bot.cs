using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    class Bot
    {
       public static void BotStart()
        {
            Helper.Message("Bot Başlatılıyor", ConsoleColor.White);
            foreach (var username in Store.UserList)
            {
                List<string> data = new List<string>();
                Instagram.WebDocument = WebDriver.GetUser(username);
                string Biography = Instagram.GetBiography();
                string Name = Instagram.GetFullName();
                data.Add(string.Format("@{0}", username));
                data.Add(Name);
                data.Add(Biography);
                

                var UsernameCheck = Store.UsernameContainsList.Any(username.Contains);
                var NameCheck = Store.NameContainsList.Any(Name.Contains);
                var BiographyCheck = Store.BiographyContainsList.Any(Biography.Contains);

                if (UsernameCheck == true || NameCheck == true || BiographyCheck == true)
                {
                    Helper.BotMessage(data, ConsoleColor.Green, ConsoleColor.Black);
                    Store.NewUserList.Add(username);
                } 
                else
                    Helper.BotMessage(data, ConsoleColor.Red, ConsoleColor.Black);
                Helper.AutoSave();
            }
            Helper.Message(string.Format("Toplam {0} işlem tammalandı.{1} eşleşme başarılı , {2} eşleşme başarısız", Store.UserList.Length,Store.NewUserList.Count, Store.UserList.Length- Store.NewUserList.Count), ConsoleColor.Green);
            Settings.SaveNewUserList();
        }
    }
}
