using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance.Action;
using Assets.Sources.Components.Interface;
using Assets.Sources.Config;
using SSJJParticle;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class PaticlePrefabInstancecs : MonoBehaviour, IPaticlePrefabInstancecs
{
	[Serializable]
	public class PlayerInfoEffectConfig : IPlayerInfoEffectConfig
	{
		public int StatusId;

		public bool Visiable = true;

		public bool IsEffect()
		{
			return StatusId > 0;
		}

		public bool getVisiable()
		{
			return Visiable;
		}

		public int getStatusId()
		{
			return StatusId;
		}
	}

	[Serializable]
	public class WeaponAnimationEffectConfig : IWeaponAnimationEffectConfig
	{
		public int AnimId;

		public int StartTime;

		public int VisibleType;

		public int FinishTime;

		public bool Equals(WeaponAnimationEffectConfig other)
		{
			if (other.AnimId > 0 && AnimId.Equals(other.AnimId) && StartTime.Equals(other.StartTime) && VisibleType.Equals(other.VisibleType))
			{
				return FinishTime.Equals(other.FinishTime);
			}
			return false;
		}

		public bool IsEffect()
		{
			return AnimId > 0;
		}

		public bool IsRangeNpc(int aniId, int visibleType)
		{
			if (!IsEffect())
			{
				return true;
			}
			if (aniId == AnimId && (VisibleType == 0 || visibleType == VisibleType))
			{
				return true;
			}
			return false;
		}

		public bool IsRange(int aniId, int remainTime, int visibleType)
		{
			if (!IsEffect())
			{
				return true;
			}
			if (aniId == AnimId && remainTime >= FinishTime && remainTime <= StartTime && (VisibleType == 0 || visibleType == VisibleType))
			{
				return true;
			}
			return false;
		}
	}

	public string effectName;

	public uint VisibleState;

	public string animClass;

	public string animParameter;

	private float _orientationRate;

	public List<uint> VisibleStateList = new List<uint>();

	protected GameObject ins;

	public GameObject instance;

	public Vector3 LocalEulerAngles;

	public Vector3 LocalPosition;

	public Vector3 LocalScala = new Vector3(1f, 1f, 1f);

	public List<ParticleSystemRenderer> AllSystems;

	private ParticleSystem _cache;

	private SSJJParticleSystem _ssjjCache;

	public List<RecordOriginal> OriginalList;

	public bool CustomScalingMode;

	public PlayerInfoEffectConfig PlayerInfoEffect = new PlayerInfoEffectConfig();

	public WeaponAnimationEffectConfig AnimationEffectConfig = new WeaponAnimationEffectConfig();

	public string AccessoryAnimation;

	public string RenderSkin;

	public Vector3 ParticleScaleVec = new Vector3(1f, 1f, 1f);

	protected bool _nowVisiable = true;

	protected bool _levelVisiable = true;

	protected bool _showDistance = true;

	protected int _showlevel = -1;

	private bool joinActive = true;

	private bool _isInitVisibleState;

	protected ParticleSystem cacheSystem
	{
		get
		{
			if (_cache == null && ins != null)
			{
				_cache = ins.GetComponent<ParticleSystem>();
			}
			return _cache;
		}
		set
		{
			_cache = value;
		}
	}

	protected SSJJParticleSystem ssjjCacheSystem
	{
		get
		{
			if (_ssjjCache == null && ins != null)
			{
				_ssjjCache = ins.GetComponent<SSJJParticleSystem>();
				if (_ssjjCache != null && !string.IsNullOrEmpty(effectName))
				{
					_ssjjCache.autoPlay = true;
				}
			}
			return _ssjjCache;
		}
		set
		{
			_ssjjCache = value;
		}
	}

	public GameObject getGameObject()
	{
		return base.gameObject;
	}

	public GameObject getInstance()
	{
		return instance;
	}

	public float GetOrientationRate()
	{
		return _orientationRate;
	}

	public uint getVisibleState()
	{
		return VisibleState;
	}

	public string getAccessoryAnimation()
	{
		return AccessoryAnimation;
	}

	public List<uint> getVisibleStateList()
	{
		return VisibleStateList;
	}

	public IPlayerInfoEffectConfig getPlayerInfoEffectConfig()
	{
		return PlayerInfoEffect;
	}

	public void PlayerInfoEffectParse(int statusId, bool visiable)
	{
		PlayerInfoEffect.StatusId = statusId;
		PlayerInfoEffect.Visiable = visiable;
	}

	public IWeaponAnimationEffectConfig getAnimationEffectConfig()
	{
		return AnimationEffectConfig;
	}

	public void AnimEffectParse(int animId, int finishTime, int startTime, int visibleType)
	{
		AnimationEffectConfig.AnimId = animId;
		AnimationEffectConfig.FinishTime = finishTime;
		AnimationEffectConfig.StartTime = startTime;
		AnimationEffectConfig.VisibleType = visibleType;
	}

	public bool GetLevelVisiable()
	{
		return _levelVisiable;
	}

	public bool GetNowVisiable()
	{
		if (_nowVisiable)
		{
			return joinActive;
		}
		return false;
	}

	public bool GetshowDistance()
	{
		return _showDistance;
	}

	public void SetshowDistance(bool isShow)
	{
		_showDistance = isShow;
	}

	public void SetshowLevel(int showlevel)
	{
		_showlevel = showlevel;
	}

	public int GetshowLevel()
	{
		return _showlevel;
	}

	public GameObject GetIns()
	{
		return ins;
	}

	public virtual void Awake()
	{
		TryInstantiate();
	}

	public void TryInstantiate()
	{
		if ((bool)GetComponent<OrientationRatePrefabInstancecs>())
		{
			_orientationRate = GetComponent<OrientationRatePrefabInstancecs>()._orientationRate;
		}
		if (!(ins == null) || !(instance != null))
		{
			return;
		}
		LocalScala = ParticleScaleVec;
		if ((double)Math.Abs(LocalScala.x - 0f) < 0.001 || (double)Math.Abs(LocalScala.y - 0f) < 0.001 || (double)Math.Abs(LocalScala.z - 0f) < 0.001)
		{
			LocalScala = new Vector3(1f, 1f, 1f);
		}
		ins = UnityEngine.Object.Instantiate(instance);
		ins.transform.SetParent(base.transform);
		ins.transform.localPosition = LocalPosition;
		ins.transform.localEulerAngles = LocalEulerAngles;
		ins.transform.localScale = LocalScala;
		ins.layer = base.gameObject.layer;
		ins.tag = base.gameObject.tag;
		Component[] componentsInChildren = ins.GetComponentsInChildren<Component>(includeInactive: true);
		foreach (Component component in componentsInChildren)
		{
			if (component == null)
			{
				continue;
			}
			component.gameObject.layer = base.gameObject.layer;
			if (component is ParticleSystem)
			{
				ParticleSystem particleSystem = component as ParticleSystem;
				if (!CustomScalingMode)
				{
					ParticleSystem.MainModule main = particleSystem.main;
					main.scalingMode = ParticleSystemScalingMode.Hierarchy;
				}
			}
			else if (component is ParticleSystemRenderer)
			{
				ParticleSystemRenderer item = component as ParticleSystemRenderer;
				if (AllSystems == null)
				{
					AllSystems = new List<ParticleSystemRenderer>();
				}
				AllSystems.Add(item);
			}
		}
		if (VisibleState != 0)
		{
			ins.SetObjectActive(isactive: false);
			_nowVisiable = false;
		}
		if (!string.IsNullOrEmpty(animClass))
		{
			SetAnim(animClass, animParameter);
		}
		if (_ssjjCache == null)
		{
			_ssjjCache = ins.GetComponent<SSJJParticleSystem>();
			if (_ssjjCache != null && !string.IsNullOrEmpty(effectName))
			{
				_ssjjCache.autoPlay = true;
			}
		}
	}

	private void Start()
	{
		TryDestoryParticleComponent();
	}

	private void TryDestoryParticleComponent()
	{
		if (!(ins == null))
		{
			ParticleSystem component = ins.GetComponent<ParticleSystem>();
			if (component != null && !component.emission.enabled && component.GetComponent<IFireEffectControl>() == null && component.GetComponent<AbstractKnifeEffectMb>() == null)
			{
				UnityEngine.Object.DestroyImmediate(component);
			}
		}
	}

	public virtual void SetInsActive(bool flag, bool isjoinActive = false)
	{
		if (ins != null)
		{
			if (isjoinActive)
			{
				joinActive = flag;
			}
			else
			{
				_nowVisiable = flag;
			}
		}
	}

	public void LateUpdate()
	{
		if (!(ins != null))
		{
			return;
		}
		bool flag = _nowVisiable && joinActive;
		if (_levelVisiable && (_showDistance || GameSetting.Config.EffectParticleDistance == 100 || !flag) && ins.IsActiveSelf() != flag)
		{
			ins.SetObjectActive(flag);
			if (flag && ssjjCacheSystem != null)
			{
				ssjjCacheSystem.Play();
			}
		}
	}

	public virtual void RefreshLevelActive(bool levelVisiable)
	{
		_levelVisiable = levelVisiable;
		bool flag = _nowVisiable && joinActive;
		if (levelVisiable && (_showDistance || GameSetting.Config.EffectParticleDistance == 100))
		{
			if (flag)
			{
				ins.SetObjectActive(flag);
				if (ssjjCacheSystem != null)
				{
					ssjjCacheSystem.Play();
				}
			}
		}
		else if (ins.IsActiveSelf())
		{
			ins.SetObjectActive(isactive: false);
		}
	}

	public bool GetInsActiveState()
	{
		return ins.activeSelf;
	}

	public void SetInsScale(float scale)
	{
		if (ins != null)
		{
			LocalScala.x = (LocalScala.y = (LocalScala.z = scale));
			ins.transform.localScale = LocalScala;
		}
	}

	public void SetInsScaleX(float scale)
	{
		if (ins != null)
		{
			LocalScala.x = scale;
			ins.transform.localScale = LocalScala;
		}
	}

	public void SetInsScaleY(float scale)
	{
		if (ins != null)
		{
			LocalScala.y = scale;
			ins.transform.localScale = LocalScala;
		}
	}

	public void SetInsScaleZ(float scale)
	{
		if (ins != null)
		{
			LocalScala.z = scale;
			ins.transform.localScale = LocalScala;
		}
	}

	public void Stop()
	{
		if (ins != null && cacheSystem != null)
		{
			cacheSystem.Stop();
		}
		if (ins != null && ssjjCacheSystem != null)
		{
			ssjjCacheSystem.Stop();
		}
	}

	public void InitVisibleState()
	{
		if (!_isInitVisibleState)
		{
			_isInitVisibleState = true;
			GetVisibleList(VisibleState);
		}
	}

	private void GetVisibleList(uint state)
	{
		uint num = state / 100;
		uint item = state % 100;
		VisibleStateList.Add(item);
		if (num != 0)
		{
			GetVisibleList(num);
		}
	}

	public void Play()
	{
		if (ins != null && cacheSystem != null && cacheSystem.isStopped)
		{
			cacheSystem.Play();
		}
		if (ins != null && ssjjCacheSystem != null)
		{
			ssjjCacheSystem.Play();
		}
	}

	public void StopAndRestart()
	{
		if (!(ins != null))
		{
			return;
		}
		if (cacheSystem == null)
		{
			cacheSystem = ins.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
			ParticleSystemRenderer component = cacheSystem.GetComponent<ParticleSystemRenderer>();
			if (component != null)
			{
				UnityEngine.Object.DestroyImmediate(component);
			}
		}
		else
		{
			cacheSystem.Stop();
			cacheSystem.Play();
		}
		if (ssjjCacheSystem != null)
		{
			ssjjCacheSystem.Stop();
			ssjjCacheSystem.Play();
		}
	}

	public void Restart()
	{
		if (ins != null && cacheSystem != null)
		{
			cacheSystem.Play();
		}
		if (ins != null && ssjjCacheSystem != null)
		{
			ssjjCacheSystem.Play();
		}
	}

	public bool IsStoped()
	{
		if (ins != null && cacheSystem != null)
		{
			return cacheSystem.isStopped;
		}
		return false;
	}

	public void SetAnim(string animClass, string animParameter)
	{
		string assemblyQualifiedName = typeof(EffectAnimBase).AssemblyQualifiedName;
		if (assemblyQualifiedName != null)
		{
			Type type = Type.GetType(assemblyQualifiedName.Replace("EffectAnimBase", animClass));
			(ins.AddComponent(type) as EffectAnimBase).animParameter = animParameter;
		}
	}

	public void SetAlpha(float alpha)
	{
		if (_ssjjCache != null)
		{
			global::SSJJParticle.SSJJParticle[] ssjjpaList = _ssjjCache.ssjjpaList;
			foreach (global::SSJJParticle.SSJJParticle obj in ssjjpaList)
			{
				Color color = obj.mater.GetColor("_TintColor");
				color.a = alpha / 2f;
				obj.mater.SetColor("_TintColor", color);
			}
		}
		if (OriginalList == null)
		{
			return;
		}
		foreach (RecordOriginal original in OriginalList)
		{
			original.SetAlpha(alpha);
		}
	}

	public void SetInsRotationX(float value)
	{
		if (ins != null)
		{
			ins.transform.localEulerAngles = LocalEulerAngles;
			ins.transform.Rotate(Vector3.right, 0f - value);
		}
	}

	public void SetInsRotationY(float value)
	{
		if (ins != null)
		{
			ins.transform.localEulerAngles = LocalEulerAngles;
			ins.transform.Rotate(Vector3.forward, 0f - value);
		}
	}

	public void SetInsRotationZ(float value)
	{
		if (ins != null)
		{
			ins.transform.localEulerAngles = LocalEulerAngles;
			ins.transform.Rotate(Vector3.up, 0f - value);
		}
	}
}
