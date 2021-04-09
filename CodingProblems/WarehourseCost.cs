using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class WarehouseCost {
        int[] parent;
        public  int EvaluateCost(int n, int[][] connections)
    {
        parent = new int[n];

        for(int i =0;i<n;i++)
        {
            parent[i] = i;
        }

        foreach(int[] conn in connections )
        {
            Union(conn[0], conn[1]);   
        }

        Dictionary<int, int> map = new Dictionary<int, int>();

        for(int i = 0;i<n ;i++)
        {
            int dad = Find(i);

            if(!map.ContainsKey(dad)){
                map.Add(dad, 1);
            }else{
                map[dad] +=1;
            }
        }

        int sum =0;

        foreach(var item in map)
        {
            sum += (int) Math.Ceiling(Math.Sqrt(item.Value));
        }

        return sum;

    }

    private void Union(int a, int b)
    {
        int aparent = Find(a);
        int bparent = Find(b);

        if(aparent != bparent)
        {
            parent[bparent] = aparent;
        }
    }

    private int Find( int a)
    {
        if(parent[a] == a) return a;
        parent[a] = Find(parent[a]);

        return parent[a];
    }

    public static int LargestIntersection(int[]arr1, int[]arr2)
    {
        var len1 = LongestConsicutiveNumbers(arr1);
        var len2 = LongestConsicutiveNumbers(arr2);

        return len1 * len2;
    }

    private static int LongestConsicutiveNumbers(int[] arr)
    {
        var maxLen = 0;
        var consecLen = 0;
        var last = -1;

        // foreach(var val in arr)
        // {
        //     if(val != last + 1)
        //     {
        //         consecLen = 0;
        //     }

        //     last = val;
        //     consecLen++;
        //     if(consecLen > maxLen)
        //     {
        //         maxLen = consecLen;
        //     }
        // }

        for(var i =0;i<arr.Length;i++)
        {
            if(arr[i] != last+1)
            {
                consecLen = 0;
            }

last = arr[i];
            consecLen ++;
            if(consecLen > maxLen)
            {
                maxLen = consecLen;
            }
        }
        // for(var i = 0;i<arr.Length - 1;i++)
        // {
        //     if(arr[i] != arr[i + 1] - 1 )
        //     {
        //         consecLen =0;
        //     }
            
        //     consecLen += 1;

        //     if(consecLen > maxLen)
        //     {
        //         maxLen = consecLen;
        //     }
        // }

        return maxLen;
       }   
       }
}