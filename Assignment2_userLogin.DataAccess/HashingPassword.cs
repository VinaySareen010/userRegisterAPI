using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess
{
    public static class HashingPassword
    {
        public static string CreateHash(string password, string salt)
        {
            var aragon2 = new Argon2id(Encoding.UTF8.GetBytes(password)); //Convert String password to bytes
            aragon2.Salt = Encoding.UTF8.GetBytes(salt);                  //Convert string salt to bytes
            aragon2.DegreeOfParallelism = 8;//Define No of Threads use by algoritham  //1degreeofparllelism 4kb required
            aragon2.Iterations = 30;                                      //No of Repitations as required req/Complaxity
            aragon2.MemorySize = 4 * 8;                          //memory size depend on degreeofparllelism 32kb

            return Convert.ToBase64String(aragon2.GetBytes(16));
        }
        public static string CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
        public static bool VerifyHash(string password, string salt, string hash)
        {
            var newHash = CreateHash(password, salt);
            return hash.SequenceEqual(newHash);
        }
    }
}
