using System;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using SSJJBase.Extensions;
using share;

namespace Assets.Sources.Free.Effect;

public class FreeSingleEffect : FreeBaseEffect
{
	public FreeSingleEffect()
	{
		_type = 1;
	}

	public override IFreeEffect Clone()
	{
		return new FreeSingleEffect();
	}

	public override void Frame(int frameTime, ISceneManage scene, FreeRenderObject freeRender)
	{
		AutoValue(frameTime);
		IAutoValue auto = GetAuto("v");
		if (auto != null)
		{
			Model3D.ResUrl = auto.Frame(frameTime).String;
		}
		IAutoValue auto2 = GetAuto("pos");
		if (auto2 != null)
		{
			Matrix3D matrix3D = auto2.Frame(frameTime).Matrix3D;
			if (matrix3D != null)
			{
				Obj3D.PosX = (float)matrix3D.GetM(0);
				Obj3D.PosY = (float)matrix3D.GetM(1);
				Obj3D.PosZ = (float)matrix3D.GetM(2);
				Obj3D.RotationX = (float)matrix3D.GetM(3);
				Obj3D.RotationZ = (float)matrix3D.GetM(5);
			}
		}
	}

	protected override void SetPureValue(string value)
	{
		Model3D.ResUrl = value;
	}

	public override void Initial(params object[] ini)
	{
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length >= 9)
		{
			Model3D.DepthMode = Convert.ToInt32(array[0]);
			Model3D.Culling = Convert.ToInt32(array[2]);
			Model3D.ModelName = array[4];
			Model3D.GeometryType = Convert.ToInt32(array[5]);
			Model3D.TextureName = array[3];
			Model3D.Alpha = Convert.ToSingle(array[6]);
			base.EffectFixInfo.Fixed = Convert.ToBoolean(array[7]);
			string[] array2 = array[8].Split(",");
			if (array2.Length == 2)
			{
				base.EffectFixInfo.FixX = Convert.ToSingle(array2[0]);
				base.EffectFixInfo.FixZ = Convert.ToSingle(array2[1]);
			}
			GetAuto("v")?.SetValue(Model3D.ResUrl);
		}
		InitialAuto(ini[1] as string);
		StartAuto();
	}
}
