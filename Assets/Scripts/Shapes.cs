using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public GameObject PixelPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        //rectangle(7, 5);
        //triangleUpsideDownLeft(5);
        triangleUpsideDownLeft(4, 6, 1);
        triangleUpsideDownRight(5, 1, 0);
        triangleRight(6, 0, 5);
        triangleLeft(5, 6, 5);

        testing();
        string str = "";
        for (int i = 0; i < 5; i += 1)
        {
            
            for(int j = 0; j < 5; j += 1)
            {
                str += "*";
            }
            str += "\n";
        }

        print(str);

        str = "";
        //triangle left upsidedown
        for (int i = 0; i < 5; i += 1)
        {
            for (int j = i; j < 5; j += 1)
            {
                str += "*";
            }
            str += "\n";
        }

        print(str);

        str = "";
        //triangle left
        for (int i = 0; i < 5; i += 1)
        {
            for (int j = 5 - i; j <= 5; j += 1)
            {
                str += "*";
            }
            str += "\n";
        }

        print(str);

        str = "";
        //triangle right upsidedown
        for (int i = 0; i < 5; i += 1)
        {
            for (int j = 0; j < 5; j += 1)
            {
                if (j < i) str += "  ";
                else str += "*";
            }
            str += "\n";
        }

        print(str);

        str = "";
        //triangle right
        for (int i = 0; i < 5; i += 1)
        {
            for (int j = 0; j < 5; j += 1)
            {
                if (j < 4 - i) str += "  ";
                else str += "*";

            }
            str += "\n";
        }

        print(str);
    }

    private void rectangle(int width, int height)
    {
        for (int x = 0; x < width; x += 1)
        {
            for (int y = 0; y < height; y += 1)
            {
                createPixel(x * 1.1f, y * 1.1f);
            }
        }
    }

    private void triangleRight(int height)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = y; x < height; x += 1)
            {
                createPixel(x * 1.1f, y * 1.1f);
            }
        }
    }

    private void triangleUpsideDownRight(int height)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = height - y -1; x < height; x += 1)
            {
                createPixel(x * 1.1f, y * 1.1f);
            }
        }
    }

    private void triangleUpsideDownLeft(int height)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = 0; x <= y; x += 1)
            {
                createPixel(x * 1.1f, y * 1.1f);
            }
        }
    }

    private void triangleLeft(int height)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = 0; x < height - y; x += 1)
            {
                createPixel(x * 1.1f, y * 1.1f);
            }
        }
    }

    private void triangleRight(int height, int xOffset, int yOffset)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = y; x < height; x += 1)
            {
                createPixel((x + xOffset) * 1.1f , (y + yOffset) * 1.1f);
            }
        }
    }

    private void triangleUpsideDownRight(int height, int xOffset, int yOffset)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = height - y - 1; x < height; x += 1)
            {
                createPixel((x + xOffset) * 1.1f, (y + yOffset) * 1.1f);
            }
        }
    }

    private void triangleUpsideDownLeft(int height, int xOffset, int yOffset)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = 0; x <= y; x += 1)
            {
                createPixel((x + xOffset) * 1.1f, (y + yOffset) * 1.1f);
            }
        }
    }

    private void triangleLeft(int height, int xOffset, int yOffset)
    {
        for (int y = 0; y < height; y += 1)
        {
            for (int x = 0; x < height - y; x += 1)
            {
                createPixel((x + xOffset) * 1.1f, (y + yOffset) * 1.1f);
            }
        }
    }

    private void createPixel(float x, float y)
    {
        if(x == y) createPixel(x, y, Color.black);
        else createPixel(x, y, Color.white);
    }


    private void createPixel(float x, float y, Color color)
    {
        GameObject pixel = Instantiate(PixelPrefab, new Vector2(x, y), Quaternion.identity);
        pixel.GetComponent<SpriteRenderer>().color = color;
    }

    private void testing()
    {
        int count = 0;
        do
        {
            print(count);
            count += 1;
        } while (count < 5);
        //while(count < 5)
        //{
        //    print(count);
        //    count += 1;
        //}

        //for(int i = 0; i < 5; i += 1)
        //{
        //    print(i);
        //}


    }
}
