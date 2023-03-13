namespace ComplexNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex z = 3;
            Complex x = (3, 0);
            Console.WriteLine(z == x);
        }
    }
}