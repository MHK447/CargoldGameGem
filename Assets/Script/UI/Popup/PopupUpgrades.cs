using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using UniRx;
using UnityEngine.UI;
using System.Linq;


public enum UPGRADETYPE
{
    ATTACK,
    DEFENCE,
    SPECIAL,
}

[UIPath("UI/Popup/PopupUpgrades")]
public class PopupUpgrades : UIBase
{
    [SerializeField]
    private Transform UpgradeComponentRoot;

    [SerializeField]
    private GameObject UpgradeComponentPrefb;

    [SerializeField]
    private List<GameObject> CachedComponents = new List<GameObject>();

    [SerializeField]
    private List<Toggle> UpgradeToggles = new List<Toggle>();

    public UPGRADETYPE CurrentTab { get; private set; } = UPGRADETYPE.ATTACK;

    private UPGRADETYPE defualtOption = UPGRADETYPE.ATTACK;

    [SerializeField]
    private GameObject SkillRoot;

    [SerializeField]
    private Button SkillUnLockBtn;

    [SerializeField]
    private Text CostText;

    private int CostValue = 0;

    private CompositeDisposable disposables = new CompositeDisposable();

    protected override void Awake()
    {
        base.Awake();
        int iter = 0;
        foreach (var toggle in UpgradeToggles)
        {
            var tabIdx = iter;
            toggle.isOn = false;
            toggle.onValueChanged.AddListener(on =>
            {
                ChangeTab((UPGRADETYPE)tabIdx, on);
            });
            ChangeTab((UPGRADETYPE)tabIdx, false);
            ++iter;
        }

        SkillUnLockBtn.onClick.AddListener(OnClickUnLockBtn);

            
    }

    public void SelectTab(UPGRADETYPE tab)
    {
      
    }

    private IEnumerator SkillPosWaitOneFrame()
    {
        yield return new WaitForEndOfFrame(); 
        yield return new WaitForEndOfFrame();


        RectTransform SkillRecT = CachedComponents.FindAll(x => x.gameObject.activeSelf == true).LastOrDefault().transform as RectTransform;

        RectTransform RecT = SkillRoot.transform as RectTransform;

        RecT.anchoredPosition = new Vector2(RecT.anchoredPosition.x, SkillRecT.anchoredPosition.y - 200);

        SkillRoot.transform.SetAsLastSibling();
    }


    private void OnDestroy()
    {
        disposables.Clear();
    }

    private void OnClickUnLockBtn()
    {
    }

    public override void OnShowBefore()
    {
        base.OnShowBefore();
        StartCoroutine(WaitOneFrame());
    }

    IEnumerator WaitOneFrame()
    {
        yield return new WaitForEndOfFrame();

    }


    public void ChangeTab(UPGRADETYPE tab, bool on)
    {
        if (CurrentTab == tab) return;

        CurrentTab = tab;

        if (on)
        {
            SelectTab(tab);
        }

        foreach (var toggle in UpgradeToggles)
        {
            var toggleani = toggle.gameObject.GetComponent<Animator>();
            toggleani.SetTrigger("Normal");
        }

        var ani = UpgradeToggles[(int)tab].gameObject.GetComponent<Animator>();
        if (ani != null)
        {
            if (on)
            {
                SoundPlayer.Instance.PlaySound("btn");
                if (!UpgradeToggles[(int)tab].isOn)
                    UpgradeToggles[(int)tab].isOn = true;
                ani.SetTrigger("Selected");
            }
            else
                ani.SetTrigger("Normal");
        }
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
}
