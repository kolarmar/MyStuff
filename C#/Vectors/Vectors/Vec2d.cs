namespace Vectors
{
    class Vec2d
    {
        public float x, y;
        public float Size => (float)Math.Sqrt(x * x + y * y);

        public Vec2d(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void Normalize()
        {
            if (Size != 0)
            {
                float tempSize = Size;
                x /= tempSize;
                y /= tempSize;
            }
        }

        // VECTOR OPERATORS

        // Negative
        public static Vec2d operator -(Vec2d v)
        {
            return new Vec2d(-v.x, -v.y);
        }

        // Add
        public static Vec2d operator +(Vec2d v1, Vec2d v2)
        {
            return new Vec2d(v1.x + v2.x, v1.y + v2.y);
        }

        // Subtract
        public static Vec2d operator -(Vec2d v1, Vec2d v2)
        {
            return new Vec2d(v1.x - v2.x, v1.y - v2.y);
        }

        // Multiply by a scalar value
        public static Vec2d operator *(Vec2d v, float scale)
        {
            return new Vec2d(v.x * scale, v.y * scale);
        }

        // Dot Product
        public static float operator *(Vec2d v1, Vec2d v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        // Convert to 3d
        public static explicit operator Vec3d(Vec2d v)
        {
            return new Vec3d(v.x, v.y);
        }
    }
}
