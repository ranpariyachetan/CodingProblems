namespace CodingProblems.Numbers
{
    // https://leetcode.com/problems/count-all-valid-pickup-and-delivery-options/

    // Given n orders, each order consist in pickup and delivery services. 
    // Count all valid pickup/delivery possible sequences such that delivery(i) is always after of pickup(i). 
    // Since the answer may be too large, return it modulo 10^9 + 7.
    public class PickupAndDelivery
    {
        private static int MOD = (int)Math.Pow(10, 9) + 7;
        public static int CountOrders(int n)
        {
            var cache = new int[n + 1, n + 1];

            return totalWays(n, n, cache);
        }

        private static int totalWays(int unpicked, int undelivered, int[,] cache)
        {
            if (unpicked == 0 && undelivered == 0)
            {
                return 1;
            }

            if (unpicked < 0 || undelivered == 0 || undelivered < unpicked)
            {
                return 0;
            }

            if (cache[unpicked, undelivered] != 0)
                return cache[unpicked, undelivered];

            long ans = 0;

            ans += unpicked * totalWays(unpicked - 1, undelivered, cache);

            ans %= MOD;

            ans += (undelivered - unpicked) * totalWays(unpicked, undelivered - 1, cache);

            ans %= MOD;

            cache[unpicked, undelivered] = (int)ans;

            return (int)ans;
        }

        public static void TestCountOrders()
        {
            var n = 3;

            Console.WriteLine(CountOrders(n));
            Console.WriteLine(CountOrdersWithPermutations(n));
        }

        public static int CountOrdersWithPermutations(int n)
        {
            long ans = 1;

            for (var it = 1; it <= n; it++)
            {
                ans = ans * it;

                ans = ans * (2 * it - 1);

                ans = ans % MOD;
            }

            return (int)ans;
        }
    }
}