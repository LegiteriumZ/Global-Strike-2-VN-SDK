using System.Collections.Generic;
using Assets.Sources.Components.Message.DeathMatch;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.DeathMatch;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.DeathMatch;

public class DeathMatchMessageModel : AbstractModel, IPlaybackSystem
{
	private DeathMatchMessageViewModel _viewModel;

	private int _currPary;

	private ActiveChip _centerActiveChip = new ActiveChip();

	private ActiveChip _centerTextActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new DeathMatchMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			UpdateParyMessage();
		}
	}

	private void UpdateParyMessage()
	{
		if (_centerTextActiveChip.Time < -2000)
		{
			List<DeathMatchMessageComponent.ParyReliveData> deathMatchMessage_ParyMessage = UiIEventCondition.Get_deathMatchMessage_ParyMessage();
			if (deathMatchMessage_ParyMessage != null && deathMatchMessage_ParyMessage.Count > 0)
			{
				DeathMatchMessageComponent.ParyReliveData paryReliveData = deathMatchMessage_ParyMessage[0];
				deathMatchMessage_ParyMessage.RemoveAt(0);
				_currPary = paryReliveData.PlayerId;
				_centerTextActiveChip.Time = 5000;
				_viewModel.CenterTextString = paryReliveData.ParyText;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(29, UiIEventCondition.Get_deathMatchMessage_MessageType, SetMessageType, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_deathMatchMessage_Name, SetName, null, initinvoke: true);
		NotifyManager.MakeNotify(30, UiIEventCondition.Get_deathMatchMessage_CancelPary, SetCancelPary, initinvoke: true);
	}

	private void SetCancelPary(int ov, int id)
	{
		if (_currPary == id && _centerTextActiveChip.Time > 0)
		{
			_centerTextActiveChip.Time = 0;
		}
	}

	private void SetName(string ov, string name)
	{
		DeathMatchMessageViewModel viewModel = _viewModel;
		string nameString = (_viewModel.NameString2 = name);
		viewModel.NameString1 = nameString;
		_viewModel.CenterHlayoutupdate();
	}

	private void SetMessageType(int ov, int type)
	{
		string text = "";
		switch ((DeathMatchMessageType)type)
		{
		case DeathMatchMessageType.RELIVEPLAYERE:
			text = "reliveplayerE";
			_centerActiveChip.Time = 100;
			_viewModel.NameShow1 = false;
			_viewModel.NameShow2 = false;
			break;
		case DeathMatchMessageType.RELIVEFRIEND:
			text = "relivefriend";
			_centerActiveChip.Time = 3000;
			_viewModel.NameShow1 = false;
			_viewModel.NameShow2 = true;
			break;
		case DeathMatchMessageType.RELIVESELF:
			text = "reliveself";
			_centerActiveChip.Time = 3000;
			_viewModel.NameShow1 = true;
			_viewModel.NameShow2 = false;
			break;
		case DeathMatchMessageType.PLAYERISRELIVEING:
			text = "reliveover";
			_centerActiveChip.Time = 3000;
			_viewModel.NameShow1 = false;
			_viewModel.NameShow2 = false;
			break;
		case DeathMatchMessageType.NOPLAYERRELIVEYOU:
			text = "longtimerelive";
			_centerActiveChip.Time = 3000;
			_viewModel.NameShow1 = false;
			_viewModel.NameShow2 = false;
			break;
		case DeathMatchMessageType.LIMITRELIVE:
			text = "norelive";
			_centerActiveChip.Time = 3000;
			_viewModel.NameShow1 = false;
			_viewModel.NameShow2 = false;
			break;
		}
		if (!string.IsNullOrEmpty(text))
		{
			_viewModel.MessageSprite = base.Loader.RetriveSprite("ui/deathmatchmodel", "Assets/Res/Assets/ui/GameGUIRes/deathMatchModel/message/" + text + ".png", delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
				_viewModel.MessageNtvsize();
				_viewModel.CenterHlayoutupdate();
			});
		}
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
		_centerTextActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.CenterShow = _centerActiveChip.Update(_timeComponent);
		_viewModel.CenterTextShow = _centerTextActiveChip.Update(_timeComponent);
	}
}
