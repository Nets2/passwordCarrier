using System.Security.Cryptography;
using System;
using System.Text;

namespace passwordCarrier
{
    public class Security
    {
        private byte[] IV { get; set; }
        private byte[] Salt { get; set; }
        private byte[] Key { get; set; }

        public Security(string IV, string salt, string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    this.IV = Encoding.Default.GetBytes(IV);
                    this.Salt = Encoding.Default.GetBytes(salt);
                    this.Key = Encoding.Default.GetBytes(GetHash(sha256Hash,salt + password));
                }
            }
        
        public static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();
        
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
        
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        
        public static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
        
        public bool verifyEncoding(string cryptedSalt, string cryptedIV)
        {
            return (decode(cryptedSalt + cryptedIV).Equals(this.Salt.ToString()+this.IV.ToString()));
        }
        public static string encode()
        {
            RijndaelManaged rij = new RijndaelManaged();
            rij.GenerateKey();
        
            return "encoded";
        }

        public static string decode(string encoded)
        {
            return "decoded";
        }
    }
}