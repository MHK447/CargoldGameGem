using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatWindowTest : MonoBehaviour
{
    [SerializeField]
    private Button MoneyCheat;

    [SerializeField]
    private Button SetStageCheat;

    [SerializeField]
    private InputField StageIdxInputField;

    [SerializeField]
    private Button CloseBtn;

    [SerializeField]
    private Button UpgradeCoinCheat;


    private void Awake()
    {
        MoneyCheat.onClick.AddListener(SetMoney);
        SetStageCheat.onClick.AddListener(SetStage);
        CloseBtn.onClick.AddListener(Hide);
        UpgradeCoinCheat.onClick.AddListener(SetUpgradeCoin);
    }

    public void Hide()
    {
        ProjectUtility.SetActiveCheck(this.gameObject, false);
    }

    public void SetMoney()
    {
        GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, 1000000000);
    }


    public void SetUpgradeCoin()
    {
        GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.UpgradeCoin, 1000000000);
    }

    public void SetStage()
    {
        int stageIdx = 0;
        if (!int.TryParse(StageIdxInputField.text, out stageIdx))
        {
            Debug.LogError("Parse 실패");
            return;
        }

        GameRoot.Instance.UserData.CurMode.StageData.StageIdx = stageIdx;
        Debug.Log($"{stageIdx}스테이지 설정 완료");

        MoveStage();
    }

    public void MoveStage()
    {
        GameRoot.Instance.UISystem.OpenUI<PageFade>(page => {
            page.Set(() => {
                GameRoot.Instance.UserData.CurMode.StageData.WaveTimeProperty.Value = 0;
                Time.timeScale = 1f;

                GameRoot.Instance.InGameSystem.GetInGame<InGameTycoon>().curInGameStage.GetBattle.Init();

                var gethudingame = GameRoot.Instance.UISystem.GetUI<HUDInGame>();

                if (gethudingame != null)
                {
                    gethudingame.Init();
                }

                ProjectUtility.SetActiveCheck(this.gameObject, false);
            });
        });
    }
}
