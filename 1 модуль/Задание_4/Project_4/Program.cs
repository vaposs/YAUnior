namespace Project_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            string name = Console.ReadLine();
            Console.WriteLine("Какой ваш знак зодиака?");
            string zodiacSing = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Где вы работаете?");
            string plaseOfWork = Console.ReadLine();

            Console.WriteLine($"Вас зовут "+ name + ", вам - "+ age + "год и вы " + zodiacSing + ". Вы работаете на " + plaseOfWork + ".");
        }
    }
}
