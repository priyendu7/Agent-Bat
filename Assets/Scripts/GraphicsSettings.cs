using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class GraphicsSettings : MonoBehaviour
{

    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
      
        //volume.profile.TryGetSettings(out bloom);
        int graphics = PlayerPrefs.GetInt("Graphics", 0);
        if(graphics == 0)
        {
            game.SetActive(true);
        }
        else
        {
            game.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
