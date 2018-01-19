using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(VerifySignature());
            Console.Read();
        }
        private static string VerifySignature()
        {

            string computedSignature = "";

            var concatenatedContent = "12";
            var secretKey = "userNam";

            var enc = Encoding.UTF8;
            using (var hmac = new HMACSHA1(enc.GetBytes(secretKey)))
            {
                computedSignature = Convert.ToBase64String(hmac.ComputeHash(enc.GetBytes(concatenatedContent)));
            }
            return computedSignature;
        }
    }
}
