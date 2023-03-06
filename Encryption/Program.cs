using System;
namespace Encryption
{
    class MonoalphabeticCipher
    {
        static void Main()
        {
            //                   ABCDEFGHIJKLMNOPQRSTUVWXYZ    >Alphabet
            const string  key = "QWERTYUIOPASDFGHJKLZXCVBNM";

            Console.Write("Enter the message to be encrypted: ");
            string message = Console.ReadLine().ToUpper();

            string encryptedMessage = Encrypt(message, key);

            string decryptedMessage = Decrypt(encryptedMessage, key);

            Console.WriteLine("Encrypted Message: {0}", encryptedMessage);
            Console.WriteLine("Decrypted Message: {0}", decryptedMessage);
        }

        static string Encrypt(string message, string key)
        {
            char[] encryptedMessage = new char[message.Length];//initialize size of the message
            for (int i = 0; i < message.Length; i++)
            {
                if (Char.IsLetter(message[i]))
                {
                    int index = Char.ToUpper(message[i]) - 'A'; //to know the index of the char in alphabet
                    encryptedMessage[i] = Char.IsUpper(message[i]) ? key[index] : Char.ToLower(key[index]);
                }
                else
                {
                    encryptedMessage[i] = message[i];
                }
            }
            return new string(encryptedMessage);
        }

        // Decrypt a message using a Monoalphabetic Cipher encryption key
        static string Decrypt(string encryptedMessage, string key)
        {
            char[] decryptedMessage = new char[encryptedMessage.Length];
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (Char.IsLetter(encryptedMessage[i]))
                {
                    int index = key.IndexOf(Char.ToUpper(encryptedMessage[i]));
                    decryptedMessage[i] = Char.IsUpper(encryptedMessage[i]) ? (char)('A' + index) : Char.ToLower((char)('A' + index));
                }
                else
                {
                    decryptedMessage[i] = encryptedMessage[i];
                }
            }
            return new string(decryptedMessage);
        }
    }
}
