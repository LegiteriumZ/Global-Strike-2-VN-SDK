using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

[GameUiTest]
public class PvetdbothpModel : AbstractModel, IPlaybackSystem
{
	private PvetdbothpViewModel _viewModel;

	private PlayerEntity _info;

	private ChatContext _chatContext;

	private float _hidetime;

	private float _delaytime;

	private float _hppercent;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PvetdbothpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited && _viewModel.pvetdbothpShow)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_chatContext = Contexts.sharedInstance.chat;
		_viewModel.pvetdbothpShow = false;
		NotifyManager.MakeNotify(3, UiIEventCondition.Get_hpProgressData_TargetId, SetTargetId);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetPlayerGp, SetGpChange);
	}

	private void InitChips()
	{
		_hppercent = 1f;
	}

	private void SetGpChange(int old, int newval)
	{
		if (newval < old && _chatContext.hasChatJobHistroy)
		{
			_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"\" type=\"{0}\" ><body>{1}</body></message>", "system", string.Format(ScriptLocalization.Get("player_use_gp"), old - newval, newval)));
		}
	}

	private void UpdateChips()
	{
		UpdateChipUi(this, _hppercent);
	}

	[GameTestClassRange(new object[]
	{
		new object[]
		{
			2,
			"FrameInterval",
			typeof(GameTestFloatRange),
			0,
			10f,
			2f
		},
		new object[]
		{
			0,
			"_delaytime",
			typeof(GameTestFloatRange),
			0,
			20f,
			-20f
		},
		new object[]
		{
			0,
			"_hidetime",
			typeof(GameTestFloatRange),
			1,
			2200f,
			-200f
		}
	})]
	[GameTestFloatRange(new object[] { 1, 1f, -1f })]
	[GameUiTestMethod]
	private void UpdateChipUi(PvetdbothpModel model, float percent)
	{
		_viewModel.hpProgressImageFillamount = percent;
		model._delaytime -= _timeComponent.FrameInterval;
		if (model._delaytime > 0f)
		{
			_viewModel.hpProgressEffectImageFillamount = _viewModel.hpProgressImageFillamount;
		}
		else if (Mathf.Abs(_viewModel.hpProgressEffectImageFillamount - _viewModel.hpProgressImageFillamount) > 0.001f)
		{
			if (_viewModel.hpProgressImageFillamount < _viewModel.hpProgressEffectImageFillamount)
			{
				_viewModel.hpProgressEffectImageFillamount -= 0.001f * (float)_timeComponent.FrameInterval;
			}
			else
			{
				_viewModel.hpProgressEffectImageFillamount += 0.001f * (float)_timeComponent.FrameInterval;
			}
		}
		model._hidetime += _timeComponent.FrameInterval;
		_viewModel.pvetdbothpShow = model._hidetime < 1900f;
	}

	private void SetTargetId(int old, int newval)
	{
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(newval);
		RefreshEntity(entityWithEntityId);
	}

	private void RefreshEntity(PlayerEntity botEntity)
	{
		if (botEntity != _info)
		{
			_info = botEntity;
			if (botEntity != null)
			{
				_viewModel.pvetdbothpShow = true;
				if (_info != null && _info.hasBasicInfo)
				{
					float percent = (float)_info.basicInfo.Current.Hp / (float)_info.basicInfo.Current.MaxHp;
					int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
					string playerName = _info.basicInfo.PlayerName;
					RefreshData(percent, _info.basicInfo.Current.EType, raceType, _info.IsBot(), playerName);
				}
			}
		}
		else if (botEntity != null)
		{
			_hidetime = 0f;
		}
	}

	[GameUiTestMethod]
	private void RefreshData(float percent, int etype, int racetype, bool isBot, string playername)
	{
		_hppercent = percent;
		if (!_viewModel.pvetdbothpShow)
		{
			PvetdbothpViewModel viewModel = _viewModel;
			float hpProgressEffectImageFillamount = (_viewModel.hpProgressImageFillamount = percent);
			viewModel.hpProgressEffectImageFillamount = hpProgressEffectImageFillamount;
			_delaytime = 500f;
		}
		_hidetime = 0f;
		if (etype == 9 && racetype == 1003)
		{
			_viewModel.botNameString = ScriptLocalization.Get("TOWER_NAME");
		}
		else if (isBot)
		{
			_viewModel.botNameString = playername;
		}
	}
}
