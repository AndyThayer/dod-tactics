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

        //public static TileBase tile;

        // master list of each type of tile (for use as an in-house DB)
        public static TileType[] tileTypes;

        // master list of each tile on the board and what it's type is
        // public static int[,] tilesMatrix;
        public static TileType[,] tilesMatrix;
        public static Tilemap tilemap;
        public static GameObject tilemapGO;
	    public static GameObject grid;
        // public static Node[,] graph;

    // UNITS

        public static UnitType[,] unitsMatrix;
        public static int unitID;
        public static Vector3Int selectedUnit = new Vector3Int(0,0,0);
        public static Vector3Int selectedPath = new Vector3Int(0,0,0);


    // HUD
        // public static GameObject HUDInfoPanel;
        public static GameObject HUDCursor;
        public static GameObject HUDCursorThreat;
        // bool to track whether or not we can "disturb" HUD or other game functionality
        public static bool freezeHUD;
        public static bool freezeIconHUD;

    // HUD elements
        public static GameObject infoPanelUnitHeaderGO;
        public static Text infoPanelUnitHeader;
        public static GameObject infoPanelUnitTextGO;
        public static Text infoPanelUnitText;
        public static GameObject infoPanelUnitText2GO;
        public static Text infoPanelUnitText2;
        public static GameObject infoPanelTerrainHeaderGO;
        public static Text infoPanelTerrainHeader;
        public static GameObject infoPanelTerrainTextGO;
        public static Text infoPanelTerrainText;
        public static GameObject infoPanelTerrainText2GO;
        public static Text infoPanelTerrainText2;
        public static GameObject infoPanelUnitGO;
        public static GameObject infoPanelTerrainGO;
        public static GameObject infoPanelTorchesGO;

    // PATHFINDING

    // COMBATE
        public static List<Initiative> initRoster = new List<Initiative>();
        
        // public static List<Node> currentPath;

}
