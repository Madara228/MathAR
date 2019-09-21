using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathOperationController : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    void Start()
    {
        Debug.Log(GetAngles(pos1, pos2) + "pos ");   
    }
    float GetAngles(Vector3 p1, Vector3 p2) {
        return Vector3.Angle(p1, p2);
    }
}
