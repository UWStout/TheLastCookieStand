using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeTillKill = 4f;
    bool ShouldDestroy=false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
