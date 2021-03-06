﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAvailableTile : MonoBehaviour {

	private int posX;
	private int posY;

	void Start(){
		// posX = (int)this.transform.position.x;
		// posY = (int)this.transform.position.y;
		posX = this.gameObject.GetComponent<HUDProperties>().posX;
		posY = this.gameObject.GetComponent<HUDProperties>().posY;
	}

	void OnMouseEnter(){

		int parentID = this.gameObject.GetComponent<HUDProperties>().parentID;
		int parentX = this.gameObject.GetComponent<HUDProperties>().parentX;
		int parentY = this.gameObject.GetComponent<HUDProperties>().parentY;
		if(GlobalVariables.tilesMatrix[ posX,posY ].defenseMod == 0){
			GlobalFunctions.DestroyGameObject("terrainStatusIconLOWER");
		}
		UnitType thisUnit = GlobalVariables.unitsMatrix [ parentX,parentY ];
		GlobalFunctions.DisplayTileInfo(posX,posY,false,true,thisUnit);
		StartCoroutine(GlobalFunctions.UpdateTileIcon(posX,posY,0.005f));
		
		if( !GlobalVariables.freezeHUD ){

			if( (GlobalVariables.selectedUnit.x == parentX && GlobalVariables.selectedUnit.y == parentY) ){
				
				GlobalFunctions.RemovePathCellsFromAllUnits();
				GlobalFunctions.DisplayPathCells(posX,posY,parentX,parentY);
				GlobalVariables.selectedPath = new Vector3Int(posX, posY, 0);

			}
		}
		
	} // end OnMouseOver

	void OnMouseExit(){

		if( !GlobalVariables.freezeHUD ){
			GlobalFunctions.RemovePathCellsFromAllUnits();
		}
		
	} // end OnMouseExit

}
