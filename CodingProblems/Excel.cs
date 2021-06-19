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
                number += number * 26;
                number += (c - 65 + 1);
            }

            return number;
        }

        public static void TestGetColumnNumber()
        {
            var columnNames = new string[]{
                        "A","B","C","Z","AA","AB","AC","AZ","BA","BB","BZ","ZA","ZB","ZZ","AAA","AAB","AAC","AAZ","BAA","BAB","BAC","BBC","BBZ","XAA","XAB","XFA","XFD","ABC"
                        };

            foreach (var columnName in columnNames)
            {
                var result = GetColumnNumber(columnName);
                Console.WriteLine("{0} : {1}", columnName, result);
            }
        }
    }
}