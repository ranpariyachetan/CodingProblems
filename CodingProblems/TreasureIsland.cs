using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingProblems
{
    public class TreasureIsland
    {
        public static int FindMinStepsWithBFS(char[][] island)
        {
            if (island == null || island.Length == 0)
            {
                return 0;
            }

            int steps = 0;
            var visited = new bool[island.Length, island[0].Length];
            visited[0, 0] = true;

            Queue<int[]> queue = new Queue<int[]>();
            var dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            queue.Enqueue(new int[] { 0, 0 });

            var counter = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;

                steps++;

                for (int i = 0; i < size; i++)
                {
                    int[] coord = queue.Dequeue();

                    if (island[coord[0]][coord[1]] == 'X')
                    {
                        Console.WriteLine($"Counter : {counter}");
                        return steps - 1;
                    }

                    foreach (var dir in dirs)
                    {
                        int newx = coord[0] + dir[0];
                        int newy = coord[1] + dir[1];
                        counter++;

                        if (newx >= 0 && newx < island.Length && newy >= 0 && newy < island[0].Length && island[newx][newy] != 'D' && !visited[newx, newy])
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            visited[newx, newy] = true;
                        }
                    }
                }

            }

            Console.WriteLine($"BFS Counter : {counter}");
            return steps - 1;
        }

        private static int result = int.MaxValue;
        private static int counter = 0;
        public static int FindMinStepsWithDFS(char[][] island)
        {
            if (island == null || island.Length == 0)
            {
                return 0;
            }

            var dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            PerformDFS(island, dirs, 0, 0, 0);

            Console.WriteLine($"DFS Counter : {counter}");
            return result;
        }

        private static void PerformDFS(char[][] island, int[][] dirs, int x, int y, int steps)
        {
            if (x < 0 || x >= island.Length || y < 0 || y >= island[0].Length || island[x][y] == 'D' || steps > result)
            {
                return;
            }

            if (island[x][y] == 'X')
            {
                result = Math.Min(result, steps);
                return;
            }

            island[x][y] = 'D';
            foreach (var dir in dirs)
            {
                counter++;
                int newx = x + dir[0];
                int newy = y + dir[1];
                PerformDFS(island, dirs, newx, newy, steps + 1);
            }
        }

        public static int FindShortestPathFromMultipleSource(char[][] island)
        {
            if (island == null || island.Length == 0)
            {
                return -1;
            }

            var dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

            Queue<int[]> queue = new Queue<int[]>();

            for(int i=0;i<island.Length;i++)
            {
                for(int j = 0;j<island[0].Length;j++)
                {
                    if(island[i][j] == 'S')
                    {
                        queue.Enqueue(new int[] {i, j});
                        island[i][j] = 'D';
                    }
                }
            }

            int steps = 1;

            while(queue.Count > 0)
            {
                int size = queue.Count;

                for(int i = 0;i<size;i++)
                {
                    int[] coords = queue.Dequeue();

                    foreach(var dir in dirs)
                    {
                        var newx = coords[0] + dir[0];
                        var newy = coords[1] + dir[1];

                        if(newx < 0 || newx >= island.Length || newy < 0 || newy >= island[0].Length || island[newx][newy] == 'D')
                        {
                            continue;
                        }

                        if(island[newx][newy] == 'X')
                        {
                            return steps;
                        }

                        queue.Enqueue(new int[] {newx, newy});

                        island[newx][newy] = 'D';
                    }
                }

                steps++;
            }

            return -1;
        }
    }
}