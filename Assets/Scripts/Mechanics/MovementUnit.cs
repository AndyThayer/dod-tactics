using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class MovementUnit : MonoBehaviour {

	float moveSpeed = 1.6f;
	bool moving = false;
	int targetX;
	int targetY;
	int parentX;
	int parentY;
	int destX;
	int destY;
	int it = 1;
	int totalNodes = 0;
	int movementPoints;
	// List<Vector3Int> avalablePaths;
	List<MovementNode> avalablePaths;
	// Animator anim;

	// Use this for initialization
	void Start () {
		// anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(moving){
			
			targetX = avalablePaths[it].node.x;
			targetY = avalablePaths[it].node.y;

			// Debug.Log("Transform: "+transform.position.x+" " +transform.position.y);
			// Debug.Log("Target: "+targetX+" " +targetY);
			
			if( (transform.position.x != destX || transform.position.y != destY) ){
				transform.position = Vector3.MoveTowards (transform.position, new Vector3Int(targetX,targetY,0), Time.deltaTime * moveSpeed);
				
				if(transform.position.x == targetX && transform.position.y == targetY){
					// update facing once per node
					if( it < totalNodes ){ 
			
						// consider MV cost vs STA cost
						updateSTA(parentX, parentY, targetX, targetY);

						transform.localRotation = GlobalFunctions.FindDirection(avalablePaths[it].direction);
						// Debug.Log("it is: "+it+" and totalNodes is: "+(totalNodes));
					}

					it++;
					
					if(it >= avalablePaths.Count){
						moving = false;
						
						// Debug.Log("case A");
					}else{
						targetX = avalablePaths[it].node.x;
						targetY = avalablePaths[it].node.y;
					}

				}
			}else{
				moving = false;
				// Debug.Log("case B"); // not sure if this one is really firing
			}

			if(it >= avalablePaths.Count){
				moving = false;
			}

			if(!moving){
				cleanUpAfterMove(parentX, parentY, targetX, targetY);
			}
			
		}
		
	}

	public void MoveUnit(int parX, int parY, int posX, int posY){
		// hide ready unit cursor
		GlobalFunctions.CleanUpOldHUDreadyUnit();
		// refresh class variables
		it = 1;
		totalNodes = 0;
		// set local variables
		int counter = 0;
		parentX = parX;
		parentY = parY;
		foreach(MovementNode mn in GlobalVariables.unitsMatrix[ parentX,parentY].availablePaths[ posX,posY ] ){
			counter++;
			// skip the "last" (actually the first) node because the direction is defaulted to UP
			if(counter < GlobalVariables.unitsMatrix[ parentX,parentY].availablePaths[ posX,posY ].Count){
				// Debug.Log(mn.direction.ToString());
				totalNodes++;
			}
		}
		avalablePaths = GlobalVariables.unitsMatrix[ parentX,parentY].availablePaths[ posX,posY ];
		destX = posX;
		destY = posY;
		transform.localRotation = GlobalFunctions.FindDirection(avalablePaths[0].direction);
		GlobalVariables.freezeHUD = true; // pause HUD or other game functionality
		moving = true; // begin moving in update()

		if(GlobalVariables.unitsMatrix[ parX,parY ].unitPrefab.GetComponent<UnitAnimations>() != null){
			GlobalVariables.unitsMatrix[ parX,parY ].unitPrefab.GetComponent<UnitAnimations>().PlayWalking();
		}
		
		movementPoints = (int)GlobalVariables.unitsMatrix[ parentX,parentY ].movementPoints;

		// for(int c = 1; c < GlobalVariables.unitsMatrix[ parentX,parentY ].availableCells.GetLength(0); c++){
        //     for(int r = 1; r < GlobalVariables.unitsMatrix[ parentX,parentY ].availableCells.GetLength(1); r++){
        //         if(GlobalVariables.unitsMatrix[ parentX,parentY ].availableCells[ c,r ] != null ){
        //             // -1 z index so that it lays "on top of" map tiles
                    
        //             Debug.Log("available: "+c+" "+r);
        //         }
        //     }
        // }

	}

	private void updateSTA(int parentX, int parentY, int targetX, int targetY){

		// tax unit
		GlobalVariables.unitsMatrix[ parentX,parentY ].stamina = Int32.Parse(GlobalVariables.unitsMatrix[ parentX,parentY ].availableCellsSTA[ targetX,targetY ]);
		// update HUD box
		GlobalFunctions.DisplayTileInfo(parentX,parentY);

		
	}

	private void cleanUpAfterMove(int parentX, int parentY, int targetX, int targetY){
		// consume unit's ability to move again this turn
		GlobalVariables.unitsMatrix[ parentX,parentY ].canMove = false;

		// SELECT this unit (checkForEndOfTurn will UN-SELECT it if that's what should happen)
		GlobalVariables.selectedUnit = new Vector3Int(targetX,targetY,0);

		GlobalFunctions.CheckForEndOfTurn(parentX,parentY);
		// consider MV cost vs STA cost
		updateSTA(parentX, parentY, targetX, targetY);
		// update HUD info boxes
		GlobalFunctions.CleanUpTerrainInfoPanel();
		GlobalFunctions.CleanUpUnitInfoPanel();	
		GlobalFunctions.DestroyGameObject("unitIcon");
		// stop walking animation
		// anim.Play("idle");
		GlobalVariables.unitsMatrix[ parentX,parentY ].unitPrefab.GetComponent<UnitAnimations>().PlayIdle();
		// resest freezeHUD
		GlobalVariables.freezeHUD = false;
		// swap unit's location old/new
		GlobalFunctions.UpdateUnitLocation(parentX, parentY, targetX, targetY);    //  NOTE: crucial - what is above and below this function!!
		// clean up all HUD after the move is complete
		GlobalFunctions.RemoveAvailableCellsFromAllUnits();
		GlobalFunctions.RemoveDisplayAvailableCellsFromAllUnits();
		GlobalFunctions.RemovePathCellsFromAllUnits();
		GlobalFunctions.UpdateHUDcursor(targetX,targetY);
		// flash this unit
		StartCoroutine(GlobalFunctions.FlashUnit(targetX,targetY, true));
		// restore ready unit cursor
		// GlobalFunctions.UpdateHUDreadyUnit( targetX,targetY );
		GlobalFunctions.UpdateWhoIsNext();
	}

}
