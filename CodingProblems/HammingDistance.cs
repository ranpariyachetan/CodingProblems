namespace CodingProblems

{
    //     Given two strings of the same length. Your task is to calculate their Hamming distance.

    // Example

    // For string1 = "abab" and string2 = "cbad", the output should be
    // hammingDistance(string1, string2) = 2.

    // Only the first and the last characters are different.
    public class HammingDistance
    {
        public static int hammingDistance(string string1, string string2)
        {
            int i = 0;
            int count = 0;

            while (i < string1.Length)
            {
                if (string1[i] != string2[i])
                {
                    count++;
                }
                i++;
            }

            return count;
        }

    }
}