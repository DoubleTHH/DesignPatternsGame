using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierOnClick : MonoBehaviour
{

    public ISoldier Soldier = null;

    public void OnClick()
    {
        PBaseDefenseGame.Instance.ShowSoldierInfo(Soldier);
    }
}
