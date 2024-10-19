using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BanpoFri;


public class FrameShopComponent : MonoBehaviour
{
    [SerializeField]
    private Image Icon;

    [SerializeField]
    private Text NameText;

    [SerializeField]
    private Text DescText;

    [SerializeField]
    private Text CostText;

    [SerializeField]
    private Button BuyBtn;

    [SerializeField]
    private Animator Anim;


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
            CostText.text = Cost.ToString();
            NameText.text = td.item_name.ToString();
            DescText.text = td.item_description.ToString();
            ProjectUtility.SetActiveCheck(BuyBtn.gameObject, true);

            Icon.sprite = Config.Instance.GetBuffIconAtlas(td.item_icon);
        }
    }

    public void OnClickBuy()
    {
        if(Cost <= GameRoot.Instance.UserData.CurMode.UpgradeCoin.Value)
        {
            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.UpgradeCoin, -Cost);

            var itemtd = Tables.Instance.GetTable<ItemInfo>().GetData(ItemInfoIdx);

            var neweapondata = new WeaponData(ItemInfoIdx, itemtd.item_effect_type);
            GameRoot.Instance.UserData.CurMode.WeaponDatas.Add(neweapondata);

            ProjectUtility.SetActiveCheck(BuyBtn.gameObject, false);

            Anim.Play("Anime_Shop", 0, 0f);
        }
    }
}
