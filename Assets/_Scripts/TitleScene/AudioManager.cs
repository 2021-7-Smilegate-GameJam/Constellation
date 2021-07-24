using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public TitleManager titleManager;
    public GameObject audioPool;

    public AudioSource Source1;
    public AudioSource Source2;
    public AudioSource Source3;
    public AudioSource Source4;

    public AudioSource Source6;
    public AudioSource Source7;

    public int hp = 100;

    public bool isSoundOn = true;
    public float soundVolume;
    
    void Start()
    {
        SoundStart();
        titleManager.GetComponent<TitleManager>();
        soundVolume = titleManager.volume.value * 0.6f;
    }

    void Update()
    {
      if(titleManager.panel.activeSelf)
        {
            soundVolume = titleManager.volume.value * 0.6f;
            Source1.volume = soundVolume;
            Source2.volume = soundVolume;
            Source3.volume = soundVolume;
            Source4.volume = soundVolume;

            Source6.volume = soundVolume;
            Source7.volume = soundVolume;
        }
    }

    public void SoundStart()
    {
        StartCoroutine("SoundType1");
    }

    public void SoundStop()
    {
        StopCoroutine("SoundType1");
        StopCoroutine("SoundType2");
    }

    public void SoundOnOff()
    {
        isSoundOn = !isSoundOn;
        audioPool.SetActive(!audioPool.activeSelf);
    }


    IEnumerator SoundType1()
    {

        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source1.Play();
        Debug.Log("1");
        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source2.Play();
        Debug.Log("2");
        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source3.Play();
        Debug.Log("3");
        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source4.Play();
        Debug.Log("4");

        StartCoroutine("SoundType2");
    }

    IEnumerator SoundType2()
    {

        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source1.Play();
        Debug.Log("5");
        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source6.Play();
        Debug.Log("6");
        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source7.Play();
        Debug.Log("7");
        yield return new WaitForSeconds((float)hp / 50 + 0.5f);
        Source4.Play();
        Debug.Log("8");

        StartCoroutine("SoundType1");
    }

    /*
    IEnumerator SoundType3()
    {

        yield return new WaitForSeconds(hp / 100 + 1.3f);
        Source1.Play();
        Debug.Log("5");
        yield return new WaitForSeconds(hp / 100 + 1.3f);
        Source6.Play();
        Debug.Log("6");
        yield return new WaitForSeconds(hp / 100 + 1.3f);
        Source7.Play();
        Debug.Log("7");
        yield return new WaitForSeconds(hp / 100 + 1.3f);
        Source4.Play();
        Debug.Log("8");
    }

    */
}
