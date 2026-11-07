using Assets.Sources.Components.Message.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class LastDefenseOtherTowerHpModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private LastDefenseOtherTowerHpViewModel _viewModel;

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
		_viewModel = new LastDefenseOtherTowerHpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.LastDefenseOtherTowerHpShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgPopMsg_RightDownQueueCount, SetRpgPopMsgCnt, _viewModel.LastDefenseOtherTowerHpObj);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.RemoveUnused();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void SetRpgPopMsgCnt(int old, int newcnt)
	{
		if (newcnt > 0)
		{
			while (UiIEventCondition.Get_rpgPopMsg_RightDownQueueCount() > 0)
			{
				RpgPopMsgComponent.PopMsg msg = _messageContext.rpgPopMsg.RightDownQueue.Dequeue();
				ShowRightDownInfo(ref msg);
			}
		}
	}

	private void ShowRightDownInfo(ref RpgPopMsgComponent.PopMsg msg)
	{
		if (msg.IsRightDown)
		{
			_viewModel.LastDefenseOtherTowerHpShow = true;
			if (int.TryParse(msg.Text, out var result))
			{
				ShowInfo(result, msg.Text);
			}
		}
	}

	[GameTestFloatRange(new object[] { 0, 0, 2000 })]
	[GameUiTestMethod]
	private void ShowInfo(int value, string text)
	{
		int num = value;
		int num2 = 0;
		while (num >= 10)
		{
			num2++;
			num /= 10;
		}
		_viewModel.tipsAnchoredposition2 = _viewModel.tipsAnchoredposition1 + new Vector2(_viewModel.tipsSize1.x / 2f + (float)(25 * num2) + 45f, 0f);
		_viewModel.infoString = text;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
