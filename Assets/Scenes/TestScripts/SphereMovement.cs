using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer m_line;
    void Start()
    {
        m_line = GetComponent<LineRenderer>();
        int k = 0;
        for (float i = -5; i < 6; i++)
        {
            float y = Mathf.Sin(i);
            m_line.SetPosition(k,new Vector3(i,y,0f));
            k+=1;
            Debug.Log(k);
        }   
    }
    
    
}
