using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Instagram
{
    class Settings
    {
        public Settings()
        {
            LoadUserList();
            CheckSettings();
        }
        public static void LoadUserList()
        {
            try
            {
                Helper.CCSuccess();
                Store.UserList = File.ReadAllLines("userlist.txt");
                Console.WriteLine("Kullanıcılar listesi okundu toplam {0} profil bulunmakta", Store.UserList.Length);
            }
            catch
            {
                Helper.CCError();
                Console.WriteLine("Kullanıcılar listesi okunamadı userlist.txt dosyasını kontrol edin!");
                return;
            }
        }
        public static void SaveSettings()
        {
            string SettingsFile = "";
            foreach (var Username in Store.UsernameContainsList) SettingsFile += Username+",";
            SettingsFile = SettingsFile.Substring(0, SettingsFile.Length - 1) + "|";
            foreach (var Name in Store.NameContainsList) SettingsFile += Name + ",";
            SettingsFile = SettingsFile.Substring(0, SettingsFile.Length - 1) + "|";
            foreach (var Biography in Store.BiographyContainsList) SettingsFile += Biography + ",";
            SettingsFile = SettingsFile.Substring(0, SettingsFile.Length - 1);
            try
            {
                File.WriteAllText("settings.txt", SettingsFile);
                Helper.CCSuccess();
                Console.WriteLine("Ayarlar dosyanız başarıyla kayıt edilmiştir");
                
                
            }
            catch
            {
                Helper.CCError();
                Console.WriteLine("Ayarlar dosyanız kayıt edilememiştir.(yönetici olarak tekrar deneyin)");
            }
        }
        public static void CheckSettings()
        {
            try
            {
                string SettingsFile = File.ReadAllText("settings.txt");
                if (SettingsFile.Length < 2)
                {
                    Helper.CCInfo();
                    Console.WriteLine("Ayarlar dosyanız boş durumda lütfen aşağıdaki bilgiler ile doldurun");
                    Console.WriteLine("Kullanıcı adlarında bulunması gereken kelimeler(araları , ile ayırın):");
                    Helper.CCBlue();
                    Store.UsernameContainsList = Console.ReadLine().Split(',');
                    Helper.CCInfo();
                    Console.WriteLine("İsimde bulunması gereken kelimeler(araları , ile ayırın):");
                    Helper.CCBlue();
                    Store.NameContainsList = Console.ReadLine().Split(',');
                    Helper.CCInfo();
                    Console.WriteLine("Biyografide bulunması gereken kelimeler(araları , ile ayırın):");
                    Helper.CCBlue();
                    Store.BiographyContainsList = Console.ReadLine().Split(',');
                    SaveSettings();
                }
                else
                {
                    Helper.CCInfo();
                    Console.Write("Daha önceden kaydedilen ayarları kullanmak istermisiniz?(e,h): ");
                    if (Console.ReadLine() == "e")
                    {
                        LoadSettings();
                    }
                    else
                    {
                        File.WriteAllText("settings.txt", "");
                        Helper.CCSuccess();
                        Console.WriteLine("Ayarlar başarıyla temizlendi");
                        CheckSettings();
                    }
                }
            }
            catch
            {
                Helper.CCError();
                Console.WriteLine("Ayarlar okunamadı settings.txt dosyasını kontrol edin!");
                return;
            }
        }
        public static void SaveNewUserList()
        {
            try
            {
                File.WriteAllLines("newuserlist.txt", Store.NewUserList);
                Helper.Message("Yeni liste başarıyla kaydedildi", ConsoleColor.Cyan);
            }
            catch
            {
                Helper.Message("Yeni liste kaydedilirken hata oluştu", ConsoleColor.Red);
            }
        }
        public static void LoadSettings()
        {
            Helper.CCSuccess();
            string SettingsFile = File.ReadAllText("settings.txt");
            Store.UsernameContainsList = SettingsFile.Split('|')[0].Split(',');
            Store.NameContainsList = SettingsFile.Split('|')[1].Split(',');
            Store.BiographyContainsList = SettingsFile.Split('|')[2].Split(',');
            Console.WriteLine("Ayarlar dosyası başarıyla yüklendi");
            Helper.CCInfo();
            Console.Write("Kullanıcı adlarında bulunması gereken kelimeler:");
            Helper.CCBlue();
            foreach (var Username in Store.UsernameContainsList) Console.Write(Username + ",");
            Helper.CCInfo();
            Console.Write("\nİsimde bulunması gereken kelimeler:");
            Helper.CCBlue();
            foreach (var Name in Store.NameContainsList) Console.Write(Name + ",");
            Helper.CCInfo();
            Console.Write("\nBiyografide bulunması gereken kelimeler:");
            Helper.CCBlue();
            foreach (var Biography in Store.BiographyContainsList) Console.Write(Biography + ",");
        }
    }
}
