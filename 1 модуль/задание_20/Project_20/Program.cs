using System;

namespace Project_20
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("введите строку для проверки - ");
            string stringValidation = Console.ReadLine();
            Array line = new Array[stringValidation.Length];
            int bracket = 0;
            int bracketMax = 0;
            bool isNormal = true;
            char openBracketChar = '(';
            char clouseBracketChar = ')';

            for (int i = 0; i < stringValidation.Length; i++)
            {
                if(stringValidation[i]== openBracketChar)
                {
                    bracket++;

                    if(bracketMax < bracket)
                    {
                        bracketMax = bracket;
                    }
                }
                else if(stringValidation[i] == clouseBracketChar)
                {
                    bracket--;
                }
                if(bracket < 0)
                {
                    isNormal = false;
                }
            }

            if ((bracket == 0) && (isNormal == true))
            {
                Console.WriteLine($"коректное скобочное выражение, глубина вложений {bracketMax}");
            }
            else
            {
                Console.WriteLine($"не коректное скобо выражение");
            }
        }
    }
}
