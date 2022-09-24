using System;

namespace Project_20
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("введите строку для проверки - ");
            string stringValidation = Console.ReadLine();
            Array str = new Array[stringValidation.Length];
            int openingBracket = 0;
            int closingBracket = 0;

            for (int i = 0; i < stringValidation.Length; i ++)
            {
                if(stringValidation[i] == '(')
                {
                    openingBracket++;
                }
                else if (stringValidation[i] == ')')
                {
                    closingBracket++;
                }
            }

            if(openingBracket == closingBracket)
            {
                Console.WriteLine($"коректное скобочное выражение, глубина вложений {openingBracket}");
            }
            else if(openingBracket > closingBracket)
            {
                Console.WriteLine($"не коректное скобочное выражение, открывающихся - {openingBracket}, закрывающихся - {closingBracket}");
            }
            else
            {
                Console.WriteLine($"не коректное скобочное выражение, открывающихся - {openingBracket}, закрывающихся - {closingBracket}");
            }
        }
    }
}
