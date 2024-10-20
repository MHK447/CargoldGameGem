using UnityEngine;
using System.Collections.Generic;

namespace BanpoFri
{
    [System.Serializable]
    public class StageInfoData
    {
        [SerializeField]
		private int _stage_id;
		public int stage_id
		{
			get { return _stage_id;}
			set { _stage_id = value;}
		}
		[SerializeField]
		private int _start_price;
		public int start_price
		{
			get { return _start_price;}
			set { _start_price = value;}
		}
		[SerializeField]
		private int _start_money;
		public int start_money
		{
			get { return _start_money;}
			set { _start_money = value;}
		}
		[SerializeField]
		private int _target_money;
		public int target_money
		{
			get { return _target_money;}
			set { _target_money = value;}
		}
		[SerializeField]
		private int _node_time;
		public int node_time
		{
			get { return _node_time;}
			set { _node_time = value;}
		}
		[SerializeField]
		private int _change_down_rate;
		public int change_down_rate
		{
			get { return _change_down_rate;}
			set { _change_down_rate = value;}
		}
		[SerializeField]
		private int _change_up_rate;
		public int change_up_rate
		{
			get { return _change_up_rate;}
			set { _change_up_rate = value;}
		}
		[SerializeField]
		private int _down_stock_min;
		public int down_stock_min
		{
			get { return _down_stock_min;}
			set { _down_stock_min = value;}
		}
		[SerializeField]
		private int _down_stock_max;
		public int down_stock_max
		{
			get { return _down_stock_max;}
			set { _down_stock_max = value;}
		}
		[SerializeField]
		private int _up_stock_min;
		public int up_stock_min
		{
			get { return _up_stock_min;}
			set { _up_stock_min = value;}
		}
		[SerializeField]
		private int _up_stock_max;
		public int up_stock_max
		{
			get { return _up_stock_max;}
			set { _up_stock_max = value;}
		}
		[SerializeField]
		private List<int> _event_time;
		public List<int> event_time
		{
			get { return _event_time;}
			set { _event_time = value;}
		}
		[SerializeField]
		private List<int> _event_goodbad;
		public List<int> event_goodbad
		{
			get { return _event_goodbad;}
			set { _event_goodbad = value;}
		}
		[SerializeField]
		private string _stage_name;
		public string stage_name
		{
			get { return _stage_name;}
			set { _stage_name = value;}
		}
		[SerializeField]
		private string _stage_number_name;
		public string stage_number_name
		{
			get { return _stage_number_name;}
			set { _stage_number_name = value;}
		}
		[SerializeField]
		private string _stage_icon_filename;
		public string stage_icon_filename
		{
			get { return _stage_icon_filename;}
			set { _stage_icon_filename = value;}
		}
		[SerializeField]
		private int _stage_end_time;
		public int stage_end_time
		{
			get { return _stage_end_time;}
			set { _stage_end_time = value;}
		}

    }

    [System.Serializable]
    public class StageInfo : Table<StageInfoData, int>
    {
    }
}

