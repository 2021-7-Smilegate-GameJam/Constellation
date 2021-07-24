using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int hp = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstruction")
        {
            
            hp -= 1;
        }
        
    }

    //swipe and touch...
}