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
    public Sprite burntCookie;
    public float healPower = 0.0f;
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
                TurnToBurnt();
            }
            else if (cookTimer >= bakeTime)
            {
                Debug.Log("Baked");
                isBaked = true;
            }
        }
    }

    public void TurnToBurnt()
    {
        sr.sprite = burntCookie;
        hlth.health = 30.0f;
        mvmnt.MoveSpeed = 0.0f;
        attackDamage = 0.0f;
        cookieChip = null;
        attackDelay = 0.0f;
    }

    public void FixFlip()
    {
        //Debug.Log("fix flip" + Input.mousePosition.x);
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
        if (isBaked && currTile != null && currTile.tileType.Equals("Tile") && cookieChip != null && cookieChip.GetComponent<CookieChip>())
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

        /*
        if (attackDamage != 0.0f)
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
        */

        if(healPower != 0.0f)
        {
            if (attackTimer == 0.0f)
            {
                //Instantiate(cookieChip, gameObject.transform);
                GameObject[] cookies = GameObject.FindGameObjectsWithTag("Cookie");

                foreach(GameObject g in cookies)
                {
                    Vector3 diff = g.transform.position - transform.position;
                    float curDist = diff.sqrMagnitude;
                    if(curDist < 5.6f*5.6f)
                    {
                        g.GetComponent<Health>().AddHealth(healPower);
                    }
                }
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
