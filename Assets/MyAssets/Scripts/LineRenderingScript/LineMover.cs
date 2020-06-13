using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class LineMover : MonoBehaviour
{
    public GameController _gameController;
    public CanvasController _canvasController;
    public GameObject moveObj;
    public ProBuilderScript proBuilderScript;
    [SerializeField] private LineRenderer _line;
    //public TextMeshProUGUI zeroPos;
    //public TextMeshProUGUI lastPos;
    private Vector3 startPos;
    private Vector3 endPos;
    public TextMeshProUGUI textCoord;
    private Vector3 _pose;
    public List<Vector3> positions = new List<Vector3>();
    private int count = 0;
    private void Start()
    {
        proBuilderScript = GameObject.FindObjectOfType<ProBuilderScript>();
        moveObj = GameObject.Find("MoveObject");
    }
    public void GetComponents()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
        _canvasController = GameController.FindObjectOfType<CanvasController>();
    }
    public void CreateLine()
    {
        if(count % 2 == 0)
        {
            moveObj.SetActive(true);
            GetComponents();
            _gameController.CreateForDimens();
            //Debug.Log(_canvasController._vectorController.gameObject.name + "NAME");
            _line = _canvasController._vectorController.gameObject.GetComponentInChildren<LineRenderer>();
        }
        else
        {
            moveObj.SetActive(false);
        }
        count++;

        
        //Debug.Log(_line + "LINE");
    }

    
    public void MoveLine()
    {

    }
    private void Update()
    {
        if(_pose!= null)
        {
            //textCoord.text = (moveObj.transform.position).ToString();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            proBuilderScript = GameObject.FindObjectOfType<ProBuilderScript>();
            positions.Add(moveObj.transform.position);
            Debug.Log("Added!");
            Debug.Log(moveObj.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            proBuilderScript.CreateMeshes(positions);
            Debug.Log("KeyCode.G");
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, 0, vertical);
    }

    public void AddPosition()
    {
        positions.Add(moveObj.transform.position);
        Debug.Log("Added!");
        Debug.Log(moveObj.transform.position);
    }

    public void SetFigure()
    {
        proBuilderScript.CreateMeshes(positions);
        Debug.Log("KeyCode.G");
    }
    public void ButtonDown()
    {
        startPos = moveObj.transform.position;
        _line.SetPosition(1, startPos);
    }
    public void ButtonOnDown()
    {
        endPos = moveObj.transform.position;
        //_line.SetPosition(0, new Vector3(startPos.x, startPos.y, 0f));
        _line.SetPosition(0, new Vector3(endPos.x, endPos.y, endPos.z));
    }
}
