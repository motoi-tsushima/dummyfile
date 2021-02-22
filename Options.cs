using System;
using System.Collections.Generic;
using System.Text;

namespace dummyfile
{
    public class Options : Colipex
    {
        public long FileSize { get; set; }

        public string FileName { get; set; }

        public bool EnableDummyData { get; set; }

        public Options(string[] args) : base(args)
        {
            // ファイルサイズを指定する。
            if (this.IsOption("s"))
            {
                string sizeWord = this.Options["s"].ToLower().Trim();
                long sizeOfFile;
                if (long.TryParse(sizeWord, out sizeOfFile) == false)
                {
                    long multiple = 1;

                    if (sizeWord.IndexOf('k') > 0) //先頭ではダメ。
                    {
                        sizeWord = sizeWord.Substring(0, sizeWord.IndexOf('k'));
                        multiple = 1024L;
                    }
                    else if (sizeWord.IndexOf('m') > 0)
                    {
                        sizeWord = sizeWord.Substring(0, sizeWord.IndexOf('m'));
                        multiple = (long)Math.Pow(1024, 2);
                    }
                    else if (sizeWord.IndexOf('g') > 0)
                    {
                        sizeWord = sizeWord.Substring(0, sizeWord.IndexOf('g'));
                        multiple = (long)Math.Pow(1024, 3);
                    }
                    else if (sizeWord.IndexOf('t') > 0)
                    {
                        sizeWord = sizeWord.Substring(0, sizeWord.IndexOf('t'));
                        multiple = (long)Math.Pow(1024, 4);
                    }

                    long.TryParse(sizeWord, out sizeOfFile);
                    sizeOfFile *= multiple;

                    this.FileSize = sizeOfFile;
                }
            }
            else
            {
                this.FileSize = 1024L;
            }

            //ダミーデータを出力する。
            if (this.IsOption("d"))
            {
                this.EnableDummyData = true;
            }
            else
            {
                this.EnableDummyData = false;
            }


                // ファイル名を指定する。
                if (this.Parameters.Count > 0)
            {
                this.FileName = this.Parameters[0];
            }
            else
            {
                this.FileName = "out.bin";
            }
        }
    }
}
