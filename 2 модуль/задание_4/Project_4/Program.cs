using System;

namespace Project_4
{
    class MainClass
    {
        public static void Main()
        {
            string enteredData;
            string commandExit = "exit";
            string commandSum = "sum";
            int sum = 0;
            int[] array = new int[0];
            bool isWork = true;

            while (isWork)
            {
                Console.Write($"введите число или команду({commandSum}/{commandExit}) - ");
                enteredData = Console.ReadLine();

                if(enteredData == commandSum)
                {
                    sum = 0;

                    for(int i = 0; i < array.Length; i++)
                    {
                        sum += array[i];
                    }
                    Console.WriteLine($"сумма чисел масива равна {sum}");
                }
                else if(enteredData == commandExit)
                {
                    isWork = false;
                }
                else if (Convert.ToInt32(enteredData) > int.MinValue && Convert.ToInt32(enteredData) < int.MaxValue)
                {
                    int[] newArray = new int[array.Length + 1];
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            newArray[i] = array[i];
                        }

                        array = newArray;
                        array[array.Length - 1] = Convert.ToInt32(enteredData);
                    }
                }
            }
        }
    }
}
