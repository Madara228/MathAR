using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureDemoController : MonoBehaviour
{
    public FigureDemonstrationBehaivor[] figures;
    [SerializeField] private FigureDemonstrationBehaivor current_figure;
    [SerializeField] private int current_num;
    void Start()
    {
        Debug.Log(figures.Length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PreviosFigure();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetElements();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            NextFigure();
        }
    }

    public void NextFigure()
    {
        if(current_num < figures.Length-1)
        {
            figures[current_num].gameObject.SetActive(false);
            current_num += 1;
            figures[current_num].gameObject.SetActive(true);
            current_figure = figures[current_num];
        }
    }
    public void PreviosFigure()
    {
        if (current_num > 0)
        {
            figures[current_num].gameObject.SetActive(false);
            current_num -= 1;
            figures[current_num].gameObject.SetActive(true);
            current_figure = figures[current_num];
        }
    }
    public void GetCurrentFigureNdReverse()
    {
        var behaiv = current_figure.GetComponent<FigureDemonstrationBehaivor>();
        behaiv.ChangeAnimationValue();
    }
    public void GetElements()
    {
        figures = GameObject.FindObjectsOfType<FigureDemonstrationBehaivor>();
        Debug.Log("figures!");
    }
}
