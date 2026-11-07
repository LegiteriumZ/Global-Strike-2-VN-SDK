using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgFrameEffectModel : AbstractModel, IPlaybackSystem
{
	private RpgFrameEffectViewModel _viewModel;

	private readonly HashSet<int> _stateSet = new HashSet<int>();

	private readonly FrameAnimaChip _imageFrameAnimaChip = new FrameAnimaChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgFrameEffectViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.ShowRootshow && _imageFrameAnimaChip.Changed)
		{
			base.Loader.RetriveSprite("ui/rpgmodel", _imageFrameAnimaChip.Value, delegate(Sprite sprite)
			{
				_viewModel.ImageSprite = sprite;
			});
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgBossjy2004Chuifeng, SetRpgBossjy2004Chuifeng, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgBossjy6001Sdl, SetRpgBossjy6001Sdl, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Anying1State, SetAnying1State, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Anying2State, SetAnying2State, null, initinvoke: true);
		_imageFrameAnimaChip.Delay = 200;
		_imageFrameAnimaChip.StartIndex = 0;
		_imageFrameAnimaChip.IsLoop = true;
	}

	private void SetRpgBossjy2004Chuifeng(bool ov, bool flag)
	{
		SetAnima(flag, PlayerInfoStatusConstant.RPG_BOSSJY2004_CHUIFENG.ID, "Assets/Res/Assets/ui/GameGUIRes/rpgModel/frameeffect/chuifeng", 4);
	}

	private void SetRpgBossjy6001Sdl(bool ov, bool flag)
	{
		SetAnima(flag, PlayerInfoStatusConstant.RPG_BOSSJY2004_CHUIFENG.ID, "Assets/Res/Assets/ui/GameGUIRes/rpgModel/frameeffect/shandianlian", 2);
	}

	private void SetAnying1State(bool ov, bool flag)
	{
		SetAnima(flag, PlayerInfoStatusConstant.ANYING1_STATE.ID, "Assets/Res/Assets/ui/GameGUIRes/rpgModel/frameeffect/anying", 2);
	}

	private void SetAnying2State(bool ov, bool flag)
	{
		SetAnima(flag, PlayerInfoStatusConstant.ANYING2_STATE.ID, "Assets/Res/Assets/ui/GameGUIRes/rpgModel/frameeffect/anying", 2);
	}

	private void SetAnima(bool flag, int state, string path, int count)
	{
		_viewModel.ShowRootshow = false;
		if (flag)
		{
			_viewModel.ShowRootshow = true;
			if (!_stateSet.Contains(state))
			{
				_stateSet.Add(state);
			}
			_imageFrameAnimaChip.Count = count;
			_imageFrameAnimaChip.Path = path;
			_imageFrameAnimaChip.Index = 0;
		}
		else
		{
			if (_stateSet.Contains(state))
			{
				_stateSet.Remove(state);
			}
			_viewModel.ShowRootshow = _stateSet.Count > 0;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		_imageFrameAnimaChip.Update(_timeComponent);
	}
}
