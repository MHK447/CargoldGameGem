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

    private float waveonesecondtime = 0f;

    private float wavedeltime = 0f;


    public void Init()
    {
        var stageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(stageidx);

        if(td != null)
        {
            GameRoot.Instance.UserData.CurMode.StageData.StageCoolTime = td.stage_end_time;
        }


        StockRoot.FirstStart();
    }


    public void Update()
    {
        if (!GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle) return;


        if (waveonesecondtime >= 1f) 
        {
            wavedeltime += 1;
            var wavetime = GameRoot.Instance.UserData.CurMode.StageData.StageCoolTime - wavedeltime;
            GameRoot.Instance.UserData.CurMode.StageData.WaveTimeProperty.Value = (int)wavetime;
            if (wavedeltime >= GameRoot.Instance.UserData.CurMode.StageData.StageCoolTime)
            {
                wavedeltime = 0;
                //NextWave();
            }
            waveonesecondtime -= 1f;
        }
        waveonesecondtime += Time.deltaTime;
    }


}
