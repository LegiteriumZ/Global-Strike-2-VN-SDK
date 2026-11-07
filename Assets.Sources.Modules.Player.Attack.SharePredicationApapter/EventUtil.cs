using System;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class EventUtil : IEventUtil
{
	public static IEventUtil Instance = new EventUtil();

	public void SendEvent(ICommonWeaponArgs arg, int eventId)
	{
		throw new NotImplementedException();
	}
}
