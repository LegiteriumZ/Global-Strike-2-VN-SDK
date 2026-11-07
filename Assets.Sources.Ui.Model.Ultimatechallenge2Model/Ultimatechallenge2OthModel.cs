using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Free.UI;
using Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;
using math;

namespace Assets.Sources.Ui.Model.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2OthModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Ultimatechallenge2OthViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private DirectionImage _image;

	private ActiveChip SKILL_CD = new ActiveChip();

	private ActiveChip FROG_DAOJISHI = new ActiveChip();

	private int skillNextTime;

	private int skillcdTime;

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
		_viewModel = new Ultimatechallenge2OthViewModel();
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
		NotifyManager.MakeNotifyClass(118, GetMessageList, SetTipsEvent, initinvoke: true);
		_image = _viewModel.directionImageObj.GetComponent<DirectionImage>();
		_image.SetOriginUv(1176f, 30f, new FreeImageComponent.ImageComponentData(1176, 30));
		_image.SetOpacityUvOnce(1f, 1f);
	}

	public List<UltChallenge> GetMessageList()
	{
		return Contexts.sharedInstance.message.ultimatechallenge2.MessageEvent;
	}

	protected virtual void SetTipsEvent(List<UltChallenge> ov, List<UltChallenge> messageEvent)
	{
		if (messageEvent == null)
		{
			return;
		}
		for (int j = 0; j < messageEvent.Count; j++)
		{
			if (messageEvent[j].EventId == 1)
			{
				_viewModel._Number_roomInfo_FreeUI_FreeCanvas_String = messageEvent[j].Ins[0].ToString();
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 2)
			{
				_viewModel._Number_roomInfo_FreeUI_FreeCanvas_String = messageEvent[j].Ins[0].ToString();
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 6)
			{
				int i;
				for (i = 0; i < 2; i++)
				{
					string assetName = "Assets/Res/Assets/ui/GameGUIRes/UltimateChallenge2Model/skill/skill" + messageEvent[j].Ins[i] + ".png";
					base.Loader.RetriveSprite("ui/newescapemodel", assetName, delegate(Sprite sprite)
					{
						_viewModel.Setskill_IconSprite(i + 1, sprite);
					});
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 7)
			{
				skillNextTime = messageEvent[j].Ins[1];
				skillcdTime = messageEvent[j].Ins[2];
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 12)
			{
				if (messageEvent[j].Ins[0] > 0)
				{
					_viewModel.airJumpInfoShow = true;
					_viewModel.parachute_speedString = messageEvent[j].Ins[0].ToString();
				}
				else
				{
					_viewModel.airJumpInfoShow = false;
				}
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 27)
			{
				FROG_DAOJISHI.Time = messageEvent[j].Ins[0];
				messageEvent.RemoveAt(j);
				j--;
			}
			else if (messageEvent[j].EventId == 28)
			{
				_viewModel.safeRate_progressFillamount = (float)(messageEvent[j].Ds[0] / messageEvent[j].Ds[1]);
				messageEvent.RemoveAt(j);
				j--;
			}
		}
	}

	private void InitChips()
	{
		SKILL_CD.Time = 0;
		FROG_DAOJISHI.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		FROG_DAOJISHI.Update(time);
		if (time.ServerTime < skillNextTime)
		{
			_viewModel.Setskill_cdFillamount(1, ((float)skillNextTime - (float)time.ServerTime * 1f) / (float)skillcdTime);
		}
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		float num = (float)AngleUtils.MakeAngleInRange(90f - myPlayerEntity.orientation.Yaw);
		float x = (num - 90f) / 360f;
		float z = (num + 90f) / 360f;
		Vector4 uvControl = new Vector4(x, 0f, z, 1f);
		_image.SetUvControl(uvControl);
		if (FROG_DAOJISHI.Time / 1000 > 60)
		{
			_viewModel.daojishi_fString = (FROG_DAOJISHI.Time / 1000 / 60).ToString();
		}
		if (FROG_DAOJISHI.Time / 1000 >= 0)
		{
			_viewModel.daojishi_mString = (FROG_DAOJISHI.Time / 1000 % 60).ToString();
		}
	}
}
