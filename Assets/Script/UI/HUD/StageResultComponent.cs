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
                gethudingame.Init();
            }

            ProjectUtility.SetActiveCheck(this.gameObject, false);
        }
        else
        {
            ProjectUtility.SetActiveCheck(this.gameObject, false);
            GameRoot.Instance.UISystem.OpenUI<PopupFrameShop>(popup => popup.Init());
        }
    }

    public void Set(int reward , bool issuccess)
    {
        IsSuccess = issuccess;
        ProjectUtility.SetActiveCheck(this.gameObject, true);
        GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.UpgradeCoin, reward);
        ResultRewardText.text = reward.ToString();
    }


}
