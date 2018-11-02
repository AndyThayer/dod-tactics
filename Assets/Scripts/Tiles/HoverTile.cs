using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTile : MonoBehaviour {
	
	public static HoverTile Instance;
	// private GameObject availableCell;

	private int posX;
	private int posY;

	void Start(){
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
	}

	void Awake() {
        Instance = this;
    }

	void OnMouseOver() {

		int selUnitX = GlobalVariables.selectedUnit.x;
		int selUnitY = GlobalVariables.selectedUnit.y;
		int selTileX = GlobalVariables.selectedTile.x;
		int selTileY = GlobalVariables.selectedTile.y;

		if( selUnitX == 0 && selUnitY == 0 ){
			GlobalFunctions.UpdateHUDcursor(posX, posY);
			GlobalFunctions.DisplayTileInfo(posX,posY);
			if( GlobalVariables.unitsMatrix [posX,posY ] != null && 
			    !GlobalVariables.unitsMatrix[ posX,posY ].displayAvailableCells && 
				GlobalVariables.unitsMatrix[ posX,posY ].canMove ){
					// display available cells
					GlobalFunctions.DisplayAvailableCells(posX,posY);
					// hide ready unit cursor
					GlobalFunctions.CleanUpOldHUDreadyUnit();
			}
		}else{
			// Debug.Log(selUnitX +" "+ selTileX +" "+ selUnitY +" "+ selTileY);
			if( selUnitX != selTileX || selUnitY != selTileY ){
				GlobalFunctions.DisplayTileInfo(selUnitX,selUnitY,false,true);
				StartCoroutine(GlobalFunctions.UpdateTileIcon(selUnitX,selUnitY,0.005f));
			}

		}
		GlobalFunctions.CleanUpOldHUDcursorThreat();
		
    }

	void OnMouseExit(){

		if( (GlobalVariables.selectedUnit.x == 0 && GlobalVariables.selectedUnit.y == 0) ){
			int posX = (int)this.transform.position.x;
			int posY = (int)this.transform.position.y;
			GlobalFunctions.CleanUpOldHUDcursor();
			// CleanUpHUDinfoPanel();
			GlobalFunctions.CleanUpUnitInfoPanel();
			GlobalFunctions.CleanUpUnitIcons("unitIcon");
			GlobalFunctions.CleanUpTerrainInfoPanel();
			GlobalFunctions.CleanUpHUDavailable(posX,posY);
			// restore ready unit cursor
			GlobalFunctions.UpdateHUDreadyUnit( GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY );
		}
		
	}



	

}
