namespace Vectors
{
    internal class Vec2d
    {
        public float x, y;
        public float size;

        public Vec2d(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
            this.size = Size();
        }

        public float Size()
        { 
            return (float)Math.Sqrt(this.x* this.x + this.y*this.y);
        }

        public void Normalize()
        {
            if (size != 0)
            {
                this.x /= this.size;
                this.y /= this.size;
                this.size = Size();
            }
        }

        // VECTOR OPERATORS

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


    }
}
