using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstruction_struct : MonoBehaviour
{
   public GameObject monster;
   public double vectorx;
    public bool onair;
    // Start is called before the first frame update
    public obstruction_struct(GameObject monster,double vectorx , bool onair)
    {
        this.monster = monster;
        this.vectorx = vectorx;
        this.onair = onair;
    }
}
