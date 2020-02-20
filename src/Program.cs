using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GoogleHashCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadWriteFiles rw = new ReadWriteFiles();
            FileInfo[] inputFiles = rw.getInputFiles();
            List<Library> libs = new List<Library>();
            List<Library> partial = new List<Library>();
            List<int> sums = new List<int>();
            List<KeyValuePair<int, List<int>>> solution = new List<KeyValuePair<int, List<int>>>();
            List<int> indexes = new List<int>();

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
                string raw = rw.readInfoFromFile(inputFiles[int.Parse(ch) - 1]);
                string[] data = raw.Trim().Split("\n");

                string[] generalInfo = data[0].Split(" ");
                string[] scores = data[1].Split(" ");

                Console.Write(data.Length);

                int libID = 0;

                for (int j = 2; j < data.Length; j += 2)
                {
                    string[] info = new string[2];
                    info[0] = data[j];
                    info[1] = data[j + 1];
                    libs.Add(createLibrary(info, scores, int.Parse(generalInfo[2]), 3, libID));
                    libID++;
                }

                List<KeyValuePair<int, List<int>>> solutions = combinations(libs, new List<Library>(), new List<int>(), new List<KeyValuePair<int, List<int>>>(), new List<int>());

                foreach (KeyValuePair<int, List<int>> k in solutions)
                {
                    Console.WriteLine(k.Key);
                    foreach (var item in k.Value)
                    {
                        Console.WriteLine(libs.ElementAt(item));
                        Thread.Sleep(5000);
                        foreach (var b in libs.ElementAt(item).books)
                        {
                            Console.WriteLine(b);
                        }
                    }
                }

                foreach (var lib in libs)
                {
                    Console.Write(lib.ToString());
                }
            }
            catch (FormatException)
            {
                Console.Write("Invalid Option!");
            }

        }
        static Library createLibrary(string[] info, string[] scores, int totDaysForScanning, int signUpStartDay, int libID)
        {
            string[] generalInfo = info[0].Split(" ");
            int totBooks = int.Parse(generalInfo[0]);
            double signUp = Double.Parse(generalInfo[1]);
            double booksPerDay = Double.Parse(generalInfo[2]);
            int totDaysToProcess = (int)Math.Ceiling(totBooks / booksPerDay);

            Tuple<List<int>, int> res = calcPriority(scores, info[1].Split(" "), signUpStartDay, totDaysForScanning, (int)signUp, (int)booksPerDay);


            Library lib = new Library((int)signUp, totDaysToProcess, res.Item2, libID, res.Item1);

            return lib;

        }

        static Tuple<List<int>, int> calcPriority(string[] scores, string[] books, int signUpStartDay, int totDaysForScanning, int signUpTime, int booksPerDay)
        {

            Dictionary<int, int> libBooks = new Dictionary<int, int>();

            foreach (string book in books)
            {
                libBooks.Add(int.Parse(book), int.Parse(scores[int.Parse(book)]));
            }

            int dayCanStartShipping = signUpStartDay + signUpTime;
            int availableDaysToShip = (totDaysForScanning - dayCanStartShipping) + 1;
            int totalBooksCanShip = availableDaysToShip * booksPerDay;

            var sortedByScore = (from entry in libBooks orderby entry.Value descending select entry).ToList();

            var finalList = (sortedByScore.Take(totalBooksCanShip)).ToList();

            int priority = 0;

            List<int> booksSent = new List<int>();

            foreach (var book in finalList)
            {
                priority += book.Value;
                booksSent.Add(book.Key);
            }

            Tuple<List<int>, int> returnedStuff = new Tuple<List<int>, int>(booksSent, priority);

            return returnedStuff;

        }

        static List<KeyValuePair<int, List<int>>> combinations(List<Library> libs, List<Library> partial, List<int> sums, List<KeyValuePair<int, List<int>>> solution, List<int> indexes)
        {
            if (!sums.Any())
            {
                sums.Add(0);
            }

            int s = partial.Sum(l => l.priority);

            Console.WriteLine(s);

            if (sums.IndexOf(s) == -1 && sums.Max() < s)
            {
                sums.Add(s);
                solution.Add(new KeyValuePair<int, List<int>>(partial.Count, indexes));
            }

            if (s + libs.Sum(l => l.priority) < sums.Max())
            {
                return new List<KeyValuePair<int, List<int>>>();
            }

            for (int i = libs.Count - 1; i > -1; i--)
            {
                Library l = libs[i];
                List<Library> remaining = libs.Take(i).ToList();
                List<Library> partial2 = new List<Library>(partial);
                partial2.Add(l);
                List<int> indexes2 = new List<int>(indexes);
                indexes2.Add(i);
                combinations(remaining, partial2, sums, solution, indexes2);
            }

            return solution;
        }
    }
}
