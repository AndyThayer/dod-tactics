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
    public GameObject HUDInfoPanel;
    public GameObject HUDCursor;

    // tileTypes
    public TileType[] tileTypes;

     public GameObject hunter;

    // prefab Tiles
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
        GlobalVariables.characterMatrix = new CharacterType[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
    }

    public static void InitializeBoardVariables(){
        GlobalVariables.grid = GameObject.FindGameObjectWithTag("Grid");
		GlobalVariables.tilemapGO = GlobalVariables.grid.transform.Find("Tilemap").gameObject;
        GlobalVariables.tilemap = GlobalVariables.tilemapGO.GetComponent<Tilemap>();
    }

    public static void InitializeHUDObjects(){
        // GlobalVariables.HUDinfoPanel = HUDinfoPanel;
        GlobalVariables.HUDInfoPanel = Instantiate(Instance.HUDInfoPanel, new Vector3(-5, -5, 0), Quaternion.identity);
        GlobalVariables.HUDInfoPanel.SetActive(false);
        GlobalVariables.HUDInfoPanel.name = "HUD_info_panel";
        
        // HUD cursor
        GlobalVariables.HUDCursor = Instantiate(Instance.HUDCursor, new Vector3(-1, -1, 0), Quaternion.identity);
        GlobalVariables.HUDCursor.SetActive(false);
        GlobalVariables.HUDCursor.name = "HUD_cursor";

        // HUD text
        // - info panel unit header
        GlobalVariables.infoPanelUnitHeaderGO = GameObject.Find("InfoPanelUnitHeader");
        GlobalVariables.infoPanelUnitHeader = GlobalVariables.infoPanelUnitHeaderGO.GetComponent<Text>();
        GlobalVariables.infoPanelUnitHeader.text = "";
        // - info panel unit text
        GlobalVariables.infoPanelUnitTextGO = GameObject.Find("InfoPanelUnitText");
        GlobalVariables.infoPanelUnitText = GlobalVariables.infoPanelUnitTextGO.GetComponent<Text>();
        GlobalVariables.infoPanelUnitText.text = "";
        // - info panel terrain header
        GlobalVariables.infoPanelTerrainHeaderGO = GameObject.Find("InfoPanelTerrainHeader");
        GlobalVariables.infoPanelTerrainHeader = GlobalVariables.infoPanelTerrainHeaderGO.GetComponent<Text>();
        GlobalVariables.infoPanelTerrainHeader.text = "";
        // - info panel terrain text
        GlobalVariables.infoPanelTerrainTextGO = GameObject.Find("InfoPanelTerrainText");
        GlobalVariables.infoPanelTerrainText = GlobalVariables.infoPanelTerrainTextGO.GetComponent<Text>();
        GlobalVariables.infoPanelTerrainText.text = "";
    }

    public static void InitializePathfinding(){
        GlobalVariables.graph = new Node[GlobalVariables.boardWidth, GlobalVariables.boardHeight];
        GlobalVariables.currentPath = null;
    }

    public void LoadFromTilemap(){

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
                        BuildTile(posX, posY, waterBLCornerTile, Enums.TileType.Water, tile.name);
                        break;
                    case "water_BR_corner":
                        BuildTile(posX, posY, waterBRCornerTile, Enums.TileType.Water, tile.name);
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
                        BuildTile(posX, posY, waterRLTile, Enums.TileType.Water, tile.name);
                        break;
                    case "water_T":
                        BuildTile(posX, posY, waterTTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_T_corners":
                        BuildTile(posX, posY, waterTCornersTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_TB":
                        BuildTile(posX, posY, waterTBTile, Enums.TileType.Water, tile.name);
                        break;
                    case "water_TL":
                        BuildTile(posX, posY, waterTLTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_TL_corner":
                        BuildTile(posX, posY, waterTLCornerTile, Enums.TileType.Water, tile.name);
                        break;
                    case "water_TR":
                        BuildTile(posX, posY, waterTRTile, Enums.TileType.WaterDeep, tile.name);
                        break;
                    case "water_TR_corner":
                        BuildTile(posX, posY, waterTRCornerTile, Enums.TileType.Water, tile.name);
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
        GlobalVariables.tilesMatrix[posX,posY] = (tile);
        // spawn prefab, set its name, and add it to parent container
        GameObject tilePrefabGO = Instantiate(tilePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
        tilePrefabGO.name = posX + "_" + posY + "_" + rawName + "_tile";
        tilePrefabGO.transform.parent = MT.transform;
        tilePrefabGO.GetComponent<GameTile>().SetTileType(type);
    }

    public void SpawnUnit(Enums.CharacterType type, int posX, int posY, Quaternion direction){
        // find parent container
        GameObject Units = GameObject.Find("Units");
        // create an instance and add it to the matrix
        CharacterType character = new CharacterType(type);
        character.availableCells = FindAvailableCells(character.movementPoints, posX, posY);
        GlobalVariables.characterMatrix[posX,posY] = character;
        // spawn prefab, set its name, and add it to parent container
        // GameObject charPrefabGO = Instantiate(hunter, new Vector3(posX, posY, 0), Quaternion.identity);
        GameObject charPrefabGO = Instantiate(hunter, new Vector3(posX, posY, 0), direction);
        charPrefabGO.name = "character_" + type.ToString() + "_" + character.characterID;
        charPrefabGO.transform.parent = Units.transform;
    }

    public void GeneratePathfindingGraph(){
        // Initialize the array
		GlobalVariables.graph = new Node[GlobalVariables.boardWidth,GlobalVariables.boardHeight];

		// Initialize a Node for each spot in the array
		for(int x=0; x < GlobalVariables.boardWidth; x++) {
			for(int y=0; y < GlobalVariables.boardHeight; y++) {
				GlobalVariables.graph[x,y] = new Node();
				GlobalVariables.graph[x,y].x = x;
				GlobalVariables.graph[x,y].y = y;
			}
		}

		// Now that all the nodes exist, calculate their neighbours
		for(int x=0; x < GlobalVariables.boardWidth; x++) {
			for(int y=0; y < GlobalVariables.boardHeight; y++) {
				// check for up, down, left, right
				if(x > 0)
					GlobalVariables.graph[x,y].neighbours.Add( GlobalVariables.graph[x-1, y] );
				if(x < GlobalVariables.boardWidth-1)
					GlobalVariables.graph[x,y].neighbours.Add( GlobalVariables.graph[x+1, y] );
				if(y > 0)
					GlobalVariables.graph[x,y].neighbours.Add( GlobalVariables.graph[x, y-1] );
				if(y < GlobalVariables.boardHeight-1)
					GlobalVariables.graph[x,y].neighbours.Add( GlobalVariables.graph[x, y+1] );
			}
		}
    }  // end GeneratePathfindingGraph()

    public static string[,] FindAvailableCells(float movPoints, int posX, int poxY){
        
        // add 1 to these array indices so we can 1 : 1 the coords (and just ignore the zero indices)
        string[,] available = new string[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        bool[,] considered = new bool[GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1];
        Vector3Int source = new Vector3Int(posX,poxY,0);
        float movementPoints = movPoints;
        int thisMV;
        float MVcost;

        considered[1,1]=true;
        if(considered[1,1]){
            Debug.Log("HEEE!");
        }

        // initialize available[]
        available[source.x,source.y] = movementPoints.ToString();

        for(int c = 1; c < available.GetLength(0); c++){
            for(int r = 1; r < available.GetLength(1); r++){
                // Debug.Log("r: " + r + " c: " + c);
                if(available[ c,r ] != null){
                    // Up
                    if( (r+1) <= GlobalVariables.boardHeight){
                        // MVcost = GlobalVariables.tileTypes[ (int)GlobalVariables.tilesMatrix[(r+1),c] ].movementCost;
                        MVcost = GlobalVariables.tilesMatrix[ c,(r+1) ].movementCost;
                        thisMV = Int32.Parse(available[ c,r ]);
                        if(MVcost <= thisMV){
                            available[ c,(r+1) ] = (thisMV - MVcost).ToString();
                        }
                    }

                    // Down
                    if( (r-1) > 0){
                        
                        MVcost = GlobalVariables.tilesMatrix[ c,(r-1) ].movementCost;
                        thisMV = Int32.Parse(available[ c,r ]);
                        if(MVcost <= thisMV){
                            available[ c,(r-1) ] = (thisMV - MVcost).ToString();
                        }
                    }

                    // Left
                    if( (c-1) > 0){
                        MVcost = GlobalVariables.tilesMatrix[ (c-1),r ].movementCost;
                        thisMV = Int32.Parse(available[ c,r ]);
                        if(MVcost <= thisMV){
                            available[ (c-1),r ] = (thisMV - MVcost).ToString();
                        }
                    }

                    // Right
                    if( (c+1) <= GlobalVariables.boardWidth){
                        MVcost = GlobalVariables.tilesMatrix[ (c+1),r ].movementCost;
                        thisMV = Int32.Parse(available[ c,r ]);
                        if(MVcost <= thisMV){
                            available[ (c+1),r ] = (thisMV - MVcost).ToString();
                        }
                    }

                    // Debug.Log(source.ToString() + ": At " + c + " & " + r + " we have " + available[ c,r ]);
                }
               
            }   
        }
         for(int c = 1; c < available.GetLength(0); c++){
            for(int r = 1; r < available.GetLength(1); r++){
                if(available[ c,r ] != null){
                    Debug.Log(source.ToString() + ": At " + c + " & " + r + " we have " + available[ c,r ]);
                }
                
            }
         }
        return available;
    
    } // end FindAvailableCells()


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

}
