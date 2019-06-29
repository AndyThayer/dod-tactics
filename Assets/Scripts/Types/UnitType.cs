using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitType {

    // stats
    public Enums.UnitType unitType;
    public string name;
    public int unitID;
    public int hitPoints;
    public int hitPointMax;
    public int movementPoints;                      // probably change these floats to ints eventually
    public int stamina;
    public int balance;
    public int staRecovery;
    public int balRecovery;
    public int accuracy;
    public int critical;
    public int speed;
    public int defense;
    public int lowDamage;
    public int highDamage;
    public Enums.BattleOption battleOption;

    // traits
    public bool passThroughGrass = false;
    public bool passThroughGrassRough = false;
    public bool passThroughWoods = false;
    public bool passThroughWoodsDense = false;
    public bool passThroughWaterShallow = false;
    public bool passThroughWaterDeep = false;
    public bool passThroughHills = false;
    public bool passThroughHillsSteep = false;
    public bool passThroughDirt = false;
    public bool passThroughDirtSand = false;

    // map / pathfinding
    public string[,] availableCells = new string[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];
    public string[,] availableCellsSTA = new string[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];
    // public string[,] availableCellsDistance = new string[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];
    public List<MovementNode>[,] availablePaths = new List<MovementNode>[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];
    public bool displayAvailableCells;

    // status
    // - is this unit the currently SELECTED unit
    // public bool selectedUnit;

    // coordination
    public int posX;
    public int posY;

    // combat
    public int team;
    public bool canAct;
    public bool canMove;
    public bool rally;
    public int lightAttackRange;
    public int heavyAttckRange;
    public string[,] threatCells = new string[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];

    // prefab
    public GameObject unitPrefab;
    
    public UnitType(Enums.UnitType type){
        // all units
        GlobalVariables.unitID++;
        unitID = GlobalVariables.unitID;
        unitType = type;
        displayAvailableCells = false;
        canAct = false;
        canMove = false;
        rally = false;
        stamina = 100;
        balance = 100;
        lightAttackRange = 1;
        heavyAttckRange = 1;
        // certain unit types
        switch(type){
            // CHARACTERS
            case Enums.UnitType.Hunter:
                name = "Hunter";
                // stats
                movementPoints = 4;
                hitPoints = 16;
                hitPointMax = 16;
                balRecovery = 0;
                staRecovery = 0;
                accuracy = 11; // 6
                critical = 10;
                speed = 1;
                defense = 3;
                lowDamage = 1;
                highDamage = 6; // 6
                break;
            case Enums.UnitType.Gatherer:
                name = "Gatherer";
                // stats
                movementPoints = 5;
                hitPoints = 15;
                hitPointMax = 15;
                balRecovery = 2;
                staRecovery = 2;
                accuracy = 14; // 4
                critical = 0;
                speed = 5;
                defense = 8;
                lowDamage = 1;
                highDamage = 4;
                break;
            case Enums.UnitType.Bandit:
                name = "Bandit";
                // stats
                movementPoints = 5;
                hitPoints = 14;
                hitPointMax = 14;
                balRecovery = 5;
                staRecovery = 0;
                accuracy = 8; // 3
                critical = 5;
                speed = 4;
                defense = 5;
                lowDamage = 1;
                highDamage = 5;
                break;
            case Enums.UnitType.Nomad:
                name = "Nomad";
                // stats
                movementPoints = 4;
                hitPoints = 18;
                hitPointMax = 18;
                balRecovery = 0;
                staRecovery = 5;
                accuracy = 7; // 2
                critical = 7;
                speed = 0;
                defense = 4;
                lowDamage = 1;
                highDamage = 6;
                break;
            // MONSTERS
            case Enums.UnitType.BarbedToad:
                name = "Barbed Toad";
                // stats
                movementPoints = 3;
                hitPoints = 4;
                hitPointMax = 4;
                balRecovery = 0;
                staRecovery = 0;
                accuracy = 8; // 3
                critical = 5;
                speed = 10; // 0
                defense = 1;
                lowDamage = 1;
                highDamage = 2; // 2
                // traits
                passThroughGrass = true;
                passThroughGrassRough = true;
                passThroughWaterShallow = true;
                passThroughWaterDeep = true;
                break;
            case Enums.UnitType.SaberToothWolf:
                name = "Saber Tooth Wolf";
                // stats
                movementPoints = 5;
                hitPoints = 8;
                hitPointMax = 8;
                balRecovery = 10;
                staRecovery = 10;
                accuracy = 6; // 1
                critical = 2; // 2
                speed = 14; // 4
                defense = 5;
                lowDamage = 1;
                highDamage = 5; // 5
                break;
        }
    }

}
