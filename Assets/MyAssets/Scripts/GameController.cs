using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject _line;
    public CanvasController _canvasController;
    public GameObject _parentImage;
    public GameObject[] endisgameObjects;
    private Camera cam;
    private float _width, _height;
    public LineMover _lineMover;
    private void Start()
    {
        //cam = Camera.main;
        //_width = cam.pixelWidth / 2;
        //_height = cam.pixelHeight / 2;
        
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
        edDis(true);
    }
    public void CreateForDimens()
    {
        
        _lineMover = GameObject.FindObjectOfType<LineMover>();
        //_lineMover.CreateLine();
        Debug.Log(_lineMover + "_LINE MOVER");
        Debug.Log("Dimension");
        _canvasController.voidCreateVectors(Vector3.zero, Vector3.zero);
    }
    public void edDis(bool t)
    {
        foreach (GameObject g in endisgameObjects)
        {
            g.SetActive(t);
        }
    }

}
