using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrRigPosition : MonoBehaviour
{

    [SerializeField]
    private GameObject vrConterollerLeftOrRight;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RightUp();
    }
    public void RightUp()
    {
     transform.localPosition = new Vector3(transform.localPosition.x, vrConterollerLeftOrRight.transform.localPosition.y*2f, transform.localPosition.z);
          
     //Debug.Log("RightUp");
        
    }
}
