using System;
using LAB_5___Encryption_Algorithms;

namespace LAB_5___ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t\t- LAB 5 -\n\nKevin Romero 1047519\nJosé De León 1072619");
            string texto = "Mejor que buscar la verdad sin método es no pensar nunca en ella, porque los estudios desordenados y las meditaciones oscuras turban las luces naturales de la razón y ciegan la inteligencia. -René Descártes";


            Console.WriteLine("\nTEXTO ORIGINAL\n" + texto);

            Cesar cesar = new Cesar();
            string llave_cesar = "MARYJ";

            Console.WriteLine("\n-------- CESAR -------------------------------------------------------------------------------------------------\nTEXTO CIFRADO");
            byte[] result_encrypt = cesar.EncryptData(ConvertToByte(texto), ConvertToByte(llave_cesar));
            Console.WriteLine(ConvertToChar(result_encrypt));

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt = cesar.DecryptData(result_encrypt, ConvertToByte(llave_cesar));
            Console.WriteLine(ConvertToChar(result_decrypt));


            ZigZag zig_zag = new ZigZag();
            byte[] llave_zig_zag = new byte[] { 4 };


            Console.WriteLine("\n-------- ZIG ZAG -----------------------------------------------------------------------------------------------\nTEXTO CIFRADO");
            byte[] result_encrypt2 = zig_zag.EncryptData(ConvertToByte(texto), llave_zig_zag);
            Console.WriteLine(ConvertToChar(result_encrypt2));

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt2 = zig_zag.DecryptData(result_encrypt2, llave_zig_zag);
            Console.WriteLine(ConvertToChar(result_decrypt2));

            Route ruta = new Route();
            byte[] llave_ruta = new byte[] { 4, 3 };


            Console.WriteLine("\n-------- Ruta -----------------------------------------------------------------------------------------------\nTEXTO CIFRADO");
            byte[] result_encrypt3 = ruta.EncryptData(ConvertToByte(texto), llave_ruta);
            Console.WriteLine(ConvertToChar(result_encrypt3));

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt3 = ruta.DecryptData(result_encrypt3, llave_ruta);
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
