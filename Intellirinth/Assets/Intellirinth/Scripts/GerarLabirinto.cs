using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GerarLabirinto 
{
    static int height;
    static int width;
    static int[][] maze;
    static public string generateMaze(int h,int w)
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
        
        int r = Random.Range(0,height);
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
        maze[r][c] = 0;

        //　Allocate the maze with recursive method
        recursion(r, c);
        string str="";
        for(int i=0;i<maze.Length;i++)
        {
            for(int j=0;j<maze[i].Length;j++)
            {

                str=string.Concat(str, maze[i][j].ToString());
            }
            str=string.Concat(str, "\r\n");
        }

        // return maze;
        return str;
    }

    static public void recursion(int r, int c)
    {
        // 4 random directions
        int[] randDirs = generateRandomDirections();
        // Examine each direction
        for (int i = 0; i < randDirs.Length; i++)
        {
            switch (randDirs[i])
            {
                case 1: // Up
                        //　Whether 2 cells up is out or not
                    if (r - 2 <= 0)
                        continue;
                    if (maze[r - 2][c] != 0)
                    {
                        maze[r - 2][c] = 0;
                        maze[r - 1][c] = 0;
                        recursion(r - 2, c);
                    }
                    break;
                case 2: // Right
                        // Whether 2 cells to the right is out or not
                    if (c + 2 >= width - 1)
                        continue;
                    if (maze[r][c + 2] != 0)
                    {
                        maze[r][c + 2] = 0;
                        maze[r][c + 1] = 0;
                        recursion(r, c + 2);
                    }
                    break;
                case 3: // Down
                        // Whether 2 cells down is out or not
                    if (r + 2 >= height - 1)
                        continue;
                    if (maze[r + 2][c] != 0)
                    {
                        maze[r + 2][c] = 0;
                        maze[r + 1][c] = 0;
                        recursion(r + 2, c);
                    }
                    break;
                case 4: // Left
                        // Whether 2 cells to the left is out or not
                    if (c - 2 <= 0)
                        continue;
                    if (maze[r][c - 2] != 0)
                    {
                        maze[r][c - 2] = 0;
                        maze[r][c - 1] = 0;
                        recursion(r, c - 2);
                    }
                    break;
            }

            maze[1][0] = 0;
            maze[height-2][width-1]= 0;
        }

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

