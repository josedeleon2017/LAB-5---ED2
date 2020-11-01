using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___Encryption_Algorithms
{
    public class ZigZag : Interfaces.IEncryptionAlgorithm
    {
        List<List<byte>> Matrix = new List<List<byte>>();
        public byte[] DecryptData(byte[] content, byte[] key)
        {
            int lenght = Convert.ToInt32(key[0]);
            Matrix = new List<List<byte>>();
            SetMatrix(lenght);

            int pos = 0;
            while (pos < content.Length)
            {
                for (int i = 1; i < lenght; i++)
                {
                    if (pos == 0)
                    {
                        Matrix[i - 1].Add(224);
                        Matrix[i].Add(224);
                        pos += 2;
                    }
                    else
                    {
                        if (pos > content.Length - 1) break;
                        Matrix[i].Add(224);
                        pos++;
                    }
                }
                for (int i = lenght - 2; i >= 0; i--)
                {
                    if (pos > content.Length - 1) break;
                    Matrix[i].Add(224);
                    pos++;
                }
            }

            int acumulator = 0;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Matrix[i][j] = content[acumulator + j];
                }
                acumulator += Matrix[i].Count;
            }

            List<byte> result = new List<byte>();
            try
            {

                List<byte> FirstLine = new List<byte>();
                FirstLine.Add(Matrix[0][0]);
                for (int i = 1; i < Matrix[0].Count; i++)
                {
                    FirstLine.Add(Matrix[0][i]);
                    FirstLine.Add(244);
                }
                Matrix[0] = FirstLine;

                List<byte> LastLine = new List<byte>();
                LastLine.Add(Matrix[lenght - 1][0]);
                for (int i = 1; i < Matrix[lenght - 1].Count; i++)
                {
                    LastLine.Add(244);
                    LastLine.Add(Matrix[lenght - 1][i]);
                }
                Matrix[lenght-1] = LastLine;


                for (int i = 0; i < lenght; i++)
                {
                    result.Add(Matrix[i][0]);
                }

                int max_lenght = Getmax();
                for (int i = 1; i < max_lenght; i++)
                {
                    if (i % 2 != 0)
                    {
                        for (int j = lenght - 2; j >= 0; j--)
                        {
                            result.Add(Matrix[j][i]);
                        }
                    }
                    if (i % 2 == 0)
                    {
                        for (int j = 1; j < lenght; j++)
                        {
                            result.Add(Matrix[j][i]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return result.ToArray();
            }
            return result.ToArray();
        }

        public int Getmax()
        {
            int max = Matrix[0].Count;
            for (int i = 0; i < Matrix.Count; i++)
            {
                if (Matrix[i].Count > max) max = Matrix[i].Count;
            }
            return max;
        }


        public byte[] EncryptData(byte[] content, byte[] key)
        {
            int lenght = Convert.ToInt32(key[0]);
            SetMatrix(lenght);

            int pos = 0;
            while (pos < content.Length)
            {
                for (int i = 1; i < lenght; i++)
                {
                    if (pos == 0)
                    {
                        Matrix[i-1].Add(content[pos]);
                        Matrix[i].Add(content[pos+1]);
                        pos+=2;
                    }
                    else
                    {
                        if (pos > content.Length-1) break;
                        Matrix[i].Add(content[pos]);
                        pos++;
                    }
                }
                for (int i = lenght-2; i >= 0; i--)
                {
                    if (pos > content.Length-1) break;
                    Matrix[i].Add(content[pos]);
                    pos++;
                }
            }

            List<byte> result = new List<byte>();
            for (int i = 0; i < Matrix.Count; i++)
            {
                List<byte> current_list = Matrix[i];
                for (int j = 0; j < current_list.Count; j++)
                {
                    result.Add(current_list[j]);
                }
            }
            return result.ToArray();
        }

        void SetMatrix(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Matrix.Add(new List<byte>());
            }
        }
    }
}
