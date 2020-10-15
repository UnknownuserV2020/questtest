using System;

namespace ConsoleApp1
{
    public class Password
    {
        //Изначально стоит обычный английский алфавит. В тексте задания даем алфавит тральфамадорцев IGUWOCYTAZJHXKVDPLRNMQSEFB
        const string alfabet = "IGUWOCYTAZJHXKVDPLRNMQSEFB";

        private string CodeEncode(string text, int k)
        {
            //добавляем в алфавит маленькие буквы
            var Alfabet = alfabet + alfabet.ToLower();
            var letterQty = Alfabet.Length;
            var returnVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = Alfabet.IndexOf(c);
                if (index < 0)
                {
                    returnVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    returnVal += Alfabet[codeIndex];
                }
            }

            return returnVal;
        }

        //шифрование 
        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key + 1);

        //дешифрование 
        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key - 1);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pass = new Password();
            Console.Write("Мультицивилизационный Дешифратор 4000  \n");
            Console.Write("Введите сообщение для дешифровки: ");
            var message = Console.ReadLine();
            Console.Write("Введите ключ доступа: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = pass.Decrypt(message, secretKey);
            Console.WriteLine("Код доустпа: {0}", encryptedText);
            Console.ReadLine();

        }
    }
}
 