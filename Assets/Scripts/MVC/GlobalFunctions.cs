using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GlobalFunctions : MonoBehaviour {

    public static GlobalFunctions Instance;

    // prefab units
   

    // HUD objects
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
    public GameObject STATUSICONTerrain;
    public GameObject STATUSICONBal;
    public GameObject STATUSICONRally;
    public GameObject STATUSICONHeavyAttack;

    // HUD misc
    public GameObject swordSwoosh;

    // tileTypes
    public TileType[] tileTypes;

    // unit prefabs
    // - characters
     public GameObject hunter;
     public GameObject gatherer;
     // - monsters
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

    public static void InitializeBoardVariables(string mapName){
        GlobalVariables.grid = GameObject.FindGameObjectWithTag("Grid");
		GlobalVariables.tilemapGO = GlobalVariables.grid.transform.Find(mapName).gameObject;
        GlobalVariables.tilemap = GlobalVariables.tilemapGO.GetComponent<Tilemap>();
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
        for(int c = 1; c < character.availablePaths.GetLength(0); c++){
            for(int r = 1; r < character.availablePaths.GetLength(1); r++){
                // character.avalablePaths[ c,r ] = new List<Vector3Int>();
                character.availablePaths[ c,r ] = new List<MovementNode>();
            }
        }

        character.team = team;
        character.posX = posX;
        character.posY = posY;
        GlobalVariables.unitsMatrix[posX,posY] = character;

        // determine which prefab to use
        GameObject charPrefab = hunter;
        switch(type){
            case Enums.UnitType.Hunter:
                charPrefab = hunter;
                break;
            case Enums.UnitType.Gatherer:
                charPrefab = gatherer;
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




   
    /*
        params:
        float movement          how many movement points to consider
        float stamina           how many stamina points to consider
        int posX                x coord of unit in question
        int poxY                y coord of unit in question
     */
    public static AvailableCells FindAvailableCells(float movement, float stamina, int posX, int posY){
        
        // reset each list in each index of availablePaths for this unit
        for(int x = 1; x < GlobalVariables.unitsMatrix[ posX,posY ].availablePaths.GetLength(0); x++){
            for(int y = 1; y < GlobalVariables.unitsMatrix[ posX,posY ].availablePaths.GetLength(1); y++){
                GlobalVariables.unitsMatrix[ posX,posY ].availablePaths[ x,y ].Clear();
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
  
        ac.available[ source.x,source.y ] = movement.ToString();
        ac.availableSTA[ source.x,source.y ] = stamina.ToString();
        // summon GF to get around weird static function object reference req's
        GlobalFunctions GF = GameObject.Find("Controller").GetComponent<GlobalFunctions>();
        UnitType thisUnit = GlobalVariables.unitsMatrix [ posX,posY ];
        int STAdecrementer = 100; // evaluate STA trail from highest to lowest
        if(stamina > 100){
            STAdecrementer = (int)stamina;
        }

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

        // determine MOV and STA costs
        TileCostType tc = DetermineTileCosts(thisUnit, dirC, dirR);

        int thisMOV = Int32.Parse(acIn.available[ sourceC,sourceR ]);
        int thisSTA = Int32.Parse(acIn.availableSTA[ sourceC,sourceR ]);
        if( tc.MOVcost <= thisMOV ){
            // if the new cell is empty OR the new cell's value is greater than the new value AND the new cell isn't occupied...
                // update availableMV 
            if( ((acIn.available[ dirC,dirR ] == null) || ( (thisMOV - tc.MOVcost) > Int32.Parse(acIn.available[ dirC,dirR ]) )) && 
            GlobalVariables.unitsMatrix[ dirC,dirR ] == null ){
                acIn.available[ dirC,dirR ] = (thisMOV - tc.MOVcost).ToString();
                acIn.availableSTA[ dirC,dirR ] = (thisSTA - tc.STAcost).ToString();
            }
        }

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

        // unless we're starting where we're ending...
        // stamp the first vector
        if(c != source.x || r != source.y){
            MovementNode mn = new MovementNode();
            mn.node = new Vector3Int(c,r,0);
            mn.direction = direction;
            // GlobalVariables.unitsMatrix[ source.x,source.y ].availablePaths[ hoverX,hoverY ].Add(new Vector3Int(c,r,0));
            GlobalVariables.unitsMatrix[ source.x,source.y ].availablePaths[ hoverX,hoverY ].Add(mn);
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
            // GlobalVariables.unitsMatrix[ source.x,source.y ].availablePaths[ hoverX,hoverY ].Add(new Vector3Int(c,r,0));
            GlobalVariables.unitsMatrix[ source.x,source.y ].availablePaths[ hoverX,hoverY ].Add(mn);
            // Debug.Log(source.ToString() + ": c/r " + c + " " + r);

            if(c == source.x && r == source.y){
                processing = false;
                GlobalVariables.unitsMatrix[ source.x,source.y ].availablePaths[ hoverX,hoverY ].Reverse();
            }

            inc++; // just a safety net to ensure that we don't infinitely loop
            if(inc >= 20){
                processing = false;
                Debug.Log("Whoa! We hit the infinite loop safety net in FindBestPath()");
            }

        } // end while processing

    } // FindBestPath

    /*
        params:
        UnitType thisUnit       unit we're referencing
        int posX                x coord of tile we're considering
        int poxY                y coord of tile we're considering
     */    
    public static TileCostType DetermineTileCosts(UnitType thisUnit, int posX, int posY){
        TileCostType tc = new TileCostType();
        int MOVcost = GlobalVariables.tilesMatrix[ posX,posY ].movementCost;
        int STAcost = GlobalVariables.tilesMatrix[ posX,posY ].staminaCost;
        switch(GlobalVariables.tilesMatrix[ posX,posY ].tileType){
            case Enums.TileType.GrassRough:
                if(thisUnit.passThroughGrassRough){
                    MOVcost = 1;
                    STAcost = 1;
                }
                break;
            case Enums.TileType.WaterShallow:
                if(thisUnit.passThroughWaterShallow){
                    MOVcost = 1;
                    STAcost = 1;
                }
                break;
            case Enums.TileType.WaterDeep:
                if(thisUnit.passThroughWaterDeep){
                    MOVcost = 1;
                    STAcost = 1;
                }
                break;    
        }
        tc.STAcost = STAcost;
        tc.MOVcost = MOVcost;
        return tc;
    }

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
        // update ths unit's poxY and posY values
        GlobalVariables.unitsMatrix[ desX,desY ].posX = desX;
        GlobalVariables.unitsMatrix[ desX,desY ].posY = desY;        
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




    public static void InitializeHUDObjects(){

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
        // - top panel unit text ACC
        GlobalVariables.infoPanelTopTextACCGO = GameObject.Find("InfoPanelTopTextACC");
        GlobalVariables.infoPanelTopTextACC = GlobalVariables.infoPanelTopTextACCGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopTextACC.text = "";
        // - top panel unit text DEF
        GlobalVariables.infoPanelTopTextDEFGO = GameObject.Find("InfoPanelTopTextDEF");
        GlobalVariables.infoPanelTopTextDEF = GlobalVariables.infoPanelTopTextDEFGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopTextDEF.text = "";
        // - top panel unit text DEF
        GlobalVariables.infoPanelTopTextACCvsDEFGO = GameObject.Find("InfoPanelTopTextACCvsDEF");
        GlobalVariables.infoPanelTopTextACCvsDEF = GlobalVariables.infoPanelTopTextACCvsDEFGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopTextACCvsDEF.text = "";

        // - top panel unit text Left
        GlobalVariables.infoPanelTopTextLeftGO = GameObject.Find("InfoPanelTopTextLeft");
        GlobalVariables.infoPanelTopTextLeft = GlobalVariables.infoPanelTopTextLeftGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopTextLeft.text = "";
        // - top panel unit text Right
        GlobalVariables.infoPanelTopTextRightGO = GameObject.Find("InfoPanelTopTextRight");
        GlobalVariables.infoPanelTopTextRight = GlobalVariables.infoPanelTopTextRightGO.GetComponent<Text>();
        GlobalVariables.infoPanelTopTextRight.text = "";

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
        // - info panel unit text column 3
        GlobalVariables.infoPanelUnitText3GO = GameObject.Find("InfoPanelUnitText3");
        GlobalVariables.infoPanelUnitText3 = GlobalVariables.infoPanelUnitText3GO.GetComponent<Text>();
        GlobalVariables.infoPanelUnitText3.text = "";
        // - info panel HP, STA, BAL bars
        // - HP
        GlobalVariables.barHPbgGO = GameObject.Find("barHPbg");
        GlobalVariables.barHPbg = GlobalVariables.barHPbgGO.GetComponent<Image>();
        GlobalVariables.barHPGO = GameObject.Find("barHP");
        GlobalVariables.barHP = GlobalVariables.barHPGO.GetComponent<Image>();
        // - STA
        GlobalVariables.barSTAbgGO = GameObject.Find("barSTAbg");
        GlobalVariables.barSTAbg = GlobalVariables.barSTAbgGO.GetComponent<Image>();
        GlobalVariables.barSTAGO = GameObject.Find("barSTA");
        GlobalVariables.barSTA = GlobalVariables.barSTAGO.GetComponent<Image>();
        // - BAL
        GlobalVariables.barBALbgGO = GameObject.Find("barBALbg");
        GlobalVariables.barBALbg = GlobalVariables.barBALbgGO.GetComponent<Image>();
        GlobalVariables.barBALGO = GameObject.Find("barBAL");
        GlobalVariables.barBAL = GlobalVariables.barBALGO.GetComponent<Image>();
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

    }

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

    public static void DisplayPathCells(int targetX, int targetY, int parentX, int parentY){
        if( GlobalVariables.unitsMatrix[ parentX,parentY ] != null ){
			
			// CharacterType thisChar = GlobalVariables.unitsMatrix[ parentX,parentY ];
			GameObject tilePrefab = GameObject.Find("Controller").GetComponent<GlobalFunctions>().GetHUDPathCell();

            foreach (MovementNode mn in GlobalVariables.unitsMatrix[ parentX,parentY ].availablePaths[ targetX,targetY ]) {
                
                // for some reason team 1 has an extra movement node on their starting cell, but AI teams do not
                if ( GlobalVariables.unitsMatrix[ parentX,parentY ].team != 1 || !(mn.node.x == parentX && mn.node.y == parentY) ) {
                    Instantiate(tilePrefab, new Vector3(mn.node.x, mn.node.y, 0), Quaternion.identity);
                }
                
            }
			
		}
    } // DisplayPathCells

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
		// Debug.Log("UpdateHUDreadyUnit");
		GlobalVariables.HUDReadyUnit.transform.position = new Vector3(posX,posY, 0);
		GlobalVariables.HUDReadyUnit.SetActive(true);
	}

	public static void CleanUpOldHUDreadyUnit(){
        // Debug.Log("CleanUpOldHUDreadyUnit");
		GlobalVariables.HUDReadyUnit.SetActive(false);
	}

    public static void CleanUpUnitInfoPanel(){
		GlobalVariables.infoPanelUnitHeader.text = "";
		GlobalVariables.infoPanelUnitText.text = "";
        GlobalVariables.infoPanelUnitText2.text = "";
        GlobalVariables.infoPanelUnitText3.text = "";
        // clean up HUD icon
        // if(GameObject.Find("unitIcon")){
        //     GameObject goUnitIcon = GameObject.Find("unitIcon");
        //     Destroy(goUnitIcon);
        // }
        // hide the Unit Panel
        GlobalVariables.infoPanelUnitGO.SetActive(false);
        GlobalVariables.barHPGO.SetActive(false);
        GlobalVariables.barHPbgGO.SetActive(false);
        GlobalVariables.barSTAGO.SetActive(false);
        GlobalVariables.barSTAbgGO.SetActive(false);
        GlobalVariables.barBALGO.SetActive(false);
        GlobalVariables.barBALbgGO.SetActive(false);
	}

    public static void DestroyGameObject(string name){
        if(GameObject.Find(name)){
            GameObject goName = GameObject.Find(name);
            Destroy(goName);
        }
    }
    

	public static void CleanUpTerrainInfoPanel(bool panel = false){
		GlobalVariables.infoPanelTerrainHeader.text = "";
		GlobalVariables.infoPanelTerrainText.text = "";
        GlobalVariables.infoPanelTerrainText2.text = "";
        // clean up terrain HUD icon
        CleanUpTileIcon();

        // hide the Terrain Panel
        if(!panel){
            GlobalVariables.infoPanelTerrainGO.SetActive(false);
        }

	}

    public static IEnumerator UpdateTileIcon(int posX, int posY, float wait){
        CleanUpTileIcon();
        yield return new WaitForSeconds(wait);
        DisplayTileIcon(posX,posY);
    }

    // public static void CleanUpBattleOptionIcons(){
    //     if(GameObject.Find("battleOptionIcon")){
    //         GameObject gotileIcon = GameObject.Find("battleOptionIcon");
    //         Destroy(gotileIcon);
    //     }
    // }

    public static void DisplayBattleOptionInfo(Enums.BattleOption battleOption){
        int posX = GlobalVariables.selectedUnit.x;
        int posY = GlobalVariables.selectedUnit.y;
        // do these cases need null checks?
        switch(battleOption){
            case Enums.BattleOption.LightAttack:
                GlobalVariables.infoPanelTerrainHeader.text = "Light Attack";
                // col 1

                // col 2                
                GlobalVariables.infoPanelTerrainText2.text = "DMG: "+GlobalVariables.unitsMatrix[ posX,posY ].lowDamage+" - "+GlobalVariables.unitsMatrix[ posX,posY ].highDamage;                
                GlobalVariables.infoPanelTerrainText2.text += "\n";                                
                GlobalVariables.infoPanelTerrainText2.text += "Worth 10 BAL";
                GlobalVariables.infoPanelTerrainText2.text += "\n";
                GlobalVariables.infoPanelTerrainText2.text += "Costs 10 STA";
                GlobalVariables.infoPanelTerrainText2.text += "\n";
                GlobalVariables.infoPanelTerrainText2.text += "ACC Mod: 0";
                // icon
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONLightAttack, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                    // bind to lower panel
                    tileIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                break;
            case Enums.BattleOption.HeavyAttack:                
                GlobalVariables.infoPanelTerrainHeader.text = "Heavy Attack";
                // col 1

                // col 2
                float highDamageTemp = GlobalVariables.unitsMatrix[ posX,posY ].highDamage;
                GlobalVariables.infoPanelTerrainText2.text = "DMG: "+GlobalVariables.unitsMatrix[ posX,posY ].lowDamage+" - "+CombatCalculateHeavyAttackDmg(highDamageTemp);                
                GlobalVariables.infoPanelTerrainText2.text += "\n";                                
                GlobalVariables.infoPanelTerrainText2.text += "Worth 30 BAL";
                GlobalVariables.infoPanelTerrainText2.text += "\n";
                GlobalVariables.infoPanelTerrainText2.text += "Costs 30 STA";                
                GlobalVariables.infoPanelTerrainText2.text += "\n";                                                
                GlobalVariables.infoPanelTerrainText2.text += "ACC Mod: "+GlobalVariables.heavyAttackAccMod;                
                GlobalVariables.infoPanelTerrainText2.text += "\n";  
                GlobalVariables.infoPanelTerrainText2.text += "CRI Mod: +"+GlobalVariables.heavyAttackBonus;  
                // icon
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONHeavyAttack, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                    // bind to lower panel
                    tileIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                // heavyAttack STATUS ICON
                if( !GameObject.Find("statusIconLOWER") ){
                    GameObject statusIcon = Instantiate(Instance.STATUSICONHeavyAttack, 
                     new Vector3(GlobalVariables.statusIconLowerPanelX, GlobalVariables.statusIconLowerPanelY, 0), Quaternion.identity);
                    statusIcon.name = "statusIconLOWER";
                    // bind to lower panel
                    statusIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                               
                break;
            case Enums.BattleOption.Rally:                
                GlobalVariables.infoPanelTerrainHeader.text = "Rally";
                // col 2
                GlobalVariables.infoPanelTerrainText2.text = "DEF Mod: +"+GlobalVariables.rallyValue;                 
                GlobalVariables.infoPanelTerrainText2.text += "\n";
                GlobalVariables.infoPanelTerrainText2.text += "STA Mod: +50";
                GlobalVariables.infoPanelTerrainText2.text += "\n";
                GlobalVariables.infoPanelTerrainText2.text += "BAL Mod: +50";
                // icon
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONRally, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                    // bind to lower panel
                    tileIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                // rally STATUS ICON
                if( !GameObject.Find("statusIconLOWER") ){
                    GameObject statusIcon = Instantiate(Instance.STATUSICONRally, 
                     new Vector3(GlobalVariables.statusIconLowerPanelX, GlobalVariables.statusIconLowerPanelY, 0), Quaternion.identity);
                    statusIcon.name = "statusIconLOWER";
                    // bind to lower panel
                    statusIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }                
                break;
            case Enums.BattleOption.UseItem:
                // col 2
                GlobalVariables.infoPanelTerrainHeader.text = "Use Item";
                GlobalVariables.infoPanelTerrainText2.text = "Coming soon...";
                // icon
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONUseItem, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                    // bind to lower panel
                    tileIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                break;
            case Enums.BattleOption.CastSpell:
                // col 2
                GlobalVariables.infoPanelTerrainHeader.text = "Cast Spell";
                GlobalVariables.infoPanelTerrainText2.text = "Coming soon...";
                // icon
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONCastSpell, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                    // bind to lower panel
                    tileIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                break;
            case Enums.BattleOption.SpecialAbility:
                // col 2
                GlobalVariables.infoPanelTerrainHeader.text = "Special Ability";
                GlobalVariables.infoPanelTerrainText2.text = "Coming soon...";
                // icon
                if( !GameObject.Find("battleOptionIcon") ){
                    GameObject tileIcon = Instantiate(Instance.ICONSpecialAbility, new Vector3(17.575f, 2.2f, 0), Quaternion.identity);
                    tileIcon.name = "battleOptionIcon";
                    // bind to lower panel
                    tileIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
                break;
            case Enums.BattleOption.EndTurn:
                GlobalVariables.infoPanelTerrainHeader.text = "End Turn";
                break;
        }
    }

    /*
        params:
        int attX            x coord of attacking unit
        int attY            y coord of attacking unit
        int defX            x coord of defending unit
        int defY            y coord of defending unit
     */
     public static void DisplayCompareUnits(int attX, int attY, int defX, int defY){
        UnitType attacker = GlobalVariables.unitsMatrix [ attX,attY ];
        UnitType defender = GlobalVariables.unitsMatrix [ defX,defY ];

        // clean up infoPanelTopText
        GlobalVariables.infoPanelTopText.text = "";

        // display attacker's unit icon and ACC score
        DisplayUnitIcon( attX, attY, 17.575f, 11.3f, "compareUnitIconAtt", GlobalFunctions.FindDirection(Enums.Direction.Right) );
        GlobalVariables.infoPanelTopTextACC.text = CombatCalculateAttackAcc(attX,attY).ToString();
        // display attacker's status icons
        DisplayStatusIcons( attX,attY,Enums.StatusIconLocation.UpperLeft );
        if(attacker.battleOption == Enums.BattleOption.LightAttack){
            GlobalVariables.infoPanelTopTextLeft.text = attacker.battleOption.ToString();
            GlobalVariables.infoPanelTopTextLeft.text += " "+attacker.lowDamage+"-"+attacker.highDamage+" dmg";
            GlobalVariables.infoPanelTopTextLeft.text += "\nCrit chance: "+CombatCalculateCriticalHitRate(attacker)+" %";
        }
        if(attacker.battleOption == Enums.BattleOption.HeavyAttack){
            GlobalVariables.infoPanelTopTextLeft.text = attacker.battleOption.ToString();
            GlobalVariables.infoPanelTopTextLeft.text += " "+attacker.lowDamage+"-"+(int)CombatCalculateHeavyAttackDmg(attacker.highDamage)+" dmg";
            GlobalVariables.infoPanelTopTextLeft.text += "\nCrit chance: "+CombatCalculateCriticalHitRate(attacker)+" %";
        }

        // display defender's unit icon and DEF score
        DisplayUnitIcon( defX, defY, 20.775f, 11.3f, "compareUnitIconDef", GlobalFunctions.FindDirection(Enums.Direction.Left) );      
        GlobalVariables.infoPanelTopTextDEF.text = CombatCalculateDefense(defX,defY).ToString();
        // display defender's status icons
        DisplayStatusIcons( defX,defY,Enums.StatusIconLocation.UpperRight );   
        GlobalVariables.infoPanelTopTextRight.text = defender.hitPoints+"/"+defender.hitPointMax+" HP";

        // generic compare HUD
        GlobalVariables.infoPanelTopTextACCvsDEF.text = "ACC  vs  DEF";      
     }

     public static void CleanUpCompareUnits(){
        GlobalFunctions.DestroyGameObject("compareUnitIconAtt");
		GlobalFunctions.DestroyGameObject("compareUnitIconDef"); 
        GlobalVariables.infoPanelTopTextACCvsDEF.text = "";
        GlobalVariables.infoPanelTopTextACC.text = "";
        GlobalVariables.infoPanelTopTextDEF.text = "";
        GlobalVariables.infoPanelTopTextLeft.text = "";
        GlobalVariables.infoPanelTopTextRight.text = "";
     }

    /*
        params:
        int posX            x coord for cursor cell   
        int posY            y coord for cursor cell
        bool units          whether or not to update display for units (defaults to YES)
        bool terrain        whether or not to update display for terrain (defaults to YES)
        UnitType thisUnit   include terrrain info specific to this unit (defaults to NULL)
     */
    public static void DisplayTileInfo(int posX, int posY, bool units = true, bool terrain = true, UnitType thisUnit = null){

		// UNITS
		if(GlobalVariables.unitsMatrix[ posX,posY ] != null && units){
            // show the Unit Panel
            GlobalVariables.infoPanelUnitGO.SetActive(true);
            GlobalVariables.barHPGO.SetActive(true);
            GlobalVariables.barHPbgGO.SetActive(true);
            GlobalVariables.barSTAGO.SetActive(true);
            GlobalVariables.barSTAbgGO.SetActive(true);
            GlobalVariables.barBALGO.SetActive(true);
            GlobalVariables.barBALbgGO.SetActive(true);
            CleanUpHUDIcons();
			// header
            // GlobalVariables.infoPanelUnitHeader.text = GlobalVariables.unitsMatrix[ posX,posY ].unitType.ToString();
            GlobalVariables.infoPanelUnitHeader.text = GlobalVariables.unitsMatrix[ posX,posY ].name;
            GlobalVariables.infoPanelUnitHeader.text += " (" + GlobalVariables.unitsMatrix[ posX,posY ].unitID + ")";
            // col 1
			GlobalVariables.infoPanelUnitText.text = "HP: " + GlobalVariables.unitsMatrix[ posX,posY ].hitPoints + " / " + GlobalVariables.unitsMatrix[ posX,posY ].hitPointMax;
			GlobalVariables.infoPanelUnitText.text += "\n";
			GlobalVariables.infoPanelUnitText.text += "STA: " + GlobalVariables.unitsMatrix[ posX,posY ].stamina + " %";
			GlobalVariables.infoPanelUnitText.text += "\n";
			GlobalVariables.infoPanelUnitText.text += "BAL: " + GlobalVariables.unitsMatrix[ posX,posY ].balance + " %";
            // col 2
            GlobalVariables.infoPanelUnitText2.text = "ACC: " + GlobalVariables.unitsMatrix[ posX,posY ].accuracy;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            GlobalVariables.infoPanelUnitText2.text += "CRI: " + GlobalVariables.unitsMatrix[ posX,posY ].critical;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            GlobalVariables.infoPanelUnitText2.text += "SPD: " + GlobalVariables.unitsMatrix[ posX,posY ].speed;
			GlobalVariables.infoPanelUnitText2.text += "\n";
            // col 3
            GlobalVariables.infoPanelUnitText3.text = "DEF: " + GlobalVariables.unitsMatrix[ posX,posY ].defense;
			GlobalVariables.infoPanelUnitText3.text += "\n";
            GlobalVariables.infoPanelUnitText3.text += "MOV: " + GlobalVariables.unitsMatrix[ posX,posY ].movementPoints;
            // status bars
            UpdateStatusBars ( posX,posY );
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
            DisplayUnitIcon(
                posX, 
                posY, 
                GlobalVariables.unitIconMiddlePanelX, 
                GlobalVariables.unitIconMiddlePanelY, 
                "unitIcon", 
                GlobalFunctions.FindDirection(Enums.Direction.Down)
            );

            // status icons
            DisplayStatusIcons( posX,posY,Enums.StatusIconLocation.Middle );

		}
		// TERRAIN
        if(GlobalVariables.tilesMatrix[ posX,posY ] != null && terrain){
            
            // specific unit addendums
            string thisMOV = "";
            string thisSTA = "";
            if(thisUnit != null){
                TileCostType tc = DetermineTileCosts(thisUnit, posX, posY);
                if(GlobalVariables.tilesMatrix[ posX,posY ].movementCost != tc.MOVcost){
                    thisMOV = " ("+tc.MOVcost+")" ;
                }
                if(GlobalVariables.tilesMatrix[ posX,posY ].staminaCost != tc.STAcost){
                    thisSTA = " ("+tc.STAcost+")" ;
                }
            }

            // show the Terrain Panel
            GlobalVariables.infoPanelTerrainGO.SetActive(true);
            // header
            GlobalVariables.infoPanelTerrainHeader.text = GlobalVariables.tilesMatrix[ posX,posY ].name;
            GlobalVariables.infoPanelTerrainHeader.text += " (" + posX + "-" + posY + ")";
            // col 1

            // col 2
            GlobalVariables.infoPanelTerrainText2.text = "MOV Cost: " + GlobalVariables.tilesMatrix[ posX,posY ].movementCost + thisMOV;
            GlobalVariables.infoPanelTerrainText2.text += "\n";
            GlobalVariables.infoPanelTerrainText2.text += "STA Cost: " + GlobalVariables.tilesMatrix[ posX,posY ].staminaCost + thisSTA;	            
            GlobalVariables.infoPanelTerrainText2.text += "\n";
            int defMod = GlobalVariables.tilesMatrix[ posX,posY ].defenseMod;
            string defModSymbol = "+";
            if(GlobalVariables.tilesMatrix[ posX,posY ].defenseMod <= 0){
                defModSymbol = "";
            }
            GlobalVariables.infoPanelTerrainText2.text += "DEF Mod: " + defModSymbol + GlobalVariables.tilesMatrix[ posX,posY ].defenseMod;

            // terrain STATUS ICON
            if(defMod != 0){
                if( !GameObject.Find("terrainStatusIconLOWER") ){ // statusIconLOWER  terrainStatusIconLOWER
                    GameObject statusIcon = Instantiate(Instance.STATUSICONTerrain, 
                     new Vector3(GlobalVariables.statusIconLowerPanelX, GlobalVariables.statusIconLowerPanelY, 0), Quaternion.identity);
                    statusIcon.name = "terrainStatusIconLOWER";
                    // bind to lower panel
                    statusIcon.transform.parent = GlobalVariables.infoPanelTerrainGO.transform;
                }
            }           

            // terrain icon
            DisplayTileIcon(posX, posY);
            // track which tile we're displaying
            GlobalVariables.selectedTile.x = posX;
            GlobalVariables.selectedTile.y = posY;
        }
        
	}

    public static void DisplayStatusIcons(int posX, int posY, Enums.StatusIconLocation location){

        // instantiate relevant unit and map tile
        UnitType thisUnit = GlobalVariables.unitsMatrix[ posX,posY ];
        TileType thisTile = GlobalVariables.tilesMatrix[ posX,posY ];

        // determine which triggers are active
        bool balTrigger = false;
        if(thisUnit.balance < 100){
            balTrigger = true;
        }
        bool terrainTrigger = false;
        if(thisTile.defenseMod != 0){
            terrainTrigger = true;
        }
        bool rallyTrigger = false;
        if(thisUnit.rally){
            rallyTrigger = true;
        }
        bool heavyAttackTrigger = false;
        if(thisUnit.battleOption == Enums.BattleOption.HeavyAttack){
            heavyAttackTrigger = true;
        }     

        // determine which names and tags are relevant
        // determine which base location is relevant
        string statusIconName = "";
        string statusIconTag = "";
        float statusIconX = 0;
        float statusIconY = 0;        
        if (location == Enums.StatusIconLocation.Middle) {
            statusIconName = "statusIconMIDDLE";
            statusIconTag = "Status_Icon_Middle";
            statusIconX = 17.2f;
            statusIconY = 6.15f;            
        }else if (location == Enums.StatusIconLocation.UpperLeft){
            statusIconName = "statusIconUPPERLEFT";
            statusIconTag = "Status_Icon_Top";
            statusIconX = 17.2f;
            statusIconY = 10.445f;             
        }else if (location == Enums.StatusIconLocation.UpperRight){
            statusIconName = "statusIconUPPERRIGHT";
            statusIconTag = "Status_Icon_Top";
            statusIconX = 21.15f;
            statusIconY = 10.445f;  
        }

        if( GlobalVariables.unitStatusIcons.posX != posX || 
            GlobalVariables.unitStatusIcons.posY != posY || 
            balTrigger != GlobalVariables.unitStatusIcons.BAL || 
            terrainTrigger != GlobalVariables.unitStatusIcons.terrain || 
            rallyTrigger != GlobalVariables.unitStatusIcons.rally || 
            heavyAttackTrigger != GlobalVariables.unitStatusIcons.heavyAttack ||
            location != Enums.StatusIconLocation.Middle
        ){
            
            // update GlobalVariables.unitStatusIcons 
            if(location == Enums.StatusIconLocation.Middle){
                GlobalVariables.unitStatusIcons.posX = posX;
                GlobalVariables.unitStatusIcons.posY = posY;
            }

            // wipe slate in order to update with currently relevant status icons
            if(location == Enums.StatusIconLocation.Middle){
                foreach(GameObject statusIcon in GameObject.FindGameObjectsWithTag(statusIconTag)){
                    Destroy(statusIcon);
                }
            }


            // BAL mod
            if(balTrigger){
                GameObject statusIcon = Instantiate(Instance.STATUSICONBal, 
                    new Vector3(statusIconX, statusIconY, 0), Quaternion.identity);
                // tag and name
                statusIcon.name = statusIconName;
                statusIcon.tag = statusIconTag;
                // bind to lower panel
                statusIcon.transform.parent = GlobalVariables.infoPanelUnitGO.transform;
                // update GlobalVariables.unitStatusIcons
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.BAL = true;
                }                
                // increment location
                if (location != Enums.StatusIconLocation.UpperRight){
                    statusIconX = statusIconX + .4f;
                }else{
                    statusIconX = statusIconX - .4f;
                }  
            }else{            
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.BAL = false;
                }
            }
            // terrain
            if(terrainTrigger && location != Enums.StatusIconLocation.UpperLeft){
                GameObject statusIcon = Instantiate(Instance.STATUSICONTerrain, 
                    new Vector3(statusIconX, statusIconY, 0), Quaternion.identity);
                // tag and name                    
                statusIcon.name = statusIconName;
                statusIcon.tag = statusIconTag;
                // bind to lower panel
                statusIcon.transform.parent = GlobalVariables.infoPanelUnitGO.transform;
                // update GlobalVariables.unitStatusIcons                
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.terrain = true;
                }
                // increment location
                if (location != Enums.StatusIconLocation.UpperRight){
                    statusIconX = statusIconX + .4f;
                }else{
                    statusIconX = statusIconX - .4f;
                }
            }else{
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.terrain = false;
                }                
            }        
            // rally
            if(rallyTrigger && location != Enums.StatusIconLocation.UpperLeft){
                GameObject statusIcon = Instantiate(Instance.STATUSICONRally, 
                    new Vector3(statusIconX, statusIconY, 0), Quaternion.identity);
                // tag and name
                statusIcon.name = statusIconName;
                statusIcon.tag = statusIconTag;
                // bind to lower panel
                statusIcon.transform.parent = GlobalVariables.infoPanelUnitGO.transform;
                // update GlobalVariables.unitStatusIcons                
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.rally = true;
                }
                // increment location
                if (location != Enums.StatusIconLocation.UpperRight){
                    statusIconX = statusIconX + .4f;
                }else{
                    statusIconX = statusIconX - .4f;
                }
            }else{
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.rally = false;
                }                
            }                
            // heavy attack
            if(heavyAttackTrigger && location != Enums.StatusIconLocation.UpperRight && location != Enums.StatusIconLocation.Middle){
                GameObject statusIcon = Instantiate(Instance.STATUSICONHeavyAttack, 
                    new Vector3(statusIconX, statusIconY, 0), Quaternion.identity);
                // tag and name
                statusIcon.name = statusIconName;
                statusIcon.tag = statusIconTag;
                // bind to lower panel
                statusIcon.transform.parent = GlobalVariables.infoPanelUnitGO.transform;
                // update GlobalVariables.unitStatusIcons
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.heavyAttack = true;
                }
                // increment location
                if (location != Enums.StatusIconLocation.UpperRight){
                    statusIconX = statusIconX + .4f;
                }else{
                    statusIconX = statusIconX - .4f;
                }
            }else{
                if(location == Enums.StatusIconLocation.Middle){
                    GlobalVariables.unitStatusIcons.heavyAttack = false;
                }
            }              
        } // end checks

    }

    /*
        params:
        int posX                x coord of unit whose icon we want to display 
        int posY                y coord of unit whose icon we want to display 
        float iconPosX          x coord of where we want the icon to display
        float iconPosY          y coord of where we want the icon to display
        string iconName         handle for the icon (to manage it's cleanup)
        Quaternion direction    facing of icon
     */
    public static void DisplayUnitIcon(int posX, int posY, float iconPosX, float iconPosY, string iconName, Quaternion direction ){
        if( !GameObject.Find(iconName) ){
            GameObject unitPrefab = GlobalVariables.unitsMatrix[ posX,posY ].unitPrefab;
            GameObject unitIcon = Instantiate(unitPrefab, new Vector3(iconPosX, iconPosY, 0), direction);
            unitIcon.name = iconName;
        }
    }

    public static void DisplayTileIcon(int posX, int posY){
        if( !GameObject.Find("tileIcon") ){
            GameObject tilePrefab = GlobalVariables.tilesMatrix[ posX,posY ].tilePrefab;
            GameObject tileIcon = Instantiate(tilePrefab, new Vector3(17.575f, 2.2f, 0), tilePrefab.transform.localRotation);
            tileIcon.name = "tileIcon";
        }
    }

    public static void CleanUpTileIcon(){
        // clean up terrain HUD icon
        if(GameObject.Find("tileIcon")){
            GameObject gotileIcon = GameObject.Find("tileIcon");
            Destroy(gotileIcon);
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
    
    public static void UpdateStatusBars( int posX, int posY ){
        // establish current values
        int HP = GlobalVariables.unitsMatrix [ posX,posY ].hitPoints;
        int maxHP = GlobalVariables.unitsMatrix [ posX,posY ].hitPointMax;
        int STA = GlobalVariables.unitsMatrix [ posX,posY ].stamina;
        int BAL = GlobalVariables.unitsMatrix [ posX,posY ].balance;
        // convert to percentages
        float HPpercent = (float)HP / (float)maxHP;
        float STApercent = (float)STA / 100f;
        float BALpercent = (float)BAL / 100f;
        // update display
        GlobalVariables.barHP.fillAmount = HPpercent;
        GlobalVariables.barSTA.fillAmount = STApercent;
        GlobalVariables.barBAL.fillAmount = BALpercent;
    }

    public static void CleanUpBattleLog(){
        if( 
            (GlobalVariables.unitsMatrix[ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].unitID != GlobalVariables.lastUnitID)  
        ){
            GlobalVariables.infoPanelTopText.text = "";
            GlobalVariables.lastRound = GlobalVariables.round; // you'll probably need to add this to the conditional logic
            GlobalVariables.lastUnitID = GlobalVariables.initRoster[0].unitID;
        }
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
        Debug.Log("UpdateInitiative()");

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
        bool teamOne = PrepForTurn();
        if(teamOne){
            UpdateWhoIsNext();
        }

		Debug.Log("\nAfter sort by initiative:");
        foreach (Initiative init in GlobalVariables.initRoster)
        {
            Debug.Log("Inititive: "+init.initiative+" UnitID: "+init.unitID);
        }

        GlobalVariables.round++;
        GlobalVariables.infoPanelTopHeader.text = "Round "+GlobalVariables.round;
        GlobalVariables.infoPanelTopText.text += "Round "+GlobalVariables.round+". ";
        GlobalVariables.infoPanelTopText.text += GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ].name+" goes first.";
    
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
        Quaternion quatDir = FindDirectionToFaceTarget(parentX, parentY, targetX, targetY);
        float destX = 0;
        float destY = 0;

        if(parentX == targetX){
            // Debug.Log("X is the same!");
            destX = parentX;
            if(parentY < targetY){ // up
                destY = (parentY + .5f);
            }else{ // down
                destY = (parentY - .5f);
            }
        }else if(parentY == targetY){
            destY = parentY;
            // Debug.Log("Y is the same!");
            if(parentX < targetX){ // right
                destX = (parentX + .5f);
            }else{ // left
                destX = (parentX - .5f);
            }
        }
        Instantiate(tilePrefab, new Vector3(destX, destY, 0), quatDir);
    }

    public static void CombatAttack(int parentX, int parentY, int targetX, int targetY){

        if( GlobalVariables.unitsMatrix[ targetX,targetY ] != null ){

            // instantiate units
            UnitType attacker = GlobalVariables.unitsMatrix[ parentX,parentY ];
            UnitType defender = GlobalVariables.unitsMatrix[ targetX,targetY ];

            // variable bank
            Enums.BattleOption battleOption = attacker.battleOption;
            float attackRoll = UnityEngine.Random.Range(1, 21);
            attackRoll += CombatCalculateAttackAcc(parentX,parentY);
            float defendRoll = UnityEngine.Random.Range(1, 21);
            defendRoll += CombatCalculateDefense(targetX, targetY);
            int damageRoll = 0; // initialize
            // LIGHT ATTACK damage
            if(battleOption == Enums.BattleOption.LightAttack){
                damageRoll = UnityEngine.Random.Range( attacker.lowDamage,(attacker.highDamage+1) );
            // HEAVY ATTACK damage
            }else if(battleOption == Enums.BattleOption.HeavyAttack){
                float highDamageTemp = attacker.highDamage;
                damageRoll = UnityEngine.Random.Range( attacker.lowDamage,((int)CombatCalculateHeavyAttackDmg(highDamageTemp)+1) );  
            }
            // set up BAL value 
            int BALvalue = 10; // initialize
            if(battleOption == Enums.BattleOption.LightAttack){
                BALvalue = 10;
            }else if(battleOption == Enums.BattleOption.HeavyAttack){
                BALvalue = 30; 
            }
            bool critHit = false;

            // consider critical hit (use critHit to remember locally)

            int critRoll = UnityEngine.Random.Range( 1,101 );
            if(critRoll <= CombatCalculateCriticalHitRate(attacker)){
                critHit = true;
                float damageRollTemp = damageRoll * GlobalVariables.critMultiplier;
                damageRoll = (int)damageRollTemp;
            }

            Debug.Log("BAL: "+attacker.balance+" attack roll before: "+attackRoll);
            Debug.Log("BAL: "+defender.balance+" defend roll before: "+defendRoll);

            Debug.Log("attack roll: "+attackRoll);
            Debug.Log("defend roll: "+defendRoll);

            // conduct attack
                // HIT!
            if(attackRoll >= defendRoll){ 
                defender.hitPoints = LessThanZero(defender.hitPoints - damageRoll);
                defender.balance = LessThanZero(defender.balance - BALvalue);
                if(critHit){
                    Debug.Log("critical hit!");
                    GlobalVariables.infoPanelTopText.text += "Critical hit! ";
                }
                Debug.Log("attacker deals "+damageRoll+" damage with "+battleOption.ToString());
                GlobalVariables.infoPanelTopText.text += attacker.name+" deals "+damageRoll+" damage to "+defender.name+" with "+battleOption.ToString()+".\n\n";
                // MISS!
            }else{ 
                attacker.balance = LessThanZero(attacker.balance - BALvalue);
                Debug.Log("attacker missed!");
                GlobalVariables.infoPanelTopText.text = attacker.name+" attacked "+defender.name+" but missed!\n\n";
            }

            // update units
            GlobalVariables.unitsMatrix[ parentX,parentY ] = attacker;
            GlobalVariables.unitsMatrix[ targetX,targetY ] = defender;
            // reflect updates in HUD
		    GlobalFunctions.DisplayTileInfo(parentX, parentY, true, false); 

        }
        // consume attacker's ability to act again this turn
        GlobalVariables.unitsMatrix[ parentX,parentY ].canAct = false;
        GlobalVariables.unitsMatrix[ parentX,parentY ].battleOption = Enums.BattleOption.None;
		// clean up TOP status icons
		foreach(GameObject statusIcon in GameObject.FindGameObjectsWithTag("Status_Icon_Top")){
			Destroy(statusIcon);
		}        

    }

    public static float CombatCalculateAttackAcc(int attX, int attY){
        UnitType attacker = GlobalVariables.unitsMatrix[ attX,attY ];
        // float attackRoll = UnityEngine.Random.Range(1, 21);
        float attackRoll = 0;
        // consider accuracy
        attackRoll += (int)attacker.accuracy;
        // consider heavy attack penalty to accuracy
        if(attacker.battleOption == Enums.BattleOption.HeavyAttack){
            attackRoll = attackRoll + GlobalVariables.heavyAttackAccMod;
        }
        // factor BAL
        float attFactor = ((float)attacker.balance / 100f);
        if(attFactor < 1){
            Debug.Log("AT: "+attFactor);
            float attFactorMod = 1 - attFactor;
            // Debug.Log("ATM: "+attFactorMod);
            attFactorMod = attFactorMod * GlobalVariables.BALmod;
            // Debug.Log("ATM: "+attFactorMod);
            attFactor = 1 - attFactorMod;
            Debug.Log("AT: "+attFactor);
        }
        // Debug.Log("attackfactor: "+attFactor);
        attackRoll = attackRoll * attFactor;

        return attackRoll;
    }

    public static float CombatCalculateDefense(int posX, int posY){
        UnitType defender = GlobalVariables.unitsMatrix[ posX,posY ];
        float defendRoll = 0;
        // consider defense
        defendRoll += (int)defender.defense;
        // - consider rallying bonus
        if(defender.rally){
            defendRoll += GlobalVariables.rallyValue;
            Debug.Log("rally bonus applied: +"+GlobalVariables.rallyValue+" DEF!");
        }
        // - consider terrain bonus to DEF
        if(GlobalVariables.tilesMatrix [ posX,posY ].defenseMod != 0){
            defendRoll += GlobalVariables.tilesMatrix [ posX,posY ].defenseMod;
            if(GlobalVariables.tilesMatrix [ posX,posY ].defenseMod > 0){ // logic just for debug log
                Debug.Log("terrain bonus applied: +"+GlobalVariables.tilesMatrix [ posX,posY ].defenseMod+" DEF!");
            }
            Debug.Log("terrain bonus applied: "+GlobalVariables.tilesMatrix [ posX,posY ].defenseMod+" DEF!");
        }
        // factor BAL
        float defFactor = ((float)defender.balance / 100f);
        if(defFactor < 1){
            Debug.Log("DF: "+defFactor);
            float defFactorMod = 1 - defFactor;
            // Debug.Log("DFM: "+defFactorMod);
            defFactorMod = defFactorMod * GlobalVariables.BALmod;
            // Debug.Log("DFM: "+defFactorMod);
            defFactor = 1 - defFactorMod;
            Debug.Log("DT: "+defFactor);
        }
        // Debug.Log("defend factor: "+defFactor);
        defendRoll = defendRoll * defFactor;

        return defendRoll;
    }

    public static float CombatCalculateHeavyAttackDmg(float highDamageTemp){
        float highDamage = highDamageTemp;
        highDamageTemp = highDamageTemp * GlobalVariables.heavyAttackMod;
        float heavyDamageDiff = highDamageTemp - highDamage;
        if(heavyDamageDiff < GlobalVariables.heavyAttackBonus){
            highDamageTemp = highDamage + GlobalVariables.heavyAttackBonus;
        }
        return highDamageTemp;
    }

    public static int CombatCalculateCriticalHitRate(UnitType thisUnit){
        int critRate = thisUnit.critical;
        if(thisUnit.battleOption == Enums.BattleOption.HeavyAttack){
            critRate = critRate + GlobalVariables.heavyAttackBonus;
        }
        return critRate;
    }

    public static void CombatRally(int posX, int posY){
        // reset ICON state
		// GlobalFunctions.CleanUpBattleOptionIcons();
        GlobalFunctions.DestroyGameObject("battleOptionIcon");
        GlobalFunctions.DestroyGameObject("statusIconLOWER");

        // gather existing values
        int thisSTA = GlobalVariables.unitsMatrix[ posX,posY ].stamina;
        int thisBAL = GlobalVariables.unitsMatrix[ posX,posY ].balance;

        // modify values as per Rally
        thisSTA = MoreThanOneHundred(thisSTA + 50);
        thisBAL = MoreThanOneHundred(thisBAL + 50);

        // update unit with modified values
        GlobalVariables.unitsMatrix[ posX,posY ].stamina = thisSTA;
        GlobalVariables.unitsMatrix[ posX,posY ].balance = thisBAL;
        GlobalVariables.unitsMatrix[ posX,posY ].rally = true;

        // update available cells for this unit
        RefreshUnitAvailabileCells( posX,posY );

        // consumer unit's movement
        GlobalVariables.unitsMatrix[ posX,posY ].canAct = false;

        // reflect updates in HUD
		GlobalFunctions.DisplayTileInfo( posX,posY, true, true); 

        GlobalVariables.infoPanelTopText.text = GlobalVariables.unitsMatrix[ posX,posY ].name+" uses Rally. +50 BAL and STA.\n\n";

        // clean up
        CheckForEndOfTurn(posX,posY);
    }

    public static void CombatEndTurn(int posX, int posY){
        Debug.Log("CombatEndTurn()");
        // consumer unit's action and movement
        GlobalVariables.unitsMatrix [ posX,posY ].canAct = false;
        GlobalVariables.unitsMatrix [ posX,posY ].canMove = false;
        // reflect updates in HUD
		GlobalFunctions.DisplayTileInfo( posX,posY, true, true); 
        GlobalVariables.HUDCursor.SetActive(false);
        // clean up
        CheckForEndOfTurn(posX,posY);
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

    public static int MoreThanOneHundred(int value){
        if(value < 100){
            return value;
        }else{
            return 100;
        }
    }

    public static void CheckForEndOfTurn(int posX, int posY){
        UnitType thisUnit = GlobalVariables.unitsMatrix[ posX,posY ];
        Debug.Log("CheckForEndOfTurn()");
        // if this unit is done attacking, and moving
        if( !thisUnit.canAct && !thisUnit.canMove ){

            GlobalVariables.initRoster.RemoveAt(0);
            // Debug.Log("removing (0) from initRoster. Count is now: "+GlobalVariables.initRoster.Count);

            // un-SELECT this unit
			GlobalVariables.selectedUnit = new Vector3Int(0,0,0); // this doesn't seem to work?
            Debug.Log(GlobalVariables.unitsMatrix[ posX,posY ].name+" finished it's turn.");
            GlobalVariables.infoPanelTopText.text += thisUnit.name+" finished it's turn.\n\n";

            if(GlobalVariables.initRoster.Count <= 0){
                UpdateInitiative();
            }else{
                // is this part necessary? don't we already do this in UpdateInitiative()?
                bool teamOne = PrepForTurn();
            }
            UpdateWhoIsNext();

            GlobalVariables.selectedUnit.x = 0;
            GlobalVariables.selectedUnit.y = 0;
        // if this unit is done attacking, but can still move
        }else if( !thisUnit.canAct && thisUnit.canMove ){
            DisplayAvailableCells(posX,posY);
            // CleanUpBattleOptionIcons(); // should it remove this HERE?
            GlobalFunctions.DestroyGameObject("battleOptionIcon");
            GlobalFunctions.DestroyGameObject("statusIconLOWER");
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
                    // PrepForTurn();
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
            // GlobalVariables.infoPanelTopText.text = thisChar.name + " (" + thisChar.unitID + ")";
            UpdateHUDreadyUnit( GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY );
        }
    }

    public static bool PrepForTurn(){
        Debug.Log("PrepForTurn()");
        bool teamOne = true;
        UnitType thisUnit = GlobalVariables.unitsMatrix [ GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY ];
        if(thisUnit.team != 1){
            Debug.Log("Prepping "+thisUnit.name+" for it's turn!!!!");
            AIProcessNPCTurn(GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY);
            teamOne = false;
        }
        
        thisUnit.canAct = true;
        thisUnit.canMove = true;
        thisUnit.rally = false;

        return teamOne;
    }



    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ******    ******          **************************************************************************************************************************
    // ****   **   ********  ******************************************************************************************************************************
    // ***  ******  *******  ******************************************************************************************************************************
    // ***          *******  ******************************************************************************************************************************
    // ***  ******  *******  ******************************************************************************************************************************
    // ***  ******  *******  ******************************************************************************************************************************
    // ***  ******  ***           *************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************



    /*
        params:
        int posX        x coord of NPC
        int posY        y coord of NPC
     */
    public static void AIProcessNPCTurn( int npcX, int npcY ){
        Debug.Log("AIProcessNPCTurn");
        UnitType nearestThreat = AIDetermineNearestThreat(npcX,npcY);
        // Debug.Log("nearest threat: "+nearestThreat.npcX+"-"+nearestThreat.npcY);
        // if there is no "nearest threat", then bail out!
        if (nearestThreat == null){
            return;
        }
        // true if enemy is far, false if enemy is near
        bool foeIsAdjacent = AIDetermineIfThreatIsAdjacent(nearestThreat, npcX, npcY); 
        // Debug.Log("<---------------------------------------------- foeIsAdjacent is <"+foeIsAdjacent+" >");

        Vector2Int targetTile;  
        if(!foeIsAdjacent){
            targetTile = AIDetermineBestTargetTile(GlobalVariables.unitsMatrix[ npcX,npcY ], nearestThreat);
        }else{
            targetTile = new Vector2Int(npcX,npcY); 
        }

        // if(targetTile.x != npcX || targetTile.y != npcY){
        if(!foeIsAdjacent){
            CleanUpOldHUDreadyUnit();
            DisplayAvailableCells(npcX, npcY);
            DisplayPathCells(targetTile.x,targetTile.y, npcX, npcY);
            GlobalVariables.unitsMatrix[ npcX,npcY ].unitPrefab.GetComponent<MovementUnit>().MoveUnit(npcX,npcY,targetTile.x,targetTile.y);
        }
        CleanUpOldHUDreadyUnit();
        
    }

    /*
        Determine if threat is adjacent to NPC
     */
    public static bool AIDetermineIfThreatIsAdjacent(UnitType nearestThreat, int npcX, int npcY){
        bool foeIsAdjacent = false; // set to true if foe is adjacent to NPC
        int threatAdjacentX = 0;
        int threatAdjacentY = 0;
        // above
        threatAdjacentX = nearestThreat.posX;
        threatAdjacentY = (nearestThreat.posY+1);
        if(threatAdjacentX == npcX && threatAdjacentY == npcY){
            foeIsAdjacent = true;
        }
        // below
        threatAdjacentX = nearestThreat.posX;
        threatAdjacentY = (nearestThreat.posY-1);    
        if(threatAdjacentX == npcX && threatAdjacentY == npcY){
            foeIsAdjacent = true;
        }            
        // left
        threatAdjacentX = (nearestThreat.posX-1);
        threatAdjacentY = nearestThreat.posY;        
        if(threatAdjacentX == npcX && threatAdjacentY == npcY){
            foeIsAdjacent = true;
        }        
        // right
        threatAdjacentX = (nearestThreat.posX+1);
        threatAdjacentY = nearestThreat.posY;   
        if(threatAdjacentX == npcX && threatAdjacentY == npcY){
            foeIsAdjacent = true;
        }  
        return foeIsAdjacent;
    }

    /*
        Determine if threat is adjacent to or within availableCells of NPC
     */
    public static bool AIDetermineIfThreatIsNear(UnitType nearestThreat, int npcX, int npcY){
        bool foeIsNear = false; // set to false if threat is within (or adjacent) existing availableCells
        int threatAdjacentX = 0;
        int threatAdjacentY = 0;
        // above
        threatAdjacentX = nearestThreat.posX;
        threatAdjacentY = (nearestThreat.posY+1);
        if(GlobalVariables.unitsMatrix[ npcX,npcY ].availableCells[ threatAdjacentX,threatAdjacentY ] != null){
            foeIsNear = true;
        }
        // below
        threatAdjacentX = nearestThreat.posX;
        threatAdjacentY = (nearestThreat.posY-1);    
        if(GlobalVariables.unitsMatrix[ npcX,npcY ].availableCells[ threatAdjacentX,threatAdjacentY ] != null){
            foeIsNear = true;
        }            
        // left
        threatAdjacentX = (nearestThreat.posX-1);
        threatAdjacentY = nearestThreat.posY;        
        if(GlobalVariables.unitsMatrix[ npcX,npcY ].availableCells[ threatAdjacentX,threatAdjacentY ] != null){
            foeIsNear = true;
        }        
        // right
        threatAdjacentX = (nearestThreat.posX+1);
        threatAdjacentY = nearestThreat.posY;   
        if(GlobalVariables.unitsMatrix[ npcX,npcY ].availableCells[ threatAdjacentX,threatAdjacentY ] != null){
            foeIsNear = true;
        }  
        return foeIsNear;
    }

    /*
        params:
        int posX        x coord of NPC
        int posY        y coord of NPC
     */
    public static UnitType AIDetermineNearestThreat(int posX, int posY){
        // Debug.Log("AIDetermineNearestThreat");
        UnitType thisUnit = GlobalVariables.unitsMatrix[ posX,posY ];
        
        // distance of nearest team 1 unit
        float nearestDistance = 1000f;
        // location of nearest team 1 unit
        int nearX = 0;
        int nearY = 0;

        // loop through team 1 units (initRoster is NOT the way to loop here. use unitMatrix instead)
        foreach(UnitType unit in GlobalVariables.unitsMatrix){
            if(unit != null && unit.team == 1){  
                float thisDistance = AICalculateDistance(posX, posY, unit.posX, unit.posY);
                if(thisDistance < nearestDistance){
                    nearestDistance = thisDistance;
                    nearX = unit.posX;
                    nearY = unit.posY;
                }
            }
        }
        return GlobalVariables.unitsMatrix[ nearX,nearY ];
    }

    /*
        params:
        int posX1               x coord of NPC 
        int posY1               y coord of NPC
        int posX2               x coord of team 1 unit 
        int posY2               y coord of team 1 unit
     */
    public static float AICalculateDistance(int posX1, int posY1, int posX2, int posY2){
        // Debug.Log("AICalculateDistance");
        float distance = 0f;
        float xDist = posX1 - posX2;
        float yDist = posY1 - posY2;
        // Debug.Log("xDist: "+xDist+" yDist: "+yDist);
        if(xDist < 0){
            xDist = xDist * -1;
        }
        if(yDist < 0){
            yDist = yDist * -1;
        }
        distance = xDist + yDist - 1;
        // Debug.Log("distance: "+distance);

        return distance;
    }

    public static Vector2Int AIDetermineBestTargetTile(UnitType thisUnit, UnitType nearestThreat){
        Vector2Int bestTile = new Vector2Int(0,0);

        // determine best target cell among availableCells
        int lastX = 0;
        int lastY = 0;
        float maxDistance = 10000f;
        float thisDistance = 10000f;
        for(int c = 1; c < thisUnit.availableCells.GetLength(0); c++){
            for(int r = 1; r < thisUnit.availableCells.GetLength(1); r++){
                if(thisUnit.availableCells[ c,r ] != null && 
                    thisUnit.availableCellsSTA[ c,r ] != null &&
                    GlobalVariables.unitsMatrix[ c,r ] == null &&                                   // doesn't include self
                //   ( GlobalVariables.unitsMatrix[ c,r ] == null || (c == thisUnit.posX && r == thisUnit.posY) ) &&       // includes self 
                    Int32.Parse(thisUnit.availableCellsSTA[ c,r ]) >= 0 ){
                        thisDistance = AICalculateDistance(nearestThreat.posX, nearestThreat.posY, c, r);
                        // Debug.Log("distance between "+c+"-"+r+" and "+nearestThreat.posX+"-"+nearestThreat.posY+" is "+thisDistance);
                        if(thisDistance < maxDistance){
                            maxDistance = thisDistance;
                            // Debug.Log("thisUnit.availableCells[ c,r ] "+thisUnit.availableCells[ c,r ]);
                            lastX = c;
                            lastY = r;
                        }
                    }
            }
        }
        // Debug.Log("LAST match: "+lastX+"-"+lastY);
        bestTile.x = lastX;
        bestTile.y = lastY;

        return bestTile;
    } // end AIDetermineBestTargetTile




    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ***  ******  ***          ***          ***  ***********          ***          ***  ******  *********************************************************
    // ***  ******  *******  ***********  *******  ***************  ***********  *******  ******  *********************************************************
    // ***  ******  *******  ***********  *******  ***************  ***********  ********  ****  **********************************************************
    // ***  ******  *******  ***********  *******  ***************  ***********  *********      ***********************************************************
    // ***  ******  *******  ***********  *******  ***************  ***********  ***********  *************************************************************
    // ***    **    *******  ***********  *******  ***************  ***********  ***********  *************************************************************
    // *****      *********  *******          ***          ***          *******  ***********  *************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************
    // ****************************************************************************************************************************************************




    public static Quaternion FindDirectionToFaceTarget(int parentX, int parentY, int targetX, int targetY){

        Quaternion quatDir = Quaternion.Euler (0, 0, 0);

        if(parentX == targetX){
            if(parentY < targetY){ // up
                quatDir = Quaternion.Euler (0, 0, 0);
            }else{ // down
                quatDir = Quaternion.Euler (0, 0, 180);
            }
        }else if(parentY == targetY){
            if(parentX < targetX){ // right
                quatDir = Quaternion.Euler (0, 0, 270);
            }else{ // left
                quatDir = Quaternion.Euler (0, 0, 90);
            }
        }
        return quatDir;

    }










































} // end GlobalFunctions
