using System.Collections;
using SSJJParticle;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleFireEffect : IFireEffectControl
{
	private float _frameTime = 16.666666f;

	public float FrameTime = 16.666666f;

	public bool IsRestart;

	private ParticleSystem _particleSystem;

	private SSJJParticleSystem _ssjjparticleSystem;

	[SerializeField]
	private Renderer[] _renderers;

	[SerializeField]
	private bool _visable;

	[SerializeField]
	private bool _noUse;

	private IEnumerator _task;

	private int fireFrameCount;

	public bool Visible
	{
		get
		{
			return _visable;
		}
		set
		{
			if (_visable != value)
			{
				_visable = value;
				UpdateStatus();
			}
		}
	}

	private void Awake()
	{
		_particleSystem = GetComponent<ParticleSystem>();
		_ssjjparticleSystem = GetComponent<SSJJParticleSystem>();
		_renderers = _particleSystem.GetComponentsInChildren<Renderer>();
		UpdateStatus();
	}

	public bool IsNewSSJJParticleSystem()
	{
		return _ssjjparticleSystem != null;
	}

	private void OnDisable()
	{
		if (!_noUse)
		{
			Visible = false;
			if (_task != null)
			{
				StopCoroutine(_task);
			}
		}
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private void UpdateStatus()
	{
		SetRender(Visible);
	}

	private IEnumerator YieldHide()
	{
		while (_frameTime > 0f)
		{
			_frameTime -= Time.deltaTime * 1000f;
			yield return null;
		}
		_frameTime = 0f;
		Visible = false;
		if (_particleSystem != null)
		{
			_particleSystem.Pause();
		}
		if (_ssjjparticleSystem != null)
		{
			_ssjjparticleSystem.Stop();
		}
	}

	public override bool Fire(bool special)
	{
		if (_noUse)
		{
			return false;
		}
		bool result = false;
		if (base.gameObject.activeInHierarchy && _particleSystem != null && Time.frameCount - fireFrameCount > 4)
		{
			fireFrameCount = Time.frameCount;
			Visible = true;
			result = true;
			_frameTime = FrameTime;
			if (IsRestart)
			{
				_particleSystem.Stop();
				_particleSystem.Play();
				if (_ssjjparticleSystem != null)
				{
					_ssjjparticleSystem.Stop();
					_ssjjparticleSystem.Play();
				}
			}
			_particleSystem.Play();
			if (_ssjjparticleSystem != null)
			{
				_ssjjparticleSystem.Play(isRestart: false);
			}
			if (_task != null)
			{
				StopCoroutine(_task);
			}
			_task = YieldHide();
			StartCoroutine(_task);
		}
		return result;
	}

	public override void SetRender(bool flag)
	{
		for (int num = _renderers.Length - 1; num >= 0; num--)
		{
			_renderers[num].enabled = flag && _ssjjparticleSystem == null;
		}
		if (_ssjjparticleSystem != null)
		{
			_ssjjparticleSystem.isShow = flag;
		}
	}

	public override void SetNoUse()
	{
		_noUse = true;
		base.enabled = false;
		SetRender(flag: true);
		_particleSystem.Play();
		if (_ssjjparticleSystem != null)
		{
			_ssjjparticleSystem.Play(isRestart: false);
		}
	}
}
