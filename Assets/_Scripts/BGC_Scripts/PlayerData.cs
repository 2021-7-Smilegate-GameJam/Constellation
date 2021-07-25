using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerData : MonoBehaviour
{
    public obstruction obs;
    
    Animator cha_ani;
    Color halpalpha = new Color(1, 1, 1, 0.5f);
    Color fullalpha = new Color(1, 1, 1, 1);
    private SpriteRenderer main_cha;
   
    public void Start()
    {
        cha_ani = transform.GetComponent<Animator>();
        main_cha = GetComponent<SpriteRenderer>();
    }
    
    public int hp = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstruction"))
        {
            Destroy(collision);
            hp -= 1;
            StartCoroutine(damaged());
            if (hp == 0)
            {
                Game_over();
            }
        }
      
    }
    public void Game_over()
    {
        //실패시 회전 멈추는 메서드
        //타일맵,및 오브젝트이동 정지
        FindObjectOfType<PlanetButtonSet>().StopRotate();
        obs.isPlaing = false;
        //Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Animator>());
    }

    IEnumerator damaged()
    {
        yield return new WaitForSeconds(0.1f);
        main_cha.color = halpalpha;
        yield return new WaitForSeconds(0.1f);
        main_cha.color = fullalpha;
        yield return new WaitForSeconds(0.1f);
        main_cha.color = halpalpha;
        yield return new WaitForSeconds(0.1f);
        main_cha.color = fullalpha;
        yield return new WaitForSeconds(0.1f);
        main_cha.color = halpalpha;
        yield return new WaitForSeconds(0.1f);
        main_cha.color = fullalpha;
    }

  
}