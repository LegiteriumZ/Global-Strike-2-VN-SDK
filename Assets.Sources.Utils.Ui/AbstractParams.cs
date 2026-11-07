using System;
using CommonUtils;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

public abstract class AbstractParams
{
	protected int LimitMax = -1;

	protected int OriginArgCount = -1;

	protected int VirtualArg;

	protected int NextReadIndex;

	public int ArgCount { get; protected set; }

	public bool CanPush
	{
		get
		{
			if (LimitMax > 0)
			{
				if (OriginArgCount > 0)
				{
					if (ArgCount < OriginArgCount)
					{
						return ArgCount < LimitMax;
					}
					return false;
				}
				return ArgCount < LimitMax;
			}
			return ArgCount < OriginArgCount;
		}
	}

	protected long _MyPow(long v, int nums)
	{
		long num = 1L;
		while (nums > 0)
		{
			num *= v;
			nums--;
		}
		return num;
	}

	protected void ThrowUsetSimple()
	{
		throw new Exception("参数较少，请使用Simpleparams");
	}

	protected void ThrowUseGener()
	{
		throw new Exception("参数过多，请使用genericparams");
	}

	public void Push(AbstractParams args)
	{
		if (args == null)
		{
			return;
		}
		if (args == this)
		{
			DebugLogger.Log("参数对象相同 无法添加");
			return;
		}
		int argCount = args.ArgCount;
		if (LimitMax != -1 && argCount + ArgCount > LimitMax)
		{
			ThrowUseGener();
			return;
		}
		if (OriginArgCount > 0)
		{
			OriginArgCount += argCount;
		}
		for (int i = 0; i < argCount; i++)
		{
			switch (args.GetArgIndexType(i))
			{
			case 1:
				WriteInt(args.ReadInt());
				break;
			case 2:
				WriteShort(args.ReadShort());
				break;
			case 3:
				WriteBool(args.ReadBool());
				break;
			case 6:
				WriteFloat(args.ReadFloat());
				break;
			case 7:
				WriteDouble(args.ReadDouble());
				break;
			case 5:
				WriteLong(args.ReadLong());
				break;
			case 4:
				WriteString(args.ReadString());
				break;
			case 8:
				WriteVector3(args.ReadVector3());
				break;
			case 9:
				WriteObject(args.ReadObject());
				break;
			case 10:
				WriteUnityObject(args.ReadUnityObject());
				break;
			}
		}
	}

	public abstract int NextValue();

	public abstract int GetArgIndexType(int index);

	public abstract void ResetReadIndex();

	public abstract void Release();

	public abstract AbstractParams SetInt(int argindex, int v);

	public abstract AbstractParams SetShort(int argindex, short v);

	public abstract AbstractParams SetString(int argindex, string v);

	public abstract AbstractParams SetBool(int argindex, bool v);

	public abstract AbstractParams SetLong(int argindex, long v);

	public abstract AbstractParams SetFloat(int argindex, float v);

	public abstract AbstractParams SetDouble(int argindex, double v);

	public abstract AbstractParams SetVector3(int argindex, Vector3 v);

	public abstract AbstractParams SetColor(int argindex, Color v);

	public abstract AbstractParams SetObject(int argindex, object v);

	public abstract AbstractParams SetUnityObject(int argindex, UnityEngine.Object v);

	public abstract AbstractParams WriteInt(int v);

	public abstract AbstractParams WriteShort(short v);

	public abstract AbstractParams WriteString(string v);

	public abstract AbstractParams WriteBool(bool v);

	public abstract AbstractParams WriteFloat(float v);

	public abstract AbstractParams WriteDouble(double v);

	public abstract AbstractParams WriteLong(long v);

	public abstract AbstractParams WriteVector3(Vector3 v);

	public abstract AbstractParams WriteColor(Color v);

	public abstract AbstractParams WriteObject(object v);

	public abstract AbstractParams WriteUnityObject(UnityEngine.Object v);

	public abstract AbstractParams InsertInt(int index, int v);

	public abstract AbstractParams InsertShort(int index, short v);

	public abstract AbstractParams InsertString(int index, string v);

	public abstract AbstractParams InsertBool(int index, bool v);

	public abstract AbstractParams InsertFloat(int index, float v);

	public abstract AbstractParams InsertDouble(int index, double v);

	public abstract AbstractParams InsertLong(int index, long v);

	public abstract AbstractParams InsertVector3(int index, Vector3 v);

	public abstract AbstractParams InsertColor(int index, Color v);

	public abstract AbstractParams InsertObject(int index, object v);

	public abstract AbstractParams InsertUnityObject(int index, UnityEngine.Object v);

	public abstract int ReadInt();

	public abstract bool ReadBool();

	public abstract short ReadShort();

	public abstract string ReadString();

	public abstract long ReadLong();

	public abstract float ReadFloat();

	public abstract double ReadDouble();

	public abstract Vector3 ReadVector3();

	public abstract Color ReadColor();

	public abstract object ReadObject();

	public abstract UnityEngine.Object ReadUnityObject();

	public abstract void PoolIncreased();
}
