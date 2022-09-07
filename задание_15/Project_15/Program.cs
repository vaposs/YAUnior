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
            int ageCountChar;
            string password = "";
            string command;
            bool toOut = true;
            int countNumberConstanta = 13;

            while(toOut)
            {
                Console.WriteLine("Список доступных команд:");
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
                        if(age<10)
                        {
                            ageCountChar = 1;
                        }
                        else if(age > 9 || age < 99)
                        {
                            ageCountChar = 2;
                        }
                        else
                        {
                            ageCountChar = 3;
                        }
                        int coutChar = countNumberConstanta + ageCountChar + name.Length + surname.Length + password.Length;
                        for (int i = 0; i < coutChar; i++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine("");
                        Console.WriteLine($"| {name} | {surname} | {age} | {password} |");
                        for (int i = 0; i < coutChar; i++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine("");
                        break;
                    case "Exit":
                        toOut = false;
                        break;
                    default:
                        Console.WriteLine("Не верный ввод, попробуйсте снова.");
                        break;
                }

            }
        }
        public static void Color()
        {
            while (true)
            {
                Console.WriteLine("выберите цвет(blue/cyan/green) - ");
                string color = Console.ReadLine();
                if(color == "blue")
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                }
                else if (color == "cyan")
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                }
                else if (color == "green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                }
                else
                {
                    Console.WriteLine("неверный ввод, попробуйте снова.");
                }
            }
        }
    }
}
