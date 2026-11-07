using System;
using System.Collections.Generic;
using C2TPro;

public class WeaponTable
{
	public class Row
	{
		public string Name;

		public int WeaponType;

		public string StringName;

		public string AttackType;

		public string SpecialAttackType;

		public string InfoType;

		public int AttackInterval;

		public float AccuracyDivisor;

		public float AccuracyOffset;

		public int MaxClip;

		public int MaxCarryClip;

		public int MaxClip2;

		public int MaxCarryClip2;

		public string SceneWeaponName;

		public float MaxInaccuracy;

		public float DefaultAccuracy;

		public float SpreadScaleY;

		public int SlashSlashTime;

		public int SlashStabTime;

		public int StabSlashTime;

		public int StabStabTime;

		public int DelayAttackSlashTime;

		public int DelayAttackSlashTime2;

		public int DelayAttackStabTime;

		public bool IsMelee;

		public int ClipCount;

		public string CrossType;

		public string ReloadType;

		public string Attach;

		public int FireBullets;

		public int ClipPerShot;

		public bool IsGold;

		public string RifleScopeParams;

		public string ThirdAnimationType;

		public string SpecialThirdAnimationType;

		public string AnimationWeaponName;

		public string EventType;

		public bool HideViewHand;

		public bool HideThirdHand;

		public bool HasKnifeEffect;

		public bool HasDoubleAttack;

		public bool HasOtherFire;

		public string MaxSpeedType;

		public string MaxSpeedParam;

		public string KickbackType;

		public string KickbackParam;

		public string SpreadType;

		public string SpreadParam;

		public string ShotDistType;

		public string ShotDistParam;

		public string AccuracyType;

		public string AccuracyParam;

		public string HoleType;

		public string HoleParam;

		public string RailType;

		public string RailParam;

		public string UiModels;

		public string RaiseType;

		public string ViewEffectModels;

		public string ThirdEffectModels;

		public string ChangeWeapon;

		public string LegsThirdAnimationType;

		public string CdTime;

		public string CdTimePara;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public void Load(string csv)
	{
		rowList.Clear();
		string[][] array = CsvParser.Parse(csv);
		for (int i = 1; i < array.Length; i++)
		{
			Row row = new Row();
			row.Name = array[i][0];
			row.WeaponType = ((!string.IsNullOrEmpty(array[i][1])) ? Convert.ToInt32(array[i][1]) : 0);
			row.StringName = array[i][2];
			row.AttackType = array[i][3];
			row.SpecialAttackType = array[i][4];
			row.InfoType = array[i][5];
			row.AttackInterval = ((!string.IsNullOrEmpty(array[i][6])) ? Convert.ToInt32(array[i][6]) : 0);
			row.AccuracyDivisor = (string.IsNullOrEmpty(array[i][7]) ? 0f : Convert.ToSingle(array[i][7]));
			row.AccuracyOffset = (string.IsNullOrEmpty(array[i][8]) ? 0f : Convert.ToSingle(array[i][8]));
			row.MaxClip = ((!string.IsNullOrEmpty(array[i][9])) ? Convert.ToInt32(array[i][9]) : 0);
			row.MaxCarryClip = ((!string.IsNullOrEmpty(array[i][10])) ? Convert.ToInt32(array[i][10]) : 0);
			row.MaxClip2 = ((!string.IsNullOrEmpty(array[i][11])) ? Convert.ToInt32(array[i][11]) : 0);
			row.MaxCarryClip2 = ((!string.IsNullOrEmpty(array[i][12])) ? Convert.ToInt32(array[i][12]) : 0);
			row.SceneWeaponName = array[i][13];
			row.MaxInaccuracy = (string.IsNullOrEmpty(array[i][14]) ? 0f : Convert.ToSingle(array[i][14]));
			row.DefaultAccuracy = (string.IsNullOrEmpty(array[i][15]) ? 0f : Convert.ToSingle(array[i][15]));
			row.SpreadScaleY = (string.IsNullOrEmpty(array[i][16]) ? 0f : Convert.ToSingle(array[i][16]));
			row.SlashSlashTime = ((!string.IsNullOrEmpty(array[i][17])) ? Convert.ToInt32(array[i][17]) : 0);
			row.SlashStabTime = ((!string.IsNullOrEmpty(array[i][18])) ? Convert.ToInt32(array[i][18]) : 0);
			row.StabSlashTime = ((!string.IsNullOrEmpty(array[i][19])) ? Convert.ToInt32(array[i][19]) : 0);
			row.StabStabTime = ((!string.IsNullOrEmpty(array[i][20])) ? Convert.ToInt32(array[i][20]) : 0);
			row.DelayAttackSlashTime = ((!string.IsNullOrEmpty(array[i][21])) ? Convert.ToInt32(array[i][21]) : 0);
			row.DelayAttackSlashTime2 = ((!string.IsNullOrEmpty(array[i][22])) ? Convert.ToInt32(array[i][22]) : 0);
			row.DelayAttackStabTime = ((!string.IsNullOrEmpty(array[i][23])) ? Convert.ToInt32(array[i][23]) : 0);
			row.IsMelee = !string.IsNullOrEmpty(array[i][24]) && Convert.ToBoolean(array[i][24]);
			row.ClipCount = ((!string.IsNullOrEmpty(array[i][25])) ? Convert.ToInt32(array[i][25]) : 0);
			row.CrossType = array[i][26];
			row.ReloadType = array[i][27];
			row.Attach = array[i][28];
			row.FireBullets = ((!string.IsNullOrEmpty(array[i][29])) ? Convert.ToInt32(array[i][29]) : 0);
			row.ClipPerShot = ((!string.IsNullOrEmpty(array[i][30])) ? Convert.ToInt32(array[i][30]) : 0);
			row.IsGold = !string.IsNullOrEmpty(array[i][31]) && Convert.ToBoolean(array[i][31]);
			row.RifleScopeParams = array[i][32];
			row.ThirdAnimationType = array[i][33];
			row.SpecialThirdAnimationType = array[i][34];
			row.AnimationWeaponName = array[i][35];
			row.EventType = array[i][36];
			row.HideViewHand = !string.IsNullOrEmpty(array[i][37]) && Convert.ToBoolean(array[i][37]);
			row.HideThirdHand = !string.IsNullOrEmpty(array[i][38]) && Convert.ToBoolean(array[i][38]);
			row.HasKnifeEffect = !string.IsNullOrEmpty(array[i][39]) && Convert.ToBoolean(array[i][39]);
			row.HasDoubleAttack = !string.IsNullOrEmpty(array[i][40]) && Convert.ToBoolean(array[i][40]);
			row.HasOtherFire = !string.IsNullOrEmpty(array[i][41]) && Convert.ToBoolean(array[i][41]);
			row.MaxSpeedType = array[i][42];
			row.MaxSpeedParam = array[i][43];
			row.KickbackType = array[i][44];
			row.KickbackParam = array[i][45];
			row.SpreadType = array[i][46];
			row.SpreadParam = array[i][47];
			row.ShotDistType = array[i][48];
			row.ShotDistParam = array[i][49];
			row.AccuracyType = array[i][50];
			row.AccuracyParam = array[i][51];
			row.HoleType = array[i][52];
			row.HoleParam = array[i][53];
			row.RailType = array[i][54];
			row.RailParam = array[i][55];
			row.UiModels = array[i][56];
			row.RaiseType = array[i][57];
			row.ViewEffectModels = array[i][58];
			row.ThirdEffectModels = array[i][59];
			row.ChangeWeapon = array[i][60];
			row.LegsThirdAnimationType = array[i][61];
			row.CdTime = array[i][62];
			row.CdTimePara = array[i][63];
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if (rowList.Count <= i)
		{
			return null;
		}
		return rowList[i];
	}

	public Row Find_Name(string find)
	{
		return rowList.Find((Row x) => x.Name == find);
	}

	public List<Row> FindAll_Name(string find)
	{
		return rowList.FindAll((Row x) => x.Name == find);
	}

	public Row Find_WeaponType(int find)
	{
		return rowList.Find((Row x) => x.WeaponType == find);
	}

	public List<Row> FindAll_WeaponType(int find)
	{
		return rowList.FindAll((Row x) => x.WeaponType == find);
	}

	public Row Find_StringName(string find)
	{
		return rowList.Find((Row x) => x.StringName == find);
	}

	public List<Row> FindAll_StringName(string find)
	{
		return rowList.FindAll((Row x) => x.StringName == find);
	}

	public Row Find_AttackType(string find)
	{
		return rowList.Find((Row x) => x.AttackType == find);
	}

	public List<Row> FindAll_AttackType(string find)
	{
		return rowList.FindAll((Row x) => x.AttackType == find);
	}

	public Row Find_SpecialAttackType(string find)
	{
		return rowList.Find((Row x) => x.SpecialAttackType == find);
	}

	public List<Row> FindAll_SpecialAttackType(string find)
	{
		return rowList.FindAll((Row x) => x.SpecialAttackType == find);
	}

	public Row Find_InfoType(string find)
	{
		return rowList.Find((Row x) => x.InfoType == find);
	}

	public List<Row> FindAll_InfoType(string find)
	{
		return rowList.FindAll((Row x) => x.InfoType == find);
	}

	public Row Find_AttackInterval(int find)
	{
		return rowList.Find((Row x) => x.AttackInterval == find);
	}

	public List<Row> FindAll_AttackInterval(int find)
	{
		return rowList.FindAll((Row x) => x.AttackInterval == find);
	}

	public Row Find_AccuracyDivisor(float find)
	{
		return rowList.Find((Row x) => x.AccuracyDivisor == find);
	}

	public List<Row> FindAll_AccuracyDivisor(float find)
	{
		return rowList.FindAll((Row x) => x.AccuracyDivisor == find);
	}

	public Row Find_AccuracyOffset(float find)
	{
		return rowList.Find((Row x) => x.AccuracyOffset == find);
	}

	public List<Row> FindAll_AccuracyOffset(float find)
	{
		return rowList.FindAll((Row x) => x.AccuracyOffset == find);
	}

	public Row Find_MaxClip(int find)
	{
		return rowList.Find((Row x) => x.MaxClip == find);
	}

	public List<Row> FindAll_MaxClip(int find)
	{
		return rowList.FindAll((Row x) => x.MaxClip == find);
	}

	public Row Find_MaxCarryClip(int find)
	{
		return rowList.Find((Row x) => x.MaxCarryClip == find);
	}

	public List<Row> FindAll_MaxCarryClip(int find)
	{
		return rowList.FindAll((Row x) => x.MaxCarryClip == find);
	}

	public Row Find_MaxClip2(int find)
	{
		return rowList.Find((Row x) => x.MaxClip2 == find);
	}

	public List<Row> FindAll_MaxClip2(int find)
	{
		return rowList.FindAll((Row x) => x.MaxClip2 == find);
	}

	public Row Find_MaxCarryClip2(int find)
	{
		return rowList.Find((Row x) => x.MaxCarryClip2 == find);
	}

	public List<Row> FindAll_MaxCarryClip2(int find)
	{
		return rowList.FindAll((Row x) => x.MaxCarryClip2 == find);
	}

	public Row Find_SceneWeaponName(string find)
	{
		return rowList.Find((Row x) => x.SceneWeaponName == find);
	}

	public List<Row> FindAll_SceneWeaponName(string find)
	{
		return rowList.FindAll((Row x) => x.SceneWeaponName == find);
	}

	public Row Find_MaxInaccuracy(float find)
	{
		return rowList.Find((Row x) => x.MaxInaccuracy == find);
	}

	public List<Row> FindAll_MaxInaccuracy(float find)
	{
		return rowList.FindAll((Row x) => x.MaxInaccuracy == find);
	}

	public Row Find_DefaultAccuracy(float find)
	{
		return rowList.Find((Row x) => x.DefaultAccuracy == find);
	}

	public List<Row> FindAll_DefaultAccuracy(float find)
	{
		return rowList.FindAll((Row x) => x.DefaultAccuracy == find);
	}

	public Row Find_SpreadScaleY(float find)
	{
		return rowList.Find((Row x) => x.SpreadScaleY == find);
	}

	public List<Row> FindAll_SpreadScaleY(float find)
	{
		return rowList.FindAll((Row x) => x.SpreadScaleY == find);
	}

	public Row Find_SlashSlashTime(int find)
	{
		return rowList.Find((Row x) => x.SlashSlashTime == find);
	}

	public List<Row> FindAll_SlashSlashTime(int find)
	{
		return rowList.FindAll((Row x) => x.SlashSlashTime == find);
	}

	public Row Find_SlashStabTime(int find)
	{
		return rowList.Find((Row x) => x.SlashStabTime == find);
	}

	public List<Row> FindAll_SlashStabTime(int find)
	{
		return rowList.FindAll((Row x) => x.SlashStabTime == find);
	}

	public Row Find_StabSlashTime(int find)
	{
		return rowList.Find((Row x) => x.StabSlashTime == find);
	}

	public List<Row> FindAll_StabSlashTime(int find)
	{
		return rowList.FindAll((Row x) => x.StabSlashTime == find);
	}

	public Row Find_StabStabTime(int find)
	{
		return rowList.Find((Row x) => x.StabStabTime == find);
	}

	public List<Row> FindAll_StabStabTime(int find)
	{
		return rowList.FindAll((Row x) => x.StabStabTime == find);
	}

	public Row Find_DelayAttackSlashTime(int find)
	{
		return rowList.Find((Row x) => x.DelayAttackSlashTime == find);
	}

	public List<Row> FindAll_DelayAttackSlashTime(int find)
	{
		return rowList.FindAll((Row x) => x.DelayAttackSlashTime == find);
	}

	public Row Find_DelayAttackSlashTime2(int find)
	{
		return rowList.Find((Row x) => x.DelayAttackSlashTime2 == find);
	}

	public List<Row> FindAll_DelayAttackSlashTime2(int find)
	{
		return rowList.FindAll((Row x) => x.DelayAttackSlashTime2 == find);
	}

	public Row Find_DelayAttackStabTime(int find)
	{
		return rowList.Find((Row x) => x.DelayAttackStabTime == find);
	}

	public List<Row> FindAll_DelayAttackStabTime(int find)
	{
		return rowList.FindAll((Row x) => x.DelayAttackStabTime == find);
	}

	public Row Find_IsMelee(bool find)
	{
		return rowList.Find((Row x) => x.IsMelee == find);
	}

	public List<Row> FindAll_IsMelee(bool find)
	{
		return rowList.FindAll((Row x) => x.IsMelee == find);
	}

	public Row Find_ClipCount(int find)
	{
		return rowList.Find((Row x) => x.ClipCount == find);
	}

	public List<Row> FindAll_ClipCount(int find)
	{
		return rowList.FindAll((Row x) => x.ClipCount == find);
	}

	public Row Find_CrossType(string find)
	{
		return rowList.Find((Row x) => x.CrossType == find);
	}

	public List<Row> FindAll_CrossType(string find)
	{
		return rowList.FindAll((Row x) => x.CrossType == find);
	}

	public Row Find_ReloadType(string find)
	{
		return rowList.Find((Row x) => x.ReloadType == find);
	}

	public List<Row> FindAll_ReloadType(string find)
	{
		return rowList.FindAll((Row x) => x.ReloadType == find);
	}

	public Row Find_Attach(string find)
	{
		return rowList.Find((Row x) => x.Attach == find);
	}

	public List<Row> FindAll_Attach(string find)
	{
		return rowList.FindAll((Row x) => x.Attach == find);
	}

	public Row Find_FireBullets(int find)
	{
		return rowList.Find((Row x) => x.FireBullets == find);
	}

	public List<Row> FindAll_FireBullets(int find)
	{
		return rowList.FindAll((Row x) => x.FireBullets == find);
	}

	public Row Find_ClipPerShot(int find)
	{
		return rowList.Find((Row x) => x.ClipPerShot == find);
	}

	public List<Row> FindAll_ClipPerShot(int find)
	{
		return rowList.FindAll((Row x) => x.ClipPerShot == find);
	}

	public Row Find_IsGold(bool find)
	{
		return rowList.Find((Row x) => x.IsGold == find);
	}

	public List<Row> FindAll_IsGold(bool find)
	{
		return rowList.FindAll((Row x) => x.IsGold == find);
	}

	public Row Find_RifleScopeParams(string find)
	{
		return rowList.Find((Row x) => x.RifleScopeParams == find);
	}

	public List<Row> FindAll_RifleScopeParams(string find)
	{
		return rowList.FindAll((Row x) => x.RifleScopeParams == find);
	}

	public Row Find_ThirdAnimationType(string find)
	{
		return rowList.Find((Row x) => x.ThirdAnimationType == find);
	}

	public List<Row> FindAll_ThirdAnimationType(string find)
	{
		return rowList.FindAll((Row x) => x.ThirdAnimationType == find);
	}

	public Row Find_SpecialThirdAnimationType(string find)
	{
		return rowList.Find((Row x) => x.SpecialThirdAnimationType == find);
	}

	public List<Row> FindAll_SpecialThirdAnimationType(string find)
	{
		return rowList.FindAll((Row x) => x.SpecialThirdAnimationType == find);
	}

	public Row Find_AnimationWeaponName(string find)
	{
		return rowList.Find((Row x) => x.AnimationWeaponName == find);
	}

	public List<Row> FindAll_AnimationWeaponName(string find)
	{
		return rowList.FindAll((Row x) => x.AnimationWeaponName == find);
	}

	public Row Find_EventType(string find)
	{
		return rowList.Find((Row x) => x.EventType == find);
	}

	public List<Row> FindAll_EventType(string find)
	{
		return rowList.FindAll((Row x) => x.EventType == find);
	}

	public Row Find_HideViewHand(bool find)
	{
		return rowList.Find((Row x) => x.HideViewHand == find);
	}

	public List<Row> FindAll_HideViewHand(bool find)
	{
		return rowList.FindAll((Row x) => x.HideViewHand == find);
	}

	public Row Find_HideThirdHand(bool find)
	{
		return rowList.Find((Row x) => x.HideThirdHand == find);
	}

	public List<Row> FindAll_HideThirdHand(bool find)
	{
		return rowList.FindAll((Row x) => x.HideThirdHand == find);
	}

	public Row Find_HasKnifeEffect(bool find)
	{
		return rowList.Find((Row x) => x.HasKnifeEffect == find);
	}

	public List<Row> FindAll_HasKnifeEffect(bool find)
	{
		return rowList.FindAll((Row x) => x.HasKnifeEffect == find);
	}

	public Row Find_HasDoubleAttack(bool find)
	{
		return rowList.Find((Row x) => x.HasDoubleAttack == find);
	}

	public List<Row> FindAll_HasDoubleAttack(bool find)
	{
		return rowList.FindAll((Row x) => x.HasDoubleAttack == find);
	}

	public Row Find_HasOtherFire(bool find)
	{
		return rowList.Find((Row x) => x.HasOtherFire == find);
	}

	public List<Row> FindAll_HasOtherFire(bool find)
	{
		return rowList.FindAll((Row x) => x.HasOtherFire == find);
	}

	public Row Find_MaxSpeedType(string find)
	{
		return rowList.Find((Row x) => x.MaxSpeedType == find);
	}

	public List<Row> FindAll_MaxSpeedType(string find)
	{
		return rowList.FindAll((Row x) => x.MaxSpeedType == find);
	}

	public Row Find_MaxSpeedParam(string find)
	{
		return rowList.Find((Row x) => x.MaxSpeedParam == find);
	}

	public List<Row> FindAll_MaxSpeedParam(string find)
	{
		return rowList.FindAll((Row x) => x.MaxSpeedParam == find);
	}

	public Row Find_KickbackType(string find)
	{
		return rowList.Find((Row x) => x.KickbackType == find);
	}

	public List<Row> FindAll_KickbackType(string find)
	{
		return rowList.FindAll((Row x) => x.KickbackType == find);
	}

	public Row Find_KickbackParam(string find)
	{
		return rowList.Find((Row x) => x.KickbackParam == find);
	}

	public List<Row> FindAll_KickbackParam(string find)
	{
		return rowList.FindAll((Row x) => x.KickbackParam == find);
	}

	public Row Find_SpreadType(string find)
	{
		return rowList.Find((Row x) => x.SpreadType == find);
	}

	public List<Row> FindAll_SpreadType(string find)
	{
		return rowList.FindAll((Row x) => x.SpreadType == find);
	}

	public Row Find_SpreadParam(string find)
	{
		return rowList.Find((Row x) => x.SpreadParam == find);
	}

	public List<Row> FindAll_SpreadParam(string find)
	{
		return rowList.FindAll((Row x) => x.SpreadParam == find);
	}

	public Row Find_ShotDistType(string find)
	{
		return rowList.Find((Row x) => x.ShotDistType == find);
	}

	public List<Row> FindAll_ShotDistType(string find)
	{
		return rowList.FindAll((Row x) => x.ShotDistType == find);
	}

	public Row Find_ShotDistParam(string find)
	{
		return rowList.Find((Row x) => x.ShotDistParam == find);
	}

	public List<Row> FindAll_ShotDistParam(string find)
	{
		return rowList.FindAll((Row x) => x.ShotDistParam == find);
	}

	public Row Find_AccuracyType(string find)
	{
		return rowList.Find((Row x) => x.AccuracyType == find);
	}

	public List<Row> FindAll_AccuracyType(string find)
	{
		return rowList.FindAll((Row x) => x.AccuracyType == find);
	}

	public Row Find_AccuracyParam(string find)
	{
		return rowList.Find((Row x) => x.AccuracyParam == find);
	}

	public List<Row> FindAll_AccuracyParam(string find)
	{
		return rowList.FindAll((Row x) => x.AccuracyParam == find);
	}

	public Row Find_HoleType(string find)
	{
		return rowList.Find((Row x) => x.HoleType == find);
	}

	public List<Row> FindAll_HoleType(string find)
	{
		return rowList.FindAll((Row x) => x.HoleType == find);
	}

	public Row Find_HoleParam(string find)
	{
		return rowList.Find((Row x) => x.HoleParam == find);
	}

	public List<Row> FindAll_HoleParam(string find)
	{
		return rowList.FindAll((Row x) => x.HoleParam == find);
	}

	public Row Find_RailType(string find)
	{
		return rowList.Find((Row x) => x.RailType == find);
	}

	public List<Row> FindAll_RailType(string find)
	{
		return rowList.FindAll((Row x) => x.RailType == find);
	}

	public Row Find_RailParam(string find)
	{
		return rowList.Find((Row x) => x.RailParam == find);
	}

	public List<Row> FindAll_RailParam(string find)
	{
		return rowList.FindAll((Row x) => x.RailParam == find);
	}

	public Row Find_UiModels(string find)
	{
		return rowList.Find((Row x) => x.UiModels == find);
	}

	public List<Row> FindAll_UiModels(string find)
	{
		return rowList.FindAll((Row x) => x.UiModels == find);
	}

	public Row Find_RaiseType(string find)
	{
		return rowList.Find((Row x) => x.RaiseType == find);
	}

	public List<Row> FindAll_RaiseType(string find)
	{
		return rowList.FindAll((Row x) => x.RaiseType == find);
	}

	public Row Find_ViewEffectModels(string find)
	{
		return rowList.Find((Row x) => x.ViewEffectModels == find);
	}

	public List<Row> FindAll_ViewEffectModels(string find)
	{
		return rowList.FindAll((Row x) => x.ViewEffectModels == find);
	}

	public Row Find_ThirdEffectModels(string find)
	{
		return rowList.Find((Row x) => x.ThirdEffectModels == find);
	}

	public List<Row> FindAll_ThirdEffectModels(string find)
	{
		return rowList.FindAll((Row x) => x.ThirdEffectModels == find);
	}

	public Row Find_ChangeWeapon(string find)
	{
		return rowList.Find((Row x) => x.ChangeWeapon == find);
	}

	public List<Row> FindAll_ChangeWeapon(string find)
	{
		return rowList.FindAll((Row x) => x.ChangeWeapon == find);
	}

	public Row Find_LegsThirdAnimationType(string find)
	{
		return rowList.Find((Row x) => x.LegsThirdAnimationType == find);
	}

	public List<Row> FindAll_LegsThirdAnimationType(string find)
	{
		return rowList.FindAll((Row x) => x.LegsThirdAnimationType == find);
	}

	public Row Find_CdTime(string find)
	{
		return rowList.Find((Row x) => x.CdTime == find);
	}

	public List<Row> FindAll_CdTime(string find)
	{
		return rowList.FindAll((Row x) => x.CdTime == find);
	}

	public Row Find_CdTimePara(string find)
	{
		return rowList.Find((Row x) => x.CdTimePara == find);
	}

	public List<Row> FindAll_CdTimePara(string find)
	{
		return rowList.FindAll((Row x) => x.CdTimePara == find);
	}
}
