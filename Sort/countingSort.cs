using System;

class Test
{
    static void CountSort(char[] arr)
    {
        int n = arr.Length;
        char[] output = new char[n];
        int[] count = new int[256];

        for (int i = 0; i < 256; ++i)
            count[i] = 0;

        for (int i = 0; i < n; ++i)
            ++count[arr[i]];

        for (int i = 1; i <= 255; ++i)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[arr[i]] - 1] = arr[i];
            --count[arr[i]];
        }

        for (int i = 0; i < n; ++i)
            arr[i] = output[i];
    }

    public static void Main()
    {

        char[] arr = { 'g', 'e', 'e', 'k', 's', 'f', 'o',
                       'r', 'g', 'e', 'e', 'k', 's' };

        CountSort(arr);

        Console.Write("Sorted character array is ");
        for (int i = 0; i < arr.Length; ++i)
            Console.Write(arr[i] + " ");
    }
}
