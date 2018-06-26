using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    class Store
    {
        public static string[] UserList;
        public static string[] UsernameContainsList;
        public static string[] NameContainsList;
        public static string[] BiographyContainsList;
        public static List<string> NewUserList =new List<string>();
        public static int SpamProtectorIndex=0;
        public static int SpamControllerIndex = 0;
        public static int BootComplateCount = 0;
    }
}
