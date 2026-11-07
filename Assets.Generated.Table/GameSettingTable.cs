using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Sources.Config;
using C2TPro;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Generated.Table;

public class GameSettingTable
{
	public enum ControlType
	{
		Dropdown,
		Slider,
		Color,
		Cross,
		Seperator,
		Text
	}

	public class Row
	{
		public int Id;

		public string Name;

		public string Property;

		public string Dependent;

		public string DependentSelect;

		public string[] Select;

		public ControlType Type;

		public string DefaultSelect;

		public bool IsOpened;

		public string Level0;

		public string Level1;

		public string Level2;

		public string Level3;

		public string Level4;

		public string Descript;

		public int Version;

		public string[] Alert;

		public string[] racrList;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cacheName = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllName = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheProperty = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllProperty = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheDependent = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllDependent = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheDependentSelect = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllDependentSelect = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string[], Row> _cacheSelect = new Dictionary<string[], Row>();

	private readonly Dictionary<string[], List<Row>> _cacheAllSelect = new Dictionary<string[], List<Row>>();

	private readonly Dictionary<ControlType, Row> _cacheType = new Dictionary<ControlType, Row>();

	private readonly Dictionary<ControlType, List<Row>> _cacheAllType = new Dictionary<ControlType, List<Row>>();

	private readonly Dictionary<string, Row> _cacheDefaultSelect = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllDefaultSelect = new Dictionary<string, List<Row>>();

	private readonly Dictionary<bool, Row> _cacheIsOpened = new Dictionary<bool, Row>();

	private readonly Dictionary<bool, List<Row>> _cacheAllIsOpened = new Dictionary<bool, List<Row>>();

	private readonly Dictionary<string, Row> _cacheLevel0 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllLevel0 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheLevel1 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllLevel1 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheLevel2 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllLevel2 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheLevel3 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllLevel3 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheLevel4 = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllLevel4 = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheDescript = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllDescript = new Dictionary<string, List<Row>>();

	private readonly Dictionary<int, Row> _cacheVersion = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllVersion = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string[], Row> _cacheAlert = new Dictionary<string[], Row>();

	private readonly Dictionary<string[], List<Row>> _cacheAllAlert = new Dictionary<string[], List<Row>>();

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
			row.Property = array[i][2];
			row.Dependent = array[i][3];
			row.DependentSelect = array[i][4];
			if (!string.IsNullOrEmpty(array[i][5]))
			{
				row.Select = array[i][5].Split(',');
			}
			if (!string.IsNullOrEmpty(array[i][6]))
			{
				row.Type = (ControlType)Enum.Parse(typeof(ControlType), array[i][6]);
			}
			row.DefaultSelect = array[i][7];
			row.IsOpened = ConvertBool(array[i][8]);
			row.Level0 = array[i][9];
			row.Level1 = array[i][10];
			row.Level2 = array[i][11];
			row.Level3 = array[i][12];
			row.Level4 = array[i][13];
			row.Descript = array[i][14];
			row.Version = ConvertInt(array[i][15]);
			if (array[i].Length >= 17 && !string.IsNullOrEmpty(array[i][16]))
			{
				row.Alert = array[i][16].Split(',');
			}
			if (array[i].Length >= 18 && !string.IsNullOrEmpty(array[i][17]))
			{
				row.racrList = array[i][17].Split(',');
			}
			rowList.Add(row);
		}
		isLoaded = true;
	}

	public void UpdateRowList()
	{
		for (int num = rowList.Count - 1; num >= 0; num--)
		{
			if (rowList[num].racrList != null && rowList[num].racrList.Length != 0)
			{
				bool flag = true;
				string[] racrList = rowList[num].racrList;
				for (int i = 0; i < racrList.Length; i++)
				{
					if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType.ToString() == racrList[i])
					{
						flag = false;
					}
				}
				if (flag)
				{
					rowList.RemoveAt(num);
					GameSetting.SpaceJumpOpen = true;
				}
			}
		}
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

	public Row Find_Property(string find)
	{
		if (!_cacheProperty.TryGetValue(find, out var value))
		{
			return _cacheProperty[find] = rowList.Find((Row x) => x.Property == find);
		}
		return value;
	}

	public List<Row> FindAll_Property(string find)
	{
		if (!_cacheAllProperty.TryGetValue(find, out var value))
		{
			return _cacheAllProperty[find] = rowList.FindAll((Row x) => x.Property == find);
		}
		return value;
	}

	public Row Find_Dependent(string find)
	{
		if (!_cacheDependent.TryGetValue(find, out var value))
		{
			return _cacheDependent[find] = rowList.Find((Row x) => x.Dependent == find);
		}
		return value;
	}

	public List<Row> FindAll_Dependent(string find)
	{
		if (!_cacheAllDependent.TryGetValue(find, out var value))
		{
			return _cacheAllDependent[find] = rowList.FindAll((Row x) => x.Dependent == find);
		}
		return value;
	}

	public Row Find_DependentSelect(string find)
	{
		if (!_cacheDependentSelect.TryGetValue(find, out var value))
		{
			return _cacheDependentSelect[find] = rowList.Find((Row x) => x.DependentSelect == find);
		}
		return value;
	}

	public List<Row> FindAll_DependentSelect(string find)
	{
		if (!_cacheAllDependentSelect.TryGetValue(find, out var value))
		{
			return _cacheAllDependentSelect[find] = rowList.FindAll((Row x) => x.DependentSelect == find);
		}
		return value;
	}

	public Row Find_Select(string[] find)
	{
		if (!_cacheSelect.TryGetValue(find, out var value))
		{
			return _cacheSelect[find] = rowList.Find((Row x) => x.Select == find);
		}
		return value;
	}

	public List<Row> FindAll_Select(string[] find)
	{
		if (!_cacheAllSelect.TryGetValue(find, out var value))
		{
			return _cacheAllSelect[find] = rowList.FindAll((Row x) => x.Select == find);
		}
		return value;
	}

	public Row Find_Type(ControlType find)
	{
		if (!_cacheType.TryGetValue(find, out var value))
		{
			return _cacheType[find] = rowList.Find((Row x) => x.Type == find);
		}
		return value;
	}

	public List<Row> FindAll_Type(ControlType find)
	{
		if (!_cacheAllType.TryGetValue(find, out var value))
		{
			return _cacheAllType[find] = rowList.FindAll((Row x) => x.Type == find);
		}
		return value;
	}

	public Row Find_DefaultSelect(string find)
	{
		if (!_cacheDefaultSelect.TryGetValue(find, out var value))
		{
			return _cacheDefaultSelect[find] = rowList.Find((Row x) => x.DefaultSelect == find);
		}
		return value;
	}

	public List<Row> FindAll_DefaultSelect(string find)
	{
		if (!_cacheAllDefaultSelect.TryGetValue(find, out var value))
		{
			return _cacheAllDefaultSelect[find] = rowList.FindAll((Row x) => x.DefaultSelect == find);
		}
		return value;
	}

	public Row Find_IsOpened(bool find)
	{
		if (!_cacheIsOpened.TryGetValue(find, out var value))
		{
			return _cacheIsOpened[find] = rowList.Find((Row x) => x.IsOpened == find);
		}
		return value;
	}

	public List<Row> FindAll_IsOpened(bool find)
	{
		if (!_cacheAllIsOpened.TryGetValue(find, out var value))
		{
			return _cacheAllIsOpened[find] = rowList.FindAll((Row x) => x.IsOpened == find);
		}
		return value;
	}

	public Row Find_Level0(string find)
	{
		if (!_cacheLevel0.TryGetValue(find, out var value))
		{
			return _cacheLevel0[find] = rowList.Find((Row x) => x.Level0 == find);
		}
		return value;
	}

	public List<Row> FindAll_Level0(string find)
	{
		if (!_cacheAllLevel0.TryGetValue(find, out var value))
		{
			return _cacheAllLevel0[find] = rowList.FindAll((Row x) => x.Level0 == find);
		}
		return value;
	}

	public Row Find_Level1(string find)
	{
		if (!_cacheLevel1.TryGetValue(find, out var value))
		{
			return _cacheLevel1[find] = rowList.Find((Row x) => x.Level1 == find);
		}
		return value;
	}

	public List<Row> FindAll_Level1(string find)
	{
		if (!_cacheAllLevel1.TryGetValue(find, out var value))
		{
			return _cacheAllLevel1[find] = rowList.FindAll((Row x) => x.Level1 == find);
		}
		return value;
	}

	public Row Find_Level2(string find)
	{
		if (!_cacheLevel2.TryGetValue(find, out var value))
		{
			return _cacheLevel2[find] = rowList.Find((Row x) => x.Level2 == find);
		}
		return value;
	}

	public List<Row> FindAll_Level2(string find)
	{
		if (!_cacheAllLevel2.TryGetValue(find, out var value))
		{
			return _cacheAllLevel2[find] = rowList.FindAll((Row x) => x.Level2 == find);
		}
		return value;
	}

	public Row Find_Level3(string find)
	{
		if (!_cacheLevel3.TryGetValue(find, out var value))
		{
			return _cacheLevel3[find] = rowList.Find((Row x) => x.Level3 == find);
		}
		return value;
	}

	public List<Row> FindAll_Level3(string find)
	{
		if (!_cacheAllLevel3.TryGetValue(find, out var value))
		{
			return _cacheAllLevel3[find] = rowList.FindAll((Row x) => x.Level3 == find);
		}
		return value;
	}

	public Row Find_Level4(string find)
	{
		if (!_cacheLevel4.TryGetValue(find, out var value))
		{
			return _cacheLevel4[find] = rowList.Find((Row x) => x.Level4 == find);
		}
		return value;
	}

	public List<Row> FindAll_Level4(string find)
	{
		if (!_cacheAllLevel4.TryGetValue(find, out var value))
		{
			return _cacheAllLevel4[find] = rowList.FindAll((Row x) => x.Level4 == find);
		}
		return value;
	}

	public Row Find_Descript(string find)
	{
		if (!_cacheDescript.TryGetValue(find, out var value))
		{
			return _cacheDescript[find] = rowList.Find((Row x) => x.Descript == find);
		}
		return value;
	}

	public List<Row> FindAll_Descript(string find)
	{
		if (!_cacheAllDescript.TryGetValue(find, out var value))
		{
			return _cacheAllDescript[find] = rowList.FindAll((Row x) => x.Descript == find);
		}
		return value;
	}

	public Row Find_Version(int find)
	{
		if (!_cacheVersion.TryGetValue(find, out var value))
		{
			return _cacheVersion[find] = rowList.Find((Row x) => x.Version == find);
		}
		return value;
	}

	public List<Row> FindAll_Version(int find)
	{
		if (!_cacheAllVersion.TryGetValue(find, out var value))
		{
			return _cacheAllVersion[find] = rowList.FindAll((Row x) => x.Version == find);
		}
		return value;
	}

	public Row Find_Alert(string[] find)
	{
		if (!_cacheAlert.TryGetValue(find, out var value))
		{
			return _cacheAlert[find] = rowList.Find((Row x) => x.Alert == find);
		}
		return value;
	}

	public List<Row> FindAll_Alert(string[] find)
	{
		if (!_cacheAllAlert.TryGetValue(find, out var value))
		{
			return _cacheAllAlert[find] = rowList.FindAll((Row x) => x.Alert == find);
		}
		return value;
	}
}
