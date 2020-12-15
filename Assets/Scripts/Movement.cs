using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speedModifier = 0.1f;
    public float speedModifierRate = 0.0001f;
    private Vector3 mousePos;
    private Vector2 dir;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _speedModifier = PlayerPrefs.GetFloat("SpeedModifier", 0.1f);
        //Debug.Log("started");
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //dragging character towards pointed
            
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(worldPosition);
            float xDis = transform.position.x + (worldPosition.x - transform.position.x) * _speedModifier;
            float yDis = transform.position.y + (worldPosition.y - transform.position.y) * _speedModifier;
            transform.position = new Vector3(xDis, yDis, 1);

            //facing character towards mousePoint
            Vector2 direction = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
            transform.up = direction;


        }
        _speedModifier += speedModifierRate;

        
    }

    //void OnMouseDrag()
    //{
    //    //dragging character towards pointed 
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    float xDis = transform.position.x + (worldPosition.x - transform.position.x) * _speedModifier;
    //    float yDis = transform.position.y + (worldPosition.y - transform.position.y) * _speedModifier;
    //    transform.position = new Vector3(xDis, yDis, 1);

    //    //facing character towards mousePoint
    //    Vector2 direction = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
    //    transform.up = direction;

    //    //Debug.Log("Mouse dragged");
    //}
}
