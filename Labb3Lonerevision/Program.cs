using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInt();
        }
        static int ReadInt()
        {
            while (true)
            {
                try
                {
                    int Salaries = int.Parse(Console.ReadLine());
                    int[] SalariesArray;
                    SalariesArray = new int[Salaries];
                }
                catch
                {
                    Console.WriteLine("Ogiltig summa. Var god försök igen");
                }
            }
        }
        static void ProcessSalaries(int count)
        { 
        
        }

    }
}
