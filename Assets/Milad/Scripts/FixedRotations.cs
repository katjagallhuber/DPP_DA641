using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotations : MonoBehaviour
{
    [SerializeField]
    private GameObject vrConterollerLeftOrRight;

  //  [SerializeField]
   // private GameObject xrRig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        var temp = vrConterollerLeftOrRight.transform.localEulerAngles.y;
            Debug.Log(temp);
        Yrotation(temp);
    }

    public void Yrotation(float temp)
    {
        if (vrConterollerLeftOrRight != null)
            transform.eulerAngles = new Vector3(transform.localEulerAngles.x,-temp*2 , transform.localEulerAngles.z);

    }
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
