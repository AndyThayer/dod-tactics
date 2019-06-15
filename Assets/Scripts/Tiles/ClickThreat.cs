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

		// reset ICON state
		GlobalVariables.freezeIconHUD = false;
		// GlobalFunctions.CleanUpBattleOptionIcons();
		GlobalFunctions.DestroyGameObject("battleOptionIcon");
		GlobalFunctions.DestroyGameObject("statusIconLOWER");
		GlobalFunctions.CleanUpCompareUnits();

		GlobalFunctions.SpawnSwordSwoosh(parentX,parentY,targetX,targetY);
		if(GlobalVariables.unitsMatrix[ targetX,targetY ] != null){
			GlobalVariables.unitsMatrix[ targetX,targetY ].unitPrefab.GetComponent<UnitAnimations>().PlayBleed();
		}
		// remove threat cells
		GlobalFunctions.RemoveAvailableCellsFromAllUnits();
		// process attack
		GlobalFunctions.CombatAttack(parentX,parentY,targetX,targetY);
		GlobalFunctions.UpdateStamina(parentX,parentY);

		// reflect updated STA	
		GlobalFunctions.DisplayTileInfo(parentX, parentY, true, false); 

		// since STA might have changed, update availableCells
		GlobalFunctions.RefreshUnitAvailabileCells(parentX,parentY);

		// make sure you do this last, because it might NULL a unit!
		GlobalFunctions.CheckForDeadUnit(targetX,targetY);
		GlobalFunctions.CheckForEndOfTurn(parentX,parentY); // before possibly NULLing parent
		GlobalFunctions.CheckForDeadUnit(parentX,parentY);

		// change facing
		Quaternion quatDir = GlobalFunctions.FindDirectionToFaceTarget(parentX, parentY, targetX, targetY);
		GlobalVariables.unitsMatrix[ parentX,parentY ].unitPrefab.transform.rotation = quatDir;

		// clean up
		GlobalFunctions.CleanUpAfterAction(parentX,parentY);

	}

}
