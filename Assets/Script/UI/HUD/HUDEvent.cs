using UnityEngine;
using BanpoFri;
using UnityEngine.UI;

[UIPath("UI/Page/HUDEventMessagePopup", true)]
public class HUDEvent : UIBase
{
    [SerializeField]
    private RectTransform moveRectTr;

    [SerializeField]
    private Text messageText;
    private Button closePopupButton;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init(string message)
    {
        messageText.text = message;
    }
}