using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Health healthStats;
    public UIBar hb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hb.current=healthStats.health;
        hb.max=healthStats.maxHealth;
        hb.UpdateHealthBar();
    }
}
