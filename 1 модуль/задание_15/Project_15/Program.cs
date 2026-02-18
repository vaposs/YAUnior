using System;

namespace qwertyu
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int CountNumber = 13;
            const string MenuBarSetName = "setName";
            const string MenuBarSetSurname = "setSurname";
            const string MenuBarSetAge = "setAge";
            const string MenuBarSetPassword = "setPassword";
            const string MenuBarChangeColor = "changeColor";
            const string MenuBarResetColor = "resetColor";
            const string MenuBarWriteAll = "writeAll";
            const string MenuBarRandomNumber = "randomNumber";
            const string MenuBarExit = "Exit";

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
                Console.WriteLine($"1. {MenuBarSetName}           - ввести/поменять имя.");
                Console.WriteLine($"2. {MenuBarSetSurname}        - ввети/поменять фамилию.");
                Console.WriteLine($"3. {MenuBarSetAge}            - ввести/поменять возраст.");
                Console.WriteLine($"4. {MenuBarSetPassword}       - ввести/поменять пароль.");
                Console.WriteLine($"5. {MenuBarChangeColor}       - установить цвет фона консоли.");
                Console.WriteLine($"6. {MenuBarResetColor}        - сбросить цвета на стандартные.");
                Console.WriteLine($"7. {MenuBarWriteAll}          - вывести всю информацию.");
                Console.WriteLine($"7. {MenuBarRandomNumber}      - сгенерировать и вывести рандомное число.");
                Console.WriteLine($"8. {MenuBarExit}              - выход.");
                Console.WriteLine(" ");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();

                switch (command)
                {
                    case MenuBarSetName:
                        Console.Clear();
                        Console.Write("введите имя - ");
                        name = Console.ReadLine();
                        break;

                    case MenuBarSetSurname:
                        Console.Clear();
                        Console.Write("введите фамилию - ");
                        surname = Console.ReadLine();
                        break;

                    case MenuBarSetAge:
                        Console.Clear();
                        Console.Write("введите возраст - ");
                        age = Convert.ToInt32(Console.ReadLine());
                        break;

                    case MenuBarSetPassword:
                        Console.Clear();
                        Console.Write("введите пароль - ");
                        password = Console.ReadLine();
                        break;

                    case MenuBarChangeColor:
                        Console.Clear();
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

                    case MenuBarResetColor:
                        Console.ResetColor();
                        break;

                    case MenuBarWriteAll:
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

                    case MenuBarRandomNumber:
                        Console.WriteLine($"{random.Next()}");
                        break;

                    case MenuBarExit:
                        isWork = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Не верный ввод, попробуйсте снова.");
                        break;
                }
            }
        }
    }
}
