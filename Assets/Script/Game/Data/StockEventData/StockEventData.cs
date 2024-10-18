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
        _callback = callback;
        SetData(true);
        GameRoot.Instance.WaitTimeAndCallback(_eventInfoData.eventDurationMs / 100, EndEvent);
    }

    public void EndEvent()
    {
        SetData(false);

        _callback.Invoke(_eventInfoData);
    }

    //TODO: Start인 경우 의도한 값 그대로 세팅하고, 끝나는 경우 -1 곱하기
    private void SetData(bool isStart)
    {
        switch (_eventInfoData.eventid)
        {
            case 1:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;
            case 2:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;
            case 3:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;
            case 4:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;
            case 5:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;
            case 6:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;


            case 7:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 8:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 9:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;
            case 10:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 11:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 12:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 13:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 14:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 15:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 16:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            case 17:
                Debug.Log($"HighCl_{Time.time}: SetData\nEvent{_eventInfoData.eventid} Data Setting");
                break;

            default:
                break;
        }
    }
}
