using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Sources.constant;
using C2TPro;
using CommonUtils;
using UnityEngine;

namespace Assets.Generated.Table;

public class GameMessagePvpTable
{
	public class Row
	{
		public int ModeId;

		public int Type;

		public string Mode;

		public string Image;

		public int Time;

		public int Priority;

		public int NumType;

		public int PosX;

		public int PosY;

		public int MsgPosY;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheModeId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllModeId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheType = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllType = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cacheMode = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllMode = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheImage = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllImage = new Dictionary<string, List<Row>>();

	private readonly Dictionary<int, Row> _cacheTime = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllTime = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cachePriority = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllPriority = new Dictionary<int, List<Row>>();

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
			row.ModeId = ConvertInt(array[i][0]);
			row.Type = ConvertConstInt(typeof(GameUiTipsConst), array[i][1]);
			row.Mode = array[i][2];
			row.Image = array[i][3];
			row.Time = ConvertInt(array[i][4]);
			row.Priority = ConvertInt(array[i][5]);
			row.NumType = ConvertInt(array[i][6]);
			row.PosX = ConvertInt(array[i][7]);
			row.PosY = ConvertInt(array[i][8]);
			row.MsgPosY = ConvertInt(array[i][9]);
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public Row Find_ModeId(int find)
	{
		if (!_cacheModeId.TryGetValue(find, out var value))
		{
			return _cacheModeId[find] = rowList.Find((Row x) => x.ModeId == find);
		}
		return value;
	}

	public List<Row> FindAll_ModeId(int find)
	{
		if (!_cacheAllModeId.TryGetValue(find, out var value))
		{
			return _cacheAllModeId[find] = rowList.FindAll((Row x) => x.ModeId == find || x.ModeId == -1);
		}
		return value;
	}

	public Row Find_Type(int find)
	{
		if (!_cacheType.TryGetValue(find, out var value))
		{
			return _cacheType[find] = rowList.Find((Row x) => x.Type == find);
		}
		return value;
	}

	public List<Row> FindAll_Type(int find)
	{
		if (!_cacheAllType.TryGetValue(find, out var value))
		{
			return _cacheAllType[find] = rowList.FindAll((Row x) => x.Type == find);
		}
		return value;
	}

	public Row Find_Mode(string find)
	{
		if (!_cacheMode.TryGetValue(find, out var value))
		{
			return _cacheMode[find] = rowList.Find((Row x) => x.Mode == find);
		}
		return value;
	}

	public List<Row> FindAll_Mode(string find)
	{
		if (!_cacheAllMode.TryGetValue(find, out var value))
		{
			return _cacheAllMode[find] = rowList.FindAll((Row x) => x.Mode == find);
		}
		return value;
	}

	public Row Find_Image(string find)
	{
		if (!_cacheImage.TryGetValue(find, out var value))
		{
			return _cacheImage[find] = rowList.Find((Row x) => x.Image == find);
		}
		return value;
	}

	public List<Row> FindAll_Image(string find)
	{
		if (!_cacheAllImage.TryGetValue(find, out var value))
		{
			return _cacheAllImage[find] = rowList.FindAll((Row x) => x.Image == find);
		}
		return value;
	}

	public Row Find_Time(int find)
	{
		if (!_cacheTime.TryGetValue(find, out var value))
		{
			return _cacheTime[find] = rowList.Find((Row x) => x.Time == find);
		}
		return value;
	}

	public List<Row> FindAll_Time(int find)
	{
		if (!_cacheAllTime.TryGetValue(find, out var value))
		{
			return _cacheAllTime[find] = rowList.FindAll((Row x) => x.Time == find);
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
}
