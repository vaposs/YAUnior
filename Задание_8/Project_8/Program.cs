using System;

namespace Project_8
{
    class Program
    {
        static void Main()
        {
            long people;
            long hour;
            long minutу;

            Console.WriteLine("Сколько человек перед вами в очереди: ");
            people = Convert.ToInt32(Console.ReadLine());
            hour = (people * 10) / 60;
            minutу = (people * 10) % 60;

            if(hour == 0)
            {
                Console.WriteLine("Вы должны стоять в очереди " + minutу + " минут");
            }
            else if(hour == 1)
            {
                Console.WriteLine("Вы должны стоять в очереди " + hour + " час, и " + minutу + " минут");
            }
            else if (hour > 1)
            {
                Console.WriteLine("Вы должны стоять в очереди " + hour + " часа, и " + minutу + " минут");
            }
        }
    }
}
