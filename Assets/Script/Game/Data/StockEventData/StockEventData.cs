using BanpoFri;
using System;
using System.Collections;
using UnityEngine;

public class StockEventData
{
    private EventInfoData _eventInfoData;
    private Action<EventInfoData> _callback;

    public void Init(EventInfoData stockEventInfo)
    {
        _eventInfoData = stockEventInfo;
    }

    public Coroutine StartEvent(Action<EventInfoData> callback)
    {
        HUDEvent eventPopup = GameRoot.Instance.UISystem.GetUI<HUDEvent>();
        if (eventPopup != null && eventPopup.gameObject.activeSelf == true)
            eventPopup.Init(_eventInfoData);
        else
            GameRoot.Instance.UISystem.OpenUI<HUDEvent>(popup => popup.Init(_eventInfoData));

        _callback = callback;
        SetData(true);
        return GameRoot.Instance.StartCoroutine(waitTimeAndCallback(_eventInfoData.event_duration / 100, EndEvent));
    }

    IEnumerator waitTimeAndCallback(float time, System.Action callback)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();
    }

    public void EndEvent()
    {
        SetData(false);
        _callback.Invoke(_eventInfoData);
    }

    private void SetData(bool isStart)
    {
        int sign = isStart ? 1 : -1;

        for (int i = 0; i < _eventInfoData.event_types.Count; i++)
        {
            int value = _eventInfoData.event_type_values[i] * sign;

            switch (_eventInfoData.event_types[i])
            {
                case "add_up_rate":
                    GameRoot.Instance.UserData.CurMode.EventData.event_change_up_rate += value;
                    break;
                case "add_down_rate":
                    GameRoot.Instance.UserData.CurMode.EventData.event_change_down_rate += value;
                    break;
                case "add_up_stock":
                    GameRoot.Instance.UserData.CurMode.EventData.event_up_stock_min += value;
                    GameRoot.Instance.UserData.CurMode.EventData.event_up_stock_max += value;
                    break;
                case "add_down_stock":
                    GameRoot.Instance.UserData.CurMode.EventData.event_down_stock_min += value;
                    GameRoot.Instance.UserData.CurMode.EventData.event_down_stock_max += value;
                    break;
                case "add_node_time":
                    GameRoot.Instance.UserData.CurMode.EventData.Event_node_time += value;
                    break;
                default:
                    break;
            }
        }
    }
}
