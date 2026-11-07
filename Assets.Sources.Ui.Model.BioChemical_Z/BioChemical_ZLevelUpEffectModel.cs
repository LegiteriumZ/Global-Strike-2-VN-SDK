using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZLevelUpEffectModel : AbstractModel, IPlaybackSystem
{
	private BioChemical_ZLevelUpEffectViewModel _viewModel;

	private float _alphaAdd;

	private float _effectAlpha;

	private int _enterTime;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZLevelUpEffectViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips(_timeComponent);
		_enterTime += _timeComponent.FrameInterval;
		_viewModel.LevelUpEffectShow = _enterTime < 1000;
		if (_viewModel.LevelUpEffectShow)
		{
			_effectAlpha += _alphaAdd * (float)_timeComponent.FrameInterval / 500f * 0.7f;
			if (_effectAlpha >= 1f)
			{
				_alphaAdd = -1f;
			}
			else if (_effectAlpha <= 0.3f)
			{
				_alphaAdd = 1f;
			}
			BioChemical_ZLevelUpEffectViewModel viewModel = _viewModel;
			float leftAlpha = (_viewModel.RightAlpha = _effectAlpha);
			viewModel.LeftAlpha = leftAlpha;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(Getlv, Setlv);
	}

	public int Getlv(int arg1)
	{
		return Contexts.sharedInstance.message.bioZInit.Level;
	}

	public void Setlv(int arg1, int arg2)
	{
		_enterTime = 0;
		_alphaAdd = 1f;
		_effectAlpha = 0.3f;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
