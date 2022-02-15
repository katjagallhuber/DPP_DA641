using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawRotationOld : MonoBehaviour
{
    //This Script works like a Seesaw to animate a wooden puppet controller in VR :D
    

    [SerializeField]
    private GameObject puppetConterollerLeft;
  
    [SerializeField]
    private GameObject puppetConterollerRight;


    [SerializeField]
    private float leftAngle = -45f;

    [SerializeField]
    private float rightAngle = 45f;


    // Update is called once per frame
    void Update()
    {
     

        var temp = ClampAngle(transform.localEulerAngles.z);
        //Debug.Log(temp);

        LockRotation90to270(temp);
        RightUp(temp);
        LeftUp(temp);


    }
    void Start()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, 1f);

    }


    public void LeftUp(float temp)
    {
        if (temp > 0f && temp <= 90f)
        {
            puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x - 1f, transform.localPosition.y + temp / leftAngle, transform.localPosition.z);
            puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x + 1f, transform.localPosition.y - temp / leftAngle, transform.localPosition.z);
        }
    }
    public void RightUp(float temp)
    {
        if (temp >= 270f && temp < 360f)
        {
            temp -= 360f;
            puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x - 1f, transform.localPosition.y - temp / rightAngle, transform.localPosition.z);
            puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x + 1f, transform.localPosition.y + temp / rightAngle, transform.localPosition.z);
        }
    }


    public void LockRotation90to270(float temp)
    {
        //Just the Z axies locked between 90 and 270
        if (temp > 90f && temp < 180f)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90f,transform.localEulerAngles.z);
        }
        if (temp > 180f && temp < 270f)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 270f, transform.localEulerAngles.z);
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
