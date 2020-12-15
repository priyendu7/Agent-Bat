using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private Camera mainCamera;
    public Vector2 screenBounds;
    public float x;
    public float yFactor;
    public float nextSpawnAt=0;
    public GameObject[] Coin;
    public float startingAngle;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        NextSpawningDistance();
        yFactor = screenBounds.y / 6;
        startingAngle = 40;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > nextSpawnAt)
        {
            
            GameObject coin = Instantiate(Coin[0]);
            GameObject coin1 = Instantiate(Coin[1]);
            GameObject coin2 = Instantiate(Coin[2]);
            GameObject coin3 = Instantiate(Coin[3]);
            GameObject coin4 = Instantiate(Coin[4]);
            GameObject coin5 = Instantiate(Coin[5]);

            int a = Random.Range(0, 3);
            if (a == 0)
            {
                x = screenBounds.x / 2 * (-1);

            }
            else if (a == 1)
            {
                x = 0;
            }
            else if (a == 2)
            {
                x = screenBounds.x / 2;
            }

            
            
            coin.transform.position = new Vector3(x, nextSpawnAt + screenBounds.y * 2 + yFactor, Coin[0].transform.position.z);
            coin.transform.eulerAngles = new Vector3(coin.transform.eulerAngles.x, coin.transform.eulerAngles.y + startingAngle, coin.transform.eulerAngles.z);

            coin1.transform.position = new Vector3(x, nextSpawnAt + screenBounds.y * 2 + yFactor*2, Coin[1].transform.position.z);
            coin1.transform.eulerAngles = new Vector3(coin1.transform.eulerAngles.x, coin1.transform.eulerAngles.y + 2*startingAngle, coin1.transform.eulerAngles.z);

            coin2.transform.position = new Vector3(x, nextSpawnAt + screenBounds.y * 2 + yFactor*3, Coin[2].transform.position.z);
            coin2.transform.eulerAngles = new Vector3(coin2.transform.eulerAngles.x, coin2.transform.eulerAngles.y + 3*startingAngle, coin2.transform.eulerAngles.z);

            coin3.transform.position = new Vector3(x, nextSpawnAt + screenBounds.y * 2 + yFactor*4, Coin[3].transform.position.z);
            coin3.transform.eulerAngles = new Vector3(coin3.transform.eulerAngles.x, coin3.transform.eulerAngles.y + 4*startingAngle, coin3.transform.eulerAngles.z);

            coin4.transform.position = new Vector3(x, nextSpawnAt + screenBounds.y * 2 + yFactor*5, Coin[4].transform.position.z);
            coin4.transform.eulerAngles = new Vector3(coin4.transform.eulerAngles.x, coin4.transform.eulerAngles.y + 5*startingAngle, coin4.transform.eulerAngles.z);

            coin5.transform.position = new Vector3(x, nextSpawnAt + screenBounds.y * 2 + yFactor*6, Coin[5].transform.position.z);
            coin5.transform.eulerAngles = new Vector3(coin5.transform.eulerAngles.x, coin5.transform.eulerAngles.y + 6*startingAngle, coin5.transform.eulerAngles.z);


            NextSpawningDistance();
        }

        

    }
    public void NextSpawningDistance()
    {
        nextSpawnAt += screenBounds.y * 2;
    }
}
