using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BanpoFri;


public class FrameShopComponent : MonoBehaviour
{
    [SerializeField]
    private Text NameText;

    [SerializeField]
    private Text DescText;

    [SerializeField]
    private Text CostText;

    [SerializeField]
    private Button BuyBtn;



    private int ItemInfoIdx = 0;

    private int Cost = 0;

    private void Awake()
    {
        BuyBtn.onClick.AddListener(OnClickBuy);
    }

    public void Set(int iteminfoidx)
    {
        ItemInfoIdx = iteminfoidx;


        var td = Tables.Instance.GetTable<ItemInfo>().GetData(iteminfoidx);

        if(td != null)
        {
            Cost = td.item_price;
            CostText.ToString();
            NameText.text = td.item_name.ToString();
            DescText.text = td.item_description.ToString();
        }
    }

    public void OnClickBuy()
    {
        if(Cost <= GameRoot.Instance.UserData.CurMode.UpgradeCoin.Value)
        {
            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.UpgradeCoin, -Cost);

            var neweapondata = new WeaponData(ItemInfoIdx);
            GameRoot.Instance.UserData.CurMode.WeaponDatas.Add(neweapondata);
        }
    }
}
