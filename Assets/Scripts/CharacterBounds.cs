using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBounds : MonoBehaviour
{
    public Vector2 screenBounds;
    public Vector3 viewPos;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, Camera.main.transform.position.y - screenBounds.y, Camera.main.transform.position.y + screenBounds.y);

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.z = 3;
        transform.position = viewPos;
    }
}
