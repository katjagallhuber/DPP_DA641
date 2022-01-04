using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

	public GameObject NPC;
	public GameObject opponent;
	public float speed = 2.0f;
	public float rotSpeed = 1.0f;
	public float accuracy = 6.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		NPC = animator.gameObject;
		if(opponent!=null)
		opponent = NPC.GetComponent<PointAI>().GetPlayer();


	}
}
