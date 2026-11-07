using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class KillStateModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetPlayerContext
{
	private KillStateViewModel _viewModel;

	private const int ShowTime = 3000;

	private const int BottomStateShowTime = 800;

	private const int GoodNum = 5;

	private const int GreatNum = 7;

	private int _effectTime;

	private PingPongChip _coolPingPongChip = new PingPongChip();

	private PingPongChip _effectBgPingPongChip = new PingPongChip();

	private static AssetInfo _infectBack = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/evenkill/infectedback.png");

	private static AssetInfo _infectEffectBg = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/evenkill/infectedback.png");

	private static AssetInfo _infectEffect = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/evenkill/infectedeffect.png");

	private static AssetInfo _killBack = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/evenkill/killback1.png");

	private static AssetInfo _killEffectBg = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/evenkill/killback3.png");

	private static AssetInfo _killEffect = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/evenkill/effect.png");

	private GameRuleContext _gameRuleContext;

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
		_viewModel = new KillStateViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.EffectBgShow)
			{
				_viewModel.EffectBgAlpha = _effectBgPingPongChip.Value;
			}
			if (_viewModel.CoolShow)
			{
				_viewModel.CoolScale = Vector3.one * _coolPingPongChip.Value;
			}
			_effectTime += _timeComponent.FrameInterval;
			if (_effectTime >= 3000 && _effectTime < 3800)
			{
				OnKillNumLerp((float)(_effectTime - 3000) / 800f);
			}
			else
			{
				_viewModel.BottomKillNumScale = Vector3.one;
			}
		}
	}

	private void InitChips()
	{
		_coolPingPongChip.From = 1f;
		_coolPingPongChip.To = 1.5f;
		_coolPingPongChip.Time = 1000;
		_effectBgPingPongChip.From = 1f;
		_effectBgPingPongChip.To = 0.5f;
		_effectBgPingPongChip.Time = 1000;
	}

	private void UpdateChips()
	{
		_coolPingPongChip.Update(_timeComponent);
		_effectBgPingPongChip.Update(_timeComponent);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetKillNum, SetKillNum, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(GetCameraOwnerId, SetCameraOwnerId, null, initinvoke: true, isFrameSeparation: true);
	}

	private long GetCameraOwnerId()
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Cid ?? 0;
	}

	private void SetCameraOwnerId(long arg1, long arg2)
	{
		if (_effectTime < 3000)
		{
			_effectTime = 3000;
		}
	}

	private bool IsBioInfect()
	{
		if (_gameRuleContext.currentRule.Rule.IsBio())
		{
			if (!PlayerCareerConstantUtility.IsDoun(UiIEventCondition.Get_cameraOwnerData_Career()))
			{
				return PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_cameraOwnerData_Career());
			}
			return true;
		}
		return false;
	}

	private void SetKillNum(int arg1, int arg2)
	{
		if (arg2 < 2)
		{
			return;
		}
		_viewModel.BottomKillNumString = StringCache.IntToString(arg2);
		if (arg2 >= 7)
		{
			_viewModel.KillStateBgShow = false;
			_viewModel.EffectBgShow = true;
			_viewModel.CoolShow = true;
		}
		else if (arg2 >= 5)
		{
			_viewModel.KillStateBgShow = false;
			_viewModel.EffectBgShow = true;
			_viewModel.CoolShow = false;
		}
		else
		{
			_viewModel.KillStateBgShow = true;
			_viewModel.EffectBgShow = false;
			_viewModel.CoolShow = false;
		}
		if (IsBioInfect())
		{
			_effectTime = 3000;
			_viewModel.KillStateBgSprite = this.GetLoader().RetriveSprite(_infectBack, delegate(Sprite sprite)
			{
				_viewModel.KillStateBgSprite = sprite;
			});
			_viewModel.EffectBgSprite = this.GetLoader().RetriveSprite(_infectEffectBg, delegate(Sprite sprite)
			{
				_viewModel.EffectBgSprite = sprite;
			});
			_viewModel.KillStateBgGreatSprite = this.GetLoader().RetriveSprite(_infectEffect, delegate(Sprite sprite)
			{
				_viewModel.KillStateBgGreatSprite = sprite;
			});
		}
		else
		{
			_effectTime = 0;
			_viewModel.KillStateBgSprite = this.GetLoader().RetriveSprite(_killBack, delegate(Sprite sprite)
			{
				_viewModel.KillStateBgSprite = sprite;
			});
			_viewModel.EffectBgSprite = this.GetLoader().RetriveSprite(_killEffectBg, delegate(Sprite sprite)
			{
				_viewModel.EffectBgSprite = sprite;
			});
			_viewModel.KillStateBgGreatSprite = this.GetLoader().RetriveSprite(_killEffect, delegate(Sprite sprite)
			{
				_viewModel.KillStateBgGreatSprite = sprite;
			});
		}
	}

	private int GetKillNum()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity == null || !cameraOwnerEntity.hasCurrKill)
		{
			return 0;
		}
		return cameraOwnerEntity.currKill.Count;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private bool GetVisible()
	{
		if (UiIEventCondition.Get_cameraOwnerData_IsDead())
		{
			return false;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (((cameraOwnerEntity != null && cameraOwnerEntity.hasCurrKill) ? cameraOwnerEntity.currKill.Count : 0) > 1)
		{
			return _effectTime >= 3000;
		}
		return false;
	}

	private void OnKillNumLerp(float lerp)
	{
		float num = NumLerpFactor(lerp);
		if (float.IsNaN(num))
		{
			num = 1f;
		}
		_viewModel.BottomKillNumScale = Vector3.one * num;
	}

	private float NumLerpFactor(float percent)
	{
		return (0f - Mathf.Pow(percent - 0.5f, 2f) + 1f) * 1.3f;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
