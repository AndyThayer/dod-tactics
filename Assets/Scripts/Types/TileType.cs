using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType {

	// make a matching encapsulated variable in class GameTile
	// for each public variable here

	public Enums.TileType tileType;
	public int movementCost;
    public int staminaCost;
	public int defenseBonus;
    public string name;

    public GameObject tilePrefab;

	public TileType(Enums.TileType type){
        tileType = type;
        switch(type){
            case Enums.TileType.Castle:
                name = "Castle";
                movementCost = 1;
                staminaCost = 1;
				defenseBonus = 30;
                break;
            case Enums.TileType.Bridge:
                name = "Bridge";
                movementCost = 1;
                staminaCost = 1;
				defenseBonus = 0;
                break;
            case Enums.TileType.Grass:
                name = "Grass";
                movementCost = 1;
                staminaCost = 2;
				defenseBonus = 0;
                break;
            case Enums.TileType.GrassRough:
                name = "Rough Grass";
                movementCost = 2;
                staminaCost = 3;
				defenseBonus = 0;
                break;
            case Enums.TileType.WaterShallow:
                name = "Shallow Water";
                movementCost = 3;
                staminaCost = 10;
				defenseBonus = 0;
                break;
            case Enums.TileType.WaterDeep:
                name = "Deep Water";
                movementCost = 9;
                staminaCost = 25;
				defenseBonus = 0;
                break;
			case Enums.TileType.Woods:
                name = "Woods";
                movementCost = 2;
                staminaCost = 4;
				defenseBonus = 5;
                break;
            case Enums.TileType.WoodsDense:
                name = "Dense Woods";
                movementCost = 3;
                staminaCost = 5;
				defenseBonus = 10;
                break;
        }
    }


}
