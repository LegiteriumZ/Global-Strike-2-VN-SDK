using System.Collections.Generic;
using Assets.Sources.Components.Interface.SceneBuffAttach;
using SSJJBase.Singleton;

namespace Assets.Sources.Info.SceneBuffAttach;

public class SceneBufferAttachFactory : SingletonInstance<SceneBufferAttachFactory>
{
	public Dictionary<string, ISceneBuffAttach> Attaches;

	private bool _init;

	public void Init()
	{
		if (!_init)
		{
			_init = true;
			Attaches = new Dictionary<string, ISceneBuffAttach>();
			if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType != 15013)
			{
				Attaches.Add("RPG_GROUP_SUPER_WEAPON", new SuperWeaponSceneBuffAttach());
			}
			Attaches.Add("RPG_ANNIHILATION_BUFF_HONG", new RpgAnnihilationBufferSceneBuffAttach());
			Attaches.Add("RPG_ANNIHILATION_BUFF_HONGBIG", new RpgAnnihilationBufferSceneBuffAttach());
			Attaches.Add("RPG_ANNIHILATION_BUFF_LAN", new RpgAnnihilationBufferSceneBuffAttach());
			Attaches.Add("RPG_ANNIHILATION_BUFF_LANBIG", new RpgAnnihilationBufferSceneBuffAttach());
			Attaches.Add("RPG_ANNIHILATION_BUFF_ZI", new RpgAnnihilationBufferSceneBuffAttach());
			Attaches.Add("RPG_ANNIHILATION_BUFF_ZIBIG", new RpgAnnihilationBufferSceneBuffAttach());
			Attaches.Add("THUNDER_SCEPTER_LEIGUANG", new MoveEntityEffectHpSceneBuffAttach());
			Attaches.Add("THUNDER_SCEPTER_LEIGUANG_SKIN_FIRE_DANCE", new MoveEntityEffectHpSceneBuffAttach());
			Attaches.Add("EV_SKY_DOME_BEACON_COLOUR_0", new SkyDomeBeaconSceneBuffAttach());
			Attaches.Add("EV_SKY_DOME_BEACON_COLOUR_1", new SkyDomeBeaconSceneBuffAttach());
			Attaches.Add("EV_SKY_DOME_BEACON_COLOUR_2", new SkyDomeBeaconSceneBuffAttach());
			Attaches.Add("EV_SKY_DOME_BEACON_COLOUR_3", new SkyDomeBeaconSceneBuffAttach());
			Attaches.Add("ENERGY_PREPARE", new EnergyPrepareBuffAttach());
			Attaches.Add("STEAL_EXPERT_BASE", new MoveEntityNameSuggestAttach());
			Attaches.Add("MYSTERY_FIRE3", new MySteryFireBufferSceneBuffAttach());
		}
	}

	public ISceneBuffAttach GetBuffAttach(string buffName)
	{
		Init();
		Attaches.TryGetValue(buffName, out var value);
		if (value != null)
		{
			ISceneBuffAttach sceneBuffAttach = value.Clone();
			sceneBuffAttach.Init();
			return sceneBuffAttach;
		}
		return null;
	}
}
