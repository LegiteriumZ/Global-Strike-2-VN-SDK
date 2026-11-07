using System.Collections.Generic;
using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveBotHitModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private PveBotHitViewModel _viewModel;

	private int _time;

	private string _image;

	private int _curIndex;

	private static Dictionary<string, AssetInfo[]> _assetDic = new Dictionary<string, AssetInfo[]>
	{
		{
			"remotebothit",
			new AssetInfo[2]
			{
				new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/botHit/remotebothit1.png"),
				new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/botHit/remotebothit2.png")
			}
		},
		{
			"bothit",
			new AssetInfo[2]
			{
				new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/botHit/bothit1.png"),
				new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/botHit/bothit2.png")
			}
		},
		{
			"variationhit",
			new AssetInfo[2]
			{
				new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/botHit/variationhit1.png"),
				new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/botHit/variationhit2.png")
			}
		}
	};

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveBotHitViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		_time += _timeComponent.FrameInterval;
		if (!string.IsNullOrEmpty(_image) && _time < 600)
		{
			int num = _time / 150;
			if (_curIndex != num)
			{
				_curIndex = num;
				if (num == 0)
				{
					this.GetLoader().RetriveSprite(_assetDic[_image][0], delegate(Sprite sprite)
					{
						_viewModel.ImageSprite = sprite;
					});
				}
				else
				{
					this.GetLoader().RetriveSprite(_assetDic[_image][1], delegate(Sprite sprite)
					{
						_viewModel.ImageSprite = sprite;
					});
				}
			}
			_viewModel.ShowRootshow = false;
			_viewModel.ShowRootshow = true;
			_viewModel.ShowAlpha = 1f - (float)_time / 600f;
		}
		else
		{
			_viewModel.ShowAlpha = 0f;
			_viewModel.ShowRootshow = false;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowRootshow = false;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_beingHit_BeinghitData, SetBeinghitData, null, initinvoke: true);
	}

	private void SetBeinghitData(BeingHitEventEntityData ov, BeingHitEventEntityData hitData)
	{
		if (hitData == null)
		{
			return;
		}
		BeingHitComponent beingHit = _playerContext.myPlayerEntity.beingHit;
		if ((beingHit.DamageFrom == 0 || beingHit.DamageFrom == 2) && hitData.Kind != 1)
		{
			_time = 0;
			_curIndex = -1;
			switch (hitData.Type)
			{
			case 0:
				_image = "remotebothit";
				break;
			case 1:
				_image = "bothit";
				break;
			case 2:
				_image = "variationhit";
				break;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
