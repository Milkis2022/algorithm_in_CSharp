using System;

// Time Complexity: O(Log min(a, b))

class Euclidean {
    public static int gcd(int a, int b)
    {
        if (a == 0)
            return b;
 
        return gcd(b % a, a);
    }
 
    static public void Main()
    {
        int a = 10, b = 15, g;
        g = gcd(a, b);
        Console.WriteLine("GCD(" + a + " , " + b + ") = " + g);
 
        a = 35;
        b = 10;
        g = gcd(a, b);
        Console.WriteLine("GCD(" + a + " , " + b + ") = " + g);
 
        a = 31;
        b = 2;
        g = gcd(a, b);
        Console.WriteLine("GCD(" + a + " , " + b + ") = " + g);
    }
}
