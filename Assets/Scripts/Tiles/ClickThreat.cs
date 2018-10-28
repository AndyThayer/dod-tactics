using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThreat : MonoBehaviour {

	void Start(){
		
	}

	void OnMouseDown() {

		int posX = (int)this.transform.position.x;
		int posY = (int)this.transform.position.y;

		int parentX = this.GetComponent<HUDProperties>().parentX;
		int parentY = this.GetComponent<HUDProperties>().parentY;

		// reset ICON state
		GlobalVariables.freezeIconHUD = false;
		GlobalFunctions.CleanUpBattleOptionIcons();

		GlobalFunctions.SpawnSwordSwoosh(parentX,parentY,posX,posY);
		if(GlobalVariables.unitsMatrix[ posX,posY ] != null){
			GlobalVariables.unitsMatrix[ posX,posY ].unitPrefab.GetComponent<UnitAnimations>().PlayBleed();
		}
		// remove threat cells
		GlobalFunctions.RemoveAvailableCellsFromAllUnits();
		// process attack
		GlobalFunctions.CombatAttack(parentX,parentY,posX,posY);
		GlobalFunctions.UpdateStamina(parentX,parentY);
		// reflect updated STA	
		GlobalFunctions.DisplayTileInfo(parentX, parentY, true, false); 

		// since STA might have changed, update availableCells
		GlobalFunctions.RefreshUnitAvailabileCells(parentX,parentY);

		// make sure you do this last, because it might NULL a unit!
		GlobalFunctions.CheckForDeadUnit(posX,posY);
		GlobalFunctions.CheckForEndOfTurn(parentX,parentY); // before possibly NULLing parent
		GlobalFunctions.CheckForDeadUnit(parentX,parentY);

	}

	
}
