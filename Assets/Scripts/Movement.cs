using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 Dir = new Vector2(1,0);
    public float MoveSpeed;
    public bool moveOnStart = false;
    public Vector2 StoredVel;

    // Start is called before the first frame update
    void Start()
    {

        //This is kind of hacky
        if (moveOnStart)
        {
            StartMoving();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Maybe we should have the dino move up and down a little bit procedurally, like a walk cycle.
    }

    public void StartMoving()
    {

        if (StoredVel==new Vector2()){
            StoredVel = Dir * MoveSpeed;
        }
        GetComponent<Rigidbody2D>().velocity = StoredVel;
    }

    public void StopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2();
    }

    public void SetMovement(Vector2 vec)
    {
        StoredVel = vec;
        StartMoving();
    }
}
