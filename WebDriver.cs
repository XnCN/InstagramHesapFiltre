using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Instagram
{
    class WebDriver
    {
        public static string GetUser(string username)
        {
            string Data="";
            try
            {
                WebClient wc = new WebClient();
                Data = wc.DownloadString("https://www.instagram.com/" + username + "/?hl=tr");
            }
            catch
            {
                Helper.SpamController();
                Helper.CCError();
                Console.WriteLine("Instagram'a bağlanırken hata oluştu, tekrar deneniyor...");
                Helper.CCReset();
            }
            return Data;
        }
    }
}
