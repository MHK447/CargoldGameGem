using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri; 


public class PlayerSystem 
{
    public int min_stock_price = 0;

    public void Create()
    {
        min_stock_price = Tables.Instance.GetTable<Define>().GetData("min_stock_price").value;
    }


    public void AddStock()
    {
        var stockvalue = GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value;

        if (GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value <= GameRoot.Instance.UserData.CurMode.Money.Value)
        {
            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, -stockvalue);
            GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Value += 1;
        }

    }


    public void SellStock()
    {
        var stockvalue = GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value;

        if (GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Value > 0)
        {
            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, stockvalue);
            GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Value -= 1;
        }

    }
}
