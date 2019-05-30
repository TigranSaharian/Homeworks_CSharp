using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acronym
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("please type Long name: ");

            string Long_name = Console.ReadLine();

            string[] words = Long_name.Split(' ');
            string letter = string.Empty;
            for (int i = 0; i < words.Length; ++i)
            {
                letter += words[i][0];
            }
            Console.Write($"The acronym of the \"{Long_name}\" is: " + letter.ToUpper());
            Console.ReadLine();
        }
    }
}
