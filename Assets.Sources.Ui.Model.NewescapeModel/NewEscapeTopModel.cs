using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.NewescapeModel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.NewescapeModel;

[GameUiTest]
public class NewEscapeTopModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private NewEscapeTopViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _mypos;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new NewEscapeTopViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		for (int i = 1; i < 21; i++)
		{
			_viewModel.SetOthPosShow(i, value: false);
			_viewModel.SetOthPosPosShow(i, value: false);
		}
		NotifyManager.MakeNotifyClass(117, GetTipsList, SetTipsEvent, initinvoke: true);
	}

	public List<NewEscapeMessageData> GetTipsList()
	{
		return Contexts.sharedInstance.message.newEscapeTipsShow.TipsEvent;
	}

	protected virtual void SetTipsEvent(List<NewEscapeMessageData> ov, List<NewEscapeMessageData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].Type != NewEscapeMessageType.PLAYERACTIVEDISTRIBUTION)
			{
				continue;
			}
			int num = (tipsEvent[i].IntData.Count - 1) / 2;
			for (int j = 1; j < num + 1; j++)
			{
				_viewModel.SetOthPosShow(j, value: true);
				_viewModel.SetOthPosPosShow(j, value: true);
			}
			for (int k = 1; k < num + 1; k++)
			{
				if (tipsEvent[i].IntData[k + num] > 0)
				{
					_viewModel.GetOthPosImage(k).enabled = true;
					_viewModel.SetOthTexString(k, tipsEvent[i].IntData[k + num].ToString());
				}
				else
				{
					_viewModel.GetOthPosImage(k).enabled = false;
					_viewModel.SetOthTexString(k, "");
				}
				if (tipsEvent[i].IntData[k] > 0)
				{
					_viewModel.GetOthPosPosImage(k).enabled = true;
					_viewModel.SetOthTextString(k, tipsEvent[i].IntData[k].ToString());
				}
				else
				{
					_viewModel.GetOthPosPosImage(k).enabled = false;
					_viewModel.SetOthTextString(k, "");
				}
			}
			if (PlayerCareerConstantUtility.IsNoHuMan(UiIEventCondition.Get_cameraOwnerData_Career()))
			{
				if (tipsEvent[i].IntData[0] > -1)
				{
					int mid2 = _mypos;
					string assetName = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/y_bag.png";
					base.Loader.RetriveSprite("ui/newescapemodel", assetName, delegate(Sprite sprite)
					{
						_viewModel.SetOthPosSprite(mid2, sprite);
					});
				}
				_mypos = tipsEvent[i].IntData[0];
				string assetName2 = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/my_pos1.png";
				base.Loader.RetriveSprite("ui/newescapemodel", assetName2, delegate(Sprite sprite)
				{
					_viewModel.SetOthPosSprite(_mypos, sprite);
				});
			}
			else
			{
				if (tipsEvent[i].IntData[0] > -1)
				{
					int mid = _mypos;
					string assetName3 = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/b_bag.png";
					base.Loader.RetriveSprite("ui/newescapemodel", assetName3, delegate(Sprite sprite)
					{
						_viewModel.SetOthPosPosSprite(mid, sprite);
					});
				}
				_mypos = tipsEvent[i].IntData[0];
				string assetName4 = "Assets/Res/Assets/ui/GameGUIRes/newescapemodel/my_pos2.png";
				base.Loader.RetriveSprite("ui/newescapemodel", assetName4, delegate(Sprite sprite)
				{
					_viewModel.SetOthPosPosSprite(_mypos, sprite);
				});
			}
			tipsEvent.RemoveAt(i);
			i--;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
