using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Middleware;

namespace TestCorentin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Decryptor().applyXOR("JVFC", "8f7/.2c?8f3/#f0:¿%*+:"));

            Console.WriteLine("Appuyer sur entrer pour quitter...");
            Console.ReadLine();
        }
    }
}
