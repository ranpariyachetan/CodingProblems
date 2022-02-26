namespace CodingProblems
{
    public class Common
    {
        public static void PrintArray(int[] arr)
        {
            Console.WriteLine($"[{string.Join(',', arr)}]");
        }

        public static void PrintJaggedArray(int[][] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"[{string.Join(',', arr[i])}]");
            }
        }
    }
}