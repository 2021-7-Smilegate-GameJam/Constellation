using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject audioPool;

    public AudioSource Source1;
    public AudioSource Source2;
    public AudioSource Source3;
    public AudioSource Source4;

    public void SoundOnOff()
    {
        audioPool.SetActive(!audioPool.activeSelf);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
