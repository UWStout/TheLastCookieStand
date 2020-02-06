using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBehavior : MonoBehaviour
{
    public Health hlth;
    public Movement mvmnt;
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    public GameManager gm;

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

        //Probably a better way to do this.
        gm = GameObject.Find("ControllerObject").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        gm.EnemiesLeftAlive -= 1;
    }
}
