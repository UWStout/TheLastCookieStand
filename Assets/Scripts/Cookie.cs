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
    //time to bake
    public float bakeTime = 12f;
    //time to burn
    public float burntTime = 24f;
    //timer
    public float cookTimer = 0f;
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    //projectile
    public GameObject cookieChip;
    //attack values
    public float attackDamage;
    float attackTimer = 0.0f;
    public float attackDelay;
    //baked cookie spite
    public Sprite bakedCookie;
    //healing value for sugar
    public float healPower = 0.0f;
    public float healRange = 5.6f;
    //health of burnt cookie
    public float burntHealth = 30;
    //backward shot
    public bool doubleShot = false;
    //healing particle
    public ParticleSystem ps;
    //cookies for healing particle
    List<GameObject> hCookie = new List<GameObject>();
    //can explode?
    public bool explosive;
    public Animator anim;
    public GameObject  UI;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        //freeze, setup, set to uncooked
        rb2d.freezeRotation = true;
        mvmnt.StartMoving();
        burntTime+=bakeTime;
        transform.gameObject.tag = "UncookedCookie";
        ps = GetComponent<ParticleSystem>();
        ps.Pause();
    }

    private void FixedUpdate()
    {
        if(currTile != null && cookTimer < burntTime && currTile.tileType.Equals("Oven"))
        {
            //increase cook timer
            cookTimer += 1f * Time.deltaTime;
            if(cookTimer >= burntTime)
            {
                //cookie is burnt
                isBurnt = true;
                TurnToBurnt();
            }
            else if (cookTimer >= bakeTime)
            {
                //cokie is baked
                isBaked = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //explode condition
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
        Destroy(gameObject);
    }

    //cookie becomes burnt
    public void TurnToBurnt()
    { 
        //set animation and values
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

    //flips cookie based on what side its on
    public void FixFlip()
    {
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
                //shoot back chip
                if (doubleShot)
                {
                    GameObject backChip = Instantiate(cookieChip, gameObject.transform);
                    backChip.GetComponent<CookieChip>().reverse=-1;
                }
                //shoot back chip
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
                    g.GetComponent<Cookie>().ps.Clear();
                    g.GetComponent<Cookie>().ps.Pause();
                    if (curDist < healRange)
                    {
                        hCookie.Add(g);
                        //g.GetComponent<Cookie>().ps.Stop(false);
                        g.GetComponent<Cookie>().ps.Play();
                        g.GetComponent<Health>().AddHealth(healPower);
                        //g.GetComponent<Cookie>().ps.Pause();
                        //g.GetComponent<ParticleSystem>().Star

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

    private void OnDestroy()
    {
        foreach (GameObject g in hCookie)
        {
            g.GetComponent<Cookie>().ps.Clear();
            g.GetComponent<Cookie>().ps.Pause();
        }
    }

}
