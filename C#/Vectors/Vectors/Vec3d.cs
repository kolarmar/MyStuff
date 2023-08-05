using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    internal class Vec3d
    {
        public float x, y, z;
        public float Size => (float)Math.Sqrt(x * x + y * y + z * z);

        public Vec3d(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Normalize()
        {
            if (Size != 0)
            {
                float tempSize = Size;
                x /= tempSize;
                y /= tempSize;
                z /= tempSize;
            }
        }

        // VECTOR OPERATORS

        // Negative
        public static Vec3d operator -(Vec3d v)
        {
            return new Vec3d(-v.x, -v.y);
        }

        // Add
        public static Vec3d operator +(Vec3d v1, Vec3d v2)
        {
            return new Vec3d(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        // Subtract
        public static Vec3d operator -(Vec3d v1, Vec3d v2)
        {
            return new Vec3d(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        // Multiply by a scalar value
        public static Vec3d operator *(Vec3d v, float scale)
        {
            return new Vec3d(v.x * scale, v.y * scale, v.z * scale);
        }

        // Dot product
        public static float operator *(Vec3d v1, Vec3d v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        // Cross product
        public static Vec3d operator %(Vec3d v1, Vec3d v2)
        {
            return new Vec3d(
                            v1.y*v2.z - v1.z*v2.y,
                            v1.z*v2.x - v1.x*v2.z,
                            v1.x*v2.y - v1.y*v2.x
                            );
        }

        // Convert to 2d
        public static explicit operator Vec2d(Vec3d v)
        {
            return new Vec2d(v.x, v.y);
        }
    }
}
