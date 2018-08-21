using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconAnimations : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void PlayIdle(){
		anim.Play("idle");
	}

	public void PlayLit(){
		anim.Play("lit");
	}

}
