using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoUnzip
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("This program takes a single arguement, the path to a zip file which will be extract to the current directory.");
                return -1;
            }

            var path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine($"Can't find a file at {path}.");
                return -2;
            }

            var extractor = new ZipPackageExtractor();
            var filesExtracted = extractor.Extract(path, Environment.CurrentDirectory);

            Console.WriteLine($"Extracted {filesExtracted} files.");

            return 0;
        }
    }
}
