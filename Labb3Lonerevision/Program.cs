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
                int amountOfSalaries = ReadInt("Ange antal löner att mata in: "); //startar metoden ReadInt och skickar med en prompt
                Console.WriteLine();
                if (amountOfSalaries < 2)   //om antal löner är mindre än 2 så får man ett felmeddelande och man får försöka igen...
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Antal löner måste vara 2 eller mer!");
                    Console.ResetColor();
                }
                else
                {
                    ProcessSalaries(amountOfSalaries); //...annars startar den metoden ProcessSalaries
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck valfri tangent för ny uträkning - ESC avslutar ");
                Console.ResetColor();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape); //...när man loopat "do-while"-loopen får man skriva in en key och så länge den inte är ESC så fortsätter loopen
        }
        static int ReadInt(string prompt) //readint läser in allt.
        {

            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine(); //skriver in userInput innan try catch och innan omvandling till int för att kunna använda den i både try och catch
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
        static void ProcessSalaries(int count) //ProcessSalaries behandlar alla siffror och uträkningar. Tar emot värdet från "amountOfSalaries" som den lägger in i integern "count"
        {
            int[] salaries = new int[count];        //är min osorterade array
            int[] sortedSalaries = new int[count];  // kommer vara min sorterade array

            for (int i = 0; i < count; i++)         //Loopar lika långt som arrayen är och man får skriva in varje "låda" en efter en. 
            {                                       //Count är hur lång arrayen är och det man fick ge ett värde första gången.
                        salaries[i] = ReadInt(String.Format("Ange lön nummer {0}: ", (i+1))); 
            }
            sortedSalaries = (int[])salaries.Clone();
            Array.Sort(sortedSalaries);
            int median;
            if (count % 2 == 0)                 //om antal löner är jämnt måste den ta de två mittersta talet och dividera det med varandra för att få medianen.
            {                           
                int number1 = count / 2;        //Tar det största mittersta "lådnummret" Ex) Längden på arrayen är 6. Då behöver man 2 och 3 (eftersom array börjar på 0, 1, 2...)
                int number2 = number1 - 1;      //tar det mindre mittersta "lådnummret"    ) 6/2=3, 3-1=2    
                median = (sortedSalaries[number1] + sortedSalaries[number2])/2; // tar värderna från respektive "låda" och lägger ihop dem sedan delar det på två. variabeln "median" får värdet
            }
            else
            {
                median = sortedSalaries[count / 2];     //ojämn tal behöver bara delas på 2. ex) 5/2 = 2,5 = 2 eftersom det är en integer.
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Medianlön:      {0,10:C0}", median);
            Console.WriteLine("Medellön:       {0,10:C0}", sortedSalaries.Average());  //räknar ut medellönen 
            Console.WriteLine("Lönespridning:  {0,10:C0}",sortedSalaries.Max() - sortedSalaries.Min()); //max-min = lönesspridning
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < count; i++)     //skriver ut lönerna i den ordning man skrev in dem i
            {
                if (i % 3 == 0)                 //var tredje rad gör den en radbrytning
                {
                    Console.WriteLine();
                }
                Console.Write("{0,10}", salaries[i]);
            }
        }
    }
}
