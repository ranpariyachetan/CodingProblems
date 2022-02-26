namespace CodingProblems.Matrix
{
    public partial class Matrix
    {
        // https://leetcode.com/problems/reshape-the-matrix/
        private static int[][] ReshapeMatrix(int[][] mat, int r, int c)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            if (m * n != r * c)
            {
                return mat;
            }

            var row = 0;
            var col = 0;
            var result = new int[r][];
            result[row] = new int[c];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[row][col] = mat[i][j];
                    col++;
                    if (col == c)
                    {
                        row++;
                        col = 0;
                        if(row < r)
                        {
                            result[row] = new int[c];
                        }
                    }
                }
            }

            return result;
        }

        public static void TestReshapeMatrix()
        {
            var mat = new int[][] {
                new int[]{1,2}, 
                new int[] {3,4}
            };

            var r = 1;
            var c = 4;

            var result = ReshapeMatrix(mat, r, c);
            Common.PrintJaggedArray(result);

            mat = new int[][] {
                new int[]{1,2}, 
                new int[] {3,4},
                                new int[] {5,6}
            };

            r = 6;
            c = 1;

            result = ReshapeMatrix(mat, r, c);
            Common.PrintJaggedArray(result);
            
        }
    }
}