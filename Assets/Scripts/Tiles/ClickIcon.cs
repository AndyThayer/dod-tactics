using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIcon : MonoBehaviour {

	public static ClickIcon Instance;

	// which icon?
	bool lightAttack;
	bool heavyAttack;
	bool useItem;
	bool rally;
	bool castSpell;
	bool specialAbility;
	bool endTurn;

	void Awake() {
        Instance = this;
    }

	void Start(){
		
		lightAttack = this.gameObject.GetComponent<IconProperties>().lightAttack;
		heavyAttack = this.gameObject.GetComponent<IconProperties>().heavyAttack;
		rally = this.gameObject.GetComponent<IconProperties>().rally;
		useItem = this.gameObject.GetComponent<IconProperties>().useItem;
		castSpell = this.gameObject.GetComponent<IconProperties>().castSpell;
		specialAbility = this.gameObject.GetComponent<IconProperties>().specialAbility;
		endTurn = this.gameObject.GetComponent<IconProperties>().endTurn;
		
	}

	void OnMouseDown() {

		Debug.Log("ClickIcon()");
		
		// selected unit's coords
		int posX = GlobalVariables.selectedUnit.x;
		int posY = GlobalVariables.selectedUnit.y;

		// reset Icon animations
		if( GlobalVariables.freezeIconHUD ){
			GlobalFunctions.CleanUpHUDIcons();
		}
		// light up this icon
		if( !GlobalVariables.freezeIconHUD && GlobalVariables.unitsMatrix[ GlobalVariables.selectedUnit.x,GlobalVariables.selectedUnit.y ].canAct ){ // || true
			this.GetComponent<HoverIcon>().PlayLit();
			GlobalVariables.freezeIconHUD = true;
		}else{
			GlobalVariables.freezeIconHUD = false;
		}
		
		if( !GlobalVariables.freezeHUD ){ // || true

			// reset status icon LOWER
			if( !GlobalVariables.freezeIconHUD ){
				GlobalFunctions.DestroyGameObject("statusIconLOWER");
			}

			// clean up available cells
			GlobalFunctions.RemoveAvailableCellsFromAllUnits();
			GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
			// bool thisUnitCanAct =  GlobalVariables.unitsMatrix[ GlobalVariables.selectedUnit.x,GlobalVariables.selectedUnit.y ].canAct;
			UnitType thisUnit = GlobalVariables.unitsMatrix[ GlobalVariables.selectedUnit.x,GlobalVariables.selectedUnit.y ];
			// wipe upper panel battle log
			GlobalFunctions.CleanUpBattleLog();

			if( thisUnit.canAct && thisUnit.stamina >= GlobalVariables.lightAttackSTAcost && lightAttack ){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.LightAttack);
				// determine threat cells
				GlobalVariables.unitsMatrix[ posX,posY ].threatCells = GlobalFunctions.FindThreatCells( GlobalVariables.unitsMatrix[ posX,posY ].lightAttackRange,posX,posY );
				// set battleOption and display threat cells
				if( GlobalVariables.freezeIconHUD ){				
					GlobalFunctions.DisplayThreatCells( posX,posY );
					GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.LightAttack;
				}else{
					GlobalFunctions.DestroyGameObject("battleOptionIcon");
				}
			}else if( thisUnit.canAct && thisUnit.stamina >= GlobalVariables.heavyAttackSTAcost && heavyAttack ){				
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.HeavyAttack);
				// determine threat cells
				GlobalVariables.unitsMatrix[ posX,posY ].threatCells = GlobalFunctions.FindThreatCells( GlobalVariables.unitsMatrix[ posX,posY ].heavyAttckRange,posX,posY );
				// set battleOption and display threat cells
				if( GlobalVariables.freezeIconHUD ){
					GlobalFunctions.DisplayThreatCells( posX,posY );
					GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.HeavyAttack;
				}else{
					GlobalFunctions.DestroyGameObject("battleOptionIcon");
				}
			}else if( thisUnit.canAct && useItem ){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.UseItem);
				Debug.Log("Use Item clicked!");
			}else if( thisUnit.canAct && rally ){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.Rally);
				// perform Rally
				GlobalFunctions.CombatRally( posX,posY );
				// set battleOption
				if( GlobalVariables.freezeIconHUD ){
					GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.Rally;
				}
			}else if( thisUnit.canAct && castSpell ){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.CastSpell);
				Debug.Log("Cast Spell clicked!");
			}else if( thisUnit.canAct && specialAbility ){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.SpecialAbility);
				Debug.Log("Special Ability clicked!");
			}else if( endTurn ){
				Debug.Log("End Turn clickd!");
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.EndTurn);
				// GlobalFunctions.CombatEndTurn( posX,posY );
				GlobalFunctions.CombatEndTurn( GlobalVariables.initRoster[0].posX,GlobalVariables.initRoster[0].posY );
				// CombatEndTurn > CheckForEndOfTurn wipes selectedUnit values, but we still need them in this scenario
				GlobalVariables.selectedUnit.x = posX;
            	GlobalVariables.selectedUnit.y = posY;
				// lift the freeze, we're done here
				GlobalVariables.freezeIconHUD = false;
			}

		} // if canAct
		

	}

}
