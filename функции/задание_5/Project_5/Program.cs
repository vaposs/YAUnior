using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Исходный массив:");
        PrintArray(numbers);

        Shuffle(numbers);

        Console.WriteLine("\nПеремешанный массив:");
        PrintArray(numbers);
    }

    static void Shuffle(int[] array)
    {
        Random random = new Random();
        int randomIndex;
        int temp;

        for (int i = array.Length - 1; i > 0; i--)
        {
            randomIndex = random.Next(i + 1);

            temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}