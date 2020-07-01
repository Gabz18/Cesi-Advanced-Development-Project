using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using 
using Middleware;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;

namespace TestCorentin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sender mySender = Sender.Instance;
            //mySender.sendMessageToJava();
            string doc = ToLiteral("");


            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit....");

            Console.ReadLine();
        }

        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
}
