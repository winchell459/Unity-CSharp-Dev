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
            lastNum = int.Parse(getDisplayValue());

        }
        
        this.oper = oper;
        operationEntered = true;

    }

    private void addToDisplay(int num)
    {
        if(Display.text== "0") //Display.text.Equals("0")
        {
            //Display.text = num.ToString();
            setDisplayValue(num);
        }
        else
        {
            setDisplayValue(int.Parse(getDisplayValue()) * 10 + num);
        }
    }
    private string getDisplayValue()
    {
        string display = Display.text;
        string valueStr = display.Replace(",", "");
        return valueStr;
    }
    private void setDisplayValue(int num)
    {
        //Display.text = num.ToString();
        formateDisplay(num);
    }

    private void formateDisplay(int num)
    {
        string display = num.ToString();
        int length = display.Length;
        int index = length % 3;
        if (index == 0) index += 3;
        while(index < display.Length)
        {
            string ending = display.Substring(index);
            string begining = display.Substring(0, index); //123456789
            display = begining + "," + ending;
            index += 4;
        }
        Display.text = display;
    }

    private void calculate()
    {
        if (oper == "/")
        {
            lastNum /= int.Parse(getDisplayValue());

        }
        else if (oper == "x")
        {
            lastNum *= int.Parse(getDisplayValue());
        }
        else if (oper == "+")
        {
            lastNum += int.Parse(getDisplayValue());
        }
        else if (oper == "-")
        {
            lastNum -= int.Parse(getDisplayValue());
        }
        else
        {
            return;
        }
        //Display.text = lastNum.ToString();
        setDisplayValue(lastNum);
        operationEntered = false;
    }
}
