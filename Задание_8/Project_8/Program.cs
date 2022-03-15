using System;

namespace Project_8
{
    class Program
    {
        static void Main()
        {
            int minutesToReceive = 10;
            int minutesPerHour = 60;
            long people;
            long hoursInLine;
            long minutsInLine;

            Console.WriteLine("Сколько человек перед вами в очереди: ");
            people = Convert.ToInt32(Console.ReadLine());
            hoursInLine = (people * minutesToReceive) / minutesPerHour;
            minutsInLine = (people * minutesToReceive) % minutesPerHour;

            if (hoursInLine == 0)
            {
                Console.WriteLine("Вы должны стоять в очереди " + minutsInLine + " минут");
            }
            else if (hoursInLine == 1)
            {
                Console.WriteLine("Вы должны стоять в очереди " + hoursInLine + " час, и " + minutsInLine + " минут");
            }
            else if (hoursInLine > 1)
            {
                Console.WriteLine("Вы должны стоять в очереди " + hoursInLine + " часа, и " + minutsInLine + " минут");
            }
        }
    }
}
