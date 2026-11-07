using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgDragonModel : AbstractModel, IPlaybackSystem
{
	private RpgDragonViewModel _viewModel;

	private AssetInfo _moveHouseAsset = new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/dragoon/moveHouse.png");

	private AssetInfo _useToSelfAsset = new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/dragoon/useToSelf.png");

	private AssetInfo _useToTargetAsset = new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/dragoon/useToTarget.png");

	private AssetInfo _useDragoonAsset = new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/dragoon/usedragoon.png");

	private ActiveChip _messageActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgDragonViewModel();
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
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_floatingMessage_DragoonData, SetDragoonData, null, initinvoke: true);
	}

	private void SetDragoonData(FloatingMessageData ov, FloatingMessageData data)
	{
		if (data == null)
		{
			_viewModel.BackRootshow = false;
			_viewModel.CenterShow = false;
			_messageActiveChip.Time = 0;
			return;
		}
		_viewModel.CenterShow = true;
		SetImagePosition();
		int num = -1;
		switch (data.SkillType)
		{
		case FloatingSkillType.SELF:
			num = (data.Open ? 1 : 0);
			_messageActiveChip.Time = (data.Open ? int.MaxValue : 0);
			_viewModel.MessageSprite = this.GetLoader().RetriveSprite(_useToSelfAsset, delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
				_viewModel.MessageNtvsize();
			});
			break;
		case FloatingSkillType.POSTION:
			num = (data.Open ? 1 : 0);
			_messageActiveChip.Time = (data.Open ? int.MaxValue : 0);
			_viewModel.MessageSprite = this.GetLoader().RetriveSprite(_moveHouseAsset, delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
				_viewModel.MessageNtvsize();
			});
			break;
		case FloatingSkillType.LOCKTARGET:
			num = (data.Open ? 1 : 0);
			_messageActiveChip.Time = (data.Open ? int.MaxValue : 0);
			_viewModel.MessageSprite = this.GetLoader().RetriveSprite(_useToTargetAsset, delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
				_viewModel.MessageNtvsize();
			});
			break;
		case FloatingSkillType.USEDRAGOON:
			_viewModel.BackRootshow = false;
			_messageActiveChip.Time = (data.Open ? int.MaxValue : 0);
			_viewModel.MessageSprite = this.GetLoader().RetriveSprite(_useDragoonAsset, delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
				_viewModel.MessageNtvsize();
			});
			break;
		}
		if (num > -1)
		{
			if (num == 1)
			{
				_viewModel.BackRootshow = true;
			}
			else
			{
				_viewModel.BackRootshow = false;
			}
		}
	}

	private void SetImagePosition()
	{
		Rect rect = _viewModel.CenterObj.GetComponent<RectTransform>().rect;
		_viewModel.LeftPosition = new Vector3((0f - rect.height) / 540f * 960f / 2f, 0f);
		_viewModel.RightPosition = new Vector3(rect.height / 540f * 960f / 2f, 0f);
	}

	private void InitChips()
	{
		_messageActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.MessageShow = _messageActiveChip.Update(_timeComponent);
	}
}
