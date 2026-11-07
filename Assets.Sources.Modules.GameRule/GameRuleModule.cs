using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Modules.GameRule.Biochemical;
using Assets.Sources.Modules.GameRule.Common;
using Assets.Sources.Modules.GameRule.Explode;
using Assets.Sources.Modules.GameRule.GoldExplode;
using Assets.Sources.Modules.GameRule.Mechwarrior;
using Assets.Sources.Modules.GameRule.Pve;
using Assets.Sources.Modules.GameRule.Rpg;
using Assets.Sources.Modules.GameRule.RpgMiner;

namespace Assets.Sources.Modules.GameRule;

public class GameRuleModule : GameModule
{
	public GameRuleModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		AddMsgSystem(contexts, systems, new PlayerUltrasonicUpdateSystem(contexts));
		AddMsgSystem(contexts, systems, new BioSelectAvatarDataSystem(contexts));
		AddMsgSystem(contexts, systems, new MetalmanSkillMpUpdateSystem(contexts));
		AddMsgSystem(contexts, systems, new C4WeaponSystem(contexts));
		AddMsgSystem(contexts, systems, new TaskSystem(contexts));
		AddMsgSystem(contexts, systems, new GameProgressSystem(contexts));
		AddMsgSystem(contexts, systems, new PlayerAmmunitionpackageUpdateSystem(contexts));
		AddMsgSystem(contexts, systems, new GoldExplodeInBuyAreaSystem(contexts));
		AddMsgSystem(contexts, systems, new PveScoreRankUpdateSystem(contexts));
		AddMsgSystem(contexts, systems, new MechwarriorHumanEnergyDataSystem(contexts));
		AddMsgSystem(contexts, systems, new SelectNodeDataSystem(contexts));
		AddMsgSystem(contexts, systems, new EliteTargetIdSystem(contexts));
		AddMsgSystem(contexts, systems, new AchievementSystem(contexts));
		AddMsgSystem(contexts, systems, new HpProgressDataSystem(contexts));
		AddMsgSystem(contexts, systems, new MiniMapDataSystem(contexts));
		AddMsgSystem(contexts, systems, new SendGoldExplodeMessageSystem(contexts));
		AddMsgSystem(contexts, systems, new GunGlorySystem(contexts));
	}

	private void AddMsgSystem<T>(Contexts contexts, List<IPlaybackSystem> systems, T system) where T : IGameRulePlaybackSystem
	{
		if (system.NeedStart(contexts))
		{
			systems.Add(system);
		}
	}

	protected override void OnAddEntityPreDestroySystems(Contexts contexts, List<IEntityPreDestroySystem> systems)
	{
		AddMsgResetSystem(contexts, systems, new GunGlorySystem(contexts));
	}

	private void AddMsgResetSystem<T>(Contexts contexts, List<IEntityPreDestroySystem> systems, T system) where T : IGameRuleResetSystem
	{
		if (system.NeedStart(contexts))
		{
			systems.Add(system);
		}
	}
}
