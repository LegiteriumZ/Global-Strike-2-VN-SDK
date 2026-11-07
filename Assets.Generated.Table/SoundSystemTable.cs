using System;
using System.Collections.Generic;
using System.Reflection;
using C2TPro;
using CommonUtils;
using UnityEngine;

namespace Assets.Generated.Table;

public class SoundSystemTable
{
	public enum SoundType
	{
		System,
		Scene,
		Voice,
		Weapon,
		Charactor
	}

	public class SoundSubtype
	{
		public static int SystemBg = 0;

		public static int Mode = 1;

		public static int System = 2;

		public static int Scene = 3;

		public static int Personalized = 4;

		public static int Tactics = 5;

		public static int Shoot = 6;

		public static int LoadBullet = 7;

		public static int Skill = 8;

		public static int Operate = 9;

		public static int Knife = 10;

		public static int ChangeWeapon = 11;

		public static int HitMaterial = 12;

		public static int Explorde = 13;

		public static int Step = 14;

		public static int Other = 15;

		public static int BG = 16;
	}

	public class Row
	{
		public int Id;

		public SoundType Type;

		public int Subtype;

		public int Priority;

		public int PriOffset;

		public int VolOffset;

		public int LimiteWhole;

		public bool LimitGlobal;

		public bool LimiteRange;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<SoundType, Row> _cacheType = new Dictionary<SoundType, Row>();

	private readonly Dictionary<SoundType, List<Row>> _cacheAllType = new Dictionary<SoundType, List<Row>>();

	private readonly Dictionary<int, Row> _cacheSubtype = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllSubtype = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cachePriority = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllPriority = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cachePriOffset = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllPriOffset = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheVolOffset = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllVolOffset = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheLimiteWhole = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllLimiteWhole = new Dictionary<int, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheLimitGlobal = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllLimitGlobal = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheLimiteRange = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllLimiteRange = new Dictionary<bool, List<Row>>();

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
			if (!string.IsNullOrEmpty(array[i][1]))
			{
				row.Type = (SoundType)Enum.Parse(typeof(SoundType), array[i][1]);
			}
			row.Subtype = ConvertConstInt(typeof(SoundSubtype), array[i][2]);
			row.Priority = ConvertInt(array[i][3]);
			row.PriOffset = ConvertInt(array[i][4]);
			row.VolOffset = ConvertInt(array[i][5]);
			row.LimiteWhole = ConvertInt(array[i][6]);
			row.LimitGlobal = ConvertBool(array[i][7]);
			row.LimiteRange = ConvertBool(array[i][8]);
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

	public Row Find_Type(SoundType find)
	{
		if (!_cacheType.TryGetValue(find, out var value))
		{
			return _cacheType[find] = rowList.Find((Row x) => x.Type == find);
		}
		return value;
	}

	public List<Row> FindAll_Type(SoundType find)
	{
		if (!_cacheAllType.TryGetValue(find, out var value))
		{
			return _cacheAllType[find] = rowList.FindAll((Row x) => x.Type == find);
		}
		return value;
	}

	public Row Find_Subtype(int find)
	{
		if (!_cacheSubtype.TryGetValue(find, out var value))
		{
			return _cacheSubtype[find] = rowList.Find((Row x) => x.Subtype == find);
		}
		return value;
	}

	public List<Row> FindAll_Subtype(int find)
	{
		if (!_cacheAllSubtype.TryGetValue(find, out var value))
		{
			return _cacheAllSubtype[find] = rowList.FindAll((Row x) => x.Subtype == find);
		}
		return value;
	}

	public Row Find_Priority(int find)
	{
		if (!_cachePriority.TryGetValue(find, out var value))
		{
			return _cachePriority[find] = rowList.Find((Row x) => x.Priority == find);
		}
		return value;
	}

	public List<Row> FindAll_Priority(int find)
	{
		if (!_cacheAllPriority.TryGetValue(find, out var value))
		{
			return _cacheAllPriority[find] = rowList.FindAll((Row x) => x.Priority == find);
		}
		return value;
	}

	public Row Find_PriOffset(int find)
	{
		if (!_cachePriOffset.TryGetValue(find, out var value))
		{
			return _cachePriOffset[find] = rowList.Find((Row x) => x.PriOffset == find);
		}
		return value;
	}

	public List<Row> FindAll_PriOffset(int find)
	{
		if (!_cacheAllPriOffset.TryGetValue(find, out var value))
		{
			return _cacheAllPriOffset[find] = rowList.FindAll((Row x) => x.PriOffset == find);
		}
		return value;
	}

	public Row Find_VolOffset(int find)
	{
		if (!_cacheVolOffset.TryGetValue(find, out var value))
		{
			return _cacheVolOffset[find] = rowList.Find((Row x) => x.VolOffset == find);
		}
		return value;
	}

	public List<Row> FindAll_VolOffset(int find)
	{
		if (!_cacheAllVolOffset.TryGetValue(find, out var value))
		{
			return _cacheAllVolOffset[find] = rowList.FindAll((Row x) => x.VolOffset == find);
		}
		return value;
	}

	public Row Find_LimiteWhole(int find)
	{
		if (!_cacheLimiteWhole.TryGetValue(find, out var value))
		{
			return _cacheLimiteWhole[find] = rowList.Find((Row x) => x.LimiteWhole == find);
		}
		return value;
	}

	public List<Row> FindAll_LimiteWhole(int find)
	{
		if (!_cacheAllLimiteWhole.TryGetValue(find, out var value))
		{
			return _cacheAllLimiteWhole[find] = rowList.FindAll((Row x) => x.LimiteWhole == find);
		}
		return value;
	}

	public Row Find_LimitGlobal(bool find)
	{
		if (!_cacheLimitGlobal.TryGetValue(find, out var value))
		{
			return _cacheLimitGlobal[find] = rowList.Find((Row x) => x.LimitGlobal == find);
		}
		return value;
	}

	public List<Row> FindAll_LimitGlobal(bool find)
	{
		if (!_cacheAllLimitGlobal.TryGetValue(find, out var value))
		{
			return _cacheAllLimitGlobal[find] = rowList.FindAll((Row x) => x.LimitGlobal == find);
		}
		return value;
	}

	public Row Find_LimiteRange(bool find)
	{
		if (!_cacheLimiteRange.TryGetValue(find, out var value))
		{
			return _cacheLimiteRange[find] = rowList.Find((Row x) => x.LimiteRange == find);
		}
		return value;
	}

	public List<Row> FindAll_LimiteRange(bool find)
	{
		if (!_cacheAllLimiteRange.TryGetValue(find, out var value))
		{
			return _cacheAllLimiteRange[find] = rowList.FindAll((Row x) => x.LimiteRange == find);
		}
		return value;
	}
}
