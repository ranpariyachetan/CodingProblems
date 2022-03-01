namespace CodingProblems.LinkedList
{
    public class ListNode<T>
    {
        public ListNode()
        {
        }

        public ListNode(T data): this(data, null)
        {
        }

        public ListNode(T data, ListNode<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }
    }
}