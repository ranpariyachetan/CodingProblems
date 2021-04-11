using System;
using System.Collections.Generic;
using System.Linq;
namespace CodingProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var maxGCD =  MaxGCD.CountLevelUpPlayers(3, 5, new int[] {2,2,3,4,5});
            var input = new int[] { 3, 3, 3, 3, 4, 8 };
            // var maxGCD = MaxGCD.packagingMine(input);
            var warehouse = new WarehouseCost();

            // int[][] pairs = new int[][] {new int[]{2,6}, new int[]{3,5},new int[]{0,1}, new int[]{2,9}, new int[]{5,6}};
            // var maxGCD = warehouse.EvaluateCost(10, pairs );

            // int[] arr1 = new int[] {2, 3};
            // int[] arr2 = new int[] {2};

            // var maxGCD = WarehouseCost.LargestIntersection(arr1, arr2);
            // Console.WriteLine(input.Sum());
            // Console.WriteLine(string.Join(',', input));

            // var arr = new int []{2, 3, 4, 8, 6, 10, 9, 12};

            // var maxGCD = AlmostIncreasingArray.CheckSequence(arr);

            // var arr = new int[] {1, 5, 4, 3};

            // var maxGCD = MaxWaterInContainer.FindContainerWithMaxWater(arr);

            // var r =     1534236469;
            // var maxGCD = MaxWaterInContainer.ReverseNumber(r);

            // var powers = new int[]{4, 2, 8 ,3, 5};
            // var maxGCD = MultiProcessor.MinimumTimeFoFinish(powers, 19);

            // var path = "SSLLSS";

            // var maxGCD = Robot.IsCirclePath(path);

            // var logs = new string[] {
            //     "345366 899212 45",
            //     "029323 382391 23",
            //     "382391 345366 15",
            //     "345366 345366 15",
            //     "029323 382391 77",
            //     "345366 382391 23",
            //     "029323 345366 13",
            //     "382391 382391 23"
            // };

            // var maxGCD = TransactionLogs.ListUserIds(logs, 4);

            // foreach (var item in maxGCD)
            // { Console.WriteLine(item); }

            // var pairs = new int[][] {new int[]{0,1}, new int[]{1,2}, new int[]{2, 3}};

            // var maxGCD = Graph.CheckIsCycleWithUnionFind(pairs, 4);

            // var connections = new int[][] {new int[] {1,2,5}, new int[] {1, 3, 6}, new int[] {2, 3, 1}, new int[] {4, 5, 6}};

            // // var connections = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 4, 4 } };

            // var maxGCD = MinimumSpanninTree.CalculateMinimumCost(connections, 5);


            // GraphClass.UseKruskalMST();

            // char[][] island = new char[][]{
            //                                 new char[]{'O', 'O', 'O', 'O'},
            //                                 new char[]{'D', 'O', 'D', 'O'},
            //                                 new char[]{'O', 'O', 'O', 'O'},
            //                                 new char[]{'O', 'O', 'O', 'X'}
            //                             };

            // var maxGCD = TreasureIsland.FindMinStepsWithDFS(island);

            char[][] island = new char[][] {
                                    new char[] {'S', 'O', 'O', 'S', 'S'},
                                    new char[]{'D', 'O', 'D', 'O', 'D'},
                                    new char[]{'O', 'O', 'O', 'O', 'X'},
                                    new char[]{'X', 'D', 'D', 'O', 'O'},
                                    new char[]{'X', 'D', 'D', 'D', 'O'}
                                };

            var maxGCD = TreasureIsland.FindShortestPathFromMultipleSource(island);

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
