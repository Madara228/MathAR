using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSpawner : MonoBehaviour
{
    public Material material;
    public int vertCount = 0;
    public int triangles_count = 0;
    public Vector3[] posf;
    void Start()
    {
        //Vector3[] vertices = new Vector3[3];
        //Vector2[] uv = new Vector2[4];
        //int[] triangles = new int[3];


        //vertices[0] = new Vector3(0, 0, 0);
        //vertices[1] = new Vector3(0.5f, 1,1);
        //vertices[2] = new Vector3(1, 0, 0);


        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        //Mesh mesh = new Mesh();
        //mesh.vertices = vertices;
        //mesh.uv = uv;
        //mesh.triangles = triangles;
        //GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        //gameObject.GetComponent<MeshFilter>().mesh = mesh;
        //gameObject.GetComponent<MeshRenderer>().material = material;
        CreatePlane(vertCount,4,triangles_count, posf);
    }

    void Update()
    {
        
    }
    void CreatePlane(int v, int u, int t, Vector3[] m_post)
    {


        Vector3[] vertices = new Vector3[v];
        Vector2[] uv = new Vector2[u];
        int[] triangles = new int[t];


        //vertices[0] = new Vector3(0, 0, 0);
        //vertices[1] = new Vector3(0.5f, 1, 0);
        //vertices[2] = new Vector3(1, 0, 0);

        for(int i = 0; i< v; i++)
        {
            vertices[i] = m_post[i];
        }



        for(int i = 0; i<t; i++)
        {
            triangles[i] = i;
        }

        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        


        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.triangles = triangles;
        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    void SetPose(Vector3 _position)
    {
        
    }

    void GetLeftPosition(Vector3[] vectors)
    {
        var debug_vector = new Vector3();

    }
}
