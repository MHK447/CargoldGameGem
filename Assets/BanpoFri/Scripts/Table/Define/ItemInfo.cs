using UnityEngine;
using System.Collections.Generic;

namespace BanpoFri
{
    [System.Serializable]
    public class ItemInfoData
    {
        [SerializeField]
		private int _item_id;
		public int item_id
		{
			get { return _item_id;}
			set { _item_id = value;}
		}
		[SerializeField]
		private string _item_name;
		public string item_name
		{
			get { return _item_name;}
			set { _item_name = value;}
		}
		[SerializeField]
		private string _item_icon;
		public string item_icon
		{
			get { return _item_icon;}
			set { _item_icon = value;}
		}
		[SerializeField]
		private int _item_appearance_weight;
		public int item_appearance_weight
		{
			get { return _item_appearance_weight;}
			set { _item_appearance_weight = value;}
		}
		[SerializeField]
		private int _item_rarity;
		public int item_rarity
		{
			get { return _item_rarity;}
			set { _item_rarity = value;}
		}
		[SerializeField]
		private int _item_price;
		public int item_price
		{
			get { return _item_price;}
			set { _item_price = value;}
		}
		[SerializeField]
		private int _item_stage_min_id;
		public int item_stage_min_id
		{
			get { return _item_stage_min_id;}
			set { _item_stage_min_id = value;}
		}
		[SerializeField]
		private int _item_stage_max_id;
		public int item_stage_max_id
		{
			get { return _item_stage_max_id;}
			set { _item_stage_max_id = value;}
		}
		[SerializeField]
		private string _item_description;
		public string item_description
		{
			get { return _item_description;}
			set { _item_description = value;}
		}
		[SerializeField]
		private int _item_effect_type;
		public int item_effect_type
		{
			get { return _item_effect_type;}
			set { _item_effect_type = value;}
		}
		[SerializeField]
		private int _item_effect_value;
		public int item_effect_value
		{
			get { return _item_effect_value;}
			set { _item_effect_value = value;}
		}

    }

    [System.Serializable]
    public class ItemInfo : Table<ItemInfoData, int>
    {
    }
}

