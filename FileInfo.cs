using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MLOOP2_L2
{
    public class FileInfo
    {
        public string Name { get; private set; }
        private Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        private string content = string.Empty;
        private int totalCountOfWords;

        public FileInfo() 
        {
            Name = string.Empty;
        }

        public FileInfo(string fileName)
        {
            Name = fileName;
            LoadFile(fileName);
        }

        private void LoadFile(string fileName)
        {
            try
            {
                content = File.ReadAllText(fileName);
                wordsCount = WordsCounter.CountWords(content);
                totalCountOfWords = wordsCount.Values.Sum(x => x);
            }
            catch
            {
                return;
            }
        }

        public override string ToString()
        {
            if (wordsCount.Count == 0) return " Вмісту немає!";
            StringBuilder sb = new StringBuilder();
            int maxKeyLength = wordsCount.Keys.Max(k => k.Length);

            sb.AppendLine($"\n Файл {Name}");
            sb.AppendLine($" Всього слів: {totalCountOfWords}\n");

            sb.AppendLine(" Всього слів".PadRight(maxKeyLength) + "  Кількість");
            sb.AppendLine(" " + new string('=', maxKeyLength + 10));

            foreach (string key in wordsCount.Keys)
            {
                sb.AppendLine($" {key.PadRight(maxKeyLength)}: {wordsCount[key]}");
            }
            return sb.ToString();
        }
    }
}
