using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MLOOP2_L2
{
    internal class FileManager
    {
        private List<FileInfo> Files = new List<FileInfo>();
        public int FileCount => Files.Count;
        private const string defaultFileName = "firstFile.stf";

        public FileManager(string fileName = defaultFileName)
        {
            LoadFilesInfo(fileName);
        }

        public FileInfo GetFile(int id)
        {
            return Files[id];
        }

        private void LoadFilesInfo(string fileName)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(fileName);
                
            } 
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return;
            }

            foreach (string line in fileContent)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(line);
                    Files.Add(fileInfo);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return;
                }
            }
        }

        public override string ToString()
        {
            if (Files.Count == 0) return "Файлів немає";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Files.Count; i++)
            {
                sb.AppendLine($" [{i + 1}] {Files[i].Name}");
            }
            return sb.ToString();
        }
    }
}
