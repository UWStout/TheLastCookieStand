using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeTillKill = 4f;
    bool ShouldDestroy=false;

    // Update is called once per frame
    void Update()
    {
        //destroy over time
        if (TimeTillKill>=0)
        {
            TimeTillKill-=Time.deltaTime;
        }
        else
        {
            ShouldDestroy=true;
        }
        
    }

    void OnBecameInvisible() {
        if(ShouldDestroy)
        {
            Destroy(gameObject);

        }

    }
}
