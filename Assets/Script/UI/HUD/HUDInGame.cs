using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UnityEngine.UI;


[UIPath("UI/Page/HUDInGame", true)]
public class HUDInGame : UIBase
{
    [SerializeField]
    private InGameTopComponent TopComponent;

    [SerializeField]
    private Button SellBtn;

    [SerializeField]
    private Button BuyBtn;

    protected override void Awake()
    {
        base.Awake();

        BuyBtn.onClick.AddListener(OnClickBuy);
        SellBtn.onClick.AddListener(OnClickSell);
    }

    public void Init()
    {
        var stageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        TopComponent.Set(stageidx);
    }

    public void OnClickBuy()
    {

    }

    public void OnClickSell()
    {

    }

}
