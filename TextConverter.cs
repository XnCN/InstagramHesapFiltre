using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Instagram
{
    class TextConverter
    {
        public static string ConvertUTF8(string text)
        {
            //http://www.fileformat.info/info/charset/UTF-8/list.htm
            Hashtable replacetable = new Hashtable();
            replacetable.Add(@"\u0130", "i");
            replacetable.Add(@"\u0131", "ı");
            replacetable.Add(@"\u00c7", "ç");
            replacetable.Add(@"\u00e7", "ç");
            replacetable.Add(@"\u00d6", "ö");
            replacetable.Add(@"\u00f6", "ö");
            replacetable.Add(@"\u011e", "ğ");
            replacetable.Add(@"\u011f", "ğ");
            replacetable.Add(@"\u015e", "ş");
            replacetable.Add(@"\u015f", "ş");
            replacetable.Add(@"\u00fc", "ü");
            replacetable.Add(@"\u00dc", "ü");
            replacetable.Add(@"\n", " ");
            foreach (DictionaryEntry item in replacetable)
            {
                text = text.Replace(item.Key.ToString(), item.Value.ToString());
            }
            return text.ToLower();
        }
    }
}
