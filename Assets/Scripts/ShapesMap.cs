using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesMap : MonoBehaviour
{
    public Shapes Shapes;
    public int xOffset;
    public int yOffset;

    public Transform Player;
    private bool settingUp = true;

    public int DrawDistance = 6;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!settingUp && Player.position.x > (xOffset - DrawDistance) *(1+Shapes.pixelSpacing)) buildChoice();
        else if(settingUp)
        {
            line(6);

            settingUp = false;
        }
    }

    int lastChoice = 4;

    private void buildChoice()
    {
        int choice = Random.Range(0, 4);
        int length = 1;
        int height = 0;
        bool decending = false;
        switch (choice)
        {
            case 0:
                length = Random.Range(3, 7);
                line(length);
                print("line");
                lastChoice = choice;
                break;
            case 1:
                length = Random.Range(3, 7);
                height = length;
                decending = Random.Range(0, 2) == 0 ? false : true;
                stairs(length, decending);
                print("stair");
                lastChoice = choice;
                break;
            case 2:
                //gap
                if(lastChoice != 2)
                {
                    length = Random.Range(1, 5);
                    xOffset += length;
                    print("gap");
                    lastChoice = choice;
                }
                
                break;
            case 3:
                height = 2;
                wall(height);
                print("wall");
                lastChoice = choice;
                break;
            default:
                print("missing case");
                break;
                
        }

        
    }

    private void line(int length)
    {
        Shapes.Line(length, xOffset, yOffset);
        xOffset += length;
    }
    private void stairs(int length, bool decending)
    {
        Shapes.Stairs(length, decending, xOffset, yOffset);
        yOffset += decending ? -length + 1 : length -1;
        xOffset += length;
    }
    private void wall(int height)
    {
        Shapes.Wall(height, xOffset, yOffset);
        xOffset += 1;
        yOffset += height - 1;
    }
}
