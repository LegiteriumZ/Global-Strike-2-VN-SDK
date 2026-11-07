using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Sound;

internal class TpsWeaponSoundPredicateSystem : IPredicateSystem
{
	private readonly Dictionary<int, int> _noticeTimeDictionary = new Dictionary<int, int>();

	private Dictionary<string, AssetInfo> _eventSoundDictionary = new Dictionary<string, AssetInfo>();

	private Dictionary<int, string> _soundDictionary = new Dictionary<int, string>();

	private int _lastAniId;

	public TpsWeaponSoundPredicateSystem(Contexts contexts)
	{
		_soundDictionary.Add(17, "reload");
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		if (!RuleUtilty.IsTpsMode() || cmd.PredicatedOnce)
		{
			return;
		}
		CurrentWeaponComponent currentWeapon = player.currentWeapon;
		if (currentWeapon == null)
		{
			return;
		}
		ITorseAnimStateInfo torsoAnimInfo = player.torseAnim.TorsoAnimInfo;
		if (torsoAnimInfo == null)
		{
			return;
		}
		int stateId = torsoAnimInfo.StateId;
		string name = currentWeapon.WeaponInfo.Name;
		int clientTime = player.clientTime.ClientTime;
		if (_lastAniId == stateId)
		{
			return;
		}
		_lastAniId = stateId;
		string value = null;
		if (!_soundDictionary.TryGetValue(stateId, out value))
		{
			return;
		}
		int value2 = 0;
		_noticeTimeDictionary.TryGetValue(stateId, out value2);
		if (clientTime - value2 > 1000)
		{
			string text = $"{name}_{value}";
			if (!_eventSoundDictionary.TryGetValue(text, out var value3))
			{
				value3 = new AssetInfo(WeaponUtility.GetAssetMp3BundleName("sound/weapon/", $"Assets/Res/Assets/sound/weapon/{text}.mp3"), $"Assets/Res/Assets/sound/weapon/{text}.mp3");
				_eventSoundDictionary[text] = value3;
			}
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Operate, isMyself: true, value3, GameSoundManager.Config.EnvironmentVolume);
			_noticeTimeDictionary[stateId] = clientTime;
		}
	}
}
