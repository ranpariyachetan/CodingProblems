// You are given n rectangular boxes, the ith box has the length lengthi, the width widthi and the height heighti. Your task is to check if it is possible to pack all boxes into one so that inside each box there is no more than one another box (which, in turn, can contain at most one another box, and so on). More formally, your task is to check whether there is such sequence of n different numbers pi (1 ≤ pi ≤ n) that for each 1 ≤ i < n the box number pi can be put into the box number pi+1.
// A box can be put into another box if all sides of the first one are less than the respective ones of the second one. You can rotate each box as you wish, i.e. you can swap its length, width and height if necessary.

// Example

// For length = [1, 3, 2], width = [1, 3, 2], and height = [1, 3, 2], the output should be
// boxesPacking(length, width, height) = true;
// For length = [1, 1], width = [1, 1], and height = [1, 1], the output should be
// boxesPacking(length, width, height) = false;
// For length = [3, 1, 2], width = [3, 1, 2], and height = [3, 2, 1], the output should be
// boxesPacking(length, width, height) = false.

namespace CodingProblems
{
    public class BoxPacking
    {
        
bool boxesPacking(int[] length, int[] width, int[] height) {
     int[] packs = new int[length.Length];

            for (int i = 0; i < length.Length; i++)
            {
                packs[i] = i;
            }

            //Sorted boxes base on total size (L * W * H)
            long currentBoxTotalSize = 0, nextBoxTotalSize = 0;
            int tempData = 0;
            for (int i = 0; i < length.Length; i++)
            {
                for (int j = 0; j < length.Length - 1; j++)
                {
                    currentBoxTotalSize = ((long)length[packs[j]] * (long)width[packs[j]] * (long)height[packs[j]]);
                    nextBoxTotalSize = ((long)length[packs[j + 1]] * (long)width[packs[j + 1]] * (long)height[packs[j + 1]]);

                    if (currentBoxTotalSize > nextBoxTotalSize)
                    {
                        tempData = packs[j];
                        packs[j] = packs[j + 1];
                        packs[j + 1] = tempData;
                    }
                }
            }

            bool result = true, swapable = false;
            int current = 0, next = 0;
            for (int i = 0; i < packs.Length - 1; i++)
            {
                current = packs[i];
                next = packs[i + 1];

                //Checking if the current box fit with the next one without any rotations.
                //If yes, keep moving to the next loop
                //If no, try to rotate all possible ways.
                if (length[current] >= length[next]
                    || width[current] >= width[next]
                    || height[current] >= height[next])
                {

                    if ((length[current] < length[next] && width[current] < height[next] && height[current] < width[next])
                        || (length[current] < width[next] && width[current] < length[next] && height[current] < height[next])
                        || (length[current] < height[next] && width[current] < width[next] && height[current] < length[next])
                        || (length[current] < width[next] && width[current] < height[next] && height[current] < length[next])
                        || (length[current] < height[next] && width[current] < length[next] && height[current] < width[next]))
                    {
                        swapable = true;
                    }

                    //If not swapable => the sequence is not correct.
                    if (!swapable)
                    {
                        return false;
                    }

                    swapable = false;
                }

            }

            return result;
}

    }
}

// Input:
// length: [1, 3, 2]
// width: [1, 3, 2]
// height: [1, 3, 2]
// Output:
// true
// Expected Output:
// true

// Input:
// length: [9980, 9984, 9981]
// width: [9980, 9984, 9983]
// height: [9981, 9984, 9982]
// Output:
// true
// Expected Output:
// true

// Input:
// length: [10, 8, 6, 4, 1]
// width: [7, 7, 6, 3, 2]
// height: [9, 6, 3, 2, 1]
// Output:
// true
// Expected Output:
// true

// Input:
// length: [4, 10, 3, 1, 4]
// width: [5, 7, 4, 1, 2]
// height: [6, 5, 5, 1, 2]
// Output:
// true
// Expected Output:
// true

// Input:
// length: [6, 5]
// width: [5, 3]
// height: [4, 4]
// Output:
// true
// Expected Output:
// true