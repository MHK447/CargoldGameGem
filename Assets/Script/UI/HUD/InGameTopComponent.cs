using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BanpoFri;
using UniRx;

public class InGameTopComponent : MonoBehaviour
{
    [SerializeField]
    private Text StageCompanyNameTexrt;

    [SerializeField]
    private Image CompanyImg;

    [SerializeField]
    private Text StageCountText;

    [SerializeField]
    private Text GoalPriceText;

    [SerializeField]
    private Text CurPriceText;

    [SerializeField]
    private Text LimitTimeText;

    [SerializeField]
    private Slider TimeSlider;

    private CompositeDisposable disposables;

    public void Set(int stageidx)
    {
        disposables.Clear();

        var infotd = Tables.Instance.GetTable<StageInfo>().GetData(stageidx);

        if (infotd != null)
        {
            GoalPriceText.tag = infotd.target_money.ToString();

            GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Subscribe(SetCurPrice).AddTo(disposables);

           //GameRoot.Instance.UserData.CurMode.StageData.WaveTimeProperty.Subscribe(WaveTime).AddTo(disposables);
        }
    }

    public void SetCurPrice(int price)
    {
        CurPriceText.text = price.ToString();
    }


    //public void WaveTime(int time)
    //{
    //    if (time == 0 && GameRoot.Instance.UserData.CurMode.StageData.WaveIdxProperty.Value > 1)
    //    {
    //        StartWave(GameRoot.Instance.UserData.CurMode.StageData.WaveIdxProperty.Value + 1);
    //    }

    //    TimeText.text = ProjectUtility.GetTimeStringFormattingShort(time);


    //}


    private void OnDestroy()
    {
        disposables.Clear();
    }

    private void OnDisable()
    {
        disposables.Clear();
    }

}
