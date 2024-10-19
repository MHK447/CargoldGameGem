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


    [SerializeField]
    private Animator Anim;


    private CompositeDisposable disposables = new CompositeDisposable();

    private HUDInGame HudInGame;

    int TargetMoney = 0;

    public void Set(int stageidx , HUDInGame hudingame)
    {
        disposables.Clear();

        HudInGame = hudingame;

        var infotd = Tables.Instance.GetTable<StageInfo>().GetData(stageidx);

        if (infotd != null)
        {
            TargetMoney = infotd.target_money;

            var buffvalue = GameRoot.Instance.WeaponSystem.GetBuffValue(WeaponSystem.Type.MoneyDecrease) == -1 ? 0
                : GameRoot.Instance.WeaponSystem.GetBuffValue(WeaponSystem.Type.MoneyDecrease);

            TargetMoney = TargetMoney - buffvalue;


            StageCompanyNameTexrt.text = infotd.stage_name.ToString();

            StageCountText.text = infotd.stage_number_name.ToString();

            GoalPriceText.text = $"${TargetMoney}";

            GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Subscribe(SetCurPrice).AddTo(disposables);

           GameRoot.Instance.UserData.CurMode.StageData.WaveTimeProperty.Subscribe(WaveTime).AddTo(disposables);
        }
    }

    public void SetCurPrice(int price)
    {
        CurPriceText.text = $"${price}";
    }


    public void WaveTime(int time)
    {
        if (GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle == false) return; 

        if (time == -1)
        {
            Result();
        }

        LimitTimeText.text = $"Time:{ProjectUtility.GetTimeStringFormattingShort(time)}";
        TimeSlider.value = (float)time / (float)GameRoot.Instance.UserData.CurMode.StageData.StageCoolTime;

        if (Anim = null)
        {
            if (TimeSlider.value > 0.5f)
            {
                Anim.Play("Char_Idle_Anime", 0, 0f);
            }
            else
            {
                if (GameRoot.Instance.UserData.CurMode.Money.Value >= TargetMoney)
                {
                    Anim.Play("Char_Cheer_Anime", 0, 0f);
                }
                else
                {
                    Anim.Play("Char_Depressed_Anime", 0, 0f);
                }

            }
        }
    }


    public void Result()
    {
        if (GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle == false) return;

        ProjectUtility.SetActiveCheck(HudInGame.ResultComponent.gameObject, true);

        var stageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(stageidx);

        if(td != null)
        {
            if (GameRoot.Instance.UserData.CurMode.Money.Value >= TargetMoney)
            {
                var stagerewardtd = Tables.Instance.GetTable<StageRewardInfo>().GetData(stageidx);

                if(stagerewardtd != null)
                {
                    var stagereward_1 = ProjectUtility.
                        GetPercentValue((float)td.target_money, stagerewardtd.bonus_percent_1);

                    var stagereward_2 = ProjectUtility.
                        GetPercentValue((float)td.target_money, stagerewardtd.bonus_percent_2);

                    var stageresult = stagerewardtd.base_reward;

                    if ((int)stagereward_1 <= GameRoot.Instance.UserData.CurMode.Money.Value)
                    {
                        stageresult = stagerewardtd.base_reward + stagerewardtd.bonus_reward_1;
                    }
                    else if((int)stagereward_2 <= GameRoot.Instance.UserData.CurMode.Money.Value)
                    {
                        stageresult = stagerewardtd.base_reward + stagerewardtd.bonus_reward_2;
                    }

                    HudInGame.ResultComponent.Set(stageresult, true, TargetMoney);
                    GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle = false;
                }
            }
            else
            {
                GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle = false;
                HudInGame.ResultComponent.Set(0, false, TargetMoney);
            }
        }
    }


    private void OnDestroy()
    {
        disposables.Clear();
    }
}
