using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using System.Linq;
using UnityEngine.UI;
using UniRx;    


[UIPath("UI/Popup/PopupUpgrades")]
public class PopupFrameShop : UIBase
{

    [SerializeField]
    private List<GameObject> CachedComponents = new List<GameObject>();

    [SerializeField]
    private Transform UpgradeComponentRoot;

    [SerializeField]
    private GameObject UpgradeComponentPrefb;

    [SerializeField]
    private Text CurUpgradeCost;

    private CompositeDisposable disposable = new CompositeDisposable();


    [SerializeField]
    private Button ExitBtn;


    protected override void Awake()
    {
        base.Awake();
        ExitBtn.onClick.AddListener(OnClickExit);
    }

    public void Init()
    {

        Time.timeScale = 0f;
        disposable.Clear();

        GameRoot.Instance.UserData.CurMode.UpgradeCoin.Subscribe(x => {
            CurUpgradeCost.text = x.ToString();
        }).AddTo(disposable);

        var curstageidx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        var iteminfotdlist = Tables.Instance.GetTable<ItemInfo>().DataList.FindAll(x => x.item_stage_max_id >= curstageidx && x.item_stage_min_id <= curstageidx).ToList();


        for(int i = 0; i < CachedComponents.Count; ++i)
        {
            ProjectUtility.SetActiveCheck(CachedComponents[i].gameObject, false);
        }


        for(int i = 0; i < 4; ++i)
        {
            var getitem =  GetRandomItem(iteminfotdlist);
            iteminfotdlist.Remove(getitem);

            var getobj = GetCachedObject().GetComponent<FrameShopComponent>();

            if(getobj != null)
            {
                ProjectUtility.SetActiveCheck(getobj.gameObject, true);
                getobj.Set(getitem.item_id);
            }
        }
    }


    public void OnClickExit()
    {
        Hide();


        GameRoot.Instance.UISystem.OpenUI<PageFade>(page => {
            page.Set(() => {
                Time.timeScale = 1f;
                GameRoot.Instance.UserData.CurMode.StageData.StageIdx += 1;

                GameRoot.Instance.InGameSystem.GetInGame<InGameTycoon>().curInGameStage.GetBattle.Init();

                var gethudingame = GameRoot.Instance.UISystem.GetUI<HUDInGame>();

                if (gethudingame != null)
                {
                    gethudingame.Init();
                }

                ProjectUtility.SetActiveCheck(this.gameObject, false);
            });
        });
    }

    


    // 가중치에 따라 랜덤으로 아이템 선택
     ItemInfoData GetRandomItem(List<ItemInfoData> items)
    {
        // 모든 아이템의 총 가중치를 계산
        float totalWeight = 0f;
        foreach (ItemInfoData item in items)
        {
            totalWeight += item.item_appearance_weight;
        }

        // 0부터 총 가중치 사이의 랜덤 값 생성
        float randomValue = Random.Range(0, totalWeight);

        // 랜덤 값이 속하는 구간을 찾아 해당 아이템 반환
        float cumulativeWeight = 0f;
        foreach (ItemInfoData item in items)
        {
            cumulativeWeight += item.item_appearance_weight;
            if (randomValue < cumulativeWeight)
            {
                return item;
            }
        }

        // 에러 방지를 위한 기본 반환 (실제로는 실행되지 않도록 보장)
        return items[0];
    }


    public GameObject GetCachedObject()
    {
        var inst = CachedComponents.Find(x => !x.activeSelf);
        if (inst == null)
        {
            inst = GameObject.Instantiate(UpgradeComponentPrefb);
            inst.transform.SetParent(UpgradeComponentRoot);
            inst.transform.localScale = Vector3.one;
            CachedComponents.Add(inst);
        }

        return inst;
    }


    private void OnDestroy()
    {
        disposable.Clear();
    }
}
