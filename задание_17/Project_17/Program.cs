using System;

namespace Project_17
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int attempts = 3;
            bool isLose = true;
            const string secretPassword = "триодиншестьчетыре";
            Console.WriteLine("пароль для дуступа к сетретному сообщению - триодиншестьчетыре");
            Console.WriteLine("продолжитьлжить ... ");
            Console.ReadKey();
            Console.Clear();
            Console.Write("введите пароль для доступа к секретному сообщению - ");

            while(attempts > 0)
            {
                string password = Console.ReadLine();

                if (password == secretPassword)
                {
                    Console.WriteLine("пароль верный");
                    isLose = false;
                }

                --attempts;

                if(attempts > 0)
                {
                    Console.Write("пароль не верный, попробуйсте снова - ");
                }
            }

            if(isLose == true)
            {
                Console.WriteLine("вы проиграли");
            }

            Console.WriteLine("нажмите любую кнопку для выхода");
            Console.ReadLine();
        }
    }
}
