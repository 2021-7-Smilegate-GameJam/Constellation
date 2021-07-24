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
    public Image background;

    public AudioManager audioManager;
    bool isSoundOn = true;
    // Start is called before the first frame update
    void Start()
    {
        setting.image.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
        gamestart.image.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
        audioManager.GetComponent<AudioManager>();
        StartCoroutine("ButtonActive");
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

    IEnumerator ButtonActive()
    {
        setting.gameObject.SetActive(false);
        gamestart.gameObject.SetActive(false);

        yield return new WaitUntil(() => background.rectTransform.pivot.y >= 0.95);
        yield return new WaitForSeconds(1f);

        setting.gameObject.SetActive(true);
        gamestart.gameObject.SetActive(true);
        
    }

}
