using System;

namespace Project_15
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = "";
            string surname = "";
            int age = 0;
            string password = "";
            string command;
            bool toOut = true;
            int countNumberConstanta = 13;

            while(toOut)
            {
                Console.WriteLine("\nСписок доступных команд:");
                Console.WriteLine("1. setName           - ввести/поменять имя.");
                Console.WriteLine("2. setSurname        - ввети/поменять фамилию.");
                Console.WriteLine("3. setAge            - ввести/поменять возраст.");
                Console.WriteLine("4. setPassword       - ввести/поменять пароль.");
                Console.WriteLine("5. changeColor   - установить цвет фона консоли.");
                Console.WriteLine("6. resetColor        - сбросить цвета на стандартные.");
                Console.WriteLine("7. writeAll          - вывести всю информацию.");
                Console.WriteLine("8. Exit              - выход.");
                Console.WriteLine(" ");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();

                switch (command) 
                {
                    case "setName":
                        Console.Clear();
                        Console.Write("введите имя - ");
                        name = Console.ReadLine();
                        break;
                    case "setSurname":
                        Console.Clear();
                        Console.Write("введите фамилию - ");
                        surname = Console.ReadLine();
                        break;
                    case "setAge":
                        Console.Clear();
                        Console.Write("введите возраст - ");
                        age = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "setPassword":
                        Console.Clear();
                        Console.Write("введите пароль - ");
                        password = Console.ReadLine();
                        break;
                    case "changeColor":
                        Console.Clear();
                        Color();
                        break;
                    case "resetColor":
                        Console.ResetColor();
                        break;
                    case "writeAll":
                        string stringAge = Convert.ToString(age);
                        int coutChar = countNumberConstanta + stringAge.Length + name.Length + surname.Length + password.Length;

                        for (int i = 0; i < coutChar; i++)
                        {
                            Console.Write("-");
                        }

                        Console.WriteLine($"\n| {name} | {surname} | {age} | {password} |");

                        for (int i = 0; i < coutChar; i++)
                        {
                            Console.Write("-");
                        }

                        break;
                    case "Exit":
                        toOut = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Не верный ввод, попробуйсте снова.");
                        break;
                }
            }
        }
        public static void Color()
        {
            bool thisColor = true;

            while (thisColor)
            {
                string blue = "blue";
                string cyan = "cyan";
                string green = "green";
                Console.WriteLine("выберите цвет(blue/cyan/green) - ");
                string color = Console.ReadLine();

                if(color == blue)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    thisColor = false;
                }
                else if (color == cyan)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    thisColor = false;
                }
                else if (color == green)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    thisColor = false;
                }
                else
                {
                    Console.WriteLine("неверный ввод, попробуйте снова.");
                }
            }
        }
    }
}
