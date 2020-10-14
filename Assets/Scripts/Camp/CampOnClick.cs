using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampOnClick : MonoBehaviour
{
    public ICamp theCamp = null;


    public void OnClick()
    {
        PBaseDefenseGame.Instance.ShowCampInfo(theCamp);
    }
}
