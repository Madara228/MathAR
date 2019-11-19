using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriggerController : MonoBehaviour
{
    public TextMeshProUGUI currentTextMesh;
    public GameObject m_canvas;
    public void OnInput(TextMeshProUGUI thistextMesh)
    {
        currentTextMesh = thistextMesh;
        m_canvas.SetActive(true);
    }

    public void GetMeshText(string c)
    {
        currentTextMesh.text += c;
    }

    public void RemoveCharFromString()
    {
        string s = currentTextMesh.text;
        s = s.Remove(s.Length - 1);
        currentTextMesh.text = s;
    }
    public void DisableCanvas()
    {
        m_canvas.SetActive(false);
    }
}