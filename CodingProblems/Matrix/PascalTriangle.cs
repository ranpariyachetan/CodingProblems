using System;
using System.Collections.Generic;

namespace CodingProblems.Matrix
{
    // https://leetcode.com/problems/pascals-triangle/
    // Given an integer numRows, return the first numRows of Pascal's triangle.
    // In Pascal's triangle, each number is the sum of the two numbers directly above it 

    public class PascalTriangle
    {
        private static int[][] BuildPascalTriangle(int numRows)
        {
            var result = new int[numRows][];

            for(var line = 1;line <= numRows;line++)
            {
                var c = 1;
                result[line - 1] = new int[line];
                for(var i = 1;i<=line;i++)
                {
                    result[line - 1][i - 1] = c;
                    c = c * (line - i) / i;
                }

                // result.Add(list);
            }

            return result;
        }

        public static void TestBuildPascalTriangle()
        {
            var n = 5;

            var pt = BuildPascalTriangle(n);

            Common.PrintJaggedArray(pt);
        }
    }
}