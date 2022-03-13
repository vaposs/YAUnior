using System;

namespace Project_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Мордакин";
            string surname = "Валентин";
            string temporaryМariable;

            Console.WriteLine(name + " " + surname);

            temporaryМariable = name;
            name = surname;
            surname = temporaryМariable;

            Console.WriteLine(name + " " + surname);
        }
    }
}
