using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverThreat : MonoBehaviour {

	public static HoverThreat Instance;

	int posX;
	int posY;

	void Start(){
		
		posX = (int)this.transform.position.x;
		posY = (int)this.transform.position.y;
	}

	void Awake() {
        Instance = this;
    }

	void OnMouseOver() {

		GlobalFunctions.UpdateHUDcursorThreat(posX, posY);

    }

	void OnMouseExit(){
		
		GlobalFunctions.CleanUpOldHUDcursorThreat();

	}

}
