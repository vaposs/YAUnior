using System;

namespace Project_8
{
    class Program
    {
        static void Main()
        {
            iConsole.Write($"Вы заходите в поликлинику, сколько человек перед вами в очереди? -  ");
            int peopleCount = Convert.ToInt32(Console.ReadLine());
            int minuts = (peopleCount * 10) % 60;
            int hour = (peopleCount * 10) / 60;
            Console.WriteLine($"Вам ждать в очереди {hour} часов и {minuts} минут");
        }
    }
}
