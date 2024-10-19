using System;
using System.Numerics;
using UniRx;
using System.Collections.Generic;
using UnityEngine;
using BanpoFri;
using System.Linq;

public interface IReadOnlyData : ICloneable { 
	void Create();
}
public interface IClientData { }

public class PlayerData
{
	public IReactiveProperty<int> CurStockCountProerty = new ReactiveProperty<int>();


	public void Clear()
    {
		CurStockCountProerty.Value = 0;
		GameRoot.Instance.UserData.CurMode.Money.Value = 0;
		GameRoot.Instance.UserData.HUDMoney.Value = 0;
    }

}


public class WeaponData
{
	public int WeaponIdx = 0;
	public int Type = 0;

	public WeaponData(int weaponidx , int type)
    {
		WeaponIdx = weaponidx;
		Type = type;
    }
}

public class StageData
{

	public IReactiveProperty<int> CurStockPriceProperty = new ReactiveProperty<int>();
	public int StageIdx { get; set; } = 0;
	public IReactiveProperty<int> WaveIdxProperty = new ReactiveProperty<int>();
	public IReactiveProperty<int> UnitCountPropety = new ReactiveProperty<int>();
	public IReactiveProperty<int> WaveRewardProperty = new ReactiveProperty<int>();

	public IReactiveProperty<int> WaveTimeProperty = new ReactiveProperty<int>();

	public int UnitAddCount = 0;

	public int StageHighWave = 1;

	public bool IsStartBattle = false;

	public float StageCoolTime = 0f;

	public IReactiveProperty<bool> IsBossProperty = new ReactiveProperty<bool>(false);

	public void StageEndClear()
    {
		WaveIdxProperty.Value = 1;
		UnitAddCount = 0;
		UnitCountPropety.Value = 0;
		WaveTimeProperty.Value = 0;

	}


	public void SetStage(int stageidx)
    {
		StageIdx = stageidx;
    }

	public void SetWave(int waveidx)
    {
		WaveIdxProperty.Value = waveidx;	
    }
}

public class EventData
{
	public int event_change_down_rate = 0; // 연결 완
	public int event_change_up_rate = 0; // 연결 완
    public int event_down_stock_min = 0; // 연결 완
    public int event_down_stock_max = 0; // 연결 완
    public int event_up_stock_min = 0; // 연결 완
    public int event_up_stock_max = 0; // 연결 완
	private int _event_node_time; 
	public int Event_node_time // 연결 완
	{
		get
		{
			return _event_node_time;
        }
		set
		{
			_event_node_time = value;
            ChangedEventNodeTime.Invoke();
        }
	}
	public Action ChangedEventNodeTime;
}

public class OutGameUnitUpgradeData
{
	public int UnitIdx = 0;
	public int UnitLevel = 0;
	public int UnitCount = 0;


	public IReactiveProperty<int> UnitCountProperty = new ReactiveProperty<int>();
	public IReactiveProperty<int> UnitLevelProperty = new ReactiveProperty<int>();




	public OutGameUnitUpgradeData(int unitidx , int unitlevel , int unitcount)
    {
		UnitIdx = unitidx;
		UnitLevel = unitlevel;
		UnitCount = unitcount;

		UnitCountProperty.Value = UnitCount;
		UnitLevelProperty.Value = UnitLevel;

		UnitLevelProperty.Subscribe(x => { UnitLevel = x; });
		UnitCountProperty.Subscribe(x => { UnitCount = x; });
	}



}

public class SelectGachaWeaponSkillData
{
	public int SkillTypeIdx = 0;
	public int Level = 0;
	public float NextFireTime = 0f;
	public ReactiveProperty<int> LevelProperty = new ReactiveProperty<int>();

	public SelectGachaWeaponSkillData(int skillidx , int level)
    {
		SkillTypeIdx = skillidx;
		Level = level;
		NextFireTime = 0f;

		LevelProperty.Value = Level;

		LevelProperty.Subscribe(x => { Level = x; });

	}
}


public class InGameUnitUpgradeData
{
	public int UpgradeTypeIdx;
	public int Level;
	public IReactiveProperty<int> LevelProperty = new ReactiveProperty<int>();


	public InGameUnitUpgradeData(int upgradeidx)
    {
		UpgradeTypeIdx = upgradeidx;
		Level = 1;

		LevelProperty.Value = Level;

		LevelProperty.Subscribe(x => { Level = x; });
    }

}


public class UnitCardData : IClientData
{
	public int UnitIdx = 0;
	public int Level = 0;
	public int CardCount = 0;
	public IReactiveProperty<int> LevelProperty = new ReactiveProperty<int>();

	public UnitCardData(int unitidx , int level , int cardcount)
    {
		UnitIdx = unitidx;
		Level = level;
		CardCount = cardcount;

		LevelProperty.Value = Level;

		LevelProperty.Subscribe(x => { Level = x; });
	}
 
}


public class PassiveSkillData : IClientData
{
	public int UnitIdx = 0;

	public int SkillIdx = 0;

	public int SkillValue = 0;
		
	public PassiveSkillData(int skillidx , int skillvalue ,  int unitidx)
    {
		SkillIdx = skillidx;
		SkillValue = skillvalue;
		UnitIdx = unitidx;
    }

}

public class InGameUpgradeData : IClientData
{
	public int Level = 0;
	public int UpgradeIdx = 0;

	public IReactiveProperty<int> LevelProperty = new ReactiveProperty<int>();

	public InGameUpgradeData(int level , int upgradeidx)
    {
		Level = level;
		UpgradeIdx = upgradeidx;
		LevelProperty.Value = level;

		LevelProperty.Subscribe(x => { Level = x; });
    }
}

public class LabUpgradeData : IClientData
{
	public int UpgradeIdx;
	public int Level;

	public LabUpgradeData(int upgradeidx, int level)
	{
		UpgradeIdx = upgradeidx;
		Level = level;
	}
}

public class SkillCardData : IClientData
{
	public int SkillIdx = 0;
	public int Level = 0;

	public IReactiveProperty<int> LevelProperty = new ReactiveProperty<int>();

	public SkillCardData(int skillidx , int level)
    {
		SkillIdx = skillidx;
		Level = level;
		LevelProperty.Value = Level;
		LevelProperty.Subscribe(x => { Level = x; });
    }
}


public class PlanetData
{
	public float Hp;

	public float StartHp;

	public float HpRegen;

	public IReactiveProperty<float> HpProperty = new ReactiveProperty<float>();

	public PlanetData()
    {
		HpProperty.Value = Hp;
		HpProperty.Subscribe(x => { Hp = x; });
    }

}


public class WeaponUpgrade
{
	public int UpgradeIdx = 0;

	public int Level = 0;

	public ReactiveProperty<int> LevelProperty = new ReactiveProperty<int>();




	public WeaponUpgrade(int upgradeidx , int level)
    {
		UpgradeIdx = upgradeidx;
		Level = level;
		LevelProperty.Value = level;
		LevelProperty.Subscribe(x => { Level = x; });
	}
}




