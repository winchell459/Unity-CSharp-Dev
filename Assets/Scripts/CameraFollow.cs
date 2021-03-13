using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public int VerticalOffset = 5;
    public int HorizontalOffset = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x + HorizontalOffset, Target.position.y + VerticalOffset, transform.position.z);
    }
}
