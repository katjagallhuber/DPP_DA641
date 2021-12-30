using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawRotation : MonoBehaviour
{
    //This Script works like a Seesaw to animate a wooden puppet controller in VR :D
    

    [SerializeField]
    private GameObject puppetConterollerLeft;
  
    [SerializeField]
    private GameObject puppetConterollerRight;


    [SerializeField]
    private float leftAngle = 45f;

    [SerializeField]
    private float rightAngle = -45f;

    // Update is called once per frame
    void Update()
    {
        var temp = ClampAngle( transform.localEulerAngles.z);
        //Debug.Log(temp);

        LockRotation90to270(temp);
        RightUp(temp);
        LeftUp(temp);

    }
    public void LeftUp(float temp)
    {
       if (temp > 0f && temp <= 90f)
       {
            //puppetConterollerLeft.transform.localPosition = new Vector3(puppetConterollerLeft.transform.localPosition.x-1, temp / leftAngle, puppetConterollerLeft.transform.localPosition.z);
           // puppetConterollerRight.transform.localPosition = new Vector3(puppetConterollerRight.transform.localPosition.x+1, -temp / leftAngle, puppetConterollerRight.transform.localPosition.z);
            puppetConterollerLeft.transform.localPosition = new Vector3(puppetConterollerLeft.transform.localPosition.x, temp / leftAngle, puppetConterollerLeft.transform.localPosition.z);
            puppetConterollerRight.transform.localPosition = new Vector3(puppetConterollerRight.transform.localPosition.x, -temp / leftAngle, puppetConterollerRight.transform.localPosition.z);
            //Debug.Log("LeftUp");
        }
    }
    public void RightUp(float temp)
    {
        if (temp >= 270f && temp <360f)
        {
          temp -= 360f;
            //  puppetConterollerLeft.transform.localPosition = new Vector3(puppetConterollerLeft.transform.localPosition.x-1, -temp / rightAngle, puppetConterollerLeft.transform.localPosition.z);
            //  puppetConterollerRight.transform.localPosition = new Vector3(puppetConterollerRight.transform.localPosition.x+1, temp / rightAngle, puppetConterollerRight.transform.localPosition.z);

            puppetConterollerLeft.transform.localPosition = new Vector3(puppetConterollerLeft.transform.localPosition.x, -temp / rightAngle, puppetConterollerLeft.transform.localPosition.z);
            puppetConterollerRight.transform.localPosition = new Vector3(puppetConterollerRight.transform.localPosition.x, temp / rightAngle, puppetConterollerRight.transform.localPosition.z);

            //Debug.Log("RightUp");
        }
    }

    public void LockRotation90to270(float temp)
    {
        //Just the Z axies locked between 90 and 270
        if (temp > 90f && temp < 180f)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 90f);
        }
        if (temp > 180f && temp < 270f)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 270f);
        }
    }
        /// <summary>
        /// Clamps any angle to a value between 0 and 360 : -90 = 270
        /// </summary>
    public static float ClampAngle(float _Angle)
    {
        float ReturnAngle = _Angle;

        if (_Angle < 0f)
            ReturnAngle = (_Angle + (360f * ((_Angle / 360f) + 1)));

        else if (_Angle > 360f)
            ReturnAngle = (_Angle - (360f * (_Angle / 360f)));

        else if (ReturnAngle == 360) //Never use 360, only go from 0 to 359
            ReturnAngle = 0;

        return ReturnAngle;
    }
}
//The script is witten by @Milad3design :D 2021
