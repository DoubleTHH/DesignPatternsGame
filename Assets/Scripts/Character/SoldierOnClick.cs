using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierOnClick : MonoBehaviour
{

    public ISoldier Soldier = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        PBaseDefenseGame.Instance.ShowSoldierInfo(Soldier);
    }
}
