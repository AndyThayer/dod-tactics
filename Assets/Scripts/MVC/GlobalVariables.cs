using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour {

    // GAME BOARD

        // number of tiles (height x width)
        public static int boardWidth = 16;
        public static int boardHeight = 12;

        // number of pixels per tile (height x width)
        public static int tileSize = 32;

        public static int boardXOffset = 8; // Grid transform.position (X was 8)
        public static int boardYOffset = 6; // Grid transform.position y (was 6)

        // master list of each type of tile (for use as an in-house DB)
        public static TileType[] tileTypes;

        // master list of each tile on the board and what it's type is
        public static TileType[,] tilesMatrix;
        public static Tilemap tilemap;
        public static GameObject tilemapGO;
	    public static GameObject grid;
        public static Vector3Int selectedTile = new Vector3Int(0,0,0);

    // UNITS

        public static UnitType[,] unitsMatrix;
        public static int unitID;
        public static Vector3Int selectedUnit = new Vector3Int(0,0,0);
        public static Vector3Int selectedPath = new Vector3Int(0,0,0);


    // HUD
        // public static GameObject HUDInfoPanel;
        public static GameObject HUDCursor;
        public static GameObject HUDCursorThreat;
        public static GameObject HUDReadyUnit;
        // bool to track whether or not we can "disturb" HUD or other game functionality
        public static bool freezeHUD;
        public static bool freezeIconHUD;

    // HUD elements
        // - top panel unit header
        public static Text infoPanelTopHeader;
        public static GameObject infoPanelTopHeaderGO;
        // - top panel unit text
        public static GameObject infoPanelTopTextGO;
        public static Text infoPanelTopText;
        // - info panel unit header
        public static GameObject infoPanelUnitHeaderGO;
        public static Text infoPanelUnitHeader;
        // - info panel unit text
        public static GameObject infoPanelUnitTextGO;
        public static Text infoPanelUnitText;
        // - info panel unit text column 2
        public static GameObject infoPanelUnitText2GO;
        public static Text infoPanelUnitText2;
        // - info panel terrain header
        public static GameObject infoPanelTerrainHeaderGO;
        public static Text infoPanelTerrainHeader;
        // - info panel terrain text
        public static GameObject infoPanelTerrainTextGO;
        public static Text infoPanelTerrainText;
        // - info panel terrain text column 2
        public static GameObject infoPanelTerrainText2GO;
        public static Text infoPanelTerrainText2;
        // infoPanels for Units and Terrain
        public static GameObject infoPanelUnitGO;
        public static GameObject infoPanelTerrainGO;

    // PATHFINDING

    // COMBAT
        public static List<Initiative> initRoster = new List<Initiative>();
        
        // public static List<Node> currentPath;

}
