using System;

class Program
{
    // Головна програма
    static void Main()
    {
        // Отримуємо розмір масиву від користувача
        int size = GetValidSize();
        int[] A = new int[size];
        FillArray(A);

        Console.WriteLine("Initial array: " + string.Join(", ", A));

        // Заповнюємо масив випадковими значеннями
        int lastOddIndex = FindLastOddIndex(A);

        if (lastOddIndex != -1)
        {
            Console.WriteLine($"Last odd element index: {lastOddIndex + 1}");
            ModifyArray(ref A, lastOddIndex);
        }
        else
        {
            Console.WriteLine("No odd elements found in the array.");
        }

        Console.WriteLine("Updated array: " + string.Join(", ", A));
    }
    //Метод
    static int FindLastOddIndex(int[] array) //Знаходження останнього непарного елемента
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] % 2 != 0)
            {
                return i;
            }
        }
        return -1;
    }

    // Метод для модифікації масиву:
    // додає від 1 до 10 нових елементів після останнього непарного елемента
    static void ModifyArray(ref int[] array, int lastOddIndex) //Зміна масиву 
    {
        Random rand = new Random();
        int countToAdd = rand.Next(1, 11);
        Array.Resize(ref array, array.Length + countToAdd);
        for (int i = array.Length - 1; i > lastOddIndex; i--)
        {
            array[i] = array[i - countToAdd];
        }
        for (int i = 0; i < countToAdd; i++)
        {
            array[lastOddIndex + 1 + i] = lastOddIndex + 1;
        }
    }


    // Метод для запиту у користувача правильного розміру масиву

    static int GetValidSize() //Отримання розміру масиву
    {
        int size;
        while (true)
        {
            Console.Write("Enter the size of the array: ");
            if (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Invalid input, please enter a positive integer greater than 0.");
                continue;
            }

            return size;
        }
    }
    //Метод 
    static void FillArray(int[] array) //Заповнення масиву
    {
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(-array.Length, array.Length + 1);
        }
    }
}
