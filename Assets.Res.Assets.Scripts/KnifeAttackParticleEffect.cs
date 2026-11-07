using SSJJParticle;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[RequireComponent(typeof(ParticleSystem))]
public class KnifeAttackParticleEffect : AbstractKnifeEffectMb
{
	private float _frameTime = 1f;

	private ParticleSystem _particle;

	private SSJJParticleSystem _ssjjparticle;

	private bool _visable;

	public bool Disable { get; set; }

	public override void Play()
	{
		if (config != null && !_visable)
		{
			Show(config.EffectTime + 500);
		}
	}

	public override bool IsPlay()
	{
		if (_ssjjparticle != null)
		{
			return _ssjjparticle.isPlayer;
		}
		if (_particle != null)
		{
			return _particle.isPlaying;
		}
		return false;
	}

	private void Awake()
	{
		_particle = GetComponent<ParticleSystem>();
		_ssjjparticle = GetComponent<SSJJParticleSystem>();
		Renderer[] componentsInChildren = _particle.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material material = componentsInChildren[i].material;
			if (material != null)
			{
				if (material.shader.name.Equals("Particles/Additive"))
				{
					material.shader = Shader.Find("Particles/SSJJ/Additive");
				}
				else if (material.shader.name.Equals("Particles/Alpha Blended"))
				{
					material.shader = Shader.Find("Particles/SSJJ/Alpha Blended");
				}
				if (config.isFrist)
				{
					material.SetInt("_ZTest", 8);
					material.SetInt("_ZWrite", 0);
				}
				else
				{
					material.SetInt("_ZTest", 2);
					material.SetInt("_ZWrite", 0);
				}
			}
		}
		if (_particle != null)
		{
			_particle.Stop();
		}
		if (_ssjjparticle != null)
		{
			_ssjjparticle.Stop();
			_particle.GetComponent<Renderer>().enabled = false;
		}
	}

	private void Update()
	{
		if (!(_particle != null) || Mathf.Approximately(_frameTime, -1f))
		{
			return;
		}
		if (!_visable || Disable)
		{
			_particle.Stop();
			if (_ssjjparticle != null)
			{
				_ssjjparticle.Stop();
			}
			_frameTime = -1f;
		}
		else
		{
			_frameTime -= (int)(Time.deltaTime * 1000f);
		}
		if (_frameTime <= 0f)
		{
			_particle.Stop();
			if (_ssjjparticle != null)
			{
				_ssjjparticle.Stop();
			}
			_visable = false;
			_frameTime = -1f;
		}
	}

	public void Show(int frameTime)
	{
		if (_particle != null)
		{
			_particle.Clear();
			_particle.Stop();
			_particle.Play();
		}
		if (_ssjjparticle != null)
		{
			_ssjjparticle.Stop();
			_ssjjparticle.Play();
		}
		_visable = true;
		_frameTime = frameTime;
	}

	public override void Stop()
	{
		if (_visable || _frameTime > -1f)
		{
			if (_particle != null)
			{
				_particle.Clear();
				_particle.Stop();
			}
			if (_ssjjparticle != null)
			{
				_ssjjparticle.Stop();
			}
			_visable = false;
			_frameTime = -1f;
		}
	}
}
