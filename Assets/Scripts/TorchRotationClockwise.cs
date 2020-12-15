using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchRotationClockwise : MonoBehaviour
{
    private float _torchRotationSpeed = 30;
    public float _startingAngle=220;
    public float _endingAngle=45;
    public float newAngle;

    private Vector3 currentEulerAngles;
    
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, newAngle);
    }

    
    void Update()
    {

        currentEulerAngles = transform.eulerAngles;
        

        if (currentEulerAngles.z >= _startingAngle )
        {
            _torchRotationSpeed *= -1;
            currentEulerAngles = new Vector3(0, 0, _startingAngle);
            //Debug.Log("Starting  wala chal raha hai" + currentEulerAngles.z +"and " + _startingAngle);
        }
        else if (currentEulerAngles.z <= _endingAngle)
        {
            _torchRotationSpeed *= -1;
            currentEulerAngles = new Vector3(0, 0, _endingAngle);
            //Debug.Log("ending wala chal raha hai");
        }

        currentEulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * _torchRotationSpeed;
        transform.eulerAngles = currentEulerAngles;

        
    }
    public void SetAngles(float s, float e,float n)
    {
        _startingAngle = s;
        _endingAngle = e;
        newAngle = n;

    }
}
