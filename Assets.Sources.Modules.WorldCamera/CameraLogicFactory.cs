using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Info.Camera.CameraLogic;
using Entitas.Utils;
using SSJJBase.Manager;

namespace Assets.Sources.Modules.WorldCamera;

public class CameraLogicFactory : BattleSingletonInstance<CameraLogicFactory>
{
	public List<ICameraLogic> CameraLogicList { get; private set; }

	public CameraLogicFactory()
	{
		CameraLogicList = new List<ICameraLogic>();
	}

	public ICameraLogic GetCameraLogic<T>()
	{
		foreach (ICameraLogic cameraLogic in CameraLogicList)
		{
			if (cameraLogic is T)
			{
				return cameraLogic;
			}
		}
		return null;
	}

	private static int SortCompare(ICameraLogic left, ICameraLogic right)
	{
		return right.Priority() - left.Priority();
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ICameraLogic>() && Activator.CreateInstance(x) is ICameraLogic item)
		{
			BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(item);
		}
	}

	public static void InitTypes()
	{
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new UsingXpSkillLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new ParasiticEntityLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new ObserverLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new NormalThirdCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new NormalCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new MainControlCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new LockEntityCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new LockPlayerCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new FreeSpecialLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new DeadCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new ControlEntityLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new CameraValueLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new CameraEffectLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new P3HeroCameraLogic());
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Add(new TpsCameraLogic());
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ICameraLogic>())
		{
			return $"Instance.CameraLogicList.Add(new {x.Name}());";
		}
		return "";
	}

	public static void ForeachDone()
	{
		BattleSingletonInstance<CameraLogicFactory>.Instance.CameraLogicList.Sort(SortCompare);
	}

	public override void Clear()
	{
		CameraLogicList.Clear();
	}
}
