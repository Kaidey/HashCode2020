using System;
using System.IO;

namespace GoogleHashCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string chosenInputFile;
            ReadWriteFiles rw = new ReadWriteFiles();
            FileInfo[] inputFiles = rw.getInputFiles();

            int i = 1;

            foreach (FileInfo file in inputFiles)
            {

                Console.WriteLine(i + " - " + file.Name + '\n');
                i++;

            }

            Console.WriteLine("Choose an input file: \n");
            string ch = Console.ReadLine();

            try
            {
                rw.readInfoFromFile(inputFiles[int.Parse(ch) - 1]);
            }
            catch (FormatException)
            {
                Console.Write("Invalid Option!");
            }

        }
    }
}
