using BanpoFri;
using DefaultSetting.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StockEventData
{
    private EventInfoData _eventInfoData;
    private Action<EventInfoData> _callback;

    public void Init(EventInfoData stockEventInfo)
    {
        _eventInfoData = stockEventInfo;
    }

    public void StartEvent(Action<EventInfoData> callback)
    {
        HUDEvent eventPopup = GameRoot.Instance.UISystem.GetUI<HUDEvent>();
        if (eventPopup != null && eventPopup.gameObject.activeSelf == true)
            eventPopup.Init(_eventInfoData.event_description);
        else
            GameRoot.Instance.UISystem.OpenUI<HUDEvent>(popup => popup.Init(_eventInfoData.event_description));

        _callback = callback;
        SetData(true);
        GameRoot.Instance.WaitTimeAndCallback(_eventInfoData.event_duration / 100, EndEvent);
    }

    public void EndEvent()
    {
        SetData(false);
        _callback.Invoke(_eventInfoData);
    }

    //TODO: Start인 경우 의도한 값 그대로 세팅하고, 끝나는 경우 -1 곱하기
    private void SetData(bool isStart)
    {
        int sign = isStart ? 1 : -1;

        switch (_eventInfoData.event_type)
        {
            case "changeStageValue":
                if (_eventInfoData.event_subtype == "increaseSpeedMin")
                    StockEventSystem.SpeedMin += _eventInfoData.event_type_value * sign;
                if (_eventInfoData.event_subtype == "changeDownRate")
                    StockEventSystem.DownRate += _eventInfoData.event_type_value * sign;
                break;
            default:
                break;
        }
    }
}
