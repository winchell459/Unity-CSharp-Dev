using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text Display;
    [SerializeField] private int lastNum;
    [SerializeField]  private string oper = "";
    [SerializeField]  private bool operationEntered;
    //private bool nextNumberAdded;
    
    public void NumberButton(int num)
    {
        if (operationEntered)
        {
            Display.text = num.ToString();
            operationEntered = false;
        }
        else 
        {

            addToDisplay(num);
        }
    }

    public void EnterButton()
    {
        if (oper != "") calculate();
    }

    public void OperationButton(string oper)
    {
        if (!operationEntered)
        {
            lastNum = int.Parse(Display.text);

        }
        
        this.oper = oper;
        operationEntered = true;

    }

    private void addToDisplay(int num)
    {
        if(Display.text== "0") //Display.text.Equals("0")
        {
            Display.text = num.ToString();
        }
        else
        {
            Display.text = Display.text + num.ToString();
        }
    }

    private void calculate()
    {
        if (oper == "/")
        {
            lastNum /= int.Parse(Display.text);

        }
        else if (oper == "x")
        {
            lastNum *= int.Parse(Display.text);
        }
        else if (oper == "+")
        {
            lastNum += int.Parse(Display.text);
        }
        else if (oper == "-")
        {
            lastNum -= int.Parse(Display.text);
        }
        else
        {
            return;
        }
        Display.text = lastNum.ToString();
        operationEntered = false;
    }
}
