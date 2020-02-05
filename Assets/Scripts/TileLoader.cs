using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLoader : MonoBehaviour
{
    List<GameObject> tiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        float initX = 1.3f;
        float xRowOffSet = .1f;
        //float diffX = 1.3f;
        float initY = .4f;
        float diffY = 1.2f;

        for (int row=0; row<4; row++)
        {
            for(int col=0; col<4; col++)
            {
                for(int side=0; side<2; side++)
                {
                    GameObject tempTile = new GameObject();
                    tempTile.AddComponent<Tile>();
                    tempTile.AddComponent<BoxCollider2D>();
                    tempTile.GetComponent<BoxCollider2D>().transform.localScale = new Vector3(1.2f, 1.2f, 1f);
                    if (side == 0)
                    {
                        tempTile.gameObject.transform.position = new Vector2((initX + xRowOffSet * row) + col * (initX + xRowOffSet * row), initY - row * diffY);
                    }
                    else
                    {
                        tempTile.gameObject.transform.position = new Vector2((-initX - xRowOffSet * row) - col * (initX + xRowOffSet * row), initY - row * diffY);
                    }
                    
                    tiles.Add(tempTile);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
