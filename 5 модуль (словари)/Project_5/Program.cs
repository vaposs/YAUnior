using System;

namespace Project_5
{

    //создать 2 масива
    // заполнить рандомными числами 1-5
    //обьеденить в один массив
    //выполнить пузирьковую сортировку


    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArrayFirst;
            int sizeArraySecond;

            Console.Write("Введите размер первого масива - ");
            sizeArrayFirst = GetNumber();
            Console.Write("Введите размер второго масива - ");
            sizeArrayFirst = GetNumber();
            Array[] arrayFirst = new Array[sizeArrayFirst];

        }

        static int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isSuccess = int.TryParse(line, out number);

                if (isSuccess && number >= 0)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($" строка - {line}, не число или меньше  нуля. Повторите ввод. ");
                }
            }
            return number;
        }
    }
}
