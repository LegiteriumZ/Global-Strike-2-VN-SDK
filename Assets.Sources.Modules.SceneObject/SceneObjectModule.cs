using Assets.Sources.Framework;
using Assets.Sources.Modules.Common;
using Assets.Sources.Modules.SceneObject.BaseEvent;
using Assets.Sources.Modules.SceneObject.BulletHole;
using Assets.Sources.Modules.SceneObject.BulletRail;
using Assets.Sources.Modules.SceneObject.CameraEntity;
using Assets.Sources.Modules.SceneObject.DamageEvent;
using Assets.Sources.Modules.SceneObject.EngineEntity;
using Assets.Sources.Modules.SceneObject.FirstPlayerEffect;
using Assets.Sources.Modules.SceneObject.GrenadeExplosion;
using Assets.Sources.Modules.SceneObject.HitEffect;
using Assets.Sources.Modules.SceneObject.LinkObject;
using Assets.Sources.Modules.SceneObject.LocalEntityEffect;
using Assets.Sources.Modules.SceneObject.MapMark;
using Assets.Sources.Modules.SceneObject.MoveObject;
using Assets.Sources.Modules.SceneObject.NewNpc;
using Assets.Sources.Modules.SceneObject.ParticleEffectConfig;
using Assets.Sources.Modules.SceneObject.ParticleLod;
using Assets.Sources.Modules.SceneObject.PathGuide;
using Assets.Sources.Modules.SceneObject.PeekabooSceneItem;
using Assets.Sources.Modules.SceneObject.PlayerEffect;
using Assets.Sources.Modules.SceneObject.PlayerEffect.AttackInfo;
using Assets.Sources.Modules.SceneObject.PlayerHpBar;
using Assets.Sources.Modules.SceneObject.PveTower;
using Assets.Sources.Modules.SceneObject.SceneBuff;
using Assets.Sources.Modules.SceneObject.SceneMap;
using Assets.Sources.Modules.SceneObject.SceneWeapon;
using Assets.Sources.Modules.SceneObject.Shake;
using Assets.Sources.Modules.SceneObject.SimpleEngineEntity;
using Assets.Sources.Modules.SceneObject.SoundEvents;
using Assets.Sources.Modules.SceneObject.Spary;

namespace Assets.Sources.Modules.SceneObject;

public sealed class SceneObjectModule : CompositeGameModule
{
	public SceneObjectModule(Contexts contexts)
	{
		SceneObjectContextResourceInfo sceneObjectContextResourceInfo = new SceneObjectContextResourceInfo(contexts);
		AddModule(new ContextCommonModule(contexts, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo, sceneObjectContextResourceInfo));
		AddModule(new BulletHoleModule(contexts));
		AddModule(new BulletRailModule(contexts));
		AddModule(new GrenadeExplosionModule(contexts));
		AddModule(new DamageEventModule(contexts));
		AddModule(new HitEffectModule(contexts));
		AddModule(new SceneWeaponModule(contexts));
		AddModule(new SceneMapModule(contexts));
		AddModule(new SceneBuffModule(contexts));
		AddModule(new PlayerStateEffectModule(contexts));
		AddModule(new PlayerTitleEffectModule(contexts));
		AddModule(new PlayerAttackInfoEffectModule(contexts));
		AddModule(new PlayerHpBarModule(contexts));
		AddModule(new EngineEntityModule(contexts));
		AddModule(new BaseEventModule(contexts));
		AddModule(new LocalEntityModule(contexts));
		AddModule(new NewNpcModule(contexts));
		AddModule(new FirstPlayerEffectModule(contexts));
		AddModule(new SimpleEngineEntityModule(contexts));
		AddModule(new MoveObjectModule(contexts));
		AddModule(new LinkObjectModule(contexts));
		AddModule(new SparyModule(contexts));
		AddModule(new ShakeModule(contexts));
		AddModule(new PveTowerModule(contexts));
		AddModule(new PeekabooSceneItemModule(contexts));
		AddModule(new CameraEntityModule(contexts));
		AddModule(new ParticleEffectModule(contexts));
		AddModule(new SoundEventsModule(contexts));
		AddModule(new MapMarkModule(contexts));
		AddModule(new ParticleLodModule(contexts));
		AddModule(new PathGuideModule(contexts));
	}
}
