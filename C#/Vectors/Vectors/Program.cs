namespace Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vec3d v1 = new Vec3d(3, 5, 6);
            Vec3d v2 = new Vec3d(1, 1, 3);
            Vec2d v3 = new Vec2d(1, 2);

            Vec3d result = v1 + (Vec3d)v3;
            Console.WriteLine(result.x);
        }
    }
}