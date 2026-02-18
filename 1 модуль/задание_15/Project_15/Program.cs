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
            const string CommandSetAge = "setAge";
            const string CommandSetPassword = "setPassword";
            const string CommandChangeColor = "changeColor";
            const string CommandResetColor = "resetColor";
            const string CommandWriteAll = "writeAll";
            const string CommandRandomNumber = "randomNumber";
            const string CommandExit = "Exit";
            const string CommandBlueColor = "blue";
            const string CommandCyanColor = "cyan";
            const string CommandGreenColor = "green";

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
                Console.WriteLine($"2. {CommandSetSurname}        - ввести/поменять фамилию.");
                Console.WriteLine($"3. {CommandSetAge}            - ввести/поменять возраст.");
                Console.WriteLine($"4. {CommandSetPassword}       - ввести/поменять пароль.");
                Console.WriteLine($"5. {CommandChangeColor}       - установить цвет фона консоли.");
                Console.WriteLine($"6. {CommandResetColor}        - сбросить цвета на стандартные.");
                Console.WriteLine($"7. {CommandWriteAll}          - вывести всю информацию.");
                Console.WriteLine($"8. {CommandRandomNumber}      - сгенерировать и вывести рандомное число.");
                Console.WriteLine($"9. {CommandExit}              - выход.");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();

                switch (command)
                {
                    case CommandSetName:
                        Console.Write("Введите имя - ");
                        name = Console.ReadLine();
                        break;

                    case CommandSetSurname:
                        Console.Write("Введите фамилию - ");
                        surname = Console.ReadLine();
                        break;

                    case CommandSetAge:
                        Console.Write("Введите возраст - ");
                        age = int.Parse(Console.ReadLine());
                        break;

                    case CommandSetPassword:
                        Console.Write("Введите пароль - ");
                        password = Console.ReadLine();
                        break;

                    case CommandChangeColor:
                        bool isColorSet = false;

                        while (!isColorSet)
                        {
                            Console.WriteLine($"Выберите цвет ({CommandBlueColor}/{CommandCyanColor}/{CommandGreenColor}): ");
                            string color = Console.ReadLine().ToLower();

                            switch (color)
                            {
                                case CommandBlueColor:
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    isColorSet = true;
                                    break;
                                case CommandCyanColor:
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    isColorSet = true;
                                    break;
                                case CommandGreenColor:
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    isColorSet = true;
                                    break;
                                default:
                                    Console.WriteLine($"Неверный ввод. Доступные цвета: {CommandBlueColor}/{CommandCyanColor}/{CommandGreenColor}. Попробуйте снова.");
                                    break;
                            }
                        }
                        break;

                    case CommandResetColor:
                        Console.ResetColor();
                        break;

                    case CommandWriteAll:
                        Console.WriteLine($"| {name} | {surname} | {age} | {password} |");
                        break;

                    case CommandRandomNumber:
                        Console.WriteLine($"Случайное число: {random.Next()}");
                        break;

                    case CommandExit:
                        isWork = false;
                        break; ;

                    default:
                        Console.WriteLine("Неверный ввод, попробуйте снова.");
                        break;
                }
            }
        }
    }
}
