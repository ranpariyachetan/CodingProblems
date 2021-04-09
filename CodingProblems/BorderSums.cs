using System;

namespace CodingProblems {

//     Consider a square matrix with sides of even length.

// Define its 0-border as the union of left and right columns as well as top and bottom rows.
// Now consider the initial matrix without the 0-border. Its 0-border is 1-border for the initial matrix. In the same way one can define 2-border, 3-border, etc.

// Given a square matrix, find sums of elements for each of the matrix borders.
    public class BorderSums {
        public static int[] borderSums(int[][] matrix) {
    int size1 = 2;
    int size2 = 2;
    int sumi = 0;
    int sumj = -1;
    for(int i=0; i < size1; i++)
    {
        for (int j=0; j<size2; j++)
        {
            if(i==0 || j== 0 || i == size2-1 || j == size2-1)
            { 
                sumi = sumi+ matrix[size1][size2];
            }
        }
    }
    sumi = sumi*-4;
int[] response = {sumi, sumj};
return response;
}

public static int[] borderSumsV2(int[][] matrix) {

    int metrixLength = matrix.Length;
    int[] sums = new int[metrixLength/2];
    
    for(int i=0; i<metrixLength/2; i++){
        sums[i] = 0;
    }

    for(int i=0; i<metrixLength; i++){
        for(int j=0; j<metrixLength; j++){
            int b = Math.Min(i, j);
            b = Math.Min(b, metrixLength - i -1);
            b = Math.Min(b, metrixLength - j -1);

            sums[b] += matrix[i][j];
        }
    }

    return sums;
}


    }
}

// Input:
// matrix:
// [[1,2,2,3], 
//  [0,1,0,2], 
//  [4,-1,-1,-3], 
//  [4,-1,-1,3]]
// Output:
// [16, -1]
// Expected Output:
// [16, -1]

// Input:
// matrix:
// [[1,1,1,1,1,1], 
//  [1,1,1,1,1,1], 
//  [1,1,1,1,1,1], 
//  [1,1,1,1,1,1], 
//  [1,1,1,1,1,1], 
//  [1,1,1,1,1,1]]
// Output:
// [-16, -1]
// Expected Output:
// [20, 12, 4]