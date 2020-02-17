using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieBakeUI : MonoBehaviour
{
    public Cookie c;
    public Image imgCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, c.gameObject.transform.position);
        Debug.Log(c);
        if (c.currTile != null && !c.currTile.tileType.Equals("Oven"))
        {
            imgCooldown.fillAmount = 0;
        }
        else if (!c.isBaked)
        {
            imgCooldown.fillAmount = (c.bakeTime - c.cookTimer) / c.bakeTime;
        }
        else if(!c.isBurnt)
        {
            imgCooldown.color = Color.red;
            imgCooldown.fillAmount = (c.cookTimer - c.bakeTime) / (c.burntTime - c.bakeTime);
        }
        
        if(c.currTile == null && (c.isBaked || c.isBurnt))
        {
            imgCooldown.fillAmount = 0;
        }
    }
}
