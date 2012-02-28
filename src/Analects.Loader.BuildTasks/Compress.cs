using System;
using System.IO;
using System.IO.Compression;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using IOFile = System.IO.File;

namespace Analects.Loader.BuildTasks
{
    public class Compress : Task
    {
        [Required]
        public string File { get; set; }

        [Required]
        public string ZipFile { get; set; }

        public override bool Execute()
        {
            bool result;

            try
            {
                FileInfo fi = new FileInfo(File);
                if (!fi.Exists)
                {
                    base.Log.LogWarning("File Not Found: {0}", new object[]
                    {
                        fi.FullName
                    });
                }
                else
                {
                    // Get the stream of the source file.
                    using (FileStream inFile = fi.OpenRead())
                    {
                        // Create the compressed file.
                        using (FileStream outFile = IOFile.Create(ZipFile))
                        {
                            using (var Compress = new DeflateStream(outFile, CompressionMode.Compress))
                            {
                                // Copy the source file into 
                                // the compression stream.
                                inFile.CopyTo(Compress);
                            }
                        }
                    }
                }
                result = true;
            }
            catch (Exception exception)
            {
                base.Log.LogErrorFromException(exception);
                result = false;
            }

            return result;
        }
    }
}
