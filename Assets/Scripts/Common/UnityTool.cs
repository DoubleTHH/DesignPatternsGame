using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool 
{
    public static GameObject FindGameObject(string GameObjectName)
    {
        GameObject pTmpGameObj = GameObject.Find(GameObjectName);
        if (pTmpGameObj == null)
        {
            Debug.LogWarning("场景中找不到GameObject[" + GameObjectName + "]对象");
            return null;
        }

        return pTmpGameObj;
    }

    public static GameObject FindChildGameObject(GameObject Container, string gameobjectName)
    {
        if (Container == null)
        {
            Debug.LogError("NGUICustomTools.GetChild:Container = null");
            return null;
        }


        Transform pGameObjectTF = null;
        if (Container.name == gameobjectName)
        {
            pGameObjectTF = Container.transform;

        }
        else
        {
            Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
            foreach (var item in allChildren)
            {
                if (item.name == gameobjectName)
                {
                    if (pGameObjectTF == null)
                    {
                        pGameObjectTF = item;
                    }
                    else
                    {
                        Debug.LogWarning("Container[" + Container.name + "]下找出重复的组件名称[" + gameobjectName + "]");

                    }
                }
            }
        }


        if (pGameObjectTF == null)
        {
            Debug.LogError("组件[" + Container.name + "]下找不到子组件[" + gameobjectName + "]");
            return null;
        }

        return pGameObjectTF.gameObject;
    }
}
