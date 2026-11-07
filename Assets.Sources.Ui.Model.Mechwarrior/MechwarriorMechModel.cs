using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorMechModel : AbstractModel, IPlaybackSystem
{
	private const int AddAlphaTime = 500;

	private const int KeepAlphaTime = 3000;

	private const int SubAlphaTime = 300;

	private MechwarriorMechViewModel _viewModel;

	private int _lvupTime;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorMechViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.TopShow)
		{
			return;
		}
		if (_lvupTime <= 500)
		{
			_viewModel.LvUpImageAlpha = (float)_lvupTime / 500f;
		}
		else if (_lvupTime <= 3500)
		{
			int num = _lvupTime - 500;
			int num2 = num / 500;
			int num3 = num % 500;
			if (num2 % 2 > 0)
			{
				_viewModel.LvUpImageAlpha = 0.9f + (float)num3 / 500f * 0.1f;
			}
			else
			{
				_viewModel.LvUpImageAlpha = 1f - (float)num3 / 500f * 0.1f;
			}
		}
		else if (_lvupTime < 3800)
		{
			_viewModel.LvUpImageAlpha = 1f - (float)(_lvupTime - 500) / 300f;
		}
		else if (_lvupTime >= 3800)
		{
			_viewModel.LvUpImageAlpha = 0f;
		}
		_lvupTime += _timeComponent.FrameInterval;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeNotify(65, UiIEventCondition.Get_mechwarriorMessageData_MechLvup, SetMechLvup, initinvoke: true);
	}

	private void SetMechLvup(bool ov, bool flag)
	{
		if (flag)
		{
			_lvupTime = 0;
		}
	}

	private void SetCareer(string ov, string career)
	{
		_viewModel.TopShow = PlayerCareerConstantUtility.IsMech(career);
		if (!_viewModel.TopShow)
		{
			return;
		}
		if (career == "mechbomberman")
		{
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/mech/bombmech.png", delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/mech/bombmechlvup.png", delegate(Sprite sprite)
			{
				_viewModel.LvUpImageSprite = sprite;
			});
		}
		else
		{
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/mech/mech.png", delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/mech/mechlvup.png", delegate(Sprite sprite)
			{
				_viewModel.LvUpImageSprite = sprite;
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
