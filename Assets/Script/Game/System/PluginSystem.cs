using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BanpoFri;

public class PluginSystem
{
    public void OnApplicationPause(bool value)
    {
        if (value)
        {
            if (GameRoot.Instance == null) Debug.Log("GameRoot is Null");
            if (GameRoot.Instance.UserData == null) Debug.Log("UserData is Null");
            if (GameRoot.Instance.UserData.CurMode == null)
            {
                Debug.Log("CurMode is Null");
                return;
            }

            GameRoot.Instance.UserData.CurMode.LastLoginTime = TimeSystem.GetCurTime();
            GameRoot.Instance.UserData.Save(true);
        }
    }
}