using System;

namespace Project_17
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string SecretPassword = "триодиншестьчетыре";
            
            int maxAttempts = 3;
            int minAttempts = 0;
            bool isLose = true;

            for (int i = maxAttempts; i > minAttempts; i--)
            {
                Console.Write("введите пароль для доступа к секретному сообщению - ");
                string password = Console.ReadLine();

                if (password == SecretPassword)
                {
                    Console.WriteLine("пароль верный");
                    isLose = false;
                    break;
                }

                if (i > 1)
                {
                    Console.WriteLine($"пароль не верный, осталось попыток: {i - 1}");
                }
            }

            if (isLose)
            {
                Console.WriteLine("вы проиграли");
            }
        }
    }
}
