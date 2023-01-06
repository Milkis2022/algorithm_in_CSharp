using System;

static class BinarySearch
{
    public static int Search(int[] array, int left, int right, int x)
    {
        if(right >= left)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == x)
                return mid;

            if (array[mid] > x)
                return Search(array, left, mid - 1, x);

            return Search(array, mid + 1, right, x);
        }

        return -1;
    }
}

class Test
{   
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        int x = 4;
        int result = BinarySearch.Search(arr, 0, arr.Length, x);

        if (result == -1)
            Console.WriteLine("찾는 요소가 없습니다.");
        else
            Console.WriteLine($"찾는 요소는 {result}번 인덱스에 있습니다.");
    }
}
