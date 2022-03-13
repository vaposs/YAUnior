using System;

namespace Project_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string zodiacSing;
            int age;
            string plaseOfWork;


            Console.WriteLine("Как вас зовут?");
            name = Console.ReadLine();
            Console.WriteLine("Какой ваш знак зодиака?");
            zodiacSing = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Где вы работаете?");
            plaseOfWork = Console.ReadLine();

            Console.WriteLine($"Вас зовут "+ name + ", вам - "+ age + "год и вы " + zodiacSing + ". Вы работаете на " + plaseOfWork + ".");



        }
    }
}
