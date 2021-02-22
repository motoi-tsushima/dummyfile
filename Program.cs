using System;

namespace dummyfile
{
    class Program
    {
        static void Main(string[] args)
        {
            Options options = new Options(args);

            CreateDummyFile createDummyFile = new CreateDummyFile(options.FileName, options.FileSize);

            createDummyFile.EnableDummyData = options.EnableDummyData;

            createDummyFile.Create();

            Console.WriteLine("CreateDummyFile {0}, {1} !", options.FileName, options.FileSize);
        }
    }
}
