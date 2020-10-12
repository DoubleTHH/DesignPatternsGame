using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITrainCost : MonoBehaviour
{

    public virtual int GetTrainCost(ENUM_Soldier eNUM_Soldier, int Lv, ENUM_Weapon eNUM_Weapon) {
        return 0;
    }
}
