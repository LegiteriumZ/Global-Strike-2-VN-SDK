using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using UnityEngine;

namespace Assets.Sources.Info.Particle.Lod;

public class ParticleLodContainer : MonoBehaviour
{
	[Serializable]
	public class ParticleLodConfig
	{
		public Transform Transform;

		public ParticleSystem ParticleSystem;

		public ParticleSystemRenderer ParticleSystemRenderer;

		public MeshRenderer MeshRenderer;

		public Animator Animator;

		public int Size;

		public int MaxParticle;

		public int NowLevel;

		public int OriginLevel;

		public int VisiableLevel;

		public int LodLevelLimit = 30;

		public int VisiableLevelLimit = 6;

		private int _capLimit = 1;

		private bool _isCheck;

		public int CapLimit => _capLimit;

		public void Check(GameObject objGameObject)
		{
			if (!_isCheck)
			{
				_isCheck = true;
				OriginLevel = (VisiableLevel = 1000);
			}
		}

		public void Refresh(ParticleLodContainer container, int level, bool isFov)
		{
			Check(container.gameObject);
			if (isFov || level == 0)
			{
				level = 1000;
			}
			if (VisiableLevel >= VisiableLevelLimit && level < VisiableLevelLimit)
			{
				if (ParticleSystem != null)
				{
					ParticleSystemRenderer.enabled = false;
				}
				if (MeshRenderer != null)
				{
					MeshRenderer.enabled = false;
				}
			}
			else if (level >= VisiableLevelLimit && VisiableLevel < VisiableLevelLimit && container.FireEffect == null)
			{
				if (ParticleSystem != null)
				{
					ParticleSystemRenderer.enabled = true;
				}
				if (MeshRenderer != null)
				{
					MeshRenderer.enabled = true;
				}
			}
			if (OriginLevel >= LodLevelLimit && level < LodLevelLimit)
			{
				if (ParticleSystem != null)
				{
					ParticleSystem.MainModule main = ParticleSystem.main;
					if (MaxParticle > 2)
					{
						main.maxParticles = MaxParticle / 2;
					}
					if (Animator != null)
					{
						Animator.enabled = false;
					}
				}
			}
			else if (OriginLevel < LodLevelLimit && level >= LodLevelLimit && ParticleSystem != null)
			{
				ParticleSystem.MainModule main2 = ParticleSystem.main;
				main2.maxParticles = MaxParticle;
				if (Animator != null)
				{
					Animator.enabled = true;
				}
			}
			NowLevel = (OriginLevel = (VisiableLevel = level));
		}
	}

	public List<ParticleLodConfig> SelfConfigs;

	public IFireEffectControl FireEffect;

	public int FrameOff;

	private bool _init;

	public void Disable()
	{
		for (int i = 0; i < SelfConfigs.Count; i++)
		{
			ParticleLodConfig particleLodConfig = SelfConfigs[i];
			if (particleLodConfig.ParticleSystemRenderer != null)
			{
				particleLodConfig.ParticleSystemRenderer.enabled = true;
			}
			if (particleLodConfig.MeshRenderer != null)
			{
				particleLodConfig.MeshRenderer.enabled = true;
			}
			particleLodConfig.VisiableLevel = (particleLodConfig.OriginLevel = 1000);
		}
	}

	public void CheckInit(float scale)
	{
		if (_init)
		{
			return;
		}
		_init = true;
		int num = 200;
		FrameOff = Mathf.RoundToInt(UnityEngine.Random.value * 10f);
		SelfConfigs = new List<ParticleLodConfig>(8);
		ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		MeshRenderer[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<MeshRenderer>();
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			if (!particleSystem.emission.enabled || !particleSystem.GetComponent<ParticleSystemRenderer>().enabled)
			{
				continue;
			}
			ParticleLodConfig particleLodConfig = new ParticleLodConfig();
			particleLodConfig.Transform = base.transform;
			particleLodConfig.Animator = base.transform.GetComponent<Animator>();
			particleLodConfig.ParticleSystemRenderer = particleSystem.GetComponent<ParticleSystemRenderer>();
			particleLodConfig.ParticleSystem = particleSystem;
			particleLodConfig.Size = CaculateParticleCap(particleSystem, particleLodConfig.ParticleSystemRenderer) + 1;
			particleLodConfig.MaxParticle = particleSystem.main.maxParticles;
			if (particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World)
			{
				particleLodConfig.Size = (int)((float)particleLodConfig.Size * 1.1f);
			}
			if (particleLodConfig.Size < num && particleLodConfig.Size > particleLodConfig.CapLimit)
			{
				if (particleLodConfig.Size < 5)
				{
					particleLodConfig.Size = 5;
				}
				particleLodConfig.VisiableLevelLimit = Mathf.FloorToInt((float)particleLodConfig.VisiableLevelLimit / scale);
				particleLodConfig.LodLevelLimit = Mathf.FloorToInt((float)particleLodConfig.LodLevelLimit / scale);
				SelfConfigs.Add(particleLodConfig);
			}
		}
		foreach (MeshRenderer meshRenderer in componentsInChildren2)
		{
			ParticleLodConfig particleLodConfig2 = new ParticleLodConfig();
			particleLodConfig2.Animator = base.transform.GetComponent<Animator>();
			particleLodConfig2.Size = CaculateMeshRenderCap(meshRenderer) + 1;
			particleLodConfig2.MeshRenderer = meshRenderer;
			particleLodConfig2.Transform = base.transform;
			if (particleLodConfig2.Size < num && particleLodConfig2.Size > particleLodConfig2.CapLimit)
			{
				if (particleLodConfig2.Size < 5)
				{
					particleLodConfig2.Size = 5;
				}
				particleLodConfig2.VisiableLevelLimit = Mathf.FloorToInt((float)particleLodConfig2.VisiableLevelLimit / scale);
				particleLodConfig2.LodLevelLimit = Mathf.FloorToInt((float)particleLodConfig2.LodLevelLimit / scale);
				SelfConfigs.Add(particleLodConfig2);
			}
		}
	}

	private int CaculateParticleCap(ParticleSystem ps, ParticleSystemRenderer render)
	{
		if (render.renderMode == ParticleSystemRenderMode.Mesh)
		{
			float num = GetMaxSize(ps) * GetShapeSize(ps) * GetMaxScale(ps.transform) * CaculateMeshCap(render.mesh);
			if (GetMaxSpeed(ps) >= 1f)
			{
				num *= GetMaxForce(ps) * GetLifeTime(ps) * GetMaxSpeed(ps);
			}
			return (int)(num * 1.1f);
		}
		float num2 = GetMaxSize(ps) * GetShapeSize(ps) * GetMaxScale(ps.transform);
		if (GetMaxSpeed(ps) >= 1f)
		{
			num2 *= GetMaxForce(ps) * GetLifeTime(ps) * GetMaxSpeed(ps);
		}
		return (int)num2;
	}

	private float GetShapeSize(ParticleSystem ps)
	{
		return 1f;
	}

	private float GetMaxForce(ParticleSystem ps)
	{
		return 1f;
	}

	private float GetLifeTime(ParticleSystem ps)
	{
		return 1f;
	}

	private float GetMaxSpeed(ParticleSystem ps)
	{
		return 1f;
	}

	private float GetMaxSize(ParticleSystem ps)
	{
		ParticleSystem.MinMaxCurve startSize = ps.main.startSize;
		float num = GetCurveMax(startSize);
		if (ps.sizeOverLifetime.enabled)
		{
			float curveMax = GetCurveMax(ps.sizeOverLifetime.x);
			float curveMax2 = GetCurveMax(ps.sizeOverLifetime.y);
			num = Mathf.Max(b: GetCurveMax(ps.sizeOverLifetime.z), a: Mathf.Max(curveMax, curveMax2)) * num;
		}
		if (ps.main.maxParticles > 5)
		{
			num *= (float)ps.main.maxParticles / 5f;
		}
		return num;
	}

	private float GetCurveMax(ParticleSystem.MinMaxCurve curve)
	{
		if (curve.mode == ParticleSystemCurveMode.Constant)
		{
			return curve.constant;
		}
		if (curve.mode == ParticleSystemCurveMode.TwoConstants)
		{
			return curve.constantMax;
		}
		if (curve.mode == ParticleSystemCurveMode.Curve)
		{
			return Mathf.Max(Mathf.Max(curve.Evaluate(0f), curve.Evaluate(1f)), curve.Evaluate(0.5f));
		}
		if (curve.mode == ParticleSystemCurveMode.TwoCurves)
		{
			return Mathf.Max(Mathf.Max(curve.curveMin.Evaluate(0f), curve.curveMin.Evaluate(1f)), Mathf.Max(curve.curveMax.Evaluate(0f), curve.curveMax.Evaluate(1f)));
		}
		return curve.constantMax;
	}

	private int CaculateMeshRenderCap(MeshRenderer meshRenderer)
	{
		MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
		if (component != null)
		{
			return (int)(GetMaxScale(meshRenderer.transform) * CaculateMeshCap(component.sharedMesh) * 1.1f);
		}
		return 100;
	}

	private float GetMaxScale(Transform tran)
	{
		return Mathf.Max(Mathf.Max(tran.lossyScale.x, tran.lossyScale.y), tran.lossyScale.z);
	}

	private float CaculateMeshCap(Mesh mesh)
	{
		if (mesh == null)
		{
			return 1000f;
		}
		float a = Mathf.Abs(mesh.bounds.max.x - mesh.bounds.min.x);
		float b = Mathf.Abs(mesh.bounds.max.y - mesh.bounds.min.y);
		return Mathf.Max(b: Mathf.Abs(mesh.bounds.max.z - mesh.bounds.min.z), a: Mathf.Max(a, b));
	}
}
