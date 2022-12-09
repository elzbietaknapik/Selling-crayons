using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefFunctionExample
{
    class Program
    {
         static void Main(string[] args)
        {
            string path = "report.txt";
            int number =38;
            
            int nrNow = number;
            string date = " ";
            File.Delete(path);
            
        start:
            if (nrNow < 15) goto ending;
            else
            {
                Console.WriteLine("Czy chcesz kupić kredki? [t/n]");
                char answer = Console.ReadKey().KeyChar;
                if (answer == 't')
                {
                    nrNow = Availability(ref number);
                    Console.WriteLine("Stan magazynowy wynosi teraz: " + nrNow);
                    date = nrNow.ToString();
                    ExampleAsync(date, path);
                    goto start;
                }
                else
                {

                    Console.WriteLine("Kończymy na dziś?");
                    char end = Console.ReadKey().KeyChar;
                    if (end == 't')
                    {
                        goto ending;
                    }
                    else if (end == 'n')
                    {
                        goto start;
                    }
                    else
                    {
                        Console.WriteLine("Niestety, Twoja odpowiedź nie była prawidłowa. Zacznijmy od nowa!");
                        goto start;
                    }

                }
            }
            ending:
                Console.WriteLine("Dzięki za zakupy, to wszystko na dziś!");
                Console.ReadKey();
            }

        static int Availability ( ref int amount)
        {
            if (amount - 15 >= 0)
            {
                amount -= 15;
                return amount;
            }
            else
                Console.WriteLine("Przykro mi, nie ma wystarczającej ilości towaru na stanie");
            return amount;
        }

        public static void ExampleAsync(string texta,string path)
        {

             File.WriteAllText(path, texta + "\n");
        }
    }
}
