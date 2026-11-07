using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GoldExplode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GoldExplode;

public class GoldExplodeMessageModel : AbstractModel, IPlaybackSystem
{
	private GoldexplodemessageViewModel _viewModel;

	private int timeCount;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GoldexplodemessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.PanelShow && _timeComponent.ClientRealTime - timeCount >= 3000)
		{
			_viewModel.PanelShow = false;
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.PanelShow = false;
		NotifyManager.MakeNotify(25, UiIEventCondition.Get_blastMessageData_GoldMessageChanged, SetGoldMessageChanged, initinvoke: true);
	}

	private void SetGoldMessageChanged(bool ov, bool changed)
	{
		if (!changed)
		{
			return;
		}
		C4MessageType blastMessageData_Type = UiIEventCondition.Get_blastMessageData_Type();
		if (blastMessageData_Type != C4MessageType.NOMONEY && blastMessageData_Type != C4MessageType.HAVELUCKYWEAPON && blastMessageData_Type != C4MessageType.HAVEEQUIPMENT)
		{
			return;
		}
		_viewModel.PanelShow = true;
		switch (blastMessageData_Type)
		{
		case C4MessageType.NOMONEY:
			base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldexplodemodel/message/nomoney.png", delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
			break;
		case C4MessageType.HAVELUCKYWEAPON:
			_viewModel.MessageImageSprite = base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldexplodemodel/message/nobuyluckyweapon.png", delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
			break;
		case C4MessageType.HAVEEQUIPMENT:
			_viewModel.MessageImageSprite = base.Loader.RetriveSprite("ui/goldexplodemodel", "Assets/Res/Assets/ui/GameGUIRes/goldexplodemodel/message/haveequipment.png", delegate(Sprite sprite)
			{
				_viewModel.MessageImageSprite = sprite;
				_viewModel.MessageImageNtvsize();
			});
			break;
		}
		timeCount = Contexts.sharedInstance.time.time.ClientRealTime;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
