using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace dummyfile
{
    public class CreateDummyFile
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public bool EnableDummyData { get; set; } = false;

        public CreateDummyFile(string fileName, long fileSize)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
        }

        public bool Create()
        {
            bool result = true;

            try
            {
                using (var fs = new FileStream(this.FileName, FileMode.Create))
                {
                    if (this.EnableDummyData)
                    {
                        for(long l = 0; l < this.FileSize; l++)
                        {
                            fs.WriteByte((byte)(l % 0xFF + 1));
                        }
                    }
                    else
                    {
                        fs.Seek(this.FileSize - 1, SeekOrigin.End);
                        fs.WriteByte((byte)0xFF);
                    }
                }
            }
            catch(Exception ex)
            {
                result = false;
                throw ex;
            }

            return result;
        }
    }
}
