using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BanpoFri;

[UIPath("UI/InGame/StockNodeComponent", false, true)]
public class StockNodeComponent : InGameFloatingUI
{
    public enum GuageType
    {
        RedCandle,
        BlueCandle,
    }
    

    [SerializeField]
    private Slider SliderValue;

    [SerializeField]
    private Image GuageBar;

    [SerializeField]
    private RectTransform ProgressTr;

    public GuageType Type;


    public void Set(int value , GuageType type, int percent = 0)
    {
        SliderValue.value = 2f;
        Type = type;
        GuageBar.color = Type == GuageType.RedCandle ? Config.Instance.GetImageColor("StockNode_Red") :
            Config.Instance.GetImageColor("StockNode_Blue");

        var finddata = GameRoot.Instance.WeaponSystem.GetBuffValue(WeaponSystem.Type.StockMinus);

        if(value <= GameRoot.Instance.PlayerSystem.min_stock_price && finddata <= -1)
        {
            value = GameRoot.Instance.PlayerSystem.min_stock_price;
            GuageBar.color = Config.Instance.GetImageColor("StockNode_Red");
            percent = 0;
        }

        GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value = value;

        ProgressTr.sizeDelta = percent < 20 ? new Vector2(20, ProgressTr.sizeDelta.y) : new Vector2(percent, ProgressTr.sizeDelta.y);
        
    }
}
