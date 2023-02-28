using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_2
{
    internal class welcomescreen
    {
        public string welcome()
        {
            Console.WriteLine("WYBIERZ OPCJĘ");
            Console.WriteLine("1 => LISTA KLIENTÓW I SAMOCHODÓW");
            Console.WriteLine("2 => WYPOŻYCZENIE SAMOCHODU");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");


            String answer = Console.ReadLine();
            return answer;
        }
    }
}
