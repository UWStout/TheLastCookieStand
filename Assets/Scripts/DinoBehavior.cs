using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehavior : MonoBehaviour
{
    public Health hlth;
    public Movement mvmnt;
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    //Used to attack
    public float attackDamage;
    public float attackTimer = 0.0f;
    public float armorWeakness = .5f;
    public GameObject whatImHitting;
    //if dino is a chicken
    public bool isChicken = false;
    // Start is called before the first frame update
    void Start()
    {
        //flip depending on what side
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
        //Dino Attack
        if(whatImHitting!=null&&((whatImHitting.tag!="Tower")||!isChicken))
        {
            //animation
            GetComponent<Animator>().Play("Attack");
            hit(whatImHitting);
            //movement
            mvmnt.StopMoving();
        }
        //Dino Walk
        else
        {
            //animation
            GetComponent<Animator>().Play("Walk");
            //movement
            mvmnt.StartMoving();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Cookie")||collision.gameObject.tag.Equals("Tower"))
        {
            
            whatImHitting =collision.gameObject;

        }
    }

    //Deal damage
    private void hit(GameObject other)
    {

        if (other.tag.Equals("Cookie") && other.gameObject.GetComponent<Cookie>().isBurnt &&!isChicken)
        {
            //Damage cookie with armor weakness
            other.gameObject.GetComponent<Health>().RemoveHealth(attackDamage*Time.deltaTime*armorWeakness);

        }
        else if (other.tag.Equals("Cookie"))
        {
            //Damage cookie
            other.gameObject.GetComponent<Health>().RemoveHealth(attackDamage*Time.deltaTime);

        }

        else if (other.gameObject.tag.Equals("Tower")&&!isChicken)
        {
            //Damage tower
            other.GetComponent<Health>().RemoveHealth(attackDamage*Time.deltaTime);


        }
    }

    private void OnDestroy()
    {
        //Remove from enemy counter
        GameManager.instance.EnemiesLeftAlive -= 1;
    }
}
