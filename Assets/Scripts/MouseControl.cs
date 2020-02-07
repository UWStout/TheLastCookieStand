using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Cookie holdingCookie = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            // whatever tag you are looking for on your game object
            if (hit.collider.tag == "Tile")
            {
                Debug.Log("---> Hit: ");
                if (Input.GetMouseButtonDown(0) && !hit.collider.gameObject.GetComponent<Tile>().taken && holdingObject != null)
                {
                    Debug.Log("Pressed primary button.");
                    hit.collider.gameObject.GetComponent<Tile>().taken = true;
                    holdingObject.gameObject.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, holdingObject.transform.position.y, hit.collider.gameObject.transform.position.z);
                }
            }
            else if(hit.collider.tag == "Cookie")
            {
                if (Input.GetMouseButtonDown(0) && holdingObject == null)
                {
                    holdingObject = hit.collider.gameObject.GetComponent<Cookie>();
                }
            }

        }
        */


        
        if (holdingCookie != null)
        {
            //Debug.Log("Running Hold Cookie");
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            holdingCookie.gameObject.transform.position = pz;
        }
        
    }
}
