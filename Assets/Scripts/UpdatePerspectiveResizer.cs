using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePerspectiveResizer : MonoBehaviour
{
    float topHeight=1;
    float bottomHeight=-5f;
    float maxSize= 1.2f;
    float minSize=.8f;
    public float temp;
    public float temp2;
    public float ypos;
    public Vector3 startSize;
    // Start is called before the first frame update
    void Start()
    {


        startSize=transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ypos=transform.position.y;
        temp=1-((ypos-bottomHeight)/(topHeight-bottomHeight));
        temp2=minSize+((maxSize-minSize)*temp);
        transform.localScale=startSize*temp2;
    }
}
