/* We have input values of N and
an array Coins that holds all of
the coins. We use data type of
long because we want to be able
to test large values without
integer overflow*/

using System;

public class getWays
{

	static long getNumberOfWays(long N, long[] Coins)
	{
		// Create the ways array to 1 plus the amount
		// to stop overflow
		long[] ways = new long[(int)N + 1];

		// Set the first way to 1 because its 0 and
		// there is 1 way to make 0 with 0 coins
		ways[0] = 1;

		// Go through all of the coins
		for (int i = 0; i < Coins.Length; i++)
		{

			// Make a comparison to each index value
			// of ways with the coin value.
			for (int j = 0; j < ways.Length; j++)
			{
				if (Coins[i] <= j)
				{
	
					// Update the ways array
					ways[j] += ways[(int)(j - Coins[i])];
				}
			}
		}

		// return the value at the Nth position
		// of the ways array.
		return ways[(int)N];
	}

	static void printArray(long[] coins)
	{
		foreach (long i in coins)
			Console.WriteLine(i);
	}

	// Driver code
	public static void Main(String []args)
	{
		long []Coins = { 1, 5, 10 };

		Console.WriteLine("The Coins Array:");
		printArray(Coins);

		Console.WriteLine("Solution:");
		Console.WriteLine(getNumberOfWays(12, Coins));
	}
}

// This code has been contributed by 29AjayKumar
