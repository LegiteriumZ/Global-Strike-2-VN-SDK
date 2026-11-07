using NetData;
using SSJJBase.Pool;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class SetValueAdapter
{
	public class SetValueData
	{
		public int SetValueInt;

		public string SetValueStr;

		public int SetValueBool;

		public float SetValueFloat;

		public double SetValueDouble;

		public long SetValueLong;

		public SimpleProto SetValueProto;

		public void Reset()
		{
			SetValueInt = 999999;
			SetValueBool = 999999;
			SetValueStr = "99999";
			SetValueFloat = 999999f;
			SetValueDouble = 999999.0;
			SetValueLong = 999999L;
			SetValueProto = null;
		}

		public override string ToString()
		{
			if (SetValueInt != 999999)
			{
				return StringCache.IntToString(SetValueInt);
			}
			if (SetValueLong != 999999)
			{
				return SetValueLong.ToString();
			}
			if (SetValueBool != 999999)
			{
				if (SetValueBool == 1)
				{
					return "true";
				}
				return "false";
			}
			if (!SetValueStr.Equals("999999"))
			{
				return SetValueStr;
			}
			if (!Mathf.Approximately(SetValueFloat, 999999f))
			{
				return SetValueFloat.ToString();
			}
			if (!Mathf.Approximately((float)SetValueDouble, 999999f))
			{
				return SetValueDouble.ToString();
			}
			if (SetValueProto != null)
			{
				return SetValueProto.ToString();
			}
			return "";
		}
	}

	private readonly StackObjectPool<SetValueData> _valueDataPool = new StackObjectPool<SetValueData>();

	private static SetValueAdapter _instance;

	public static SetValueAdapter Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SetValueAdapter();
			}
			return _instance;
		}
	}

	public SetValueData GetData()
	{
		SetValueData setValueData = _valueDataPool.GetOrNull();
		if (setValueData == null)
		{
			setValueData = new SetValueData();
		}
		setValueData.Reset();
		return setValueData;
	}

	public void Release(SetValueData a, SetValueData b)
	{
		_valueDataPool.Add(a);
		_valueDataPool.Add(b);
	}
}
