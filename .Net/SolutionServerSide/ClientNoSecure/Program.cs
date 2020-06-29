using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClientNoSecure.ServiceReference1;


namespace ClientNoSecure
{
    class Program
    {
        static void Main(string[] args)
        {

            string action;
            string docToDecrypt;

            Console.WriteLine("Enter the action you want (D -> Decryption and S -> StopDecryption");
            action = Console.ReadLine();

            IService1 proxy = new Service1Client();

            if(action == "D")
            {
                //Console.WriteLine("Enter the text to decode:");
                docToDecrypt = "8f7/.2c?8f3/#f0:¿%*+:";

                STG response = proxy.m_service(new MessageCreator().createMessageSTG("Decryption", new object[] { docToDecrypt }));

                Console.WriteLine("Pour le text crypté: {0} la bonne clé est {1} et le résultat du fichier est: {2}", response.Data[0], response.Data[1], response.Data[2]);
            }

            if (action == "S")
            {
                proxy.m_service(new MessageCreator().createMessageSTG("StopDecryption", new object[] { "benjamin", "JVFC" }));
            }


            Console.WriteLine("Tap Enter to finish the process");
            Console.ReadLine();
        }

        public class MessageCreator
        {

            public STG createMessageSTG(string OperationName, object[] data)
            {
                STG message = new STG();
                message.OperationName = OperationName;
                message.Data = data;

                return message;
            }
        }
    }
}
