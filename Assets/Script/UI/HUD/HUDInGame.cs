using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UnityEngine.UI;
using UniRx;


[UIPath("UI/Page/HUDInGame", true)]
public class HUDInGame : UIBase
{
    [SerializeField]
    private InGameTopComponent TopComponent;

    public StageResultComponent ResultComponent;

    [SerializeField]
    private Button SellBtn;

    [SerializeField]
    private Button BuyBtn;

    [SerializeField]
    private Text MyMoneyText;

    [SerializeField]
    private Text CurPlayerStockText;

    private CompositeDisposable disposables = new CompositeDisposable();

    protected override void Awake()
    {
        base.Awake();

        BuyBtn.onClick.AddListener(OnClickBuy);
        SellBtn.onClick.AddListener(OnClickSell);
    }

    public void Init()
    {
        ProjectUtility.SetActiveCheck(ResultComponent.gameObject, false);

        disposables.Clear();

        var stageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;
        TopComponent.Set(stageidx , this);

        GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Subscribe(x => {
            CurPlayerStockText.text = $"{x}주";
        }).AddTo(disposables);


        GameRoot.Instance.UserData.CurMode.Money.Subscribe(x=> {
            SetMyMoneyText((int)x);
        }).AddTo(disposables);
    }

    public void OnClickBuy()
    {
        GameRoot.Instance.PlayerSystem.AddStock();
    }


    public void OnClickSell()
    {
        GameRoot.Instance.PlayerSystem.SellStock();
    }

    public void SetMyMoneyText(int mymoney)
    {
        MyMoneyText.text = mymoney.ToString();
    }


    private void OnDestroy()
    {
        disposables.Clear();
    }
}
