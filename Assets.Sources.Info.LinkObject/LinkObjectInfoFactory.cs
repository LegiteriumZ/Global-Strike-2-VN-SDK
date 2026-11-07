using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.LinkObject;
using Entitas.Utils;
using NetData;
using SSJJBase.Manager;

namespace Assets.Sources.Info.LinkObject;

public class LinkObjectInfoFactory : BattleSingletonInstance<LinkObjectInfoFactory>
{
	public Dictionary<string, ILinkObjectInfo> LinkObjectInfoDict { get; private set; }

	public LinkObjectInfoFactory()
	{
		LinkObjectInfoDict = new Dictionary<string, ILinkObjectInfo>();
	}

	public ILinkObjectInfo GetLinkObjectInfo(LinkEntityType type, int type2)
	{
		if (type2 > 0)
		{
			return new AbstractLinkObjectInfo();
		}
		switch (type)
		{
		case LinkEntityType.FLASHLINK:
			return new FlashLinkObjectInfo();
		case LinkEntityType.SOULLINK:
			return new SoulLinkObjectInfo();
		case LinkEntityType.ZHIZHUZHAOHUAN:
			return new ZhizhuLianxianLinkObjectInfo();
		case LinkEntityType.RPGFIRINGBEAMLINE:
		case LinkEntityType.PISTOFROZEN:
		case LinkEntityType.DAWNLIGHTSHOTGUNJIGUANG:
		case LinkEntityType.DAWNLIGHTSHOTGUN1JIGUANG:
		case LinkEntityType.DAWNLIGHTSHOTGUN2JIGUANG:
		case LinkEntityType.DAWNLIGHTSHOTGUN3JIGUANG:
			return new RpgFiringbeamlineLinkObjectInfo();
		case LinkEntityType.TPSSUOLIAN:
		case LinkEntityType.ACGLASER1:
			return new LoopLinkObjectInfo();
		case LinkEntityType.RAINBOWPISTOLBLUELINE:
		case LinkEntityType.RAINBOWPISTOLPURPLELINE:
		case LinkEntityType.RAINBOWPISTOLBLUELINEPINK:
		case LinkEntityType.RAINBOWPISTOLPURPLELINEPINK:
			return new TrackLinkObjectInfo();
		default:
			return new AbstractLinkObjectInfo();
		}
	}

	public static void ForeachType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ILinkObjectInfo>())
		{
			BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add(x.Name, Activator.CreateInstance(x) as ILinkObjectInfo);
		}
	}

	public static void InitTypes()
	{
		ZhizhuLianxianLinkObjectInfo value = new ZhizhuLianxianLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("ZhizhuLianxianLinkObjectInfo", value);
		SoulLinkObjectInfo value2 = new SoulLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("SoulLinkObjectInfo", value2);
		RpgFiringbeamlineLinkObjectInfo value3 = new RpgFiringbeamlineLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("RpgFiringbeamlineLinkObjectInfo", value3);
		LinkObjecInfo value4 = new LinkObjecInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("LinkObjecInfo", value4);
		FlashLinkObjectInfo value5 = new FlashLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("FlashLinkObjectInfo", value5);
		CommonLinkObjectInfo value6 = new CommonLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("CommonLinkObjectInfo", value6);
		AbstractLinkObjectInfo value7 = new AbstractLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("AbstractLinkObjectInfo", value7);
		LoopLinkObjectInfo value8 = new LoopLinkObjectInfo();
		BattleSingletonInstance<LinkObjectInfoFactory>.Instance.LinkObjectInfoDict.Add("LoopLinkObjectInfo", value8);
	}

	public static string CheckInitType(Type x)
	{
		if (x.IsClass && !x.IsAbstract && x.ImplementsInterface<ILinkObjectInfo>())
		{
			return string.Format("var info{0} = new {0}(); Instance.LinkObjectInfoDict.Add(\"{0}\", info{0});", x.Name);
		}
		return "";
	}

	public override void Clear()
	{
		LinkObjectInfoDict.Clear();
	}
}
