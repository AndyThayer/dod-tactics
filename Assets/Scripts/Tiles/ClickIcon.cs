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
		
	}

	void OnMouseUp() {
		
		// selected unit's coords
		int posX = GlobalVariables.selectedUnit.x;
		int posY = GlobalVariables.selectedUnit.y;

		// clean up available cells
		GlobalFunctions.RemoveAvailableCellsFromAllUnits();
		GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();

		// reset Icon animations
		if( GlobalVariables.freezeIconHUD ){
			GlobalFunctions.CleanUpHUDIcons();
		}
		// light up this icon
		if( !GlobalVariables.freezeIconHUD ){
			this.GetComponent<HoverIcon>().PlayLit();
			GlobalVariables.freezeIconHUD = true;
		}else{
			GlobalVariables.freezeIconHUD = false;
		}
		
		if(lightAttack){
			GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.LightAttack);
			// determine threat cells
			GlobalVariables.unitsMatrix[ posX,posY ].threatCells = GlobalFunctions.FindThreatCells( GlobalVariables.unitsMatrix[ posX,posY ].lightAttackRange,posX,posY );
			// display threat cells
			if( GlobalVariables.freezeIconHUD ){
				GlobalFunctions.DisplayThreatCells( posX,posY );
				GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.LightAttack;
			}
		}else if(heavyAttack){
			GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.HeavyAttack);
			// determine threat cells
			GlobalVariables.unitsMatrix[ posX,posY ].threatCells = GlobalFunctions.FindThreatCells( GlobalVariables.unitsMatrix[ posX,posY ].heavyAttckRange,posX,posY );
			// display threat cells
			if( GlobalVariables.freezeIconHUD ){
				GlobalFunctions.DisplayThreatCells( posX,posY );
				GlobalVariables.unitsMatrix[ posX,posY ].battleOption = Enums.BattleOption.HeavyAttack;
			}
		}else if(useItem){
			GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.UseItem);
			Debug.Log("Use Item clicked!");
		}else if(rally){
			GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.Rally);
			Debug.Log("Rally clicked!");
		}else if(castSpell){
			GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.CastSpell);
			Debug.Log("Cast Spell clicked!");
		}else if(specialAbility){
			GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.SpecialAbility);
			Debug.Log("Special Ability clicked!");

		}

		

	}

}
