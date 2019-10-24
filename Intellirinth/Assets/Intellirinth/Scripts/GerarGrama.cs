using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GerarGrama
{ 
    static int height;
    static int width;
    static int[][] maze;
    static public string generateMaze(int h, int w)
    {
        height = h;
        width = w;
        height = height % 2 == 0 ? height + 1 : height;
        width = width % 2 == 0 ? width + 1 : width;
        maze = new int[height][];
        // Initialize
        for (int i = 0; i < height; i++)
        {
            maze[i] = new int[width];
            for (int j = 0; j < width; j++)
                maze[i][j] = 1;
        }

        Random rand = new Random();
        // r for row、c for column
        // Generate random r

        int r = Random.Range(0, height);
        while (r % 2 == 0)
        {
            r = Random.Range(0, height);
        }
        // Generate random c
        int c = Random.Range(0, width);
        while (c % 2 == 0)
        {
            c = Random.Range(0, width);
        }
        // Starting cell
        maze[r][c] = 1;

        //　Allocate the maze with recursive method
       
        string str = "";
        for (int i = 0; i < maze.Length; i++)
        {
            for (int j = 0; j < maze[i].Length; j++)
            {

                str = string.Concat(str, maze[i][j].ToString());
            }
            str = string.Concat(str, "\r\n");
        }

        // return maze;
        return str;
    }

    /**
    * Generate an array with random directions 1-4
    * @return Array containing 4 directions in random order
    */
    static public int[] generateRandomDirections()
    {
        List<int> randoms = new List<int>();
        for (int i = 0; i < 4; i++)
            randoms.Add(i + 1);
        Shuffle(randoms);
        //System.Collections.shuffle(randoms);
        return randoms.ToArray();

    }

    public static void Shuffle<T>(this IList<T> list)
    {

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
