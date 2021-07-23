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

    bool isSoundOn;

    // Start is called before the first frame update
    void Start()
    {
        isSoundOn = true;
   
        volume.value = 0.5f;
        panel.SetActive(false);
    }

    public void SoundOnOffChange()
    {
        isSoundOn = !isSoundOn;
        soundOn.interactable = !isSoundOn;
        soundOff.interactable = isSoundOn;
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
