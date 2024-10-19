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

    [SerializeField]
    private Transform SellTextRoot;

    [SerializeField]
    private Transform BuyTrTextRoot;

    [SerializeField]
    private Transform SellTrTextRoot;

    [SerializeField]
    private Image ConcentrationLine;

    [SerializeField]
    private Animator characterAnim;


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

        GameRoot.Instance.StockEventSystem.onStartEventAction -= OnStartEvent;
        GameRoot.Instance.StockEventSystem.onStartEventAction += OnStartEvent;
        GameRoot.Instance.StockEventSystem.onEndEventAction -= OnEndEvent;
        GameRoot.Instance.StockEventSystem.onEndEventAction += OnEndEvent;

        var stageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;
        TopComponent.Set(stageidx , this);

        GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Subscribe(x => {
            CurPlayerStockText.text = $"{x}주";
        }).AddTo(disposables);


        GameRoot.Instance.UserData.CurMode.Money.Subscribe(x=> {
            SetMyMoneyText((int)x);
        }).AddTo(disposables);

        ConcentrationLine.enabled = false;
    }

    public void OnClickBuy()
    {
        SoundPlayer.Instance.PlaySound("Effect_Btn_Buy");
        if (GameRoot.Instance.PlayerSystem.IsLuckyBuy())
        {
            GameRoot.Instance.PlayerSystem.AddStock(BuyTrTextRoot);
        }

        GameRoot.Instance.PlayerSystem.AddStock(BuyTrTextRoot);

        characterAnim.SetTrigger("Click");
    }


    public void OnClickSell()
    {
        SoundPlayer.Instance.PlaySound("Effect_Btn_Sell");
        GameRoot.Instance.PlayerSystem.SellStock(SellTrTextRoot);

        characterAnim.SetTrigger("Click");
    }

    public void SetMyMoneyText(int mymoney)
    {
        MyMoneyText.text = $"${mymoney}";
    }

    public void OnStartEvent()
    {
        ConcentrationLine.enabled = true;
    }

    public void OnEndEvent() 
    {
        ConcentrationLine.enabled = false;
    }

    private void OnDestroy()
    {
        disposables.Clear();
    }
}
