using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieChip : MonoBehaviour
{
    public Movement mvmnt;
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    public float attackDamage;
    public float reverse = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.freezeRotation = true;
        if (gameObject.transform.position.x*reverse < 0)
        {
            mvmnt.Dir.x = -1;
            sr.flipX = true;

        }
        else
        {
            mvmnt.Dir.x = 1;
            sr.flipX = false;
        }
        mvmnt.StartMoving();

        sr.sortingOrder = Mathf.CeilToInt((gameObject.transform.position.y * -1) + 5);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Dino"))
    //    {
    //        mvmnt.StopMoving();
    //    }
    //}

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Dino"))
        {
            other.gameObject.GetComponent<Health>().RemoveHealth(attackDamage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mvmnt.StartMoving();
    }
}
