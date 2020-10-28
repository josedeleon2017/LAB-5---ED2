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
            throw new NotImplementedException();
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
