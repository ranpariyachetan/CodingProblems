using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class ChangeBST
    {
        //
        // Binary trees are already defined with this interface:
        // class Tree<T> {
        //   Tree(T x) {
        //     value = x;
        //   }
        //   T value;
        //   Tree<T> left;
        //   Tree<T> right;
        // }
        static Tree<int> changeBST(Tree<int> t)
        {

            int[] sum = new int[1];
            return changeBSTSum(t, sum);

        }


        static Tree<int> changeBSTSum(Tree<int> t, int[] sum)
        {
            if (t == null)
                return t;
            changeBSTSum(t.Right, sum);
            sum[0] = sum[0] + t.Value;
            t.Value = sum[0] - t.Value;
            changeBSTSum(t.Left, sum);
            return t;
        }

        //
        // Binary trees are already defined with this interface:
        // class Tree<T> {
        //   public T value { get; set; }
        //   public Tree<T> left { get; set; }
        //   public Tree<T> right { get; set; }
        // }
        Tree<int> changeBSTV2(Tree<int> t)
        {

            List<Tree<int>> temp = ListAdding(t, new List<Tree<int>>());
            Tree<int> t1 = Calculate(temp, t);
            return t1;
        }

        public static Tree<int> Calculate(List<Tree<int>> t, Tree<int> root)
        {
            int sum = 0;

            foreach (Tree<int> node in t)
            {
                sum += node.Value;
            }

            Tree<int> rootNode = t.Find(x => x == root);

            foreach (Tree<int> node in t)
            {
                sum -= node.Value;
                node.Value = sum;
            }
            return rootNode;
        }


        public static List<Tree<int>> ListAdding(Tree<int> n, List<Tree<int>> lst)
        {
            if (n == null)
            {
                return lst;
            }

            ListAdding(n.Left, lst);
            lst.Add(n);
            ListAdding(n.Right, lst);

            return lst;
        }

        public static void TestChangeBST()
        {
            var root = new Tree<int>();
            root.Value = 8;
            root.Left = new Tree<int>();
            root.Left.Value = 3;
            root.Left.Left = new Tree<int>();
            root.Left.Left.Value = 1;
            root.Left.Right = new Tree<int>();
            root.Left.Right.Value = 6;
            root.Left.Right.Left = new Tree<int>();
            root.Left.Right.Left.Value = 4;
            root.Left.Right.Right = new Tree<int>();
            root.Left.Right.Right.Value = 7;
            root.Right = new Tree<int>();
            root.Right.Value = 10;
            root.Right.Right = new Tree<int>();
            root.Right.Right.Value = 14;
            root.Right.Right.Left = new Tree<int>();
            root.Right.Right.Left.Value = 13;

            var r = changeBST(root);

            Console.WriteLine(r.Value);
        }
    }

    public class Tree<T>
    {
        public T Value;

        public Tree<T> Left;

        public Tree<T> Right;
    }
}