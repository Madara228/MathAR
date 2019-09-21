using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject _line;
    public CanvasController _canvasController;
    public GameObject _parentImage;
    private Camera cam;
    private float _width, _height;

    private void Start()
    {
        cam = Camera.main;
        _width = cam.pixelWidth / 2;
        _height = cam.pixelHeight / 2;
        CreateVectorStarter(new Vector3(0,0,0), new Vector3(7,0,0));
        CreateVectorStarter(new Vector3(0, 0, 0), new Vector3(0, 7, 0));
        CreateVectorStarter(new Vector3(0, 0, 0), new Vector3(0, 0, 7));
        _canvasController.gameObject.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CreateVector(Vector3.zero,Vector3.zero);
        }
    }

    public void CreateVectorStarter(Vector3 point1, Vector3 point2)
    {
        var temp = Instantiate(_line, Vector3.zero, Quaternion.identity);
    
        _canvasController.SendMessage("GetTemp",temp);
        _canvasController.SendMessage("GetFirstArgument", point1);
        _canvasController.SendMessage("GetSecondArg", point2);
        _canvasController.SendMessage("CreateVectors");
    }
    public void CreateVector(Vector3 point1, Vector3 point2)
    {
        var temp = Instantiate(_line, Vector3.zero, Quaternion.identity);
        //temp.transform.parent = _parentImage.transform;
        _canvasController.gameObject.SetActive(true);
        _canvasController.SendMessage("GetTemp", temp);
        _canvasController.SendMessage("GetFirstArgument", point1);
        _canvasController.SendMessage("GetSecondArg", point2);
        _canvasController.SendMessage("CreateVectors");
    }
    public void CreateLine()
    {
        CreateVector(Vector3.zero, Vector3.zero);
    }
}
