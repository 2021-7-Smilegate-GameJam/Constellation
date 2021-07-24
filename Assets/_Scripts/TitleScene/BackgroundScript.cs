using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScript : MonoBehaviour
{
    public Image backGround;
    public float x, y;
    public float k=0;

    void Start()
    {
        //StartCoroutine("Movebg");
    }

    // Update is called once per frame
    void Update()
    {
        if (k < 1)
        {
            Move();
            k += 0.001f;
        }
        else
        {
            k = 1f;
            Move();
        }
    }

    void Move()
    {
        backGround.rectTransform.pivot = new Vector2(0.5f, k);
        backGround.rectTransform.anchorMin = new Vector2(0.5f, k);
        backGround.rectTransform.anchorMax = new Vector2(0.5f, k);

        backGround.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    }
    
    
}
