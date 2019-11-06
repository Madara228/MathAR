using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureDemonstrationBehaivor : MonoBehaviour
{
    [SerializeField] private Animator _manimator;
    private bool isReverse;
    private void Start()
    {
        _manimator = GetComponent<Animator>();

        //_manimator.SetFloat("Multiplier", -1f);
    }
    public void ChangeAnimationValue()
    {
        if (isReverse)
        {
            isReverse = false;
            _manimator.SetBool("reverse", isReverse);
        }
        else
        {
            isReverse = true;
            _manimator.SetBool("reverse", isReverse);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeAnimationValue();
        }
    }

}
