using System;
using System.Text;

class EncodeAndDecodeString
{
    static string Encode(string text, string key)
    {
        var encryptedMessage = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            encryptedMessage.Append((char)(text[i] ^ key[i % key.Length]));
        }
            
        return encryptedMessage.ToString();
    }

    static string Decode(string text, string key)
    {
        return Encode(text, key);
    }

    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string key = "anything";
        Console.WriteLine(Decode(Encode(text, key), key));
    }
}

