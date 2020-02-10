using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cookie : MonoBehaviour
{
    public Health hlth;
    public Movement mvmnt;
    public Tile currTile = null;
    public bool isBaked = false;
    public bool isBurnt = false;
    public float bakeTime = 12f;
    public float burntTime = 24f;
    public float cookTimer = 0f;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if(currTile != null && cookTimer < burntTime && currTile.tileType.Equals("Oven"))
        {
            cookTimer += 1f * Time.deltaTime;
            
            if(cookTimer >= burntTime)
            {
                Debug.Log("Burnt");
                isBurnt = true;
            }
            else if (cookTimer >= bakeTime)
            {
                Debug.Log("Baked");
                isBaked = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
