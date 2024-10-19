using UnityEngine;
using BanpoFri;
using UnityEngine.UI;

[UIPath("UI/Page/HUDEvent", true)]
public class HUDEvent : UIBase
{
    [SerializeField] private Image eventImage;
    [SerializeField] private Text messageText;
    [SerializeField] private float buttonDelay = 0.5f;  // 버튼 딜레이
    
    private float _popupEntryTime;  // 버튼 딜레이
    private float _beforeTimeScale = 1;
    

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init(EventInfoData eventInfoData)
    {
        Time.timeScale = 0;
        _popupEntryTime = Time.realtimeSinceStartup;

        eventImage.sprite = Config.Instance.GetUIEventImg(eventInfoData.event_filename);
        messageText.text = eventInfoData.event_description;
    }

    public override void Hide()
    {
        if (_popupEntryTime + buttonDelay > Time.realtimeSinceStartup)
            return;

        base.Hide();
        Time.timeScale = 1f ;
    }
}