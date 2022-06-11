namespace CodingProblems.Matrix
{
    public partial class Matrix
    {
        // https://leetcode.com/problems/search-a-2d-matrix/
        // Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:
        // Integers in each row are sorted from left to right.
        // The first integer of each row is greater than the last integer of the previous row.
        public static bool SearchMatrix(int[][] mat, int target)
        {
            for (var i = 0; i < mat.Length; i++)
            {
                if (mat[i][mat[i].Length - 1] < target)
                {
                    continue;
                }
                if (BinarySearch(mat[i], target, 0, mat[i].Length))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool BinarySearch(int[] arr, int target, int l, int r)
        {
            if (l >= r)
                return false;

            int m = (l + r) / 2;

            if (arr[m] == target)
                return true;

            if (target < arr[m])
                return BinarySearch(arr, target, l, m);
            else
                return BinarySearch(arr, target, m + 1, r);
        }


        // This solution doe's not work on certain uses cases of target does not exist in the Matrix.
        private static bool SearchMatrixV2(int[][] matrix, int target)
        {
            var minRowIdx = 0;
            var minColIdx = 0;
            var maxRowIdx = matrix.Length - 1;
            var maxColIdx = matrix[0].Length - 1;

            var top = minRowIdx;
            var bottom = maxRowIdx;

            while(top <= bottom)
            {
                var m = (top + (bottom - top)) / 2;

                if(target == matrix[m][maxColIdx])
                {
                    return true;
                }
                if(target > matrix[m][maxColIdx])
                {
                    top = m + 1;
                }
                if(target < matrix[m][maxColIdx])
                {
                    bottom = m - 1;
                }
            }

            var l = minColIdx;
            var r = maxColIdx;
            while(l <= r)
            {
                var m = (l +(r - l)) / 2;

                if(target == matrix[top][m]){
                    return true;
                }

                if(target > matrix[top][m])
                {
                    l = m+1;
                }

                if(target < matrix[top][m])
                {
                    r = m - 1;
                }
            }

            return false;

        }

        public static void TestMatrixSearch()
        {
            var mat = new int[][]{
                new int[] {1,3,5,7},
                new int[] {10,11,16,20},
                new int[] {23,30,34,60}
            };

            var res = SearchMatrix(mat, 3);

            Console.WriteLine(res);

            res = SearchMatrix(mat,30);

            Console.WriteLine(res);

            res = SearchMatrix(mat, 8);

            Console.WriteLine(res);

            res = SearchMatrix(mat, 1);

            Console.WriteLine(res);

            res = SearchMatrix(mat, 7);

            Console.WriteLine(res);
        }
    }
}