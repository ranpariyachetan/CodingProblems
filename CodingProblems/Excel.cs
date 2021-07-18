using System;

namespace CodingProblems
{

    public class Excel
    {
        private static int GetColumnNumber(string columnName)
        {
            // var n = columnName.Length;

            var number = 0;

            // var i = 0;
            // while (n > 0)
            // {
            //     if (i == 0)
            //     {
            //         number += columnName[n - 1] - 65 + 1;
            //     }

            //     else
            //     {
            //         number += (int)Math.Pow(26, i) * ((int)(columnName[n - 1]) - 65 + 1);
            //     }
            //     i++;
            //     n--;
            // }

            foreach (var c in columnName)
            {
                number = number * 26;
                number += ((int)c - 65 + 1);
            }

            return number;
        }


        public static void TestGetColumnNumber()
        {
            var columnNames = new string[]{
                        "A","B","C","Z","AA","AB","AC","AZ","BA","BB","BZ","ZA","ZB","ZZ","AAA","AAB","AAC","AAZ","BAA","BAB","BAC","BBC","BBZ","XAA","XAB","XFA","XFD","ABC","AAA", "AZA"
                        };

            foreach (var columnName in columnNames)
            {
                var result = GetColumnNumber(columnName);
                Console.WriteLine("{0} : {1}", columnName, result);
            }
        }

        private static string GetColumnName(int columnNumber)
        {
            var n = columnNumber;
            string result = "";
            while (n > 0)
            {
                var rem = n % 26;
                if(rem == 0)
                {
                    result = (char)(65 + 25) + result;
                }
                else
                {
                    result = (char)(65 + rem - 1) + result;
                }
                n = n / 26;
            }

            return result;
        }

        public static void TestGetColumnName()
        {
            var columnNumbers = new int[] { 
                    //1, 2, 3, 4, 26, 27, 28,677, 703, 731 
                    677,
                    // 16384, 
                    // 1353
                };

            foreach (var columnNumber in columnNumbers)
            {
                var result = GetColumnName(columnNumber);
                Console.WriteLine("{0} : {1}", columnNumber, result);
            }
        }
    }
}