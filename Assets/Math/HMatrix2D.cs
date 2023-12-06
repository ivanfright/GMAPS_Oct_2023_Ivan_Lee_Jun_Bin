using System;
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
        //y would start from 0
        //if y is lesser than 3
        //the next iteration plus 1
        //ensuring this for loop repeat 3 times
        for (int y = 0; y < 3; y++)
        {
            //same goes for the x
            for (int x = 0; x < 3; x++)
            {
                //Then this is the array
                Entries[x,y] = multiArray[x, y];
            }
        }
    }

    //This is basically creating a 3 by 3 grid
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

    //This makes it so our 3x3 is able to add to another 3x3
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(
            //this first row
            // the first add the second and repeated 3 times as it is column of 3
            left.Entries[0, 0] + right.Entries[0, 0], left.Entries[0, 1] + right.Entries[0, 1], left.Entries[0, 2] + right.Entries[0, 2],
            //second row
            left.Entries[1, 0] + right.Entries[1, 0], left.Entries[1, 1] + right.Entries[1, 1], left.Entries[1, 2] + right.Entries[1, 2],
            //third row
            left.Entries[2, 0] + right.Entries[2, 0], left.Entries[2, 1] + right.Entries[2, 1], left.Entries[2, 2] + right.Entries[2, 2]
        );

        return result;
    }

    //Minus operator works almost the same as the plus operator
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        //but with the left and right values deducting each other
        HMatrix2D result = new HMatrix2D(
                left.Entries[0, 0] - right.Entries[0, 0], left.Entries[0, 1] - right.Entries[0, 1], left.Entries[0, 2] - right.Entries[0, 2],
                left.Entries[1, 0] - right.Entries[1, 0], left.Entries[1, 1] - right.Entries[1, 1], left.Entries[1, 2] - right.Entries[1, 2],
                left.Entries[2, 0] - right.Entries[2, 0], left.Entries[2, 1] - right.Entries[2, 1], left.Entries[2, 2] - right.Entries[2, 2]
            );

        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        //this scaling
        HMatrix2D result = new HMatrix2D(
            left.Entries[0, 0] * scalar, left.Entries[0, 1] * scalar, left.Entries[0, 2] * scalar,
            left.Entries[1, 0] * scalar, left.Entries[1, 1] * scalar, left.Entries[1, 2] * scalar,
            left.Entries[2, 0] * scalar, left.Entries[2, 1] * scalar, left.Entries[2, 2] * scalar
        );

        return result;
    }

    //this is when it multiply a 3x3 by 3x1
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {

        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h,
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h
        );
    }

    
    //this is for a 3x3 multiply by a 3x3
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            // First row
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            // Second row
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            // Third row
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (left.Entries[row, col] != right.Entries[row, col])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (left.Entries[row, col] != right.Entries[row, col])
                {
                    return true;
                }
            }
        }

        return false;
    }

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
        setIdentity();
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;

        Entries[0, 0] = MathF.Cos(rad);
        Entries[0, 1] = -MathF.Sin(rad);
        Entries[1, 0] = MathF.Sin(rad);
        Entries[1, 1] = MathF.Cos(rad);
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        Entries[0, 0] = scaleX;
        Entries[1, 1] = scaleY;

        // your code here
        setIdentity();
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