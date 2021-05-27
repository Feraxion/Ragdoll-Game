using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMesh : MonoBehaviour
{
    public float Intensity = 1f;
    public float mass = 1f;
    public float stifness = 1f;
    public float damping = 0.75f;
    private Mesh originalMesh;
    private Mesh meshClone;
    private MeshRenderer renderer;

    private JellyVertex[] jellyV;
    private Vector3[] vertexArray;
    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().sharedMesh;
        meshClone = Instantiate(originalMesh);
        GetComponent<MeshFilter>().sharedMesh = meshClone;
        renderer = GetComponent<MeshRenderer>();

        jellyV = new JellyVertex[meshClone.vertices.Length];
        for (int i = 0; i < meshClone.vertices.Length; i++)
        {
            jellyV[i] = new JellyVertex(i, transform.TransformPoint(meshClone.vertices[i]));
        }

    }

   
    void FixedUpdate()
    {
        vertexArray = originalMesh.vertices;
        for (int i = 0; i < jellyV.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jellyV[i].ID]);
            float intensity = (1 - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * Intensity;
            jellyV[i].Shake(target, mass, stifness, damping);
            target = transform.InverseTransformPoint(jellyV[i].Position);
            vertexArray[jellyV[i].ID] = Vector3.Lerp(vertexArray[jellyV[i].ID], target, intensity);
        }
        meshClone.vertices = vertexArray;
    }
}
