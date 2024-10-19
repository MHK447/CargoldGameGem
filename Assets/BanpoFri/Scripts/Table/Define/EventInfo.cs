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
		private int _good_event_yn;
		public int good_event_yn
		{
			get { return _good_event_yn;}
			set { _good_event_yn = value;}
		}
		[SerializeField]
		private List<string> _event_types;
		public List<string> event_types
		{
			get { return _event_types;}
			set { _event_types = value;}
		}
		[SerializeField]
		private int _event_weight;
		public int event_weight
		{
			get { return _event_weight;}
			set { _event_weight = value;}
		}
		[SerializeField]
		private List<int> _event_type_values;
		public List<int> event_type_values
		{
			get { return _event_type_values;}
			set { _event_type_values = value;}
		}
		[SerializeField]
		private int _event_duration;
		public int event_duration
		{
			get { return _event_duration;}
			set { _event_duration = value;}
		}
		[SerializeField]
		private string _event_filename;
		public string event_filename
		{
			get { return _event_filename;}
			set { _event_filename = value;}
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

