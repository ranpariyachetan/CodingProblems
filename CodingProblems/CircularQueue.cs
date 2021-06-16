using System;

namespace CodingProblems
{
    public class CircularQueue
    {
        private int[] items;
        private int start;
        private int end;
        private int size;
        private int count;

        public CircularQueue(int k)
        {
            if (k <= 0)
                throw new ArgumentException("Queue can not be created with size 0 or less");

            items = new int[k];
            size = k;
            start = 0;
            end = -1;
            count = 0;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
            {
                return false;
            }

            end = (end + 1) % size;
            items[end] = value;
            count++;
            return true;

        }

        public bool DeQueue()
        {
            if (IsEmpty())
            {
                return false;
            }
            start = (start + 1 + size) % size;
            count--;
            return true;
        }

        public int Front()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return items[start];
        }

        public int Rear()
        {
            if (IsEmpty())
            {
                return -1;
            }
            return items[end];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == size;
        }

        public static void TestCircularQueue()
        {
            var queue = new CircularQueue(8);

            Console.WriteLine($"Enqueue : {queue.EnQueue(00)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(10)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(20)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(30)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(40)}");

            Console.WriteLine($"IsFull : {queue.IsFull()}");
            Console.WriteLine($"Front : {queue.Front()}");
            Console.WriteLine($"Rear : {queue.Rear()}");
            Console.WriteLine($"Dequeue : {queue.DeQueue()}");
            Console.WriteLine($"Front : {queue.Front()}");
            Console.WriteLine($"Dequeue : {queue.DeQueue()}");
            Console.WriteLine($"Front : {queue.Front()}");
            Console.WriteLine($"Dequeue : {queue.DeQueue()}");
            Console.WriteLine($"Front : {queue.Front()}");
            Console.WriteLine($"Dequeue : {queue.DeQueue()}");
            Console.WriteLine($"Front : {queue.Front()}");
            Console.WriteLine($"IsEmpty : {queue.IsEmpty()}");
            Console.WriteLine($"Dequeue : {queue.DeQueue()}");
            Console.WriteLine($"Front : {queue.Front()}");
            Console.WriteLine($"Dequeue : {queue.DeQueue()}");
            Console.WriteLine($"Rear : {queue.Rear()}");

            Console.WriteLine($"Enqueue : {queue.EnQueue(60)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(70)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(80)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(90)}");
            Console.WriteLine($"Enqueue : {queue.EnQueue(100)}");
            Console.WriteLine($"Front : {queue.Front()}");
        }
    }
}