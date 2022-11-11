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
            int[] temporaryArray = new int[size];
            int[] mixingArray;

            FillLine(temporaryArray);
            PrintArray(temporaryArray);
            mixingArray = Shuffle(temporaryArray);
            Console.WriteLine();
            PrintArray(mixingArray);
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

        static int[] FillLine(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            return array;
        }

        static void PrintArray(int[] array)
        {
            for(int i = 0; i < array.Length; i ++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static int[] Shuffle(int[] array)
        {
            int temporaryNumber;
            int temporaryNumber2;
            int maxRandom = array.Length;
            int minRandom = 1;
            Random rand = new Random();

            for (int i = 0; i < array.Length; i ++)
            {
                temporaryNumber = array[i];
                temporaryNumber2 = rand.Next(minRandom, maxRandom);
                array[i]= array[temporaryNumber2];
                array[temporaryNumber2] = temporaryNumber;
            }
            return array;
        }
    }
}
