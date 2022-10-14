using System;

namespace Project_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int arraySize = 50;
            int randomMax = 10;
            int repetition = 1;
            int numberReps = 0;
            int maxReps = 1;
            int referencePoint = 1;
            Random randon = new Random();
            int[] array = new int[arraySize];

            Console.WriteLine($"дан масив чисел из {arraySize}");

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = randon.Next(randomMax);
                Console.Write(array[i] + ",");
            }

            for(int i = 1; i < array.Length; i ++)
            {
                if(array[i] == array[i - referencePoint])
                {
                    repetition++;

                    if (repetition > maxReps)
                    {
                        maxReps = repetition;
                        numberReps = array[i];
                    }
                }
                else
                {
                    repetition = referencePoint;
                }
            }

            Console.WriteLine($"\nмаксимально повторов - {maxReps}, числа {numberReps}" );
        }
    }
}
