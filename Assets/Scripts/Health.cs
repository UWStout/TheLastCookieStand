using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RemoveHealth(float damage)
    {
        health -= damage;
    }

    public void AddHealth(float heal)
    {
        health += heal;
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
