using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour {



	void OnMouseUp() {

		int posX = (int)this.transform.position.x;
		int posY = (int)this.transform.position.y;
		GlobalFunctions.CleanUpUnitIcons("terrainStatusIconLOWER");

		if( !GlobalVariables.freezeHUD ){

			// reset ICON state
			GlobalVariables.freezeIconHUD = false;
			GlobalFunctions.CleanUpBattleOptionIcons();

			if( GlobalVariables.unitsMatrix[ posX,posY ] != null ){

				// if *THERE IS* a selected unit on this tile
				if(GlobalVariables.selectedUnit.x == posX && GlobalVariables.selectedUnit.y == posY){
					// un-SELECT this unit
					GlobalVariables.selectedUnit = new Vector3Int(0,0,0);
					// flash this unit
					StartCoroutine(GlobalFunctions.FlashUnit(posX,posY, true));
					// Debug.Log("Unit on this tile: " + posX + " " + posY + " was already selected.");
					
					// update HUD info boxes
					GlobalFunctions.CleanUpTerrainInfoPanel();
					GlobalFunctions.CleanUpUnitInfoPanel();
					GlobalFunctions.CleanUpUnitIcons("unitIcon");
					GlobalFunctions.CleanUpUnitIcons("terrainStatusIconLOWER");
					GlobalFunctions.DisplayTileInfo(posX,posY);

				// else, if *THERE IS NOT* a selected unit on this tile	
				// if it's their TURN as per INITIATIVE
				}else if ( 
					(GlobalVariables.unitsMatrix[ posX,posY ].unitID == GlobalVariables.initRoster[0].unitID) && 
					(GlobalVariables.unitsMatrix[ posX,posY ].canMove || GlobalVariables.unitsMatrix[ posX,posY ].canAct) 
					){

					// wipe battle log in upper panel
					GlobalFunctions.CleanUpBattleLog();

					// SELECT this unit
					GlobalVariables.selectedUnit = new Vector3Int(posX,posY,0);
					GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
					GlobalFunctions.UpdateHUDcursor(posX, posY);

					// remove available cells from everyone, then display them for this unit
					if(GlobalVariables.unitsMatrix[ posX,posY ].canMove){
						GlobalFunctions.RemoveAvailableCellsFromAllUnits();
						// display available cells
						GlobalFunctions.DisplayAvailableCells(posX, posY, true);	
					}

					// flash this unit
					StartCoroutine(GlobalFunctions.FlashUnit(posX,posY,true));

					// update HUD info boxes
					GlobalFunctions.CleanUpTerrainInfoPanel();
					GlobalFunctions.CleanUpUnitInfoPanel();
					GlobalFunctions.CleanUpUnitIcons("unitIcon");
					GlobalFunctions.CleanUpUnitIcons("terrainStatusIconLOWER");
					GlobalFunctions.DisplayTileInfo(posX,posY);

					// hide ready unit cursor
					GlobalFunctions.CleanUpOldHUDreadyUnit();

				}else{
					// reset cursor and selected tile
					GlobalFunctions.RemoveAvailableCellsFromAllUnits();
					GlobalVariables.selectedUnit = new Vector3Int(0,0,0);
					GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
					
					// udpate unit info panel
					GlobalFunctions.CleanUpUnitInfoPanel();
					GlobalFunctions.CleanUpUnitIcons("unitIcon");
					GlobalFunctions.CleanUpUnitIcons("terrainStatusIconLOWER");
					GlobalFunctions.DisplayUnitIcon(
						posX, 
						posY, 
						GlobalVariables.unitIconMiddlePanelX, 
						GlobalVariables.unitIconMiddlePanelY, 
						"unitIcon", 
						GlobalFunctions.FindDirection(Enums.Direction.Down)
					);
				}	

			}else{
				// reset cursor and selected tile
				GlobalFunctions.RemoveAvailableCellsFromAllUnits();
				GlobalVariables.selectedUnit = new Vector3Int(0,0,0);
				GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
				// restore ready unit cursor
				GlobalFunctions.UpdateHUDreadyUnit( GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY );
			}

			// update HUD info boxes (does this belong at the bottom of EVERYTHING, or after SELECT and un-SELECT?)
			// GlobalFunctions.CleanUpTerrainInfoPanel();
			// GlobalFunctions.CleanUpUnitInfoPanel();
			// GlobalFunctions.DisplayTileInfo(posX,posY);
		}


		
	} // end on mouseUp

}
