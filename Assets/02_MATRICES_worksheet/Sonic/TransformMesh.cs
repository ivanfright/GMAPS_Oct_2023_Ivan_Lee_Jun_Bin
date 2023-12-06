
//using Mono.Cecil.cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformmesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    private HMatrix2D scaleMatrix = new HMatrix2D();
    private HMatrix2D toOriginMatrix = new HMatrix2D();
    private HMatrix2D fromOriginMatrix = new HMatrix2D();
    private HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    private HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1, 1);
        rotate(90);
        
    }


    void Translate(float x, float y)
    {
        transformMatrix.setIdentity();
        transformMatrix.setTranslationMat(x, y);
        transform();

        pos = transformMatrix * pos;
    }

    void rotate(float angle)
    {
        toOriginMatrix.setTranslationMat(- pos.x, - pos.y);
        fromOriginMatrix.setTranslationMat(pos.x, pos.y);

        rotateMatrix.setRotationMat(angle);

        transformMatrix.setIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        transform();
    }

    void scale(float x, float y)
    {
        scaleMatrix.setScalingMat(x, y);
        transform();
    }

    private void transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
