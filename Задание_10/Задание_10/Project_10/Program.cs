using System;

namespace Project_10
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool isActive = true;
            string stopCicle = "exit";

            while(isActive)
            {
                Console.Write("Введите любое значение для повтора цикла или 'exit' для выхода. - ");
                string textMessege = Console.ReadLine();

                if(textMessege == stopCicle)
                {
                    isActive = false;
                    Console.WriteLine("Вы вышли из цикла.");
                }
            }
        }
    }
}
