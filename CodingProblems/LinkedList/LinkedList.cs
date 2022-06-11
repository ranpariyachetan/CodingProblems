using System;

namespace CodingProblems.LinkedList
{
    public class Node
    {
        public Node()
        {
            Data = 0;
            Next = null;
        }

        public Node(int data, Node next)
        {
            Data = data;
            Next = next;
        }

        public int Data { get; set; }

        public Node Next { get; set; }
    }

    public partial class LinkedList
    {
        public static Node FindIntersection(Node head1, Node head2)
        {
            if (head1 == null || head2 == null)
            {
                return null;
            }

            if(head1 == head2)
            {
                return head1;
            }

            var h1 = head1;
            var h2 = head2;

            while (h1 != null || h2 != null)
            {

                h1 = h1 == null ? head2 : h1.Next;
                h2 = h2 == null ? head1 : h2.Next;

                if (h1 == h2)
                {
                    return h1;
                }
            }

            return null;
        }

        private static Node Reverse(Node head)
        {
            var right = head;
            Node prev = null;
            Node next = null;

            while(right != null)
            {
                next = right.Next;
                right.Next = prev;
                prev = right;
                right = next;
            }

            return prev;
        }

        public static void TestReverse()
        {
            var head = new Node(1, new Node(2, new Node(3, new Node(4, null))));

            var rev = Reverse(head);

            while(rev != null)
            {
                Console.WriteLine(rev.Data);
                rev = rev.Next;
            }
        }

        public static void TestFindIntersection()
        {
            var tail = new Node(300, null);
            var twoH = new Node(200, tail);
            var oneH = new Node(100, twoH);

            var ninety = new Node(90, oneH);
            var eighty = new Node(80, ninety);
            var seventy = new Node(70, eighty);

            var ninenine = new Node(99, new Node(100, new Node(110, new Node(120, null))));

            Console.WriteLine("List 1");
            var head1 = seventy;

            while(head1 != null) {
                Console.Write("{0} -> ", head1.Data);
                head1 = head1.Next;
            }
            Console.WriteLine();

            Console.WriteLine("List 2");
             head1 = ninenine;

            while(head1 != null) {
                Console.Write("{0} -> ", head1.Data);
                head1 = head1.Next;
            }
            Console.WriteLine();

            var result = FindIntersection(seventy, ninenine);

            if (result != null)
            {
                Console.WriteLine (result.Data);
            }
            else
            {
                Console.WriteLine("Intersection not found");
            }
        }
    }
}