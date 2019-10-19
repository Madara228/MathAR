using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using TMPro;
public class FigureController : MonoBehaviour
{
    public TMP_Dropdown _Dropdown;

    #region PrefabFigures
    public GameObject cube;
    public GameObject sphere;
    public GameObject Cylinder;
    #endregion

    public TMP_InputField _InputField;
    private void Start()
    {
    }
    public void OnChangeValue()
    {
        Debug.Log(_Dropdown.options[_Dropdown.value].text);

        if (_Dropdown.options[_Dropdown.value].text == "Cube")
        {
            Instantiate(cube, figurePosition(_InputField.text), Quaternion.identity);
        }
        else if (_Dropdown.options[_Dropdown.value].text == "Sphere")
        {
            Instantiate(sphere, figurePosition(_InputField.text), Quaternion.identity);
        }
        else if (_Dropdown.options[_Dropdown.value].text == "Cylinder")
        {
            Instantiate(Cylinder, figurePosition(_InputField.text), Quaternion.identity);
        }

        Vector3 figurePosition(string input_text)
        {
            string[] temp_string = input_text.Split(';');
            return new Vector3(float.Parse(temp_string[0]),
                float.Parse(temp_string[1]),
                float.Parse(temp_string[2]));
        }
//        if (_Dropdown.itemText.
//        {
//            Debug.Log("ValueChanged!",this.gameObject);
//        }
    }
}
