using System;
using System.Collections.Generic;
using System.Reflection;
using C2TPro;
using CommonUtils;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Generated.Table;

public class WeaponSkillTable
{
	public enum CanUseType
	{
		Normal,
		Percent,
		PowerUnit,
		Special,
		EffectLevel,
		MaxPower2,
		RifleOPticor,
		Clip2Special,
		PercentGt,
		CdAndPercent,
		Clip2,
		SpecialMode,
		RpgMaxPower,
		SniperGuard,
		HormoneInjection,
		AllAwalys,
		Power,
		MirageDouBladeHero,
		MirageDouBlade,
		LightEdgeGrenade,
		EndlessMachinegun,
		M99Barrett
	}

	public enum ProgressType
	{
		Power,
		Power2,
		SkillPower,
		Mp,
		Special,
		ClipPower,
		WeaponPower,
		EffectLevel,
		TdSkillPower,
		WeaponLevel,
		Cd,
		PowerLevel,
		Kill,
		Power2IsZero,
		InfiniteSkillPower,
		RifleOPticor,
		SkillPower1,
		EffectLevelCd,
		UniqueCd,
		SkillPower2,
		SkillMaxPower,
		VoidLink,
		SniperGuard,
		ThunderScepter,
		PowerMaxPower,
		HormoneInjection,
		MirageDouBladeHero,
		MirageDouBlade,
		MpWeaponPower,
		Type91Dagger,
		EndlessMachinegun,
		M4A1Hero
	}

	public enum ModeType
	{
		AllMode,
		IsGeneralPve,
		IsBioMode,
		IsPveMode,
		IsMechMode,
		IsTd,
		Kriss,
		Kriss1,
		Mp5Wr,
		Qbz95Hero,
		Rage,
		SanDanHero,
		M4A1Hero,
		IsPvpMode,
		IsTat,
		IsBighead,
		IsOldPve,
		IsGroup,
		IsRpgPvp,
		IsRpgPve,
		Deformation,
		None,
		AwmStrike,
		SwordHeavenJudge,
		SpecialMode,
		ArcElectricShotgun,
		VoidSpear,
		IsTeamRace,
		BreakShotgunPistol,
		VoidLink,
		SniperGuard,
		ThunderScepter,
		MirageDouBladeHero,
		MirageDouBlade,
		Pickaxe,
		DataCube,
		EndlessMachinegun,
		LightEdgeGrenade
	}

	public enum EffectType
	{
		None,
		Alpha,
		Frame,
		Scale,
		Rotation
	}

	public enum FillOriginType
	{
		Bottom,
		Right,
		Top,
		Left
	}

	public enum SpecialType
	{
		None,
		Skill1,
		RifleOPticor,
		Clip2Special,
		MirageDouBlade,
		Type91Dagger
	}

	public enum CdType
	{
		Normal,
		RifleOpticor,
		None
	}

	public enum ProgressVisiableType
	{
		Normal,
		MirageDouBladeHero,
		LightEdgeGrenade
	}

	public class Row
	{
		public int Id;

		public string Name;

		public string Progress;

		public int ProgressCount;

		public int ProgressSpace;

		public string[] Back;

		public SpecialType SpecialType;

		public string[] SpecialBack;

		public string[] Icon;

		public string[] SpecialIcon;

		public string DisabledIcon;

		public EffectType Effect;

		public string FrameName;

		public int FrameStart;

		public int FrameCount;

		public float Total;

		public Image.FillMethod FillMethod;

		public FillOriginType FillOrigin;

		public float FillAmount;

		public bool FillClockwise;

		public Vector3 ProgressPos;

		public Vector3 IconPos;

		public Vector3 EffectPos;

		public Quaternion ProgressRot;

		public bool HideBackWhenActive;

		public ModeType Mode;

		public ProgressType Type;

		public int MaxLevel;

		public int SpecialTime;

		public CanUseType CanUse;

		public float CanUseValue;

		public CdType Cd;

		public ProgressVisiableType ProgressVisiable;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cacheName = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllName = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheProgress = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllProgress = new Dictionary<string, List<Row>>();

	private readonly Dictionary<int, Row> _cacheProgressCount = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllProgressCount = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheProgressSpace = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllProgressSpace = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string[], Row> _cacheBack = new Dictionary<string[], Row>();

	private readonly Dictionary<string[], List<Row>> _cacheAllBack = new Dictionary<string[], List<Row>>();

	private readonly Dictionary<SpecialType, Row> _cacheSpecialType = new Dictionary<SpecialType, Row>();

	private readonly Dictionary<SpecialType, List<Row>> _cacheAllSpecialType = new Dictionary<SpecialType, List<Row>>();

	private readonly Dictionary<string[], Row> _cacheSpecialBack = new Dictionary<string[], Row>();

	private readonly Dictionary<string[], List<Row>> _cacheAllSpecialBack = new Dictionary<string[], List<Row>>();

	private readonly Dictionary<string[], Row> _cacheIcon = new Dictionary<string[], Row>();

	private readonly Dictionary<string[], List<Row>> _cacheAllIcon = new Dictionary<string[], List<Row>>();

	private readonly Dictionary<string[], Row> _cacheSpecialIcon = new Dictionary<string[], Row>();

	private readonly Dictionary<string[], List<Row>> _cacheAllSpecialIcon = new Dictionary<string[], List<Row>>();

	private readonly Dictionary<string, Row> _cacheDisabledIcon = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllDisabledIcon = new Dictionary<string, List<Row>>();

	private readonly Dictionary<EffectType, Row> _cacheEffect = new Dictionary<EffectType, Row>();

	private readonly Dictionary<EffectType, List<Row>> _cacheAllEffect = new Dictionary<EffectType, List<Row>>();

	private readonly Dictionary<string, Row> _cacheFrameName = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllFrameName = new Dictionary<string, List<Row>>();

	private readonly Dictionary<int, Row> _cacheFrameStart = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllFrameStart = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheFrameCount = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllFrameCount = new Dictionary<int, List<Row>>();

	private readonly Dictionary<float, Row> _cacheTotal = new Dictionary<float, Row>();

	private readonly Dictionary<float, List<Row>> _cacheAllTotal = new Dictionary<float, List<Row>>();

	private readonly Dictionary<Image.FillMethod, Row> _cacheFillMethod = new Dictionary<Image.FillMethod, Row>();

	private readonly Dictionary<Image.FillMethod, List<Row>> _cacheAllFillMethod = new Dictionary<Image.FillMethod, List<Row>>();

	private readonly Dictionary<FillOriginType, Row> _cacheFillOrigin = new Dictionary<FillOriginType, Row>();

	private readonly Dictionary<FillOriginType, List<Row>> _cacheAllFillOrigin = new Dictionary<FillOriginType, List<Row>>();

	private readonly Dictionary<float, Row> _cacheFillAmount = new Dictionary<float, Row>();

	private readonly Dictionary<float, List<Row>> _cacheAllFillAmount = new Dictionary<float, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheFillClockwise = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllFillClockwise = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<Vector3, Row> _cacheProgressPos = new Dictionary<Vector3, Row>();

	private readonly Dictionary<Vector3, List<Row>> _cacheAllProgressPos = new Dictionary<Vector3, List<Row>>();

	private readonly Dictionary<Vector3, Row> _cacheIconPos = new Dictionary<Vector3, Row>();

	private readonly Dictionary<Vector3, List<Row>> _cacheAllIconPos = new Dictionary<Vector3, List<Row>>();

	private readonly Dictionary<Vector3, Row> _cacheEffectPos = new Dictionary<Vector3, Row>();

	private readonly Dictionary<Vector3, List<Row>> _cacheAllEffectPos = new Dictionary<Vector3, List<Row>>();

	private readonly Dictionary<Quaternion, Row> _cacheProgressRot = new Dictionary<Quaternion, Row>();

	private readonly Dictionary<Quaternion, List<Row>> _cacheAllProgressRot = new Dictionary<Quaternion, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheHideBackWhenActive = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllHideBackWhenActive = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<ModeType, Row> _cacheMode = new Dictionary<ModeType, Row>();

	private readonly Dictionary<ModeType, List<Row>> _cacheAllMode = new Dictionary<ModeType, List<Row>>();

	private readonly Dictionary<ProgressType, Row> _cacheType = new Dictionary<ProgressType, Row>();

	private readonly Dictionary<ProgressType, List<Row>> _cacheAllType = new Dictionary<ProgressType, List<Row>>();

	private readonly Dictionary<int, Row> _cacheMaxLevel = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllMaxLevel = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheSpecialTime = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllSpecialTime = new Dictionary<int, List<Row>>();

	private readonly Dictionary<CanUseType, Row> _cacheCanUse = new Dictionary<CanUseType, Row>();

	private readonly Dictionary<CanUseType, List<Row>> _cacheAllCanUse = new Dictionary<CanUseType, List<Row>>();

	private readonly Dictionary<float, Row> _cacheCanUseValue = new Dictionary<float, Row>();

	private readonly Dictionary<float, List<Row>> _cacheAllCanUseValue = new Dictionary<float, List<Row>>();

	private readonly Dictionary<CdType, Row> _cacheCd = new Dictionary<CdType, Row>();

	private readonly Dictionary<CdType, List<Row>> _cacheAllCd = new Dictionary<CdType, List<Row>>();

	private readonly Dictionary<ProgressVisiableType, Row> _cacheProgressVisiable = new Dictionary<ProgressVisiableType, Row>();

	private readonly Dictionary<ProgressVisiableType, List<Row>> _cacheAllProgressVisiable = new Dictionary<ProgressVisiableType, List<Row>>();

	private string GetAt(string[] arr, int i)
	{
		if (i >= arr.Length)
		{
			return null;
		}
		return arr[i];
	}

	private int ConvertInt(string str)
	{
		if (!string.IsNullOrEmpty(str))
		{
			return Convert.ToInt32(str);
		}
		return 0;
	}

	private float ConvertFloat(string str)
	{
		if (!string.IsNullOrEmpty(str))
		{
			return Convert.ToSingle(str);
		}
		return 0f;
	}

	private bool ConvertBool(string str)
	{
		if (!string.IsNullOrEmpty(str))
		{
			return Convert.ToBoolean(str);
		}
		return false;
	}

	private Vector3 ConvertVector3(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return Vector3.zero;
		}
		string[] arr = str.Split(',');
		return new Vector3(ConvertFloat(GetAt(arr, 0)), ConvertFloat(GetAt(arr, 1)), ConvertFloat(GetAt(arr, 2)));
	}

	private int[] ConvertIntArray(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return new int[0];
		}
		string[] array = str.Split(',');
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = ConvertInt(GetAt(array, i));
		}
		return array2;
	}

	private float[] ConvertFloatArray(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return new float[0];
		}
		string[] array = str.Split(',');
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = ConvertFloat(GetAt(array, i));
		}
		return array2;
	}

	private Quaternion ConvertQuaternion(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return new Quaternion(0f, 0f, 0f, 0f);
		}
		string[] arr = str.Split(',');
		return new Quaternion(ConvertFloat(GetAt(arr, 0)), ConvertFloat(GetAt(arr, 1)), ConvertFloat(GetAt(arr, 2)), ConvertFloat(GetAt(arr, 3)));
	}

	private string ConvertConstString(Type type, string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return "";
		}
		FieldInfo field = type.GetField(str);
		if (field == null)
		{
			DebugLogger.LogError(str + " property can not found in " + type.Name);
			return "";
		}
		return (string)field.GetValue(null);
	}

	private int ConvertConstInt(Type type, string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return 0;
		}
		FieldInfo field = type.GetField(str);
		if (field == null)
		{
			DebugLogger.LogError(str + " property can not found in " + type.Name);
			return 0;
		}
		object value = field.GetValue(null);
		if (value != null)
		{
			return Convert.ToInt32(value);
		}
		return 0;
	}

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
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

	public void Load(string csv)
	{
		rowList.Clear();
		string[][] array = CsvParser.Parse(csv);
		for (int i = 2; i < array.Length; i++)
		{
			Row row = new Row();
			row.Id = ConvertInt(array[i][0]);
			row.Name = array[i][1];
			row.Progress = array[i][2];
			row.ProgressCount = ConvertInt(array[i][3]);
			row.ProgressSpace = ConvertInt(array[i][4]);
			if (!string.IsNullOrEmpty(array[i][5]))
			{
				row.Back = array[i][5].Split(',');
			}
			if (!string.IsNullOrEmpty(array[i][6]))
			{
				row.SpecialType = (SpecialType)Enum.Parse(typeof(SpecialType), array[i][6]);
			}
			if (!string.IsNullOrEmpty(array[i][7]))
			{
				row.SpecialBack = array[i][7].Split(',');
			}
			if (!string.IsNullOrEmpty(array[i][8]))
			{
				row.Icon = array[i][8].Split(',');
			}
			if (!string.IsNullOrEmpty(array[i][9]))
			{
				row.SpecialIcon = array[i][9].Split(',');
			}
			row.DisabledIcon = array[i][10];
			if (!string.IsNullOrEmpty(array[i][11]))
			{
				row.Effect = (EffectType)Enum.Parse(typeof(EffectType), array[i][11]);
			}
			row.FrameName = array[i][12];
			row.FrameStart = ConvertInt(array[i][13]);
			row.FrameCount = ConvertInt(array[i][14]);
			row.Total = ConvertFloat(array[i][15]);
			if (!string.IsNullOrEmpty(array[i][16]))
			{
				row.FillMethod = (Image.FillMethod)Enum.Parse(typeof(Image.FillMethod), array[i][16]);
			}
			if (!string.IsNullOrEmpty(array[i][17]))
			{
				row.FillOrigin = (FillOriginType)Enum.Parse(typeof(FillOriginType), array[i][17]);
			}
			row.FillAmount = ConvertFloat(array[i][18]);
			row.FillClockwise = ConvertBool(array[i][19]);
			row.ProgressPos = ConvertVector3(array[i][20]);
			row.IconPos = ConvertVector3(array[i][21]);
			row.EffectPos = ConvertVector3(array[i][22]);
			row.ProgressRot = ConvertQuaternion(array[i][23]);
			row.HideBackWhenActive = ConvertBool(array[i][24]);
			if (!string.IsNullOrEmpty(array[i][25]))
			{
				row.Mode = (ModeType)Enum.Parse(typeof(ModeType), array[i][25]);
			}
			if (!string.IsNullOrEmpty(array[i][26]))
			{
				row.Type = (ProgressType)Enum.Parse(typeof(ProgressType), array[i][26]);
			}
			row.MaxLevel = ConvertInt(array[i][27]);
			row.SpecialTime = ConvertInt(array[i][28]);
			if (!string.IsNullOrEmpty(array[i][29]))
			{
				row.CanUse = (CanUseType)Enum.Parse(typeof(CanUseType), array[i][29]);
			}
			row.CanUseValue = ConvertFloat(array[i][30]);
			if (!string.IsNullOrEmpty(array[i][31]))
			{
				row.Cd = (CdType)Enum.Parse(typeof(CdType), array[i][31]);
			}
			if (!string.IsNullOrEmpty(array[i][32]))
			{
				row.ProgressVisiable = (ProgressVisiableType)Enum.Parse(typeof(ProgressVisiableType), array[i][32]);
			}
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public Row Find_Id(int find)
	{
		if (!_cacheId.TryGetValue(find, out var value))
		{
			return _cacheId[find] = rowList.Find((Row x) => x.Id == find);
		}
		return value;
	}

	public List<Row> FindAll_Id(int find)
	{
		if (!_cacheAllId.TryGetValue(find, out var value))
		{
			return _cacheAllId[find] = rowList.FindAll((Row x) => x.Id == find);
		}
		return value;
	}

	public Row Find_Name(string find)
	{
		if (!_cacheName.TryGetValue(find, out var value))
		{
			return _cacheName[find] = rowList.Find((Row x) => x.Name == find);
		}
		return value;
	}

	public List<Row> FindAll_Name(string find)
	{
		if (!_cacheAllName.TryGetValue(find, out var value))
		{
			return _cacheAllName[find] = rowList.FindAll((Row x) => x.Name == find);
		}
		return value;
	}

	public Row Find_Progress(string find)
	{
		if (!_cacheProgress.TryGetValue(find, out var value))
		{
			return _cacheProgress[find] = rowList.Find((Row x) => x.Progress == find);
		}
		return value;
	}

	public List<Row> FindAll_Progress(string find)
	{
		if (!_cacheAllProgress.TryGetValue(find, out var value))
		{
			return _cacheAllProgress[find] = rowList.FindAll((Row x) => x.Progress == find);
		}
		return value;
	}

	public Row Find_ProgressCount(int find)
	{
		if (!_cacheProgressCount.TryGetValue(find, out var value))
		{
			return _cacheProgressCount[find] = rowList.Find((Row x) => x.ProgressCount == find);
		}
		return value;
	}

	public List<Row> FindAll_ProgressCount(int find)
	{
		if (!_cacheAllProgressCount.TryGetValue(find, out var value))
		{
			return _cacheAllProgressCount[find] = rowList.FindAll((Row x) => x.ProgressCount == find);
		}
		return value;
	}

	public Row Find_ProgressSpace(int find)
	{
		if (!_cacheProgressSpace.TryGetValue(find, out var value))
		{
			return _cacheProgressSpace[find] = rowList.Find((Row x) => x.ProgressSpace == find);
		}
		return value;
	}

	public List<Row> FindAll_ProgressSpace(int find)
	{
		if (!_cacheAllProgressSpace.TryGetValue(find, out var value))
		{
			return _cacheAllProgressSpace[find] = rowList.FindAll((Row x) => x.ProgressSpace == find);
		}
		return value;
	}

	public Row Find_Back(string[] find)
	{
		if (!_cacheBack.TryGetValue(find, out var value))
		{
			return _cacheBack[find] = rowList.Find((Row x) => x.Back == find);
		}
		return value;
	}

	public List<Row> FindAll_Back(string[] find)
	{
		if (!_cacheAllBack.TryGetValue(find, out var value))
		{
			return _cacheAllBack[find] = rowList.FindAll((Row x) => x.Back == find);
		}
		return value;
	}

	public Row Find_SpecialType(SpecialType find)
	{
		if (!_cacheSpecialType.TryGetValue(find, out var value))
		{
			return _cacheSpecialType[find] = rowList.Find((Row x) => x.SpecialType == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialType(SpecialType find)
	{
		if (!_cacheAllSpecialType.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialType[find] = rowList.FindAll((Row x) => x.SpecialType == find);
		}
		return value;
	}

	public Row Find_SpecialBack(string[] find)
	{
		if (!_cacheSpecialBack.TryGetValue(find, out var value))
		{
			return _cacheSpecialBack[find] = rowList.Find((Row x) => x.SpecialBack == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialBack(string[] find)
	{
		if (!_cacheAllSpecialBack.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialBack[find] = rowList.FindAll((Row x) => x.SpecialBack == find);
		}
		return value;
	}

	public Row Find_Icon(string[] find)
	{
		if (!_cacheIcon.TryGetValue(find, out var value))
		{
			return _cacheIcon[find] = rowList.Find((Row x) => x.Icon == find);
		}
		return value;
	}

	public List<Row> FindAll_Icon(string[] find)
	{
		if (!_cacheAllIcon.TryGetValue(find, out var value))
		{
			return _cacheAllIcon[find] = rowList.FindAll((Row x) => x.Icon == find);
		}
		return value;
	}

	public Row Find_SpecialIcon(string[] find)
	{
		if (!_cacheSpecialIcon.TryGetValue(find, out var value))
		{
			return _cacheSpecialIcon[find] = rowList.Find((Row x) => x.SpecialIcon == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialIcon(string[] find)
	{
		if (!_cacheAllSpecialIcon.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialIcon[find] = rowList.FindAll((Row x) => x.SpecialIcon == find);
		}
		return value;
	}

	public Row Find_DisabledIcon(string find)
	{
		if (!_cacheDisabledIcon.TryGetValue(find, out var value))
		{
			return _cacheDisabledIcon[find] = rowList.Find((Row x) => x.DisabledIcon == find);
		}
		return value;
	}

	public List<Row> FindAll_DisabledIcon(string find)
	{
		if (!_cacheAllDisabledIcon.TryGetValue(find, out var value))
		{
			return _cacheAllDisabledIcon[find] = rowList.FindAll((Row x) => x.DisabledIcon == find);
		}
		return value;
	}

	public Row Find_Effect(EffectType find)
	{
		if (!_cacheEffect.TryGetValue(find, out var value))
		{
			return _cacheEffect[find] = rowList.Find((Row x) => x.Effect == find);
		}
		return value;
	}

	public List<Row> FindAll_Effect(EffectType find)
	{
		if (!_cacheAllEffect.TryGetValue(find, out var value))
		{
			return _cacheAllEffect[find] = rowList.FindAll((Row x) => x.Effect == find);
		}
		return value;
	}

	public Row Find_FrameName(string find)
	{
		if (!_cacheFrameName.TryGetValue(find, out var value))
		{
			return _cacheFrameName[find] = rowList.Find((Row x) => x.FrameName == find);
		}
		return value;
	}

	public List<Row> FindAll_FrameName(string find)
	{
		if (!_cacheAllFrameName.TryGetValue(find, out var value))
		{
			return _cacheAllFrameName[find] = rowList.FindAll((Row x) => x.FrameName == find);
		}
		return value;
	}

	public Row Find_FrameStart(int find)
	{
		if (!_cacheFrameStart.TryGetValue(find, out var value))
		{
			return _cacheFrameStart[find] = rowList.Find((Row x) => x.FrameStart == find);
		}
		return value;
	}

	public List<Row> FindAll_FrameStart(int find)
	{
		if (!_cacheAllFrameStart.TryGetValue(find, out var value))
		{
			return _cacheAllFrameStart[find] = rowList.FindAll((Row x) => x.FrameStart == find);
		}
		return value;
	}

	public Row Find_FrameCount(int find)
	{
		if (!_cacheFrameCount.TryGetValue(find, out var value))
		{
			return _cacheFrameCount[find] = rowList.Find((Row x) => x.FrameCount == find);
		}
		return value;
	}

	public List<Row> FindAll_FrameCount(int find)
	{
		if (!_cacheAllFrameCount.TryGetValue(find, out var value))
		{
			return _cacheAllFrameCount[find] = rowList.FindAll((Row x) => x.FrameCount == find);
		}
		return value;
	}

	public Row Find_Total(float find)
	{
		if (!_cacheTotal.TryGetValue(find, out var value))
		{
			return _cacheTotal[find] = rowList.Find((Row x) => x.Total == find);
		}
		return value;
	}

	public List<Row> FindAll_Total(float find)
	{
		if (!_cacheAllTotal.TryGetValue(find, out var value))
		{
			return _cacheAllTotal[find] = rowList.FindAll((Row x) => x.Total == find);
		}
		return value;
	}

	public Row Find_FillMethod(Image.FillMethod find)
	{
		if (!_cacheFillMethod.TryGetValue(find, out var value))
		{
			return _cacheFillMethod[find] = rowList.Find((Row x) => x.FillMethod == find);
		}
		return value;
	}

	public List<Row> FindAll_FillMethod(Image.FillMethod find)
	{
		if (!_cacheAllFillMethod.TryGetValue(find, out var value))
		{
			return _cacheAllFillMethod[find] = rowList.FindAll((Row x) => x.FillMethod == find);
		}
		return value;
	}

	public Row Find_FillOrigin(FillOriginType find)
	{
		if (!_cacheFillOrigin.TryGetValue(find, out var value))
		{
			return _cacheFillOrigin[find] = rowList.Find((Row x) => x.FillOrigin == find);
		}
		return value;
	}

	public List<Row> FindAll_FillOrigin(FillOriginType find)
	{
		if (!_cacheAllFillOrigin.TryGetValue(find, out var value))
		{
			return _cacheAllFillOrigin[find] = rowList.FindAll((Row x) => x.FillOrigin == find);
		}
		return value;
	}

	public Row Find_FillAmount(float find)
	{
		if (!_cacheFillAmount.TryGetValue(find, out var value))
		{
			return _cacheFillAmount[find] = rowList.Find((Row x) => x.FillAmount == find);
		}
		return value;
	}

	public List<Row> FindAll_FillAmount(float find)
	{
		if (!_cacheAllFillAmount.TryGetValue(find, out var value))
		{
			return _cacheAllFillAmount[find] = rowList.FindAll((Row x) => x.FillAmount == find);
		}
		return value;
	}

	public Row Find_FillClockwise(bool find)
	{
		if (!_cacheFillClockwise.TryGetValue(find, out var value))
		{
			return _cacheFillClockwise[find] = rowList.Find((Row x) => x.FillClockwise == find);
		}
		return value;
	}

	public List<Row> FindAll_FillClockwise(bool find)
	{
		if (!_cacheAllFillClockwise.TryGetValue(find, out var value))
		{
			return _cacheAllFillClockwise[find] = rowList.FindAll((Row x) => x.FillClockwise == find);
		}
		return value;
	}

	public Row Find_ProgressPos(Vector3 find)
	{
		if (!_cacheProgressPos.TryGetValue(find, out var value))
		{
			return _cacheProgressPos[find] = rowList.Find((Row x) => x.ProgressPos == find);
		}
		return value;
	}

	public List<Row> FindAll_ProgressPos(Vector3 find)
	{
		if (!_cacheAllProgressPos.TryGetValue(find, out var value))
		{
			return _cacheAllProgressPos[find] = rowList.FindAll((Row x) => x.ProgressPos == find);
		}
		return value;
	}

	public Row Find_IconPos(Vector3 find)
	{
		if (!_cacheIconPos.TryGetValue(find, out var value))
		{
			return _cacheIconPos[find] = rowList.Find((Row x) => x.IconPos == find);
		}
		return value;
	}

	public List<Row> FindAll_IconPos(Vector3 find)
	{
		if (!_cacheAllIconPos.TryGetValue(find, out var value))
		{
			return _cacheAllIconPos[find] = rowList.FindAll((Row x) => x.IconPos == find);
		}
		return value;
	}

	public Row Find_EffectPos(Vector3 find)
	{
		if (!_cacheEffectPos.TryGetValue(find, out var value))
		{
			return _cacheEffectPos[find] = rowList.Find((Row x) => x.EffectPos == find);
		}
		return value;
	}

	public List<Row> FindAll_EffectPos(Vector3 find)
	{
		if (!_cacheAllEffectPos.TryGetValue(find, out var value))
		{
			return _cacheAllEffectPos[find] = rowList.FindAll((Row x) => x.EffectPos == find);
		}
		return value;
	}

	public Row Find_ProgressRot(Quaternion find)
	{
		if (!_cacheProgressRot.TryGetValue(find, out var value))
		{
			return _cacheProgressRot[find] = rowList.Find((Row x) => x.ProgressRot == find);
		}
		return value;
	}

	public List<Row> FindAll_ProgressRot(Quaternion find)
	{
		if (!_cacheAllProgressRot.TryGetValue(find, out var value))
		{
			return _cacheAllProgressRot[find] = rowList.FindAll((Row x) => x.ProgressRot == find);
		}
		return value;
	}

	public Row Find_HideBackWhenActive(bool find)
	{
		if (!_cacheHideBackWhenActive.TryGetValue(find, out var value))
		{
			return _cacheHideBackWhenActive[find] = rowList.Find((Row x) => x.HideBackWhenActive == find);
		}
		return value;
	}

	public List<Row> FindAll_HideBackWhenActive(bool find)
	{
		if (!_cacheAllHideBackWhenActive.TryGetValue(find, out var value))
		{
			return _cacheAllHideBackWhenActive[find] = rowList.FindAll((Row x) => x.HideBackWhenActive == find);
		}
		return value;
	}

	public Row Find_Mode(ModeType find)
	{
		if (!_cacheMode.TryGetValue(find, out var value))
		{
			return _cacheMode[find] = rowList.Find((Row x) => x.Mode == find);
		}
		return value;
	}

	public List<Row> FindAll_Mode(ModeType find)
	{
		if (!_cacheAllMode.TryGetValue(find, out var value))
		{
			return _cacheAllMode[find] = rowList.FindAll((Row x) => x.Mode == find);
		}
		return value;
	}

	public Row Find_Type(ProgressType find)
	{
		if (!_cacheType.TryGetValue(find, out var value))
		{
			return _cacheType[find] = rowList.Find((Row x) => x.Type == find);
		}
		return value;
	}

	public List<Row> FindAll_Type(ProgressType find)
	{
		if (!_cacheAllType.TryGetValue(find, out var value))
		{
			return _cacheAllType[find] = rowList.FindAll((Row x) => x.Type == find);
		}
		return value;
	}

	public Row Find_MaxLevel(int find)
	{
		if (!_cacheMaxLevel.TryGetValue(find, out var value))
		{
			return _cacheMaxLevel[find] = rowList.Find((Row x) => x.MaxLevel == find);
		}
		return value;
	}

	public List<Row> FindAll_MaxLevel(int find)
	{
		if (!_cacheAllMaxLevel.TryGetValue(find, out var value))
		{
			return _cacheAllMaxLevel[find] = rowList.FindAll((Row x) => x.MaxLevel == find);
		}
		return value;
	}

	public Row Find_SpecialTime(int find)
	{
		if (!_cacheSpecialTime.TryGetValue(find, out var value))
		{
			return _cacheSpecialTime[find] = rowList.Find((Row x) => x.SpecialTime == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialTime(int find)
	{
		if (!_cacheAllSpecialTime.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialTime[find] = rowList.FindAll((Row x) => x.SpecialTime == find);
		}
		return value;
	}

	public Row Find_CanUse(CanUseType find)
	{
		if (!_cacheCanUse.TryGetValue(find, out var value))
		{
			return _cacheCanUse[find] = rowList.Find((Row x) => x.CanUse == find);
		}
		return value;
	}

	public List<Row> FindAll_CanUse(CanUseType find)
	{
		if (!_cacheAllCanUse.TryGetValue(find, out var value))
		{
			return _cacheAllCanUse[find] = rowList.FindAll((Row x) => x.CanUse == find);
		}
		return value;
	}

	public Row Find_CanUseValue(float find)
	{
		if (!_cacheCanUseValue.TryGetValue(find, out var value))
		{
			return _cacheCanUseValue[find] = rowList.Find((Row x) => x.CanUseValue == find);
		}
		return value;
	}

	public List<Row> FindAll_CanUseValue(float find)
	{
		if (!_cacheAllCanUseValue.TryGetValue(find, out var value))
		{
			return _cacheAllCanUseValue[find] = rowList.FindAll((Row x) => x.CanUseValue == find);
		}
		return value;
	}

	public Row Find_Cd(CdType find)
	{
		if (!_cacheCd.TryGetValue(find, out var value))
		{
			return _cacheCd[find] = rowList.Find((Row x) => x.Cd == find);
		}
		return value;
	}

	public List<Row> FindAll_Cd(CdType find)
	{
		if (!_cacheAllCd.TryGetValue(find, out var value))
		{
			return _cacheAllCd[find] = rowList.FindAll((Row x) => x.Cd == find);
		}
		return value;
	}

	public Row Find_ProgressVisiable(ProgressVisiableType find)
	{
		if (!_cacheProgressVisiable.TryGetValue(find, out var value))
		{
			return _cacheProgressVisiable[find] = rowList.Find((Row x) => x.ProgressVisiable == find);
		}
		return value;
	}

	public List<Row> FindAll_ProgressVisiable(ProgressVisiableType find)
	{
		if (!_cacheAllProgressVisiable.TryGetValue(find, out var value))
		{
			return _cacheAllProgressVisiable[find] = rowList.FindAll((Row x) => x.ProgressVisiable == find);
		}
		return value;
	}
}
