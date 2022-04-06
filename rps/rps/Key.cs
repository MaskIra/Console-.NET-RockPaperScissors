using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace rps
{
    class Key
    {
        private byte[] salt;
        private byte[] hash;

        public Key(int key_length, string computer_move)
        {
            GenerateSalt(key_length);
            ComputeHMACSHA512(computer_move);
        }

        private void GenerateSalt(int length)
        {
            RNGCryptoServiceProvider p = new RNGCryptoServiceProvider();
            salt = new byte[length];
            p.GetBytes(salt);
        }

        private void ComputeHMACSHA512(string computer_move)
        {
            using (var HMAC = new HMACSHA512(salt))
            {
                hash = HMAC.ComputeHash(Encoding.Default.GetBytes(computer_move));
            }
        }

        public byte[] getKey() { return salt; }
        public byte[] gethash() { return hash; }

        public static string GetBytesToString(byte[] value)
        {
            SoapHexBinary shb = new SoapHexBinary(value);
            return shb.ToString();
        }
    }
}
