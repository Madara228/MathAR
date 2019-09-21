using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorController : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public Vector3 startPoint;
    public Vector3 endPoint;

    public LineRenderer LineRenderer { get => _lineRenderer; set => _lineRenderer = value; }

    //MeshCollider meshCollider;
    void Start()
    {
        //meshCollider = GetComponentInChildren<MeshCollider>();
        LineRenderer = GetComponentInChildren<LineRenderer>();
        Debug.Log(LineRenderer + "_linerenderer");
        Debug.Log(Time.time + "start");
    }
    
    void Update()
    {

    }
    private void SetPosions()
    {
        LineRenderer.SetPosition(0, startPoint);
        LineRenderer.SetPosition(1, endPoint);
    }

    void CheckColor()
    {
        Debug.Log("checkColor");
        if(endPoint.x>endPoint.y && endPoint.x > endPoint.z)
        {
            Debug.Log("color green");
            GradientColorKey[] colorKey;
            GradientAlphaKey[] alphaKey;

            colorKey = new GradientColorKey[2];
            colorKey[0].color = Color.green;
            colorKey[0].time = 0.0f;
            colorKey[1].color = Color.green;
            colorKey[1].time = 1.0f;

            //gradient alpha
            alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 1.0f;
            alphaKey[1].time = 1.0f;

            Gradient _gradient = new Gradient();

            _gradient.SetKeys(colorKey, alphaKey);

            LineRenderer.colorGradient = _gradient;
        }
    }
}
