using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathOperationController : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public Transform _vectorsTransform;
    public Transform nums;
    public TextMeshProUGUI vectorText;

    public TextMeshProUGUI vectorText1;
    public TextMeshProUGUI vectorText2;
    public TextMeshProUGUI angleText;


    public GameObject AnglePlane;
    public GameObject MathCanvas;


    private VectorController _vectorController;
    private VectorController[] vectorControllers;


    private GradientColorKey[] previosColorKey;
    private GradientAlphaKey[] previosAlphaKey;
    private int changeCount = 0;

    private VectorController _previosVectorController;

    private Vector3 firstArgument;
    private Vector3 secondArgument;

    private int vectorPosition = 0;

    public int count = 0;

    [SerializeField] private float sizeController = 1.5f;


    void Start()
    {

    }

    #region GetAngleBetweenVectors

    float mGetAngle(Vector3 p1, Vector3 p2)
    {
        return Mathf.Acos(dot_product(p1, p2) / scale_factor(p1, p2)) * Mathf.Rad2Deg;
    }

    private float dot_product(Vector3 v1, Vector3 v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    private float scale_factor(Vector3 v1, Vector3 v2)
    {
        var temp1 = Mathf.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z);
        var temp2 = Mathf.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
        return temp1 * temp2;
    }

    #endregion


    private void Update()
    {
        //        if (Input.GetKeyDown(KeyCode.K))
        //        {
        //            Debug.Log(mGetAngle(firstArgument, secondArgument));
        //            Debug.Log(firstArgument + "firstArg" + secondArgument + "secondArg");
        //            firstArgument = Vector3.zero;
        //            secondArgument = Vector3.zero;
        //        }
        //
        //        if (Input.GetKeyDown(KeyCode.H))
        //        {
        //            MakeSmaller();
        //        }

        //        if (Input.GetKeyDown(KeyCode.K))
        //        {
        //            if (MathCanvas.activeInHierarchy)
        //            {
        //                MathCanvas.SetActive(false);
        //            }
        //            else
        //            {
        //                MathCanvas.SetActive(true);
        //            }
        //        }
    }

    public void GetArgument()
    {
        Debug.Log("clicked");
        if (firstArgument == Vector3.zero)
        {
            firstArgument = vectorControllers[vectorPosition].LineRenderer.GetPosition(1);
            vectorText1.text = firstArgument.ToString();
        }
        else if ((firstArgument != Vector3.zero) && secondArgument == Vector3.zero)
        {
            secondArgument = vectorControllers[vectorPosition].LineRenderer.GetPosition(1);
            vectorText2.text = secondArgument.ToString();
        }
        else if ((firstArgument != Vector3.zero) && (secondArgument != Vector3.zero))
        {
            angleText.text = mGetAngle(firstArgument, secondArgument).ToString();
            firstArgument = Vector3.zero;
            secondArgument = Vector3.zero;
        }
    }

    public void MakeSmaller()
    {
        VectorController[] m_vectorControllers = GameObject.FindObjectsOfType<VectorController>();
        count -= 1;
        foreach (var m_vectorController in m_vectorControllers)
        {
            var temp = m_vectorController.LineRenderer.GetPosition(1);
            temp = temp / sizeController;
            m_vectorController.LineRenderer.SetPosition(1, temp);
        }
        nums.localScale /= sizeController;
    }

    public void MakeBigger()
    {
        VectorController[] m_vectorControllers = GameObject.FindObjectsOfType<VectorController>();
        count += 1;
        foreach (var m_vectorController in m_vectorControllers)
        {
            var temp = m_vectorController.LineRenderer.GetPosition(1);;
            temp = temp * sizeController;
            m_vectorController.LineRenderer.SetPosition(1, temp);
        }
        nums.localScale *= sizeController;
    }

    public void MoveRight()
    {
        if (vectorPosition + 1 <= vectorControllers.Length - 1)
        {
            vectorPosition++;
            SelectVector(vectorControllers[vectorPosition]);
        }
    }
    public void MoveLeft()
    {
        if (vectorPosition - 1 >= 0)
        {
            vectorPosition--;
            SelectVector(vectorControllers[vectorPosition]);
        }
    }

    public void CheckSize(VectorController changingVectorController)
    {
        if (count > 0)
        {
            var temp = changingVectorController.LineRenderer.GetPosition(1);
            for(int i = 0; i<Mathf.Abs(count); i++)
            {
                temp *= sizeController;
            }
            changingVectorController.LineRenderer.SetPosition(1, temp);
        }
        else if (count < 0)
        {
            var temp = changingVectorController.LineRenderer.GetPosition(1);
            for (int i = 0; i < Mathf.Abs(count); i++)
            {
                temp /= sizeController;
            }
            changingVectorController.LineRenderer.SetPosition(1, temp);
        }
        else if (count == 0) {
            Debug.Log("not must to resize");
        }
        Debug.Log(count + " COUNT");
    }

    void SelectVector(VectorController v)
    {
        Debug.Log(v.LineRenderer.GetPosition(1));


        #region GetCurrentGradient

        previosColorKey = new GradientColorKey[2];

        previosColorKey[0].color = v.LineRenderer.startColor;
        previosColorKey[0].time = 0.0f;
        previosColorKey[1].color = v.LineRenderer.endColor;
        previosColorKey[1].time = 1.0f;

        //alpha gradient
        previosAlphaKey = new GradientAlphaKey[2];
        previosAlphaKey[0].alpha = 1.0f;
        previosAlphaKey[0].time = 0.0f;
        previosAlphaKey[1].alpha = 1.0f;
        previosAlphaKey[1].time = 1.0f;

        #endregion

        #region NewGradient

        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.black;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.black;
        colorKey[1].time = 1.0f;

        //gradient alpha
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        Gradient _gradient = new Gradient();

        _gradient.SetKeys(colorKey, alphaKey);

        v.LineRenderer.colorGradient = _gradient;

        #endregion

        #region SetGradient

        if (changeCount > 0)
        {
            Gradient _mGradient = new Gradient();
            _mGradient.SetKeys(previosColorKey, previosAlphaKey);

            _previosVectorController.LineRenderer.colorGradient = _mGradient;
        }

        #endregion

        changeCount += 1;
        _previosVectorController = v;
    }

    public void EnDisableAnglePlane()
    {
        Debug.Log("endisable");
        if (AnglePlane.activeInHierarchy)
        {
            AnglePlane.SetActive(false);
            Debug.Log("FALSE");
        }

        else if (!AnglePlane.activeInHierarchy)
        {
            Debug.Log("True");
            AnglePlane.SetActive(true);
        }
    }

    public void PopulateList()
    {
        vectorControllers = _vectorsTransform.GetComponentsInChildren<VectorController>();
        Debug.Log(vectorControllers.Length);
        foreach (var i in vectorControllers)
        {
            vectorText.text += i.LineRenderer.GetPosition(1) + "\n";
        }
    }
}