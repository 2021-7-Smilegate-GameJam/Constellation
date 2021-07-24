using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstruction : MonoBehaviour
{
    StageModel stage;
    
   public GameObject[] monster;
    //need monster object
    List<obstruction_struct> spawn_data;
    List<GameObject> spawned_object;
    
    public float timer;
    public void Start()
    {
       this.stage=this.gameObject.GetComponent<TilemapLoop>().stage;
        spawn_data = new List<obstruction_struct>();
        spawned_object = new List<GameObject>();
        set_monster();
    }
    public List<obstruction_struct> set_monster()
    {
        for(int i =0; i<stage.objectPositions.Length;i++)
        {
            int ran = Random.Range(0, monster.Length);
            bool onairtest =Random.Range(0, 2)==0?true:false;
            spawn_data.Add(new obstruction_struct(monster[ran], stage.objectPositions[i], onairtest));
        }
        return spawn_data;
    }
    
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        spawn_object();
        move_object();
    }
   
    public void move_object()
    {
        if (timer < 60)
        {
            for (int i = 0; i < spawned_object.Count; i++)
            {
                spawned_object[i].transform.position = new Vector3(spawned_object[i].transform.position.x - Time.deltaTime * stage.rollingSpeed, spawned_object[i].transform.position.y, 0);
            }
        }
    }
    public void spawn_object()
    {
      
        if(spawn_data.Count!=0)
        {
           
            if (timer>spawn_data[0].vectorx)
            {

            if(spawn_data[0].onair)
                {
                    spawned_object.Add(Instantiate(spawn_data[0].monster, new Vector3(7, 0.5f, 0), Quaternion.identity, this.gameObject.transform));
                }
            else
                {
                    spawned_object.Add(Instantiate(spawn_data[0].monster, new Vector3(7, -0.5f, 0), Quaternion.identity, this.gameObject.transform));
                }
           
            spawn_data.RemoveRange(0, 1);
            }
        }
    }
}
