using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrollerScript : MonoBehaviour
{
    public Animator anim;
    public void ChangeState()
    {
        Debug.Log("anim");
        Debug.Log(anim.GetBool("Trigger"));
        if (anim.GetBool("Trigger"))
        {
            anim.SetBool("Trigger", false);
        }
        else if (!anim.GetBool("Trigger"))
        {
            anim.SetBool("Trigger", true);
        }
    }
}
