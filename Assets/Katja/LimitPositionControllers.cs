using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class LimitPositionControllers : MonoBehaviour
{
    [SerializeField] private XRController leftController;
    [SerializeField] private XRController rightController;
    [SerializeField] private XROffsetGrabInteractible handController;
    [SerializeField] private XROffsetGrabInteractible feetController;

    [SerializeField] private float distanceLimit = 1f;

    void Update()
    {
        LimitControllersDistance(leftController.gameObject, rightController.gameObject, distanceLimit);
    }

    private void LimitControllersDistance(GameObject Controller2, GameObject Controller1, float maxDistance)
    {

        Vector3 position2 = Controller2.transform.position;
        Vector3 position1 = Controller1.transform.position;
        Vector3 direction = position2 - position1;
        float sqrDistance = direction.sqrMagnitude;
        if (sqrDistance > maxDistance * maxDistance)
        {
            handController.trackPosition = false;
            feetController.trackPosition = false;

            handController.trackRotation = false;
            feetController.trackRotation = false;

            ActivateHaptics(leftController, 0.3f, 0.3f);
            ActivateHaptics(rightController, 0.3f, 0.3f);
        }
        else
        {
            handController.trackPosition = true;
            feetController.trackPosition = true;

            handController.trackRotation = true;
            feetController.trackRotation = true;
        }
    }

    public static void ActivateHaptics(XRController controller, float amplitude, float duration)
    {
        controller.SendHapticImpulse(amplitude, duration);
    }
}
