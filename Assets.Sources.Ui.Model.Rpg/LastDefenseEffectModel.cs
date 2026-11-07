using Assets.Sources.Components.Message.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class LastDefenseEffectModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private LastDefenseEffectViewModel _viewModel;

	private int _showeffectTime;

	private FrameAnimaChip _chip = new FrameAnimaChip();

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
		_viewModel = new LastDefenseEffectViewModel();
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
		_viewModel.lastDefenseEffectShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgPopMsg_TimeQueueCount, SetRpgPopMsgCnt, _viewModel.lastDefenseEffectObj);
	}

	private void SetRpgPopMsgCnt(int old, int newcnt)
	{
		if (newcnt <= 0)
		{
			return;
		}
		while (UiIEventCondition.Get_rpgPopMsg_TimeQueueCount() > 0)
		{
			RpgPopMsgComponent.PopMsg msg = _messageContext.rpgPopMsg.TimeQueue.Dequeue();
			if (msg.IsTime)
			{
				ShowInfo(ref msg);
			}
		}
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.Remove(_viewModel.lastDefenseEffectObj);
	}

	private void InitChips()
	{
		_chip.IsLoop = true;
		_chip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type1_arrow/effect_type1_arrow";
		_chip.StartIndex = 1;
		_chip.Count = 10;
		_chip.Init();
	}

	private void UpdateChips()
	{
		if (_showeffectTime > 0)
		{
			_viewModel.lastDefenseEffectShow = true;
			_showeffectTime -= _timeComponent.FrameInterval;
			string assetName = _chip.Update(_timeComponent);
			base.Loader.RetriveSprite("ui/freerpg_110000model", assetName, _viewModel.tipsImage2);
		}
		else
		{
			_viewModel.lastDefenseEffectShow = false;
		}
	}

	private void ShowInfo(ref RpgPopMsgComponent.PopMsg msg)
	{
		if (int.TryParse(msg.Text, out var result))
		{
			_showeffectTime = result;
			_viewModel.lastDefenseEffectShow = true;
			if (msg.Type == 1004)
			{
				base.Loader.RetriveSprite("ui/freerpg_110000model", "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type1_arrow/effect_type1_font.png", _viewModel.tipsImage1);
				base.Loader.RetriveSprite("ui/freerpg_110000model", "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type1_arrow/effect_type1_back.png", _viewModel.backImage);
				_chip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type1_arrow/effect_type1_arrow";
				_chip.Index = 1;
			}
			else if (msg.Type == 1005)
			{
				base.Loader.RetriveSprite("ui/freerpg_110000model", "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type2_arrow/effect_type2_font.png", _viewModel.tipsImage1);
				base.Loader.RetriveSprite("ui/freerpg_110000model", "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type2_arrow/effect_type2_back.png", _viewModel.backImage);
				_chip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type2_arrow/effect_type2_arrow";
				_chip.Index = 1;
			}
			else if (msg.Type == 1006)
			{
				base.Loader.RetriveSprite("ui/freerpg_110000model", "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type3_arrow/effect_type3_font.png", _viewModel.tipsImage1);
				base.Loader.RetriveSprite("ui/freerpg_110000model", "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type3_arrow/effect_type3_back.png", _viewModel.backImage);
				_chip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_type2_arrow/effect_type2_arrow";
				_chip.Index = 1;
			}
		}
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
