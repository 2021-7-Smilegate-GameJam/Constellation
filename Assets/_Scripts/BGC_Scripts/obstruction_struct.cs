using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstruction_struct : MonoBehaviour
{
   public GameObject monster;
   public double vectorx;
    public int object_type;
    // Start is called before the first frame update
    public obstruction_struct()
    {

    }
    public obstruction_struct(GameObject monster,double vectorx , int objecttype=0)
    {
        this.monster = monster;
        this.vectorx = vectorx;
        this.object_type = objecttype;
    }
 
}
