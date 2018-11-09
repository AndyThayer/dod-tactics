using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverThreat : MonoBehaviour {

	public static HoverThreat Instance;

	int posX;
	int posY;

	void Start(){
		
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
	}

	void Awake() {
        Instance = this;
    }

	void OnMouseOver() {

		int parentX = this.GetComponent<HUDProperties>().parentX;
		int parentY = this.GetComponent<HUDProperties>().parentY;

		GlobalFunctions.UpdateHUDcursorThreat(posX, posY);
		if( GlobalVariables.unitsMatrix [ posX,posY ] != null && !GlobalVariables.freezeHUD){
			GlobalFunctions.DisplayCompareUnits( parentX,parentY,posX,posY );
			GlobalVariables.freezeHUD = true;
		}

    }

	void OnMouseExit(){
		
		GlobalFunctions.CleanUpOldHUDcursorThreat();
		GlobalFunctions.CleanUpCompareUnits();
		// GlobalFunctions.DestroyGameObject("compareUnitIconAtt");
		// GlobalFunctions.DestroyGameObject("compareUnitIconDef");
		// GlobalVariables.infoPanelTopTextACC.text = "";
		// GlobalVariables.infoPanelTopTextDEF.text = "";

		GlobalVariables.freezeHUD = false;

	}

}
