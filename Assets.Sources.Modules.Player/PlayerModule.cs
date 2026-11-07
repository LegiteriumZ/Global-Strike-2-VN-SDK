using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.GameRule;
using Assets.Sources.Modules.Message;
using Assets.Sources.Modules.Player.Accessory;
using Assets.Sources.Modules.Player.Action;
using Assets.Sources.Modules.Player.Anim;
using Assets.Sources.Modules.Player.Attack;
using Assets.Sources.Modules.Player.Beinghit;
using Assets.Sources.Modules.Player.ClientTime;
using Assets.Sources.Modules.Player.Dead;
using Assets.Sources.Modules.Player.Effect;
using Assets.Sources.Modules.Player.EntityCreate;
using Assets.Sources.Modules.Player.EntityDestroy;
using Assets.Sources.Modules.Player.Events;
using Assets.Sources.Modules.Player.HeadScale;
using Assets.Sources.Modules.Player.HitBox;
using Assets.Sources.Modules.Player.KillInfo;
using Assets.Sources.Modules.Player.Move;
using Assets.Sources.Modules.Player.NormalBrush;
using Assets.Sources.Modules.Player.ObserverInfo;
using Assets.Sources.Modules.Player.Orientation;
using Assets.Sources.Modules.Player.PlayerBag;
using Assets.Sources.Modules.Player.Position;
using Assets.Sources.Modules.Player.PyEntity;
using Assets.Sources.Modules.Player.Skill;
using Assets.Sources.Modules.Player.SmallMap;
using Assets.Sources.Modules.Player.Sound;
using Assets.Sources.Modules.Player.Vip;
using Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;
using Assets.Sources.Modules.SceneObject.PlayerEffect.ParticleLoop;

namespace Assets.Sources.Modules.Player;

public class PlayerModule : CompositeGameModule
{
	public PlayerModule(Contexts contexts)
	{
		PlayerContextResourceInfo playerContextResourceInfo = new PlayerContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, playerContextResourceInfo, playerContextResourceInfo, null));
		AddModule(new PlayerEntityCreateModule(contexts));
		AddModule(new PlayerClientTimeModule(contexts));
		AddModule(new PlayerBagModule(contexts));
		AddModule(new PlayerOrientationModule(contexts));
		AddModule(new PlayerPositionModule(contexts));
		AddModule(new PlayerMoveModule(contexts));
		AddModule(new NormalBrushModule(contexts));
		AddModule(new PlayerAttackModule(contexts));
		AddModule(new PlayerAnimModule(contexts));
		AddModule(new HeadScaleModule(contexts));
		AddModule(new PlayerEventsModule(contexts));
		AddModule(new PlayerHitBoxModule(contexts));
		AddModule(new PlayerPyEntityModule(contexts));
		AddModule(new PlayerPredicationModule(contexts));
		AddModule(new PlayerDeadModule(contexts));
		if (OfflineGameController.setting == null || !OfflineGameController.setting.TurnOn)
		{
			AddModule(new PlayerEffectModule(contexts));
			AddModule(new PlayerBaseShowEffectModule(contexts));
			AddModule(new PlayerInfoParticleLoopEffectModule(contexts));
			AddModule(new PlayerSmallMapModule(contexts));
			AddModule(new PlayerSkillModule(contexts));
			AddModule(new PlayerEntityDestroyModule(contexts));
			AddModule(new SoundModule(contexts));
			AddModule(new PlayerAccessoryModule(contexts));
			AddModule(new VipModule(contexts));
			AddModule(new KillInfoModule(contexts));
			AddModule(new ObserverModule(contexts));
			AddModule(new BeinghitModule(contexts));
			AddModule(new GameRuleModule(contexts));
			AddModule(new MessageModule(contexts));
			AddModule(new ActionModule(contexts));
		}
	}
}
