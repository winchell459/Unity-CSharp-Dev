using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringsPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Replace - replaces all instances of a string with another string
        //Split
        //Substring
        //IndexOf
        //Equals

        string input = "1,009,456";

        string output = "";
        output = input.Replace(",", "");
        print(output); //"1009456"

        string[] output2 = new string[2];
        output2 = input.Split(',');
        print(output2[1]); // "009"

        
        string output3 = "";
        output3 = output.Substring(3);
        print(output3); //"9456"

        int output4 = 0;
        string substring = "09";
        output4 = output.IndexOf(substring);
        print(output4); //2
    }

    
}
