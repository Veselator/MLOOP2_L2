using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLOOP2_L2
{
    public class WordsCounter
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            char[] punctuation = { '.', ',', '!', '?', ';', ':', '"', '\'', '(', ')', '[', ']', '-' };

            return text.ToLower()
                       .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(word => word.Trim(punctuation))
                       .Where(word => !string.IsNullOrEmpty(word))
                       .GroupBy(word => word)
                       .ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
