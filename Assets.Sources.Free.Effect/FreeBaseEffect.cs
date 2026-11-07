using System;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using UnityEngine;

namespace Assets.Sources.Free.Effect;

public abstract class FreeBaseEffect : BaseAutoFields, IFreeEffect
{
	public const int EFFECT_TYPE_SINGLE = 1;

	public const int EFFECT_TYPE_PARTICLE = 3;

	public const int EFFECT_TYPE_PARTICLE_LINK = 4;

	public const int EFFECT_TYPE_SHADER = 10;

	protected IObject3D Obj3D;

	protected IEffectModel3D Model3D;

	protected IObject3D OriObj3D;

	private float _per;

	private readonly EffectFixInfo _effectFixInfo;

	protected int _type;

	public IEffectModel3D EffectModel3D => Model3D;

	public EffectFixInfo EffectFixInfo => _effectFixInfo;

	public int Type => _type;

	public IObject3D OriObject3D => OriObj3D;

	protected FreeBaseEffect()
	{
		GameObject gameObject = new GameObject("Obj3d");
		gameObject.transform.SetParent(FreeEffectManager.GetInstance().GetEffectParent());
		GameObject gameObject2 = new GameObject("Obj3d_Origin");
		gameObject2.transform.SetParent(FreeEffectManager.GetInstance().GetEffectParent());
		Obj3D = new UnityObject3D(gameObject);
		OriObj3D = new UnityObject3D(gameObject2);
		Model3D = new UnityDefaultEffectModel3D(Obj3D, 0);
		_effectFixInfo = new EffectFixInfo();
	}

	public virtual IFreeEffect Clone()
	{
		throw new NotImplementedException();
	}

	public virtual void Destroy()
	{
		Obj3D.Destory();
		OriObj3D.Destory();
		Model3D.Destory();
	}

	public virtual void Frame(int frameTime, ISceneManage scene, FreeRenderObject freeRender)
	{
	}

	protected bool IsNullString(string str)
	{
		if (!string.IsNullOrEmpty(str))
		{
			return str.Equals("null");
		}
		return true;
	}

	public void SetPos(float x, float y, float z, float scaleX, float scaleY, float scaleZ, float rotationX, float rotationY, float rotationZ)
	{
		Obj3D.PosX = x;
		Obj3D.PosY = y;
		Obj3D.PosZ = z;
		Obj3D.ScaleX = scaleX;
		Obj3D.ScaleY = scaleY;
		Obj3D.ScaleZ = scaleZ;
		Obj3D.RotationX = rotationX;
		Obj3D.RotationY = rotationY;
		Obj3D.RotationZ = rotationZ;
		OriObj3D.PosX = x;
		OriObj3D.PosY = y;
		OriObj3D.PosZ = z;
		OriObj3D.ScaleX = scaleX;
		OriObj3D.ScaleY = scaleY;
		OriObj3D.ScaleZ = scaleZ;
		OriObj3D.RotationX = rotationX;
		OriObj3D.RotationY = rotationY;
		OriObj3D.RotationZ = rotationZ;
	}

	public void SetValue(int vsInt, string vsString)
	{
		int num = vsInt / 100;
		int num2 = vsInt % 100;
		if (num == 2 || num == 1)
		{
			StartAuto(num2);
		}
		else
		{
			StopAuto(num2);
		}
		if (num != 2 && num != 4 && num != 0)
		{
			return;
		}
		if (num == 2 || num == 4)
		{
			SetAutoValue(vsString, num2);
		}
		if (num == 0)
		{
			if (num2 == 0)
			{
				SetPureValue(vsString);
			}
			else
			{
				SetAutoValue(vsString, num2);
			}
		}
	}

	public virtual void Initial(params object[] ini)
	{
	}

	protected abstract void SetPureValue(string v);

	protected override void InitialAutoValue(string field, IAutoValue auto)
	{
		if (!("x" == field) && !("y" == field) && !("z" == field) && !("sx" == field) && !("sy" == field) && !("sz" == field))
		{
			if ("rx" == field)
			{
				auto.SetValue(Obj3D.RotationX.ToString());
			}
			else if ("ry" == field)
			{
				auto.SetValue(Obj3D.RotationY.ToString());
			}
			else if ("rz" == field)
			{
				auto.SetValue(Obj3D.RotationZ.ToString());
			}
			else if ("r" == field)
			{
				auto.SetValue(((ISprite3D)Obj3D).rotation.ToString());
			}
			else if ("per" == field)
			{
				auto.SetValue(_per.ToString());
			}
		}
	}

	protected override void SetAutoValueTo(AutoField auto, int frammeTime)
	{
		if ("x" == auto.field)
		{
			Obj3D.PosX = (float)auto.auto.Frame(frammeTime).Float;
			OriObj3D.PosX = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("y" == auto.field)
		{
			Obj3D.PosY = (float)auto.auto.Frame(frammeTime).Float;
			OriObj3D.PosY = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("z" == auto.field)
		{
			Obj3D.PosZ = (float)auto.auto.Frame(frammeTime).Float;
			OriObj3D.PosZ = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("sx" == auto.field)
		{
			float result = 1f;
			if (float.TryParse(auto.auto.Frame(frammeTime).String, out result))
			{
				Obj3D.ScaleX = result / 100f;
			}
		}
		else if ("sy" == auto.field)
		{
			float result2 = 1f;
			if (float.TryParse(auto.auto.Frame(frammeTime).String, out result2))
			{
				Obj3D.ScaleY = result2 / 100f;
			}
		}
		else if ("sz" == auto.field)
		{
			float result3 = 1f;
			if (float.TryParse(auto.auto.Frame(frammeTime).String, out result3))
			{
				Obj3D.ScaleZ = result3 / 100f;
			}
		}
		else if ("rx" == auto.field)
		{
			Obj3D.RotationX = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("ry" == auto.field)
		{
			Obj3D.RotationY = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rz" == auto.field)
		{
			Obj3D.RotationZ = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("r" == auto.field)
		{
			((ISprite3D)Obj3D).rotation = (float)auto.auto.Frame(frammeTime).Float;
			((ISprite3D)Obj3D).rotation = (float)((double)((ISprite3D)Obj3D).rotation * Math.PI / 180.0);
		}
		else if ("per" == auto.field)
		{
			_per = (float)auto.auto.Frame(frammeTime).Float;
		}
	}

	protected string GetEffectUrl(string url)
	{
		return url;
	}
}
