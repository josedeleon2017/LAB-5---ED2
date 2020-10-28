using System;
using LAB_5___Encryption_Algorithms;

namespace LAB_5___ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t\t- LAB 5 -\n\nKevin Romero 1047519\nJosé De León 1072619");
            string texto = "COMO ESTAS AMIGO";


            Cesar cesar = new Cesar();
            Console.WriteLine("\n\nCESAR\nTEXTO ORIGINAL\n" + texto);
            string llave_cesar = "MARYJ";
            Console.WriteLine("\nTEXTO CIFRADO");
            byte[] result_encrypt = cesar.EncryptData(ConvertToByte(texto), ConvertToByte(llave_cesar));
            Console.WriteLine(ConvertToChar(result_encrypt));

            Console.WriteLine("\nTEXTO DESCIFRADO");
            byte[] result_decrypt = cesar.DecryptData(result_encrypt, ConvertToByte(llave_cesar));
            Console.WriteLine(ConvertToChar(result_decrypt));


            ZigZag zig_zag = new ZigZag();
            Console.WriteLine("\n\nZIG ZAG\nTEXTO ORIGINAL\n" + texto);
            byte[] llave_zig_zag = new byte[] { 5 };
            Console.WriteLine("\nTEXTO CIFRADO");
            byte[] result_encrypt2 = zig_zag.EncryptData(ConvertToByte(texto), llave_zig_zag);
            Console.WriteLine(ConvertToChar(result_encrypt2));

            //Console.WriteLine("\nTEXTO DESCIFRADO");
            //byte[] result_decrypt2 = zig_zag.DecryptData(result_encrypt2, ConvertToByte(llave_zig_zag));
            //Console.WriteLine(ConvertToChar(result_decrypt2));

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
