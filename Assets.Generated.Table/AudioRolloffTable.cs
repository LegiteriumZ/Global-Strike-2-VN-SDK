using System;
using System.Collections.Generic;
using System.Reflection;
using C2TPro;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Generated.Table;

public class AudioRolloffTable
{
	public class Row
	{
		public int Id;

		public int Min;

		public int Max;

		public float A;

		public float B;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheMin = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllMin = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheMax = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllMax = new Dictionary<int, List<Row>>();

	private readonly Dictionary<float, Row> _cacheA = new Dictionary<float, Row>();

	private readonly Dictionary<float, List<Row>> _cacheAllA = new Dictionary<float, List<Row>>();

	private readonly Dictionary<float, Row> _cacheB = new Dictionary<float, Row>();

	private readonly Dictionary<float, List<Row>> _cacheAllB = new Dictionary<float, List<Row>>();

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
			row.Min = ConvertInt(array[i][1]);
			row.Max = ConvertInt(array[i][2]);
			row.A = ConvertFloat(array[i][3]);
			row.B = ConvertFloat(array[i][4]);
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

	public Row Find_Min(int find)
	{
		if (!_cacheMin.TryGetValue(find, out var value))
		{
			return _cacheMin[find] = rowList.Find((Row x) => x.Min == find);
		}
		return value;
	}

	public List<Row> FindAll_Min(int find)
	{
		if (!_cacheAllMin.TryGetValue(find, out var value))
		{
			return _cacheAllMin[find] = rowList.FindAll((Row x) => x.Min == find);
		}
		return value;
	}

	public Row Find_Max(int find)
	{
		if (!_cacheMax.TryGetValue(find, out var value))
		{
			return _cacheMax[find] = rowList.Find((Row x) => x.Max == find);
		}
		return value;
	}

	public List<Row> FindAll_Max(int find)
	{
		if (!_cacheAllMax.TryGetValue(find, out var value))
		{
			return _cacheAllMax[find] = rowList.FindAll((Row x) => x.Max == find);
		}
		return value;
	}

	public Row Find_A(float find)
	{
		if (!_cacheA.TryGetValue(find, out var value))
		{
			return _cacheA[find] = rowList.Find((Row x) => x.A == find);
		}
		return value;
	}

	public List<Row> FindAll_A(float find)
	{
		if (!_cacheAllA.TryGetValue(find, out var value))
		{
			return _cacheAllA[find] = rowList.FindAll((Row x) => x.A == find);
		}
		return value;
	}

	public Row Find_B(float find)
	{
		if (!_cacheB.TryGetValue(find, out var value))
		{
			return _cacheB[find] = rowList.Find((Row x) => x.B == find);
		}
		return value;
	}

	public List<Row> FindAll_B(float find)
	{
		if (!_cacheAllB.TryGetValue(find, out var value))
		{
			return _cacheAllB[find] = rowList.FindAll((Row x) => x.B == find);
		}
		return value;
	}
}
