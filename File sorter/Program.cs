using File_sorter;
using System;
using System.Runtime.CompilerServices;

Console.WriteLine("1: Entire pc\n2: Custom directory");
int num = 0;
var isNumeric = false;

while (!isNumeric || num < 1 || num > 2) {
isNumeric = int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out num);
}

// "C:\Users\nijme\Desktop"

switch (num)
{
    case 1:
        Console.WriteLine("What directory?");
        string? directory = Console.ReadLine();
        Console.WriteLine("What file name to filter for?");
        string? filter = Console.ReadLine(); 
       

        (string[] foundFiles, bool errorOccured) = FileSorter.FindAllFilesInDirectory(filter, directory);
        if (foundFiles.Length == 0)
        {
            if (!errorOccured) { Console.WriteLine("No files found."); }

            Console.WriteLine("Exiting...");
            break;
        }

        foreach(string file in foundFiles)
        {
          
            Console.WriteLine(FileSorter.GetFileName(file));

        }
        Console.WriteLine("Move these files? \n[y] for yes, \n[n] for no.");
        bool move = Console.ReadKey().KeyChar.ToString() == "y";

        if (move) {
            Directory.CreateDirectory($"{directory}\\{filter}Files");
            foreach(string file in foundFiles)
            {
                try {

                    File.Move(file, Path.Combine(directory, $"{filter}Files", FileSorter.GetFileName(file)));
                }
                catch { }
            }
        
        }
        break;


}


