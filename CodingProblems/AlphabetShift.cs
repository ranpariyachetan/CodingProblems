using System;
using System.Text;

namespace CodingProblems
{
    public class AlphabetShift
    {
        public static string AlphabeticShift(string inputString)
        {
            char[] chArr = inputString.ToCharArray();
            string result = "";

            foreach (char ch in chArr)
            {
                var asciiChar = Encoding.ASCII.GetBytes(ch.ToString());
                int nxtChar = 0;
                if (Convert.ToInt32(asciiChar[0]) == 122)
                {
                    nxtChar = 97;
                }
                else if (Convert.ToInt32(asciiChar[0]) == 90)
                {
                    nxtChar = 65;
                }
                else
                {
                    nxtChar = Convert.ToInt32(asciiChar[0]) + 1;
                }

                char c = Convert.ToChar(nxtChar);
                result = result + c.ToString();
            }

            Console.WriteLine("Output string is =" + result);
            return result;
        }

        public static String AlphabeticShiftV2(String inputString)
        {
            char[] inputCharArray = inputString.ToCharArray();

            for (int i = 0; i < inputCharArray.Length; i++)
            {
                if(inputCharArray[i] >= 'a')
                {
                    inputCharArray[i] = (char)((inputCharArray[i] - 'a' + 1) % 26 + 'a');
                }
                else if (inputCharArray[i] >= 'A')
                {
                    inputCharArray[i] = (char)((inputCharArray[i] - 'A' + 1) % 26 + 'A');
                }
            }
            return new string(inputCharArray);
        }
    }
}