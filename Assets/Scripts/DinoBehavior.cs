﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehavior : MonoBehaviour
{
    public Health hlth;
    public Movement mvmnt;
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    public float attackDamage;
    public float attackTimer = 0.0f;
    //public float attackDelay;
    public float armorWeakness = .5f;
    public GameObject whatImHitting;
    public bool isChicken = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.freezeRotation = true;
        if (gameObject.transform.position.x>0)
        {
            mvmnt.Dir.x = -1;
            
        }
        else
        {
            sr.flipX = true;
        }
        mvmnt.StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if(whatImHitting!=null&&((whatImHitting.tag!="Tower")||!isChicken))
        {
            hit(whatImHitting);
            mvmnt.StopMoving();
        }
        else
        {
            mvmnt.StartMoving();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Cookie")||collision.gameObject.tag.Equals("Tower"))
        {
            whatImHitting=collision.gameObject;
            //StartCoroutine(StopMoving());

        }
    }
    /*
    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(.05f);
        mvmnt.StopMoving();
    }*/

    private void hit(GameObject other)
    {

        if (other.tag.Equals("Cookie") && other.gameObject.GetComponent<Cookie>().isBurnt &&!isChicken)
        {
            other.gameObject.GetComponent<Health>().RemoveHealth(attackDamage*Time.deltaTime*armorWeakness);
            //Debug.Log("Burnt Hit: "+attackDamage*Time.deltaTime*armorWeakness);

        }
        else if (other.tag.Equals("Cookie"))
        {
            other.gameObject.GetComponent<Health>().RemoveHealth(attackDamage*Time.deltaTime);

        }

        else if (other.gameObject.tag.Equals("Tower")&&!isChicken)
        {
            other.GetComponent<Health>().RemoveHealth(attackDamage*Time.deltaTime);


        }
    }


    /*private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("OnTriggerStay");



        /*
        if(attackTimer <= 0f)
        {
            attackTimer = attackDelay;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

    }*/

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {

        //whatImHitting=null;
        //attackTimer = 0.0f;
    }*/

    private void OnDestroy()
    {
        GameManager.instance.EnemiesLeftAlive -= 1;
    }
}
