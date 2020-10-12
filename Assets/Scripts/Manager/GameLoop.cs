using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    SceneStateController m_SceneStateController = new SceneStateController();

    void Awake()
    {
        DontDestroyOnLoad(this);

        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }
    // Start is called before the first frame update
    void Start()
    {
        m_SceneStateController.SetState(new StartState(m_SceneStateController), "");
    }

    // Update is called once per frame
    void Update()
    {
        m_SceneStateController.StateUpdate();
    }
}
