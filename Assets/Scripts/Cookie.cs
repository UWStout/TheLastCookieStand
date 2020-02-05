using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cookie : MonoBehaviour
{
    Tile currTile;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTile(Tile t)
    {

    }

    public void SetTile(OvenTile t)
    {

    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Destroy(gameObject);
    }
}
