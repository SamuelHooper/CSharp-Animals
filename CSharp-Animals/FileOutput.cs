using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Animals
{
    public class FileOutput
    {
        private StreamWriter Out = null;
        private string FileName;

        public FileOutput(string fileName)
        {
            FileName = fileName;
            try
            {
                Out = new StreamWriter(fileName);
            } catch (FileNotFoundException e)
            {
                Console.WriteLine($"File Open Error: {FileName} {e}");
            }
        }

        public void FileWrite(string line)
        {
            try
            {
                Out.WriteLine(line);
            } catch (Exception e)
            {
                Console.WriteLine($"File Write Error: {FileName} {e}");
            }
        }

        public void FileClose()
        {
            if (Out != null)
            {
                try
                {
                    Out.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
