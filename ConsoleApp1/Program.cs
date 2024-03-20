using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream FileText = new FileStream("data.txt", FileMode.OpenOrCreate);
            string lines = "Имя фамилия";
                using (StreamWriter Writer = new StreamWriter(FileText))
                {
                    for (int i = 0; i < 300000; i++)
                    {
                        {
                            Writer.WriteLine(lines + $" №{i + 1}");
                        }
                    }
                }
            string[] data = File.ReadAllLines("data.txt");
            /*foreach (string line in data)
            {
                Console.WriteLine(line);
            }*/
        
        }
    }
}
