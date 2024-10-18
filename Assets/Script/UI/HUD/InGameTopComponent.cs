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

    private CompositeDisposable disposables = new CompositeDisposable();

    public void Set(int stageidx)
    {
        disposables.Clear();

        var infotd = Tables.Instance.GetTable<StageInfo>().GetData(stageidx);

        if (infotd != null)
        {
            GoalPriceText.text = infotd.target_money.ToString();

            GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Subscribe(SetCurPrice).AddTo(disposables);

           GameRoot.Instance.UserData.CurMode.StageData.WaveTimeProperty.Subscribe(WaveTime).AddTo(disposables);
        }
    }

    public void SetCurPrice(int price)
    {
        CurPriceText.text = price.ToString();
    }


    public void WaveTime(int time)
    {
        if (time <= 0)
        {
            //death
        }

        LimitTimeText.text = $"Time:{ProjectUtility.GetTimeStringFormattingShort(time)}";
        TimeSlider.value = (float)time / (float)GameRoot.Instance.UserData.CurMode.StageData.StageCoolTime;

    }


    private void OnDestroy()
    {
        disposables.Clear();
    }
}
