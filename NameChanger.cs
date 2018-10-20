// Simple program to copy drone videos & photos to backup directory.

using System;
using System.IO;


namespace NameChanger
{
    class Program
    {
        public static void copyfiles(string source, string target)
        {
            string[] dircontents = System.IO.Directory.GetFiles(source);
            foreach (string item in dircontents)
            {
                // Get a random number to append to file name
                Random nRand = new Random();
                int fileRand = nRand.Next();
                // Get the file name and move to target dir
                FileInfo f = new FileInfo(item);
                if ((target[target.Length - 1]).ToString() != "\\")
                {
                   
                    f.CopyTo(target + "\\" + System.DateTime.Now.DayOfWeek.ToString() + fileRand.ToString() + f.Name);
                }
                else
                {
                    f.CopyTo(target + System.DateTime.Now.DayOfWeek.ToString() + fileRand.ToString() + f.Name);
                }
                Console.WriteLine("Copied " + item + " to " + target);
            }

        }
        static void Main(string[] args)
        {
            
            if (args.Length < 2 || args.Length > 2)
            {
                Console.WriteLine("Program to copy all files from a source directory to a destination");
                Console.WriteLine("Usage namechanger.exe <source dir> <destination dir");
                Environment.Exit(1);
                
            }
            string sourceDir = args[0];
            string destDir = args[1];
            

            if ((System.IO.Directory.Exists(sourceDir)) != true)
            {
                Console.WriteLine("Source directory doesn't exist");
                Environment.Exit(1);
            }

            //String destDir = Console.ReadLine();
            if ((System.IO.Directory.Exists(destDir)) != true)
            {
                Console.WriteLine("Destination directory doesn't exist");
                System.Environment.Exit(1);

            }
            copyfiles(sourceDir, destDir);
            Console.WriteLine("complete!");
            Environment.Exit(1);
                      
        }
    }
}
