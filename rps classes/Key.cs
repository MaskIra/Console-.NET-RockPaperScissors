using System.Security.Cryptography;
using System.Text;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace rps
{
    class Key
    {
        private byte[] salt;
        private byte[] hash;

        public Key(int keyLength, string computerMove)
        {
            GenerateSalt(keyLength);
            ComputeHMACSHA5256(computerMove);
        }

        private void GenerateSalt(int length)
        {
            salt = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(salt);
        }

        private void ComputeHMACSHA5256(string computerMove)
        {
            using (var HMAC = new HMACSHA256(salt))
            {
                hash = HMAC.ComputeHash(Encoding.Default.GetBytes(computerMove));
            }
        }

        public byte[] GetKey() { return salt; }
        public byte[] Gethash() { return hash; }

        public static string GetBytesToString(byte[] value)
        {
            return new SoapHexBinary(value).ToString();
        }
    }
}
