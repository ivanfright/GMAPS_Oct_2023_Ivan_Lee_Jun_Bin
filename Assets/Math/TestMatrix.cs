using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    void Start()
    {
        Qn2();
        mat.setIdentity();
        mat.Print();
    }

    public void Qn2()
    {
        // Declare three 3x3 matrices
        HMatrix2D mat1 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
        HMatrix2D mat2 = new HMatrix2D(9, 8, 7, 6, 5, 4, 3, 2, 1);

        // Declare a 3x1 vector
        HVector2D vec1 = new HVector2D(1, 2);

        // Declare a result matrix for multiplication
        HMatrix2D resultMat;

        // Test 1: Multiply two 3x3 matrices
        resultMat = mat1 * mat2;

        // Display the result using Print
        Debug.Log("Result of mat1 * mat2:");
        resultMat.Print();

        // Test 2: Multiply a 3x3 matrix with a 3x1 vector
        HVector2D resultVec = mat1 * vec1;

        // Display the result using a different method
        Debug.Log("Result of mat1 * vec1:");
        print(resultVec.x + ", " + resultVec.y);
    }
}
