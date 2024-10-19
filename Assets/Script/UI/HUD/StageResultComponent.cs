using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UnityEngine.UI;

public class StageResultComponent : MonoBehaviour
{
    [SerializeField]
    private Button NextStageBtn;

    [SerializeField]
    private Text ResultRewardText;

    [SerializeField]
    private Text GoalAndMyMoneyText;

    [SerializeField]
    private Text GoalText;

    [SerializeField]
    private Text ActivedMoney;

    [SerializeField]
    private Text ResultText;

    [SerializeField]
    private Slider SliderValue;

    private bool IsSuccess = false;

    private void Awake()
    {
        NextStageBtn.onClick.AddListener(OnClickNextStage);
    }

    public void OnClickNextStage()
    {
        if(IsSuccess == false)
        {
            GameRoot.Instance.InGameSystem.GetInGame<InGameTycoon>().curInGameStage.GetBattle.Init();

            var gethudingame = GameRoot.Instance.UISystem.GetUI<HUDInGame>();

            if (gethudingame != null)
            {
                gethudingame.Init(null);
            }

            ProjectUtility.SetActiveCheck(this.gameObject, false);
            GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle = true;
        }
        else
        {
            ProjectUtility.SetActiveCheck(this.gameObject, false);
            GameRoot.Instance.UISystem.OpenUI<PopupFrameShop>(popup => popup.Init());
        }
    }

    public void Set(int reward , bool issuccess , int goalvalue )
    {
        IsSuccess = issuccess;
        ProjectUtility.SetActiveCheck(this.gameObject, true);
        GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.UpgradeCoin, reward);
        ResultRewardText.text = reward.ToString();

        SliderValue.value = (float)GameRoot.Instance.UserData.CurMode.Money.Value / (float)goalvalue;

        GoalAndMyMoneyText.text = $"Goal:{GameRoot.Instance.UserData.CurMode.Money.Value}/{goalvalue}";

        GoalText.text = $"Goal:{goalvalue}";

        ResultText.text = IsSuccess ? "VICTORY!!" : "FAILED!!";

        ResultText.color = issuccess ? Color.green : Color.red;

        ActivedMoney.text = $"ACTIVED MONEY:{GameRoot.Instance.UserData.CurMode.Money.Value}";
    }


}
