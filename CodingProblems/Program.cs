﻿using System;
using System.Linq;
namespace CodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
        //    var maxGCD =  MaxGCD.CountLevelUpPlayers(3, 5, new int[] {2,2,3,4,5});
            var input = new int[] {3, 3, 3, 3, 4, 8};
            // var maxGCD = MaxGCD.packagingMine(input);
            var warehouse = new WarehouseCost();

            // int[][] pairs = new int[][] {new int[]{2,6}, new int[]{3,5},new int[]{0,1}, new int[]{2,9}, new int[]{5,6}};
            // var maxGCD = warehouse.EvaluateCost(10, pairs );

            int[] arr1 = new int[] {2, 3};
            int[] arr2 = new int[] {2};

            var maxGCD = WarehouseCost.LargestIntersection(arr1, arr2);
            // Console.WriteLine(input.Sum());
            // Console.WriteLine(string.Join(',', input));
           Console.WriteLine(maxGCD);
        }
    }
}

//1, 3, 3, 5
//1, 3, 4, 5

//3, 3, 3, 3, 4, 8
//1, 3, 3, 3, 4, 8
//1, 3, 4, 3, 4, 5

//1, 

//21 

//[3, 1, 3, 4]

//[1, 1, 3, 4] 2

// [1, 1, 2, 3, 4]

//3, 3, 3, 3, 4, 8 - 24 
// 1,1,2,3,4,5,6  - 22

// Total 23
//1,2,3,4,5,6,7,8,9,10
