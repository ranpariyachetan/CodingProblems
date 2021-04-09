using System;

namespace CodingProblems
{
    public class AlmostIncreasingArray {
       public static bool almostIncreasingSequence(int[] sequence) {

    // If the Length is 2 , We can reomve any element to make the sequence strictly increasing sequance
    if(sequence.Length ==2)
    {
         return true;
    }

    // counter to track the sequances
    int counterOne = 0;
    int counterTwo = 0;

    for(int i = 0 ; i < sequence.Length -1 ; i++)
    {
        // compare the immediate items to check if they are in sequence. 
        if(sequence[i] >= sequence[i+1])
        {
            counterOne++;
        }
        if(i != 0)
        {
            // remove/skip the element to see if we are getting increasing sequance
            if(sequence[i-1] >= sequence[i+1])
            {
                counterTwo++;
            }
        }
    }

    // check if there were only one item to remove for making the sequance strictly increasing.
    if(counterOne == 1 && counterTwo <= 1 )
       return true;
    else 
       return false;
}

bool almostIncreasingSequenceV3(int[] sequence) {
    if (sequence.Length <= 1) {
        return true;
    }
    int[] checker = new int[sequence.Length];
    for (int i = 0; i < sequence.Length; ++i) {
        checker[i] = 1;
    }
    for (int i = 0; i < sequence.Length; ++i) {
        for (int j = Math.Max(0, i - 2); j < i; ++j) {
            if (sequence[i] > sequence[j]) {
                checker[i] = Math.Max(checker[i], checker[j] + 1);
            }
        }
    }
    int count = 1;
    for (int i = 0; i < sequence.Length; ++i) {
        count = Math.Max(count, checker[i]);
    }
    return count >= sequence.Length - 1;
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