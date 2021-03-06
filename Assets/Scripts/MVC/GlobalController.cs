﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// board / game setup
		GlobalFunctions.InitializeBoardVariables("Plains"); // or whatever the Tilemap name is 
		// GlobalFunctions.LoadFromTilemap();
		GlobalFunctions.InitializeMatrices();
		gameObject.GetComponent<GlobalFunctions>().LoadMapFromTilemap();
		GlobalFunctions.InitializeHUDObjects();
		// start off by not displaying HUD unit panel
		GlobalFunctions.CleanUpUnitInfoPanel();
		GlobalFunctions.DestroyGameObject("unitIcon");

		// we don't need to see the original tilemap because we've instantiated prefab tiles instead
		GlobalVariables.tilemapGO.SetActive(false);

		// team 1
		// gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.Hunter, 2,2, GlobalFunctions.FindDirection(Enums.Direction.Right), 1);
		gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.Gatherer, 1,9, GlobalFunctions.FindDirection(Enums.Direction.Right), 1);
        // team 2
        gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.BarbedToad, 5,9, GlobalFunctions.FindDirection(Enums.Direction.Up), 2);
        // gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.BarbedToad, 6,11, GlobalFunctions.FindDirection(Enums.Direction.Up), 2);
        //  gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.SaberToothWolf, 8,11, GlobalFunctions.FindDirection(Enums.Direction.Left), 2);
        //gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.BarbedToad, 11,11, GlobalFunctions.FindDirection(Enums.Direction.Left), 1);

        //gameObject.GetComponent<GlobalFunctions>().SpawnUnit(Enums.UnitType.BarbedToad, 11, 11, GlobalFunctions.FindDirection(Enums.Direction.Left), 2);

        //  team 2 at 6,11 while team 1 is present is infinite loop?


        // run this after spawning units so that we know where all other units are beforehand
        GlobalFunctions.RefreshUnitAvailabileCells();

		GlobalFunctions.UpdateInitiative();
		// GlobalVariables.infoPanelTopHeader.text = "Round 1";


	}

}
