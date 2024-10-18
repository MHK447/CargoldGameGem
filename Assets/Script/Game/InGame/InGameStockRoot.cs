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


    public void FirstStart()
    {
        CreateNode();
    }

    public void CreateNode()
    {
        var getobj = GetCachedObject().GetComponent<StockNodeComponent>();

        GameRoot.Instance.UISystem.LoadFloatingUI<StockNodeComponent>((stock) => {
            ProjectUtility.SetActiveCheck(stock.gameObject, true);
            CachedComponents.Add(stock.gameObject);
            stock.transform.SetParent(stock.transform);
            stock.transform.position = Vector3.zero;
        });


    }


    public GameObject GetCachedObject()
    {
        var inst = CachedComponents.Find(x => !x.activeSelf);
        if (inst == null)
        {
            inst = GameObject.Instantiate(NodePrefab);
            inst.transform.SetParent(NodeRoot);
            inst.transform.localScale = Vector3.one;
            CachedComponents.Add(inst);
        }

        return inst;
    }




}
