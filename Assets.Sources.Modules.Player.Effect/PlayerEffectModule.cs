using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerEffectModule : GameModule
{
	private LoadVolumeConfigSystem _volumeConfigSystem;

	public PlayerEffectModule(Contexts contexts)
		: base(contexts)
	{
		_volumeConfigSystem = new LoadVolumeConfigSystem(contexts);
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerAnimationEffectSystem(contexts));
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new VolumeConfigCreateSystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_volumeConfigSystem);
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_volumeConfigSystem);
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerSetStealthAlphaSystem(contexts));
		systems.Add(new PlayerSetZWriteSystem(contexts));
		systems.Add(new PlayerLoadOutlineSystem(contexts));
		systems.Add(new ThirdKnifeEffectPlayBackSystem(contexts));
		systems.Add(new PlayerAnimationEffectCreateSystem(contexts));
		systems.Add(new PlayerEffectStatusPlayBackSystem(contexts));
		systems.Add(new PlayerSpecialSkillEffectSystem(contexts));
		systems.Add(new PlayerMpPlayBackSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new PlayerDrawVertexColorSystem(contexts));
		systems.Add(new PlayerChangeSkinSystem(contexts));
		systems.Add(new PlayerAnimationEffectRenderSystem(contexts));
		systems.Add(new PlayerEffectVisibleRenderSystem(contexts));
		systems.Add(new PlayerEffectLevelRenderSystem(contexts));
		systems.Add(new MeshLodSystem(contexts));
	}

	protected override void OnAddPreRenderSystems(Contexts contexts, List<IPreRenderSystem> systems)
	{
		systems.Add(new WeaponDrawColorSystem(contexts));
		systems.Add(new HideWeaponSystem(contexts));
		systems.Add(new HidePlayerSystem(contexts));
	}

	protected override void OnAddAfterPredicationSystems(Contexts contexts, List<IAfterPredicationSystem> systems)
	{
		systems.Add(new HideFirstPersonViewSystem(contexts));
		systems.Add(new FirstKnifeEffectAfterPredicationSystem(contexts));
	}
}
