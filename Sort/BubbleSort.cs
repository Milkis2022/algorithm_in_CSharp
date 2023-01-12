class Program
{   
    static void BubbleSort(int[] arr, int len)
    {
        bool swapped = false;
        int i, j, temp;
        for(i = 0; i < len - 1; i++)
        {
            for(j = 0; j < len - i - 1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            // 만약 스왑이 한번도 안일어났다면 정렬 종료
            if(swapped == false)
                break;
        }
    }
    static void Main(string[] args)
    {
        int[] arr = { 1, 5, 6, 8, 11, 4, 7, 4 };
        BubbleSort(arr, arr.Length);

        foreach(var i in arr)
        {
            System.Console.Write(i + " ");
        }
    }
}
