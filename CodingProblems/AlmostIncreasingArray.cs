using System;

namespace CodingProblems
{
    // Problem statement
    // https://leetcode.com/problems/remove-one-element-to-make-the-array-strictly-increasing/
    // Given a 0-indexed integer array nums, return true if it can be made strictly increasing after removing exactly one element, or false otherwise. If the array is already strictly increasing, return true.
    // The array nums is strictly increasing if nums[i - 1] < nums[i] for each index (1 <= i < nums.length).
    public class AlmostIncreasingArray
    {
        public static bool IsAlmostIncreasingSequence(int[] sequence)
        {
            // If the Length is 2 , We can reomve any element to make the sequence strictly increasing sequance
            if (sequence.Length == 2)
            {
                return true;
            }

            // counter to track the sequances
            int counterOne = 0;
            int counterTwo = 0;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                // compare the immediate items to check if they are in sequence. 
                if (sequence[i] >= sequence[i + 1])
                {
                    counterOne++;
                }
                if (i != 0)
                {
                    // remove/skip the element to see if we are getting increasing sequance
                    if (sequence[i - 1] >= sequence[i + 1])
                    {
                        counterTwo++;
                    }
                }
            }

            // check if there were only one item to remove for making the sequance strictly increasing.
            if (counterOne == 1 && counterTwo <= 1)
                return true;
            else
                return false;
        }

        bool almostIncreasingSequenceV3(int[] sequence)
        {
            if (sequence.Length <= 1)
            {
                return true;
            }
            int[] checker = new int[sequence.Length];
            Array.Fill(checker, 1);
            // for (int i = 0; i < sequence.Length; ++i)
            // {
            //     checker[i] = 1;
            // }
            for (int i = 0; i < sequence.Length; ++i)
            {
                for (int j = Math.Max(0, i - 2); j < i; ++j)
                {
                    if (sequence[i] > sequence[j])
                    {
                        checker[i] = Math.Max(checker[i], checker[j] + 1);
                    }
                }
            }
            int count = 1;
            for (int i = 0; i < sequence.Length; ++i)
            {
                count = Math.Max(count, checker[i]);
            }
            return count >= sequence.Length - 1;
        }
    
        public static bool CheckAlmostIncreasingArray(int[] arr)
        {
            int change = 0;

            if(arr.Length <=2)
            {
                return true;
            }

            if(arr[0] > arr[1])
            {
                arr[0] = arr[1] / 2;
                change++;
            }

            for(int i = 1; i<arr.Length - 1;i++)
            {
                if((arr[i - 1] < arr[i] && arr[i+1] < arr[i])
                    || (arr[i-1] > arr[i] && arr[i + 1] > arr[i]))
                    {
                        arr[i] = (arr[i - 1] + arr[i + 1]) / 2;

                        if(arr[i] == arr[i - 1] || arr[i] == arr[i + 1])
                        {
                            return false;
                        }

                        change++;
                    }
            }

            if(arr[arr.Length-1] < arr[arr.Length - 2]) 
            {
                change++;
            }

            if(change > 1)
            {
                return false;
            }

            return true;
        }

        public static bool CheckSequence(int[] arr) 
        {
            if(arr.Length <=2)
            {
                return true;
            }

            int change = 0;

            for(int i = 0;i<arr.Length - 1;i++)
            {
                if(arr[i] >= arr[i+1])
                {
                    change ++;
                }

                if(change >= 2)
                {
                    return false;
                }
            }

            return true;
        }

        public static void TestCheckSequence()
        {
            var input = new int[] {1, 3, 2, 1};

            var result = CheckSequence(input);

            Console.WriteLine(result);
        }
    }
}


// input:
// sequence: [1, 3, 2, 1]
// Output:
// false
// Expected Output:
// false

// Input:
// sequence: [1, 2, 1, 2]
// Output:
// false
// Expected Output:
// false

// Input:
// sequence: [3, 6, 5, 8, 10, 20, 15]
// Output:
// false
// Expected Output:
// false

// Input:
// sequence: [1, 1, 2, 3, 4, 4]
// Output:
// false
// Expected Output:
// false

// Input:
// sequence: [123, -17, -5, 1, 2, 3, 12, 43, 45]
// Output:
// true
// Expected Output:
// true

// Input:
// sequence: [1, 2, 3, 4, 99, 5, 6]
// Output:
// true
// Expected Output:
// true

// Input:
// sequence: [1, 2, 3, 4, 3, 6]
// Output:
// true
// Expected Output:
// true