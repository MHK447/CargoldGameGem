using System.Collections;
using System;
using System.Numerics;
using System.Collections.Generic;
using UniRx;

public interface IUserDataMode
{
	// Config.Language Language {get; set;}= Config.Language.en;
	IReactiveProperty<BigInteger> Money { get; set; }
	IReactiveProperty<BigInteger> UpgradeCoin { get; set; }
	DateTime LastLoginTime { get; set; }
	DateTime CurPlayDateTime { get; set; }
	public PlayerData PlayerData { get; set; }
	public StageData StageData { get; set; }
	public EventData EventData { get; set; }
	List<LabUpgradeData> LABBuffList { get; set; }
	public PlanetData PlanetData { get; set; }
	List<InGameUpgradeData> InGameUpgradeDataList { get; set; }
	IReactiveProperty<BigInteger> EnergyMoney { get; set; }
	IReactiveProperty<int> GachaCoin { get; set; }
	public List<UnitCardData> UnitCardDatas { get; set; }
	public List<InGameUnitUpgradeData> UnitUpgradeDatas { get; set; }
	public List<PassiveSkillData> PassiveSkillDatas { get; set; }
	public IReactiveCollection<SkillCardData> SkillCardDatas { get; set; }
	public IReactiveCollection<OutGameUnitUpgradeData> OutGameUnitUpgradeDatas { get; set; }
	public IReactiveCollection<SelectGachaWeaponSkillData> SelectGachaWeaponSkillDatas { get; set; }
	public IReactiveCollection<WeaponData> WeaponDatas { get; set; }
}

public class UserDataMain : IUserDataMode
{
	public IReactiveProperty<BigInteger> Money { get; set; } = new ReactiveProperty<BigInteger>(0);
	public DateTime LastLoginTime { get; set; } = default(DateTime);
	public DateTime CurPlayDateTime { get; set; } = new DateTime(1, 1, 1);
	public StageData StageData { get; set; } = new StageData();
	public EventData EventData { get; set; } = new EventData();
	public PlayerData PlayerData { get; set; } = new PlayerData();
	public List<LabUpgradeData> LABBuffList { get; set; } = new List<LabUpgradeData>();
	public PlanetData PlanetData { get; set; } = new PlanetData();
	public List<InGameUpgradeData> InGameUpgradeDataList { get; set; } = new List<InGameUpgradeData>();
	public IReactiveProperty<BigInteger> EnergyMoney { get; set; } = new ReactiveProperty<BigInteger>(0);
	public IReactiveProperty<int> GachaCoin { get; set; } = new ReactiveProperty<int>(0);
	public IReactiveProperty<BigInteger> UpgradeCoin { get; set; } = new ReactiveProperty<BigInteger>(0);
	public List<UnitCardData> UnitCardDatas { get; set; } = new List<UnitCardData>();
	public List<InGameUnitUpgradeData> UnitUpgradeDatas { get; set; } = new List<InGameUnitUpgradeData>();

	public IReactiveCollection<WeaponData> WeaponDatas { get; set; } = new ReactiveCollection<WeaponData>();

	public List<PassiveSkillData> PassiveSkillDatas { get; set; } = new List<PassiveSkillData>();
	public IReactiveCollection<SkillCardData> SkillCardDatas { get; set; } = new ReactiveCollection<SkillCardData>();
	public IReactiveCollection<OutGameUnitUpgradeData> OutGameUnitUpgradeDatas { get; set; } = new ReactiveCollection<OutGameUnitUpgradeData>();
	public IReactiveCollection<SelectGachaWeaponSkillData> SelectGachaWeaponSkillDatas { get; set; } = new ReactiveCollection<SelectGachaWeaponSkillData>();

}

public class UserDataEvent : UserDataMain
{
}