using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAI : MonoBehaviour
{
	public GameObject point;
	Animator anim;
	public GameObject GetPlayer()
	{
		return point;
	}

	void Start()
	{
		anim = GetComponent<Animator>();
		anim.SetBool("Point", false);
	}

	void Update()
	{
		if (GameObject.FindGameObjectWithTag("Point"))
		{
			point = GameObject.FindGameObjectWithTag("Point");
			anim.SetBool("Point", true);
			anim.SetFloat("DistanceToPoint", Vector3.Distance(transform.position, point.transform.position));
			
		}
        else
        {
			anim.SetBool("Point", false);
			anim.SetFloat("DistanceToPoint", 100f);
			
		}
		
	}
	void OnTriggerEnter(Collider collider)
	{

		if (collider.gameObject.tag == "Point")
		{
			Destroy(collider.gameObject);
			//Add point to collection
		}
	}

}
