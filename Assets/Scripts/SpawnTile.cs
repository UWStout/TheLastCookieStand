using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public string cookieType;
    public Cookie c;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (cookieType.Equals("Cookie"))
        {
            Cookie newCookie = Instantiate(c);
            newCookie.gameObject.transform.position = this.gameObject.transform.position;
            gm.mc.holdingCookie = newCookie;
        }
    }
}
