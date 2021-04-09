using System;
using System.Collections.Generic;
using System.Linq;
namespace CodingProblems
{
    public class ClockDigitCount {
       public static int[] clockDigitsCount(int[] startTime, int[] finishTime) {
 var myList = new List<string>();

 while(startTime[2] <= finishTime[2])
 {
     foreach(int i in startTime)
     {
         string chStr = (i.ToString().Length <= 1) ? "0" + i.ToString() : i.ToString();

         char[] ch = chStr.ToCharArray();
         foreach(char c in ch)
         {
             myList.Add(c.ToString());
         }         
     }
     startTime[2] = startTime[2] + 1;
 }

 myList.Sort();
 var g = myList.GroupBy(i=>i);
 int[] outArray = new int[10];
 
 foreach(var grp in g)
 {
     int tmp = 0;
     while(tmp < 10)
     {
        if(Convert.ToInt32(grp.Key) == tmp)
        {
            outArray[tmp] = Convert.ToInt32(grp.Count());
        }
        tmp++;
    }    
 }

foreach(int ir in outArray)
{
    Console.WriteLine(ir);
}

 return outArray;
}

public static int[] clockDigitsCountV2(int[] startTime, int[] finishTime) {
  
                int start = startTime[0] * 60 * 60 + startTime[1] * 60 + startTime[2];
                int finish = finishTime[0] * 60 * 60 + finishTime[1] * 60 + finishTime[2];

            int[] result = new int[10];

            for (int current = start; current <= finish; current++)
            {
                int[] values = {current % 60,
                    (current / 60) % 60,
                    current / (60 * 60)};
                for (int i = 0; i < values.Length; i++)
                {
                    result[values[i] % 10]++;
                    result[(values[i] / 10) % 10]++;
                }
            }

            return result;
}


    }
}

// Input:
// startTime: [13, 24, 5]
// finishTime: [13, 24, 20]
// Output:
// [7, 27, 18, 17, 17, 2, 2, 2, 2, 2]
// Expected Output:
// [7, 27, 18, 17, 17, 2, 2, 2, 2, 2]

// input:
// startTime: [23, 59, 58]
// finishTime: [23, 59, 59]
// Output:
// [0, 0, 2, 2, 0, 4, 0, 0, 1, 3]
// Expected Output:
// [0, 0, 2, 2, 0, 4, 0, 0, 1, 3]

// Input:
// startTime: [13, 24, 9]
// finishTime: [13, 24, 40]
// Output:
// [5, 45, 45, 45, 36, 3, 3, 3, 3, 4]
// Expected Output:
// [5, 45, 45, 45, 36, 3, 3, 3, 3, 4]