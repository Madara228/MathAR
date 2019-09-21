using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasController : MonoBehaviour
{
    private VectorController _vectorController;
    public TMP_InputField vector_1_x, vector_1_y, vector_1_z;
    public TMP_InputField vector_2_x, vector_2_y, vector_2_z;
    private TextMesh _text3D;
    private Vector3 tempStartPoint, tempEndPoint;
    public GameController _gameController;
    public void GetTemp(GameObject temp)
    {
        _vectorController = temp.GetComponent<VectorController>();
    }
    public void GetFirstArgument(Vector3 sPoint)
    {
        tempStartPoint = sPoint;
    }
    public void GetSecondArg(Vector3 ePoint)
    {
        tempEndPoint = ePoint;
    }
    public void OnSumbit()
    {
        _vectorController.startPoint = new Vector3(float.Parse(vector_1_x.text), float.Parse(vector_1_y.text), float.Parse(vector_1_z.text));
        _vectorController.endPoint = new Vector3(float.Parse(vector_2_x.text), float.Parse(vector_2_y.text), float.Parse(vector_2_z.text));
    }

    public void Attempt()
    {
        _vectorController.SendMessage("CheckColor");
        var _canvasController = GameObject.Find("Canvas");
        _canvasController.SetActive(false);
        vector_1_x.text = ""; vector_1_y.text = ""; vector_1_z.text = "";
        vector_2_x.text = ""; vector_2_y.text = ""; vector_2_z.text = "";
    }

    public void OnNot()
    {
        Destroy(_vectorController.gameObject);
        gameObject.SetActive(false);
    }
    
    void CreateVectors()
    {
        Creating(tempStartPoint, tempEndPoint);
        Debug.Log(Time.time + "check");
    }
    void Creating(Vector3 starVector, Vector3 endVector)
    {
        _vectorController.LineRenderer = _vectorController.GetComponentInChildren<LineRenderer>();
        Debug.Log(_vectorController.LineRenderer.gameObject.name);
        Debug.Log(_vectorController.gameObject);
        _vectorController.LineRenderer.SetPosition(0, starVector);
        _vectorController.LineRenderer.SetPosition(1, endVector);
        //_vectorController.startPoint = starVector;
        //_vectorController.endPoint = endVector;
    }


}
