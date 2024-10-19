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

    public void Init(string message)
    {
        messageText.text = message;
    }
}