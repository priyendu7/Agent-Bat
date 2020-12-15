using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchRotationAntiClockwise : MonoBehaviour
{
    private float _torchRotationSpeed = 30;
    public float _startingAngle = 220;
    public float _endingAngle = 40;
    public float newAngle;
    public Vector3 currentEulerAngles;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, newAngle);
    }


    void Update()
    {

        currentEulerAngles = transform.eulerAngles;

        //if both angles are negative
        if(_startingAngle>220 && _endingAngle > 220)
        {
            if (currentEulerAngles.z > _endingAngle)
            {
                _torchRotationSpeed *= -1;
                currentEulerAngles = new Vector3(0, 0, _endingAngle);
            }
            else if(currentEulerAngles.z < _startingAngle)
            {
                _torchRotationSpeed *= -1;
                currentEulerAngles = new Vector3(0, 0, _startingAngle);
            }
        }
        //if both angles are positive
        else if (_startingAngle<220 && _endingAngle<220)
        {
            if (currentEulerAngles.z > _endingAngle)
            {
                _torchRotationSpeed *= -1;
                currentEulerAngles = new Vector3(0, 0, _endingAngle);
            }
            else if (currentEulerAngles.z < _startingAngle)
            {
                _torchRotationSpeed *= -1;
                currentEulerAngles = new Vector3(0, 0, _startingAngle);
            }
        }
        else
        {
            //checking if current angle is positive
           if(currentEulerAngles.z>_endingAngle && currentEulerAngles.z < 200)
            {
                //Debug.Log("setting angle to ending angle");
                _torchRotationSpeed *= -1;
                currentEulerAngles = new Vector3(0, 0, _endingAngle);
            }
           //checking if current angle is negative
           else if (currentEulerAngles.z<=_startingAngle && currentEulerAngles.z >200)
            {
                //Debug.Log("setting angle to starting angle");
                _torchRotationSpeed *= -1;
                currentEulerAngles = new Vector3(0, 0, _startingAngle);
            }
        }

        currentEulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * _torchRotationSpeed;
        transform.eulerAngles = currentEulerAngles;


    }
    public void SetAngles(float s, float e)
    {

        newAngle = e;
    }

   
}
