using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyItself : MonoBehaviour
{
    public Vector2 screenBounds;
    Camera cam;
    public float idk;

    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        //Debug.Log(cam.transform.position);
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        idk = cam.transform.position.y;

        if (transform.position.y < (cam.transform.position.y - 20))
        {
          
           Destroy(gameObject);
        }
    }
}
