using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using System.Linq;

public class WeaponSystem
{

    public enum Type
    {
        MoneyDecrease = 1,
        StartMoneyIncrease,
        StockMinus,
        MinusMoney,
        LuckyStockAdd,
        LuckyStockSell,

    }



    public int GetBuffValue(Type type)
    {
        var finddata = GameRoot.Instance.UserData.CurMode.WeaponDatas.ToList().FindAll(x=> x.Type == (int)type);

        int value = -1;

        if (finddata.Count > 0)
        {
            value = 0;
            foreach (var data in finddata)
            {
                var td = Tables.Instance.GetTable<ItemInfo>().GetData((int)data.WeaponIdx);
                if (td != null)
                {
                    value += td.item_effect_value;
                }

            }
        }

        return value;
    }
}
