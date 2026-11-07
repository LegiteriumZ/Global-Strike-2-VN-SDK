using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.HerofightingModel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.HerofightingModel;

[GameUiTest]
public class HeroFightingLeftModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HeroFightingLeftViewModel _viewModel;

	protected GameRuleContext _gameRuleContext;

	private Dictionary<int, SimpleBuffData> buffList = new Dictionary<int, SimpleBuffData>();

	private Dictionary<int, ActiveChip> buff_time = new Dictionary<int, ActiveChip>();

	private Dictionary<int, int> buff_id = new Dictionary<int, int>();

	private ActiveChip _centerActiveChip = new ActiveChip();

	private ActiveChip _gameTipActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new HeroFightingLeftViewModel();
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
		SimpleNotify.Add(GetVisible, SetVisible);
		NotifyManager.MakeNotifyClass(119, GetTipsList, SetTipsEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(121, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		_viewModel.Panel_jifengShow = false;
	}

	public List<SimpleBuffDiffData> GetTipsList()
	{
		return Contexts.sharedInstance.message.heroFightingBuffShow.BuffEvent;
	}

	protected virtual void SetTipsEvent(List<SimpleBuffDiffData> ov, List<SimpleBuffDiffData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			for (int j = 0; j < tipsEvent[i].UpdateBuffList.Count; j++)
			{
				SimpleBuffData simpleBuffData = tipsEvent[i].UpdateBuffList[j];
				if (simpleBuffData.Type != 0)
				{
					continue;
				}
				if (!buffList.ContainsKey(simpleBuffData.Id))
				{
					buffList.Add(simpleBuffData.Id, simpleBuffData);
					string assetName = "Assets/Res/Assets/ui/GameGUIRes/herofightingModel/tips/+" + simpleBuffData.BuffId + ".png";
					base.Loader.RetriveSprite("ui/herofightingmodel", assetName, delegate(Sprite sprite)
					{
						_viewModel.Panel_TipShow = true;
						_viewModel.messageSprite = sprite;
						_viewModel.messageImage.SetNativeSize();
						_centerActiveChip.Time = 3000;
					});
				}
				else
				{
					buffList[simpleBuffData.Id] = simpleBuffData;
				}
				tipsEvent[i].UpdateBuffList.RemoveAt(j);
				j--;
			}
			for (int k = 0; k < tipsEvent[i].DeleteIdList.Count; k++)
			{
				int key = tipsEvent[i].DeleteIdList[k];
				if (buffList.ContainsKey(key))
				{
					SimpleBuffData simpleBuffData2 = buffList[key];
					string assetName2 = "Assets/Res/Assets/ui/GameGUIRes/herofightingModel/tips/-" + simpleBuffData2.BuffId + ".png";
					base.Loader.RetriveSprite("ui/herofightingmodel", assetName2, delegate(Sprite sprite)
					{
						_viewModel.Panel_TipShow = true;
						_viewModel.messageSprite = sprite;
						_viewModel.messageImage.SetNativeSize();
						_centerActiveChip.Time = 3000;
					});
					buffList.Remove(key);
					tipsEvent[i].DeleteIdList.RemoveAt(k);
					k--;
				}
			}
			if (tipsEvent[i].UpdateBuffList.Count == 0 && tipsEvent[i].DeleteIdList.Count == 0)
			{
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
		int num = 0;
		foreach (ActiveChip value in buff_time.Values)
		{
			value.Time = 0;
		}
		foreach (SimpleBuffData value2 in buffList.Values)
		{
			num++;
			_viewModel.SetbuffShow(num, value: true);
			if (value2.Duration < 0)
			{
				_viewModel.SetbuffsumString(num, value2.Cnt.ToString());
			}
			else
			{
				if (!buff_time.ContainsKey(value2.BuffId))
				{
					buff_time.Add(value2.BuffId, new ActiveChip());
				}
				if (!buff_id.ContainsKey(value2.BuffId))
				{
					buff_id.Add(value2.BuffId, num);
				}
				else
				{
					buff_id[value2.BuffId] = num;
				}
				buff_time[value2.BuffId].Time = value2.StartTime + value2.Duration - _timeComponent.ServerTime;
			}
			int mid = num;
			string assetName3 = "Assets/Res/Assets/ui/GameGUIRes/herofightingModel/buff/" + value2.BuffId + ".png";
			base.Loader.RetriveSprite("ui/herofightingmodel", assetName3, delegate(Sprite sprite)
			{
				_viewModel.SetbufficonSprite(mid, sprite);
			});
		}
		for (int l = buffList.Count; l < 10; l++)
		{
			_viewModel.SetbuffShow(l + 1, value: false);
		}
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -13504)
			{
				_viewModel.jfString1 = tipsEvent[i].Time1.ToString();
				_viewModel.jfString2 = tipsEvent[i].Time2.ToString();
				_viewModel.Panel_jifengShow = true;
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -13505)
			{
				string assetName = "Assets/Res/Assets/ui/GameGUIRes/herofightingModel/tips/top2.png";
				base.Loader.RetriveSprite("ui/herofightingmodel", assetName, delegate(Sprite sprite)
				{
					_viewModel.Game_TipShow = true;
					_viewModel.game_messageSprite = sprite;
					_viewModel.messageImage.SetNativeSize();
					_gameTipActiveChip.Time = 3000;
				});
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -13503)
			{
				string assetName2 = "Assets/Res/Assets/ui/GameGUIRes/herofightingModel/tips/outtips.png";
				base.Loader.RetriveSprite("ui/herofightingmodel", assetName2, delegate(Sprite sprite)
				{
					_viewModel.Game_TipShow = true;
					_viewModel.game_messageSprite = sprite;
					_viewModel.messageImage.SetNativeSize();
					_gameTipActiveChip.Time = 3000;
				});
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void SetVisible(bool arg1, int index)
	{
		string assetName = "Assets/Res/Assets/ui/GameGUIRes/herofightingModel/tips/insufficient.png";
		base.Loader.RetriveSprite("ui/herofightingmodel", assetName, delegate(Sprite sprite)
		{
			_viewModel.Game_TipShow = arg1;
			_viewModel.game_messageSprite = sprite;
			_viewModel.messageImage.SetNativeSize();
			if (arg1)
			{
				_gameTipActiveChip.Time = int.MaxValue;
			}
			else
			{
				_gameTipActiveChip.Time = 0;
			}
		});
	}

	private bool GetVisible(int index)
	{
		return getTipsData(-2545)?.Show ?? false;
	}

	private RpgTipsEventData getTipsData(int tipID)
	{
		Dictionary<int, RpgTipsEventData> eventDataDic = _gameRuleContext.rpgCommon.EventDataDic;
		RpgTipsEventData value = null;
		if (eventDataDic != null)
		{
			eventDataDic.TryGetValue(tipID, out value);
			if (value != null)
			{
				return value;
			}
		}
		return null;
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
		_gameTipActiveChip.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.Panel_TipShow = _centerActiveChip.Update(_timeComponent);
		_viewModel.Game_TipShow = _gameTipActiveChip.Update(_timeComponent);
		foreach (int key in buff_time.Keys)
		{
			if (buff_time[key].Time > 0)
			{
				buff_time[key].Update(_timeComponent);
				_viewModel.SetbuffsumString(buff_id[key], (buff_time[key].Time / 1000).ToString());
			}
		}
	}
}
