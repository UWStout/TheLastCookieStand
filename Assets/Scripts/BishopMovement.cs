using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Movement mvmt;
    public float maxH = .25f;
    public float minH = -4.3f;
    Vector2 up = new Vector2(0,.5f);
    bool upB = false;
    bool doB = false;
    bool init = false;
    void Start()
    {

        mvmt=GetComponent<Movement>();

    }

    // Update is called once per frame
    void Update()
    {

        if (mvmt.StoredVel==null||mvmt.StoredVel.y==(0))
        {
            if (!init||mvmt.StoredVel.y==(0))
            {
                init=true;
                mvmt.SetMovement((mvmt.Dir + up)* mvmt.MoveSpeed);
                upB=true;
                doB=false;
                Debug.Log("Init:" + (mvmt.Dir + up)* mvmt.MoveSpeed);

            }





        }
        else
        {
            if (GetComponent<Rigidbody2D>().position.y<=minH&&!upB)
            {
                mvmt.SetMovement((mvmt.Dir + up)* mvmt.MoveSpeed);
                upB=true;
                doB=false;
                Debug.Log("Up:" + (mvmt.Dir + up)* mvmt.MoveSpeed);
            }
            else if (GetComponent<Rigidbody2D>().position.y>=maxH&&!doB)
            {
                mvmt.SetMovement((mvmt.Dir + up*-1)* mvmt.MoveSpeed);
                upB=false;
                doB=true;
                Debug.Log("Down:" + (mvmt.Dir + up*-1)* mvmt.MoveSpeed);
            }
        }
    }
}
