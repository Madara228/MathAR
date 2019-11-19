using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public void FigureScene()
    {
        SceneManager.LoadScene("FigureScene");
    }
    public void VectorScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
