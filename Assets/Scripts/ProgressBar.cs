using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameManager gm;
    public UIBar hb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gm.state==0&&gm.EnemiesTotal!=0){
            hb.current=gm.EnemiesLeftToSpawn+gm.EnemiesLeftAlive;
            //Alternative to just keep track of spawning
            //hb.current=gm.EnemiesTotal-gm.EnemiesLeftToSpawn;
            hb.max=gm.EnemiesTotal;
        }
        else
        {
            hb.current=1;
            hb.max=1;
        }



        hb.UpdateHealthBar();
    }
}
