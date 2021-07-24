using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstruction_struct 
{
   public GameObject monster;
   public double vectorx;
    public int object_type;
    // Start is called before the first frame update
    public obstruction_struct()
    {

    }
    /// <summary>
    /// objecttype  0=default 1=fly 2=monster 
    /// </summary>
    /// <param name="monster"></param>
    /// <param name="vectorx"></param>
    /// <param name="objecttype"></param>
    public obstruction_struct(GameObject monster,double vectorx , int objecttype=0)
    {
        this.monster = monster;
        this.vectorx = vectorx;
        this.object_type = objecttype;
    }
 
}
