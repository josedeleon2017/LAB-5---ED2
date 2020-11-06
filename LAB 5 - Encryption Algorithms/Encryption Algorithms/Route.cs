using LAB_5___Encryption_Algorithms.Encryption_Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace LAB_5___Encryption_Algorithms
{
    public class Route : Interfaces.IEncryptionAlgorithm
    {
        private int keyN { get; set; }
        private int keyM { get; set; }

        public int inicio { get; set; }
        public int outFor { get; set; }

        public byte dontExist { get; set; }

        public int countContent { get; set; }


        private byte[,] route;
        List<byte> outEncypred;
        List<byte> outDecrypted;

        public byte[] DecryptData(byte[] content, Key key)
        {
            List<byte> auxContent = content.ToList();
            outDecrypted = new List<byte>();

            keyN = key.Rows; //filas
            keyM = key.Columns; //columnas
            inicio = 0;
            countContent = 0;
            route = new byte[keyN, keyM];
            dontExist = content[0];
            auxContent.RemoveAt(0);
            while (countContent < auxContent.Count)
            {
                GetRoute(auxContent);
                for (int i = 0; outFor < route.Length; i++)
                {
                    GetRight(content);
                    GetDown(content);
                    GetLeft(content);
                    GetUp(content);
                    inicio++;
                    keyM--;
                    keyN--;
                }
                outFor = 0;
                inicio = 0;
                keyN = key.Rows;
                keyM = key.Columns;
            }
            return outDecrypted.ToArray();
        }
        void GetRoute(List<byte> content)
        {

            for (int i = 0; i < route.GetLength(0); i++)
            {
                for (int j = 0; j < route.GetLength(1); j++)
                {
                    route[i, j] = content[countContent];
                    countContent++;
                }
            }
        }
        void GetRight(byte[] content)
        {
            for (int i = inicio; i < keyM; i++)
            {
                if (route[inicio, i] != dontExist)
                    outDecrypted.Add(route[inicio, i]);
                outFor++;
            }
        }
        void GetDown(byte[] content)
        {
            for (int i = inicio + 1; i < keyN; i++)
            {
                if (route[i, keyM - 1] != dontExist) 
                    outDecrypted.Add(route[i, keyM - 1]);
                outFor++;
            }
        }
        void GetLeft(byte[] content)
        {
            for (int i = keyM - 2; i >= inicio; i--)
            {
                if (route[keyN - 1, i] != dontExist)
                    outDecrypted.Add(route[keyN - 1, i]);
                outFor++;
            }
        }
        void GetUp(byte[] content)
        {
            for (int i = keyN - 2; i >= inicio + 1; i--)
            {
                if (route[i, inicio] != dontExist)
                    outDecrypted.Add(route[i, inicio]);
                outFor++;
            }
        }

        public byte[] EncryptData(byte[] content, Key key)
        {
                List<byte> outContent = new List<byte>();
                keyN = key.Rows; //filas
                keyM = key.Columns; //columnas

                inicio = 0;


                countContent = 0;

                route = new byte[keyN, keyM];
                serchDontExist(content);
                while (countContent < content.Length)
                {
                    for (int i = 0; outFor < route.Length; i++)
                    {
                        SetRight(content);
                        SetDown(content);
                        SetLeft(content);
                        SetUp(content);
                        inicio++;
                        keyM--;
                        keyN--;
                    }
                    outFor = 0;
                    inicio = 0;
                    keyN = key.Rows;
                    keyM = key.Columns; 
                    outContent.AddRange(readRoute());
                }
                outContent.Insert(0 , dontExist);
                return outContent.ToArray();
        }
        public void serchDontExist(byte[] content)
        {
            for (byte i = 1; i <= 255; i++)
            {
                if (!ContentByte(content, i))
                {
                    dontExist = i;
                    return;
                }
            }
        }
        public bool ContentByte(byte[] content, byte newByte)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == newByte) return true;
            }
            return false;
        }
        List<byte> readRoute()
        {
            outEncypred = new List<byte>(route.Length);
            for (int i = 0; i < route.GetLength(0); i++)
            {
                for (int j = 0; j < route.GetLength(1); j++)
                {
                    outEncypred.Add(route[i, j]);
                    route[i, j] = 0;
                }
            }
            return outEncypred;
        }
        void SetRight(byte[] content)
        {
            for (int i = inicio; i < keyM; i++)
            {
                if (countContent < content.Count())
                    route[inicio, i] = content[countContent];
                else
                    route[inicio, i] = dontExist;
                countContent++;
                outFor++;
            }
        }
        void SetDown(byte[] content)
        {
            for (int i = inicio + 1; i < keyN; i++)
            {
                if (countContent < content.Count())
                    route[i, keyM - 1] = content[countContent];
                else
                    route[i, keyM -1] = dontExist;

                countContent++;
                outFor++;
            }
        }
        void SetLeft(byte[] content)
        {
            for (int i = keyM - 2; i >= inicio; i--)
            {
                if (countContent < content.Count())
                    route[keyN - 1, i] = content[countContent];
                else
                    route[keyN - 1, i] = dontExist;
                countContent++;
                outFor++;
            }
        }
        void SetUp(byte[] content)
        {
            for (int i = keyN - 2; i >= inicio + 1; i--)
            {
                if (countContent < content.Count())
                    route[i, inicio] = content[countContent];
                else
                    route[i, inicio] = dontExist;
                countContent++;
                outFor++;
            }
        }

     
    }
}
