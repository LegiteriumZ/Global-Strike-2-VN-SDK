using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Npc;
using Entitas.Utils;
using SSJJBase.Manager;

namespace Assets.Sources.Info.Npc;

public class NpcInfoFactory : BattleSingletonInstance<NpcInfoFactory>
{
	public Dictionary<string, Type> TypeInfoMap { get; private set; }

	public NpcInfoFactory()
	{
		TypeInfoMap = new Dictionary<string, Type>();
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<INpcInfo>())
		{
			BattleSingletonInstance<NpcInfoFactory>.Instance.TypeInfoMap.Add(x.Name, x);
		}
	}

	public static void InitTypes()
	{
		BattleSingletonInstance<NpcInfoFactory>.Instance.TypeInfoMap.Add("Dragoon01Info", typeof(Dragoon01Info));
		BattleSingletonInstance<NpcInfoFactory>.Instance.TypeInfoMap.Add("DefaultBattlePetInfo", typeof(DefaultBattlePetInfo));
		BattleSingletonInstance<NpcInfoFactory>.Instance.TypeInfoMap.Add("ChickenInfo", typeof(ChickenInfo));
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<INpcInfo>())
		{
			return string.Format("Instance.TypeInfoMap.Add(\"{0}\", typeof({0}));", x.Name);
		}
		return "";
	}

	public override void Clear()
	{
		TypeInfoMap.Clear();
	}
}
