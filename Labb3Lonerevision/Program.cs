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
            do
            {
                Console.Clear();
                int amountOfSalaries = ReadInt("Ange antal löner att mata in: ");
                Console.WriteLine();
                if (amountOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antal löner måste vara 2 eller mer!");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Tryck valfri tangent för ny uträkning - ESC avslutar ");
                    Console.ResetColor();
                }
                else
                {
                    ProcessSalaries(amountOfSalaries);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static int ReadInt(string prompt)
        {

            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                try
                {
                    int value = int.Parse(userInput);
                    return value;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig summa. '{0}' kan inte tolkas som ett heltal! Var god försök igen", userInput);
                    Console.ResetColor();
                }
            }
        }
        static void ProcessSalaries(int count)
        {
            int[] salaries = new int[count];
            int[] sortedSalaries = new int[count];

            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    try
                    {
                        salaries[i] = ReadInt("Ange lön nummer " + (i+1) + ": ");
                        break;
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig summa. Var god försök igen");
                        Console.ResetColor();
                    }
                }
            }
            sortedSalaries = (int[])salaries.Clone();
            Array.Sort(sortedSalaries);
            int median;
            if (count % 2 == 0)
            {
                int number1 = sortedSalaries.Length / 2;
                int number2 = number1 - 1;
                median = (sortedSalaries[number1] + sortedSalaries[number2])/2;
            }
            else
            {
                median = sortedSalaries[sortedSalaries.Length / 2];
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Medianlön:      {0,10:C0}", median);
            Console.WriteLine("Medellön:       {0,10:C0}", sortedSalaries.Average());
            Console.WriteLine("Lönespridning:  {0,10:C0}",sortedSalaries.Max() - sortedSalaries.Min());
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < count; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write("{0,10}", salaries[i]);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nTryck valfri tangent för ny uträkning - ESC avslutar ");
            Console.ResetColor();
        }

    }
}
