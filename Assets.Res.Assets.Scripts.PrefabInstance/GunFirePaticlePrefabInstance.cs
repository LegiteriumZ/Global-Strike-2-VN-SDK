using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class GunFirePaticlePrefabInstance : PaticlePrefabInstancecs, IGunFirePaticlePrefabInstance
{
	public bool IsRestart;

	public int FrameTime = 50;

	private ParticleFireEffect fire;

	public override void Awake()
	{
		base.Awake();
		if (instance != null)
		{
			fire = ins.AddComponent<ParticleFireEffect>();
			fire.IsRestart = IsRestart;
			fire.FrameTime = FrameTime;
			ParticleSystem component = ins.GetComponent<ParticleSystem>();
			ParticleSystem[] componentsInChildren = ins.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ParticleSystem.MainModule main = componentsInChildren[i].main;
				main.playOnAwake = false;
			}
			component.Stop();
		}
	}

	public override void SetInsActive(bool flag, bool isJoinActive = false)
	{
		if (!(ins != null))
		{
			return;
		}
		_nowVisiable = flag;
		if (_levelVisiable && ins.IsActiveSelf() != flag)
		{
			ins.SetObjectActive(flag);
			if (flag && (bool)fire && (isJoinActive || fire.IsNewSSJJParticleSystem()))
			{
				fire.Fire(special: true);
			}
		}
	}
}
