using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpSpawnner : MonoBehaviour
{
    private Camera mainCamera;
    public Vector2 screenBounds;
    public float spawningDistance = 0;
    public int randomTime;
    public int spawningTime=0;
    public int spawningCount = 0;
    public float x ;
    public GameObject healthPowerUps;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        x = screenBounds.x-0.2f;
        nextSpawningTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawningTime)
        {
            spawningTime = 70 * spawningCount;
            spawningCount++;
            nextSpawningTime();
            float spawningDistance = screenBounds.y*3 + mainCamera.transform.position.y;
            GameObject healthPowerUp = Instantiate(healthPowerUps);
            
            healthPowerUp.transform.position = new Vector3(Random.Range(-x,x), spawningDistance, healthPowerUps.transform.position.z);

        }
        
    }
    

    public void nextSpawningTime()
    {
        randomTime = Random.Range(0, 20);
        spawningTime += randomTime;

    }
}
