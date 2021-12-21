using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlPuppet : MonoBehaviour
{
    public FixedJoint rightHand;
    public FixedJoint leftHand;
    public FixedJoint rightFoot;
    public FixedJoint leftFoot;

    public XRController leftController;
    public XRController rightController;

    public Rigidbody leftControllerRigidbody;
    public Rigidbody rightControllerRigidbody;

    public Rigidbody xrRigRigidbody;

    // Update is called once per frame
    void Update()
    {
        // Hands
        if (CheckIfActivated(leftController, InputHelpers.Button.Trigger))
        {
            leftHand.connectedBody = leftControllerRigidbody;
        } else
        {
            leftHand.connectedBody = xrRigRigidbody;
        }

        if (CheckIfActivated(rightController, InputHelpers.Button.Trigger))
        {
            rightHand.connectedBody = rightControllerRigidbody;
        }
        else
        {
            rightHand.connectedBody = xrRigRigidbody;
        }

        //Feet
        if (CheckIfActivated(rightController, InputHelpers.Button.Grip))
        {
            rightFoot.connectedBody = rightControllerRigidbody;
        }
        else
        {
            rightFoot.connectedBody = xrRigRigidbody;
        }

        //Feet
        if (CheckIfActivated(leftController, InputHelpers.Button.Grip))
        {
            leftFoot.connectedBody = leftControllerRigidbody;
        }
        else
        {
            leftFoot.connectedBody = xrRigRigidbody;
        }
    }

    public bool CheckIfActivated(XRController controller, InputHelpers.Button pressedInput)
    {
        InputHelpers.IsPressed(controller.inputDevice, pressedInput, out bool isActivated, 0.1f);
        return isActivated;
    }
}
