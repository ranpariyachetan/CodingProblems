namespace CodingProblems.Numbers
{
    public class Fibonacci
    {
        public static int GetFibonacci(int n)
        {
            var cache = new Dictionary<int, int>();

            return GetFib(n, cache);
        }

        private static int GetFib(int n, Dictionary<int, int> cache)
        {
            if(n == 0 || n == 1)
                return n;

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            cache[n] = GetFib(n - 1, cache) + GetFib(n - 2, cache);

            Console.WriteLine(cache[n]);

            return cache[n];
        }

        public static void TestFibonacci()
        {
            var n = 8;

            Console.WriteLine(GetFibonacci(n));
        }
    }
}