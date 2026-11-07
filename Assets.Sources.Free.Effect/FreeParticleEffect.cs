using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJBase.Extensions;
using SSJJBase.Thread;
using share;

namespace Assets.Sources.Free.Effect;

public class FreeParticleEffect : FreeBaseEffect
{
	private string _particleName;

	public string ParticleName
	{
		get
		{
			return _particleName;
		}
		set
		{
			if (!(value == _particleName))
			{
				_particleName = value;
				if (_particleName != null)
				{
					BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadParticle(Model3D, _particleName, 1f));
				}
			}
		}
	}

	public FreeParticleEffect()
	{
		_type = 3;
	}

	public override IFreeEffect Clone()
	{
		return new FreeParticleEffect();
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
			}
		}
	}

	protected override void SetPureValue(string value)
	{
		Model3D.ResUrl = GetEffectUrl(value);
	}

	public override void Initial(params object[] ini)
	{
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length == 1)
		{
			ParticleName = array[0];
		}
		InitialAuto(ini[1] as string);
		StartAuto();
	}
}
