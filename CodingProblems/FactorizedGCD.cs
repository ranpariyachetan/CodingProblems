namespace CodingProblems
{
    //     Find the greatest common divisor of two given integer numbers. Each number is given in the form of its prime factorization - a sorted array of all prime factors.

    // Example

    // For a = [2, 3, 3, 3, 5] and b = [2, 2, 2, 2, 3, 3], the output should be
    // factorizedGCD(a, b) = 18.
    public class FactorizedGCD
    {
        public static int GetFactorizedGCD(int[] a, int[] b)
        {

            //Note: There is a failed hidden test case and I think the issue would be a big multiplication (int and long can't handle the case 97 x 10 times). I tried to use BigInteger but I got compiled error on CodeSignal.

            int firstNumber = a[0], secondNumber = b[0];
            for (int i = 0; i < a.Length - 1; i++)
            {
                firstNumber = firstNumber * a[i + 1];
            }

            for (int i = 0; i < b.Length - 1; i++)
            {
                secondNumber = secondNumber * b[i + 1];
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            int primeFractor = 0, smallestNumber = 0;

            if (firstNumber >= secondNumber)
            {
                smallestNumber = secondNumber;
            }
            else
            {
                smallestNumber = firstNumber;
            }

            for (int i = 1; i <= smallestNumber; i++)
            {
                if (firstNumber % i == 0 && secondNumber % i == 0)
                {
                    primeFractor = i;
                }
            }

            return primeFractor;
        }

        public static int GetFactorizedGCDV2(int[] a, int[] b)
        {
            int result = 1;
            int counter = 0;

            for (int i = 0; i < a.Length; i++)
            {
                //Skip if a value is greater than b value
                while (counter < b.Length && a[i] > b[counter])
                {
                    counter++;
                }

                //Find the common value in both and multiply as a factor
                if (counter < b.Length && a[i] == b[counter])
                {
                    result = result * a[i];
                    counter++;
                }
            }

            return result;
        }

    }
}

// Input:
// a: [2, 3, 3, 3, 5]
// b: [2, 2, 2, 2, 3, 3]
// Output:
// 18
// Expected Output:
// 18

// Input:
// a: [31, 37]
// b: [31, 37]
// Output:
// 1147
// Expected Output:
// 1147

// Input:
// a: [3, 5, 11]
// b: [13, 17]
// Output:
// 1
// Expected Output:
// 1

// Input:
// a: [7]
// b: [2, 3, 3, 3, 7]
// Output:
// 7
// Expected Output:
// 7