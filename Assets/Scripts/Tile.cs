using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Cookie cookieOnTile = null;
    public string tileType;
    public Cookie c;
    //GameManager gm;
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
        if (tileType.Equals("Cookie") && !GameManager.instance.mc.holdingCookie)
        {
            Cookie newCookie = Instantiate(c);
            newCookie.gameObject.transform.position = this.gameObject.transform.position;
            //Debug.Log(newCookie);
            GameManager.instance.mc.holdingCookie = newCookie;
        }
        else if (tileType.Equals("Oven") && GameManager.instance.mc.holdingCookie && cookieOnTile == null)
        {
            GameManager.instance.mc.holdingCookie.currTile = this;
            cookieOnTile = GameManager.instance.mc.holdingCookie;
            GameManager.instance.mc.holdingCookie.gameObject.transform.position = this.gameObject.transform.position;
            GameManager.instance.mc.holdingCookie = null;
            
        }
        else if (tileType.Equals("Oven") && !GameManager.instance.mc.holdingCookie && cookieOnTile != null && (cookieOnTile.isBaked || cookieOnTile.isBurnt))
        {
            GameManager.instance.mc.holdingCookie = cookieOnTile;
            GameManager.instance.mc.holdingCookie.currTile = null;
            cookieOnTile = null;
        }
        else if(tileType.Equals("Tile") && cookieOnTile == null && (GameManager.instance.mc.holdingCookie.isBaked || GameManager.instance.mc.holdingCookie.isBurnt))
        {
            GameManager.instance.mc.holdingCookie.currTile = this;
            cookieOnTile = GameManager.instance.mc.holdingCookie;
            GameManager.instance.mc.holdingCookie.gameObject.transform.position = this.gameObject.transform.position;
            GameManager.instance.mc.holdingCookie = null;
        }
    }
}
