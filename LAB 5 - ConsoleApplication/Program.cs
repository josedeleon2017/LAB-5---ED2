using System;
using LAB_5___Encryption_Algorithms;
using LAB_5___Encryption_Algorithms.Encryption_Algorithms;

namespace LAB_5___ConsoleApplication
{
    class Program
    {
        public static Key keyCipher = new Key() { Word  = "MARYJ" , Levels = 4 , Columns = 3, Rows = 4};
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t\t- LAB 5 -\n\nKevin Romero 1047519\nJosé De León 1072619");
            string texto = "Mejor que buscar la verdad sin método es no pensar nunca en ella, porque los estudios desordenados y las meditaciones oscuras turban las luces naturales de la razón y ciegan la inteligencia. -René Descártes";
            

            Console.WriteLine("\nTEXTO ORIGINAL\n" + texto);

            Cesar cesar = new Cesar();

            Console.WriteLine("\n-------- CESAR -------------------------------------------------------------------------------------------------\nTEXTO CIFRADO");
            byte[] result_encrypt = cesar.EncryptData(ConvertToByte(texto), keyCipher);
            Console.WriteLine(ConvertToChar(result_encrypt));

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt = cesar.DecryptData(result_encrypt, keyCipher);
            Console.WriteLine(ConvertToChar(result_decrypt));


            ZigZag zig_zag = new ZigZag();


            Console.WriteLine("\n-------- ZIG ZAG -----------------------------------------------------------------------------------------------\nTEXTO CIFRADO");
            byte[] result_encrypt2 = zig_zag.EncryptData(ConvertToByte(texto), keyCipher);
            Console.WriteLine(ConvertToChar(result_encrypt2));

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt2 = zig_zag.DecryptData(result_encrypt2, keyCipher);
            Console.WriteLine(ConvertToChar(result_decrypt2));

            Route ruta = new Route();


            Console.WriteLine("\n-------- Ruta -----------------------------------------------------------------------------------------------\nTEXTO CIFRADO");
            byte[] result_encrypt3 = ruta.EncryptData(ConvertToByte(texto), keyCipher);
            Console.WriteLine(ConvertToChar(result_encrypt3));

            ruta = new Route();

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt3 = ruta.DecryptData(result_encrypt3, keyCipher);
            Console.WriteLine(ConvertToChar(result_decrypt3));

            Console.ReadKey();
        }

        public static byte[] ConvertToByte(string content)
        {
            byte[] array = new byte[content.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(content[i]);
            }
            return array;
        }

        public static char[] ConvertToChar(byte[] content)
        {
            char[] array = new char[content.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToChar(content[i]);
            }
            return array;
        }
    }
}
