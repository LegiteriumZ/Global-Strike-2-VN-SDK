using System;
using System.Collections.Generic;
using System.Reflection;
using C2TPro;
using CommonUtils;
using UnityEngine;

namespace Assets.Generated.Table;

public class PlayerInfoSkillTable
{
	public class Row
	{
		public int PlayerInfoId;

		public string Message;

		public string ProgressBack;

		public string ProgressBar;

		public int MessagePosX;

		public int MessagePosY;

		public int PBackPosX;

		public int PBackPosY;

		public int PBarPosX;

		public int PBarPosY;

		public bool StartProgress;

		public int Time;

		public bool Up;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

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
			row.PlayerInfoId = ConvertInt(array[i][0]);
			row.Message = array[i][1];
			row.ProgressBack = array[i][2];
			row.ProgressBar = array[i][3];
			row.MessagePosX = ConvertInt(array[i][4]);
			row.MessagePosY = ConvertInt(array[i][5]);
			row.PBackPosX = ConvertInt(array[i][6]);
			row.PBackPosY = ConvertInt(array[i][7]);
			row.PBarPosX = ConvertInt(array[i][8]);
			row.PBarPosY = ConvertInt(array[i][9]);
			row.StartProgress = ConvertBool(array[i][10]);
			row.Time = ConvertInt(array[i][11]);
			row.Up = ConvertBool(array[i][12]);
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public Row Find_Id(int find)
	{
		if (!_cacheId.TryGetValue(find, out var value))
		{
			return _cacheId[find] = rowList.Find((Row x) => x.PlayerInfoId == find);
		}
		return value;
	}

	public List<Row> FindAll_Id(int find)
	{
		if (!_cacheAllId.TryGetValue(find, out var value))
		{
			return _cacheAllId[find] = rowList.FindAll((Row x) => x.PlayerInfoId == find);
		}
		return value;
	}
}
