using System;
using System.Collections;
using System.Collections.Generic;
// using System.Random;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GlobalFunctions : MonoBehaviour {

    public static GlobalFunctions Instance;

    // prefab units
   

    // HUD objects
    // public GameObject HUDPanelTerrain;
    // public GameObject HUDPanelUnit;
    public GameObject HUDCursor;
    public GameObject HUDCursorThreat;
    public GameObject HUDReadyUnit;
    public GameObject HUDPathCell;
    public GameObject HUDAvailableCell;
    public GameObject HUDAvailableCellSelf;
    public GameObject HUDThreatCell;
    public GameObject ICONHeavyAttack;
    public GameObject ICONLightAttack;
    public GameObject ICONRally;
    public GameObject ICONUseItem;
    public GameObject ICONCastSpell;
    public GameObject ICONSpecialAbility;

    // HUD misc
    public GameObject swordSwoosh;

    // tileTypes
    public TileType[] tileTypes;

    // unit prefabs
     public GameObject hunter;
     public GameObject barbed_toad;
     public GameObject saber_tooth_wolf;

    // prefab Tiles
    public GameObject castleTile;
    public GameObject bridgeHorizTile;
    public GameObject bridgeVertTile;
    public GameObject grassTile;
    public GameObject grassRoughTile;
    public GameObject waterTile;
    public GameObject waterBTile;
    public GameObject waterBCornersTile;
    public GameObject waterBLTile;
    public GameObject waterBLCornerTile;
    public GameObject waterBRCornerTile;
    public GameObject waterLTile;
    public GameObject waterLCornersTile;
    public GameObject waterRTile;
    public GameObject waterRCornersTile;
    public GameObject waterRBTile;
    public GameObject waterRLTile;
    public GameObject waterTTile;
    public GameObject waterTCornersTile;
    public GameObject waterTBTile;
    public GameObject waterTLTile;
    public GameObject waterTLCornerTile;
    public GameObject waterTRTile;
    public GameObject waterTRCornerTile;
    public GameObject woodsTile;
    public GameObject woodsDenseTile;
    

    void Awake() {
        Instance = this;
    }

    // Use this for initialization
    void Start() {
        // initialize global tileTypes array
        GlobalVariables.tileTypes = new TileType[tileTypes.Length]; // offset so we can ignore zero-index
        for(int i = 0; i < tileTypes.Length; i++){
            GlobalVariables.tileTypes[(int)tileTypes[i].tileType] = tileTypes[i];
        }
        // Debug.Log("what is waterDeep MV cost? " + GlobalVariables.tileTypes[(int)Enums.TileType.WaterDeep].movementCost);
        
    }

    public static void InitializeMatrices(){
        // offset by 1 so we can match "real coords" with indices in the array
        // (we'll ignore the zero x and y axis)
        GlobalVariables.tilesMatrix = new TileType[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        GlobalVariables.unitsMatrix = new UnitType[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        for(int c = 1; c < GlobalVariables.unitsMatrix.GetLength(0); c++){
            for(int r = 1; r < GlobalVariables.unitsMatrix.GetLength(1); r++){
                GlobalVariables.unitsMatrix[ c,r ] = null;
            }
        }
    }

    public static void InitializeBoardVariables(){
        GlobalVariables.grid = GameObject.FindGameObjectWithTag("Grid");
		GlobalVariables.tilemapGO = GlobalVariables.grid.transform.Find("Tilemap").gameObject;
        GlobalVariables.tilemap = GlobalVariables.tilemapGO.GetComponent<Tilemap>();
    }

    public static void InitializeHUDObjects(){
        // GlobalVariables.HUDinfoPanel = HUDinfoPanel;
        // GlobalVariables.HUDInfoPanel = Instantiate(Instance.HUDInfoPanel, new Vector3(-5, -5, 0), Quaternion.identity);
        // GlobalVariables.HUDInfoPanel.SetActive(false);
        // GlobalVariables.HUDInfoPanel.name = "HUD_info_panel";

        // HUD cursor
        GlobalVariables.HUDCursor = Instantiate(Instance.HUDCursor, new Vector3(-1, -1, 0), Quaternion.identity);
        GlobalVariables.HUDCursor.SetActive(false);
        GlobalVariables.HUDCursor.name = "HUD_cursor";

        // HUD cursor threat
        GlobalVariables.HUDCursorThreat = Instantiate(Instance.HUDCursorThreat, new Vector3(-1, -1, 0), Quaternion.identity);
        GlobalVariables.HUDCursorThreat.SetActive(false);
        GlobalVariables.HUDCursorThreat.name = "HUD_cursor_threat";

        // HUD ready unit
        GlobalVariables.HUDReadyUnit = Instantiate(Instance.HUDReadyUnit, new Vector3(-1, -1, 0), Quaternion.identity);
        GlobalVariables.HUDReadyUnit.SetActive(false);
        GlobalVariables.HUDReadyUnit.name = "HUD_ready_unit";

        // HUD text
        // - top panel unit header
        GlobalVariables.infoPanelTopHeaderGO = GameObject.Find("InfoPanelTopHeader");
        GlobalVariables.infoPanelTopHeader = GlobalVariables.infoPanelTopHeaderGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopHeader.text = "";
        // - top panel unit text
        GlobalVariables.infoPanelTopTextGO = GameObject.Find("InfoPanelTopText");
        GlobalVariables.infoPanelTopText = GlobalVariables.infoPanelTopTextGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopText.text = "";
        // - info panel unit header
        GlobalVariables.infoPanelUnitHeaderGO = GameObject.Find("InfoPanelUnitHeader");
        GlobalVariables.infoPanelUnitHeader = GlobalVariables.infoPanelUnitHeaderGO.GetComponent<Text>();
        GlobalVariables.infoPanelUnitHeader.text = "";
        // - info panel unit text
        GlobalVariables.infoPanelUnitTextGO = GameObject.Find("InfoPanelUnitText");
        GlobalVariables.infoPanelUnitText = GlobalVariables.infoPanelUnitTextGO.GetComponent<Text>();
        GlobalVariables.infoPanelUnitText.text = "";
        // - info panel unit text column 2
        GlobalVariables.infoPanelUnitText2GO = GameObject.Find("InfoPanelUnitText2");
        GlobalVariables.infoPanelUnitText2 = GlobalVariables.infoPanelUnitText2GO.GetComponent<Text>();
        GlobalVariables.infoPanelUnitText2.text = "";
        // - info panel terrain header
        GlobalVariables.infoPanelTerrainHeaderGO = GameObject.Find("InfoPanelTerrainHeader");
        GlobalVariables.infoPanelTerrainHeader = GlobalVariables.infoPanelTerrainHeaderGO.GetComponent<Text>();
        GlobalVariables.infoPanelTerrainHeader.text = "";
        // - info panel terrain text
        GlobalVariables.infoPanelTerrainTextGO = GameObject.Find("InfoPanelTerrainText");
        GlobalVariables.infoPanelTerrainText = GlobalVariables.infoPanelTerrainTextGO.GetComponent<Text>();
        GlobalVariables.infoPanelTerrainText.text = "";
        // - info panel terrain text column 2
        GlobalVariables.infoPanelTerrainText2GO = GameObject.Find("InfoPanelTerrainText2");
        GlobalVariables.infoPanelTerrainText2 = GlobalVariables.infoPanelTerrainText2GO.GetComponent<Text>();
        GlobalVariables.infoPanelTerrainText2.text = "";
        // infoPanels for Units and Terrain
        GlobalVariables.infoPanelTerrainGO = GameObject.Find("HUD_side_panel_bottom");
        GlobalVariables.infoPanelTerrainGO.SetActive(false);
        GlobalVariables.infoPanelUnitGO = GameObject.Find("HUD_side_panel_middle");


        // GlobalVariables.infoPanelTerrainGO = Instantiate(Instance.HUDPanelTerrain, new Vector3(19.175f, 2, 0), Quaternion.identity);
        // GlobalVariables.infoPanelTerrainGO.name = "HUD_info_panel_terrain";
        // GlobalVariables.infoPanelUnitGO = Instantiate(Instance.HUDPanelUnit, new Vector3(19.175f, 6.5f, 0), Quaternion.identity);
        // GlobalVariables.infoPanelUnitGO.name = "HUD_info_panel_units";
        // GlobalVariables.battleOptionHeavyAttack = GameObject.Find("icon_heavy_attack");
    }

   

    public void LoadMapFromTilemap(){

        // GameObject tilePrefab;
        // Enums.TileType type;
        // GameObject MT = GameObject.Find("Map Tiles");
        int posX;
        int posY;
        TileBase tile;

        // cycle through every tile on the map
        for (int i = 0; i < GlobalVariables.boardWidth; i++) {
            for (int j = 0; j < GlobalVariables.boardHeight; j++) {
                tile = GlobalVariables.tilemap.GetTile(new Vector3Int( (i-GlobalVariables.boardXOffset), (j-GlobalVariables.boardYOffset), 0 ));
                posX = (i+1);
                posY = (j+1);
                switch(tile.name){
                    case "castle":
                        BuildTile(posX, posY, castleTile, Enums.TileType.Castle, tile.name);
                        break;
                    case "bridge_horiz":
                        BuildTile(posX, posY, bridgeHorizTile, Enums.TileType.Bridge, tile.name);
                        break;
                    case "bridge_vert":
                        BuildTile(posX, posY, bridgeVertTile, Enums.TileType.Bridge, tile.name);
                        break;
                    case "grass":
                        BuildTile(posX, posY, grassTile, Enums.TileType.Grass, tile.name);
                        break;
                    case "grass_rough":
                        BuildTile(posX, posY, grassRoughTile, Enums.TileType.GrassRough, tile.name);
                        break;
                    case "water":
                        BuildTile(posX, posY, waterTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_B":
                        BuildTile(posX, posY, waterBTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_B_corners":
                        BuildTile(posX, posY, waterBCornersTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_BL":
                        BuildTile(posX, posY, waterBLTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_BL_corner":
                        BuildTile(posX, posY, waterBLCornerTile, Enums.TileType.WaterShallow, tile.name);
                        break;
                    case "water_BR_corner":
                        BuildTile(posX, posY, waterBRCornerTile, Enums.TileType.WaterShallow, tile.name);
                        break;
                    case "water_L":
                        BuildTile(posX, posY, waterLTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_L_corners":
                        BuildTile(posX, posY, waterLCornersTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_R":
                        BuildTile(posX, posY, waterRTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_R_corners":
                        BuildTile(posX, posY, waterRCornersTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_RB":
                        BuildTile(posX, posY, waterRBTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_RL":
                        BuildTile(posX, posY, waterRLTile, Enums.TileType.WaterShallow, tile.name);
                        break;
                    case "water_T":
                        BuildTile(posX, posY, waterTTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_T_corners":
                        BuildTile(posX, posY, waterTCornersTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_TB":
                        BuildTile(posX, posY, waterTBTile, Enums.TileType.WaterShallow, tile.name);
                        break;
                    case "water_TL":
                        BuildTile(posX, posY, waterTLTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_TL_corner":
                        BuildTile(posX, posY, waterTLCornerTile, Enums.TileType.WaterShallow, tile.name);
                        break;
                    case "water_TR":
                        BuildTile(posX, posY, waterTRTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_TR_corner":
                        BuildTile(posX, posY, waterTRCornerTile, Enums.TileType.WaterShallow, tile.name);
                        break;
                    case "woods":
                        BuildTile(posX, posY, woodsTile, Enums.TileType.Woods, tile.name);
                        break;
                    case "woods_dense":
                        BuildTile(posX, posY, woodsDenseTile, Enums.TileType.WoodsDense, tile.name);
                        break;
                } // end switch
               
            }
        }

    } // end LoadFromTilemap

    private void BuildTile(int posX, int posY, GameObject tilePrefab, Enums.TileType type, string rawName){
        // find parent container
        GameObject MT = GameObject.Find("Map Tiles");
        // create an instance and add tileType to matrix
        TileType tile = new TileType(type);
        // GlobalVariables.tilesMatrix[posX,posY] = (int)type;
        
        // spawn prefab, set its name, and add it to parent container
        GameObject tilePrefabGO = Instantiate(tilePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
        tilePrefabGO.name = posX + "_" + posY + "_" + rawName + "_tile";
        tilePrefabGO.transform.parent = MT.transform;
        tilePrefabGO.GetComponent<GameTile>().SetTileType(type);
        tile.tilePrefab = tilePrefabGO;

        GlobalVariables.tilesMatrix[ posX,posY ] = (tile);
    }

    public void SpawnUnit(Enums.UnitType type, int posX, int posY, Quaternion direction, int team){
        // find parent container
        GameObject Units = GameObject.Find("Units");
        // create an instance and add it to the matrix
        UnitType character = new UnitType(type);
        // initialze a list in each index of availablePaths
        for(int c = 1; c < character.avalablePaths.GetLength(0); c++){
            for(int r = 1; r < character.avalablePaths.GetLength(1); r++){
                // character.avalablePaths[ c,r ] = new List<Vector3Int>();
                character.avalablePaths[ c,r ] = new List<MovementNode>();
            }
        }

        character.team = team;
        GlobalVariables.unitsMatrix[posX,posY] = character;

        // determine which prefab to use
        GameObject charPrefab = hunter;
        switch(type){
            case Enums.UnitType.Hunter:
                charPrefab = hunter;
                break;
            case Enums.UnitType.BarbedToad:
                charPrefab = barbed_toad;
                break;
            case Enums.UnitType.SaberToothWolf:
                charPrefab = saber_tooth_wolf;
                break;
        }

        // spawn prefab, set its name, and add it to parent container
        GameObject charPrefabGO = Instantiate(charPrefab, new Vector3(posX, posY, 0), direction);
        charPrefabGO.name = "character_" + type.ToString() + "_" + character.unitID;
        charPrefabGO.transform.parent = Units.transform;
        character.unitPrefab = charPrefabGO;
    }





    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ***         *******    ******          ***  ******  ************************************************************************************************
    // ***  ******  ****   **   ********  *******  ******  ************************************************************************************************
    // ***  *****  ****  ******  *******  *******  ******  ************************************************************************************************
    // ***        *****          *******  *******          ************************************************************************************************    
    // ***  ***********  ******  *******  *******  ******  ************************************************************************************************
    // ***  ***********  ******  *******  *******  ******  ************************************************************************************************
    // ***  ***********  ******  *******  *******  ******  ************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************




   
    public static AvailableCells FindAvailableCells(float movement, float stamina, int posX, int posY){
        
        // reset each list in each index of availablePaths for this unit
        for(int x = 1; x < GlobalVariables.unitsMatrix[ posX,posY ].avalablePaths.GetLength(0); x++){
            for(int y = 1; y < GlobalVariables.unitsMatrix[ posX,posY ].avalablePaths.GetLength(1); y++){
                GlobalVariables.unitsMatrix[ posX,posY ].avalablePaths[ x,y ].Clear();
            }
        }

        // create wrapper for MV and STA tallies
        AvailableCells ac = new AvailableCells();

        // add 1 to these array indices so we can 1 : 1 the coords (and just ignore the zero indices)
        string[,] available = new string[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        string[,] availableSTA = new string[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        ac.available = available;
        ac.availableSTA = availableSTA;
        bool[,] considered = new bool[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        Vector3Int source = new Vector3Int(posX,posY,0);
        // float startingPoints = movement;
        // int thisMV;
        // float MVcost;
        ac.available[ source.x,source.y ] = movement.ToString();
        ac.availableSTA[ source.x,source.y ] = stamina.ToString();
        // summon GF to get around weird static function object reference req's
        GlobalFunctions GF = GameObject.Find("Controller").GetComponent<GlobalFunctions>();
        UnitType thisUnit = GlobalVariables.unitsMatrix [ posX,posY ];
        int STAdecrementer = 100; // evaluate STA trail from highest to lowest

        bool processing = true;
        int inc = 0;
        while(processing || inc >= 10000){
            for(int c = 1; c < ac.available.GetLength(0); c++){
                for(int r = 1; r < ac.available.GetLength(1); r++){
                    if( ac.available[ c,r ] != null && !considered [ c,r ] && Int32.Parse(ac.availableSTA[ c,r ]) == STAdecrementer ){
 
                        // Debug.Log("avai STA cr: "+Int32.Parse(ac.availableSTA[ c,r ])+" and STAdec: "+STAdecrementer);
                        // eventually add a check to NOT BE ALE TO PASS THROUGH cells occupied by enemies
                        // you can pass through friendly cells, just can't park there
                        // NOTE: this happens in CheckForDirectionalAvailability()

                        // Up
                        if( (r+1) <= GlobalVariables.boardHeight){
                            int dirC = c;
                            int dirR = (r+1);
                            ac = GF.CheckForDirectionalAvailablity(ac, c, r, dirC, dirR, thisUnit);
                        }

                        // Down
                        if( (r-1) > 0){
                            int dirC = c;
                            int dirR = (r-1);
                            ac = GF.CheckForDirectionalAvailablity(ac, c, r, dirC, dirR, thisUnit);
                        }

                        // Left
                        if( (c-1) > 0){
                            int dirC = (c-1);
                            int dirR = r;
                            ac = GF.CheckForDirectionalAvailablity(ac, c, r, dirC, dirR, thisUnit);
                        }

                        // Right
                        if( (c+1) <= GlobalVariables.boardWidth){
                            int dirC = (c+1);
                            int dirR = r;
                            ac = GF.CheckForDirectionalAvailablity(ac, c, r, dirC, dirR, thisUnit);
                        }

                        considered[ c,r ] = true;
                        // Debug.Log(">>>>>>>>>>>>>>> considered: "+c+" "+r);
                        // GF.FindBestPath(ac.availableSTA,c,r,source);
                        
                        // we're done processing the while loop...
                        // unless there are any available cells that we haven't yet considered
                        processing = false; 
                        for(int c2 = 1; c2 < ac.available.GetLength(0); c2++){
                            for(int r2 = 1; r2 < ac.available.GetLength(1); r2++){
                                if(ac.available[ c2,r2 ] != null){
                                    if( !considered[ c2,r2 ] ){
                                        processing = true;
                                    }
                                }
                            }
                        }

                    } // end available != null
                    
                }
            }
            inc++; // just a safety net to ensure that we don't infinitely loop
            if(inc >= 10000){
                processing = false;
                Debug.Log("Whoa! We hit the infinite loop safety net in FindAvailableCells()");
            }
            STAdecrementer--;
        } // end while(processing)

        // now that we've fully populated available[]
        // lets update the best paths to take in that matrix
        for(int c = 1; c < available.GetLength(0); c++){
            for(int r = 1; r < available.GetLength(1); r++){
                if(available[ c,r ] != null ){
                    // -1 z index so that it lays "on top of" map tiles
                    GF.FindBestPath(ac.availableSTA,c,r,source);
                    // Debug.Log("available: "+c+" "+r);
                }
            }
        }

        // Debug.Log(source.ToString() + ": " + inc + " times through FindAvailableCells()");
        return ac;
    
    } // end FindAvailableCells()

    private AvailableCells CheckForDirectionalAvailablity(AvailableCells acIn, int sourceC, int sourceR, int dirC, int dirR, UnitType thisUnit){
        
        // Debug.Log("\n"+sourceC+" "+sourceR);
        // Debug.Log(dirC+" "+dirR);

        // if(sourceC == 6 && sourceR == 6 && thisUnit.unitType == Enums.UnitType.SaberToothWolf){
        //     Debug.Log("\ndirCR: "+dirC+" "+dirR);
        //     Debug.Log("availableSTA for dirCR "+acIn.availableSTA[dirC,dirR]);
        //     Debug.Log("sourceCR: "+sourceC+" "+sourceR);
        //     Debug.Log("availableSTA for sourceCR "+acIn.availableSTA[sourceC,sourceR]);
        // }
        

        // determine MV and STA costs
        float MVcost = GlobalVariables.tilesMatrix[ dirC,dirR ].movementCost;
        float STAcost = GlobalVariables.tilesMatrix[ dirC,dirR ].staminaCost;
        switch(GlobalVariables.tilesMatrix[ dirC,dirR ].tileType){
            case Enums.TileType.GrassRough:
                if(thisUnit.passThroughGrassRough){
                    MVcost = 1;
                    STAcost = 1;
                }
                break;
            case Enums.TileType.WaterShallow:
                if(thisUnit.passThroughWaterShallow){
                    MVcost = 1;
                    STAcost = 1;
                }
                break;
        }

        int thisMV = Int32.Parse(acIn.available[ sourceC,sourceR ]);
        int thisSTA = Int32.Parse(acIn.availableSTA[ sourceC,sourceR ]);
        if( MVcost <= thisMV ){
            // if the new cell is empty OR the new cell's value is greater than the new value AND the new cell isn't occupied...
                // update availableMV 
            if( ((acIn.available[ dirC,dirR ] == null) || ( (thisMV - MVcost) > Int32.Parse(acIn.available[ dirC,dirR ]) )) && 
            GlobalVariables.unitsMatrix[ dirC,dirR ] == null ){
                acIn.available[ dirC,dirR ] = (thisMV - MVcost).ToString();
                acIn.availableSTA[ dirC,dirR ] = (thisSTA - STAcost).ToString();
            }
        }
        // if( STAcost <= thisSTA ){
        //     // update availableSTA
        //     if( ((acIn.availableSTA[ dirC,dirR ] == null) || ( (thisSTA - STAcost) > Int32.Parse(acIn.availableSTA[ dirC,dirR ]) )) && 
        //     GlobalVariables.unitsMatrix[ dirC,dirR ] == null ){
        //         // acIn.available[ dirC,dirR ] = (thisMV - MVcost).ToString();
        //         acIn.availableSTA[ dirC,dirR ] = (thisSTA - STAcost).ToString();
        //         // if(sourceC == 6 && sourceR == 6 && thisUnit.unitType == Enums.UnitType.SaberToothWolf){
        //         //     Debug.Log("<----- GOBBLED a STA spot: "+(thisSTA - STAcost).ToString());
        //         // }
        //     }
        // }
        return acIn;
    }

    private void FindBestPath(string[,] availableIn, int c, int r, Vector3Int source){

        // directional
        Enums.Direction direction = Enums.Direction.Up;
        int dirC;
        int dirR;
        // current best choice
        int bestC = c;
        int bestR = r;
        // hovered cell (the availablePaths List we're updating)
        int hoverX = c;
        int hoverY = r;

        int bestMV = Int32.Parse(availableIn[ c,r ]);
        bool processing = true;
        int inc = 0;

        // if(c == 6 && r == 6){
        //     Debug.Log("best move "+bestMV);
        // }


        // unless we're starting where we're ending...
        // stamp the first vector
        if(c != source.x || r != source.y){
            MovementNode mn = new MovementNode();
            mn.node = new Vector3Int(c,r,0);
            mn.direction = direction;
            // GlobalVariables.unitsMatrix[ source.x,source.y ].avalablePaths[ hoverX,hoverY ].Add(new Vector3Int(c,r,0));
            GlobalVariables.unitsMatrix[ source.x,source.y ].avalablePaths[ hoverX,hoverY ].Add(mn);
            // Debug.Log(source.ToString() + ": c/r " + c + " " + r);
        }

        while(processing || inc >= 20){

            // Up
            if( (r+1) <= GlobalVariables.boardHeight){
                dirC = c;
                dirR = (r+1); // && GlobalVariables.unitsMatrix[ dirC,dirR ] == null
                if( availableIn[ dirC,dirR ] != null && Int32.Parse(availableIn[ dirC,dirR ]) > bestMV ){
                    bestMV = Int32.Parse(availableIn[ dirC,dirR ]);
                    bestC = dirC;
                    bestR = dirR;
                    direction = Enums.Direction.Down; // opposite because we're starting from the destination and working back to the start
                }
            }

            // Down
            if( (r-1) > 0){
                dirC = c;
                dirR = (r-1);
                if( availableIn[ dirC,dirR ] != null && Int32.Parse(availableIn[ dirC,dirR ]) > bestMV ){
                    bestMV = Int32.Parse(availableIn[ dirC,dirR ]);
                    bestC = dirC;
                    bestR = dirR;
                    direction = Enums.Direction.Up; // opposite because we're starting from the destination and working back to the start
                }
            }

            // Left
            if( (c-1) > 0){
                dirC = (c-1);
                dirR = r;
                if( availableIn[ dirC,dirR ] != null && Int32.Parse(availableIn[ dirC,dirR ]) > bestMV ){
                    bestMV = Int32.Parse(availableIn[ dirC,dirR ]);
                    bestC = dirC;
                    bestR = dirR;
                    direction = Enums.Direction.Right; // opposite because we're starting from the destination and working back to the start
                }
            }

            // Right
            if( (c+1) <= GlobalVariables.boardWidth){
                dirC = (c+1);
                dirR = r;
                if( availableIn[ dirC,dirR ] != null && Int32.Parse(availableIn[ dirC,dirR ]) > bestMV ){
                    bestMV = Int32.Parse(availableIn[ dirC,dirR ]);
                    bestC = dirC;
                    bestR = dirR;
                    direction = Enums.Direction.Left; // opposite because we're starting from the destination and working back to the start
                }
            }
            
            c = bestC;
            r = bestR;

            MovementNode mn = new MovementNode();
            mn.node = new Vector3Int(c,r,0);
            mn.direction = direction;
            // GlobalVariables.unitsMatrix[ source.x,source.y ].avalablePaths[ hoverX,hoverY ].Add(new Vector3Int(c,r,0));
            GlobalVariables.unitsMatrix[ source.x,source.y ].avalablePaths[ hoverX,hoverY ].Add(mn);
            // Debug.Log(source.ToString() + ": c/r " + c + " " + r);

            if(c == source.x && r == source.y){
                processing = false;
                GlobalVariables.unitsMatrix[ source.x,source.y ].avalablePaths[ hoverX,hoverY ].Reverse();
            }

            inc++; // just a safety net to ensure that we don't infinitely loop
            if(inc >= 20){
                processing = false;
                Debug.Log("Whoa! We hit the infinite loop safety net in FindBestPath()");
            }


        } // end while processing

        // Debug.Log(source.ToString() + ": " + inc + " times through FindBestPath()");

    } // FindBestPath

    public static void RefreshUnitAvailabileCells(int posX = 0, int posY = 0){
        // all units
        if (posX == 0 || posY == 0){
            for(int c = 1; c < GlobalVariables.unitsMatrix.GetLength(0); c++){
                for(int r = 1; r < GlobalVariables.unitsMatrix.GetLength(1); r++){
                    if(GlobalVariables.unitsMatrix[ c,r ] != null){
                        UnitType character = GlobalVariables.unitsMatrix[ c,r ];
                        AvailableCells ac = FindAvailableCells(character.movementPoints, character.stamina, c, r);
                        character.availableCells = ac.available;
                        character.availableCellsSTA = ac.availableSTA;
                    }
                }
            }
        // just this unit 
        }else{
            if(GlobalVariables.unitsMatrix[ posX,posY ] != null){
                UnitType character = GlobalVariables.unitsMatrix[ posX,posY ];
                AvailableCells ac = FindAvailableCells(character.movementPoints, character.stamina, posX,posY);
                character.availableCells = ac.available;
                character.availableCellsSTA = ac.availableSTA;
            }
        }
        
    }


    public static Quaternion FindDirection(Enums.Direction direction){
        Quaternion quatDir;
        switch(direction){
            case Enums.Direction.Up:
                quatDir =  Quaternion.Euler (0, 0, 0);
                break;
            case Enums.Direction.Down:
                quatDir =  Quaternion.Euler (0, 0, 180);
                break;
            case Enums.Direction.Left:
                quatDir =  Quaternion.Euler (0, 0, 90);
                break;
            case Enums.Direction.Right:
                quatDir =  Quaternion.Euler (0, 0, 270);
                break;
            default:
                quatDir = Quaternion.Euler (0, 0, 90);
                break;
        }
        return quatDir;
    }  // end FindDirection

    public static void UpdateUnitLocation(int parX, int parY, int desX, int desY){
        // swap this unit's coords in the unitMatrix
        GlobalVariables.unitsMatrix[ desX,desY ] = GlobalVariables.unitsMatrix[ parX,parY ];
        GlobalVariables.unitsMatrix[ parX,parY ] = null;
        // update initRoster's positioning of this unit
        for(int i = 0; i < GlobalVariables.initRoster.Count; i++){
            if( GlobalVariables.initRoster[ i ].posX == parX && GlobalVariables.initRoster[ i ].posY == parY ){
                GlobalVariables.initRoster[ i ].posX = desX;
                GlobalVariables.initRoster[ i ].posY = desY;
            }
        }
        // refresh ALL UNIT's available cells
        GlobalFunctions.RefreshUnitAvailabileCells();
    }




    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ***  ******  ***  ******  ***        ***************************************************************************************************************
    // ***  ******  ***  ******  ***  *****  **************************************************************************************************************
    // ***  ******  ***  ******  ***  ******  *************************************************************************************************************
    // ***          ***  ******  ***  ******  *************************************************************************************************************    
    // ***  ******  ***  ******  ***  ******  *************************************************************************************************************
    // ***  ******  ****  ****  ****  *****  **************************************************************************************************************
    // ***  ******  *****      *****        ***************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************




    // used to pass the prefab HUDAvailableCell
    public GameObject GetHUDAvailableCell(bool self = false){
        if(self){
            return HUDAvailableCellSelf;
        }else{
            return HUDAvailableCell;
        }        
    }

    public GameObject GetHUDPathCell(){
        return HUDPathCell;
    }

    public GameObject GetHUDThreatCell(){
        return HUDThreatCell;
    }

    public GameObject GetSwordSwoosh(){
        return swordSwoosh;
    }

    public static IEnumerator FlashUnit(int posX, int posY, bool updateInfo=false){
        GlobalVariables.unitsMatrix [ posX,posY ].unitPrefab.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        GlobalVariables.unitsMatrix [ posX,posY ].unitPrefab.GetComponent<Renderer>().enabled = true;
        // update unit and tile HUD boxes
        if(updateInfo){
            GlobalFunctions.CleanUpTerrainInfoPanel();
		    GlobalFunctions.CleanUpUnitInfoPanel();
		    GlobalFunctions.DisplayTileInfo(posX,posY);
        }
    }

    public static void RemoveDisplayAvailableCellsFromAllUnits(){
        for(int c = 1; c < GlobalVariables.unitsMatrix.GetLength(0); c++){
            for(int r = 1; r < GlobalVariables.unitsMatrix.GetLength(1); r++){
				if(GlobalVariables.unitsMatrix[ c,r ] != null){
                    GlobalVariables.unitsMatrix[ c,r ].displayAvailableCells = false;
                }
            }
        } 
    }

 

    public static void RemoveAvailableCellsFromAllUnits(){
		// CharacterType thisChar = GlobalVariables.unitsMatrix[ posX,posY ];
		foreach(GameObject availableCell in GameObject.FindGameObjectsWithTag("HUD_available")) {
			Destroy(availableCell);
		}
	}

    public static void RemovePathCellsFromAllUnits(){
		// CharacterType thisChar = GlobalVariables.unitsMatrix[ posX,posY ];
		foreach(GameObject pathCell in GameObject.FindGameObjectsWithTag("HUD_path")) {
			Destroy(pathCell);
		}
	}

    public static void DisplayAvailableCells(int posX, int posY, bool click=false){
        if( GlobalVariables.unitsMatrix[ posX,posY ] != null ){
			
            UnitType thisChar = GlobalVariables.unitsMatrix[ posX,posY ];			
			if(!thisChar.displayAvailableCells){  

				GameObject tilePrefab = GameObject.Find("Controller").GetComponent<GlobalFunctions>().GetHUDAvailableCell();
                GameObject tilePrefabSelf = GameObject.Find("Controller").GetComponent<GlobalFunctions>().GetHUDAvailableCell(true);
				for(int c = 1; c < thisChar.availableCells.GetLength(0); c++){
					for(int r = 1; r < thisChar.availableCells.GetLength(1); r++){

						if(thisChar.availableCells[ c,r ] != null && 
                           thisChar.availableCellsSTA[ c,r ] != null &&
                        //    GlobalVariables.unitsMatrix[ c,r ] == null &&                                   // doesn't include self
                          ( GlobalVariables.unitsMatrix[ c,r ] == null || (c == posX && r == posY) ) &&       // includes self 
                           Int32.Parse(thisChar.availableCellsSTA[ c,r ]) >= 0 ){

							// -1 z index so that it lays "on top of" map tiles
                            GameObject tilePrefabGO;
                            // "self" is a hack (doesn't have Box Collider 2D)
                            // tilePrefabSelf won't trigger OnMouseExit() in HoverTile
                            if(c == posX && r == posY){
                                tilePrefabGO = Instantiate(tilePrefabSelf, new Vector3(c, r, -1), Quaternion.identity);
                            }else{
                                tilePrefabGO = Instantiate(tilePrefab, new Vector3(c, r, -1), Quaternion.identity);
                            }
							tilePrefabGO.GetComponent<HUDProperties>().parentID = thisChar.unitID;
                            tilePrefabGO.GetComponent<HUDProperties>().parentX = posX;
                            tilePrefabGO.GetComponent<HUDProperties>().parentY = posY;
							tilePrefabGO.name = "available_cell:_"+thisChar.unitType.ToString()+"_("+thisChar.unitID+")_"+c+"_"+r;
                            // Debug.Log(c+" "+r+" :"+GlobalVariables.unitsMatrix[ posX,posY ].availableCellsSTA[ c,r ]);
						}

					}
				}
                
				thisChar.displayAvailableCells = true;
			} // end if we can display available cells

		}

    } // displayAvailableCells

    public static void DisplayPathCells(int posX, int posY, int parentX, int parentY){
        if( GlobalVariables.unitsMatrix[ parentX,parentY ] != null ){
			
			// CharacterType thisChar = GlobalVariables.unitsMatrix[ parentX,parentY ];
			GameObject tilePrefab = GameObject.Find("Controller").GetComponent<GlobalFunctions>().GetHUDPathCell();

            // foreach (Vector3Int v3 in GlobalVariables.unitsMatrix[ parentX,parentY ].avalablePaths[ posX,posY ])
            foreach (MovementNode mn in GlobalVariables.unitsMatrix[ parentX,parentY ].avalablePaths[ posX,posY ])
            {
                if ( !(mn.node.x == parentX && mn.node.y == parentY) ) {
                    // GameObject tilePrefabGO = Instantiate(tilePrefab, new Vector3(v3.x, v3.y, 0), Quaternion.identity);
                    Instantiate(tilePrefab, new Vector3(mn.node.x, mn.node.y, 0), Quaternion.identity);
                }
                
            }
			
		}
    } // displayAvailableCells

    public static void UpdateHUDcursor(int posX, int posY){
		CleanUpOldHUDcursor();
		
		GlobalVariables.HUDCursor.transform.position = new Vector3(posX,posY, 0);
		GlobalVariables.HUDCursor.SetActive(true);
	}

	public static void CleanUpOldHUDcursor(){
		GlobalVariables.HUDCursor.SetActive(false);
	}

    public static void UpdateHUDcursorThreat(int posX, int posY){
		CleanUpOldHUDcursorThreat();
		
		GlobalVariables.HUDCursorThreat.transform.position = new Vector3(posX,posY, 0);
		GlobalVariables.HUDCursorThreat.SetActive(true);
	}

	public static void CleanUpOldHUDcursorThreat(){
		GlobalVariables.HUDCursorThreat.SetActive(false);
	}

    public static void UpdateHUDreadyUnit(int posX, int posY){
		CleanUpOldHUDreadyUnit();
		
		GlobalVariables.HUDReadyUnit.transform.position = new Vector3(posX,posY, 0);
		GlobalVariables.HUDReadyUnit.SetActive(true);
	}

	public static void CleanUpOldHUDreadyUnit(){
		GlobalVariables.HUDReadyUnit.SetActive(false);
	}

    public static void CleanUpUnitInfoPanel(){
		GlobalVariables.infoPanelUnitHeader.text = "";
		GlobalVariables.infoPanelUnitText.text = "";
        GlobalVariables.infoPanelUnitText2.text = "";
        // clean up HUD icon
        if(GameObject.Find("unitIcon")){
            GameObject goUnitIcon = GameObject.Find("unitIcon");
            Destroy(goUnitIcon);
        }
        // hide the Unit Panel
        GlobalVariables.infoPanelUnitGO.SetActive(false);
	}

	public static void CleanUpTerrainInfoPanel(bool panel = false){
		GlobalVariables.infoPanelTerrainHeader.text = "";
		GlobalVariables.infoPanelTerrainText.text = "";
        GlobalVariables.infoPanelTerrainText2.text = "";
        // clean up terrain HUD icon
        if(GameObject.Find("tileIcon")){
            GameObject gotileIcon = GameObject.Find("tileIcon");
            Destroy(gotileIcon);
        }

        // hide the Terrain Panel
        if(!panel){
            GlobalVariables.infoPanelTerrainGO.SetActive(false);
        }

	}

    public static void CleanUpBattleOptionIcons(){
        if(GameObject.Find("battleOptionIcon")){
            GameObject gotileIcon = GameObject.Find("battleOptionIcon");
            Destroy(gotileIcon);
        }
    }

    public static void DisplayBattleOptionInfo(Enums.BattleOption battleOption){
        int posX = GlobalVariables.selectedUnit.x;
        int posY = GlobalVariables.selectedUnit.y;
        switch(battleOption){
            case Enums.BattleOption.LightAttack:
                GlobalVariables.infoPanelTerrainHeader.text = "Light Attack";
                // col 1
                GlobalVariables.infoPanelTerrainText.text = "Worth 10 BAL";
                GlobalVariables.infoPanelTerrainText.text += "\n";
                GlobalVariables.infoPanelTerrainText.text += "Costs 10 STA";
                // col 2
                GlobalVariables.infoPanelTerrainText2.text = "DMG: "+GlobalVariables.unitsMatrix[ posX,posY ].lowDamage+" - "+GlobalVariables.unitsMatrix[ posX,posY ].highDamage;
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONLightAttack, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                }
                break;
            case Enums.BattleOption.HeavyAttack:
                // col 1
                GlobalVariables.infoPanelTerrainHeader.text = "Heavy Attack";
                GlobalVariables.infoPanelTerrainText.text = "Worth 30 BAL";
                GlobalVariables.infoPanelTerrainText.text += "\n";
                GlobalVariables.infoPanelTerrainText.text += "Costs 30 STA";
                // col 2
                GlobalVariables.infoPanelTerrainText2.text = "DMG: "+GlobalVariables.unitsMatrix[ posX,posY ].lowDamage+" - "+(GlobalVariables.unitsMatrix[ posX,posY ].highDamage * 2);
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONHeavyAttack, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                }
                break;
            case Enums.BattleOption.Rally:
                // col 1
                GlobalVariables.infoPanelTerrainHeader.text = "Rally";
                GlobalVariables.infoPanelTerrainText.text = "+ 5 DEF";
                GlobalVariables.infoPanelTerrainText.text += "\n";
                GlobalVariables.infoPanelTerrainText.text += "+ 50 STA & BAL";
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONRally, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                }
                break;
            case Enums.BattleOption.UseItem:
                GlobalVariables.infoPanelTerrainHeader.text = "Use Item";
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONUseItem, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                }
                break;
            case Enums.BattleOption.CastSpell:
                GlobalVariables.infoPanelTerrainHeader.text = "Cast Spell";
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONCastSpell, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                }
                break;
            case Enums.BattleOption.SpecialAbility:
                GlobalVariables.infoPanelTerrainHeader.text = "Special Ability";
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONSpecialAbility, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                }
                break;
        }
    }

    public static void DisplayTileInfo(int posX, int posY, bool units = true, bool terrain = true){

		// UNITS
		if(GlobalVariables.unitsMatrix[ posX,posY ] != null && units){
            // show the Unit Panel
            GlobalVariables.infoPanelUnitGO.SetActive(true);
            CleanUpHUDIcons();
			// header
            // GlobalVariables.infoPanelUnitHeader.text = GlobalVariables.unitsMatrix[ posX,posY ].unitType.ToString();
            GlobalVariables.infoPanelUnitHeader.text = GlobalVariables.unitsMatrix[ posX,posY ].name;
            GlobalVariables.infoPanelUnitHeader.text += " (" + GlobalVariables.unitsMatrix[ posX,posY ].unitID + ")";
            // col 1
			GlobalVariables.infoPanelUnitText.text = "HP: " + GlobalVariables.unitsMatrix[ posX,posY ].hitPoints + " / " + GlobalVariables.unitsMatrix[ posX,posY ].hitPointMax;
            GlobalVariables.infoPanelUnitText.text += "\n";
            GlobalVariables.infoPanelUnitText.text += "MOV: " + GlobalVariables.unitsMatrix[ posX,posY ].movementPoints;
			GlobalVariables.infoPanelUnitText.text += "\n";
			GlobalVariables.infoPanelUnitText.text += "STA: " + GlobalVariables.unitsMatrix[ posX,posY ].stamina;
			GlobalVariables.infoPanelUnitText.text += "\n";
			GlobalVariables.infoPanelUnitText.text += "BAL: " + GlobalVariables.unitsMatrix[ posX,posY ].balance;
            // col 2
            GlobalVariables.infoPanelUnitText2.text = "ACC: " + GlobalVariables.unitsMatrix[ posX,posY ].accuracy;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            GlobalVariables.infoPanelUnitText2.text += "CRI: " + GlobalVariables.unitsMatrix[ posX,posY ].critical;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            GlobalVariables.infoPanelUnitText2.text += "SPD: " + GlobalVariables.unitsMatrix[ posX,posY ].speed;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            GlobalVariables.infoPanelUnitText2.text += "DEF: " + GlobalVariables.unitsMatrix[ posX,posY ].defense;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            // GlobalVariables.infoPanelUnitText2.text += "ACT: " + GlobalVariables.unitsMatrix[ posX,posY ].canAct;
			// GlobalVariables.infoPanelUnitText2.text += "\n";
            // GlobalVariables.infoPanelUnitText2.text += "MOV: " + GlobalVariables.unitsMatrix[ posX,posY ].canMove;
			// GlobalVariables.infoPanelUnitText2.text += "\n";
            if(GlobalVariables.unitsMatrix[ posX,posY ].canAct){
                GameObject.Find("torch_flame_ACT").GetComponent<IconAnimations>().PlayLit();
            }else{
                GameObject.Find("torch_flame_ACT").GetComponent<IconAnimations>().PlayIdle();
            }
            if(GlobalVariables.unitsMatrix[ posX,posY ].canMove){
                GameObject.Find("torch_flame_MOV").GetComponent<IconAnimations>().PlayLit();
            }else{
                GameObject.Find("torch_flame_MOV").GetComponent<IconAnimations>().PlayIdle();
            }
            // unit icon
            DisplayUnitIcon(posX, posY);
		}else{
			GlobalFunctions.CleanUpUnitInfoPanel();
		}
		// TERRAIN
        if(GlobalVariables.tilesMatrix[ posX,posY ] != null && terrain){
            // show the Terrain Panel
            GlobalVariables.infoPanelTerrainGO.SetActive(true);
            // header
            // GlobalVariables.infoPanelTerrainHeader.text = GlobalVariables.tilesMatrix[ posX,posY ].tileType.ToString();
            GlobalVariables.infoPanelTerrainHeader.text = GlobalVariables.tilesMatrix[ posX,posY ].name;
            GlobalVariables.infoPanelTerrainHeader.text += " (" + posX + "-" + posY + ")";
            // col 1
            GlobalVariables.infoPanelTerrainText.text = "MOV Cost: " + GlobalVariables.tilesMatrix[ posX,posY ].movementCost;
            GlobalVariables.infoPanelTerrainText.text += "\n";
            GlobalVariables.infoPanelTerrainText.text += "STA Cost: " + GlobalVariables.tilesMatrix[ posX,posY ].staminaCost;	
            // col 2
            GlobalVariables.infoPanelTerrainText2.text = "DEF Bonus: " + GlobalVariables.tilesMatrix[ posX,posY ].defenseBonus;
            // terrain icon
            DisplayTileIcon(posX, posY);
        }
        
	}

    public static void DisplayUnitIcon(int posX, int posY){
        if( !GameObject.Find("unitIcon") ){
            GameObject unitPrefab = GlobalVariables.unitsMatrix[ posX,posY ].unitPrefab;
            // GameObject unitIcon = Instantiate(unitPrefab, new Vector3(17.575f, 8.05f, 0), unitPrefab.transform.localRotation);
            GameObject unitIcon = Instantiate(unitPrefab, new Vector3(17.575f, 8.05f, 0), Quaternion.Euler (0, 0, 180));
            unitIcon.name = "unitIcon";
        }
    }

    public static void DisplayTileIcon(int posX, int posY){
        if( !GameObject.Find("tileIcon") ){
            GameObject tilePrefab = GlobalVariables.tilesMatrix[ posX,posY ].tilePrefab;
            GameObject tileIcon = Instantiate(tilePrefab, new Vector3(17.575f, 2.2f, 0), tilePrefab.transform.localRotation);
            tileIcon.name = "tileIcon";
        }
    }

    public static void CleanUpHUDavailable(int posX, int posY){

		if( GlobalVariables.unitsMatrix[ posX,posY ] != null && !(GlobalVariables.selectedUnit.x == posX && GlobalVariables.selectedUnit.y == posY) ){
			UnitType thisChar = GlobalVariables.unitsMatrix[ posX,posY ];
        	foreach(GameObject availableCell in GameObject.FindGameObjectsWithTag("HUD_available")) {
            	if( availableCell.GetComponent<HUDProperties>().parentID == thisChar.unitID ){
					Destroy(availableCell);
				}
         	}	
			// thisChar.displayAvailableCells = false;
		}
		if( GlobalVariables.unitsMatrix[ posX,posY ] != null && (GlobalVariables.selectedUnit.x != posX && GlobalVariables.selectedUnit.y != posY) ){
		// if( GlobalVariables.unitsMatrix[ posX,posY ] != null ){
			GlobalVariables.unitsMatrix[ posX,posY ].displayAvailableCells = false;
		}
		
	}

    public static void CleanUpHUDIcons(){
        // reset battle icons
        foreach( GameObject battleIcon in GameObject.FindGameObjectsWithTag("HUD_battle_option") ){
            battleIcon.GetComponent<HoverIcon>().PlayIdle();
        }
        // GlobalVariables.freezeIconHUD = false;
    }




    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // *****      *******      *****  ******  ***         *******    ******          **********************************************************************
    // ****  ****  *****  ****  ****   ****   ***  ******  ****   **   ********  **************************************************************************
    // ***  ***********  ******  ***    **    ***  *****  ****  ******  *******  **************************************************************************
    // ***  ***********  ******  ***  *    *  ***        *****          *******  **************************************************************************    
    // ***  ***********  ******  ***  **  **  ***  *****  ****  ******  *******  **************************************************************************
    // ****  ****  *****  ****  ****  ******  ***  ******  ***  ******  *******  **************************************************************************
    // *****      *******      *****  ******  ***         ****  ******  *******  **************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************




    public static void UpdateInitiative(){

        GlobalVariables.initRoster.Clear();

        // for each unit
        for(int x = 1; x < GlobalVariables.unitsMatrix.GetLength(0); x++){
			for(int y = 1; y < GlobalVariables.unitsMatrix.GetLength(1); y++){
                if(GlobalVariables.unitsMatrix[ x,y ] != null){
                    // Roll initiative
                    int initRoll = UnityEngine.Random.Range(1, 11);
                    int speed = (int)GlobalVariables.unitsMatrix[ x,y ].speed;
                    int total = (initRoll + speed);
                    // Debug.Log("initroll is "+initRoll+"\nspeed is "+speed+"\ntotal is "+total);
                    // Debug.Log("speed is "+speed);
                    Initiative init = new Initiative();
                    init.initiative = total;
                    init.unitID = GlobalVariables.unitsMatrix[ x,y ].unitID;
                    init.team = GlobalVariables.unitsMatrix[ x,y ].team;
                    init.posX = x;
                    init.posY = y;
                    GlobalVariables.initRoster.Add(init);
                    // Debug.Log(x+" "+y+" : "+GlobalVariables.unitsMatrix[ x,y ].name);
                }
            }
        }

		GlobalVariables.initRoster.Sort(delegate(Initiative a, Initiative b) {
			return a.CompareTo(b);
		});
        // enable first unit
        GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].canAct = true;
        GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].canMove = true;
        UpdateWhoIsNext();

		Debug.Log("\nAfter sort by initiative:");
        foreach (Initiative init in GlobalVariables.initRoster)
        {
            Debug.Log("Inititive: "+init.initiative+" UnitID: "+init.unitID);
        }
    }

    public static string[,] FindThreatCells(int attackRange, int posX, int posY){

        // add 1 to these array indices so we can 1 : 1 the coords (and just ignore the zero indices)
        string[,] threatenedCells = new string[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        bool[,] considered = new bool[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        threatenedCells[ posX,posY ] = attackRange.ToString();
        // summon GF to get around weird static function object reference req's
        GlobalFunctions GF = GameObject.Find("Controller").GetComponent<GlobalFunctions>();

        bool processing = true;
        int inc = 0;
        while(processing || inc >= 10000){
            for(int c = 1; c < threatenedCells.GetLength(0); c++){
                for(int r = 1; r < threatenedCells.GetLength(1); r++){
                    if( threatenedCells[ c,r ] != null && !considered [ c,r ] ){
                        
                        // eventually add a check to NOT BE ALE TO PASS THROUGH cells occupied by enemies
                        // you can pass through friendly cells, just can't park there
                        // NOTE: this happens in CheckForDirectionalAvailability()

                         // Up
                        if( (r+1) <= GlobalVariables.boardHeight){
                            int dirC = c;
                            int dirR = (r+1);
                            threatenedCells = GF.CheckForThreatAvailability(threatenedCells, c, r, dirC, dirR);
                        }

                        // Down
                        if( (r-1) > 0){
                            int dirC = c;
                            int dirR = (r-1);
                            threatenedCells = GF.CheckForThreatAvailability(threatenedCells, c, r, dirC, dirR);
                        }

                        // Left
                        if( (c-1) > 0){
                            int dirC = (c-1);
                            int dirR = r;
                            threatenedCells = GF.CheckForThreatAvailability(threatenedCells, c, r, dirC, dirR);
                        }

                        // Right
                        if( (c+1) <= GlobalVariables.boardWidth){
                            int dirC = (c+1);
                            int dirR = r;
                            threatenedCells = GF.CheckForThreatAvailability(threatenedCells, c, r, dirC, dirR);
                        }

                        considered[ c,r ] = true;
                        // Debug.Log(">>>>>>>>>>>>>>> considered: "+c+" "+r);
                        
                        // we're done processing the while loop...
                        // unless there are any threatenedCells cells that we haven't yet considered
                        processing = false; 
                        for(int c2 = 1; c2 < threatenedCells.GetLength(0); c2++){
                            for(int r2 = 1; r2 < threatenedCells.GetLength(1); r2++){
                                if(threatenedCells[ c2,r2 ] != null){
                                    if( !considered[ c2,r2 ] ){
                                        processing = true;
                                    }
                                }
                            }
                        }

                    } // end threatenedCells != null
                    
                }
            }
            inc++; // just a safety net to ensure that we don't infinitely loop
            if(inc >= 1000){
                processing = false;
                Debug.Log("Whoa! We hit the infinite loop safety net in FindThreatCells()");
            }
        } // end while(processing)

        return threatenedCells;

    }

    private String[,] CheckForThreatAvailability(String[,] threatenedIn, int sourceC, int sourceR, int dirC, int dirR){
        
        // all cells should have threat level of 1 (at this point in development)
        float threatCost = 1;

        int thisThreat = Int32.Parse(threatenedIn[ sourceC,sourceR ]);
        if( threatCost <= thisThreat ){
            // if the new cell is empty OR the new cell's value is greater than the new value 
            if( ((threatenedIn[ dirC,dirR ] == null) || ( (thisThreat - threatCost) > Int32.Parse(threatenedIn[ dirC,dirR ]) )) ){
                threatenedIn[ dirC,dirR ] = (thisThreat - threatCost).ToString();
            }
        }
        return threatenedIn;
    }

    public static void DisplayThreatCells(int posX, int posY){
        // if( GlobalVariables.unitsMatrix[ parentX,parentY ] != null ){
			
			// CharacterType thisChar = GlobalVariables.unitsMatrix[ parentX,parentY ];
			GameObject tilePrefab = GameObject.Find("Controller").GetComponent<GlobalFunctions>().GetHUDThreatCell();
            UnitType thisChar = GlobalVariables.unitsMatrix[ posX,posY ];

            // Debug.Log("XY: "+posX+" "+posY);
            //  ( GlobalVariables.unitsMatrix[ c,r ] == null || (c == posX && r == posY) ) &&
            for(int c = 1; c < thisChar.threatCells.GetLength(0); c++){
                for(int r = 1; r < thisChar.threatCells.GetLength(1); r++){
                    GameObject tilePrefabGO;
                    if( (thisChar.threatCells[ c,r ] != null) && (c != posX || r != posY) ){
                        tilePrefabGO = Instantiate(tilePrefab, new Vector3(c, r, 0), Quaternion.identity);
                        tilePrefabGO.GetComponent<HUDProperties>().parentID = thisChar.unitID;
                        tilePrefabGO.GetComponent<HUDProperties>().parentX = posX;
                        tilePrefabGO.GetComponent<HUDProperties>().parentY = posY;
						tilePrefabGO.name = "threat_cell:_"+thisChar.unitType.ToString()+"_("+thisChar.unitID+")_"+c+"_"+r;
                    }
                    
                }
            }
			
		// }
    } // displayThreatCells

    public static void SpawnSwordSwoosh(int parentX, int parentY, int targetX, int targetY){

        GameObject tilePrefab = GameObject.Find("Controller").GetComponent<GlobalFunctions>().GetSwordSwoosh();
        Quaternion quatDir = Quaternion.Euler (0, 0, 0);
        float destX = 0;
        float destY = 0;

        // Debug.Log(parentX+" "+parentY+" is my parent! "+targetX+" "+targetY+" is my target!");
        if(parentX == targetX){
            // Debug.Log("X is the same!");
            destX = parentX;
            if(parentY < targetY){ // up
                destY = (parentY + .5f);
                quatDir =  Quaternion.Euler (0, 0, 0);
                // Debug.Log("parentY is less than targtetY");
            }else{ // down
                destY = (parentY - .5f);
                quatDir =  Quaternion.Euler (0, 0, 180);
                // Debug.Log("parentY is more than targtetY");
            }
        }else if(parentY == targetY){
            destY = parentY;
            // Debug.Log("Y is the same!");
            if(parentX < targetX){ // right
                destX = (parentX + .5f);
                quatDir =  Quaternion.Euler (0, 0, 270);
                // Debug.Log("parentX is less than targtetX");
            }else{ // left
                destX = (parentX - .5f);
                quatDir =  Quaternion.Euler (0, 0, 90);
                // Debug.Log("parentX is more than targtetX");
            }
        }
        // Debug.Log("destination coords: "+destX+" "+destY);
        Instantiate(tilePrefab, new Vector3(destX, destY, 0), quatDir);
    }

    public static void CombatAttack(int parentX, int parentY, int targetX, int targetY){

        if( GlobalVariables.unitsMatrix[ targetX,targetY ] != null ){

            // instantiate units
            UnitType attacker = GlobalVariables.unitsMatrix[ parentX,parentY ];
            UnitType defender = GlobalVariables.unitsMatrix[ targetX,targetY ];

            // variable bank
            Enums.BattleOption battleOption = GlobalVariables.unitsMatrix[ parentX,parentY ].battleOption;
            int attackRoll = UnityEngine.Random.Range(1, 21);
            int defendRoll = UnityEngine.Random.Range(1, 21);
            int damageRoll = 0; // initialize
            if(battleOption == Enums.BattleOption.LightAttack){
                damageRoll = UnityEngine.Random.Range( attacker.lowDamage,(attacker.highDamage+1) );
            }else if(battleOption == Enums.BattleOption.HeavyAttack){
                damageRoll = UnityEngine.Random.Range( attacker.lowDamage,((attacker.highDamage+1)*2) );
            }
            int BALvalue = 10; // initialize
            if(battleOption == Enums.BattleOption.LightAttack){
                BALvalue = 10;
            }else if(battleOption == Enums.BattleOption.HeavyAttack){
                BALvalue = 30; 
            }

            // generate attack and defense scores
            attackRoll += (int)attacker.accuracy;
            if(battleOption == Enums.BattleOption.HeavyAttack){
                attackRoll = attackRoll - 5;
            }
            defendRoll += (int)defender.defense;

            Debug.Log("attack roll: "+attackRoll);
            Debug.Log("defend roll: "+defendRoll);

            // conduct attack
                // HIT!
            if(attackRoll >= defendRoll){ 
                defender.hitPoints = LessThanZero(defender.hitPoints - damageRoll);
                defender.balance = LessThanZero(defender.balance - BALvalue);
                Debug.Log("attacker deals "+damageRoll+" damage with "+battleOption.ToString());
                // MISS!
            }else{ 
                attacker.balance = LessThanZero(attacker.balance - BALvalue);
                Debug.Log("attacker missed!");
            }

            // update units
            GlobalVariables.unitsMatrix[ parentX,parentY ] = attacker;
            GlobalVariables.unitsMatrix[ targetX,targetY ] = defender;
            // reflect updates in HUD
		    GlobalFunctions.DisplayTileInfo(parentX, parentY, true, false); 

        }
        // consume attacker's ability to act again this turn
        GlobalVariables.unitsMatrix[ parentX,parentY ].canAct = false;

    }

    public static void UpdateStamina(int posX, int posY){
        UnitType thisChar = GlobalVariables.unitsMatrix[ posX,posY ];
        switch(thisChar.battleOption){
            case Enums.BattleOption.LightAttack:
                thisChar.stamina = LessThanZero(thisChar.stamina - 10);
                break;
            case Enums.BattleOption.HeavyAttack:
                thisChar.stamina = LessThanZero(thisChar.stamina - 30);
                break;
            case Enums.BattleOption.Rally:
                // thisChar.stamina = LessThanZero(thisChar.stamina - 10);
                break;
            case Enums.BattleOption.UseItem:
                thisChar.stamina = LessThanZero(thisChar.stamina - 10);
                break;
            case Enums.BattleOption.CastSpell:
                thisChar.stamina = LessThanZero(thisChar.stamina - 10);
                break;
            case Enums.BattleOption.SpecialAbility:
                thisChar.stamina = LessThanZero(thisChar.stamina - 10);
                break;
        }
        GlobalVariables.unitsMatrix[ posX,posY ] = thisChar;
    }

    public static int LessThanZero(int value){
        if(value > 0){
            return value;
        }else{
            return 0;
        }
    }

    public static void CheckForEndOfTurn(int posX, int posY){
        UnitType thisUnit = GlobalVariables.unitsMatrix[ posX,posY ];
        // if this unit is done attacking, and moving
        if( !thisUnit.canAct && !thisUnit.canMove ){

            GlobalVariables.initRoster.RemoveAt(0);
            Debug.Log("removing (0) from initRoster. Count is now: "+GlobalVariables.initRoster.Count);
            if(GlobalVariables.initRoster.Count <= 0){
                UpdateInitiative();
            }else{
                // is this part necessary? don't we already do this in UpdateInitiative()?
                GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].canAct = true;
                GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].canMove = true;
            }
            UpdateWhoIsNext();
            // un-SELECT this unit
			GlobalVariables.selectedUnit = new Vector3Int(0,0,0); // this doesn't seem to work?
            Debug.Log(GlobalVariables.unitsMatrix[ posX,posY ].name+" finished it's turn.");

            GlobalVariables.selectedUnit.x = 0;
            GlobalVariables.selectedUnit.y = 0;
        // if this unit is done attacking, but can still move
        }else if( !thisUnit.canAct && thisUnit.canMove ){
            DisplayAvailableCells(posX,posY);
            CleanUpBattleOptionIcons(); // should it remove this HERE?
        }

    }

    public static void CheckForDeadUnit(int posX, int posY){
        
        if (GlobalVariables.unitsMatrix[ posX,posY ] != null ){
            // if unit is dead
            if( GlobalVariables.unitsMatrix[ posX,posY ].hitPoints <= 0 ){
                // remove from initRoster
                for(int i = 0; i < GlobalVariables.initRoster.Count; i++){
                    if( GlobalVariables.initRoster[i].unitID == GlobalVariables.unitsMatrix[ posX,posY ].unitID ){
                        Debug.Log("\nremoving "+GlobalVariables.initRoster[i].unitID+" from initRoster!");
                        GlobalVariables.initRoster.RemoveAt(i);
                    }
                }
                // destroy on screen prefab
                Destroy(GlobalVariables.unitsMatrix[ posX,posY ].unitPrefab);
                // destroy actual data of unit
                GlobalVariables.unitsMatrix[ posX,posY ] = null;
                // allow other units to move to this space now
                GlobalFunctions.RefreshUnitAvailabileCells();
                // update initiative roster
                if(GlobalVariables.initRoster.Count <= 0){
                    UpdateInitiative();
                }else{
                    UpdateWhoIsNext();

                    // is this part necessary? don't we already do this in UpdateInitiative()?
                    // GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].canAct = true;
                    // GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].canMove = true;
                }

                for(int x = 0; x < GlobalVariables.initRoster.Count; x++){
                    Debug.Log(GlobalVariables.initRoster[x].unitID+" at "+x+" in initRoster");
                }
            }

        }

    }

    public static void UpdateWhoIsNext(){
        if (GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ] != null){
            UnitType thisChar = GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ];
            // display first current unit in TOP PANEL
            GlobalVariables.infoPanelTopText.text = thisChar.name + " (" + thisChar.unitID + ")";
            // UpdateHUDreadyUnit( (int)thisChar.unitPrefab.transform.position.x,(int)thisChar.unitPrefab.transform.position.y );
            UpdateHUDreadyUnit( GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY );
        }
    }
















































} // end GlobalFunctions
