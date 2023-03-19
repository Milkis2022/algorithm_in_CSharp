using System;

public class AllPairShortestPath
{
	readonly static int INF = 99999, V = 4;

	void floydWarshall(int[,] graph)
	{
		int[,] dist = new int[V, V];
		int i, j, k;

		for (i = 0; i < V; i++)
		{
			for (j = 0; j < V; j++)
			{
				dist[i, j] = graph[i, j];
			}
		}

		for (k = 0; k < V; k++)
		{

			for (i = 0; i < V; i++)
			{

				for (j = 0; j < V; j++)
				{

					if (dist[i, k] + dist[k, j] < dist[i, j])
					{
						dist[i, j]
							= dist[i, k] + dist[k, j];
					}
				}
			}
		}
		printSolution(dist);
	}

	void printSolution(int[,] dist)
	{
		Console.WriteLine(
			"Following matrix shows the shortest "
			+ "distances between every pair of vertices");
		for (int i = 0; i < V; ++i)
		{
			for (int j = 0; j < V; ++j)
			{
				if (dist[i, j] == INF)
				{
					Console.Write("INF ");
				}
				else
				{
					Console.Write(dist[i, j] + " ");
				}
			}

			Console.WriteLine();
		}
	}
	public static void Main(string[] args)
	{
		/* Let us create the following
		weighted graph
			10
		(0)------->(3)
		|		 /|\
		5 |		 |
		|		 | 1
		\|/		 |
		(1)------->(2)
			3			 */

		int[,] graph = { { 0, 5, INF, 10 },
						{ INF, 0, 3, INF },
						{ INF, INF, 0, 1 },
						{ INF, INF, INF, 0 } };

		AllPairShortestPath a = new AllPairShortestPath();

		// Function call
		a.floydWarshall(graph);
	}
}

