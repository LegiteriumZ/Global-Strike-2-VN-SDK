using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PromiseMessageModel : AbstractModel, IPlaybackSystem
{
	private PromiseMessageViewModel _viewModel;

	private static Dictionary<GameMessageType, AssetInfo> _msgAssets = new Dictionary<GameMessageType, AssetInfo>
	{
		{
			GameMessageType.FLEEOVER,
			new AssetInfo("ui/promisemodel", "Assets/Res/Assets/ui/GameGUIRes/promiseModel/fleeover.png")
		},
		{
			GameMessageType.GAMESTART,
			new AssetInfo("ui/promisemodel", "Assets/Res/Assets/ui/GameGUIRes/promiseModel/gamestart.png")
		},
		{
			GameMessageType.HALFOVER,
			new AssetInfo("ui/promisemodel", "Assets/Res/Assets/ui/GameGUIRes/promiseModel/halfover.png")
		},
		{
			GameMessageType.WAITPLAYER,
			new AssetInfo("ui/promisemodel", "Assets/Res/Assets/ui/GameGUIRes/promiseModel/waitplayer.png")
		}
	};

	private ActiveChip _messageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PromiseMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameMessageData_MessageData, SetMessageData, null, initinvoke: true);
	}

	private void SetMessageData(GameMessageData ov, GameMessageData msg)
	{
		if (msg == null)
		{
			_messageActiveChip.Time = 0;
		}
		else if (_msgAssets.ContainsKey(msg.Type))
		{
			_messageActiveChip.Time = ((msg.Type == GameMessageType.WAITPLAYER) ? int.MaxValue : 3000);
			_viewModel.MessageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_msgAssets[msg.Type], delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
				_viewModel.MessageNtvsize();
			});
		}
	}

	private void InitChips()
	{
		_messageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.MessageShow = _messageActiveChip.Update(_timeComponent);
	}
}
