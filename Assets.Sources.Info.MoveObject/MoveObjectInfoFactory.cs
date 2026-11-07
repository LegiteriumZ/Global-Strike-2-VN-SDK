using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.MoveObject;
using Assets.Sources.Info.Res;
using Entitas.Utils;
using NetData;
using SSJJBase.Manager;

namespace Assets.Sources.Info.MoveObject;

public class MoveObjectInfoFactory : BattleSingletonInstance<MoveObjectInfoFactory>
{
	public Dictionary<string, Type> MoveObjectInfoDict { get; private set; }

	public MoveObjectInfoFactory()
	{
		MoveObjectInfoDict = new Dictionary<string, Type>();
	}

	public IMoveObjectInfo GetMoveObjectInfo(MoveEntityData data)
	{
		if (data.EType == 13)
		{
			data.Name = "Carboxylic";
		}
		MoveEntityConfig moveEntityConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetMoveEntityConfig(data.Name);
		if (moveEntityConfig == null || !MoveObjectInfoDict.TryGetValue(moveEntityConfig.Class, out var value))
		{
			value = GetDefault(data);
		}
		return Activator.CreateInstance(value) as IMoveObjectInfo;
	}

	private Type GetDefault(MoveEntityData data)
	{
		if (data.Name == "RPG_SURVIVALPVP_BUFF_1")
		{
			return typeof(RpgBoxTitleMoveObject);
		}
		return typeof(DefaultMoveObjectInfo);
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<IMoveObjectInfo>())
		{
			BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add(x.Name, x);
		}
	}

	public static void InitTypes()
	{
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("ZhuaZiInfo", typeof(ZhuaZiInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("MoveEntityEffectRenderObjectInfo", typeof(MoveEntityEffectRenderObjectInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("MedicalBagInfo", typeof(MedicalBagInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("FlybombMoveEntityEffectRenderObject", typeof(FlybombMoveEntityEffectRenderObject));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("FireBombMoveObjectInfo", typeof(FireBombMoveObjectInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("DoubleScytheHellInfo", typeof(DoubleScytheHellInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("DefaultMoveObjectInfo2", typeof(DefaultMoveObjectInfo2));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("DefaultMoveObjectInfo", typeof(DefaultMoveObjectInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("DefaultAngleMoveObjectInfo", typeof(DefaultAngleMoveObjectInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("DarkDrainInfo", typeof(DarkDrainInfo));
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Add("CarboxylicInfo", typeof(CarboxylicInfo));
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<IMoveObjectInfo>())
		{
			return string.Format("Instance.MoveObjectInfoDict.Add(\"{0}\", typeof({0}));", x.Name);
		}
		return "";
	}

	public override void Clear()
	{
		BattleSingletonInstance<MoveObjectInfoFactory>.Instance.MoveObjectInfoDict.Clear();
	}
}
