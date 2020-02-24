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
    //public RuntimeAnimatorController burntCookie;
    public Sprite bakedCookie;
    public float healPower = 0.0f;
    public float healRange = 5.6f;
    public float burntHealth = 30;
    public bool doubleShot = false;


    public bool explosive;
    public Animator anim;
    public GameObject  UI;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.freezeRotation = true;
        mvmnt.StartMoving();
        burntTime+=bakeTime;
        transform.gameObject.tag = "UncookedCookie";
    }

    private void FixedUpdate()
    {
        if(currTile != null && cookTimer < burntTime && currTile.tileType.Equals("Oven"))
        {
            cookTimer += 1f * Time.deltaTime;
            
            if(cookTimer >= burntTime)
            {
                //Debug.Log("Burnt");
                isBurnt = true;
                TurnToBurnt();
            }
            else if (cookTimer >= bakeTime)
            {
                //Debug.Log("Baked");
                isBaked = true;
                
                //sr.sprite = bakedCookie;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Dino")&&explosive&&isBaked && currTile != null && currTile.tileType.Equals("Tile")&&!isBurnt)
        {
            anim = GetComponent<Animator>();
            anim.SetBool("IsExploding",true);
            StartCoroutine(Explosive(collision.gameObject));
        }
    }

    IEnumerator Explosive(GameObject dino)
    {
        yield return new WaitForSeconds(.5f);
        dino.GetComponent<Health>().RemoveHealth(100000);
        //hlth.health=0;
        Destroy(gameObject);
    }

    public void TurnToBurnt()
    {
        //sr.sprite = burntCookie;
        gameObject.GetComponent<Animator>().Play("BurntCookie");
        hlth.health = burntHealth;
        hlth.maxHealth = burntHealth;
        mvmnt.MoveSpeed = 0.0f;
        attackDamage = 0.0f;
        cookieChip = null;
        attackDelay = 0.0f;
        healPower = 0.0f;
        if (explosive)
        {
            UI.SetActive(true);
        }
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
                if (doubleShot)
                {
                    GameObject backChip = Instantiate(cookieChip, gameObject.transform);
                    backChip.GetComponent<CookieChip>().reverse=-1;
                }

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
                    if(curDist < healRange)
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
