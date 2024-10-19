using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataController : MonoBehaviour
{
    public enum Event
    {
        add_up_rate,
        add_down_rate,
        add_up_stock,
        add_down_stock,
        add_node_time,
    }
    public Event eventList;
    public int setValue;

    public int currentStageIdx;
    public int event_change_up_rate;
    public int event_change_down_rate;
    public int event_up_stock_min;
    public int event_up_stock_max;
    public int event_down_stock_min;
    public int event_down_stock_max;
    public int Event_node_time;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 3f)
            return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            switch (eventList)
            {
                case Event.add_up_rate:
                    GameRoot.Instance.UserData.CurMode.EventData.event_change_up_rate = setValue;
                    break;
                case Event.add_down_rate:
                    GameRoot.Instance.UserData.CurMode.EventData.event_change_down_rate = setValue;
                    break;
                case Event.add_up_stock:
                    GameRoot.Instance.UserData.CurMode.EventData.event_up_stock_min = setValue;
                    GameRoot.Instance.UserData.CurMode.EventData.event_up_stock_max = setValue;
                    break;
                case Event.add_down_stock:
                    GameRoot.Instance.UserData.CurMode.EventData.event_down_stock_min = setValue;
                    GameRoot.Instance.UserData.CurMode.EventData.event_down_stock_max = setValue;
                    break;
                case Event.add_node_time:
                    GameRoot.Instance.UserData.CurMode.EventData.Event_node_time = setValue;
                    break;
                default:
                    break;
            }
        }

        currentStageIdx = GameRoot.Instance.UserData.CurMode.StageData.StageIdx;

        event_change_up_rate = GameRoot.Instance.UserData.CurMode.EventData.event_change_up_rate;
        event_change_down_rate = GameRoot.Instance.UserData.CurMode.EventData.event_change_down_rate;
        event_up_stock_min = GameRoot.Instance.UserData.CurMode.EventData.event_up_stock_min;
        event_up_stock_max = GameRoot.Instance.UserData.CurMode.EventData.event_up_stock_max;
        event_down_stock_min = GameRoot.Instance.UserData.CurMode.EventData.event_down_stock_min;
        event_down_stock_max = GameRoot.Instance.UserData.CurMode.EventData.event_down_stock_max;
        Event_node_time = GameRoot.Instance.UserData.CurMode.EventData.Event_node_time;
    }
}
