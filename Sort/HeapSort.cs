using System;

public static class HeapSort
{
    public static void Sort(int[] arr)
    {
        int N = arr.Length;

        for(int i = N / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, N, i);
        }

        for(int i = N - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    public static void Heapify(int[] arr, int N, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        if (l < N && arr[l] > arr[largest])
            largest = l;

        if (r < N && arr[r] > arr[largest])
            largest = r;

        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, N, largest);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 10, 5, 4, 2, 7, 1 };

        HeapSort.Sort(arr);

        foreach (var i in arr)
            Console.WriteLine(i);

    }
}
