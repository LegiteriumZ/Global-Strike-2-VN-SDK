using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.UltimateChallenge;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.UltimateChallenge;

[GameUiTest]
public class UltimateKillMessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private class RemainTime
	{
		public int Time = 5000;
	}

	private UltimateKillMessageViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private KillPlayerInfoComponent _killPlayerInfo;

	private const int Duration = 5000;

	private Dictionary<UltKillPlayerData, RemainTime> _remainTimeDic = new Dictionary<UltKillPlayerData, RemainTime>();

	private List<UltKillPlayerData> _deleteList = new List<UltKillPlayerData>();

	private Color[] RelatedColors = new Color[4]
	{
		Color.white,
		new Color(72f / 85f, 0.4117647f, 0.4117647f),
		new Color(0.47843137f, 0.6627451f, 41f / 51f),
		new Color(0.827451f, 0.827451f, 0.827451f)
	};

	private bool _dirty;

	private string _bundleName
	{
		get
		{
			if (_battleRoomContext.roomData.Data.RaceType == 127)
			{
				return "ui/ultimatechallenge2model";
			}
			return "ui/ultimatechallengegroupmodel";
		}
	}

	protected override IUiViewModel ViewModel => _viewModel;

	private string GetAssetPath(string name)
	{
		if (_battleRoomContext.roomData.Data.RaceType == 127)
		{
			return $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/weaponCut/{name}.png";
		}
		return $"Assets/Res/Assets/ui/GameGUIRes/UltimateChallengeGroupModel/weaponCut/{name}.png";
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_killPlayerInfo = context.killPlayerInfo;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new UltimateKillMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		_deleteList.Clear();
		foreach (KeyValuePair<UltKillPlayerData, RemainTime> item in _remainTimeDic)
		{
			if (item.Value.Time <= 0)
			{
				_deleteList.Add(item.Key);
			}
			else
			{
				_remainTimeDic[item.Key].Time -= _timeComponent.FrameInterval;
			}
		}
		foreach (UltKillPlayerData delete in _deleteList)
		{
			_dirty = true;
			_remainTimeDic.Remove(delete);
			_killPlayerInfo.UltKillInfoList.Remove(delete);
		}
		if (_dirty)
		{
			_dirty = false;
			UpdateKillMessage();
		}
	}

	private void UpdateKillMessage()
	{
		for (int j = 0; j < _killPlayerInfo.UltKillInfoList.Count; j++)
		{
			_viewModel.SetMessageShow(j + 1, value: true);
			UltKillPlayerData info = _killPlayerInfo.UltKillInfoList[j];
			_viewModel.SetKillerTextcolor(j + 1, RelatedColors[info.RelatedType]);
			_viewModel.SetKillerString(j + 1, info.KillPlayerName);
			_viewModel.SetVictimString(j + 1, info.BeKillPlayerName);
			string name = "";
			if (info.InfoType == 1)
			{
				name = ((!info.Headshot) ? "beat" : "headShotBeat");
			}
			else if (info.InfoType == 2)
			{
				name = ((!info.Headshot) ? "kill" : "heatShot");
			}
			int i1 = j;
			base.Loader.RetriveSprite(_bundleName, GetAssetPath(name), delegate(Sprite sprite)
			{
				_viewModel.SetKillTypeSprite(i1 + 1, sprite);
				_viewModel.CallKillTypeNtvsize(i1 + 1);
				_viewModel.SetKillTypeColor(i1 + 1, RelatedColors[info.RelatedType]);
			});
			base.Loader.RetriveSprite(_bundleName, GetAssetPath(info.WeaponName), delegate(Sprite sprite)
			{
				_viewModel.SetWeaponSprite(i1 + 1, sprite);
				_viewModel.CallWeaponNtvsize(i1 + 1);
				_viewModel.SetWeaponColor(i1 + 1, RelatedColors[info.RelatedType]);
			});
			_viewModel.CallMessageHlayoutupdate(j + 1);
		}
		for (int k = _killPlayerInfo.UltKillInfoList.Count; k < 8; k++)
		{
			_viewModel.SetMessageShow(k + 1, value: false);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetMessageShow(i + 1, value: false);
		}
		NotifyManager.MakeTempNotify(GetChanged, SetChanged, null, initinvoke: true);
	}

	private void SetChanged(bool arg1, bool arg2)
	{
		for (int i = 0; i < _killPlayerInfo.UltKillInfoList.Count; i++)
		{
			if (!_remainTimeDic.ContainsKey(_killPlayerInfo.UltKillInfoList[i]))
			{
				_remainTimeDic.Add(_killPlayerInfo.UltKillInfoList[i], new RemainTime());
			}
		}
		_killPlayerInfo.Changed = false;
		_dirty = true;
	}

	private bool GetChanged()
	{
		return _killPlayerInfo.Changed;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
