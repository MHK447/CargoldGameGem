using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UnityEngine.UI;


[UIPath("UI/Page/HUDInGame", true)]
public class HUDInGame : UIBase
{
    [SerializeField]
    private InGameTopComponent TopComponent;

    [SerializeField]
    private Button SellBtn;

    [SerializeField]
    private Button BuyBtn;

}
