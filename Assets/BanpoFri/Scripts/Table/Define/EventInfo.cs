using UnityEngine;
using System.Collections.Generic;

namespace BanpoFri
{
    [System.Serializable]
    public class EventInfoData
    {
        [SerializeField]
		private int _event_id;
		public int event_id
		{
			get { return _event_id;}
			set { _event_id = value;}
		}
		[SerializeField]
		private int _stage_id;
		public int stage_id
		{
			get { return _stage_id;}
			set { _stage_id = value;}
		}
		[SerializeField]
		private string _event_type;
		public string event_type
		{
			get { return _event_type;}
			set { _event_type = value;}
		}
		[SerializeField]
		private string _event_subtype;
		public string event_subtype
		{
			get { return _event_subtype;}
			set { _event_subtype = value;}
		}
		[SerializeField]
		private int _event_weight;
		public int event_weight
		{
			get { return _event_weight;}
			set { _event_weight = value;}
		}
		[SerializeField]
		private int _event_type_value;
		public int event_type_value
		{
			get { return _event_type_value;}
			set { _event_type_value = value;}
		}
		[SerializeField]
		private int _event_duration;
		public int event_duration
		{
			get { return _event_duration;}
			set { _event_duration = value;}
		}
		[SerializeField]
		private string _event_description;
		public string event_description
		{
			get { return _event_description;}
			set { _event_description = value;}
		}

    }

    [System.Serializable]
    public class EventInfo : Table<EventInfoData, int>
    {
    }
}

