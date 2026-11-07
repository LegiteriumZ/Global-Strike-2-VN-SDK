using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Effect;
using Entitas.Utils;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class SceneBuffEffectInfoFactory
{
	private static SceneBuffEffectInfoFactory _instance;

	public static SceneBuffEffectInfoFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SceneBuffEffectInfoFactory();
			}
			return _instance;
		}
	}

	public List<ISceneBufferEffectInfo> BuffEffectInfoList { get; private set; }

	public ISceneBufferEffectInfo DefaultSceneBuffer { get; private set; }

	public SceneBuffEffectInfoFactory()
	{
		BuffEffectInfoList = new List<ISceneBufferEffectInfo>();
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ISceneBufferEffectInfo>())
		{
			if (x.Name == "SceneBufferEffectInfo")
			{
				Instance.DefaultSceneBuffer = Activator.CreateInstance(x) as ISceneBufferEffectInfo;
			}
			else
			{
				Instance.BuffEffectInfoList.Add(Activator.CreateInstance(x) as ISceneBufferEffectInfo);
			}
		}
	}

	public static void InitTypes()
	{
		Instance.BuffEffectInfoList.Add(new EnergyPrepareEffectInfo());
		Instance.BuffEffectInfoList.Add(new EnergyReadyEffectInfo());
		Instance.BuffEffectInfoList.Add(new WeaponBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new WayPointBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new WayPoint2BufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new TianhuoshizheBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new StrongholdBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new SkillBufferEffectInfo());
		Instance.DefaultSceneBuffer = new SceneBufferEffectInfo();
		Instance.BuffEffectInfoList.Add(new RpgIceGranadeExplosionEffectInfo());
		Instance.BuffEffectInfoList.Add(new RobChickenBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new PveBuySkillBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new PveBuyBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new KrissHealEffectInfo());
		Instance.BuffEffectInfoList.Add(new KongzhiqiBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new JumpStartBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new JumpEndBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new IntelligenceBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new HuoyanBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new HeroSwordBufferEffectInfo());
		Instance.BuffEffectInfoList.Add(new EnergyDeviceEffectInfo());
		Instance.BuffEffectInfoList.Add(new BreakPointEffectInfo());
		Instance.BuffEffectInfoList.Add(new AmmunitionEffectInfo());
		Instance.BuffEffectInfoList.Add(new AccelerateEffectInfo());
		Instance.BuffEffectInfoList.Add(new SafeAreaEffectInfo());
		Instance.BuffEffectInfoList.Add(new GunFightFlagEffectInfo());
		Instance.BuffEffectInfoList.Add(new BravebieberSceneEffectInfo());
		Instance.BuffEffectInfoList.Add(new AwakeningSceneEffectInfo());
		Instance.BuffEffectInfoList.Add(new GoHeSceneEffectInfo());
		Instance.BuffEffectInfoList.Add(new GoHeCrystalSceneEffectInfo());
		Instance.BuffEffectInfoList.Add(new GoHeSakuraSceneEffectInfo());
		Instance.BuffEffectInfoList.Add(new GoHeElecSceneEffectInfo());
		Instance.BuffEffectInfoList.Add(new ShutterFlashbangTagEffectInfo());
		Instance.BuffEffectInfoList.Add(new TransmitSceneBuffEffectRender());
		Instance.BuffEffectInfoList.Add(new HomeLandLockEffect());
		Instance.BuffEffectInfoList.Add(new IconEffect());
		Instance.BuffEffectInfoList.Add(new DistanceShowEffect());
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ISceneBufferEffectInfo>())
		{
			if (x.Name == "SceneBufferEffectInfo")
			{
				return $"Instance.DefaultSceneBuffer = new {x.Name}();";
			}
			return $"Instance.BuffEffectInfoList.Add(new {x.Name}());";
		}
		return "";
	}
}
