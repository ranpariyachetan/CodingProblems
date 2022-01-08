using System.Collections.Generic;

namespace CodingProblems
{
    public class Password
    {
        public static long GetPasswordStrength(string password)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            for (var c = 'a'; c <= 'z'; c++)
            {
                map[c] = -1;
            }

            long ret = 0;
            int left = 0;
            int right = 0;
            for (var i = 0; i < password.Length; i++)
            {
                left = i - map[password[i]];
                right = password.Length - i;
                ret += left * right;
                map[password[i]] = i;
            }

            return ret;
        }
    }
}