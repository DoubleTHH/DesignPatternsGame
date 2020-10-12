using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    ISceneState m_State;
    bool m_bRunBegin = false;
    public SceneStateController() { }
    static AsyncOperation asyncOperation;

    public void SetState(ISceneState State, string LoadSceneName)
    {
        m_bRunBegin = false;

        LoadScene(LoadSceneName);

        if (m_State != null)
            m_State.StateEnd();

        m_State = State;

    }

    void LoadScene(string LoadSceneName)
    {
        if (LoadSceneName == null || LoadSceneName.Length == 0)
            return;

        asyncOperation = SceneManager.LoadSceneAsync(LoadSceneName);
    }

    public void StateUpdate()
    {
        if (!asyncOperation.isDone)
            return;
        if (m_State != null && m_bRunBegin ==false)
        {
            m_State.StateBegin();
            m_bRunBegin = true;
        }

        if (m_State !=null)
            m_State.StateUpdate();
    }
}
