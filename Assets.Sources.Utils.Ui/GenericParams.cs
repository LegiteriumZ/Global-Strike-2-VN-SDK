using System;
using System.Collections.Generic;
using System.Text;
using CommonUtils;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

public sealed class GenericParams : AbstractParams, IEquatable<GenericParams>
{
	private sealed class ParamsList<T>
	{
		private List<T> _list;

		public int Count
		{
			get
			{
				if (_list != null)
				{
					return _list.Count;
				}
				return 0;
			}
		}

		public T this[int index]
		{
			get
			{
				return _list[index];
			}
			set
			{
				_list[index] = value;
			}
		}

		public ParamsList()
		{
			_list = new List<T>(4);
		}

		public void Reset()
		{
		}

		public void Clear()
		{
			_list.Clear();
		}

		public void Insert(int index, T item)
		{
			_list.Insert(index, item);
		}

		public void Add(T item)
		{
			_list.Add(item);
		}

		public void Remove(T item)
		{
			_list.Remove(item);
		}
	}

	private static StackObjectPool<GenericParams> _pool = new StackObjectPool<GenericParams>();

	private ParamsList<int> intList;

	private ParamsList<short> shortlist;

	private ParamsList<bool> boollist;

	private ParamsList<string> strlist;

	private ParamsList<long> longList;

	private ParamsList<float> floatList;

	private ParamsList<double> doubleList;

	private ParamsList<Vector3> vector3List;

	private ParamsList<Color> colorList;

	private ParamsList<object> objList;

	private ParamsList<UnityEngine.Object> UnityObjList;

	private List<KeyValuePair<int, int>> ArgSortList = new List<KeyValuePair<int, int>>();

	private static GenericParams PreCreate(int origion = -1)
	{
		return new GenericParams
		{
			OriginArgCount = origion
		};
	}

	public static GenericParams Create(int origion = -1)
	{
		GenericParams genericParams = _pool.GetOrNull();
		if (genericParams == null)
		{
			genericParams = new GenericParams();
		}
		if (origion != -1)
		{
			genericParams.OriginArgCount = origion;
		}
		genericParams.ResetReadIndex();
		return genericParams;
	}

	public override void Release()
	{
		PoolIncreased();
		_pool.Add(this);
	}

	public override void PoolIncreased()
	{
		if (intList != null)
		{
			intList.Reset();
			intList.Clear();
		}
		if (shortlist != null)
		{
			shortlist.Reset();
			shortlist.Clear();
		}
		if (boollist != null)
		{
			boollist.Reset();
			boollist.Clear();
		}
		if (strlist != null)
		{
			strlist.Reset();
			strlist.Clear();
		}
		if (longList != null)
		{
			longList.Reset();
			longList.Clear();
		}
		if (objList != null)
		{
			objList.Reset();
			objList.Clear();
		}
		if (UnityObjList != null)
		{
			UnityObjList.Reset();
			UnityObjList.Clear();
		}
		if (floatList != null)
		{
			floatList.Reset();
			floatList.Clear();
		}
		if (doubleList != null)
		{
			doubleList.Reset();
			doubleList.Clear();
		}
		ArgSortList.Clear();
		base.ArgCount = 0;
		VirtualArg = 0;
		OriginArgCount = -1;
		NextReadIndex = 0;
	}

	public override AbstractParams InsertInt(int index, int v)
	{
		if (intList == null)
		{
			intList = new ParamsList<int>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			intList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(1, intList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			intList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(1, intList.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertShort(int index, short v)
	{
		if (shortlist == null)
		{
			shortlist = new ParamsList<short>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			shortlist.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(2, shortlist.Count - 1));
		}
		else
		{
			base.ArgCount++;
			shortlist.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(2, shortlist.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertString(int index, string v)
	{
		if (strlist == null)
		{
			strlist = new ParamsList<string>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			strlist.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(4, strlist.Count - 1));
		}
		else
		{
			base.ArgCount++;
			strlist.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(4, strlist.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertBool(int index, bool v)
	{
		if (boollist == null)
		{
			boollist = new ParamsList<bool>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			boollist.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(3, boollist.Count - 1));
		}
		else
		{
			base.ArgCount++;
			boollist.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(3, boollist.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertFloat(int index, float v)
	{
		if (floatList == null)
		{
			floatList = new ParamsList<float>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			floatList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(6, floatList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			floatList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(6, floatList.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertDouble(int index, double v)
	{
		if (doubleList == null)
		{
			doubleList = new ParamsList<double>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			doubleList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(7, doubleList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			doubleList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(7, doubleList.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertLong(int index, long v)
	{
		if (longList == null)
		{
			longList = new ParamsList<long>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			longList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(5, longList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			longList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(5, longList.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertVector3(int index, Vector3 v)
	{
		if (vector3List == null)
		{
			vector3List = new ParamsList<Vector3>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			vector3List.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(8, vector3List.Count - 1));
		}
		else
		{
			base.ArgCount++;
			vector3List.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(8, vector3List.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertColor(int index, Color v)
	{
		if (colorList == null)
		{
			colorList = new ParamsList<Color>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			colorList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(11, colorList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			colorList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(11, colorList.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertObject(int index, object v)
	{
		if (objList == null)
		{
			objList = new ParamsList<object>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			objList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(9, objList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			objList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(9, objList.Count - 1));
		}
		return this;
	}

	public override AbstractParams InsertUnityObject(int index, UnityEngine.Object v)
	{
		if (UnityObjList == null)
		{
			UnityObjList = new ParamsList<UnityEngine.Object>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			OriginArgCount++;
			UnityObjList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(10, UnityObjList.Count - 1));
		}
		else
		{
			base.ArgCount++;
			UnityObjList.Add(v);
			ArgSortList.Insert(index, new KeyValuePair<int, int>(10, UnityObjList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteInt(int v)
	{
		if (intList == null)
		{
			intList = new ParamsList<int>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetInt(v);
			}
			else
			{
				intList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(1, intList.Count - 1));
			}
		}
		else
		{
			intList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(1, intList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteShort(short v)
	{
		if (shortlist == null)
		{
			shortlist = new ParamsList<short>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetShort(v);
			}
			else
			{
				shortlist.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(2, shortlist.Count - 1));
			}
		}
		else
		{
			shortlist.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(2, shortlist.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteBool(bool v)
	{
		if (boollist == null)
		{
			boollist = new ParamsList<bool>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetBool(v);
			}
			else
			{
				boollist.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(3, boollist.Count - 1));
			}
		}
		else
		{
			boollist.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(3, boollist.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteString(string v)
	{
		if (strlist == null)
		{
			strlist = new ParamsList<string>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetString(v);
			}
			else
			{
				strlist.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(4, strlist.Count - 1));
			}
		}
		else
		{
			strlist.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(4, strlist.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteLong(long v)
	{
		if (longList == null)
		{
			longList = new ParamsList<long>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetLong(v);
			}
			else
			{
				longList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(5, longList.Count - 1));
			}
		}
		else
		{
			longList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(5, longList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteColor(Color v)
	{
		if (colorList == null)
		{
			colorList = new ParamsList<Color>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetColor(v);
			}
			else
			{
				colorList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(11, colorList.Count - 1));
			}
		}
		else
		{
			colorList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(11, colorList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteVector3(Vector3 v)
	{
		if (vector3List == null)
		{
			vector3List = new ParamsList<Vector3>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetVector3(v);
			}
			else
			{
				vector3List.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(8, vector3List.Count - 1));
			}
		}
		else
		{
			vector3List.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(8, vector3List.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteObject(object v)
	{
		if (objList == null)
		{
			objList = new ParamsList<object>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetObject(v);
			}
			else
			{
				objList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(9, objList.Count - 1));
			}
		}
		else
		{
			objList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(9, objList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteUnityObject(UnityEngine.Object v)
	{
		if (UnityObjList == null)
		{
			UnityObjList = new ParamsList<UnityEngine.Object>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetUnityObj(v);
			}
			else
			{
				UnityObjList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(10, UnityObjList.Count - 1));
			}
		}
		else
		{
			UnityObjList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(10, UnityObjList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteDouble(double v)
	{
		if (doubleList == null)
		{
			doubleList = new ParamsList<double>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetUnityObj(v);
			}
			else
			{
				doubleList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(7, doubleList.Count - 1));
			}
		}
		else
		{
			doubleList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(7, doubleList.Count - 1));
		}
		return this;
	}

	public override AbstractParams WriteFloat(float v)
	{
		if (floatList == null)
		{
			floatList = new ParamsList<float>();
		}
		if (OriginArgCount >= 0)
		{
			base.ArgCount++;
			VirtualArg++;
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				_VirtualsetUnityObj(v);
			}
			else
			{
				floatList.Add(v);
				ArgSortList.Add(new KeyValuePair<int, int>(6, floatList.Count - 1));
			}
		}
		else
		{
			floatList.Add(v);
			base.ArgCount++;
			ArgSortList.Add(new KeyValuePair<int, int>(6, floatList.Count - 1));
		}
		return this;
	}

	private void _VirtualsetShort(short v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 2)
		{
			shortlist[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非Short类型 ");
		}
	}

	private void _VirtualsetBool(bool v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 3)
		{
			boollist[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非bool类型 ");
		}
	}

	private void _VirtualsetInt(int v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		if (ArgSortList[index].Key == 1)
		{
			intList[ArgSortList[index].Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非Int类型 ");
		}
	}

	private void _VirtualsetString(string v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 4)
		{
			strlist[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非string类型 ");
		}
	}

	private void _VirtualsetLong(long v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 5)
		{
			longList[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非Long类型 ");
		}
	}

	private void _VirtualsetColor(Color v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 11)
		{
			colorList[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非Color类型 ");
		}
	}

	private void _VirtualsetVector3(Vector3 v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 8)
		{
			vector3List[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非Vector3类型 ");
		}
	}

	private void _VirtualsetObject(object v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 9)
		{
			objList[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非Object类型 ");
		}
	}

	private void _VirtualsetUnityObj(UnityEngine.Object v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 10)
		{
			UnityObjList[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非UnityObject类型 ");
		}
	}

	private void _VirtualsetUnityObj(float v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 6)
		{
			floatList[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非float类型 ");
		}
	}

	private void _VirtualsetUnityObj(double v)
	{
		int index = (VirtualArg - 1) % OriginArgCount;
		KeyValuePair<int, int> keyValuePair = ArgSortList[index];
		if (keyValuePair.Key == 7)
		{
			doubleList[keyValuePair.Value] = v;
		}
		else
		{
			ThrowError("参数类型错误 此为非double类型 ");
		}
	}

	public override AbstractParams SetInt(int argIndex, int v)
	{
		if (argIndex < ArgSortList.Count)
		{
			if (ArgSortList[argIndex].Key == 1)
			{
				if (intList == null)
				{
					ThrowError("参数列表为空");
				}
				else if (intList != null && ArgSortList[argIndex].Value >= intList.Count)
				{
					ThrowError("参数索引错误");
				}
				else
				{
					intList[ArgSortList[argIndex].Value] = v;
				}
			}
			else
			{
				ThrowError("参数类型错误 此为非Int类型 ");
			}
		}
		else
		{
			ThrowError("参数索引错误");
		}
		return this;
	}

	public override AbstractParams SetShort(int argIndex, short v)
	{
		if (argIndex < ArgSortList.Count)
		{
			if (ArgSortList[argIndex].Key == 2)
			{
				if (shortlist == null)
				{
					ThrowError("参数列表为空");
				}
				else if (shortlist != null && ArgSortList[argIndex].Value >= shortlist.Count)
				{
					ThrowError("参数索引错误");
				}
				else
				{
					shortlist[ArgSortList[argIndex].Value] = v;
				}
			}
			else
			{
				ThrowError("参数类型错误 此为非short类型 ");
			}
		}
		else
		{
			ThrowError("参数索引错误");
		}
		return this;
	}

	public override AbstractParams SetBool(int argIndex, bool v)
	{
		if (GetArgIndexType(argIndex) == 3)
		{
			if (boollist == null)
			{
				ThrowError("参数列表为空");
			}
			else if (boollist != null && ArgSortList[argIndex].Value >= boollist.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				boollist[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非bool类型 ");
		}
		return this;
	}

	public override AbstractParams SetString(int argIndex, string v)
	{
		if (GetArgIndexType(argIndex) == 4)
		{
			if (strlist == null)
			{
				ThrowError("参数列表为空");
			}
			else if (strlist != null && ArgSortList[argIndex].Value >= strlist.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				strlist[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非string类型 ");
		}
		return this;
	}

	public override AbstractParams SetLong(int argIndex, long v)
	{
		if (GetArgIndexType(argIndex) == 5)
		{
			if (longList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (longList != null && ArgSortList[argIndex].Value >= longList.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				longList[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非long类型 ");
		}
		return this;
	}

	public override AbstractParams SetVector3(int argIndex, Vector3 v)
	{
		if (GetArgIndexType(argIndex) == 8)
		{
			if (objList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (vector3List != null && ArgSortList[argIndex].Value >= vector3List.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				vector3List[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非Vector3类型 ");
		}
		return this;
	}

	public override AbstractParams SetColor(int argIndex, Color v)
	{
		if (GetArgIndexType(argIndex) == 11)
		{
			if (objList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (colorList != null && ArgSortList[argIndex].Value >= colorList.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				colorList[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非Color类型 ");
		}
		return this;
	}

	public override AbstractParams SetObject(int argIndex, object v)
	{
		if (GetArgIndexType(argIndex) == 9)
		{
			if (objList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (objList != null && ArgSortList[argIndex].Value >= objList.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				objList[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非object类型 ");
		}
		return this;
	}

	public override AbstractParams SetUnityObject(int argIndex, UnityEngine.Object v)
	{
		if (GetArgIndexType(argIndex) == 10)
		{
			if (UnityObjList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (UnityObjList != null && ArgSortList[argIndex].Value >= UnityObjList.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				UnityObjList[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非UnityObject类型 ");
		}
		return this;
	}

	public override AbstractParams SetFloat(int argIndex, float v)
	{
		if (GetArgIndexType(argIndex) == 6)
		{
			if (floatList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (floatList != null && ArgSortList[argIndex].Value >= floatList.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				floatList[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非float类型 ");
		}
		return this;
	}

	public override AbstractParams SetDouble(int argIndex, double v)
	{
		if (GetArgIndexType(argIndex) == 7)
		{
			if (doubleList == null)
			{
				ThrowError("参数列表为空");
			}
			else if (doubleList != null && ArgSortList[argIndex].Value >= doubleList.Count)
			{
				ThrowError("参数索引错误");
			}
			else
			{
				doubleList[ArgSortList[argIndex].Value] = v;
			}
		}
		else
		{
			ThrowError("参数类型错误 此为非UnityObject类型 ");
		}
		return this;
	}

	private void _ResetAll()
	{
		if (intList != null)
		{
			intList.Reset();
		}
		if (shortlist != null)
		{
			shortlist.Reset();
		}
		if (boollist != null)
		{
			boollist.Reset();
		}
		if (strlist != null)
		{
			strlist.Reset();
		}
		if (longList != null)
		{
			longList.Reset();
		}
		if (objList != null)
		{
			objList.Reset();
		}
		if (UnityObjList != null)
		{
			UnityObjList.Reset();
		}
		NextReadIndex = 0;
	}

	private void _IncreateIndex()
	{
		NextReadIndex++;
		NextReadIndex %= base.ArgCount + 1;
		if (NextReadIndex == 0)
		{
			_ResetAll();
		}
	}

	public override void ResetReadIndex()
	{
		_ResetAll();
	}

	public override int NextValue()
	{
		if (NextReadIndex >= ArgSortList.Count)
		{
			return 0;
		}
		return ArgSortList[NextReadIndex].Key;
	}

	public override int ReadInt()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 1)
			{
				if (intList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return intList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		ThrowError("参数数量不足");
		return 0;
	}

	private void ThrowError(string info)
	{
		throw new ArgumentException(info);
	}

	public override short ReadShort()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 2)
			{
				if (shortlist == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return shortlist[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return 0;
	}

	public override float ReadFloat()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 6)
			{
				if (floatList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return floatList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return 0f;
	}

	public override double ReadDouble()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 7)
			{
				if (doubleList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return doubleList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return 0.0;
	}

	public override bool ReadBool()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 3)
			{
				if (boollist == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return boollist[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return false;
	}

	public override string ReadString()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 4)
			{
				if (strlist == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return strlist[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return "";
	}

	public override long ReadLong()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 5)
			{
				if (longList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return longList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return 0L;
	}

	public override Vector3 ReadVector3()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 8)
			{
				if (vector3List == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return vector3List[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return Vector3.zero;
	}

	public override Color ReadColor()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 11)
			{
				if (colorList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return colorList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return Color.white;
	}

	public override object ReadObject()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 9)
			{
				if (objList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return objList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return null;
	}

	public override UnityEngine.Object ReadUnityObject()
	{
		if (NextReadIndex < ArgSortList.Count)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[NextReadIndex];
			if (keyValuePair.Key == 10)
			{
				if (UnityObjList == null)
				{
					ThrowError("参数列表为空");
				}
				else
				{
					_IncreateIndex();
				}
				return UnityObjList[keyValuePair.Value];
			}
			ThrowError("参数类型不匹配");
		}
		else
		{
			ThrowError("参数数量不足");
		}
		return null;
	}

	public override int GetArgIndexType(int index)
	{
		if (index < ArgSortList.Count)
		{
			return ArgSortList[index].Key;
		}
		return -1;
	}

	public bool Equals(GenericParams other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (EqualList(intList, other.intList) && EqualList(shortlist, other.shortlist) && EqualList(boollist, other.boollist) && EqualList(strlist, other.strlist) && EqualList(longList, other.longList) && EqualList(floatList, other.floatList) && EqualList(doubleList, other.doubleList) && EqualList(vector3List, other.vector3List) && EqualList(colorList, other.colorList) && EqualList(objList, other.objList))
		{
			return EqualList(UnityObjList, other.UnityObjList);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is GenericParams)
		{
			return Equals((GenericParams)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int code = 37;
		code = ((intList != null) ? GetCode(code, intList) : 0);
		code = (code * 397) ^ ((shortlist != null) ? GetCode(code, shortlist) : 0);
		code = (code * 397) ^ ((boollist != null) ? GetCode(code, boollist) : 0);
		code = (code * 397) ^ ((strlist != null) ? GetCode(code, strlist) : 0);
		code = (code * 397) ^ ((longList != null) ? GetCode(code, longList) : 0);
		code = (code * 397) ^ ((floatList != null) ? GetCode(code, floatList) : 0);
		code = (code * 397) ^ ((doubleList != null) ? GetCode(code, doubleList) : 0);
		code = (code * 397) ^ ((vector3List != null) ? GetCode(code, vector3List) : 0);
		code = (code * 397) ^ ((colorList != null) ? GetCode(code, colorList) : 0);
		code = (code * 397) ^ ((objList != null) ? GetCode(code, objList) : 0);
		return (code * 397) ^ ((UnityObjList != null) ? GetCode(code, UnityObjList) : 0);
	}

	private bool EqualList<T>(ParamsList<T> left, ParamsList<T> right) where T : IEquatable<T>
	{
		if ((left == null && right != null) || (left != null && right == null))
		{
			return false;
		}
		if (left == null && right == null)
		{
			return true;
		}
		if (left.Count != right.Count)
		{
			return false;
		}
		for (int i = 0; i < left.Count; i++)
		{
			if (!left[i].Equals(right[i]))
			{
				return false;
			}
		}
		return true;
	}

	private bool EqualList(ParamsList<Vector3> left, ParamsList<Vector3> right)
	{
		if ((left == null && right != null) || (left != null && right == null))
		{
			return false;
		}
		if (left == null && right == null)
		{
			return true;
		}
		if (left.Count != right.Count)
		{
			return false;
		}
		for (int i = 0; i < left.Count; i++)
		{
			if (left[i] != right[i])
			{
				return false;
			}
		}
		return true;
	}

	private bool EqualList(ParamsList<Color> left, ParamsList<Color> right)
	{
		if ((left == null && right != null) || (left != null && right == null))
		{
			return false;
		}
		if (left == null && right == null)
		{
			return true;
		}
		if (left.Count != right.Count)
		{
			return false;
		}
		for (int i = 0; i < left.Count; i++)
		{
			if (left[i] != right[i])
			{
				return false;
			}
		}
		return true;
	}

	private bool EqualList(ParamsList<UnityEngine.Object> left, ParamsList<UnityEngine.Object> right)
	{
		if ((left == null && right != null) || (left != null && right == null))
		{
			return false;
		}
		if (left == null && right == null)
		{
			return true;
		}
		if (left.Count != right.Count)
		{
			return false;
		}
		for (int i = 0; i < left.Count; i++)
		{
			if (left[i] != right[i])
			{
				return false;
			}
		}
		return true;
	}

	private bool EqualList(ParamsList<object> left, ParamsList<object> right)
	{
		if ((left == null && right != null) || (left != null && right == null))
		{
			return false;
		}
		if (left == null && right == null)
		{
			return true;
		}
		if (left.Count != right.Count)
		{
			return false;
		}
		for (int i = 0; i < left.Count; i++)
		{
			if (left[i] != right[i])
			{
				return false;
			}
		}
		return true;
	}

	private int GetCode<T>(int code, ParamsList<T> list)
	{
		if (list == null)
		{
			return (code * 397) ^ 0;
		}
		for (int i = 0; i < list.Count; i++)
		{
			code = (code * 397) ^ list[i].GetHashCode();
		}
		return code;
	}

	public static bool operator ==(GenericParams left, GenericParams right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(GenericParams left, GenericParams right)
	{
		return !object.Equals(left, right);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} 参数个数: {1} ", base.ToString(), base.ArgCount.ToString());
		for (int i = 0; i < ArgSortList.Count; i++)
		{
			KeyValuePair<int, int> keyValuePair = ArgSortList[i];
			if (keyValuePair.Key == 1)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, intList[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 2)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, shortlist[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 3)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, boollist[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 7)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, doubleList[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 6)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, floatList[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 0)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, "空");
			}
			else if (keyValuePair.Key == 4)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, strlist[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 5)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, longList[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 8)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, vector3List[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 9)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, objList[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 10)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, UnityObjList[keyValuePair.Value]);
			}
			else if (keyValuePair.Key == 11)
			{
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, colorList[keyValuePair.Value]);
			}
			else
			{
				DebugLogger.LogError("未增加的类型");
			}
		}
		return stringBuilder.ToString();
	}
}
