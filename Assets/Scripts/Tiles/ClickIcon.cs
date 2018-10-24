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
		
		// selected unit's coords
		int posX = GlobalVariables.selectedUnit.x;
		int posY = GlobalVariables.selectedUnit.y;

		// reset Icon animations
		if( GlobalVariables.freezeIconHUD ){
			GlobalFunctions.CleanUpHUDIcons();
		}
		// light up this icon
		if( !GlobalVariables.freezeIconHUD && GlobalVariables.unitsMatrix[ GlobalVariables.selectedUnit.x,GlobalVariables.selectedUnit.y ].canAct ){
			this.GetComponent<HoverIcon>().PlayLit();
			GlobalVariables.freezeIconHUD = true;
		}else{
			GlobalVariables.freezeIconHUD = false;
		}
		
		if( GlobalVariables.unitsMatrix[ GlobalVariables.selectedUnit.x,GlobalVariables.selectedUnit.y ].canAct && !GlobalVariables.freezeHUD ){

			// clean up available cells
			GlobalFunctions.RemoveAvailableCellsFromAllUnits();
			GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();

			if(lightAttack){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.LightAttack);
				// determine threat cells
				GlobalVariables.unitsMatrix[ posX,posY ].threatCells = GlobalFunctions.FindThreatCells( GlobalVariables.unitsMatrix[ posX,posY ].lightAttackRange,posX,posY );
				// set battleOption and display threat cells
				if( GlobalVariables.freezeIconHUD ){
					GlobalFunctions.DisplayThreatCells( posX,posY );
					GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.LightAttack;
				}
			}else if(heavyAttack){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.HeavyAttack);
				// determine threat cells
				GlobalVariables.unitsMatrix[ posX,posY ].threatCells = GlobalFunctions.FindThreatCells( GlobalVariables.unitsMatrix[ posX,posY ].heavyAttckRange,posX,posY );
				// set battleOption and display threat cells
				if( GlobalVariables.freezeIconHUD ){
					GlobalFunctions.DisplayThreatCells( posX,posY );
					GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.HeavyAttack;
				}
			}else if(useItem){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.UseItem);
				Debug.Log("Use Item clicked!");
			}else if(rally){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.Rally);
				// perform Rally
				GlobalFunctions.CombatRally( posX,posY );
				// set battleOption
				if( GlobalVariables.freezeIconHUD ){
					GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.Rally;
				}
			}else if(castSpell){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.CastSpell);
				Debug.Log("Cast Spell clicked!");
			}else if(specialAbility){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.SpecialAbility);
				Debug.Log("Special Ability clicked!");
			}else if(endTurn){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.EndTurn);
				GlobalFunctions.CombatEndTurn( posX,posY );
				// CombatEndTurn > CheckForEndOfTurn wipes selectedUnit values, but we still need them in this scenario
				GlobalVariables.selectedUnit.x = posX;
            	GlobalVariables.selectedUnit.y = posY;
				// lift the freeze, we're done here
				GlobalVariables.freezeIconHUD = false;
			}

		} // if canAct
		

	}

}
