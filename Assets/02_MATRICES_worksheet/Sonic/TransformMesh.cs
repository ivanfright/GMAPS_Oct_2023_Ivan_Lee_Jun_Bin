
//using Mono.Cecil.cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformmesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    private HMatrix2D toOriginMatrix = new HMatrix2D();
    private HMatrix2D fromOriginMatrix = new HMatrix2D();
    private HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    private HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        // Your code here
    }


    void translate(float x, float y)
    {
        // your code here
    }

    void rotate(float angle)
    {
        transformMatrix.setIdentity();

        // your code here

        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        transform();
    }

    private void transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // your code here
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
