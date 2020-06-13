using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubmeInstance : MonoBehaviour
{
    public GameObject _number;
    public Transform _NumberTransform;

    public void InstanceNums(Vector3 _stVector)
    {
        Debug.Log("nums");
        for (int i = -7; i < 7; i++)
        {
            var c = Instantiate(_number, new Vector3((float)i, 0, 0) + _stVector, Quaternion.identity);
            c.transform.parent = _NumberTransform;
            c.GetComponent<TextMesh>().text = i.ToString();
            c.GetComponent<TextMesh>().color = Color.red;
        }
        for (int i = -7; i < 7; i++)
        {
            var c = Instantiate(_number, new Vector3(0, (float)i, 0) + _stVector, Quaternion.identity);
            c.transform.parent = _NumberTransform;
            c.GetComponent<TextMesh>().text = i.ToString();
            c.GetComponent<TextMesh>().color = Color.green;
        }
        for (int i = -7; i < 7; i++)
        {
            var c = Instantiate(_number, new Vector3(0, 0, (float)i) + _stVector, Quaternion.identity);
            c.transform.parent = _NumberTransform;
            c.GetComponent<TextMesh>().text = i.ToString();
            c.GetComponent<TextMesh>().color = Color.blue;
        }
    }
}
