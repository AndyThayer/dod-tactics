using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThreat : MonoBehaviour {

	void Start(){
		
	}

	void OnMouseDown() {

		int targetX = (int)this.transform.position.x;
		int targetY = (int)this.transform.position.y;

		int parentX = this.GetComponent<HUDProperties>().parentX;
		int parentY = this.GetComponent<HUDProperties>().parentY;

		GlobalFunctions.CombatProcessAttack(parentX,parentY,targetX,targetY);

	}

}
