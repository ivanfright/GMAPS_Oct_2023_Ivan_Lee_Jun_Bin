using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        Entries = new float[3, 3];
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x,y] = multiArray[x, y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        Entries[0,0] = m00;
        Entries[0,1] = m01;
        Entries[0,2] = m02;

        Entries[1,0] = m10;
        Entries[1,1] = m11;
        Entries[1,2] = m12;

        Entries[2,0] = m20;
        Entries[2,1] = m21;
        Entries[2,2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(
            left.Entries[0, 0] + right.Entries[0, 0], left.Entries[0, 1] + right.Entries[0, 1], left.Entries[0, 2] + right.Entries[0, 2],
            left.Entries[1, 0] + right.Entries[1, 0], left.Entries[1, 1] + right.Entries[1, 1], left.Entries[1, 2] + right.Entries[1, 2],
            left.Entries[2, 0] + right.Entries[2, 0], left.Entries[2, 1] + right.Entries[2, 1], left.Entries[2, 2] + right.Entries[2, 2]
        );

        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(
                left.Entries[0, 0] - right.Entries[0, 0], left.Entries[0, 1] - right.Entries[0, 1], left.Entries[0, 2] - right.Entries[0, 2],
                left.Entries[1, 0] - right.Entries[1, 0], left.Entries[1, 1] - right.Entries[1, 1], left.Entries[1, 2] - right.Entries[1, 2],
                left.Entries[2, 0] - right.Entries[2, 0], left.Entries[2, 1] - right.Entries[2, 1], left.Entries[2, 2] - right.Entries[2, 2]
            );

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D(
            left.Entries[0, 0] * scalar, left.Entries[0, 1] * scalar, left.Entries[0, 2] * scalar,
            left.Entries[1, 0] * scalar, left.Entries[1, 1] * scalar, left.Entries[1, 2] * scalar,
            left.Entries[2, 0] * scalar, left.Entries[2, 1] * scalar, left.Entries[2, 2] * scalar
        );

        return result;
    }

    // Note that the second argument is a HVector2D object
    //
    //public static HVector2D operator *(HMatrix2D left, HVector2D right)
    //{
    //return // your code here
    //}

    // Note that the second argument is a HMatrix2D object
    //
    //public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    //{
    //return new HMatrix2D
    //(
    /* 
        00 01 02    00 xx xx
        xx xx xx    10 xx xx
        xx xx xx    20 xx xx
        */
    //left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

    /* 
        00 01 02    xx 01 xx
        xx xx xx    xx 11 xx
        xx xx xx    xx 21 xx
        */
    //left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

    // and so on for another 7 entries
    //);
    //}

    //public static bool operator ==(HMatrix2D left, HMatrix2D right)
    //{
    // your code here
    //}

    //public static bool operator !=(HMatrix2D left, HMatrix2D right)
    //{
    // your code here
    //}

    //public override bool Equals(object obj)
    //{
    // your code here
    //}

    //public override int GetHashCode()
    //{
    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //return
    //}

    //public float getDeterminant()
    //{
    //return 
    //}

    /*public void setIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for(int x = 0; x < 3; x++)
            {
                if (x == y)
                {
                    Entries[x, y] = 1;
                }
                else
                {
                    Entries[x, y] = 0;
                }
            }
        }
    }*/

    public void setIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x, y] = (x == y) ? 1 : 0;
                //x equal to y, set to 1
                //else set to 0
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void setRotationMat(float rotDeg)
    {
        // your code here
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}