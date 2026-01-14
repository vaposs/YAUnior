using System;

namespace pr1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minutesPerPatient = 10;
            int minutesPerHour = 60;

            Console.Write("Сколько человек перед вами в очереди? ");
            int patientsAhead = Convert.ToInt32(Console.ReadLine());
    
            int totalWaitMinutes = patientsAhead * minutesPerPatient;
            int waitHours = totalWaitMinutes / minutesPerHour;
            int remainingMinutes = totalWaitMinutes % minutesPerHour;
    
            Console.WriteLine($"Примерное время ожидания в очереди: {waitHours} часов и {remainingMinutes} минут");
        }
    }
}
