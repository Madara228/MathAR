using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SwitcherController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator selfAnimator;
    public GameObject thObj;
    public TextMeshProUGUI textMesh;
    private void Start()
    {
        StartCoroutine(doStart());
    }

    private IEnumerator doStart()
    {
        yield return new WaitForSeconds(0.7f);
        textMesh = GetComponentInParent<TextMeshProUGUI>();
        thObj.SetActive(selfAnimator.GetBool("Enable"));
        Debug.Log(thObj);
        textMesh.text = thObj.gameObject.name;
    }
    public void ChangeState()
    {
        if (selfAnimator.GetBool("Enable"))
        {
            selfAnimator.SetBool("Enable", false);
            thObj.SetActive(false);
        }
        else
        {
            selfAnimator.SetBool("Enable", true);
            thObj.SetActive(true);
        }
    }
}
