using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public Button setting;
    public Button gamestart;
    public Button soundOn;
    public Button soundOff;
    public Slider volume;
    public GameObject panel;

    public AudioManager audioManager;

    bool isSoundOn;

    // Start is called before the first frame update
    void Start()
    {
        isSoundOn = true;
   
        volume.value = 0.5f;
        panel.SetActive(false);
        audioManager.GetComponent<AudioManager>();
    }

    public void SoundOnOffChange()
    {
        isSoundOn = !isSoundOn;
        soundOn.interactable = !isSoundOn;
        soundOff.interactable = isSoundOn;
        volume.interactable = isSoundOn;

        audioManager.SoundOnOff();
        
        if(isSoundOn)
        {
            audioManager.SoundStart();
        }
        else
        {
            audioManager.SoundStop();
        }
    }

    public void PanelOnOffChange()
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void GameStart()
    {
        Debug.Log("SceneMove");
        //SceneManager.LoadScene("KimSM");
    }
}
