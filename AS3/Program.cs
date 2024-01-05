using System;

class Program
{
    static int[] GenerateRandomArray(int size)
    {
        int[] array = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(-50, 51);
        }
        return array;
    }

    static int LinearSearch(int[] array, int target, out int iterations)
    {
        iterations = 0;
        for (int i = 0; i < array.Length; i++)
        {
            iterations++;
            if (array[i] == target)
                return i;
        }
        return -1;
    }

    static int BinarySearch(int[] array, int target, out int iterations)
    {
        iterations = 0;
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            iterations++;
            int mid = left + (right - left) / 2;
            if (array[mid] == target)
                return mid;

            if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left;

        for (int j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                Swap(ref array[i], ref array[j]);
                i++;
            }
        }

        Swap(ref array[i], ref array[right]);
        return i;
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        int[] array30 = GenerateRandomArray(30);
        int[] array200 = GenerateRandomArray(200);

        // Поиск определенного значения в неупорядоченном массиве для набора данных из 30 элементов
        int target1 = 10;
        int iterations1;
        int index1 = LinearSearch(array30, target1, out iterations1);
        Console.WriteLine("Индекс найденного элемента (полный перебор): " + index1);

        // Поиск определенного значения в неупорядоченном массиве для набора данных из 200 элементов
        int target2 = 20;
        int iterations2;
        int index2 = LinearSearch(array200, target2, out iterations2);
        Console.WriteLine("Индекс найденного элемента (полный перебор): " + index2);

        // Сортировка массива данных для набора данных из 30 элементов
        QuickSort(array30, 0, array30.Length - 1);

        // Сортировка массива данных для набора данных из 200 элементов
        QuickSort(array200, 0, array200.Length - 1);

        // Поиск определенного значения в упорядоченном массиве для набора данных из 30 элементов (метод прямого перебора)
        int target3 = 15;
        int iterations3;
        int index3 = LinearSearch(array30, target3, out iterations3);
        Console.WriteLine("Индекс найденного элемента (метод прямого перебора): " + index3);
        Console.WriteLine("Количество итераций (метод прямого перебора): " + iterations3);

        // Поиск определенного значения в упорядоченном массиве для набора данных из 30 элементов (метод бинарного поиска)
        int target4 = 15;
        int iterations4;
        int index4 = BinarySearch(array30, target4, out iterations4);
        Console.WriteLine("Индекс найденного элемента (метод бинарного поиска): " + index4);
        Console.WriteLine("Количество итераций (метод бинарного поиска): " + iterations4);
    }
}