using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ActiveType
{
    None,
    Dissolving,
    Appear
}
public class TestDissolve : MonoBehaviour
{

    private ActiveType activeType = ActiveType.None;
    private bool isDissolving, isAppearing;
    private float timer = 0, duration = 0.5f;
    private Renderer renderer;


    private void Start()
    {
        renderer = GetComponent<Renderer>();//.material.SetFloat("_Threshold",)
    }
    public static bool IsGameObjectInCameraView(GameObject targetObj, Camera camera = null)
    {
        if (camera == null)
            camera = Camera.main;

        if (camera == null)
            return false;

        Vector3 targetObjViewportCoord = camera.WorldToViewportPoint(targetObj.transform.position);
        if (targetObjViewportCoord.x > 0 && targetObjViewportCoord.x < 1 && targetObjViewportCoord.y > 0f && targetObjViewportCoord.y < 1 && targetObjViewportCoord.z > camera.nearClipPlane && targetObjViewportCoord.z < camera.farClipPlane)
            return true;

        return false;
    }

    private void Update()
    {
        switch (activeType)
        {
            case ActiveType.None:
                if (IsGameObjectInCameraView(gameObject) && !isAppearing)
                {
                    activeType = ActiveType.Appear;

                }
                else if(!IsGameObjectInCameraView(gameObject) && !isDissolving)
                {
                    activeType = ActiveType.Dissolving;
                }
                timer = 0;
                break;
            case ActiveType.Dissolving:
                if (!isDissolving)
                {
                    if (timer< duration)
                    {
                        timer += Time.deltaTime;
                        renderer.material.SetFloat("_Threshold", timer / duration);
                    }
                    else
                    {
                        isDissolving = true;
                        activeType = ActiveType.None;
                        isAppearing = false;

                    }
                }
                break;
            case ActiveType.Appear:
                if (!isAppearing)
                {
                    if (timer < duration)
                    {
                        timer += Time.deltaTime;
                        renderer.material.SetFloat("_Threshold", 1- timer / duration);
                    }
                    else
                    {
                        isAppearing = true;
                        activeType = ActiveType.None;
                        isDissolving = false;

                    }
                }
                break;
            default:
                break;
        }

    }


     
}
