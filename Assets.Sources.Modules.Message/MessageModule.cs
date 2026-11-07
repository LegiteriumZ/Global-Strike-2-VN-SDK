using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Message.Common;
using Assets.Sources.Modules.Message.Rpg;

namespace Assets.Sources.Modules.Message;

public class MessageModule : GameModule
{
	public MessageModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		AddMsgSystem(contexts, systems, new RpgTipsSystem(contexts));
		AddMsgSystem(contexts, systems, new MessageRemindDataSystem(contexts));
		AddMsgSystem(contexts, systems, new NoBulletTipsSystem(contexts));
	}

	private void AddMsgSystem<T>(Contexts contexts, List<IPlaybackSystem> systems, T system) where T : IMessagePlaybackSystem
	{
		if (system.NeedStart(contexts))
		{
			systems.Add(system);
		}
	}

	protected override void OnAddEntityPreDestroySystems(Contexts contexts, List<IEntityPreDestroySystem> systems)
	{
		AddMsgResetSystem(contexts, systems, new ResetDamageCountSystem(contexts));
	}

	private void AddMsgResetSystem<T>(Contexts contexts, List<IEntityPreDestroySystem> systems, T system) where T : IMessageResetSystem
	{
		if (system.NeedStart(contexts))
		{
			systems.Add(system);
		}
	}
}
