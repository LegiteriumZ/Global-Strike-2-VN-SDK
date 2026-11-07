using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class HomeLandInfoMessageHandler : ApcPacketHandler<HomelandInfoData>
{
	public override int MethodId()
	{
		return 606;
	}

	public override void Handle(HomelandInfoData data)
	{
		Contexts.sharedInstance.message.homeLandScene.CharacterId = data.CharacterId;
		Contexts.sharedInstance.message.homeLandScene.UnlockedIds = data.UnlockedIds;
		if (Contexts.sharedInstance.message.homeLandScene.msg_List == null)
		{
			Contexts.sharedInstance.message.homeLandScene.msg_List = new List<HomelandWeaponData>();
		}
		Contexts.sharedInstance.message.homeLandScene.msg_List.AddRange(data.WeaponData);
		Contexts.sharedInstance.message.homeLandScene.leftWeekRentOutCount = data.LeftWeekRentOutCount;
		Contexts.sharedInstance.message.homeLandScene.leftMonthRentOutCount = data.LeftMonthRentOutCount;
		Contexts.sharedInstance.message.homeLandScene.teamId = data.TeamId;
	}
}
