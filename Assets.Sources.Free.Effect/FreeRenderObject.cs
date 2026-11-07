using System;
using System.Collections.Generic;
using Assets.Sources.Components.Common;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.UI;
using Assets.Sources.Free.Utility;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;
using share;

namespace Assets.Sources.Free.Effect;

public class FreeRenderObject : MonoBehaviour, IUIUpdater
{
	public string Name;

	private string _key;

	private List<AutoField> _autos;

	private IShowStyle _showStyle;

	private int _currentTime;

	private int _totalTime;

	private Vector3D _min;

	private Vector3D _max;

	private Vector3D _boundMin;

	private Vector3D _boundMax;

	public RaderImage RaderImage;

	private SceneObjectEntity _raderEntity;

	private List<IFreeEffect> _effects;

	private bool _hide;

	public bool NeedPvs;

	public bool HideHpNumber;

	private IObject3D _model3D;

	private List<IEffectModel3D> _effectModel3DList;

	private float _scale;

	public bool Fixed;

	public string Key
	{
		get
		{
			return _key;
		}
		set
		{
			_key = value;
		}
	}

	public bool Visible
	{
		get
		{
			return _model3D.Visible;
		}
		set
		{
			_model3D.Visible = value;
		}
	}

	public bool IsHide => _hide;

	public bool IsDisabled { get; set; }

	private void Awake()
	{
		_autos = new List<AutoField>();
		_effects = new List<IFreeEffect>();
		_boundMin = new Vector3D(-10.0, -10.0, -10.0);
		_boundMax = new Vector3D(10.0, 10.0, 10.0);
		_min = new Vector3D();
		_max = new Vector3D();
		GameObject gameObject = new GameObject("FreeRenderObject");
		gameObject.transform.SetParent(base.transform);
		_model3D = new UnityObject3D(gameObject);
		_effectModel3DList = new List<IEffectModel3D>();
		MonoBehaviourSingleton<SimpleUIUpdater>.Instance.AddList(this);
	}

	private void UpdateSmallMapImage()
	{
		if (!string.IsNullOrEmpty(RaderImage.RadarImage))
		{
			if (_raderEntity == null)
			{
				_raderEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
				_raderEntity.AddComponent(13, new SmallMapImageComponent());
				_raderEntity.smallMapImage.IsHideNameAndHp = HideHpNumber;
			}
			SmallMapImageComponent smallMapImage = _raderEntity.smallMapImage;
			smallMapImage.Position = new Vector3(_model3D.PosX, _model3D.PosY, _model3D.PosZ);
			AssetInfo uiAssetPath = FreeResourceUtility.GetUiAssetPath(RaderImage.RadarImage);
			if (uiAssetPath.AssetName.Info.EndsWith("nextSafe.png"))
			{
				smallMapImage.Safe = true;
				smallMapImage.RadarImage = new AssetInfo("null", "null");
				smallMapImage.SmallMapImage = new AssetInfo("null", "null");
			}
			else
			{
				smallMapImage.RadarImage = uiAssetPath;
				smallMapImage.SmallMapImage = uiAssetPath;
			}
			smallMapImage.FullImage = FreeResourceUtility.GetUiAssetPath(RaderImage.SmallMapFullImg);
			smallMapImage.Alpha = RaderImage.Alpha / 100f;
			smallMapImage.Mask = RaderImage.Mask;
			smallMapImage.ScaleX = RaderImage.ScaleX / 100f;
			smallMapImage.ScaleY = RaderImage.ScaleY / 100f;
			smallMapImage.RealWidth = RaderImage.RealWidth;
			smallMapImage.RealHeight = RaderImage.RealHeight;
			smallMapImage.FreeRadar = true;
			smallMapImage.SmallMapScale = FreeResourceUtility.GetSmallMapScale(smallMapImage.SmallMapImage.AssetName.Info);
			smallMapImage.RadarScale = FreeResourceUtility.GetRadarScale(smallMapImage.RadarImage.AssetName.Info);
			smallMapImage.RadarFixPos = FreeResourceUtility.GetRadarFixPos(smallMapImage.RadarImage.AssetName.Info);
			smallMapImage.Rotation = _model3D.RotationZ - 90f;
		}
	}

	private void OnDestroy()
	{
		for (int i = 0; i < _effects.Count; i++)
		{
			_effects[i].Destroy();
		}
		_model3D.Destory();
		if (MonoBehaviourSingleton<SimpleUIUpdater>.HasInstance)
		{
			MonoBehaviourSingleton<SimpleUIUpdater>.Instance.RemoveList(this);
		}
		if (_raderEntity != null)
		{
			_raderEntity.Destroy();
		}
	}

	public void ChangeAutoValue(int index, string value)
	{
		BaseAutoFields.SetValue(_autos, index, value);
	}

	public Vector3D GetMin()
	{
		_min.x = _boundMin.x + (double)_model3D.PosX;
		_min.y = _boundMin.y + (double)_model3D.PosY;
		_min.z = _boundMin.z + (double)_model3D.PosZ;
		return _min;
	}

	public Vector3D GetMax()
	{
		_max.x = _boundMax.x + (double)_model3D.PosX;
		_max.y = _boundMax.y + (double)_model3D.PosY;
		_max.z = _boundMax.z + (double)_model3D.PosZ;
		return _max;
	}

	public IFreeEffect GetEffect(int index)
	{
		if (index < _effects.Count)
		{
			return _effects[index];
		}
		return null;
	}

	public void AddEffect(IFreeEffect effect)
	{
		_effects.Add(effect);
		_model3D.AddChild(effect.OriObject3D);
		_model3D.AddChild(effect.EffectModel3D.Model3D);
		_effectModel3DList.Add(effect.EffectModel3D);
	}

	public void SetGameObjectName(string objName)
	{
		_model3D.GameObject.name = objName;
	}

	public void Show(IShowStyle show, int total)
	{
		_showStyle = show;
		_totalTime = total;
		_currentTime = 0;
	}

	public void Move(float x, float y, float z, float rx, float ry, float rz)
	{
		_model3D.PosX = x;
		_model3D.PosY = y;
		_model3D.PosZ = z;
		_model3D.RotationX = rx;
		_model3D.RotationY = ry;
		_model3D.RotationZ = rz;
	}

	public void Render(object centity, ISceneManage scene)
	{
		AutoValue(scene.frameTime);
		for (int i = 0; i < _effects.Count; i++)
		{
			IFreeEffect freeEffect = _effects[i];
			freeEffect.Frame(scene.frameTime, scene, this);
			if (freeEffect.EffectFixInfo.Fixed)
			{
				int fov = (Contexts.sharedInstance.player.isCameraOwner ? Contexts.sharedInstance.player.cameraOwnerEntity.fov.Fov : 90);
				UpdateScaleV(Contexts.sharedInstance.worldCamera.cameraTransform.position, freeEffect.EffectModel3D.Model3D, 430);
				UpdateScale(fov, freeEffect.EffectModel3D.Model3D, freeEffect.OriObject3D);
				UpdateZ(freeEffect.EffectFixInfo.FixZ, fov, freeEffect.EffectModel3D.Model3D, freeEffect.OriObject3D);
				UpdateX(freeEffect.EffectFixInfo.FixX, fov, freeEffect.EffectModel3D.Model3D, freeEffect.OriObject3D);
			}
		}
		if (_showStyle != null)
		{
			_showStyle.ShowEffect(this, _currentTime, _totalTime);
		}
		_currentTime += scene.frameTime;
	}

	protected void UpdateX(float scaleX, int fov, IObject3D model3D, IObject3D ori)
	{
		model3D.PosX = UpdateScaleXZ(scaleX, ori.ScaleX, fov, model3D, ori.PosX);
	}

	protected void UpdateZ(float scaleZ, int fov, IObject3D model3D, IObject3D ori)
	{
		model3D.PosZ = UpdateScaleXZ(scaleZ, ori.ScaleY, fov, model3D, ori.PosZ);
	}

	protected float UpdateScaleXZ(float scaleZ, float len, int fov, IObject3D model3D, float oldV)
	{
		float num = _scale * scaleZ / 4f;
		float num2 = oldV;
		if (90 == fov)
		{
			num2 += num;
		}
		else if (40 == fov)
		{
			num2 += num * 0f;
		}
		else if (10 == fov)
		{
			num2 += num * 0f;
		}
		else if (55 == fov)
		{
			num2 += num * 0f;
		}
		return num2;
	}

	protected void UpdateScale(int fov, IObject3D object3D, IObject3D ori)
	{
		if (90 == fov)
		{
			object3D.ScaleX = _scale * ori.ScaleX;
			object3D.ScaleY = _scale * ori.ScaleY;
			object3D.ScaleZ = _scale * ori.ScaleZ;
		}
		else if (40 == fov)
		{
			object3D.ScaleX = _scale * ori.ScaleX * 0f;
			object3D.ScaleY = _scale * ori.ScaleY * 0f;
			object3D.ScaleZ = _scale * ori.ScaleZ * 0f;
		}
		else if (10 == fov)
		{
			object3D.ScaleX = _scale * ori.ScaleX * 0f;
			object3D.ScaleY = _scale * ori.ScaleY * 0f;
			object3D.ScaleZ = _scale * ori.ScaleZ * 0f;
		}
		else if (55 == fov)
		{
			object3D.ScaleX = _scale * ori.ScaleX * 0f;
			object3D.ScaleY = _scale * ori.ScaleY * 0f;
			object3D.ScaleZ = _scale * ori.ScaleZ * 0f;
		}
	}

	protected void UpdateScaleV(Vector3 viewOrg, IObject3D pos, int distanceSacle = 200)
	{
		float num = Vector3.Distance(new Vector3(_model3D.PosX + pos.PosX, _model3D.PosY + pos.PosY, _model3D.PosZ + pos.PosZ), viewOrg);
		_scale = num / (float)distanceSacle;
	}

	protected void StartAuto()
	{
		for (int i = 0; i < _autos.Count; i++)
		{
			_autos[i].auto.Start();
		}
	}

	protected void StopAuto()
	{
		for (int i = 0; i < _autos.Count; i++)
		{
			_autos[i].auto.Stop();
		}
	}

	protected IAutoValue GetAuto(string field)
	{
		for (int i = 0; i < _autos.Count; i++)
		{
			AutoField autoField = _autos[i];
			if (autoField.field == field)
			{
				return autoField.auto;
			}
		}
		return null;
	}

	public void SetPos(float x, float y, float z, float scaleX, float scaleY, float scaleZ, float rotationX, float rotationY, float rotationZ)
	{
		_model3D.PosX = x;
		_model3D.PosY = y;
		_model3D.PosZ = z;
		_model3D.ScaleX = scaleX;
		_model3D.ScaleY = scaleY;
		_model3D.ScaleZ = scaleZ;
		_model3D.RotationX = rotationX;
		_model3D.RotationY = rotationY;
		_model3D.RotationZ = rotationZ;
	}

	public void InitialAuto(string config)
	{
		if (config == null)
		{
			return;
		}
		string[] array = config.Split("|||");
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i].IndexOf("=");
			if (num > 0)
			{
				InitialOneAuto(array[i].Substring(0, num), array[i].Substring(num + 1));
			}
		}
		StartAuto();
	}

	private void InitialOneAuto(string field, string config)
	{
		IAutoValue autoValue = Assets.Sources.Free.Auto.AutoValue.Parse(config);
		if (autoValue != null)
		{
			InitialAutoValue(field, autoValue);
			_autos.Add(new AutoField(field, autoValue));
		}
	}

	protected void InitialAutoValue(string field, IAutoValue auto)
	{
		if ("x" == field)
		{
			auto.SetValue(_model3D.PosX.ToString());
		}
		else if ("y" == field)
		{
			auto.SetValue(_model3D.PosY.ToString());
		}
		else if ("z" == field)
		{
			auto.SetValue(_model3D.PosZ.ToString());
		}
		else if ("sx" == field)
		{
			auto.SetValue(_model3D.ScaleX.ToString());
		}
		else if ("sy" == field)
		{
			auto.SetValue(_model3D.ScaleY.ToString());
		}
		else if ("sz" == field)
		{
			auto.SetValue(_model3D.ScaleZ.ToString());
		}
		else if ("rx" == field)
		{
			auto.SetValue(_model3D.RotationX.ToString());
		}
		else if ("ry" == field)
		{
			auto.SetValue(_model3D.RotationY.ToString());
		}
		else if ("rz" == field)
		{
			auto.SetValue(_model3D.RotationZ.ToString());
		}
		if ("vi" == field)
		{
			auto.SetValue((!_hide).ToString());
		}
	}

	protected void AutoValue(int frameTime)
	{
		for (int i = 0; i < _autos.Count; i++)
		{
			AutoField auto = _autos[i];
			SetAutoValueTo(auto, frameTime);
		}
		IAutoValue auto2 = GetAuto("pos");
		if (auto2 == null)
		{
			return;
		}
		Matrix3D matrix3D = auto2.Frame(frameTime).Matrix3D;
		if (matrix3D == null)
		{
			return;
		}
		_model3D.PosX = (float)matrix3D.GetM(0);
		_model3D.PosY = (float)matrix3D.GetM(1);
		_model3D.PosZ = (float)matrix3D.GetM(2);
		if ((int)matrix3D.GetM(11) != 0)
		{
			_model3D.RotationX = (float)matrix3D.GetM(3);
			if (Fixed)
			{
				_model3D.RotationY = 0f - (float)matrix3D.GetM(4);
			}
			else
			{
				_model3D.RotationY = (float)matrix3D.GetM(4);
			}
			_model3D.RotationZ = (float)matrix3D.GetM(5);
		}
	}

	protected void SetAutoValueTo(AutoField auto, int frammeTime)
	{
		if ("x" == auto.field)
		{
			_model3D.PosX = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("y" == auto.field)
		{
			_model3D.PosY = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("z" == auto.field)
		{
			_model3D.PosZ = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("sx" == auto.field)
		{
			_model3D.ScaleX = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("sy" == auto.field)
		{
			_model3D.ScaleY = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("sz" == auto.field)
		{
			_model3D.ScaleZ = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rx" == auto.field)
		{
			_model3D.RotationX = (float)auto.auto.Frame(frammeTime).Float;
			_model3D.RotationX = _model3D.RotationX;
		}
		else if ("ry" == auto.field)
		{
			_model3D.RotationY = (float)auto.auto.Frame(frammeTime).Float;
			_model3D.RotationY = _model3D.RotationY;
		}
		else if ("rz" == auto.field)
		{
			_model3D.RotationZ = (float)auto.auto.Frame(frammeTime).Float;
			_model3D.RotationZ = _model3D.RotationZ;
		}
		else if ("vi" == auto.field)
		{
			_hide = !Convert.ToBoolean(auto.auto.Frame(frammeTime).String);
		}
		else if ("rd-img" == auto.field)
		{
			RaderImage.RadarImage = auto.auto.Frame(frammeTime).String;
		}
		else if ("rd-sx" == auto.field)
		{
			RaderImage.ScaleX = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rd-sy" == auto.field)
		{
			RaderImage.ScaleY = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rd-alpha" == auto.field)
		{
			RaderImage.Alpha = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rd-mask" == auto.field)
		{
			RaderImage.Mask = (int)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rd-fullimg" == auto.field)
		{
			RaderImage.SmallMapFullImg = auto.auto.Frame(frammeTime).String;
		}
		else if ("rd-real-width" == auto.field)
		{
			RaderImage.RealWidth = (float)auto.auto.Frame(frammeTime).Float;
		}
		else if ("rd-real-height" == auto.field)
		{
			RaderImage.RealHeight = (float)auto.auto.Frame(frammeTime).Float;
		}
	}

	public void UIUpdate(int frameTime)
	{
		Render(null, MonoBehaviourSingleton<UnitySceneManager>.Instance);
		UpdateSmallMapImage();
	}
}
