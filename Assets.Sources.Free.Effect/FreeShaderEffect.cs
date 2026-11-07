using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using SSJJBase.Extensions;
using UnityEngine;
using share;

namespace Assets.Sources.Free.Effect;

public class FreeShaderEffect : FreeBaseEffect
{
	public FreeShaderEffect()
	{
		_type = 10;
	}

	public override void Initial(params object[] ini)
	{
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length > 5)
		{
			int depthMode = int.Parse(array[0]);
			int culling = int.Parse(array[1]);
			string shaderParams = array[2];
			string shaderName = array[3];
			string text = array[4];
			string textureParams = array[5];
			GameObject gameObject = new GameObject(text);
			gameObject.transform.SetParent(FreeEffectManager.GetInstance().GetEffectParent());
			Obj3D = new UnityObject3D(gameObject);
			Model3D = new UnityShaderEffectModel3D(Obj3D);
			Model3D.DepthMode = depthMode;
			Model3D.Culling = culling;
			FrameParams data = default(FrameParams);
			data.Constheight = Model3D.Model3D.ScaleZ;
			data.ShaderName = shaderName;
			data.ShaderParams = shaderParams;
			data.ModelName = text;
			data.TextureParams = textureParams;
			Model3D.Frame(ref data);
		}
		InitialAuto(ini[1] as string);
		StartAuto();
	}

	protected override void SetPureValue(string value)
	{
		Model3D.TextureName = value;
	}

	private string PickString(string key, int frameTime)
	{
		return GetAuto(key)?.Frame(frameTime).String;
	}

	public override void Frame(int frameTime, ISceneManage scene, FreeRenderObject freeRender)
	{
		AutoValue(frameTime);
		IAutoValue auto = GetAuto("pos");
		if (auto != null)
		{
			Matrix3D matrix3D = auto.Frame(frameTime).Matrix3D;
			if (matrix3D != null)
			{
				Obj3D.PosX = (float)matrix3D.GetM(0);
				Obj3D.PosY = (float)matrix3D.GetM(1);
				Obj3D.PosZ = (float)matrix3D.GetM(2);
				Obj3D.RotationX = (float)matrix3D.GetM(3);
				Obj3D.RotationY = (float)matrix3D.GetM(4);
				Obj3D.RotationZ = (float)matrix3D.GetM(5);
			}
		}
		if (Model3D != null)
		{
			FrameParams data = default(FrameParams);
			data.Constheight = Model3D.Model3D.ScaleZ;
			data.ShaderName = PickString("shaderUrl", frameTime);
			data.ShaderParams = PickString("shaderParas", frameTime);
			data.ModelName = PickString("model", frameTime);
			data.TextureParams = PickString("resUrl", frameTime);
			Model3D.Frame(ref data);
		}
	}

	public override IFreeEffect Clone()
	{
		return new FreeShaderEffect();
	}
}
