using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehavior : MonoBehaviour
{
    public Health hlth;
    public Movement mvmnt;
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    public float attackDamage;
    float attackTimer = 0.0f;
    public float attackDelay;
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

        sr.sortingOrder = Mathf.CeilToInt((gameObject.transform.position.y*-1) +5);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Cookie"))
        {
            mvmnt.StopMoving();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Cookie") && attackTimer == 0.0f)
        {
            other.gameObject.GetComponent<Health>().RemoveHealth(attackDamage);
            attackTimer += Time.deltaTime;
        }
        else if (other.gameObject.tag.Equals("Cookie"))
        {
            attackTimer += Time.deltaTime;
        }

        if(attackTimer >= attackDelay)
        {
            attackTimer = 0.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mvmnt.StartMoving();
        attackTimer = 0.0f;
    }

    private void OnDestroy()
    {
        GameManager.instance.EnemiesLeftAlive -= 1;
    }
}
