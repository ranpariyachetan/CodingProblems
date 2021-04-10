namespace CodingProblems
{
    public class MaxWaterInContainer
    {
        public static int FindContainerWithMaxWater(int[] arr)
        {
            int n = arr.Length;
            int start = 0;
            int end = n - 1;

            int maxArea = 0;
            while (start < end)
            {
                var h = arr[start] < arr[end] ? arr[start] : arr[end];

                var area = h * (end - start);

                maxArea = area > maxArea ? area : maxArea;

                if (h == arr[start])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return maxArea;
        }

        public static int ReverseNumber(int x)
        {
            long rev = 0;
            int m;
            bool isnegative = x < 0;
            int t = x < 0 ? -x : x;

            if (x + 1 == int.MaxValue)
            {
                return 0;
            }
            while (t > 0)
            {
                m = t % 10;
                rev = (rev * 10) + m;

                if (rev >= int.MaxValue)
                {
                    return 0;
                }

                t = t / 10;

            }

            rev = rev > int.MaxValue || rev < int.MinValue ? 0 : rev;

            return isnegative ? (int)-rev : (int)rev;
        }
    }
}