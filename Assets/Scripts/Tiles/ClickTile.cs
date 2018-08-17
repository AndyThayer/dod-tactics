using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour {



	void OnMouseUp() {

		int posX = (int)this.transform.position.x;
		int posY = (int)this.transform.position.y;

		if( !GlobalVariables.freezeHUD ){

			// reset ICON state
			GlobalVariables.freezeIconHUD = false;
			// Debug.Log("ts happening");
			if(GameObject.Find("battleOptionIcon")){
				GameObject gotileIcon = GameObject.Find("battleOptionIcon");
				Destroy(gotileIcon);
			}


			if( GlobalVariables.unitsMatrix[ posX,posY ] != null ){

				// if *THERE IS* a unit on this tile
				if(GlobalVariables.selectedUnit.x == posX && GlobalVariables.selectedUnit.y == posY){
					// un-SELECT this unit
					GlobalVariables.selectedUnit = new Vector3Int(0,0,0);
					// flash this unit
					StartCoroutine(GlobalFunctions.FlashUnit(posX,posY, true));
					// Debug.Log("Unit on this tile: " + posX + " " + posY + " was already selected.");
					
					// update HUD info boxes
					GlobalFunctions.CleanUpTerrainInfoPanel();
					GlobalFunctions.CleanUpUnitInfoPanel();
					GlobalFunctions.DisplayTileInfo(posX,posY);

				// else, if *THERE IS NOT* a unit on this tile	
				// if it's their TURN as per INITIATIVE
				}else if ( 
					(GlobalVariables.unitsMatrix[ posX,posY ].unitID == GlobalVariables.initRoster[0].unitID) && 
					(GlobalVariables.unitsMatrix[ posX,posY ].canMove || GlobalVariables.unitsMatrix[ posX,posY ].canAct) 
					){

					// SELECT this unit
					GlobalVariables.selectedUnit = new Vector3Int(posX,posY,0);
					GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
					GlobalFunctions.UpdateHUDcursor(posX, posY);

					// remove available cells from everyone, then display them for this unit
					if(GlobalVariables.unitsMatrix[ posX,posY ].canMove){
						GlobalFunctions.RemoveAvailableCellsFromAllUnits();
						// display available cells
						GlobalFunctions.DisplayAvailableCells(posX, posY, true);	
						// hide ready unit cursor
						GlobalFunctions.CleanUpOldHUDreadyUnit();
					}

					// flash this unit
					StartCoroutine(GlobalFunctions.FlashUnit(posX,posY,true));

					// update HUD info boxes
					GlobalFunctions.CleanUpTerrainInfoPanel();
					GlobalFunctions.CleanUpUnitInfoPanel();
					GlobalFunctions.DisplayTileInfo(posX,posY);

				}else{
					// reset cursor and selected tile
					GlobalFunctions.RemoveAvailableCellsFromAllUnits();
					GlobalVariables.selectedUnit = new Vector3Int(0,0,0);
					GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
				}	

			}else{
				// reset cursor and selected tile
				GlobalFunctions.RemoveAvailableCellsFromAllUnits();
				GlobalVariables.selectedUnit = new Vector3Int(0,0,0);
				GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
			}

			// update HUD info boxes (does this belong at the bottom of EVERYTHING, or after SELECT and un-SELECT?)
			// GlobalFunctions.CleanUpTerrainInfoPanel();
			// GlobalFunctions.CleanUpUnitInfoPanel();
			// GlobalFunctions.DisplayTileInfo(posX,posY);
		}


		
	} // end on mouseUp

}
