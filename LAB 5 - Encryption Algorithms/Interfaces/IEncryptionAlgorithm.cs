using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___Encryption_Algorithms.Interfaces
{
    interface IEncryptionAlgorithm
    {
        public byte[] EncryptData(byte[] content, byte[] key);
        public byte[] DecryptData(byte[] content, byte[] key);
    }
}
