namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackAsArray stack = new StackAsArray(10);

            for( int i = 0; i < 25; i++ )
            {
                stack.Push(i);
            }
            

            stack.Print();

        }
    }
}
