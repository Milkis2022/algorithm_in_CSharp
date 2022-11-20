using System;
 
static class Test {
    static int[] arr = { 5, 15, 6, 9, 4 };
 
    //선형 탐색.
     public static int search(int[] arr, int x)
    {
        int N = arr.Length;
        for (int i = 0; i < N; i++) {
            if (arr[i] == x)
                return i;
        }
        return -1;
    }
    
    // 재귀 탐색
    static int linearsearch(int[] arr, int size, int key)
    {
        if (size == 0) {
            return -1;
        }
        else if (arr[size - 1] == key) {
            // Return the index of found key.
            return size - 1;
        }
        else {
            return linearsearch(arr, size - 1, key);
        }
    }
 

    public static void Main(String[] args)
    {
        int key = 4;
 
        // Test code.
        int index = linearsearch(arr, arr.Length, key);
 
        if (index != -1)
            Console.Write("The element " + key
                          + " is found at " + index
                          + " index of the given array.");
        else
            Console.Write("The element " + key
                          + " is not found.");
    }
}
 
