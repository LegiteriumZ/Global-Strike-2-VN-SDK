using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.HulaoguanModel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearLeftModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HuLaoGuanNewYearLeftViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private List<PlayerEntity> _players = new List<PlayerEntity>();

	private List<int> _playerJobs = new List<int>();

	private Dictionary<int, string> _rpgSkillStateCache = new Dictionary<int, string>();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new HuLaoGuanNewYearLeftViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(Get_Player);
		for (int i = 0; i < 3; i++)
		{
			listNotify.AddEvent<PlayerEntity, string>("PlayerName", GetPlayerName, SetPlayerName, i);
			listNotify.AddEvent<PlayerEntity, long>("PlayerHP", GetPlayerHp, SetPlayerHP, i);
			listNotify.AddEvent<PlayerEntity, long>("PlayerAc", GetPlayerAc, SetPlayerAc, i);
		}
		_notifyGroup.Add(listNotify.Id);
		for (int j = 0; j < 3; j++)
		{
			_viewModel.SetPlayerShow(j + 1, value: false);
		}
		listNotify.ForceInvoke();
		NotifyManager.MakeNotify(116, GetPlayerNum, Set_Player, initinvoke: true);
	}

	private string GetPlayerName(PlayerEntity val, int idx)
	{
		if (val == null)
		{
			return "";
		}
		if (!val.hasBasicInfo)
		{
			return "";
		}
		return val.basicInfo.PlayerName;
	}

	private void SetPlayerName(PlayerEntity val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (val != null && val.hasBasicInfo)
		{
			_viewModel.SetNameString(idx + 1, newfs);
		}
	}

	private int GetPlayerNum()
	{
		return Contexts.sharedInstance.player.count;
	}

	private void UpdatePlayerList(int ov, int tipsEvent)
	{
		NotifyManager.ForceInvoke(116);
	}

	private void Set_Player(int ov, int tipsEvent)
	{
		if (Contexts.sharedInstance.gameRule.huLaoGuanPlayerInfo.palyerInof == null)
		{
			Contexts.sharedInstance.gameRule.huLaoGuanPlayerInfo.palyerInof = new Dictionary<int, long>(4);
		}
		_players.Clear();
		_playerJobs.Clear();
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			if (item.IsBot() || item.basicInfo.Current.CharacterId < 0 || item.isMyPlayer)
			{
				continue;
			}
			bool flag = false;
			foreach (KeyValuePair<int, long> item2 in Contexts.sharedInstance.gameRule.huLaoGuanPlayerInfo.palyerInof)
			{
				if (item.basicInfo.Cid == item2.Value)
				{
					_players.Add(item);
					_playerJobs.Add(item2.Key);
					flag = true;
				}
			}
			if (!flag)
			{
				_players.Add(item);
				_playerJobs.Add(-1);
			}
		}
		for (int i = 0; i < _players.Count; i++)
		{
			_viewModel.SetPlayerShow(i + 1, value: true);
			_viewModel.SetIconShow(i + 1, _playerJobs[i] != -1);
			if (_playerJobs[i] != -1)
			{
				string value = null;
				if (!_rpgSkillStateCache.TryGetValue(_playerJobs[i], out value))
				{
					value = "Assets/Res/Assets/ui/GameGUIRes/hulaoguanmodel/newyear/" + _playerJobs[i] + ".png";
					_rpgSkillStateCache[_playerJobs[i]] = value;
				}
				int idx2 = i + 1;
				base.Loader.RetriveSprite("ui/hulaoguanmodel", value, delegate(Sprite sprite)
				{
					_viewModel.SetIconSprite(idx2, sprite);
				});
			}
		}
		for (int j = _players.Count; j < 3; j++)
		{
			_viewModel.SetPlayerShow(j + 1, value: false);
		}
	}

	private List<PlayerEntity> Get_Player()
	{
		return _players;
	}

	private long GetPlayerHp(PlayerEntity val, int idx)
	{
		if (val == null)
		{
			return 0L;
		}
		if (!val.hasBasicInfo)
		{
			return 0L;
		}
		return val.basicInfo.Current.Hp;
	}

	private void SetPlayerHP(PlayerEntity val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (val != null && val.hasBasicInfo)
		{
			long hp = val.basicInfo.Current.Hp;
			long maxHp = val.basicInfo.Current.MaxHp;
			if (maxHp > 0)
			{
				float value = (float)hp / (float)maxHp;
				_viewModel.SetHpProgressBarFillamount(idx + 1, value);
			}
			bool[] shows = new bool[4];
			ConvertLargeNummber(hp, ref shows, out var wholeStr, out var decimalStr);
			LargeNumberPosition(shows[0], hp >= 10000, wholeStr, decimalStr, out var positions, new Vector2(-173.9f, -72f));
			switch (idx)
			{
			case 0:
				_viewModel.SetHpCount1ShowLargenumber(shows);
				_viewModel.SetHpCount1PosiLargenumber(positions);
				_viewModel.SetHpCount1TextLargenumber(wholeStr, decimalStr);
				break;
			case 1:
				_viewModel.SetHpCount2ShowLargenumber(shows);
				_viewModel.SetHpCount2PosiLargenumber(positions);
				_viewModel.SetHpCount2TextLargenumber(wholeStr, decimalStr);
				break;
			case 2:
				_viewModel.SetHpCount3ShowLargenumber(shows);
				_viewModel.SetHpCount3PosiLargenumber(positions);
				_viewModel.SetHpCount3TextLargenumber(wholeStr, decimalStr);
				break;
			}
		}
	}

	private long GetPlayerAc(PlayerEntity val, int idx)
	{
		if (val == null)
		{
			return 0L;
		}
		if (!val.hasBasicInfo)
		{
			return 0L;
		}
		return val.basicInfo.Current.ShieldHp;
	}

	private void SetPlayerAc(PlayerEntity player, int idx, long oldHp, long newHp, ElementStatus status)
	{
		if (player.hasBasicInfo)
		{
			long shieldHp = player.basicInfo.Current.ShieldHp;
			long shieldMaxHp = player.basicInfo.Current.ShieldMaxHp;
			if (shieldMaxHp > 0)
			{
				float value = (float)shieldHp / (float)shieldMaxHp;
				_viewModel.SetAcProgressBarFillamount(idx + 1, value);
			}
			bool[] shows = new bool[4];
			ConvertLargeNummber(shieldHp, ref shows, out var wholeStr, out var decimalStr);
			LargeNumberPosition(shows[0], shieldHp >= 10000, wholeStr, decimalStr, out var positions, new Vector2(-173.9f, -43.8f));
			switch (idx)
			{
			case 0:
				_viewModel.SetAcCount1ShowLargenumber(shows);
				_viewModel.SetAcCount1PosiLargenumber(positions);
				_viewModel.SetAcCount1TextLargenumber(wholeStr, decimalStr);
				break;
			case 1:
				_viewModel.SetAcCount2ShowLargenumber(shows);
				_viewModel.SetAcCount2PosiLargenumber(positions);
				_viewModel.SetAcCount2TextLargenumber(wholeStr, decimalStr);
				break;
			case 2:
				_viewModel.SetAcCount3ShowLargenumber(shows);
				_viewModel.SetAcCount3PosiLargenumber(positions);
				_viewModel.SetAcCount3TextLargenumber(wholeStr, decimalStr);
				break;
			}
		}
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 3.51f;
		float num2 = (usingDot ? 199f : (usingSuffix ? 205f : 210f));
		float num3 = (usingDot ? 22f : 10f);
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[5]
		{
			new Vector3(num2 + offset.x, 41f + offset.y),
			new Vector3(5.5f + (float)num4 * num, -3.5f),
			new Vector3(12f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, 0.5f),
			new Vector3(num3 + (float)num4 * num, 0.5f)
		};
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
