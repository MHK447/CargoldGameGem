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

        var finddata = GameRoot.Instance.WeaponSystem.GetBuffValue(WeaponSystem.Type.MinusMoney);

        if (GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value <= GameRoot.Instance.UserData.CurMode.Money.Value
            || finddata > -1)
        {
            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, -stockvalue);
            GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Value += 1;
        }

    }


    public bool IsLuckySell()
    {
        var finddata = GameRoot.Instance.WeaponSystem.GetBuffValue(WeaponSystem.Type.LuckyStockSell);

        if (finddata > 0)
        {
            return Random.Range(0, 100) < finddata;
        }

        return false;
    }


    public bool IsLuckyBuy()
    {
        var finddata = GameRoot.Instance.WeaponSystem.GetBuffValue(WeaponSystem.Type.LuckyStockAdd);

        if (finddata > 0)
        {
            return Random.Range(0, 100) < finddata;
        }

        return false;
    }



    public void SellStock()
    {
        var stockvalue = GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value;

        if (GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Value > 0)
        {
            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, stockvalue);


            if(!IsLuckySell())
            GameRoot.Instance.UserData.CurMode.PlayerData.CurStockCountProerty.Value -= 1;
        }

    }
}
