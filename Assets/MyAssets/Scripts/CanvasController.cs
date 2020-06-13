using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasController : MonoBehaviour
{
    public VectorController _vectorController;
    //public TMP_InputField input1, input2;
    public TextMeshProUGUI input1, input2;
    private TextMesh _text3D;
    private Vector3 tempStartPoint, tempEndPoint;

    public Transform _vectorsTransform;
    public GameController _gameController;
    public MathOperationController _MathOperationController;
    public LineRenderer lastLine;
    public Vector3 stVec;
    private void Start()
    {
        //CollapseVectors(new Vector3(0, 0, 0));
        //stVec = new Vector3(0, 0, 0);
        //TODO : delete stVec
    }

    public void CollapseVectors(Vector3 startVector)
    { 
        voidCreateVectors(startVector, startVector + new Vector3(6, 0, 0));
        voidCreateVectors(startVector, startVector + new Vector3(0, 6, 0));
        voidCreateVectors(startVector, startVector + new Vector3(0, 0, 6));
        voidCreateVectors(startVector, startVector + new Vector3(-6, 0, 0));
        voidCreateVectors(startVector, startVector + new Vector3(0, -6, 0));
        voidCreateVectors(startVector, startVector + new Vector3(0, 0, -6));
        //Debug.Log("collapsed");
        stVec = startVector;
    }
    public void voidCreateVectors(Vector3 point1, Vector3 point2)
    {
        var temp = Instantiate(_gameController._line, Vector3.zero, Quaternion.identity);
        temp.transform.parent = _vectorsTransform;
        _vectorController = temp.GetComponent<VectorController>();
        tempStartPoint = point1;
        tempEndPoint = point2;
        CreateVectors();
    }

    public void OnSumbit()
    {
        string[] temp1 = input1.text.Split(';');
        string[] temp2 = input2.text.Split(';');
        _vectorController.LineRenderer.SetPosition(0,stVec + new Vector3(float.Parse(temp1[0]),
                                                                  float.Parse(temp1[1]),
                                                                  float.Parse(temp1[2])));
        _vectorController.LineRenderer.SetPosition(1, stVec + new Vector3(float.Parse(temp2[0]),
                                                                  float.Parse(temp2[1]),
                                                                  float.Parse(temp2[2])));
        _MathOperationController.CheckSize(_vectorController);
    }

    public void Attempt()
    {
        _vectorController.SendMessage("CheckColor");
        var _canvasController = GameObject.Find("Canvas");
        _gameController.edDis(false);
        //_canvasController.SetActive(false);
    }
    public void EnableCanvas()
    {
        _gameController.GameCreateVectors();
    }
    public void OnNot()
    {
        Destroy(_vectorController.gameObject);
        gameObject.SetActive(false);
    }
    
    void CreateVectors()
    {
        Creating(tempStartPoint, tempEndPoint);
    }
    void Creating(Vector3 starVector, Vector3 endVector)
    {
        _vectorController.LineRenderer = _vectorController.GetComponentInChildren<LineRenderer>();
        _vectorController.LineRenderer.SetPosition(0, starVector);
        _vectorController.LineRenderer.SetPosition(1, endVector);
        _vectorController.CheckColor();
    }
}
