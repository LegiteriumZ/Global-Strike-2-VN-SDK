using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.Player;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.WeaponAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJAnim.WeaponAnim;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJUserCmd;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Sound;

internal class WeaponNoticePlayBackSystem : IPredicateSystem
{
	protected readonly Dictionary<string, float> NoticeTimeDictionary = new Dictionary<string, float>();

	protected IGroup<PlayerEntity> Players;

	private int _lastAnimSeq;

	private int _lastCurrentTime;

	private Dictionary<string, string> _leftKeyDictionary = new Dictionary<string, string>();

	private Dictionary<string, string> _rightKeyDictionary = new Dictionary<string, string>();

	private Dictionary<string, AssetInfo> _eventSoundDictionary = new Dictionary<string, AssetInfo>();

	public WeaponNoticePlayBackSystem(Contexts contexts)
	{
		Players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ViewAnim, PlayerMatcher.CurrentWeapon));
	}

	private void ProcessNotice(int time, IWeaponAnimInfo info, int animId, string keyPrefex, Dictionary<string, string> keyDictionary, int currentTime, float speed, int animSeq, bool isMyself, IUserCmd cmd)
	{
		float num = Mathf.Floor((float)info.GetViewAnimDuration(animId) / speed);
		if ((float)currentTime > num && !info.ViewAnimIsLoop(animId))
		{
			currentTime = (int)num - 1;
		}
		string text = info.ViewAnimEventName(animId);
		int num2 = info.ViewAnimEventTime(animId);
		if (text == null)
		{
			return;
		}
		string value = null;
		if (!keyDictionary.TryGetValue(text, out value))
		{
			keyDictionary[text] = $"{keyPrefex}_{text}";
			value = keyDictionary[text];
		}
		if ((!NoticeTimeDictionary.ContainsKey(value) || NoticeTimeDictionary[value] < NoticeTimeDictionary[value] - num + (float)currentTime / speed || animSeq != _lastAnimSeq || (animSeq == _lastAnimSeq && currentTime + 200 < _lastCurrentTime)) && currentTime > num2)
		{
			NoticeTimeDictionary[value] = (float)(((!NoticeTimeDictionary.ContainsKey(value)) ? 200 : 0) + time) + num;
			if (!_eventSoundDictionary.TryGetValue(text, out var value2))
			{
				AssetInfo assetInfo = default(AssetInfo);
				assetInfo.BundleName = WeaponUtility.GetAssetMp3BundleName("sound/weapon/", $"Assets/Res/Assets/sound/weapon/{text}.mp3");
				assetInfo.AssetName = $"Assets/Res/Assets/sound/weapon/{text}.mp3";
				value2 = assetInfo;
				_eventSoundDictionary[text] = value2;
			}
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Operate, isMyself, value2, GameSoundManager.Config.EnvironmentVolume);
		}
		_lastCurrentTime = currentTime;
		_lastAnimSeq = animSeq;
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		if (RuleUtilty.IsTpsMode() || cmd.PredicatedOnce)
		{
			return;
		}
		int clientTime = player.clientTime.ClientTime;
		foreach (PlayerEntity player2 in Players)
		{
			if (player2.IsDead() || !player2.isCameraOwner)
			{
				continue;
			}
			CurrentWeaponComponent currentWeapon = player2.currentWeapon;
			if (currentWeapon == null)
			{
				continue;
			}
			IWeaponAnimInfo weaponAnimInfo = WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(currentWeapon.WeaponInfo);
			if (weaponAnimInfo != null && player2.hasViewAnim)
			{
				if (player2.viewAnim.ViewAnimInfo != null)
				{
					ProcessNotice(clientTime, weaponAnimInfo, player2.viewAnim.ViewAnimInfo.StateId, "right", _rightKeyDictionary, player2.viewAnim.RightCurrentTime, player2.viewAnim.RightSpeed, player2.viewAnim.AnimSeq, player2.isMyPlayer, cmd);
				}
				if (player2.viewAnim.LeftViewAnimInfo != null)
				{
					ProcessNotice(clientTime, weaponAnimInfo, player2.viewAnim.LeftViewAnimInfo.StateId, "Left", _leftKeyDictionary, player2.viewAnim.LeftCurrentTime, player2.viewAnim.LeftSpeed, player2.viewAnim.AnimSeq, player2.isMyPlayer, cmd);
				}
			}
		}
	}
}
