using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider slider;
    public AudioManager audioManager;
    public Button highButton;
    public Button lowButton;
    
    public void SetVolume(float volume)
    {
        audioManager.SetVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void Start()
    {
       float volume= PlayerPrefs.GetFloat("Volume", 0.5f);
        slider.value = volume;
        setColor();
    }

    public void highButtonClicked()
    {
        PlayerPrefs.SetInt("Graphics", 0);
        setColor();

    }
    public void lowButtonClicked()
    {
        PlayerPrefs.SetInt("Graphics", 1);
        setColor();
    }

    public void setColor()
    {
        Debug.Log("setting color");
        int graphics = PlayerPrefs.GetInt("Graphics", 0);
        if (graphics == 0)
        {
            highButton.GetComponent<Image>().color = new Color32(0, 255, 151, 255);
            lowButton.GetComponent<Image>().color = new Color32(0, 255, 151, 20);
        }
        else
        {
            highButton.GetComponent<Image>().color = new Color32(0, 255, 151, 20);
            lowButton.GetComponent<Image>().color = new Color32(0, 255, 151, 255);
        }
    }
}
