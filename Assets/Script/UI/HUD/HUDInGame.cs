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
    private Animator HUDInGameAnim;

    [SerializeField]
    private Text GoodNewsText;

    [SerializeField]
    private Text BadNewsText;

    [SerializeField]
    private Image ConcentrationLine;

    [SerializeField]
    private Animator characterAnim;

    [SerializeField]
    private Image CompanyLogoImage;

    private CompositeDisposable disposables = new CompositeDisposable();

    protected override void Awake()
    {
        base.Awake();

        BuyBtn.onClick.AddListener(OnClickBuy);
        SellBtn.onClick.AddListener(OnClickSell);
    }

    public void Init()
    {
        Debug.Log("InGameLoad!!");

        ProjectUtility.SetActiveCheck(ResultComponent.gameObject, false);

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

        string iconFileName = Tables.Instance.GetTable<StageInfo>().GetData(stageidx).stage_icon_filename;
        CompanyLogoImage.sprite = Config.Instance.GetCompanyAtlasImg(iconFileName);
        GoodNewsText.gameObject.SetActive(false);
        BadNewsText.gameObject.SetActive(false);
        ConcentrationLine.enabled = false;
    }

    public void OnClickBuy()
    {
        SoundPlayer.Instance.PlaySound("Effect_Btn_Buy");
        if (GameRoot.Instance.PlayerSystem.IsLuckyBuy())
        {
            GameRoot.Instance.PlayerSystem.AddStock(BuyTrTextRoot);
        }
        //TreepllaNative.Vibrate();
        GameRoot.Instance.PlayerSystem.AddStock(BuyTrTextRoot);

        characterAnim.SetTrigger("Click");
    }


    public void OnClickSell()
    {
        SoundPlayer.Instance.PlaySound("Effect_Btn_Sell");
        GameRoot.Instance.PlayerSystem.SellStock(SellTrTextRoot);
        characterAnim.SetTrigger("Click");
        //TreepllaNative.Vibrate();
    }

    public void SetMyMoneyText(int mymoney)
    {
        MyMoneyText.text = $"${mymoney}";
    }

    public void OnStartEvent(EventInfoData eventInfoData)
    {
        string hudTriggerStr = eventInfoData.good_event_yn == 1 ? "UP" : "Down";
        if (hudTriggerStr == "UP")
            GoodNewsText.gameObject.SetActive(true);
        else if (hudTriggerStr == "Down")
            BadNewsText.gameObject.SetActive(true);
        HUDInGameAnim.SetTrigger(hudTriggerStr);

        ConcentrationLine.enabled = true;
    }

    public void OnEndEvent(EventInfoData eventInfoData)
    {
        GoodNewsText.gameObject.SetActive(false);
        BadNewsText.gameObject.SetActive(false);
        ConcentrationLine.enabled = false;
    }
}
