using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgAngerFireScarModel : AbstractModel, IPlaybackSystem
{
	private RpgAngerFireScarViewModel _viewModel;

	private FrameAnimaChip _animaChip1 = new FrameAnimaChip();

	private FrameAnimaChip _animaChip2 = new FrameAnimaChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgAngerFireScarViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited || !_viewModel.ShowShow)
		{
			return;
		}
		_animaChip1.Update(_timeComponent);
		if (_animaChip1.Changed)
		{
			base.Loader.RetriveSprite("weapon/angerfirescar", _animaChip1.Value, delegate(Sprite sprite)
			{
				_viewModel.ImageSprite1 = sprite;
			});
		}
		_animaChip2.Update(_timeComponent);
		if (_animaChip2.Changed)
		{
			base.Loader.RetriveSprite("weapon/angerfirescar", _animaChip2.Value, delegate(Sprite sprite)
			{
				_viewModel.ImageSprite2 = sprite;
			});
		}
		_viewModel.ImageSize1 = new Vector3(_viewModel.ImageRect1.height * 280f / 350f, 0f);
		_viewModel.ImageSize2 = new Vector3(_viewModel.ImageRect2.height * 280f / 350f, 0f);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_AngryFireScarSkillShifang, SetAngryFireScarSkillShifang, null, initinvoke: true);
		_animaChip1.Delay = 200;
		_animaChip1.Count = 5;
		_animaChip1.IsLoop = true;
		_animaChip1.Path = "Assets/Res/Assets/weapon/angerfirescar/ui/bz";
		_animaChip2.Delay = 200;
		_animaChip2.Count = 5;
		_animaChip2.IsLoop = true;
		_animaChip2.Path = "Assets/Res/Assets/weapon/angerfirescar/ui/bz";
		RpgAngerFireScarViewModel viewModel = _viewModel;
		Sprite imageSprite = (_viewModel.ImageSprite2 = base.Loader.RetriveSprite("weapon/angerfirescar", "Assets/Res/Assets/weapon/angerfirescar/ui/bz1.png", delegate(Sprite sprite)
		{
			_viewModel.ImageSprite1 = sprite;
			_viewModel.ImageSprite2 = sprite;
		}));
		viewModel.ImageSprite1 = imageSprite;
	}

	private void SetAngryFireScarSkillShifang(bool ov, bool flag)
	{
		if (flag)
		{
			_viewModel.ShowShow = true;
		}
		else
		{
			_viewModel.ShowShow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
