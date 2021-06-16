
using System;
using System.Text;

namespace CodingProblems
{
    // Given a string, find the shortest possible string which can be achieved by adding characters to the end of initial string to make it a palindrome.
    public class BuildPalindrome
    {
        public static string BuildPalindromeString(string input)
        {

            bool isPalindromePossible;
            // start from the strng Length and keep adding charaters until we find the palindrone
            for (int i = input.Length; ; i++)
            {
                isPalindromePossible = true;

                for (int j = 0; j < input.Length; j++)
                {
                    if (i - j <= input.Length && input[j] != input[i - j - 1])
                    {
                        isPalindromePossible = false;
                        break;
                    }
                }
                if (isPalindromePossible)
                {
                    // append the characters to form the palindrome
                    for (int j = input.Length; j < i; j++)
                    {
                        input += input[i - j - 1];
                    }
                    return input;
                }
            }
        }

        public static string buildPalindromeV3(string st)
        {
            var builder = new StringBuilder(st);
            for (int i = 0; i < st.Length; i++)
            {
                var subStr = st.Substring(0, i);
                builder.Append(ReverseString(subStr));

                if (IsPalindrome(builder.ToString()))
                {
                    return builder.ToString();
                }
                else
                {
                    builder = new StringBuilder(st);
                }
            }
            return builder.ToString();
        }

        static bool IsPalindrome(string st)
        {
            if (st.Equals(ReverseString(st)))
            {
                return true;
            }
            return false;
        }

        static string ReverseString(string st)
        {
            char[] arr = st.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }

        static bool isPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (s[l] != s[r])
                {
                    return false;
                }
                ++l;
                --r;
            }
            return true;
        }

        public static string buildPalindromeV4(string st)
        {
            if (isPalindrome(st))
            {
                return st;
            }
            string temp = "";
            for (int i = 0; i < st.Length; ++i)
            {
                temp = st[i] + temp;
                if (isPalindrome(st + temp))
                {
                    return st + temp;
                }
            }
            return temp;
        }

        private static string LongestPalindrome(string s)
        {
            if (s.Length == 0)
            {
                return s;
            }

            if (s.Length <= 2)
            {
                return s.Substring(0, 1);
            }

            int i = 0;

            int start = 0, x = start;

            int end = s.Length - 1, y = end;

            var maxLen = int.MinValue;

            var low = 0;

            for(i = 1;i<s.Length;i++)
            {
                start = i-1;
                end = i;

                while(start >=0 && end < s.Length && s[start] == s[end])
                {
                    if(end - start + 1 > maxLen)
                    {
                        low = start;
                        maxLen = end-start + 1;
                    }

                    start--;
                    end++;
                }

                start = i-1;

                end = i + 1;

                while(start >=0 && end < s.Length && s[start] == s[end])
                {
                    if(end - start + 1 > maxLen)
                    {
                        low = start;
                        maxLen = end - start + 1;
                    }

                    start--;
                    end ++;
                }

            }

            return s.Substring(low, maxLen);
        }

        public static void TestLongestPalindrome()
        {
            var input = "achetehcbchetehc";

            var result = LongestPalindrome(input);

            Console.WriteLine(result);
        }

        public static void TestBuildPalindromeString()
        {
            var input = "aacecaaa";

            var result = BuildPalindromeString(input);

            Console.WriteLine(result);
        }
    }
}

// Input:
// st: "abcdc"
// Output:
// "abcdcba"
// Expected Output:
// "abcdcba"

// Input:
// st: "ababab"
// Output:
// "abababa"
// Expected Output:
// "abababa"

// Input:
// st: "abba"
// Output:
// "abba"
// Expected Output:
// "abba"

// Input:
// st: "abc"
// Output:
// "abcba"
// Expected Output:
// "abcba"

// Input:
// st: "abcabc"
// Output:
// "abcabcbacba"
// Expected Output:
// "abcabcbacba"

// Input:
// st: "euotmn"
// Output:
// "euotmnmtoue"
// Expected Output:
// "euotmnmtoue"