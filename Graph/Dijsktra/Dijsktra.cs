using System;
using System.Collections.Generic;

// This class represents a directed graph using
// adjacency list representation
public class Graph
{
private const int INF = 2147483647;

private int V;
private List<int[]>[] adj;

public Graph(int V)
{
	// No. of vertices
	this.V = V;
	// In a weighted graph, we need to store vertex
	// and weight pair for every edge
	this.adj = new List<int[]>[V];

	for (int i = 0; i < V; i++)
	{
	this.adj[i] = new List<int[]>();
	}
}

public void AddEdge(int u, int v, int w)
{
	this.adj[u].Add(new int[] { v, w });
	this.adj[v].Add(new int[] { u, w });
}

// Prints shortest paths from src to all other vertices
public void ShortestPath(int src)
{
	// Create a priority queue to store vertices that
	// are being preprocessed.
	SortedSet<int[]> pq = new SortedSet<int[]>(new DistanceComparer());

	// Create an array for distances and initialize all
	// distances as infinite (INF)
	int[] dist = new int[V];
	for (int i = 0; i < V; i++)
	{
	dist[i] = INF;
	}

	// Insert source itself in priority queue and initialize
	// its distance as 0.
	pq.Add(new int[] { 0, src });
	dist[src] = 0;

	/* Looping till priority queue becomes empty (or all
		distances are not finalized) */
	while (pq.Count > 0)
	{
	// The first vertex in pair is the minimum distance
	// vertex, extract it from priority queue.
	// vertex label is stored in second of pair (it
	// has to be done this way to keep the vertices
	// sorted by distance)
	int[] minDistVertex = pq.Min;
	pq.Remove(minDistVertex);
	int u = minDistVertex[1];

	// 'i' is used to get all adjacent vertices of a
	// vertex
	foreach (int[] adjVertex in this.adj[u])
	{
		// Get vertex label and weight of current
		// adjacent of u.
		int v = adjVertex[0];
		int weight = adjVertex[1];

		// If there is a shorter path to v through u.
		if (dist[v] > dist[u] + weight)
		{
		// Updating distance of v
		dist[v] = dist[u] + weight;
		pq.Add(new int[] { dist[v], v });
		}
	}
	}

	// Print shortest distances stored in dist[]
	Console.WriteLine("Vertex Distance from Source");
	for (int i = 0; i < V; ++i)
	Console.WriteLine(i + "\t" + dist[i]);
}

private class DistanceComparer : IComparer<int[]>
{
	public int Compare(int[] x, int[] y)
	{
	if (x[0] == y[0])
	{
		return x[1] - y[1];
	}
	return x[0] - y[0];
	}
}
}

public class Program
{
// Driver Code
public static void Main()
{
	// create the graph given in above figure
	int V = 9;
	Graph g = new Graph(V);

	// making above shown graph
	g.AddEdge(0, 1, 4);
	g.AddEdge(0, 7, 8);
	g.AddEdge(1, 2, 8);
	g.AddEdge(1, 7, 11);
	g.AddEdge(2, 3, 7);
	g.AddEdge(2, 8, 2);
	g.AddEdge(2, 5, 4);
	g.AddEdge(3, 4, 9);
	g.AddEdge(3, 5, 14);
	g.AddEdge(4, 5, 10);
	g.AddEdge(5, 6, 2);
	g.AddEdge(6, 7, 1);
	g.AddEdge(6, 8, 6);
	g.AddEdge(7, 8, 7);
	g.ShortestPath(0);
}
}

// this code is contributed by bhardwajji

