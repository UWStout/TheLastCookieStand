using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool DestroyOnDeath = true;
    // Start is called before the first frame update
    void Start()
    {
        health=maxHealth;
    }

    public void RemoveHealth(float damage)
    {
        health -= damage;
    }

    public void AddHealth(float heal)
    {
        
        health += heal;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Theoretically we don't need to check for this every frame. Don't want to change because it might break something. (Exploddy cookies)
        if (health<=0&&DestroyOnDeath)
        {
            Destroy(gameObject);
        }

    }
}
