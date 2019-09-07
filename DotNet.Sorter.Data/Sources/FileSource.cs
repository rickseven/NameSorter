using System;
using System.IO;
using System.Linq;

namespace DotNet.Sorter.Data.Sources
{
    public class FileSource : IFileSource
    {
        public string[] Read(string path)
        {
            if(path.Equals(""))
                throw new FileNotFoundException("File Not Found");

            try
            {
                string[] stringArr;
                stringArr = File.ReadAllLines(path);
                stringArr = stringArr.Where(x => !x.Equals("")).ToArray();
                return stringArr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Read Data Failed");
            }
            
        }

        public bool Write(string path, string[] stringArr)
        {
            try {
                StreamWriter streamWriter = new StreamWriter(path);
                foreach (var val in stringArr)
                {
                    if(!val.Equals(""))
                        streamWriter.WriteLine(val);
                }
                streamWriter.Close();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
