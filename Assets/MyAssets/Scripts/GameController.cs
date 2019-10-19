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
        
        _canvasController.gameObject.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameCreateVectors();
        }
    }

    public void GameCreateVectors()
    {
        _canvasController.voidCreateVectors(Vector3.zero, Vector3.zero);
        _canvasController.gameObject.SetActive(true);
    }

}
