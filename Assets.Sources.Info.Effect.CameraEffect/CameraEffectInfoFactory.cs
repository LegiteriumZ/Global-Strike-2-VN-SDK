using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.CameraEffect;
using Entitas.Utils;

namespace Assets.Sources.Info.Effect.CameraEffect;

public class CameraEffectInfoFactory
{
	private static CameraEffectInfoFactory _instance;

	public static CameraEffectInfoFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new CameraEffectInfoFactory();
			}
			return _instance;
		}
	}

	public List<ICameraEffectInfo> EffectInfoList { get; private set; }

	public CameraEffectInfoFactory()
	{
		EffectInfoList = new List<ICameraEffectInfo>();
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ICameraEffectInfo>())
		{
			Instance.EffectInfoList.Add(Activator.CreateInstance(x) as ICameraEffectInfo);
		}
	}

	public static void InitTypes()
	{
		Instance.EffectInfoList.Add(new PlayerCameraEffectInfo());
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ICameraEffectInfo>())
		{
			return $"Instance.EffectInfoList.Add(new {x.Name}());";
		}
		return "";
	}
}
