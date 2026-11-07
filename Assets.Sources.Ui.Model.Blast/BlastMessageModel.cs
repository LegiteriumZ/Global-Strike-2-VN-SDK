using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Blast;

public class BlastMessageModel : AbstractModel, IPlaybackSystem
{
	private const int RemainTime = 3000;

	private BlastmessageViewModel _viewModel;

	private int timeCount;

	private string _image;

	private ActiveChip _c4MessageTextActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BlastmessageViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (UiIEventCondition.Get_c4Message_Active() && timeCount > 0)
		{
			_viewModel.C4StateImageAlpha -= (float)_timeComponent.FrameInterval / (float)timeCount;
			if (_viewModel.C4StateImageAlpha <= 0f)
			{
				_viewModel.C4StateImageAlpha = 1f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_c4Message_Active, SetActive, null, initinvoke: true);
		NotifyManager.MakeNotify(48, UiIEventCondition.Get_blastMessageData_Changed, SetChanged, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_c4Message_RemainTime, SetRemainTime, null, initinvoke: true);
	}

	private void SetRemainTime(int ov, int time)
	{
		int num = UiIEventCondition.Get_c4Message_TotalTime() - UiIEventCondition.Get_c4Message_RemainTime();
		if (num < 7000)
		{
			timeCount = 1567;
			SetImage("", "Assets/Res/Assets/ui/GameGUIRes/blastModel/c4state/c4state1.png");
		}
		else if (num < 14000)
		{
			timeCount = 783;
			SetImage("", "Assets/Res/Assets/ui/GameGUIRes/blastModel/c4state/c4state1.png");
		}
		else if (num < 21000)
		{
			timeCount = 522;
			SetImage("", "Assets/Res/Assets/ui/GameGUIRes/blastModel/c4state/c4state2.png");
		}
		else if (num < 28000)
		{
			timeCount = 313;
			SetImage("", "Assets/Res/Assets/ui/GameGUIRes/blastModel/c4state/c4state2.png");
		}
		else
		{
			timeCount = 195;
			SetImage("", "Assets/Res/Assets/ui/GameGUIRes/blastModel/c4state/c4state3.png");
		}
	}

	private void SetActive(bool ov, bool flag)
	{
		BlastmessageViewModel viewModel = _viewModel;
		bool c4StateBackImageShow = (_viewModel.C4StateImageShow = flag);
		viewModel.C4StateBackImageShow = c4StateBackImageShow;
		_viewModel.C4StateImageAlpha = 0.5f;
	}

	private void SetImage(string ov, string image)
	{
		if (!string.IsNullOrEmpty(image) && _image != image)
		{
			_image = image;
			_viewModel.C4StateImageSprite = base.Loader.RetriveSprite("ui/blastmodel", image, delegate(Sprite sprite)
			{
				_viewModel.C4StateImageSprite = sprite;
			});
		}
	}

	private void SetChanged(bool ov, bool changed)
	{
		if (changed)
		{
			switch (UiIEventCondition.Get_blastMessageData_Type())
			{
			case C4MessageType.PICKUP:
				_viewModel.C4MessageTextString = UiIEventCondition.Get_blastMessageData_PlayerName() + ScriptLocalization.Get("Pickuptext");
				_c4MessageTextActiveChip.Time = 3000;
				break;
			case C4MessageType.FALLING:
				_viewModel.C4MessageTextString = UiIEventCondition.Get_blastMessageData_PlayerName() + ScriptLocalization.Get("Fallingtext");
				_c4MessageTextActiveChip.Time = 3000;
				break;
			case C4MessageType.ACTIVE:
				_viewModel.C4MessageTextString = ScriptLocalization.Get("Activetext");
				_c4MessageTextActiveChip.Time = 3000;
				break;
			case C4MessageType.FINDC4INA:
				_viewModel.C4MessageTextString = ScriptLocalization.Get("Findc4Inatext");
				_c4MessageTextActiveChip.Time = 3000;
				break;
			case C4MessageType.FINDC4INB:
				_viewModel.C4MessageTextString = ScriptLocalization.Get("Findc4Inbtext");
				_c4MessageTextActiveChip.Time = 3000;
				break;
			}
		}
	}

	private void InitChips()
	{
		_c4MessageTextActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.C4MessageTextShow = _c4MessageTextActiveChip.Update(_timeComponent);
	}
}
