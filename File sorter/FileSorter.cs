using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_sorter
{
    internal class FileSorter
    {
        public static string GetFileName(string filepath) {
            return filepath.Substring(filepath.LastIndexOf(@"\") + 1);



        }
        public static (string[], bool) FindAllFilesInDirectory(string nameToCheck, string directory) {
           
            try {
                string[] FoundFiles = Directory.GetFiles(directory, "*" + nameToCheck + "*", SearchOption.AllDirectories);


                return (FoundFiles, false);
            }
            catch {
                Console.WriteLine("Access to path denied. Try running as administrator or being more specific in your path.");
                return (new string[0], true);
            }





        }

    }
}
