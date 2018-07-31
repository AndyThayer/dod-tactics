using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThreat : MonoBehaviour {

	void Start(){
		
	}

	void OnMouseUp() {

		int posX = (int)this.transform.position.x;
		int posY = (int)this.transform.position.y;

		int parentX = this.GetComponent<HUDProperties>().parentX;
		int parentY = this.GetComponent<HUDProperties>().parentY;

		// Debug.Log("\nthreat cell clicked!");
		GlobalFunctions.SpawnSwordSwoosh(parentX,parentY,posX,posY);
		if(GlobalVariables.unitsMatrix[ posX,posY ] != null){
			GlobalVariables.unitsMatrix[ posX,posY ].unitPrefab.GetComponent<UnitAnimations>().PlayBleed();
		}
		GlobalFunctions.CombatAttack(parentX,parentY,posX,posY);
		GlobalFunctions.UpdateStamina(parentX,parentY);
		// Debug.Log("\n"+posX+" "+posY+" is my target!");

		// since STA might have changed, update availableCells
		GlobalFunctions.RefreshUnitAvailabileCells(parentX,parentY);

	}

	
}
