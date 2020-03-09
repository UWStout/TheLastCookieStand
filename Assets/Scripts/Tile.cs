using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Cookie cookieOnTile = null;
    public string tileType;
    public Cookie c;
    public Sprite[] s;

    private void OnMouseDown()
    {
        //if tile is cookie and not holding cookie
        if (tileType.Equals("Cookie") && !GameManager.instance.mc.holdingCookie)
        {
            //use random sprite
            if (s.Length > 0)
            {
                int sId = Random.Range(0, s.Length);
                c.sr.sprite = s[sId];

            }
            //make cookie and put it in holding
            Cookie newCookie = Instantiate(c);
            newCookie.gameObject.transform.position = this.gameObject.transform.position;
            GameManager.instance.mc.holdingCookie = newCookie;
        }
        //if tile is cookie and holding cookie
        else if (tileType.Equals("Cookie") && GameManager.instance.mc.holdingCookie)
        {
            //put cookie back
            Destroy(GameManager.instance.mc.holdingCookie.gameObject);
            GameManager.instance.mc.holdingCookie = null;
        }
        //if tile is oven, player is holding cookie, and no cookie is currently in oven
        else if (tileType.Equals("Oven") && GameManager.instance.mc.holdingCookie && cookieOnTile == null)
        {
            //remove cookie from holding
            GameManager.instance.mc.holdingCookie.currTile = this;
            cookieOnTile = GameManager.instance.mc.holdingCookie;
            //put cookie in oven
            GameManager.instance.mc.holdingCookie.gameObject.transform.position = this.gameObject.transform.position;
            GameManager.instance.mc.holdingCookie = null;
            
        }
        //if tile is oven, player is not holding cookie, and cookie in oven is baked or burnt
        else if (tileType.Equals("Oven") && !GameManager.instance.mc.holdingCookie && cookieOnTile != null && (cookieOnTile.isBaked || cookieOnTile.isBurnt))
        {
            //give cookie to player to hold
            GameManager.instance.mc.holdingCookie = cookieOnTile;
            GameManager.instance.mc.holdingCookie.currTile = null;
            cookieOnTile = null;
        }
        //if tile is a game tile (playable area), player is holding a baked/burnt cookie, an there is no cookie currently on tile
        else if(tileType.Equals("Tile") && cookieOnTile == null && GameManager.instance.mc.holdingCookie != null && (GameManager.instance.mc.holdingCookie.isBaked || GameManager.instance.mc.holdingCookie.isBurnt))
        {
            //set cookie to game tile
            GameManager.instance.mc.holdingCookie.currTile = this;
            cookieOnTile = GameManager.instance.mc.holdingCookie;
            GameManager.instance.mc.holdingCookie.gameObject.tag = "Cookie";
            GameManager.instance.mc.holdingCookie.gameObject.transform.position = this.gameObject.transform.position;
            GameManager.instance.mc.holdingCookie = null;
        }
    }
}
