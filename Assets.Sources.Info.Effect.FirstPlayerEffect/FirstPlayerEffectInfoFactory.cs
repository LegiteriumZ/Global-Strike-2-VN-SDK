using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Effect;
using Entitas.Utils;

namespace Assets.Sources.Info.Effect.FirstPlayerEffect;

public class FirstPlayerEffectInfoFactory
{
	private static FirstPlayerEffectInfoFactory _instance;

	public static FirstPlayerEffectInfoFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new FirstPlayerEffectInfoFactory();
			}
			return _instance;
		}
	}

	public List<IFirstPlayerEffectInfo> PlayerInfoList { get; private set; }

	public FirstPlayerEffectInfoFactory()
	{
		PlayerInfoList = new List<IFirstPlayerEffectInfo>();
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<IFirstPlayerEffectInfo>())
		{
			Instance.PlayerInfoList.Add(Activator.CreateInstance(x) as IFirstPlayerEffectInfo);
		}
	}

	public static void InitTypes()
	{
		Instance.PlayerInfoList.Add(new CarboxylicEffectInfo());
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<IFirstPlayerEffectInfo>())
		{
			return $"Instance.PlayerInfoList.Add(new {x.Name}());";
		}
		return "";
	}
}
