using System;
using System.Collections.Generic;

public class DijkstraAlgorithm
{
    private int[][] graph;
    private int numVertices;

    public DijkstraAlgorithm(int[][] graph)
    {
        this.graph = graph;
        numVertices = graph.Length;
    }

    public int[] FindShortestPaths(int startVertex)
    {
        int[] shortestPaths = new int[numVertices];
        bool[] visited = new bool[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            shortestPaths[i] = int.MaxValue;
            visited[i] = false;
        }

        shortestPaths[startVertex] = 0;

        FindShortestPathsRecursive(startVertex, shortestPaths, visited);

        return shortestPaths;
    }

    private void FindShortestPathsRecursive(int currentVertex, int[] shortestPaths, bool[] visited)
    {
        visited[currentVertex] = true;

        for (int vertex = 0; vertex < numVertices; vertex++)
        {
            if (graph[currentVertex][vertex] != 0 && !visited[vertex])
            {
                int newPathDistance = shortestPaths[currentVertex] + graph[currentVertex][vertex];

                if (newPathDistance < shortestPaths[vertex])
                {
                    shortestPaths[vertex] = newPathDistance;
                }
            }
        }

        int minVertex = -1;
        int minDistance = int.MaxValue;

        for (int vertex = 0; vertex < numVertices; vertex++)
        {
            if (shortestPaths[vertex] < minDistance && !visited[vertex])
            {
                minVertex = vertex;
                minDistance = shortestPaths[vertex];
            }
        }

        if (minVertex != -1)
        {
            FindShortestPathsRecursive(minVertex, shortestPaths, visited);
        }
    }
}

public class Program
{
    public static void Main()
    {
        int[][] graph = new int[][]
        {
            new int[] {0, 4, 0, 0, 0, 0, 0, 8, 0},
            new int[] {4, 0, 8, 0, 0, 0, 0, 11, 0},
            new int[] {0, 8, 0, 7, 0, 4, 0, 0, 2},
            new int[] {0, 0, 7, 0, 9, 14, 0, 0, 0},
            new int[] {0, 0, 0, 9, 0, 10, 0, 0, 0},
            new int[] {0, 0, 4, 14, 10, 0, 2, 0, 0},
            new int[] {0, 0, 0, 0, 0, 2, 0, 1, 6},
            new int[] {8, 11, 0, 0, 0, 0, 1, 0, 7},
            new int[] {0, 0, 2, 0, 0, 0, 6, 7, 0}
        };

        int startVertex = 0;

        DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
        int[] shortestPaths = dijkstra.FindShortestPaths(startVertex);

        Console.WriteLine("Shortest paths from vertex " + startVertex + ":");
        for (int i = 0; i < shortestPaths.Length; i++)
        {
            Console.WriteLine("Vertex " + i + ": " + shortestPaths[i]);
        }

        Console.ReadLine();
    }
}
