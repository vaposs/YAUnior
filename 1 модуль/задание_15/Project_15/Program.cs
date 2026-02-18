using System;

namespace qwertyu
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int CountNumber = 13;
            const string CommandSetName = "setName";
            const string CommandSetSurname = "setSurname";
            const string CommandBarSetAge = "setAge";
            const string CommandSetPassword = "setPassword";
            const string CommandChangeColor = "changeColor";
            const string CommandResetColor = "resetColor";
            const string CommandWriteAll = "writeAll";
            const string CommandRandomNumber = "randomNumber";
            const string CommandExit = "Exit";

            Random random = new Random();
            string name = "";
            string surname = "";
            int age = 0;
            string password = "";
            string command;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("\nСписок доступных команд:");
                Console.WriteLine($"1. {CommandSetName}           - ввести/поменять имя.");
                Console.WriteLine($"2. {CommandSetSurname}        - ввети/поменять фамилию.");
                Console.WriteLine($"3. {CommandBarSetAge}            - ввести/поменять возраст.");
                Console.WriteLine($"4. {CommandSetPassword}       - ввести/поменять пароль.");
                Console.WriteLine($"5. {CommandChangeColor}       - установить цвет фона консоли.");
                Console.WriteLine($"6. {CommandResetColor}        - сбросить цвета на стандартные.");
                Console.WriteLine($"7. {CommandWriteAll}          - вывести всю информацию.");
                Console.WriteLine($"7. {CommandRandomNumber}      - сгенерировать и вывести рандомное число.");
                Console.WriteLine($"8. {CommandExit}              - выход.");
                Console.WriteLine(" ");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case CommandSetName:
                        Console.Write("введите имя - ");
                        name = Console.ReadLine();
                        break;

                    case CommandSetSurname:
                        Console.Write("введите фамилию - ");
                        surname = Console.ReadLine();
                        break;

                    case CommandBarSetAge:
                        Console.Write("введите возраст - ");
                        age = Convert.ToInt32(Console.ReadLine());
                        break;

                    case CommandSetPassword:
                        Console.Write("введите пароль - ");
                        password = Console.ReadLine();
                        break;

                    case CommandChangeColor:
                        bool isThisColor = true;

                        while (isThisColor)
                        {
                            string blue = "blue";
                            string cyan = "cyan";
                            string green = "green";
                            Console.WriteLine("выберите цвет(blue/cyan/green) - ");
                            string color = Console.ReadLine();

                            if (color == blue)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                isThisColor = false;
                            }
                            else if (color == cyan)
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                isThisColor = false;
                            }
                            else if (color == green)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                isThisColor = false;
                            }
                            else
                            {
                                Console.WriteLine("неверный ввод, попробуйте снова.");
                            }
                        }
                        break;

                    case CommandResetColor:
                        Console.ResetColor();
                        break;

                    case CommandWriteAll:
                        string stringAge = Convert.ToString(age);
                        int coutChar = CountNumber + stringAge.Length + name.Length + surname.Length + password.Length;

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

                    case CommandRandomNumber:
                        Console.WriteLine($"{random.Next()}");
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод, попробуйсте снова.");
                        break;
                }
            }
        }
    }
}
