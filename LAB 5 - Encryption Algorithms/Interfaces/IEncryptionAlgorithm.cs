using LAB_5___Encryption_Algorithms.Encryption_Algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___Encryption_Algorithms.Interfaces
{
    interface IEncryptionAlgorithm
    {
        public byte[] EncryptData(byte[] content, Key key);
        public byte[] DecryptData(byte[] content, Key key);
    }
}
