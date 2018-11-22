using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAvailableTile : MonoBehaviour {

	void OnMouseDown() {

		if( !GlobalVariables.freezeHUD ){
			int posX = (int)this.transform.position.x;
			int posY = (int)this.transform.position.y;

			int parentX = this.GetComponent<HUDProperties>().parentX;
			int parentY = this.GetComponent<HUDProperties>().parentY;

			GlobalVariables.unitsMatrix[ parentX,parentY ].unitPrefab.GetComponent<MovementUnit>().MoveUnit(parentX,parentY,posX,posY);

		}else{
			Debug.Log("Trying to click an available cell while HUD is frozen!");
		}
		

	}

}
