using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyBoardScripts : MonoBehaviour
{
    private string m_text;
    public TriggerController triggerController;
    private int num;
    private void Start()
    {
        m_text = GetComponentInChildren<TextMeshProUGUI>().text;
    }
    public void DebugText()
    {
        triggerController.SendMessage("GetMeshText", m_text);
    }
    public void RemoveChar()
    {
        triggerController.SendMessage("RemoveCharFromString");
    }
    public void DisabeCanvas()
    {
        triggerController.SendMessage("DisableCanvas");
    }
}
