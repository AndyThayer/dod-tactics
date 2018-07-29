using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {
	
	// make an encapsulated variable (private, with getters and setters)
	// for each public variable in class TileType

	private Enums.TileType tileType;
	// private int movementCost;

	// tileType
	public Enums.TileType GetTileType(){
		return tileType;
	}

	public void SetTileType(Enums.TileType tt){
		tileType = tt;
	}

	// movementCost
	// public int GetMovementCost(){
	// 	return movementCost;
	// }

	// public void SetMovementCost(int mc){
	// 	movementCost = mc;
	// }

}
