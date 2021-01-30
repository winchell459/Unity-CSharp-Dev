using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    public InputField txtA, txtB;
    public Text lblOutput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommitButton()
    {
        try
        {
            int a = int.Parse(txtA.text);
            int b = int.Parse(txtB.text);
            lblOutput.text = (a + b).ToString();
        }
        catch (System.FormatException)
        {
            print("parse error");
        }
        
    }

}
