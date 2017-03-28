using System.IO;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace OctoUnzip
{
    public class ZipPackageExtractor
    {
        public int Extract(string packageFile, string directory)
        {
            var filesExtracted = 0;
            using (var inStream = new FileStream(packageFile, FileMode.Open, FileAccess.Read))
            using (var archive = ZipArchive.Open(inStream))
            {
                foreach (var entry in archive.Entries)
                {
                    ProcessEvent(ref filesExtracted, entry);
                    entry.WriteToDirectory(directory, new ExtractionOptions { ExtractFullPath = true, Overwrite = true, PreserveFileTime = true });
                }
            }
            return filesExtracted;
        }

        private void ProcessEvent(ref int filesExtracted, IEntry entry)
        {
            if (entry.IsDirectory) return;

            filesExtracted++;
        }
    }
}