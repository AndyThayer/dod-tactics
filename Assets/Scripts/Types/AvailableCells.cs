using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AvailableCells{

	public string[,] available = new string[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];
    public string[,] availableSTA = new string[ GlobalVariables.boardWidth+1,GlobalVariables.boardHeight+1 ];

}
