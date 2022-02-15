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
    private float leftAngleZ = -45f;

    [SerializeField]
    private float rightAngleZ = 45f;

    [SerializeField]
    private float leftAngleY = -45f;

    [SerializeField]
    private float rightAngleY = 45f;

    // [SerializeField]
    // private GameObject PositionLeft;

    //[SerializeField]
    //  private GameObject PositionRight;

    // Update is called once per frame
    void Update()
    {
       
        var tempZ = ClampAngle( transform.localEulerAngles.z);
        //Debug.Log(temp);

        LockRotationZ90to270(tempZ);
        //RightUp(tempZ);
        //LeftUp(tempZ);

       

        var tempY = ClampAngle(transform.localEulerAngles.y);
        //Debug.Log(temp);

        LockRotationY90to270(tempY);
        //RightFront(tempY);
        //LeftFront(tempY);

        LeftUpYZ(tempY, tempZ);
        RightUpYZ(tempY, tempZ);







    }
    void Start()
    {
        transform.localEulerAngles = new Vector3(1f, 1f, 1f);
        //transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
    }
    //public void LeftUp(float temp)
    //{
    //   if (temp > 0f && temp <= 90f)
    //   {
    //        puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x-1f, transform.localPosition.y + temp / leftAngle, transform.localPosition.z);
    //        puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x+1f, transform.localPosition.y - temp / leftAngle, transform.localPosition.z);
    //   }
    //}
    //public void RightUp(float temp)
    //{
    //    if (temp >= 270f && temp <360f)
    //    {
    //      temp -= 360f;
    //          puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x-1f, transform.localPosition.y - temp / rightAngle, transform.localPosition.z);
    //          puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x+1f, transform.localPosition.y + temp / rightAngle, transform.localPosition.z);
    //    }
    //}

    public void LockRotationZ90to270(float temp)
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



    public void LockRotationY90to270(float temp)
    {
        //Just the Y axies locked between 90 and 270
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
    public void LeftUpYZ(float tempY, float tempZ)
    {
        if (tempZ > 0f && tempZ <= 90f)
        {
            puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x - 1f, transform.localPosition.y + tempZ / leftAngleZ, puppetConterollerLeft.transform.localPosition.z);
            puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x + 1f, transform.localPosition.y - tempZ / leftAngleZ, puppetConterollerRight.transform.localPosition.z);
        }
        if (tempY > 0f && tempY <= 90f)
        {
            puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x - 1f, puppetConterollerLeft.transform.localPosition.y, transform.localPosition.z - tempY / leftAngleY);
            puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x + 1f, puppetConterollerRight.transform.localPosition.y, transform.localPosition.z + tempY / leftAngleY);
        }
    }
    public void RightUpYZ(float tempY, float tempZ)
    {
        if (tempZ >= 270f && tempZ < 360f)
        {
            tempZ -= 360f;
            puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x - 1f, transform.localPosition.y - tempZ / rightAngleZ, puppetConterollerLeft.transform.localPosition.z);
            puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x + 1f, transform.localPosition.y + tempZ / rightAngleZ, puppetConterollerRight.transform.localPosition.z);
        }
        if (tempY >= 270f && tempY < 360f)
        {
            tempY -= 360f;
            puppetConterollerLeft.transform.localPosition = new Vector3(transform.localPosition.x - 1f, puppetConterollerLeft.transform.localPosition.y, transform.localPosition.z + tempY / rightAngleY);
            puppetConterollerRight.transform.localPosition = new Vector3(transform.localPosition.x + 1f, puppetConterollerRight.transform.localPosition.y, transform.localPosition.z - tempY / rightAngleY);
        }


    }

}
//The script is witten by @Milad3design :D 2021
