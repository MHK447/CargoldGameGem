using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UnityEngine.AddressableAssets;
using System.Linq;


public class InGameBattle : MonoBehaviour
{
    [SerializeField]
    private InGameStockRoot StockRoot;


    public void Init()
    {
        StockRoot.FirstStart();
    }
  

}
