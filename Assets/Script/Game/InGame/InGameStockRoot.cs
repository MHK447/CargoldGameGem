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

    private PanAndZoom Cam;

    private StockNodeComponent CurStock;

    public void FirstStart()
    {
        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var td = Tables.Instance.GetTable<StageInfo>().GetData(curstageidx);

        if(td != null)
        {
            delcreatetime = (float)td.node_time / 100f;

            NodeCreateTime = Time.time + delcreatetime;

            Cam = GameRoot.Instance.InGameSystem.CurInGame.IngameCamera;
        }

    }

    public void CreateNode()
    {
        GameRoot.Instance.UISystem.LoadFloatingUI<StockNodeComponent>((stock) => {
            ProjectUtility.SetActiveCheck(stock.gameObject, true);
            CachedComponents.Add(stock.gameObject);
            stock.transform.SetParent(stock.transform);
            stock.transform.position = Vector3.zero;

            Cam.transform.position = new Vector3(Cam.transform.position.x + CameraX, Cam.transform.position.y, 0f);

            if(CurStock != null)
            {
                float curstockx = CurStock.transform.position.x;
                float curstocky = CurStock.transform.position.y;

                if(CurStock.Type == StockNodeComponent.GuageType.RedCandle)
                {
                    var istype = IsChangeUpNode();
                    stock.transform.position =
                    new Vector3(CurStock.transform.position.x + NodeSpaceIncreaseX, CurStock.transform.position.y + NodeSpaceIncreaseY, 1f);
                    stock.Set(1, istype);
                    CurStock = stock;
                }
                else
                {
                    var istype = IsChangeDownNode();
                    stock.transform.position =
                    new Vector3(CurStock.transform.position.x + NodeSpaceIncreaseX, CurStock.transform.position.y + -NodeSpaceIncreaseY, 1f);
                    stock.Set(1, istype);
                    CurStock = stock;
                }
            }
            else
            {
                CurStock = stock;
                stock.transform.position = Vector3.zero;
                stock.Set(1, StockNodeComponent.GuageType.RedCandle);

            }
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


}
