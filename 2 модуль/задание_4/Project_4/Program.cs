using System;

namespace Project_4
{
    class MainClass
    {
        public static void Main()
        {
            string enteredData;
            int arraySize = 1;
            int arraySizeNext = 1;
            int sumInt = 0;
            string exit = "exit";
            string sumString = "sum";
            int[] beginArray = new int[arraySize];
            bool isNext = true;


            while (isNext)
            {
                Console.Write("введите число или команду(sum/exit) - ");
                enteredData = Console.ReadLine();

                if (enteredData == exit)
                {
                    isNext = false;
                }
                else if (enteredData == sumString)
                {
                    for (int i = 0; i < beginArray.Length; i++)
                    {
                        sumInt += beginArray[i];
                    }

                    Console.WriteLine($"сумма чисел равна - {sumInt}");
                }
                else
                {
                    beginArray[arraySize - 1] = Convert.ToInt32(enteredData);
                    int[] nextArray = new int[beginArray.Length + arraySizeNext];

                    for(int i = 0; i < beginArray.Length; i ++)
                    {
                        nextArray[i] = beginArray[i];
                    }

                    arraySize++;
                    beginArray = nextArray;

                    for(int i = 0; i < beginArray.Length; i ++)
                    {
                        Console.Write(beginArray[i] + ",");
                    }
                }
            }
        }
    }
}
