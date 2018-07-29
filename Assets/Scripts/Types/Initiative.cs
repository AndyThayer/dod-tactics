using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Initiative{

    public int initiative;
    public int unitID;
    public int posX;
    public int posY;
    public int team;

    // Compare function to sort initiative HIGH to LOW
    // #pragma warning disable // without this the Initiative in CompareTo() causes a weird circular reference WARNING
    public int CompareTo(Initiative compareInit)
    {
          // A null value means that this object is greater.
        if (compareInit == null){
            return 1;
        }else if(this.initiative > compareInit.initiative){
            return -1;
            // return this.initiative.CompareTo(compareInit.initiative);
        }else{
            return 1;
        }
    }

} // end Initiative
