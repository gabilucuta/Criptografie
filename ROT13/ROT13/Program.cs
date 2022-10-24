using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ROT13
{

    public class EncryptDecryptRot13
    {
        private string[] textToBeCrypted;
        private static string encryptedText = "";
        private string decryptedText = "";

        public EncryptDecryptRot13(string[] a)
        {
            this.textToBeCrypted = a;
        }


        public string[] alfa = { "A" , "B" , "C" , "D", "E", "F" , "G", "H", "I" , "J", "K", "L" , "M", "N", "O" , "P", "Q",
            "R" , "S" , "T" , "U", "V" , "W" , "X" , "Y" , "Z"};

        public string Encrypt()
        {

            for (int i = 0; i < this.textToBeCrypted.Length; i++)
            {
                foreach (char b in this.textToBeCrypted[i])
                {

                    for (int j = 0; j < alfa.Length; j++)
                    {
                        if (alfa[j] == b.ToString())
                        {
                            if (j + 13 >= alfa.Length)
                                encryptedText += alfa[(j + 13) - alfa.Length];
                            else
                                encryptedText += alfa[j + 13];


                        }

                    }
                }
                encryptedText += " ";
            }

            Console.WriteLine(encryptedText);
            return encryptedText;
        }



        public void Decrypt()
        {
            foreach (char b in encryptedText)
            {
                if (b == ' ') decryptedText += " ";
                ;

                for (int j = 0; j < alfa.Length; j++)
                {
                    if (alfa[j] == b.ToString())
                    {
                        if (j - 13 < 0)
                            decryptedText += alfa[(j - 13) + alfa.Length];
                        else
                            decryptedText += alfa[j - 13];
                    }

                }
            }


            Console.WriteLine(decryptedText);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter text: ");
            string textToBeEncrypted = Console.ReadLine();
            string[] textSplited = textToBeEncrypted.Split(' ');


            EncryptDecryptRot13 data = new EncryptDecryptRot13(textSplited);

            Console.WriteLine("Press any key  to encrypt the text (ROT13) ");
            Console.ReadKey();
            data.Encrypt();

            Console.WriteLine("Press any key cu decrypt the text (ROT13)");
            Console.ReadKey();
            data.Decrypt();


        }
    }
}