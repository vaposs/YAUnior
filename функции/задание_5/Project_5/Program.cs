using System;

namespace Project_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            uint size;
            
            Console.Write("Введите размер масива - ");
            size = GetNumber();
            int[] array = new int[size];

            FillLine(array);
            PrintArray(array);
            Shuffle(array);
            Console.WriteLine();
            PrintArray(array);
        }

        static uint GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            uint number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isSuccess = uint.TryParse(line, out number);

                if (isSuccess)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.Write($"неверное значение {line}, введите другое число - ");
                }
            }
            return number;
        }

        static void FillLine(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        static void PrintArray(int[] array)
        {
            for(int i = 0; i < array.Length; i ++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void Shuffle(int[] array)
        {
            int temporaryNumber;
            int temporaryNumber2;
            int maxRandom = array.Length;
            int minRandom = 1;
            Random randomNumber = new Random();

            for (int i = 0; i < array.Length; i ++)
            {
                temporaryNumber = array[i];
                temporaryNumber2 = randomNumber.Next(minRandom, maxRandom);
                array[i]= array[temporaryNumber2];
                array[temporaryNumber2] = temporaryNumber;
            }
        }
    }
}
