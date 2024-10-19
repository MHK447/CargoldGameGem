using UnityEngine;
using BanpoFri;
using UnityEngine.UI;

[UIPath("UI/Page/HUDEvent", true)]
public class HUDEvent : UIBase
{
    [SerializeField] private Image eventImage;
    [SerializeField] private Text messageText;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init(EventInfoData eventInfoData)
    {
        eventImage.sprite = Config.Instance.GetUIEventImg(eventInfoData.event_filename);
        messageText.text = eventInfoData.event_description;
    }
}