using System;

namespace Project_13
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
            const int countNumber = 13;
            const string MENUBAR_1 = "setName";
            const string MENUBAR_2 = "setSurname";
            const string MENUBAR_3 = "setAge";
            const string MENUBAR_4 = "setPassword";
            const string MENUBAR_5 = "changeColor";
            const string MENUBAR_6 = "resetColor";
            const string MENUBAR_7 = "writeAll";
            const string MENUBAR_8 = "Exit";

            while (toOut)
            {
                Console.WriteLine("\nСписок доступных команд:");
                Console.WriteLine("1. setName           - ввести/поменять имя.");
                Console.WriteLine("2. setSurname        - ввети/поменять фамилию.");
                Console.WriteLine("3. setAge            - ввести/поменять возраст.");
                Console.WriteLine("4. setPassword       - ввести/поменять пароль.");
                Console.WriteLine("5. changeColor       - установить цвет фона консоли.");
                Console.WriteLine("6. resetColor        - сбросить цвета на стандартные.");
                Console.WriteLine("7. writeAll          - вывести всю информацию.");
                Console.WriteLine("8. Exit              - выход.");
                Console.WriteLine(" ");
                Console.Write("Введите команду - ");
                command = Console.ReadLine();

                switch (command) 
                {
                    case MENUBAR_1:
                        Console.Clear();
                        Console.Write("введите имя - ");
                        name = Console.ReadLine();
                        break;
                    case MENUBAR_2:
                        Console.Clear();
                        Console.Write("введите фамилию - ");
                        surname = Console.ReadLine();
                        break;
                    case MENUBAR_3:
                        Console.Clear();
                        Console.Write("введите возраст - ");
                        age = Convert.ToInt32(Console.ReadLine());
                        break;
                    case MENUBAR_4:
                        Console.Clear();
                        Console.Write("введите пароль - ");
                        password = Console.ReadLine();
                        break;
                    case MENUBAR_5:
                        Console.Clear();
                        Color();
                        break;
                    case MENUBAR_6:
                        Console.ResetColor();
                        break;
                    case MENUBAR_7:
                        string stringAge = Convert.ToString(age);
                        int coutChar = countNumber + stringAge.Length + name.Length + surname.Length + password.Length;

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
                    case MENUBAR_8:
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
