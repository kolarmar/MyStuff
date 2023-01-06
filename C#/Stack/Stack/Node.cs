namespace Stack
{
    internal class Node
    {
        public int value;
        public Node next;

        public Node(int iValue, Node nNext = null)
        {
            value = iValue;
            next = nNext;
        }
    }
}
