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
        public float size;

        public Vec3d(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.size = Size();
        }

        public float Size()
        {
            return (float)Math.Sqrt(this.x*this.x + this.y * this.y + this.z * this.z);
        }

        public void Normalize()
        {
            if (this.size != 0)
            {
                this.x /= this.size;
                this.y /= this.size;
                this.z /= this.size;
                this.size = Size();
            }
        }

        // VECTOR OPERATORS

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
    }
}
