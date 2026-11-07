using System;
using System.Collections.Generic;
using Assets.Sources.Chat;
using Assets.Sources.Components.Interface.Info.Chat;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ChattingLiveModel : AbstractModel, IPlaybackSystem
{
	private const int MaxShowCount = 8;

	private ChattingLiveViewModel _viewModel;

	private List<ChatHistroyData> _giftList = new List<ChatHistroyData>();

	private List<ChatHistroyData> _barrageList = new List<ChatHistroyData>();

	private ChatContext _chatContext;

	private Comparison<ChatHistroyData> _comparison;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		_comparison = SortFunc;
		_chatContext = Contexts.sharedInstance.chat;
	}

	public override void CreateViewModel()
	{
		_viewModel = new ChattingLiveViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited && _chatContext.hasChatJobHistroy)
		{
			bool barchange = false;
			bool giftchange = false;
			SplitList(ref barchange, ref giftchange);
			UpdateBarrageList(ref barchange);
			UpdateGiftList(ref giftchange);
		}
	}

	private void SplitList(ref bool barchange, ref bool giftchange)
	{
		List<IChatHistroyData> group = _chatContext.chatJobHistroy.LiveList.Group;
		for (int i = 0; i < group.Count; i++)
		{
			ChatHistroyData item = (ChatHistroyData)(object)group[i];
			if (item.MsgType == "live_barrage")
			{
				_barrageList.Add(item);
				barchange = true;
			}
			else if (item.MsgType == "live_gift")
			{
				_giftList.Add(item);
				giftchange = true;
			}
		}
		group.Clear();
		_chatContext.chatJobHistroy.LiveList.Mark = false;
	}

	private void UpdateBarrageList(ref bool barchange)
	{
		for (int i = 0; i < _barrageList.Count; i++)
		{
			ChatHistroyData value = _barrageList[i];
			value.KeepTime -= _timeComponent.FrameInterval;
			_barrageList[i] = value;
			if (_barrageList[i].KeepTime <= 0)
			{
				_barrageList.RemoveAt(i);
				barchange = true;
				i--;
			}
			else if (_barrageList.Count > 8 && _barrageList[i].KeepTime < 9000)
			{
				_barrageList.RemoveAt(i);
				barchange = true;
				i--;
			}
		}
		if (_barrageList.Count > 8)
		{
			_barrageList.RemoveRange(8, _barrageList.Count - 8);
		}
		if (barchange)
		{
			for (int j = 0; j < _barrageList.Count; j++)
			{
				ChatHistroyData chatHistroyData = _barrageList[j];
				_viewModel.SetGiftTextShow(j + 1, value: true);
				_viewModel.SetGiftTextString(j + 1, chatHistroyData.AssembleBody);
			}
			for (int k = _barrageList.Count; k < 8; k++)
			{
				_viewModel.SetGiftTextShow(k + 1, value: false);
			}
		}
	}

	private void UpdateGiftList(ref bool giftChanged)
	{
		for (int i = 0; i < _giftList.Count; i++)
		{
			ChatHistroyData value = _giftList[i];
			value.KeepTime -= _timeComponent.FrameInterval;
			_giftList[i] = value;
			if (_giftList[i].KeepTime < 0)
			{
				_giftList.RemoveAt(i);
				giftChanged = true;
				i--;
			}
			else if (_giftList.Count > 8 && _giftList[i].KeepTime < 9000)
			{
				_giftList.RemoveAt(i);
				giftChanged = true;
				i--;
			}
		}
		if (_giftList.Count > 8)
		{
			_giftList.RemoveRange(8, _giftList.Count - 8);
		}
		if (giftChanged)
		{
			_giftList.Sort(_comparison);
			for (int j = 0; j < _giftList.Count; j++)
			{
				ChatHistroyData chatHistroyData = _giftList[j];
				_viewModel.SetGiftTextShow(j + 1, value: true);
				_viewModel.SetGiftTextString(j + 1, chatHistroyData.AssembleBody);
			}
			for (int k = _giftList.Count; k < 8; k++)
			{
				_viewModel.SetGiftTextShow(k + 1, value: false);
			}
		}
	}

	private int SortFunc(ChatHistroyData x, ChatHistroyData y)
	{
		if (x.Weight <= y.Weight)
		{
			return -1;
		}
		return 1;
	}
}
