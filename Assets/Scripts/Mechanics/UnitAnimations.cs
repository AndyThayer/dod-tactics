using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimations : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void PlayIdle(){
		anim.Play("idle");
	}

	public void PlayWalking(){
		anim.Play("walking");
	}

	public void PlayBleed(){
		anim.Play("bleed", -1, 0f); // extra params because this animation doesn't loop and needs to be rewound each time it fires
	}

}
