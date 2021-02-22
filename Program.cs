using System;

namespace dummyfile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] help = { 
                "" 
                , "dummyfile v1.0.0.0  Copyright 2021 motoi.tsushima."
                , ""
                , " options."
                , "     /s:filesize     ファイルサイズ(byte size)を指定する。(単位として、k,m,g,tを指定可能)"
                , "     /d              ダミーデータを書き込む。(0x01から0xFFまでの数値を、繰り返し書き込む)"
                , ""
            };

            foreach(var row in help)
            {
                Console.WriteLine(row);
            }

            Options options = new Options(args);

            CreateDummyFile createDummyFile = new CreateDummyFile(options.FileName, options.FileSize);

            createDummyFile.EnableDummyData = options.EnableDummyData;

            createDummyFile.Create();

            Console.WriteLine("CreateDummyFile {0}, {1}byte !", options.FileName, options.FileSize);
        }
    }
}
