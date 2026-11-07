using System;
using System.Text;
using CommonUtils;
using SSJJBase.Pool;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

public class SimpleParams : AbstractParams, IEquatable<SimpleParams>
{
	private static StackObjectPool<SimpleParams> _pool = new StackObjectPool<SimpleParams>();

	private long bitIndex;

	private long bitDataSort;

	private long? m_l1;

	private long? m_l2;

	private long? m_l3;

	private int? m_i1;

	private int? m_i2;

	private int? m_i3;

	private short? m_st1;

	private short? m_st2;

	private short? m_st3;

	private bool? m_b1;

	private bool? m_b2;

	private bool? m_b3;

	private string m_string1;

	private string m_string2;

	private string m_string3;

	private float? m_f1;

	private float? m_f2;

	private float? m_f3;

	private double? m_d1;

	private double? m_d2;

	private double? m_d3;

	private Vector3? m_v1;

	private Vector3? m_v2;

	private Vector3? m_v3;

	private Color? m_c1;

	private Color? m_c2;

	private Color? m_c3;

	private object m_o1;

	private object m_o2;

	private object m_o3;

	private UnityEngine.Object m_uo1;

	private UnityEngine.Object m_uo2;

	private UnityEngine.Object m_uo3;

	private static SimpleParams PreCreate(int origion = -1)
	{
		return new SimpleParams
		{
			OriginArgCount = origion,
			VirtualArg = 0,
			LimitMax = 16
		};
	}

	public static SimpleParams Create()
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		return simpleParams;
	}

	public static SimpleParams Create<T>(T arg1) where T : class
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		if (arg1 is UnityEngine.Object)
		{
			simpleParams.WriteUnityObject(arg1 as UnityEngine.Object);
		}
		else
		{
			simpleParams.WriteObject(arg1);
		}
		return simpleParams;
	}

	public static SimpleParams Create(int arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteInt(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(short arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteShort(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(long arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteLong(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(float arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteFloat(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(string arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteString(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(bool arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteBool(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(double arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteDouble(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(Color arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteColor(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(Vector3 arg1)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteVector3(arg1);
		return simpleParams;
	}

	public static SimpleParams Create(string arg1, string arg2)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteString(arg1);
		simpleParams.WriteString(arg2);
		return simpleParams;
	}

	public static SimpleParams Create(string arg1, int arg2)
	{
		SimpleParams simpleParams = _pool.GetOrNull();
		if (simpleParams == null)
		{
			simpleParams = new SimpleParams();
		}
		simpleParams.ResetReadIndex();
		simpleParams.LimitMax = 16;
		simpleParams.WriteString(arg1);
		simpleParams.WriteInt(arg2);
		return simpleParams;
	}

	private SimpleParams()
	{
	}

	public override void Release()
	{
		PoolIncreased();
		_pool.Add(this);
	}

	public override void PoolIncreased()
	{
		m_l1 = null;
		m_l2 = null;
		m_l3 = null;
		m_i1 = null;
		m_i2 = null;
		m_i2 = null;
		m_st1 = null;
		m_st2 = null;
		m_st3 = null;
		m_string1 = null;
		m_string2 = null;
		m_string3 = null;
		m_b1 = null;
		m_b2 = null;
		m_b3 = null;
		m_f1 = null;
		m_f2 = null;
		m_f3 = null;
		m_c1 = null;
		m_c2 = null;
		m_c3 = null;
		m_d1 = null;
		m_d2 = null;
		m_d3 = null;
		m_v1 = null;
		m_v2 = null;
		m_v3 = null;
		m_o1 = null;
		m_o2 = null;
		m_o3 = null;
		m_uo1 = null;
		m_uo2 = null;
		m_uo3 = null;
		base.ArgCount = 0;
		VirtualArg = 0;
		NextReadIndex = 0;
		OriginArgCount = -1;
		bitIndex = 0L;
		bitDataSort = 0L;
	}

	public override int GetHashCode()
	{
		int hashCode = 0;
		GetCode(ref m_i1, ref hashCode);
		GetCode(ref m_i2, ref hashCode);
		GetCode(ref m_i3, ref hashCode);
		GetCode(ref m_l1, ref hashCode);
		GetCode(ref m_l2, ref hashCode);
		GetCode(ref m_l3, ref hashCode);
		GetCode(ref m_f1, ref hashCode);
		GetCode(ref m_f2, ref hashCode);
		GetCode(ref m_f3, ref hashCode);
		GetCode(ref m_b1, ref hashCode);
		GetCode(ref m_b2, ref hashCode);
		GetCode(ref m_b3, ref hashCode);
		GetCode(ref m_st1, ref hashCode);
		GetCode(ref m_st2, ref hashCode);
		GetCode(ref m_st3, ref hashCode);
		GetCode(ref m_d1, ref hashCode);
		GetCode(ref m_d2, ref hashCode);
		GetCode(ref m_d3, ref hashCode);
		GetCode(m_string1, ref hashCode);
		GetCode(m_string2, ref hashCode);
		GetCode(m_string3, ref hashCode);
		GetCode(ref m_v1, ref hashCode);
		GetCode(ref m_v2, ref hashCode);
		GetCode(ref m_v3, ref hashCode);
		GetCode(ref m_c1, ref hashCode);
		GetCode(ref m_c2, ref hashCode);
		GetCode(ref m_c3, ref hashCode);
		GetClsCode(m_o1, ref hashCode);
		GetClsCode(m_o2, ref hashCode);
		GetClsCode(m_o3, ref hashCode);
		GetClsCode(m_uo1, ref hashCode);
		GetClsCode(m_uo2, ref hashCode);
		GetClsCode(m_uo3, ref hashCode);
		return hashCode;
	}

	private void GetCode(string data, ref int hashCode)
	{
		hashCode = (hashCode * 397) ^ ((!string.IsNullOrEmpty(data)) ? data.GetHashCode() : 0);
	}

	private void GetCode<T>(ref T? data, ref int hashCode) where T : struct
	{
		hashCode = (hashCode * 397) ^ (data.HasValue ? data.GetHashCode() : 0);
	}

	private void GetClsCode<T>(T data, ref int hashCode) where T : class
	{
		hashCode = (hashCode * 397) ^ (data?.GetHashCode() ?? 0);
	}

	public bool Equals(SimpleParams other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (m_i1 == other.m_i1 && m_i2 == other.m_i2 && m_i3 == other.m_i3 && m_l1 == other.m_l1 && m_l2 == other.m_l2 && m_l3 == other.m_l3 && m_st1 == other.m_st1 && m_st2 == other.m_st2 && m_st3 == other.m_st3 && m_string1 == other.m_string1 && m_string2 == other.m_string2 && m_string3 == other.m_string3 && m_b1 == other.m_b1 && m_b2 == other.m_b2 && m_b3 == other.m_b3 && m_f1 == other.m_f1 && m_f2 == other.m_f2 && m_f3 == other.m_f3 && m_v1 == other.m_v1)
		{
			Vector3? v = m_v2;
			Vector3? v2 = other.m_v2;
			if (v.HasValue == v2.HasValue && (!v.HasValue || v.GetValueOrDefault() == v2.GetValueOrDefault()) && m_v3 == other.m_v3)
			{
				Color? c = m_c1;
				Color? c2 = other.m_c1;
				if (c.HasValue == c2.HasValue && (!c.HasValue || c.GetValueOrDefault() == c2.GetValueOrDefault()) && m_c2 == other.m_c2)
				{
					c = m_c3;
					c2 = other.m_c3;
					if (c.HasValue == c2.HasValue && (!c.HasValue || c.GetValueOrDefault() == c2.GetValueOrDefault()) && m_o1 == other.m_o1 && m_o2 == other.m_o2 && m_o3 == other.m_o3 && m_uo1 == other.m_uo1 && m_uo2 == other.m_uo2 && m_uo3 == other.m_uo3 && m_d1 == other.m_d1 && m_d2 == other.m_d2)
					{
						return m_d3 == other.m_d3;
					}
				}
			}
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is SimpleParams)
		{
			return Equals((SimpleParams)obj);
		}
		return false;
	}

	private long _ReadIndex(int ReadIndex, out int index)
	{
		long result = (bitDataSort & (15 << 4 * ReadIndex)) >> 4 * ReadIndex;
		long num = bitIndex & (3 << 2 * ReadIndex);
		index = (int)(num >> 2 * ReadIndex);
		return result;
	}

	private long _ReadNextTp(out int index)
	{
		if (NextReadIndex >= base.ArgCount)
		{
			NextReadIndex = base.ArgCount - 1;
			index = -1;
			return 0L;
		}
		long result = _ReadIndex(NextReadIndex, out index);
		if (base.ArgCount != 0)
		{
			NextReadIndex++;
		}
		return result;
	}

	private void _SetNextTp(long tp, long index)
	{
		if (index > 4 || index < 0)
		{
			ThrowError("参数索引错误");
			return;
		}
		if (base.ArgCount + 1 > LimitMax)
		{
			ThrowError("参数过多");
			return;
		}
		int argCount = base.ArgCount;
		base.ArgCount++;
		if (OriginArgCount > -1)
		{
			if (OriginArgCount < base.ArgCount)
			{
				base.ArgCount = OriginArgCount;
				return;
			}
			bitDataSort |= tp << 4 * argCount;
			bitIndex |= index << 2 * argCount;
		}
		else
		{
			bitDataSort |= tp << 4 * argCount;
			bitIndex |= index << 2 * argCount;
		}
	}

	private long _insertBit(long orig, int databit, int index, int tpval)
	{
		if (index == 0)
		{
			return orig * _MyPow(2L, databit) + tpval;
		}
		long num = _MyPow(2L, databit * index) - 1;
		long num2 = orig & num;
		return ((orig & ~num) + tpval) * (num + 1) + num2;
	}

	public override AbstractParams InsertInt(int index, int v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 1)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 1);
		switch (num)
		{
		case 0:
			m_i1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_i2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_i3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertShort(int index, short v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 2)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 2);
		switch (num)
		{
		case 0:
			m_st1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_st2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_st3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertString(int index, string v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 4)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 4);
		switch (num)
		{
		case 0:
			m_string1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_string2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_string3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertBool(int index, bool v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 3)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 3);
		switch (num)
		{
		case 0:
			m_b1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_b2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_b3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertFloat(int index, float v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 6)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 6);
		switch (num)
		{
		case 0:
			m_f1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_f2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_f3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertDouble(int index, double v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 7)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 7);
		switch (num)
		{
		case 0:
			m_d1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_d2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_d3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertLong(int index, long v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 5)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 5);
		switch (num)
		{
		case 0:
			m_l1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_l2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_l3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertVector3(int index, Vector3 v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 8)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 8);
		switch (num)
		{
		case 0:
			m_v1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_v2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_v3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertColor(int index, Color v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 11)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 11);
		switch (num)
		{
		case 0:
			m_c1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_c2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_c3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertObject(int index, object v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 9)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 9);
		switch (num)
		{
		case 0:
			m_o1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_o2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_o3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override AbstractParams InsertUnityObject(int index, UnityEngine.Object v)
	{
		if (OriginArgCount > 0)
		{
			OriginArgCount++;
		}
		short num = 0;
		for (int i = 0; i < base.ArgCount; i++)
		{
			if (GetArgIndexType(i) == 10)
			{
				num++;
			}
		}
		bitDataSort = _insertBit(bitDataSort, 4, index, 10);
		switch (num)
		{
		case 0:
			m_uo1 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 0);
			base.ArgCount++;
			break;
		case 1:
			m_uo2 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 1);
			base.ArgCount++;
			break;
		case 2:
			m_uo3 = v;
			bitIndex = _insertBit(bitIndex, 2, index, 2);
			base.ArgCount++;
			break;
		default:
			ThrowUseGener();
			break;
		}
		return this;
	}

	public override int NextValue()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		NextReadIndex = nextReadIndex;
		return (int)num;
	}

	private void ThrowError(string info)
	{
		throw new ArgumentException(info);
	}

	public override int ReadInt()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 1)
		{
			switch (index)
			{
			case 0:
				if (m_i1.HasValue)
				{
					return m_i1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_i2.HasValue)
				{
					return m_i2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_i3.HasValue)
				{
					return m_i3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return 0;
	}

	public override bool ReadBool()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 3)
		{
			switch (index)
			{
			case 0:
				if (m_b1.HasValue)
				{
					return m_b1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_b2.HasValue)
				{
					return m_b2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_b3.HasValue)
				{
					return m_b3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return false;
	}

	public override short ReadShort()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 2)
		{
			switch (index)
			{
			case 0:
				if (m_st1.HasValue)
				{
					return m_st1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_st2.HasValue)
				{
					return m_st2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_st3.HasValue)
				{
					return m_st3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return 0;
	}

	public override string ReadString()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 4)
		{
			switch (index)
			{
			case 0:
				if (m_string1 != null)
				{
					return m_string1;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_string2 != null)
				{
					return m_string2;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_string3 != null)
				{
					return m_string3;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return "";
	}

	public override long ReadLong()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 5)
		{
			switch (index)
			{
			case 0:
				if (m_l1.HasValue)
				{
					return m_l1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_l2.HasValue)
				{
					return m_l2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_l3.HasValue)
				{
					return m_l3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return 0L;
	}

	public override float ReadFloat()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 6)
		{
			switch (index)
			{
			case 0:
				if (m_f1.HasValue)
				{
					return m_f1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_f2.HasValue)
				{
					return m_f2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_f3.HasValue)
				{
					return m_f3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return 0f;
	}

	public override double ReadDouble()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 7)
		{
			switch (index)
			{
			case 0:
				if (m_d1.HasValue)
				{
					return m_d1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_d2.HasValue)
				{
					return m_d2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_d3.HasValue)
				{
					return m_d3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return 0.0;
	}

	public override Vector3 ReadVector3()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 8)
		{
			switch (index)
			{
			case 0:
				if (m_v1.HasValue)
				{
					return m_v1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_v2.HasValue)
				{
					return m_v2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_v3.HasValue)
				{
					return m_v3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return Vector3.zero;
	}

	public override Color ReadColor()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 11)
		{
			switch (index)
			{
			case 0:
				if (m_c1.HasValue)
				{
					return m_c1.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 1:
				if (m_c2.HasValue)
				{
					return m_c2.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			case 2:
				if (m_c3.HasValue)
				{
					return m_c3.Value;
				}
				NextReadIndex = nextReadIndex;
				ThrowError("参数异常，未赋值");
				break;
			default:
				NextReadIndex = nextReadIndex;
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return Color.white;
	}

	public override object ReadObject()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 9)
		{
			switch (index)
			{
			case 0:
				return m_o1;
			case 1:
				return m_o2;
			case 2:
				return m_o3;
			}
			NextReadIndex = nextReadIndex;
			ThrowError("参数索引异常");
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return null;
	}

	public override UnityEngine.Object ReadUnityObject()
	{
		int nextReadIndex = NextReadIndex;
		int index;
		long num = _ReadNextTp(out index);
		if (num == 10)
		{
			switch (index)
			{
			case 0:
				return m_uo1;
			case 1:
				return m_uo2;
			case 2:
				return m_uo3;
			}
			NextReadIndex = nextReadIndex;
			ThrowError("参数索引异常");
		}
		else
		{
			NextReadIndex = nextReadIndex;
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{nextReadIndex}");
		}
		return null;
	}

	public override AbstractParams WriteInt(int v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 1)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_i1 = v;
				_SetNextTp(1L, 0L);
				break;
			case 1:
				m_i2 = v;
				_SetNextTp(1L, 1L);
				break;
			case 2:
				m_i3 = v;
				_SetNextTp(1L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_i1.HasValue)
		{
			m_i1 = v;
			_SetNextTp(1L, 0L);
		}
		else if (!m_i2.HasValue)
		{
			m_i2 = v;
			_SetNextTp(1L, 1L);
		}
		else if (!m_i3.HasValue)
		{
			m_i3 = v;
			_SetNextTp(1L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteShort(short v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 2)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_st1 = v;
				_SetNextTp(2L, 0L);
				break;
			case 1:
				m_st2 = v;
				_SetNextTp(2L, 1L);
				break;
			case 2:
				m_st3 = v;
				_SetNextTp(2L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_st1.HasValue)
		{
			m_st1 = v;
			_SetNextTp(2L, 0L);
		}
		else if (!m_st2.HasValue)
		{
			m_st2 = v;
			_SetNextTp(2L, 1L);
		}
		else if (!m_st3.HasValue)
		{
			m_st3 = v;
			_SetNextTp(2L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteString(string v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 4)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_string1 = v;
				_SetNextTp(4L, 0L);
				break;
			case 1:
				m_string2 = v;
				_SetNextTp(4L, 1L);
				break;
			case 2:
				m_string3 = v;
				_SetNextTp(4L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (m_string1 == null)
		{
			m_string1 = v;
			_SetNextTp(4L, 0L);
		}
		else if (m_string2 == null)
		{
			m_string2 = v;
			_SetNextTp(4L, 1L);
		}
		else if (m_string3 == null)
		{
			m_string3 = v;
			_SetNextTp(4L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteFloat(float v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 6)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_f1 = v;
				_SetNextTp(6L, 0L);
				break;
			case 1:
				m_f2 = v;
				_SetNextTp(6L, 1L);
				break;
			case 2:
				m_f3 = v;
				_SetNextTp(6L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_f1.HasValue)
		{
			m_f1 = v;
			_SetNextTp(6L, 0L);
		}
		else if (!m_f2.HasValue)
		{
			m_f2 = v;
			_SetNextTp(6L, 1L);
		}
		else if (!m_f3.HasValue)
		{
			m_f3 = v;
			_SetNextTp(6L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteDouble(double v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 7)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_d1 = v;
				_SetNextTp(7L, 0L);
				break;
			case 1:
				m_d2 = v;
				_SetNextTp(7L, 1L);
				break;
			case 2:
				m_d3 = v;
				_SetNextTp(7L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_d1.HasValue)
		{
			m_d1 = v;
			_SetNextTp(7L, 0L);
		}
		else if (!m_d2.HasValue)
		{
			m_d2 = v;
			_SetNextTp(7L, 1L);
		}
		else if (!m_d3.HasValue)
		{
			m_d3 = v;
			_SetNextTp(7L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteBool(bool v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 3)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_b1 = v;
				_SetNextTp(3L, 0L);
				break;
			case 1:
				m_b2 = v;
				_SetNextTp(3L, 1L);
				break;
			case 2:
				m_b3 = v;
				_SetNextTp(3L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_b1.HasValue)
		{
			m_b1 = v;
			_SetNextTp(3L, 0L);
		}
		else if (!m_b2.HasValue)
		{
			m_b2 = v;
			_SetNextTp(3L, 1L);
		}
		else if (!m_b3.HasValue)
		{
			m_b3 = v;
			_SetNextTp(3L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteLong(long v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 5)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_l1 = v;
				_SetNextTp(5L, 0L);
				break;
			case 1:
				m_l2 = v;
				_SetNextTp(5L, 1L);
				break;
			case 2:
				m_l3 = v;
				_SetNextTp(5L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_l1.HasValue)
		{
			m_l1 = v;
			_SetNextTp(5L, 0L);
		}
		else if (!m_l2.HasValue)
		{
			m_l2 = v;
			_SetNextTp(5L, 1L);
		}
		else if (!m_l3.HasValue)
		{
			m_l3 = v;
			_SetNextTp(5L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteVector3(Vector3 v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 8)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_v1 = v;
				_SetNextTp(8L, 0L);
				break;
			case 1:
				m_v2 = v;
				_SetNextTp(8L, 1L);
				break;
			case 2:
				m_v3 = v;
				_SetNextTp(8L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_v1.HasValue)
		{
			m_v1 = v;
			_SetNextTp(8L, 0L);
		}
		else if (!m_v2.HasValue)
		{
			m_v2 = v;
			_SetNextTp(8L, 1L);
		}
		else if (!m_v3.HasValue)
		{
			m_v3 = v;
			_SetNextTp(8L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteColor(Color v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 11)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_c1 = v;
				_SetNextTp(11L, 0L);
				break;
			case 1:
				m_c2 = v;
				_SetNextTp(11L, 1L);
				break;
			case 2:
				m_c3 = v;
				_SetNextTp(11L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (!m_c1.HasValue)
		{
			m_c1 = v;
			_SetNextTp(11L, 0L);
		}
		else if (!m_c2.HasValue)
		{
			m_c2 = v;
			_SetNextTp(11L, 1L);
		}
		else if (!m_c3.HasValue)
		{
			m_c3 = v;
			_SetNextTp(11L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteObject(object v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 9)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_o1 = v;
				_SetNextTp(9L, 0L);
				break;
			case 1:
				m_o2 = v;
				_SetNextTp(9L, 1L);
				break;
			case 2:
				m_o3 = v;
				_SetNextTp(9L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (m_o1 == null)
		{
			m_o1 = v;
			_SetNextTp(9L, 0L);
		}
		else if (m_o2 == null)
		{
			m_o2 = v;
			_SetNextTp(9L, 1L);
		}
		else if (m_o3 == null)
		{
			m_o3 = v;
			_SetNextTp(9L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams WriteUnityObject(UnityEngine.Object v)
	{
		if (OriginArgCount > 0)
		{
			short num = 0;
			for (int i = 0; i < VirtualArg; i++)
			{
				if (GetArgIndexType(i) == 10)
				{
					num++;
				}
			}
			switch (num)
			{
			case 0:
				m_uo1 = v;
				_SetNextTp(10L, 0L);
				break;
			case 1:
				m_uo2 = v;
				_SetNextTp(10L, 1L);
				break;
			case 2:
				m_uo3 = v;
				_SetNextTp(10L, 2L);
				break;
			default:
				ThrowUseGener();
				break;
			}
			VirtualArg++;
			VirtualArg %= OriginArgCount;
		}
		else if (m_uo1 == null)
		{
			m_uo1 = v;
			_SetNextTp(10L, 0L);
		}
		else if (m_uo2 == null)
		{
			m_uo2 = v;
			_SetNextTp(10L, 1L);
		}
		else if (m_uo3 == null)
		{
			m_uo3 = v;
			_SetNextTp(10L, 2L);
		}
		else
		{
			ThrowUseGener();
		}
		return this;
	}

	public override AbstractParams SetInt(int argindex, int v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 1)
		{
			switch (index)
			{
			case 0:
				m_i1 = v;
				break;
			case 1:
				m_i2 = v;
				break;
			case 2:
				m_i3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetShort(int argindex, short v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 2)
		{
			switch (index)
			{
			case 0:
				m_st1 = v;
				break;
			case 1:
				m_st2 = v;
				break;
			case 2:
				m_st3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetString(int argindex, string v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 4)
		{
			switch (index)
			{
			case 0:
				m_string1 = v;
				break;
			case 1:
				m_string2 = v;
				break;
			case 2:
				m_string3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetBool(int argindex, bool v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 3)
		{
			switch (index)
			{
			case 0:
				m_b1 = v;
				break;
			case 1:
				m_b2 = v;
				break;
			case 2:
				m_b3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetLong(int argindex, long v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 5)
		{
			switch (index)
			{
			case 0:
				m_l1 = v;
				break;
			case 1:
				m_l2 = v;
				break;
			case 2:
				m_l3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetVector3(int argindex, Vector3 v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 8)
		{
			switch (index)
			{
			case 0:
				m_v1 = v;
				break;
			case 1:
				m_v2 = v;
				break;
			case 2:
				m_v3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetColor(int argindex, Color v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 11)
		{
			switch (index)
			{
			case 0:
				m_c1 = v;
				break;
			case 1:
				m_c2 = v;
				break;
			case 2:
				m_c3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetObject(int argindex, object v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 9)
		{
			switch (index)
			{
			case 0:
				m_o1 = v;
				break;
			case 1:
				m_o2 = v;
				break;
			case 2:
				m_o3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetUnityObject(int argindex, UnityEngine.Object v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 10)
		{
			switch (index)
			{
			case 0:
				m_uo1 = v;
				break;
			case 1:
				m_uo2 = v;
				break;
			case 2:
				m_uo3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetFloat(int argindex, float v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 6)
		{
			switch (index)
			{
			case 0:
				m_f1 = v;
				break;
			case 1:
				m_f2 = v;
				break;
			case 2:
				m_f3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override AbstractParams SetDouble(int argindex, double v)
	{
		int index;
		long num = _ReadIndex(argindex, out index);
		if (num == 7)
		{
			switch (index)
			{
			case 0:
				m_d1 = v;
				break;
			case 1:
				m_d2 = v;
				break;
			case 2:
				m_d3 = v;
				break;
			default:
				ThrowError("参数索引异常");
				break;
			}
		}
		else
		{
			ThrowError($"下一个类型为:{(ParamType)num} 参数异常 当前索引为 :{argindex}");
		}
		return this;
	}

	public override void ResetReadIndex()
	{
		NextReadIndex = 0;
	}

	public override int GetArgIndexType(int index)
	{
		int index2;
		return (int)_ReadIndex(index, out index2);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} 参数个数: {1} ", base.ToString(), base.ArgCount.ToString());
		int nextReadIndex = NextReadIndex;
		ResetReadIndex();
		for (int i = 0; i < base.ArgCount; i++)
		{
			switch (GetArgIndexType(i))
			{
			case 1:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadInt());
				break;
			case 2:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadShort());
				break;
			case 3:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadBool());
				break;
			case 4:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadString());
				break;
			case 7:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadDouble());
				break;
			case 6:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadFloat());
				break;
			case 0:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, "空");
				break;
			case 5:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadLong());
				break;
			case 8:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadVector3());
				break;
			case 9:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadObject());
				break;
			case 10:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadUnityObject());
				break;
			case 11:
				stringBuilder.AppendFormat("第{0}个参数为: {1} ", i + 1, ReadColor());
				break;
			default:
				DebugLogger.LogError("未增加的类型");
				break;
			}
		}
		NextReadIndex = nextReadIndex;
		return stringBuilder.ToString();
	}
}
