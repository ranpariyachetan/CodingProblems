using System.Collections.Generic;
using System;
namespace CodingProblems
{
    public static class DiscountCoupons
    {
        private  static List<int> CheckValidDiscountCoupons(List<string> discounts)
        {
            List<int> result = new List<int>();

            foreach(var discount in discounts)
            {
                result.Add(IsValidDiscount(discount) ? 1 : 0);
            }

            return result;
        }

        private static bool IsValidDiscount(string discount)
        {
            var stck = new Stack<char>();

            for(var i = 0;i<discount.Length;i++)
            {
                if(stck.Count == 0 || discount[i] != stck.Peek())
                {
                    stck.Push(discount[i]);
                } 
                else
                {
                    stck.Pop();
                }
            }

            return stck.Count == 0;

        }

        public static void TestValidDiscounts()
        {
            var discounts = new List<string> { "abc", "abba", "adbbdadd" };

            var res = CheckValidDiscountCoupons(discounts);

            foreach(var r in res)
            {
                Console.WriteLine(r);
            }
        }
    }
}
