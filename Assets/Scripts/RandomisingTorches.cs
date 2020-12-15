using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisingTorches : MonoBehaviour
{
    public GameObject[] torches;
    private Camera mainCamera;
    public Vector2 screenBounds;
    public float spawningDistance=0;
    public float timer =0;
    public int count = 0;
    public int r;
    //public float nextSpawningPosition;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        nextSpawningDistance();
    }

    // Update is called once per frame
    void Update()
    { 

        if (transform.position.y>spawningDistance)
        {
            //Debug.Log("spawning torches");

            count = 0;
            r = Random.Range(0, 3);
            if( r == 0)
            {
                //Initiating Left torch

                GameObject leftTorch = Instantiate(torches[0]);
                leftTorch.transform.position = new Vector3(torches[0].transform.position.x, spawningDistance + screenBounds.y *3, torches[0].transform.position.z);
                leftTorch.name = torches[0].name + 1;
                float[] angles = LeftTorchRandomAngles();
                leftTorch.GetComponent<TorchRotationAntiClockwise>().SetAngles(angles[0], angles[1]);
            }
            else if (r == 1)
            {
                //Initiating right torch

                GameObject rightTorch = Instantiate(torches[1]);
                rightTorch.transform.position = new Vector3(torches[1].transform.position.x, spawningDistance + screenBounds.y * 3, torches[1].transform.position.z);
                rightTorch.name = torches[1].name + 1;
                float[] angles = RightTorchRandomAngles();
                rightTorch.GetComponent<TorchRotationClockwise>().SetAngles(220, 45,angles[0]);
            }
            else if(r==2)
            {
                //Initiating center torch

                GameObject centerTorch = Instantiate(torches[2]);
                centerTorch.transform.position = new Vector3(torches[2].transform.position.x, spawningDistance + screenBounds.y * 3, torches[2].transform.position.z);
                centerTorch.name = torches[2].name + 1;
                float angle = CenterTorchRandomAngle();
                //Vector3 currentEulerAngles = new Vector3(0, 0, angle);
                //centerTorch.transform.eulerAngles = currentEulerAngles;
                centerTorch.GetComponent<TorchRotationClockwise>().SetAngles(359,1,angle);
                //Debug.Log(centerTorch.transform.position);
            }

            count++;
            nextSpawningDistance();
        }
    }
    
    private void nextSpawningDistance()
    {
        spawningDistance += screenBounds.y;
    }

    private float[] LeftTorchRandomAngles()
    {
        
        float a = Random.Range(-140, 40);
        float b = Random.Range(-140, 40);
        if (a < b)
        {
            if (a < 0)
            {
                a = 360 + a;
            }
            if (b < 0)
            {
                b = 360 + b;
            }
            float[] angles= { a,b};
            return angles;


        }
        else
        {
            if (a < 0)
            {
                a = 360 + a;
            }
            if (b < 0)
            {
                b = 360 + b;
            }
            float[] angles = { b, a };
            return angles;

        }

    }

    private float[] RightTorchRandomAngles()
    {
        
        float a = Random.Range(45, 220);
        float b = Random.Range(45, 220);
        if (a < b)
        {
            float[] angles = { b, a };
            return angles;
        }
        else
        {
            float[] angles = { a, b };
            return angles;
        }

    }
    private float CenterTorchRandomAngle()
    {
        return Random.Range(1, 359);
    }

}
