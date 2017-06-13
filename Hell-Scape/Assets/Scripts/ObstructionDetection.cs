using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionDetection : MonoBehaviour {

	public Transform playerTrans;
	private AlphaMasking lastWall;

	// Use this for initialization
	void Start (){
		
	}

	IEnumerator DetectPlayerObstructions(){
		while(true){
			yield return new WaitForSeconds (0.5f);
			Vector3 direction = (playerTrans.position - Camera.main.transform.position).normalized;
			RaycastHit raycastHit;

			if (Physics.Raycast(Camera.main.transform.position, direction, out raycastHit, Mathf.Infinity )){
				AlphaMasking alphaMasking = raycastHit.collider.gameObject.GetComponent<AlphaMasking>();
				if(alphaMasking){
					alphaMasking .SetTransparent();
					lastWall = alphaMasking;
				}else{
					if(lastWall){
						lastWall.SetToNormal();
						lastWall = null;
				}
			}
		}
	}
}
	public void StartRayCast(){
		StopCoroutine ("DetectPlayerObstructions");
		StartCoroutine (DetectPlayerObstructions ());
	}
	public void StopRayCast(){
		StopCoroutine ("DetectPlayerObstructions");
	}
}
		