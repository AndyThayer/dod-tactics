using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// board / game setup
		GlobalFunctions.InitializeBoardVariables();
		// GlobalFunctions.LoadFromTilemap();
		GlobalFunctions.InitializeMatrices();
		gameObject.GetComponent<GlobalFunctions>().LoadMapFromTilemap();
		GlobalFunctions.InitializeHUDObjects();
		// start off by not displaying HUD unit panel
		GlobalFunctions.CleanUpUnitInfoPanel();

		// we don't need to see the original tilemap because we've instantiated prefab tiles instead
		GlobalVariables.tilemapGO.SetActive(false);


		gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.Hunter, 14,2, GlobalFunctions.FindDirection(Enums.Direction.Right), 1);
		gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.BarbedToad, 15,3, GlobalFunctions.FindDirection(Enums.Direction.Left), 2);
		gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.SaberToothWolf, 16,2, GlobalFunctions.FindDirection(Enums.Direction.Down), 2);
		// gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.Hunter, 8,4, GlobalFunctions.FindDirection(Enums.Direction.Down));
		// gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.Hunter, 8,10, GlobalFunctions.FindDirection(Enums.Direction.Left));

		// GlobalFunctions.FindAvailableCells();

		// run this after spawning units so that we know where all other units are beforehand
		GlobalFunctions.RefreshUnitAvailabileCells();

		// foreach (Vector3Int v3 in GlobalVariables.unitsMatrix[ 1,12 ].avalablePaths[ 1,10 ])
		// {

		GlobalFunctions.UpdateInitiative();
		GlobalVariables.infoPanelTopHeader.text = "Woods of Thaden";


	}

}
