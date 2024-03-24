using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public partial class Program
    {
        static void Main()
        {
            FileStream FileText = new FileStream("data.txt", FileMode.OpenOrCreate);
            string lines = "Имя фамилия";
                using (StreamWriter Writer = new StreamWriter(FileText))
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        {
                            Writer.WriteLine(lines + $" №{i + 1}");
                        }
                    }
                }
            /*foreach (string line in data)
            {
                Console.WriteLine(line);
            }*/
        
        }
    }
}
