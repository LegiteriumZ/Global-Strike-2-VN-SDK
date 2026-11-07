using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Sound;

internal class SoundModule : GameModule
{
	public SoundModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(new ThirdFootstepsPlaybackSystem(contexts));
		systems.Add(new FirstFootstepsPlaybackSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new UpdateSoundSystem(contexts));
	}

	protected override void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
		systems.Add(new TpsWeaponSoundPredicateSystem(contexts));
		systems.Add(new WeaponNoticePlayBackSystem(contexts));
	}
}
