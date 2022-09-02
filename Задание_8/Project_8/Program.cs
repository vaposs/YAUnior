using System;

namespace pr1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minutesToReceive = 10;
            int minutesInAnHour = 60;

            Console.Write($"Вы заходите в поликлинику, сколько человек перед вами в очереди? -  ");
            int peopleCount = Convert.ToInt32(Console.ReadLine());
            int totalMinutesInQueue = peopleCount * minutesToReceive;
            int minuts = totalMinutesInQueue % minutesInAnHour;
            int hour = totalMinutesInQueue / minutesInAnHour;
            Console.WriteLine($"Вам ждать в очереди {hour} часов и {minuts} минут");
        }
    }
}
