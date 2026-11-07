using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Finalbio;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioChangeHumanityModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private FinalbiochangehumanityViewModel _viewModel;

	private int _totalTime;

	private FinalBioMessageType _stateType = FinalBioMessageType.PLAYERGETANTIDOTE;

	private int _moveTime;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new FinalbiochangehumanityViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (_viewModel.PanelShow)
		{
			HideImage();
			UpdateProgress();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.PanelShow = false;
		base.DoSubscribe();
		NotifyManager.MakeNotify(28, UiIEventCondition.Get_finalBioMessageData_ChangeHumanityChanged, SetChangeHumanityChanged, initinvoke: true);
	}

	protected void SetChangeHumanityChanged(bool ov, bool changed)
	{
		if (!changed)
		{
			return;
		}
		_stateType = UiIEventCondition.Get_finalBioMessageData_ChangeHumanityType();
		_totalTime = UiIEventCondition.Get_finalBioMessageData_ChangeHumanityTime();
		_moveTime = 0;
		_viewModel.PanelShow = true;
		if (_stateType == FinalBioMessageType.PLAYERGETANTIDOTE)
		{
			_viewModel.BackImageSprite = base.Loader.RetriveSprite("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbiomodel/changehumanity/back.png", delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
		}
		else if (_stateType == FinalBioMessageType.PLAYERUSEANTIDOTE)
		{
			_viewModel.BackImageSprite = base.Loader.RetriveSprite("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbiomodel/changehumanity/useback.png", delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
		}
	}

	private void UpdateProgress()
	{
		_moveTime += _timeComponent.FrameInterval;
		_viewModel.ProgressImageFillamount = (float)(_totalTime - _moveTime) / (float)_totalTime;
	}

	private void HideImage()
	{
		if (_moveTime >= _totalTime)
		{
			_viewModel.PanelShow = false;
		}
		else if (!PlayerCareerConstantUtility.IsDoun(UiIEventCondition.Get_cameraOwnerData_Career()) && UiIEventCondition.Get_cameraOwnerData_Career() != "qingniujing_mother")
		{
			_viewModel.PanelShow = false;
		}
		else if (UiIEventCondition.Get_cameraOwnerData_IsDead())
		{
			_viewModel.PanelShow = false;
		}
		else if (_messageContext.bioMessageData.IsHeroChanged)
		{
			_viewModel.PanelShow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
