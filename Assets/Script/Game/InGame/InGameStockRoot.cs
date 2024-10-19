using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;

public class InGameStockRoot : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> CachedComponents = new List<GameObject>();

    [SerializeField]
    private GameObject NodePrefab;

    [SerializeField]
    private Transform NodeRoot;

    private float NodeSpaceIncreaseX = 0.5f;

    private float NodeSpaceIncreaseY = 0.5f;

    private float CamXMove = 0.1f;

    private float NodeCreateTime = 0f;

    private float delcreatetime = 0f;

    public float CameraX = 1f;

    public float CameraY = 1f;

    private PanAndZoom Cam;

    private StockNodeComponent CurStock;

    private StageInfoData StageInfoData; 

    public void FirstStart()
    {
        GameRoot.Instance.UserData.CurMode.StageData.IsStartBattle = true;

        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        StageInfoData = Tables.Instance.GetTable<StageInfo>().GetData(curstageidx);

        if(StageInfoData != null)
        {
            delcreatetime = (float)StageInfoData.node_time / 100f;

            NodeCreateTime = Time.time + delcreatetime;

            Cam = GameRoot.Instance.InGameSystem.CurInGame.IngameCamera;

            GameRoot.Instance.UserData.SetReward((int)Config.RewardType.Currency, (int)Config.CurrencyID.Money, StageInfoData.start_money);
        }

    }

    public void CreateNode()
    {
        GameRoot.Instance.UISystem.LoadFloatingUI<StockNodeComponent>((stock) => {
            ProjectUtility.SetActiveCheck(stock.gameObject, true);
            CachedComponents.Add(stock.gameObject);
            stock.transform.SetParent(stock.transform);
            stock.transform.position = Vector3.zero;

            int curstockvalue = GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value;

            if (CurStock != null)
            {
                float curstockx = CurStock.transform.position.x;
                float curstocky = CurStock.transform.position.y;



                if(CurStock.Type == StockNodeComponent.GuageType.RedCandle)
                {
                    int percentvalue = 0;

                    var istype = IsChangeUpNode();

                    percentvalue = GetStocUpPercent();

                    var plusvalue = ProjectUtility.GetPercentValue(GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value, percentvalue);

                    plusvalue = curstockvalue + plusvalue;

                    var pluspercentvalue = percentvalue / 20;

                    NodeSpaceIncreaseX = NodeSpaceIncreaseX * pluspercentvalue;

                    stock.transform.position =
                    new Vector3(CurStock.transform.position.x + NodeSpaceIncreaseX, CurStock.transform.position.y + NodeSpaceIncreaseY, 1f);
                    stock.Set((int)plusvalue, istype,percentvalue);
                    CurStock = stock;
                }
                else
                {
                    int percentvalue = 0;

                    var istype = IsChangeDownNode();

                    percentvalue = GetStocUpPercent();

                    var plusvalue = ProjectUtility.GetPercentValue(GameRoot.Instance.UserData.CurMode.StageData.CurStockPriceProperty.Value, percentvalue);

                    plusvalue = curstockvalue - plusvalue;

                    var pluspercentvalue = percentvalue / 20;

                    NodeSpaceIncreaseX = NodeSpaceIncreaseX * pluspercentvalue;

                    stock.transform.position =
                    new Vector3(CurStock.transform.position.x + NodeSpaceIncreaseX, CurStock.transform.position.y + -NodeSpaceIncreaseY, 1f);
                    stock.Set((int)plusvalue, istype , percentvalue);
                    CurStock = stock;
                }
            }
            else
            {
                CurStock = stock;
                stock.transform.position = new Vector3(0, 20, 0);
                stock.Set(StageInfoData.start_price, StockNodeComponent.GuageType.RedCandle);

            }

            var cameray = CurStock.Type == StockNodeComponent.GuageType.RedCandle ? CameraY : -CameraY;

            Cam.FollowCameraPos(CurStock.transform);
            //Cam.transform.position = new Vector3(Cam.transform.position.x + CameraX, Cam.transform.position.y + CameraY, 0f);
        });


    }


    private void Update()
    {
        if(NodeCreateTime <= Time.time)
        {
            CreateNode();
            NodeCreateTime = Time.time + delcreatetime;
        }
    }


    public StockNodeComponent.GuageType IsChangeUpNode()
    {
        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(curstageidx);

        var randavalue = Random.Range(0, 100);

        StockNodeComponent.GuageType type;

        type = td.change_down_rate < randavalue ? StockNodeComponent.GuageType.RedCandle : StockNodeComponent.GuageType.BlueCandle;

        return type;
    }

    public StockNodeComponent.GuageType IsChangeDownNode()
    {
        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(curstageidx);

        var randavalue = Random.Range(0, 100);

        StockNodeComponent.GuageType type;

        type = td.change_down_rate < randavalue ? StockNodeComponent.GuageType.BlueCandle : StockNodeComponent.GuageType.RedCandle;

        return type;
    }


    public int GetStockDownPercent()
    {
        int returnvalue = 0;

        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(curstageidx);

        if(td != null)
        {
            returnvalue = Random.Range(td.down_stock_min, td.down_stock_max);


        }

        return returnvalue;
    }


    public int GetStocUpPercent()
    {
        int returnvalue = 0;

        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(curstageidx);

        if (td != null)
        {
            returnvalue = Random.Range(td.down_stock_min, td.down_stock_max);


        }

        return returnvalue;
    }

}
