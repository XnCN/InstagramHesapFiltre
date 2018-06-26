using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Instagram
{
    class Instagram
    {
        public static string WebDocument;
        public static string RegexCheck(string regex)
        {
            Regex rg = new Regex(regex);
            Match match = rg.Match(WebDocument);
            if (match.Success) return TextConverter.ConvertUTF8(match.Groups[1].Value);
            return "";
        }
        public static string GetBiography()
        {
            //"biography":"(.*?)"
            //"\"biography\":\"(.*?)\""
            return RegexCheck("\"biography\":\"(.*?)\"");
        }
        public static string GetFullName()
        {
            //"full_name":"(.*?)"
            //"\"full_name\":\"(.*?)\""
            return RegexCheck("\"full_name\":\"(.*?)\"");
        }
        public static string GetUsername()
        {
            //"username":"(.*?)"
            //"\"username\":\"(.*?)\""
            return RegexCheck("\"username\":\"(.*?)\"");
        }
    }
}
