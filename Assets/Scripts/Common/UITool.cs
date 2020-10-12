using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UITool
{
    private static GameObject m_CanvasObj = null;

    public static GameObject FindUIGameObject(string UIName)
    {
        if (m_CanvasObj == null)
            m_CanvasObj = UnityTool.FindGameObject("Canvas");
        if (m_CanvasObj == null)
            return null;
        return UnityTool.FindChildGameObject(m_CanvasObj,UIName);
    }


    public static T GetUIComponent<T> (GameObject Container, string UIName) where T: UnityEngine.Component
    {
        GameObject ChildGameObject = UnityTool.FindChildGameObject(Container,UIName);
        if (ChildGameObject == null)
            return null;

        T tempObj = ChildGameObject.GetComponent<T>();
        if (tempObj == null)
        {
            Debug.LogWarning("组件[" + UIName + "]不是[" + typeof(T) + "]");
            return null;
        }
        return tempObj;
    }
}
