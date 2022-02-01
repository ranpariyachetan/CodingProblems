using System;

namespace CodingProblems
{
    public class Islands 
    {
        public static int GetNumberOfIslandsDFS(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            bool[,] visited = new bool[rows, cols];

            int count = 0;

            for(var i = 0;i<rows;i++)
            {
                for(var j = 0;j<cols;j++)
                {
                    if(m[i,j] == 1 && !visited[i, j])
                    {
                        DFS(m, i, j, visited);
                        
                        count++;
                        // Console.WriteLine("Count is :"+ count);
                    }
                }
            }

            return count;
        }

        private static void DFS(int[,] m, int i, int j, bool[,] visited)
        {
            var nextX = new int[] { -1, 0, 0, 1 };

            var nextY = new int[] {  0, -1, 1, 0 };

            visited[i, j] = true;

            for(var k = 0;k<4;k++)
            {
                if (isSafe(m, i + nextX[k], j + nextY[k], visited))
                {
                    DFS(m, i + nextX[k], j + nextY[k], visited);
                }   
            }
        }

        private static bool isSafe(int[,] m, int i, int j, bool[,] visited) {
            return i >=0 && i < m.GetLength(0) && j >=0 && j< m.GetLength(1) && m[i,j] == 1 && !visited[i, j];
        }
    }
}