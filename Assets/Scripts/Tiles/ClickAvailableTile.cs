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

			// Debug.Log(parentX+" "+parentY+" is my parent!");
			// Debug.Log("\n"+posX+" "+posY+" is my target!");

			GlobalVariables.unitsMatrix[ parentX,parentY ].unitPrefab.GetComponent<MovementUnit>().MoveUnit(parentX,parentY,posX,posY);

			// GlobalFunctions.CheckForEndOfTurn(parentX,parentY);
		}else{
			Debug.Log("Trying to click an available cell while HUD is frozen!");
		}
		

	}

}
