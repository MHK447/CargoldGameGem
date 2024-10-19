using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatWindowTest : MonoBehaviour
{
    [SerializeField]
    private Button MoneyCheat;

    [SerializeField]
    private Button StageCheat;

    [SerializeField]
    private Button CloseBtn;


    private void Awake()
    {
        MoneyCheat.onClick.AddListener(SetMoney);
        StageCheat.onClick.AddListener(SetStage);
        CloseBtn.onClick.AddListener(Hide);
    }

    public void Hide()
    {
        ProjectUtility.SetActiveCheck(this.gameObject, false);
    }

    public void SetMoney()
    {
        GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, 1000000000);
    }

    public void SetStage()
    {
        GameRoot.Instance.UserData.CurMode.StageData.StageIdx += 1;
    }
}
