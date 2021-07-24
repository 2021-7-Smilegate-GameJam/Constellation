using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilemapLoop : MonoBehaviour
{
    public StageModel stage;
    public Tile[] Bottomtile;
    public Tile[] Toptile;
   //need tile image;
    public Tilemap tilemap;
    public float testfloat;
    private int last_x;
    private int first_x = -6;
    private float movement_stack = 0;

    public void get_stagemodel(StageModel stage)
    {
        this.stage = stage;
    }


    void Start()
    {
        for (int x = -6; x < 6; x++)
        {
            for (int y = -7; y < -1; y++)
            {
                Vector3Int p = new Vector3Int(last_x, y, 0);
                if (y == 2)
                {
                    int top_tiletype = Random.Range(0, Toptile.Length);
                    Tile top_tile = Toptile[top_tiletype];
                    tilemap.SetTile(p, top_tile);
                    tilemap.SetTile(new Vector3Int(first_x, y, 0), null);
                }
                else
                {
                    int bottom_tiletype = Random.Range(0, Bottomtile.Length);
                    Tile bottom_tile = Bottomtile[bottom_tiletype];
                    tilemap.SetTile(p, bottom_tile);

                }
            }
         last_x = x;
        }
    }
    private void Add_tile()
    {
        for (int y = -3; y < -1; y++)
        {
            Vector3Int p = new Vector3Int(last_x, y, 0);

         
         
        }
    }
    private void Movetilemap()
    {
        movement_stack += Time.deltaTime * stage.rollingSpeed;
        tilemap.transform.parent.position = new Vector3(tilemap.transform.parent.position.x - Time.deltaTime * stage.rollingSpeed, tilemap.transform.parent.position.y, tilemap.transform.parent.position.z);
        if (movement_stack>1.0f)
        {
            tilemap.size = new Vector3Int(tilemap.size.x - 1, 3, 0);
            for (int y = -7; y < -1; y++)
            {
                Vector3Int p = new Vector3Int( last_x, y, 0);
                    if(y==2)
                {
                    int top_tiletype = Random.Range(0, Toptile.Length);
                    Tile top_tile = Toptile[top_tiletype];
                    tilemap.SetTile(p, top_tile);
                    tilemap.SetTile(new Vector3Int(first_x, y, 0), null);
                }
             else
                { 
                        int bottom_tiletype = Random.Range(0, Bottomtile.Length);
                    Tile bottom_tile = Bottomtile[bottom_tiletype];
                    tilemap.SetTile(p, bottom_tile);
                    tilemap.SetTile(new Vector3Int(first_x, y, 0), null);
                }
                   
            }
           
            movement_stack -= 1.0f;
            last_x++;
            first_x++;
              

        }

          }
    private void FixedUpdate()
    {

        if (transform.GetComponent<obstruction>().timer < 60)
        {
            Movetilemap();
        }
    }
}
