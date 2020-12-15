using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioManager audioManager;
    public Slider slider;
    // Start is called before the first frame update
    public void SettingVolume()
    {
        
        audioManager.SetVolume(slider.value);
    }
    
}
