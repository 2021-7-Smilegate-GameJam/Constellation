using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerData : MonoBehaviour
{
    public enum Playerstate
    {
        run,
        jump,
        sliding,
        attack
    }
    public Playerstate current_state;
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
        
    }

    //swipe and touch...
}