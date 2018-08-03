using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFreezeHUD : MonoBehaviour {

	void FeezeHUD(){
		GlobalVariables.freezeHUD = true;
	}

	void ThawHUD(){
		GlobalVariables.freezeHUD = false;
	}

}
