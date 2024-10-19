using UnityEngine;
using System.Collections.Generic;

namespace BanpoFri
{
    [System.Serializable]
    public class StageRewardInfoData
    {
        [SerializeField]
		private int _stage_id;
		public int stage_id
		{
			get { return _stage_id;}
			set { _stage_id = value;}
		}
		[SerializeField]
		private int _bonus_percent_1;
		public int bonus_percent_1
		{
			get { return _bonus_percent_1;}
			set { _bonus_percent_1 = value;}
		}
		[SerializeField]
		private int _bonus_percent_2;
		public int bonus_percent_2
		{
			get { return _bonus_percent_2;}
			set { _bonus_percent_2 = value;}
		}
		[SerializeField]
		private int _base_reward;
		public int base_reward
		{
			get { return _base_reward;}
			set { _base_reward = value;}
		}
		[SerializeField]
		private int _bonus_reward_1;
		public int bonus_reward_1
		{
			get { return _bonus_reward_1;}
			set { _bonus_reward_1 = value;}
		}
		[SerializeField]
		private int _bonus_reward_2;
		public int bonus_reward_2
		{
			get { return _bonus_reward_2;}
			set { _bonus_reward_2 = value;}
		}

    }

    [System.Serializable]
    public class StageRewardInfo : Table<StageRewardInfoData, int>
    {
    }
}

