using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Animals
{
    public class FileInput
    {
        private StreamReader In = null;
        private string FileName;

        public FileInput(string fileName)
        {
            FileName = fileName;
            try
            {
                In = new StreamReader(fileName);
            } catch (FileNotFoundException e)
            {
                Console.WriteLine($"File Open Error: {FileName} {e}");
            }
        }

        public void FileRead()
        {
            string line;
            try
            {
                while (!In.EndOfStream)
                {
                    line = In.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File Read Error: {FileName} {e}");
            }
        }

        public string FileReadLine()
        {
            try
            {
                string line = In.ReadLine();
                return line;
            } catch (Exception e)
            {
                Console.WriteLine($"File Read Error: {FileName} {e}");
                return null;
            }
        }

        public void FileClose()
        {
            if (In != null)
            {
                try
                {
                    In.Close();
                } catch (IOException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
