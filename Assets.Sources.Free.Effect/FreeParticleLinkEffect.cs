using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJBase.Extensions;
using SSJJBase.Thread;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Free.Effect;

public class FreeParticleLinkEffect : FreeBaseEffect
{
	private float _scale;

	private float _adjust;

	private int _fromId;

	private int _toId;

	private int _fromZ;

	private int _toZ;

	private Vector3 _startPos;

	private Vector3 _finishPos;

	private readonly Vector3D _forward = new Vector3D();

	private double _forwardLength;

	private string _particleName;

	public string ParticleName
	{
		get
		{
			return _particleName;
		}
		set
		{
			if (!string.IsNullOrEmpty(value) && !(value == _particleName))
			{
				_particleName = value;
				BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadParticle(Model3D, _particleName, -1f));
			}
		}
	}

	public FreeParticleLinkEffect()
	{
		_type = 4;
	}

	protected override void SetPureValue(string v)
	{
	}

	public override void Initial(params object[] ini)
	{
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length >= 7)
		{
			FreeDataHelperUtility.GetStringArrayIdx(array, 0, ref _fromId);
			FreeDataHelperUtility.GetStringArrayIdx(array, 1, ref _toId);
			string t = "";
			FreeDataHelperUtility.GetStringArrayIdx(array, 2, ref t);
			ParticleName = t;
			FreeDataHelperUtility.GetStringArrayIdx(array, 3, ref _scale);
			FreeDataHelperUtility.GetStringArrayIdx(array, 4, ref _adjust);
			FreeDataHelperUtility.GetStringArrayIdx(array, 5, ref _fromZ);
			FreeDataHelperUtility.GetStringArrayIdx(array, 6, ref _toZ);
		}
		InitialAuto(ini[1] as string);
		StartAuto();
	}

	public override void Frame(int frameTime, ISceneManage scene, FreeRenderObject freeRender)
	{
		AutoValue(frameTime);
		Obj3D.GameObject.SetObjectActive(Init());
		if (!Obj3D.GameObject.IsActiveSelf())
		{
			return;
		}
		UpdateOrg();
		UpdateRotation();
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
	}

	private bool Init()
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(_fromId);
		SceneObjectEntity entityWithEntityId2 = Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(_toId);
		PlayerEntity entityWithEntityId3 = Contexts.sharedInstance.player.GetEntityWithEntityId(_toId);
		if (entityWithEntityId == null || (entityWithEntityId2 == null && entityWithEntityId3 == null))
		{
			return false;
		}
		_startPos.Set(entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()).x, entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()).y, entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex()).z);
		if (entityWithEntityId2 != null)
		{
			_finishPos.Set(entityWithEntityId2.position.Origin.x, entityWithEntityId2.position.Origin.y, entityWithEntityId2.position.Origin.z);
		}
		else
		{
			_finishPos.Set(entityWithEntityId3.GetCompenstatePos(entityWithEntityId3.fpos.Change.GetPosIndex()).x, entityWithEntityId3.GetCompenstatePos(entityWithEntityId3.fpos.Change.GetPosIndex()).y, entityWithEntityId3.GetCompenstatePos(entityWithEntityId3.fpos.Change.GetPosIndex()).z);
		}
		_startPos.z += _fromZ;
		_finishPos.z += _toZ;
		Math3D.SubtractVecAFromB(VectorTypeConverter.Unity2Ssjj(_finishPos), VectorTypeConverter.Unity2Ssjj(_startPos), _forward);
		_forwardLength = _forward.Normalize();
		float z = (float)_forwardLength * _adjust / 100f;
		Model3D.GameObject.transform.localScale = new Vector3(1f, 1f, z);
		return true;
	}

	private void UpdateRotation()
	{
		Model3D.GameObject.transform.LookAt(VectorCoordConverter.SsjjToUnity(_finishPos));
	}

	private void UpdateOrg()
	{
		Model3D.GameObject.transform.position = VectorCoordConverter.SsjjToUnity(_startPos);
	}

	public override IFreeEffect Clone()
	{
		return new FreeParticleLinkEffect();
	}
}
