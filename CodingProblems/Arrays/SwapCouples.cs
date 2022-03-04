namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        // https://leetcode.com/problems/couples-holding-hands/
        // There are n couples sitting in 2n seats arranged in a row and want to hold hands.
        // The people and seats are represented by an integer array row where row[i] is the ID of the person sitting in the ith seat. 
        // The couples are numbered in order, the first couple being (0, 1), the second couple being (2, 3), and so on with the last couple being (2n - 2, 2n - 1).
        // Return the minimum number of swaps so that every couple is sitting side by side. 
        // A swap consists of choosing any two people, then they stand up and switch seats.
 
        private static int SwapCouples(int[] row)
        {
            var map = new Dictionary<int, int>();

            for (var j = 0; j < row.Length; j++)
            {
                map.Add(row[j], j);
            }
            var i = 0;

            var count = 0;
            var nextNumber = 0;
            while (i < row.Length)
            {
                if (row[i] / 2 != row[i + 1] / 2)
                {
                    if (row[i] % 2 == 0)
                    {
                        nextNumber = row[i] + 1;
                    }
                    else
                    {
                        nextNumber = row[i] - 1;
                    }

                    var temp = row[i + 1];
                    var idx = map[nextNumber];

                    row[i + 1] = row[idx];
                    row[idx] = temp;
                    map[row[i + 1]] = i + 1;
                    map[temp] = idx;
                    count++;
                }
                i = i + 2;
            }

            return count;
        }

        public static void TestCoupleSwap()
        {
            var arr = new int[] { 0, 2, 1, 3 };
            var res = SwapCouples(arr);

            Console.WriteLine(res);

            arr = new int[] { 3, 5, 0, 1, 2, 4 };
            res = SwapCouples(arr);

            Console.WriteLine(res);

            arr = new int[] {5,4,2,6,3,1,0,7};

            res  = SwapCouples(arr);

            Console.WriteLine(res);
        }
    }
}