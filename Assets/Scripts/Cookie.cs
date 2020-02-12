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
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    public GameObject cookieChip;
    public float attackDamage;
    float attackTimer = 0.0f;
    public float attackDelay;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.freezeRotation = true;
        mvmnt.StartMoving();
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

    public void FixFlip()
    {
        Debug.Log("fix flip" + Input.mousePosition.x);
        if (gameObject.transform.position.x < 0)
        {
            mvmnt.Dir.x = -1;
            sr.flipX = true;

        }
        else
        {
            mvmnt.Dir.x = 1;
            sr.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isBaked && currTile != null && currTile.tileType.Equals("Tile") && cookieChip.GetComponent<CookieChip>())
        {
            if (attackTimer == 0.0f)
            {
                Instantiate(cookieChip, gameObject.transform);
                attackTimer += Time.deltaTime;
            }

            if (attackTimer >= attackDelay)
            {
                attackTimer = 0.0f;
            }
            else
            {
                attackTimer += Time.deltaTime;
            }
        }
    }
}
