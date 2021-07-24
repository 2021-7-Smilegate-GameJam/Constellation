using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerData : MonoBehaviour
{
    Animator cha_ani;
   
    public void Start()
    {
        cha_ani = transform.GetComponent<Animator>();
    }
    
    public int hp = 5;
    private Vector2 touchBeganPos;
    private Vector2 touchEndedPos;
    private Vector2 touchDif;
    private float swipeSensitivity;
    
    private void Update()
    {
       
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstruction")
        {
            
            hp -= 1;
        }
        else  if(hp==0)
        {

        }
    }
   
    //swipe and touch...
}