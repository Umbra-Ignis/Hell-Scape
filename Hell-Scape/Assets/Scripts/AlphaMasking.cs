using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMasking : MonoBehaviour {

	public Color transparentColor;

	private Color initialColor;

	// Use this for initialization
	void Start () {
		initialColor = GetComponent <Renderer>().material.color;
	}
	public void SetTransparent(){
		GetComponent<Renderer>().material.color = transparentColor;
	}
	public void SetToNormal(){
		GetComponent<Renderer>().material.color = initialColor;
	}
}
