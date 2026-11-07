using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Sources.constant;
using C2TPro;
using CommonUtils;
using UnityEngine;

namespace Assets.Generated.Table;

public class GameMessageTable
{
	public enum MessageLayer
	{
		Toper,
		Top,
		Center,
		DownCenter,
		Bottom
	}

	public enum AnimEnum
	{
		None,
		Zoomout,
		Zoomin
	}

	public enum CounterTypeEnum
	{
		None,
		Second,
		MinuteSecond,
		Msm,
		Time,
		RealSecond
	}

	public class Row
	{
		public int Id;

		public int Type;

		public string Mode;

		public string Image;

		public MessageLayer Layer;

		public int Time;

		public int Priority;

		public AnimEnum Anim;

		public CounterTypeEnum CounterType;

		public int[] Counter1;

		public int[] Counter2;

		public int[] Counter3;

		public int[] Text;

		public int[] MessagePosition;
	}

	private List<Row> rowList = new List<Row>();

	private bool isLoaded;

	private readonly Dictionary<int, Row> _cacheId = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllId = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cacheType = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllType = new Dictionary<int, List<Row>>();

	private readonly Dictionary<string, Row> _cacheMode = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllMode = new Dictionary<string, List<Row>>();

	private readonly Dictionary<string, Row> _cacheImage = new Dictionary<string, Row>();

	private readonly Dictionary<string, List<Row>> _cacheAllImage = new Dictionary<string, List<Row>>();

	private readonly Dictionary<MessageLayer, Row> _cacheLayer = new Dictionary<MessageLayer, Row>();

	private readonly Dictionary<MessageLayer, List<Row>> _cacheAllLayer = new Dictionary<MessageLayer, List<Row>>();

	private readonly Dictionary<int, Row> _cacheTime = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllTime = new Dictionary<int, List<Row>>();

	private readonly Dictionary<int, Row> _cachePriority = new Dictionary<int, Row>();

	private readonly Dictionary<int, List<Row>> _cacheAllPriority = new Dictionary<int, List<Row>>();

	private readonly Dictionary<AnimEnum, Row> _cacheAnim = new Dictionary<AnimEnum, Row>();

	private readonly Dictionary<AnimEnum, List<Row>> _cacheAllAnim = new Dictionary<AnimEnum, List<Row>>();

	private readonly Dictionary<CounterTypeEnum, Row> _cacheCounterType = new Dictionary<CounterTypeEnum, Row>();

	private readonly Dictionary<CounterTypeEnum, List<Row>> _cacheAllCounterType = new Dictionary<CounterTypeEnum, List<Row>>();

	private readonly Dictionary<int[], Row> _cacheCounter1 = new Dictionary<int[], Row>();

	private readonly Dictionary<int[], List<Row>> _cacheAllCounter1 = new Dictionary<int[], List<Row>>();

	private readonly Dictionary<int[], Row> _cacheCounter2 = new Dictionary<int[], Row>();

	private readonly Dictionary<int[], List<Row>> _cacheAllCounter2 = new Dictionary<int[], List<Row>>();

	private readonly Dictionary<int[], Row> _cacheCounter3 = new Dictionary<int[], Row>();

	private readonly Dictionary<int[], List<Row>> _cacheAllCounter3 = new Dictionary<int[], List<Row>>();

	private readonly Dictionary<int[], Row> _cacheText = new Dictionary<int[], Row>();

	private readonly Dictionary<int[], List<Row>> _cacheAllText = new Dictionary<int[], List<Row>>();

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
			row.Type = ConvertConstInt(typeof(GameUiTipsConst), array[i][1]);
			row.Mode = array[i][2];
			row.Image = array[i][3];
			if (!string.IsNullOrEmpty(array[i][4]))
			{
				row.Layer = (MessageLayer)Enum.Parse(typeof(MessageLayer), array[i][4]);
			}
			row.Time = ConvertInt(array[i][5]);
			row.Priority = ConvertInt(array[i][6]);
			if (!string.IsNullOrEmpty(array[i][7]))
			{
				row.Anim = (AnimEnum)Enum.Parse(typeof(AnimEnum), array[i][7]);
			}
			if (!string.IsNullOrEmpty(array[i][8]))
			{
				row.CounterType = (CounterTypeEnum)Enum.Parse(typeof(CounterTypeEnum), array[i][8]);
			}
			row.Counter1 = ConvertIntArray(array[i][9]);
			row.Counter2 = ConvertIntArray(array[i][10]);
			row.Counter3 = ConvertIntArray(array[i][11]);
			row.Text = ConvertIntArray(array[i][12]);
			row.MessagePosition = ConvertIntArray(array[i][13]);
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

	public Row Find_Layer(MessageLayer find)
	{
		if (!_cacheLayer.TryGetValue(find, out var value))
		{
			return _cacheLayer[find] = rowList.Find((Row x) => x.Layer == find);
		}
		return value;
	}

	public List<Row> FindAll_Layer(MessageLayer find)
	{
		if (!_cacheAllLayer.TryGetValue(find, out var value))
		{
			return _cacheAllLayer[find] = rowList.FindAll((Row x) => x.Layer == find);
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

	public Row Find_Anim(AnimEnum find)
	{
		if (!_cacheAnim.TryGetValue(find, out var value))
		{
			return _cacheAnim[find] = rowList.Find((Row x) => x.Anim == find);
		}
		return value;
	}

	public List<Row> FindAll_Anim(AnimEnum find)
	{
		if (!_cacheAllAnim.TryGetValue(find, out var value))
		{
			return _cacheAllAnim[find] = rowList.FindAll((Row x) => x.Anim == find);
		}
		return value;
	}

	public Row Find_CounterType(CounterTypeEnum find)
	{
		if (!_cacheCounterType.TryGetValue(find, out var value))
		{
			return _cacheCounterType[find] = rowList.Find((Row x) => x.CounterType == find);
		}
		return value;
	}

	public List<Row> FindAll_CounterType(CounterTypeEnum find)
	{
		if (!_cacheAllCounterType.TryGetValue(find, out var value))
		{
			return _cacheAllCounterType[find] = rowList.FindAll((Row x) => x.CounterType == find);
		}
		return value;
	}

	public Row Find_Counter1(int[] find)
	{
		if (!_cacheCounter1.TryGetValue(find, out var value))
		{
			return _cacheCounter1[find] = rowList.Find((Row x) => x.Counter1 == find);
		}
		return value;
	}

	public List<Row> FindAll_Counter1(int[] find)
	{
		if (!_cacheAllCounter1.TryGetValue(find, out var value))
		{
			return _cacheAllCounter1[find] = rowList.FindAll((Row x) => x.Counter1 == find);
		}
		return value;
	}

	public Row Find_Counter2(int[] find)
	{
		if (!_cacheCounter2.TryGetValue(find, out var value))
		{
			return _cacheCounter2[find] = rowList.Find((Row x) => x.Counter2 == find);
		}
		return value;
	}

	public List<Row> FindAll_Counter2(int[] find)
	{
		if (!_cacheAllCounter2.TryGetValue(find, out var value))
		{
			return _cacheAllCounter2[find] = rowList.FindAll((Row x) => x.Counter2 == find);
		}
		return value;
	}

	public Row Find_Counter3(int[] find)
	{
		if (!_cacheCounter3.TryGetValue(find, out var value))
		{
			return _cacheCounter3[find] = rowList.Find((Row x) => x.Counter3 == find);
		}
		return value;
	}

	public List<Row> FindAll_Counter3(int[] find)
	{
		if (!_cacheAllCounter3.TryGetValue(find, out var value))
		{
			return _cacheAllCounter3[find] = rowList.FindAll((Row x) => x.Counter3 == find);
		}
		return value;
	}

	public Row Find_Text(int[] find)
	{
		if (!_cacheText.TryGetValue(find, out var value))
		{
			return _cacheText[find] = rowList.Find((Row x) => x.Text == find);
		}
		return value;
	}

	public List<Row> FindAll_Text(int[] find)
	{
		if (!_cacheAllText.TryGetValue(find, out var value))
		{
			return _cacheAllText[find] = rowList.FindAll((Row x) => x.Text == find);
		}
		return value;
	}
}
