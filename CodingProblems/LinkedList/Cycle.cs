using System;
using System.Collections.Generic;
namespace CodingProblems.LinkedList
{
    public partial class LinkedList
    {
        // https://leetcode.com/problems/linked-list-cycle/submissions/
        // Given head, the head of a linked list, determine if the linked list has a cycle in it.
        // There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. 
        // Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
        // Return true if there is a cycle in the linked list. Otherwise, return false.
        private static bool IsCycleV1(ListNode<int> head)
        {
            if(head == null || head.Next == null)
                return false;

            var set = new HashSet<ListNode<int>>();

            while(head != null)
            {
                if(set.Contains(head))
                {
                    return true;
                }
                else
                {
                    set.Add(head);
                }
                head = head.Next;
            }

            return false;
        }

        private static bool IsCycleV2(ListNode<int> head)
        {
            if(head == null || head.Next == null)
                return false;

            var fast = head.Next;
            var slow = head.Next;

            while(fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if(fast == slow)
                {
                    return true;
                }
            }

            return false;
        }

        public static void TestIsCycle()
        {
            var four = new ListNode<int>(4, null);
            var three = new ListNode<int>(3, four);
            var two = new ListNode<int> (2, three);
            var one = new ListNode<int>(1, two);
            var head = new ListNode<int>(0, one);
            four.Next = one;

            var result = IsCycleV1(head);

            Console.WriteLine(result);

            result = IsCycleV2(head);

            Console.WriteLine(result);
            
        }
    }
}