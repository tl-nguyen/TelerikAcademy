using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DecodeAnd_Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "ABBAA";
            var cypher = "BBBBBBA";

            Console.WriteLine(Decrypt(message, cypher), cypher);
        }

        private static string Encrypt(string message, string cypher)
        {
            StringBuilder decryptedMess = new StringBuilder(message);
            int steps = Math.Max(message.Length, cypher.Length);

            for (int step = 0; step < steps; step++)
            {
                var indexMessage = step % message.Length;
                var indexCypher = step % cypher.Length;

                decryptedMess[indexMessage] = (char)(((decryptedMess[indexMessage] - 'A') ^ (cypher[indexCypher]) - 'A') + 'A');
            }

            return decryptedMess.ToString();
        }

        private static string Decrypt(string message, string cypher)
        {
            return Encrypt(message, cypher);
        }


    }
}
