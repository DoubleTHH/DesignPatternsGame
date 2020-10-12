using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampOnClick : MonoBehaviour
{
    public ICamp theCamp = null;
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
        PBaseDefenseGame.Instance.ShowCampInfo(theCamp);
    }
}
