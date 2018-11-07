using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverIcon : MonoBehaviour {

	public static HoverIcon Instance;

	// coordination
	private int posX;
	private int posY;
	
	// which icon?
	bool lightAttack;
	bool heavyAttack;
	bool useItem;
	bool rally;
	bool castSpell;
	bool specialAbility;
	bool endTurn;

	Animator anim;

	void Start(){
		
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
		anim = GetComponent<Animator>();

		lightAttack = this.gameObject.GetComponent<IconProperties>().lightAttack;
		heavyAttack = this.gameObject.GetComponent<IconProperties>().heavyAttack;
		rally = this.gameObject.GetComponent<IconProperties>().rally;
		useItem = this.gameObject.GetComponent<IconProperties>().useItem;
		castSpell = this.gameObject.GetComponent<IconProperties>().castSpell;
		specialAbility = this.gameObject.GetComponent<IconProperties>().specialAbility;
		endTurn = this.gameObject.GetComponent<IconProperties>().endTurn;

	}

	void Awake() {
        Instance = this;
    }

	void OnMouseOver() {

		GlobalFunctions.CleanUpUnitIcons("terrainStatusIconLOWER");

		if( !GlobalVariables.freezeIconHUD ){
			// for all icons
			anim.Play("lit");
			GlobalFunctions.CleanUpTerrainInfoPanel(true);

			if(lightAttack){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.LightAttack);
			}else if(heavyAttack){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.HeavyAttack);
			}else if(useItem){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.UseItem);
			}else if(rally){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.Rally);
			}else if(castSpell){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.CastSpell);
			}else if(specialAbility){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.SpecialAbility);
			}else if(endTurn){
				GlobalFunctions.DisplayBattleOptionInfo(Enums.BattleOption.EndTurn);
			}
		}

    }

	void OnMouseExit(){
		
		if( !GlobalVariables.freezeIconHUD ){
			// clean up battle option HUD icon
			GlobalFunctions.CleanUpBattleOptionIcons();
			// display terrian info again
			GlobalFunctions.DisplayTileInfo(GlobalVariables.selectedUnit.x, GlobalVariables.selectedUnit.y);
			anim.Play("idle");
		}
		GlobalFunctions.CleanUpUnitIcons("heavyAttackStatusIconLOWER");

	}

	public void PlayIdle(){
		anim.Play("idle");
	}

	public void PlayLit(){
		anim.Play("lit");
	}

}
