using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UnityEngine.AddressableAssets;
using System.Linq;


public class InGameBattle : MonoBehaviour
{
    [SerializeField]
    private InGameStockRoot StockRoot;


    public void Init()
    {
        StockRoot.FirstStart();
    }


    public void Update()
    {
        if (!GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle) return;


        //if (waveonesecondtime >= 1f) // one seconds updates;
        //{
        //    wavedeltime += 1;
        //    var wavetime = WaveCoolTime - wavedeltime;
        //    GameRoot.Instance.UserData.CurMode.StageData.WaveTimeProperty.Value = (int)wavetime;
        //    if (wavedeltime >= WaveCoolTime)
        //    {
        //        wavedeltime = 0;
        //        NextWave();
        //    }
        //    waveonesecondtime -= 1f;
        //}
        //waveonesecondtime += Time.deltaTime;
    }


}
