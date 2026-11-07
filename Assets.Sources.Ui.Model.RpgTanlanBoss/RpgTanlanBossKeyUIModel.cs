using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTanlanBoss;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.RpgTanlanBoss;

[GameUiTest]
public class RpgTanlanBossKeyUIModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private RpgTanlanBossKeyUIViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int RemainingTime;

	private int TotalTime;

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
		_viewModel = new RpgTanlanBossKeyUIViewModel();
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
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetUIChange, SetUIChange, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetTipChange, SetTipChange, null, initinvoke: true);
	}

	private bool GetTipChange()
	{
		return _gameRuleContext.rpgTanlanJinWu.JinwuTimeChange;
	}

	private void SetTipChange(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_gameRuleContext.rpgTanlanJinWu.JinwuTimeChange = false;
			RpgTipsEventData jinwuTime = _gameRuleContext.rpgTanlanJinWu.JinwuTime;
			RemainingTime = jinwuTime.Time1;
			TotalTime = jinwuTime.Time2;
		}
	}

	private void updateIcon(GameObject obj, string url)
	{
		if (!(obj == null))
		{
			Image img = obj.GetComponent<Image>();
			this.GetLoader().RetriveSprite("ui/rpgtanlanbossmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgTanlanBossModel/" + url + ".png", delegate(Sprite sprite)
			{
				img.sprite = sprite;
			});
		}
	}

	private void updateActive(GameObject obj, bool flag)
	{
		if (!(obj == null))
		{
			obj.SetObjectActive(flag);
		}
	}

	private void updateItemContentWidth(int itemCount)
	{
		HorizontalLayoutGroup component = _viewModel.itemContainerObj.GetComponent<HorizontalLayoutGroup>();
		Vector3 itemContainerSize = _viewModel.itemContainerSize;
		itemContainerSize.x = (float)itemCount * _viewModel.itemSize0.x + (float)(itemCount - 1) * component.spacing;
		_viewModel.itemContainerSize = itemContainerSize;
	}

	private bool GetUIChange()
	{
		return _gameRuleContext.rpgTanlanJinWu.UIChange;
	}

	private void SetUIChange(bool arg1, bool arg2)
	{
		if (arg2)
		{
			updateUI();
		}
	}

	private bool GetVisible()
	{
		return _gameRuleContext.rpgTanlanJinWu.IsUIShow;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		if (arg2)
		{
			updateUI();
		}
	}

	private void updateUI()
	{
		_gameRuleContext.rpgTanlanJinWu.UIChange = false;
		List<JinWuKeyData> keyList = _gameRuleContext.rpgTanlanJinWu.KeyList;
		GameObject itemContainerObj = _viewModel.itemContainerObj;
		int childCount = itemContainerObj.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = itemContainerObj.transform.GetChild(i);
			updateActive(child.gameObject, flag: false);
		}
		for (int j = 0; j < keyList.Count; j++)
		{
			if (j >= itemContainerObj.transform.childCount)
			{
				Transform transform = Object.Instantiate(itemContainerObj.transform.GetChild(0));
				transform.transform.parent = itemContainerObj.transform;
				transform.transform.localScale = Vector3.one;
			}
			Transform child2 = itemContainerObj.transform.GetChild(j);
			updateActive(child2.gameObject, flag: true);
			Transform transform2 = child2.FindChild("iconKeyBg");
			Transform transform3 = child2.FindChild("imgKey");
			JinWuKeyData jinWuKeyData = keyList[j];
			if (jinWuKeyData.KindType == 1)
			{
				updateIcon(transform2.gameObject, "UnityKeyUITexture/keyOnDi");
				updateIcon(transform3.gameObject, "UnityKeyUITexture/key_" + jinWuKeyData.KeyName + "_On");
			}
			else if (keyList[j].KindType == 2)
			{
				updateIcon(transform2.gameObject, "UnityKeyUITexture/keyDownDi");
				updateIcon(transform3.gameObject, "UnityKeyUITexture/key_" + jinWuKeyData.KeyName + "_Down");
			}
			else if (keyList[j].KindType == 3)
			{
				updateIcon(transform2.gameObject, "UnityKeyUITexture/keyBrDi");
				updateIcon(transform3.gameObject, "UnityKeyUITexture/key_" + jinWuKeyData.KeyName + "_br");
			}
			else if (keyList[j].KindType == 4)
			{
				updateIcon(transform2.gameObject, "UnityKeyUITexture/keyBfDi");
				updateIcon(transform3.gameObject, "UnityKeyUITexture/key_" + jinWuKeyData.KeyName + "_bf");
			}
		}
		updateItemContentWidth(keyList.Count);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (RemainingTime > 0)
		{
			RemainingTime -= time.FrameInterval;
			if (RemainingTime < 0)
			{
				RemainingTime = 0;
			}
			_viewModel.imgProgressFillamount = (float)RemainingTime / (float)TotalTime;
		}
	}
}
