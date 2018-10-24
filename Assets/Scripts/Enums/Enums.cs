using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enums : MonoBehaviour {

    public enum Direction : int {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4
    }

    // be careful changing the values of this ENUM
    // the values seem to reset to the topmost for the following:
    // Grid > Tilemaps
    // Prefabs > Characters
    public enum MouseOverType {
        //HUD,
        Tile,
        Character,
        Monster
    }

    public enum UnitType{
        // Characters
        Hunter,
        Gatherer,
        Bandit,
        Woodsman,
        // Monsters
        BarbedToad,
        SaberToothWolf
    }

    public enum TileType {
        Castle,
        Bridge,
        Grass,
        GrassRough,
        Woods,
        WoodsDense,
        WaterShallow,
        WaterDeep,
        Hills,
        HillsSteep,
        Dirt,
        DirtSand
    }

    public enum BattleOption {
        LightAttack,
        HeavyAttack,
        Rally,
        UseItem,
        CastSpell,
        SpecialAbility,
        EndTurn
    }

}
