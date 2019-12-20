using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using TMPro;
public class FigureController : MonoBehaviour
{
    public TMP_Dropdown _Dropdown;
    public Transform im_transform;
    public MathOperationController mathController;
    #region PrefabFigures
    public GameObject cube;
    public GameObject sphere;
    public GameObject Cylinder;
    #endregion

    //public TMP_InputField _InputField;
    public TextMeshProUGUI _InputField;
    private void Start()
    {
    }
    public void OnChangeValue()
    {
        Debug.Log(_Dropdown.options[_Dropdown.value].text);

        if (_Dropdown.options[_Dropdown.value].text == "Cube")
        {
            var c = Instantiate(cube, figurePosition(_InputField.text), Quaternion.identity);
            c.transform.localScale = figurePosition("1;1;1");
            c.transform.parent = im_transform;
        }
        else if (_Dropdown.options[_Dropdown.value].text == "Sphere")
        {
            var c = Instantiate(sphere, figurePosition(_InputField.text), Quaternion.identity);
            c.transform.localScale = figurePosition("1;1;1");
            c.transform.parent = im_transform;
        }
        else if (_Dropdown.options[_Dropdown.value].text == "Cylinder")
        {
            var c =Instantiate(Cylinder, figurePosition(_InputField.text), Quaternion.identity);
            c.transform.localScale = figurePosition("1;1;1");
            c.transform.parent = im_transform;


        }

        Vector3 figurePosition(string input_text)
        {
            string[] temp_string = input_text.Split(';');
            Vector3 temp = new Vector3(float.Parse(temp_string[0]),
                float.Parse(temp_string[1]),
                float.Parse(temp_string[2]));
            if (mathController.count > 0)
            {
                for(int i =0; i<Mathf.Abs(mathController.count); i++)
                {
                    temp *= 1.5f;
                }
            }
            else if (mathController.count < 0)
            {
                for (int i = 0; i < Mathf.Abs(mathController.count); i++)
                {
                    temp /= 1.5f;
                }
            }

            return temp;
        }
    }
}
