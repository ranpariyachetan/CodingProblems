using System;
using System.Collections.Generic;

// Two words are blanagrams if they are anagrams but exactly one letter has been substituted for another.

// Given two words, check if they are blanagrams of each other.

// Example

// For word1 = "tangram" and word2 = "anagram", the output should be
// checkBlanagrams(word1, word2) = true;

// After changing the first letter 't' to 'a' in the word1, the words become anagrams.

// For word1 = "tangram" and word2 = "pangram", the output should be
// checkBlanagrams(word1, word2) = true.

// Since a word is an anagram of itself (a so-called trivial anagram), we are not obliged to rearrange letters. Only the substitution of a single letter is required for a word to be a blanagram, and here 't' is changed to 'p'.

// For word1 = "aba" and word2 = "bab", the output should be
// checkBlanagrams(word1, word2) = true.

// You can take the first letter 'a' of word1 and change it to 'b', obtaining the word "bba", which is an anagram of word2 = "bab". It is also possible to change the first letter 'b' of word2 to 'a' and obtain "aab", which is an anagram of word1 = "aba".

// For word1 = "silent" and word2 = "listen", the output should be
// checkBlanagrams(word1, word2) = false.

// These two words are anagrams of each other, but no letter substitution was made (the trivial substitution of a letter with itself shouldn't be considered), so they are not blanagrams.

namespace CodingProblems
{
    public class CheckBlanagrams
    {
        static bool checkBlanagrams(string word1, string word2)
        {
            int flag = 0;

            var str1 = word1.ToCharArray();
            var str2 = word2.ToCharArray();

            Array.Sort(str1);
            Array.Sort(str2);
            // List<string> str1 = new List<string>();
            // List<string> str2 = new List<string>();
            // for (int i = 0; i < word1.Length; i++)
            // {
            //     str1.Add(Convert.ToString(word1[i]));
            //     str2.Add(Convert.ToString(word2[i]));
            // }
            // str1.Sort();
            // str2.Sort();

            int i = 0, x = 0, y = 0;

            while (i + x < word1.Length && i + y < word1.Length)
            {
                if (str1[i + x] != str2[i + y])
                {
                    flag++;
                    i++;
                    if (str1[i] > str2[i])
                    {
                        y++;
                    }
                    else
                    {
                        x++;
                    }
                    continue;
                }
                i++;
            }

            if (flag == 1)
            {
                return true;
            }
            return false;
        }

        static bool checkBlanagramsV2(string word1, string word2)
        {
            int[] checker = new int[26];
            for (int i = 0; i < 26; ++i)
            {
                checker[i] = 0;
            }
            for (int i = 0; i < word1.Length; ++i)
            {
                checker[word1[i] - 'a']++;
            }
            for (int i = 0; i < word1.Length; ++i)
            {
                checker[word2[i] - 'a']--;
            }
            int count = 0;
            for (int i = 0; i < 26; ++i)
            {
                count += Math.Abs(checker[i]);
            }
            return count == 2;
        }

        public static void TestBlanagrams()
        {
            var word1 = "gramnah";
            var word2 = "anagram";

            var result = checkBlanagrams(word1, word2);

            Console.WriteLine(result);
        }
    }
}