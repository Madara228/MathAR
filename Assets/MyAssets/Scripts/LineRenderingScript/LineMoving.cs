using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMoving : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRend;
    private Vector2 mousePos;
    private Vector2 firstPos;
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,17));
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 17));
            lineRend.SetPosition(0, new Vector3(firstPos.x, firstPos.y, 0f));
            lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
        }
    }
}
