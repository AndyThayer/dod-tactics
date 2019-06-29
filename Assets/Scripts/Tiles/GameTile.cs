using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {
	
	// make an encapsulated variable (private, with getters and setters)
	// for each public variable in class TileType
	public int posX;
    public int posY;

	private Enums.TileType tileType;
	// private int movementCost;

	// tileType
	public Enums.TileType GetTileType(){
		return tileType;
	}

	public void SetTileType(Enums.TileType tt){
		tileType = tt;
	}

	public int GetPosX(){
		return posX;
	}

	public void SetPosX(int tilePosX){
		posX = tilePosX;
	}

	public int GetPosY(){
		return posY;
	}

	public void SetPosY(int tilePosY){
		posY = tilePosY;
	}

}
