using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ConversionNumber();   
        }

        static void ConversionNumber()
        {
           string line;
           bool conversionSucceeded = true;
           bool success;
           int number;

           while (conversionSucceeded)
           {
                Console.Write("введите целое число - ");
                line = Console.ReadLine();


                success = int.TryParse(line, out number);
                if (success)
                {
                    Console.WriteLine($"строка {line} успешно конвертирован в число - {number} ");
                    conversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($"строка {line} не может быть конвертирована");
                }
           }
        }
    }
}
