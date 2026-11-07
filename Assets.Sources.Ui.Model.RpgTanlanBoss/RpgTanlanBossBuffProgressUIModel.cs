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
public class RpgTanlanBossBuffProgressUIModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private RpgTanlanBossBuffProgressUIViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private bool IsShow;

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
		_viewModel = new RpgTanlanBossBuffProgressUIViewModel();
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
		NotifyManager.MakeTempNotify(GetTipChange, SetTipChange, null, initinvoke: true);
	}

	private bool GetTipChange()
	{
		return _gameRuleContext.rpgTanlanJinWu.BuffTipsChange;
	}

	private void SetTipChange(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_gameRuleContext.rpgTanlanJinWu.BuffTipsChange = false;
			RpgTipsEventData buffTips = _gameRuleContext.rpgTanlanJinWu.BuffTips;
			IsShow = buffTips.Show;
			if (IsShow)
			{
				UpdateProgress(buffTips);
			}
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

	private void UpdateProgress(RpgTipsEventData data)
	{
		if (data.Time1 == 0 && data.Time2 == 0)
		{
			_viewModel.imgProgressFillamount = 0f;
		}
		else if (data.Time1 >= data.Time2)
		{
			_viewModel.imgProgressFillamount = (float)data.Time1 / (float)data.Time3;
			updateIcon(_viewModel.imgIconObj, "Texture/iconBing");
		}
		else
		{
			_viewModel.imgProgressFillamount = (float)data.Time2 / (float)data.Time3;
			updateIcon(_viewModel.imgIconObj, "Texture/iconHuo");
		}
	}

	private bool GetVisible()
	{
		return IsShow;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.ShowShow = IsShow;
	}
}
