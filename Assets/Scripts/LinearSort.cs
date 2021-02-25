using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinearSort : MonoBehaviour
{
    public Button[] Buttons;
    private int[] numbers;

    // Start is called before the first frame update
    void Start()
    {
        setupButtons();
    }

    private void setupButtons()
    {
        int count = Buttons.Length;
        numbers = new int[count];
        for(int i = 0; i < count; i += 1)
        {
            numbers[i] = i;
        }

        for(int i = 0; i < count*count; i++)
        {
            int index1 = Random.Range(0, count);
            int index2 = Random.Range(0, count);
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }

        for(int i = 0; i < count; i += 1)
        {
            Buttons[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
        }
    }

    private void swapNumbers(int index1, int index2)
    {
        int temp = numbers[index1];
        numbers[index1] = numbers[index2];
        numbers[index2] = temp;
    }

    private void setButtons()
    {
        for (int i = 0; i < Buttons.Length; i += 1)
        {
            Buttons[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
        }
    }

    public void NumberButton(int buttonIndex)
    {
        if(!checkSorted() && buttonIndex <= Buttons.Length - 2)
        {
            swapNumbers(buttonIndex, buttonIndex + 1);
            setButtons();
        }
    }

    private bool checkSorted()
    {
        bool sorted = true;
        for(int i = 0; i < numbers.Length-1; i += 1)
        {
            if (numbers[i] > numbers[i + 1]) sorted = false;
        }
        return sorted;
    }
}
