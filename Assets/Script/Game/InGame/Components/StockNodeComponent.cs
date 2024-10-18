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

    public GuageType Type;


    public void Set(int value , GuageType type)
    {
        SliderValue.value = 2f;
        Type = type;
        GuageBar.color = Type == GuageType.RedCandle ? Config.Instance.GetImageColor("StockNode_Red") :
            Config.Instance.GetImageColor("StockNode_Blue");

    }
}
