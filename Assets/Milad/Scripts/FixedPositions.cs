using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPositions : MonoBehaviour
{
    [SerializeField]
    private GameObject xrRig;
    //[SerializeField]
   // private FixedJoint fixp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FixedPosition();
    }
    public void FixedPosition()
    {
       
        if(xrRig!=null)
        transform.localPosition = new Vector3(xrRig.transform.localPosition.x, xrRig.transform.localPosition.y, xrRig.transform.localPosition.z);



    }
}
