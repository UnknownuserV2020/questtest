using System;

namespace ConsoleApp1
{
    public class Password
    {   //Мы пребываем На планету Тральфамадор ее код в галактике - 8 и находим дневник, некого путешественника, где описана инопланетная раса Тральфамадорцев. А также находим мультицивилизационный переводчик.
        //У них очень интересный алфавит"IGUWOCYTAZJHXKVDPLRNMQSEFB". Из дневника узнаем, что Тральфамадорцы не очень любят человеческую расу, но путешественнику удалось найти с ними общий язык. Среди записей находим послание, что если кто-то когда-то прочитает этот дневник
        //Должен сказать Тральфамадорцам XY xYGY CYUp Ad ShGp EkUUYjhp. Встретив Тральфамадрцев, мы так и сделали, но они не доверяют нам и в ответ на это говорят PYII hC pmY UhWAYG kT cIlhjmpYGmkhCY
        //Изначально стоит обычный английский алфавит. В тексте задания даем алфавит тральфамадорцев IGUWOCYTAZJHXKVDPLRNMQSEFB и код планеты  - 8.

        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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

        //шифрование если нам понадобиться что-то перешифровать до ввода задания в продакшн
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
            Console.Write("Введите Код цивилизации: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = pass.Decrypt(message, secretKey);
            Console.WriteLine("Код доустпа: {0}", encryptedText);
            Console.ReadLine();

        }
    }
}
