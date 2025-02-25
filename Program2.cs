using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
    
    }
}

class Vector3D
{
    float x, y, z;

    public Vector3D(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    // Comparison methods overload
    public override bool Equals(object other)
    {
        if(other == null)
        {
            return false;
        }

        Vector3D vector3D = (Vector3D)other;
        return x == vector3D.x && y == vector3D.y && z == vector3D.z;
    }

    public override int GetHashCode()
    {
        float hash = 5;
        hash = hash * 23f + x;
        hash = hash * 23f + y;
        hash = hash * 27f + z;
        return (int)hash;
    }

    // Operators overloading
    public static Vector3D operator +(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z); 
    }

    public static Vector3D operator -(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z); 
    }

    public static Vector3D operator *(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z); 
    }

    public static Vector3D operator /(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z); 
    }

    public static bool operator ==(Vector3D v1, Vector3D v2)
    {
        return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z; 
    }

    public static bool operator !=(Vector3D v1, Vector3D v2)
    {
        return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z; 
    }

    public static bool operator true(Vector3D v)
    {
        return v.x != 0 && v.y != 0 && v.z != 0; 
    }

    public static bool operator false(Vector3D v)
    {
        return v.x == 0 || v.y == 0 || v.z == 0; 
    }

    public static bool operator >(Vector3D v1, Vector3D v2)
    {
        return Math.Sqrt((v1.x * v1.x) + (v1.y * v1.y) + (v1.z * v1.z)) > Math.Sqrt((v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z));
    }

    public static bool operator <(Vector3D v1, Vector3D v2)
    {
        return Math.Sqrt((v1.x * v1.x) + (v1.y * v1.y) + (v1.z * v1.z)) < Math.Sqrt((v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z));
    }

    public static bool operator >=(Vector3D v1, Vector3D v2)
    {
        return Math.Sqrt((v1.x * v1.x) + (v1.y * v1.y) + (v1.z * v1.z)) >= Math.Sqrt((v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z));
    }

    public static bool operator <=(Vector3D v1, Vector3D v2)
    {
        return Math.Sqrt((v1.x * v1.x) + (v1.y * v1.y) + (v1.z * v1.z)) <= Math.Sqrt((v2.x * v2.x) + (v2.y * v2.y) + (v2.z * v2.z));
    }
}