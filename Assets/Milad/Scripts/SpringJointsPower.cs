using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJointsPower : MonoBehaviour
{
    // Start is called before the first frame update
    //[Header("Head Spring Power:")]
    [SerializeField]
    private float headSpringPower;

    //[Header("Left Hand Spring Power:")]
    [SerializeField]
    private float leftHandSpringPower;

   // [Header("Right Hand Spring Power:")]
    [SerializeField]
    private float rightHandSpringPower;

    //[Header("Left Foot Spring Power:")]
    [SerializeField]
    private float leftFootSpringPower;

   // [Header("Right Foot Spring Power:")]
    [SerializeField]
    private float rightFootSpringPower;

    [SerializeField]
    private SpringJoint head;
    [SerializeField]
    private SpringJoint leftHand;
    [SerializeField]
    private SpringJoint rightHand;
    [SerializeField]
    private SpringJoint leftFoot;
    [SerializeField]
    private SpringJoint rightFoot;

    private void Update()
    {
        if (head != null && leftHand != null && rightHand != null && leftFoot != null && rightFoot != null)
        {
            head.spring = headSpringPower;
            leftHand.spring = leftHandSpringPower;
            rightHand.spring = rightHandSpringPower;
            leftFoot.spring = leftFootSpringPower;
            rightFoot.spring = rightFootSpringPower;
        }
    }
}
