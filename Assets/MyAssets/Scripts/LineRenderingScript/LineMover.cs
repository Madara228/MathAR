using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LineMover : MonoBehaviour
{
    public GameController _gameController;
    public CanvasController _canvasController;
    public GameObject moveObj;
    [SerializeField] private LineRenderer _line;
    public TextMeshProUGUI zeroPos;
    public TextMeshProUGUI lastPos;
    private Vector3 startPos;
    private Vector3 endPos;
    
    public void CreateLine()
    {
        _gameController.CreateForDimens();
        Debug.Log(_canvasController._vectorController.gameObject.name + "NAME");
        _line = _canvasController._vectorController.gameObject.GetComponentInChildren<LineRenderer>();
        Debug.Log(_line + "LINE");
    }
    public void MoveLine()
    {
        //if (Input.touchCount == 1) 
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        startPos = moveObj.transform.position;
        //    }
        //    endPos = moveObj.transform.position;
        //    _line.SetPosition(0, startPos);
        //    _line.SetPosition(1, endPos);
        //}
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = moveObj.transform.position;
            zeroPos.text = startPos.x.ToString() + " " + startPos.y.ToString() + " "+ startPos.z.ToString();
        }
        if (Input.GetMouseButton(0))
        {
            endPos = moveObj.transform.position;
            _line.SetPosition(0, new Vector3(startPos.x, startPos.y, 0f));
            _line.SetPosition(1, new Vector3(endPos.x, endPos.y, 0f));
            lastPos.text = endPos.x.ToString() + " " + endPos.y.ToString() + " " + endPos.z.ToString();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(endPos + "ENDPOS");
        }
    }
}
