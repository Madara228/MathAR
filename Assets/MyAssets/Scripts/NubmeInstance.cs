using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubmeInstance : MonoBehaviour
{
    public GameObject _number;
    public Transform _NumberTransform;
    void Start()
    {
        for(int i = 1; i<7; i++)
        {
            var c = Instantiate(_number, new Vector3((float)i, 0, 0), Quaternion.identity);
            c.transform.parent = _NumberTransform;
            c.GetComponent<TextMesh>().text = i.ToString();
            c.GetComponent<TextMesh>().color = Color.red;
        }
        for (int i = 1; i < 7; i++)
        {
            var c = Instantiate(_number, new Vector3(0, (float)i, 0), Quaternion.identity);
            c.transform.parent = _NumberTransform;
            c.GetComponent<TextMesh>().text = i.ToString();
            c.GetComponent<TextMesh>().color = Color.green;
        }
        for (int i = 1; i < 7; i++)
        {
            var c = Instantiate(_number, new Vector3(0, 0, (float)i), Quaternion.identity);
            c.transform.parent = _NumberTransform;
            c.GetComponent<TextMesh>().text = i.ToString();
            c.GetComponent<TextMesh>().color = Color.blue;
        }
    }
}
