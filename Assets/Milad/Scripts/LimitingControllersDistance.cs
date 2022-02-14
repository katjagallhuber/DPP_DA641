using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitingControllersDistance : MonoBehaviour
{
    [SerializeField]
    float maxDistance;
    [SerializeField]
    GameObject HandController;
    [SerializeField]
    GameObject FeetController;

    [SerializeField]
    XROffsetGrabInteractible grabController;

    [SerializeField]
    GameObject grabObjectMaterial;

    [SerializeField]
    Material green;
    [SerializeField]
    Material red;

    void Start()
    {
        grabObjectMaterial.GetComponent<Renderer>().material = green;
    }

    // Update is called once per frame
    void Update()
    {
        LimitControllersDistance(FeetController, HandController, maxDistance);
    }
    public void LimitControllersDistance(GameObject Controller2, GameObject Controller1, float maxDistance)
    {

            Vector3 position2 = Controller2.transform.position;
            Vector3 position1 = Controller1.transform.position;
            Vector3 direction = position2 - position1;
            float sqrDistance = direction.sqrMagnitude;
            if (sqrDistance > maxDistance * maxDistance)
            {
            Controller2.transform.position = direction.normalized * maxDistance + position1;
            grabController.enabled = false;
            grabObjectMaterial.GetComponent<Renderer>().material = red;
            //StartCoroutine(WaitToGrabAgain(0.5f));


        }
        if (sqrDistance < maxDistance * maxDistance )
        {

                grabController.enabled = true;
                grabObjectMaterial.GetComponent<Renderer>().material = green;
 
        }


    }

    //IEnumerator WaitToGrabAgain(float time)
    //{

    //    yield return Helpers.GetWait(time);
    //    if (!grabController.enabled)
    //    {
    //        grabController.enabled = true;
    //        grabObjectMaterial.GetComponent<Renderer>().material = green;
    //    }

    //}



}
