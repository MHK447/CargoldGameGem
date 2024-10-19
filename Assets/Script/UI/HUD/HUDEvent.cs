using UnityEngine;
using BanpoFri;
using UnityEngine.UI;

[UIPath("UI/Page/HUDEvent", true)]
public class HUDEvent : UIBase
{
    [SerializeField] private Image eventImage;
    [SerializeField] private Text messageText;
    private float _beforeTimeScale = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init(EventInfoData eventInfoData)
    {
        Time.timeScale = 0;

        eventImage.sprite = Config.Instance.GetUIEventImg(eventInfoData.event_filename);
        messageText.text = eventInfoData.event_description;
    }

    public override void Hide()
    {
        base.Hide();

        Time.timeScale = 1f ;
    }
}