using System;
using System.Collections.Generic;
using System.Reflection;
using C2TPro;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Generated.Table;

public class WeaponCrossTable
{
	public enum CrossType
	{
		None,
		Normal,
		Weapon,
		Dangong,
		Mech
	}

	public enum SniperCrossType
	{
		Awp,
		Normal,
		Weapon,
		Gold,
		Dsr,
		Dangong,
		G36c,
		Special,
		Mp5sd6Devil,
		JusticeFromAbove,
		AwmStrike,
		Mech
	}

	public enum ProgressType
	{
		None,
		Dsr,
		M96
	}

	public class Row
	{
		public int Id;

		public string Name;

		public bool SpecialPve;

		public bool SpecialBio;

		public bool SpecialModel;

		public CrossType SpecialCross;

		public SniperCrossType SniperCross;

		public bool SniperLevelCross;

		public string Fov1;

		public string Fov2;

		public bool InfraredGuid;

		public bool IsHideHand;

		public ProgressType Progress;

		public int EffectLevel;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cacheName = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllName = new Dictionary<string, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheSpecialPve = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllSpecialPve = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheSpecialBio = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllSpecialBio = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheSpecialModel = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllSpecialModel = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<CrossType, Row> _cacheSpecialCross = new Dictionary<CrossType, Row>();

	private readonly Dictionary<CrossType, List<Row>> _cacheAllSpecialCross = new Dictionary<CrossType, List<Row>>();

	private readonly Dictionary<SniperCrossType, Row> _cacheSniperCross = new Dictionary<SniperCrossType, Row>();

	private readonly Dictionary<SniperCrossType, List<Row>> _cacheAllSniperCross = new Dictionary<SniperCrossType, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheSniperLevelCross = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllSniperLevelCross = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<string, Row> _cacheFov1 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllFov1 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheFov2 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllFov2 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheInfraredGuid = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllInfraredGuid = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheIsHideHand = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllIsHideHand = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<ProgressType, Row> _cacheProgress = new Dictionary<ProgressType, Row>();

	private readonly Dictionary<ProgressType, List<Row>> _cacheAllProgress = new Dictionary<ProgressType, List<Row>>();

	private readonly Dictionary<int, Row> _cacheEffectLevel = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllEffectLevel = new Dictionary<int, List<Row>>();

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
			this.LogError(str + " property can not found in " + type.Name);
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
			this.LogError(str + " property can not found in " + type.Name);
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
			row.SpecialPve = ConvertBool(array[i][2]);
			row.SpecialBio = ConvertBool(array[i][3]);
			row.SpecialModel = ConvertBool(array[i][4]);
			if (!string.IsNullOrEmpty(array[i][5]))
			{
				row.SpecialCross = (CrossType)Enum.Parse(typeof(CrossType), array[i][5]);
			}
			if (!string.IsNullOrEmpty(array[i][6]))
			{
				row.SniperCross = (SniperCrossType)Enum.Parse(typeof(SniperCrossType), array[i][6]);
			}
			row.SniperLevelCross = ConvertBool(array[i][7]);
			row.Fov1 = array[i][8];
			row.Fov2 = array[i][9];
			row.InfraredGuid = ConvertBool(array[i][10]);
			row.IsHideHand = ConvertBool(array[i][11]);
			if (!string.IsNullOrEmpty(array[i][12]))
			{
				row.Progress = (ProgressType)Enum.Parse(typeof(ProgressType), array[i][12]);
			}
			row.EffectLevel = ConvertInt(array[i][13]);
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

	public Row Find_SpecialPve(bool find)
	{
		if (!_cacheSpecialPve.TryGetValue(find, out var value))
		{
			return _cacheSpecialPve[find] = rowList.Find((Row x) => x.SpecialPve == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialPve(bool find)
	{
		if (!_cacheAllSpecialPve.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialPve[find] = rowList.FindAll((Row x) => x.SpecialPve == find);
		}
		return value;
	}

	public Row Find_SpecialBio(bool find)
	{
		if (!_cacheSpecialBio.TryGetValue(find, out var value))
		{
			return _cacheSpecialBio[find] = rowList.Find((Row x) => x.SpecialBio == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialBio(bool find)
	{
		if (!_cacheAllSpecialBio.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialBio[find] = rowList.FindAll((Row x) => x.SpecialBio == find);
		}
		return value;
	}

	public Row Find_SpecialModel(bool find)
	{
		if (!_cacheSpecialModel.TryGetValue(find, out var value))
		{
			return _cacheSpecialModel[find] = rowList.Find((Row x) => x.SpecialModel == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialModel(bool find)
	{
		if (!_cacheAllSpecialModel.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialModel[find] = rowList.FindAll((Row x) => x.SpecialModel == find);
		}
		return value;
	}

	public Row Find_SpecialCross(CrossType find)
	{
		if (!_cacheSpecialCross.TryGetValue(find, out var value))
		{
			return _cacheSpecialCross[find] = rowList.Find((Row x) => x.SpecialCross == find);
		}
		return value;
	}

	public List<Row> FindAll_SpecialCross(CrossType find)
	{
		if (!_cacheAllSpecialCross.TryGetValue(find, out var value))
		{
			return _cacheAllSpecialCross[find] = rowList.FindAll((Row x) => x.SpecialCross == find);
		}
		return value;
	}

	public Row Find_SniperCross(SniperCrossType find)
	{
		if (!_cacheSniperCross.TryGetValue(find, out var value))
		{
			return _cacheSniperCross[find] = rowList.Find((Row x) => x.SniperCross == find);
		}
		return value;
	}

	public List<Row> FindAll_SniperCross(SniperCrossType find)
	{
		if (!_cacheAllSniperCross.TryGetValue(find, out var value))
		{
			return _cacheAllSniperCross[find] = rowList.FindAll((Row x) => x.SniperCross == find);
		}
		return value;
	}

	public Row Find_SniperLevelCross(bool find)
	{
		if (!_cacheSniperLevelCross.TryGetValue(find, out var value))
		{
			return _cacheSniperLevelCross[find] = rowList.Find((Row x) => x.SniperLevelCross == find);
		}
		return value;
	}

	public List<Row> FindAll_SniperLevelCross(bool find)
	{
		if (!_cacheAllSniperLevelCross.TryGetValue(find, out var value))
		{
			return _cacheAllSniperLevelCross[find] = rowList.FindAll((Row x) => x.SniperLevelCross == find);
		}
		return value;
	}

	public Row Find_Fov1(string find)
	{
		if (!_cacheFov1.TryGetValue(find, out var value))
		{
			return _cacheFov1[find] = rowList.Find((Row x) => x.Fov1 == find);
		}
		return value;
	}

	public List<Row> FindAll_Fov1(string find)
	{
		if (!_cacheAllFov1.TryGetValue(find, out var value))
		{
			return _cacheAllFov1[find] = rowList.FindAll((Row x) => x.Fov1 == find);
		}
		return value;
	}

	public Row Find_Fov2(string find)
	{
		if (!_cacheFov2.TryGetValue(find, out var value))
		{
			return _cacheFov2[find] = rowList.Find((Row x) => x.Fov2 == find);
		}
		return value;
	}

	public List<Row> FindAll_Fov2(string find)
	{
		if (!_cacheAllFov2.TryGetValue(find, out var value))
		{
			return _cacheAllFov2[find] = rowList.FindAll((Row x) => x.Fov2 == find);
		}
		return value;
	}

	public Row Find_InfraredGuid(bool find)
	{
		if (!_cacheInfraredGuid.TryGetValue(find, out var value))
		{
			return _cacheInfraredGuid[find] = rowList.Find((Row x) => x.InfraredGuid == find);
		}
		return value;
	}

	public List<Row> FindAll_InfraredGuid(bool find)
	{
		if (!_cacheAllInfraredGuid.TryGetValue(find, out var value))
		{
			return _cacheAllInfraredGuid[find] = rowList.FindAll((Row x) => x.InfraredGuid == find);
		}
		return value;
	}

	public Row Find_IsHideHand(bool find)
	{
		if (!_cacheIsHideHand.TryGetValue(find, out var value))
		{
			return _cacheIsHideHand[find] = rowList.Find((Row x) => x.IsHideHand == find);
		}
		return value;
	}

	public List<Row> FindAll_IsHideHand(bool find)
	{
		if (!_cacheAllIsHideHand.TryGetValue(find, out var value))
		{
			return _cacheAllIsHideHand[find] = rowList.FindAll((Row x) => x.IsHideHand == find);
		}
		return value;
	}

	public Row Find_Progress(ProgressType find)
	{
		if (!_cacheProgress.TryGetValue(find, out var value))
		{
			return _cacheProgress[find] = rowList.Find((Row x) => x.Progress == find);
		}
		return value;
	}

	public List<Row> FindAll_Progress(ProgressType find)
	{
		if (!_cacheAllProgress.TryGetValue(find, out var value))
		{
			return _cacheAllProgress[find] = rowList.FindAll((Row x) => x.Progress == find);
		}
		return value;
	}

	public Row Find_EffectLevel(int find)
	{
		if (!_cacheEffectLevel.TryGetValue(find, out var value))
		{
			return _cacheEffectLevel[find] = rowList.Find((Row x) => x.EffectLevel == find);
		}
		return value;
	}

	public List<Row> FindAll_EffectLevel(int find)
	{
		if (!_cacheAllEffectLevel.TryGetValue(find, out var value))
		{
			return _cacheAllEffectLevel[find] = rowList.FindAll((Row x) => x.EffectLevel == find);
		}
		return value;
	}
}
