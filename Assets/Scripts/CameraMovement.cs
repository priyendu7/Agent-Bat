using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public float characterSpeedModifier = 0.1f;
    public static float _cameraSpeed=1.5f;
    public static float cameraRate = 0.001f;
    //public GameObject bat;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //Debug.Log("start is called");
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update ho raha hai"+transform.position+"Delta Time is "+Time.deltaTime+"timescale is "+Time.timeScale);
       transform.position = new Vector3(transform.position.x , transform.position.y + _cameraSpeed * Time.deltaTime, transform.position.z);
        _cameraSpeed += cameraRate;
    }
    public void CameraSpeedReset()
    {
        _cameraSpeed = 1.5f;
    }
    //public void OnMouseDrag()
    //{
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    float xDis = bat.transform.position.x + (worldPosition.x - bat.transform.position.x) * characterSpeedModifier;
    //    float yDis = bat.transform.position.y + (worldPosition.y - bat.transform.position.y) * characterSpeedModifier;
    //    bat.transform.position = new Vector3(xDis, yDis, 1);
    //}
}
