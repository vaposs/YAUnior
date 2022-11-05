using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GetNumber();   
        }

        static void GetNumber()
        {
           string line;
           bool isConversionSucceeded = true;
           bool isSuccess;
           int number;

           while (isConversionSucceeded)
           {
                Console.Write("введите целое число - ");
                line = Console.ReadLine();
                iSsuccess = int.TryParse(line, out number);
                if (isSuccess)
                {
                    Console.WriteLine($"строка {line} успешно конвертирован в число - {number} ");
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($"строка {line} не может быть конвертирована");
                }
           }
        }
    }
}
