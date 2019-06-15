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
        // public static Vector3Int hoverTile = new Vector3Int(0,0,0);

    // UNITS

        public static UnitType[,] unitsMatrix;
        public static int unitID;
        public static Vector3Int selectedUnit = new Vector3Int(0,0,0);
        public static Vector3Int displayUnit = new Vector3Int(0,0,0);
        public static Vector3Int selectedPath = new Vector3Int(0,0,0);
        public static UnitTypeStatusIcons unitStatusIcons = new UnitTypeStatusIcons();


    // HUD
        // public static GameObject HUDInfoPanel;
        public static GameObject HUDCursor;
        public static GameObject HUDCursorThreat;
        public static GameObject HUDReadyUnit;
        // bool to track whether or not we can "disturb" HUD or other game functionality
        public static bool freezeHUD;
        public static bool freezeIconHUD;

        public static float unitIconMiddlePanelX = 17.575f;
        public static float unitIconMiddlePanelY = 8.15f; // 8.05f
        public static float statusIconLowerPanelX = 21.15f;
        public static float statusIconLowerPanelY = 2.99275f;

    // HUD elements
        // - top panel unit header
        public static Text infoPanelTopHeader;
        public static GameObject infoPanelTopHeaderGO;
        // - top panel unit text
        public static GameObject infoPanelTopTextGO;
        public static Text infoPanelTopText;
        // - top panel unit text ACC
        public static GameObject infoPanelTopTextACCGO;
        public static Text infoPanelTopTextACC;
        // - top panel unit text DEF
        public static GameObject infoPanelTopTextDEFGO;
        public static Text infoPanelTopTextDEF;
        // - top panel unit text DEF
        public static GameObject infoPanelTopTextACCvsDEFGO;
        public static Text infoPanelTopTextACCvsDEF;

        // - top panel unit text Left
        public static GameObject infoPanelTopTextLeftGO;
        public static Text infoPanelTopTextLeft;
        // - top panel unit text Right
        public static GameObject infoPanelTopTextRightGO;
        public static Text infoPanelTopTextRight;

        // - info panel unit header
        public static GameObject infoPanelUnitHeaderGO;
        public static Text infoPanelUnitHeader;
        // - info panel unit text
        public static GameObject infoPanelUnitTextGO;
        public static Text infoPanelUnitText;
        // - info panel unit text column 2
        public static GameObject infoPanelUnitText2GO;
        public static Text infoPanelUnitText2;
        // - info panel unit text column 3
        public static GameObject infoPanelUnitText3GO;
        public static Text infoPanelUnitText3;
        // info panel HP, STA, BAL bars
        // - HP
        public static GameObject barHPbgGO;
        public static Image barHPbg;
        public static GameObject barHPGO;
        public static Image barHP;
        // - BAL
        public static GameObject barBALbgGO;
        public static Image barBALbg;
        public static GameObject barBALGO;
        public static Image barBAL;     
        // - STA
        public static GameObject barSTAbgGO;
        public static Image barSTAbg;
        public static GameObject barSTAGO;
        public static Image barSTA;
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
        public static int round = 0;
        public static int lastRound = 0;
        public static int lastUnitID = 0;
        
        // base DEF bonus for rallying
        public static int rallyValue = 5; 

        // penalty to accuracy when making a heavy attack
        public static int heavyAttackAccMod = -5;

        // bonus to damage roll when making a heavy attack (only if unit.highDamage * heavyAttackMod < heavyAttackBonus)
        public static int heavyAttackBonus = 5;

        // bonus to damage roll when making a heavy attack (minimum should be = heavyAttackBonus)
        public static float heavyAttackMod = 1.2f;

        /*
         what we divide the percentage that BAL impacts attack and defend rolls
         70 BAL would be: attack/defend roll * (1 - (.3 * BAL mod))
         */
        public static float BALmod = .5f; 

        public static float critMultiplier = 2f;

        public static int lightAttackSTAcost = 10;
        public static int heavyAttackSTAcost = 30;
        public static int lightAttackBALworth = 10;
        public static int heavyAttackBALworth = 30;

}
