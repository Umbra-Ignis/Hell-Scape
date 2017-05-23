using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour {

	public GameObject torch;
	public Transform target;
	NavMeshAgent agent;
	public bool isActive;

	// Use this for initialization
	void Start () {

		isActive = true;

		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () { 
			agent.SetDestination (target.position);
	}
}
