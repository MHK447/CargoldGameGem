using UnityEngine;
using System.Collections.Generic;

namespace BanpoFri
{
    [System.Serializable]
    public class EventInfoData
    {
        [SerializeField]
		private int _eventid;
		public int eventid
		{
			get { return _eventid;}
			set { _eventid = value;}
		}
		[SerializeField]
		private int _stageId;
		public int stageId
		{
			get { return _stageId;}
			set { _stageId = value;}
		}
		[SerializeField]
		private string _eventType;
		public string eventType
		{
			get { return _eventType;}
			set { _eventType = value;}
		}
		[SerializeField]
		private string _eventSubtype;
		public string eventSubtype
		{
			get { return _eventSubtype;}
			set { _eventSubtype = value;}
		}
		[SerializeField]
		private int _eventTypeValue;
		public int eventTypeValue
		{
			get { return _eventTypeValue;}
			set { _eventTypeValue = value;}
		}
		[SerializeField]
		private int _eventDurationMs;
		public int eventDurationMs
		{
			get { return _eventDurationMs;}
			set { _eventDurationMs = value;}
		}
		[SerializeField]
		private string _randomEventText;
		public string randomEventText
		{
			get { return _randomEventText;}
			set { _randomEventText = value;}
		}

    }

    [System.Serializable]
    public class EventInfo : Table<EventInfoData, int>
    {
    }
}

