using System;

namespace Project_10
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool cycleActive = true;

            while(cycleActive)
            {
                Console.Write("Введите любое значение для повтора цикла или 'exit' для выхода. - ");
                string textMessege = Console.ReadLine();

                if(textMessege == "exit")
                {
                    cycleActive = false;
                    Console.WriteLine("Вы вышли из цикла.");
                }
            }
        }
    }
}
