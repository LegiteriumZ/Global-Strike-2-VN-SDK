using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Sources.Constant;
using C2TPro;
using SSJJBase.Logger;
using UnityEngine;
using share.constant;

namespace Assets.Generated.Table;

public class LocalEntityEffectTable
{
	public class Row
	{
		public int Id;

		public int EventId;

		public int EntityType;

		public string Weapon;

		public int LifeTime;

		public string Prefab;

		public string Render;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheEventId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllEventId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheEntityType = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllEntityType = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cacheWeapon = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllWeapon = new Dictionary<string, List<Row>>();

	private readonly Dictionary<int, Row> _cacheLifeTime = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllLifeTime = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cachePrefab = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllPrefab = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheRender = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllRender = new Dictionary<string, List<Row>>();

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
			row.EventId = ConvertConstInt(typeof(EntityEventType), array[i][1]);
			row.EntityType = ConvertConstInt(typeof(LocalEntityType), array[i][2]);
			row.Weapon = array[i][3];
			row.LifeTime = ConvertInt(array[i][4]);
			row.Prefab = array[i][5];
			row.Render = array[i][6];
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

	public Row Find_EventId(int find)
	{
		if (!_cacheEventId.TryGetValue(find, out var value))
		{
			return _cacheEventId[find] = rowList.Find((Row x) => x.EventId == find);
		}
		return value;
	}

	public List<Row> FindAll_EventId(int find)
	{
		if (!_cacheAllEventId.TryGetValue(find, out var value))
		{
			return _cacheAllEventId[find] = rowList.FindAll((Row x) => x.EventId == find);
		}
		return value;
	}

	public Row Find_EntityType(int find)
	{
		if (!_cacheEntityType.TryGetValue(find, out var value))
		{
			return _cacheEntityType[find] = rowList.Find((Row x) => x.EntityType == find);
		}
		return value;
	}

	public List<Row> FindAll_EntityType(int find)
	{
		if (!_cacheAllEntityType.TryGetValue(find, out var value))
		{
			return _cacheAllEntityType[find] = rowList.FindAll((Row x) => x.EntityType == find);
		}
		return value;
	}

	public Row Find_Weapon(string find)
	{
		if (!_cacheWeapon.TryGetValue(find, out var value))
		{
			return _cacheWeapon[find] = rowList.Find((Row x) => x.Weapon == find);
		}
		return value;
	}

	public List<Row> FindAll_Weapon(string find)
	{
		if (!_cacheAllWeapon.TryGetValue(find, out var value))
		{
			return _cacheAllWeapon[find] = rowList.FindAll((Row x) => x.Weapon == find);
		}
		return value;
	}

	public Row Find_LifeTime(int find)
	{
		if (!_cacheLifeTime.TryGetValue(find, out var value))
		{
			return _cacheLifeTime[find] = rowList.Find((Row x) => x.LifeTime == find);
		}
		return value;
	}

	public List<Row> FindAll_LifeTime(int find)
	{
		if (!_cacheAllLifeTime.TryGetValue(find, out var value))
		{
			return _cacheAllLifeTime[find] = rowList.FindAll((Row x) => x.LifeTime == find);
		}
		return value;
	}

	public Row Find_Prefab(string find)
	{
		if (!_cachePrefab.TryGetValue(find, out var value))
		{
			return _cachePrefab[find] = rowList.Find((Row x) => x.Prefab == find);
		}
		return value;
	}

	public List<Row> FindAll_Prefab(string find)
	{
		if (!_cacheAllPrefab.TryGetValue(find, out var value))
		{
			return _cacheAllPrefab[find] = rowList.FindAll((Row x) => x.Prefab == find);
		}
		return value;
	}

	public Row Find_Render(string find)
	{
		if (!_cacheRender.TryGetValue(find, out var value))
		{
			return _cacheRender[find] = rowList.Find((Row x) => x.Render == find);
		}
		return value;
	}

	public List<Row> FindAll_Render(string find)
	{
		if (!_cacheAllRender.TryGetValue(find, out var value))
		{
			return _cacheAllRender[find] = rowList.FindAll((Row x) => x.Render == find);
		}
		return value;
	}
}
