using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class ProBuilderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> points = new List<Vector3>();
    public Material mat;


    public void CreateMeshes(List<Vector3> poss)
    {
        var filter = GetComponent<MeshFilter>();

        // Add a new uninitialized pb_Object
        var mesh = gameObject.AddComponent<ProBuilderMesh>();

        var pb = ProBuilderMesh.Create();

        pb.CreateShapeFromPolygon(poss, 0f, false);
        MeshRenderer meshRenderer = pb.GetComponent<MeshRenderer>();
        meshRenderer.material = mat;
    }
}
