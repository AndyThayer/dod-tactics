using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAvailableTile : MonoBehaviour {

	private int posX;
	private int posY;

	void Start(){
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
	}

	void OnMouseEnter(){
		
		if( !GlobalVariables.freezeHUD ){
			int parentID = this.gameObject.GetComponent<HUDProperties>().parentID;
			int parentX = this.gameObject.GetComponent<HUDProperties>().parentX;
			int parentY = this.gameObject.GetComponent<HUDProperties>().parentY;

			if( (GlobalVariables.selectedUnit.x == parentX && GlobalVariables.selectedUnit.y == parentY) ){
				// Debug.Log("Hovering over an AVAILABLE CELL: ("+parentID+") "+parentX+" "+parentY);
				
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
