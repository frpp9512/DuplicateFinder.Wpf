using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartB1t.Toolbox.DuplicateFinder;

namespace DuplicateFinderConsoleOutput
{
    class Program
    {
        static DuplicateFinder finder;

        static void Main(string[] args)
        {
            finder = new DuplicateFinder("D:\\");
            (finder.ProgressReporter as Progress<DuplicationSearchProgressStatus>).ProgressChanged += Program_ProgressChanged;
            StartSearch();
        }

        public static void StartSearch()
        {
            finder.FindDuplicates();
        }

        private static void Program_ProgressChanged(object sender, DuplicationSearchProgressStatus e)
        {
            Console.WriteLine($"{e.CurrentOperation} {e.CurrentDirectory} {e.Percentage}% {e.Details}");
            if (e.CurrentOperation == DuplicateSearchOperation.Finished)
            {
                Console.WriteLine($"Duplicates find: {finder.DuplicatedFiles}");
                Console.ReadKey();
            }
        }
    }
}
