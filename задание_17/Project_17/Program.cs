using System;

namespace Project_17
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string secretPassword = "триодиншестьчетыре";
            Console.WriteLine("пароль для дуступа к сетретному сообщению - триодиншестьчетыре");
            Console.WriteLine("продолжитьлжить ... ");
            Console.ReadKey();
            Console.Clear();
            Console.Write("введите пароль для доступа к секретному сообщению - ");

            while(true)
            {
                string password = Console.ReadLine();
                if (password == secretPassword)
                {
                    Console.WriteLine("пароль верный");
                    break;
                }
                else
                {
                    Console.Write("пароль не верный, попробуйсте снова - ");
                }
            }

            Console.WriteLine("нажмите любую кнопку для выхода");
            Console.ReadLine();
        }
    }
}
