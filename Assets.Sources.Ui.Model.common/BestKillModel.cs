using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class BestKillModel : AbstractModel, IPlaybackSystem
{
	protected BestKillViewModel _viewModel;

	protected const int ShowTime = 10000;

	private string _suffix = "...";

	private int _suffixLength;

	private Text _text;

	private ActiveChip _showActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	protected ActiveChip ShowActiveChip => _showActiveChip;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BestKillViewModel();
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
		_text = _viewModel.PlayerNameObj1.GetComponent<Text>();
		_suffixLength = TextUtils.CalculateLengthOfText(_suffix, _text);
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bestKillData_LastMvpData, SetLastMvpData, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bestKillData_BiochemicalBestData, SetBiochemicalBestData, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bestKillData_GroupBestData, SetGroupBestData, null, initinvoke: true);
	}

	private string StripLengthWithSuffix(string name)
	{
		return TextUtils.StripLengthWithSuffix(name, _text, _suffix, _suffixLength, (int)_text.rectTransform.sizeDelta.x);
	}

	private void SetGroupBestData(GroupBestKillData arg1, GroupBestKillData arg2)
	{
		if (!UiIEventCondition.Get_uiRoomData_IsObserver())
		{
			return;
		}
		if (arg2 == null)
		{
			return;
		}
		_viewModel.BestItemShow1 = arg2.Ace1Specified;
		if (_viewModel.BestItemShow1)
		{
			_viewModel.PlayerNameString1 = StripLengthWithSuffix(arg2.Ace1);
			_viewModel.DataString1 = arg2.AceNum1.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/ace.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite1 = sprite;
			});
		}
		_viewModel.BestItemShow2 = arg2.Ace2Specified;
		if (_viewModel.BestItemShow2)
		{
			_viewModel.PlayerNameString2 = StripLengthWithSuffix(arg2.Ace2);
			_viewModel.DataString2 = arg2.AceNum2.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/2nd.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite2 = sprite;
			});
		}
		_viewModel.BestItemShow3 = arg2.Ace3Specified;
		if (_viewModel.BestItemShow3)
		{
			_viewModel.PlayerNameString3 = StripLengthWithSuffix(arg2.Ace3);
			_viewModel.DataString3 = arg2.AceNum3.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/3rd.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite3 = sprite;
			});
		}
		_viewModel.BestItemShow4 = arg2.BestKillSpecified;
		if (arg2.BestKillSpecified)
		{
			_viewModel.PlayerNameString4 = StripLengthWithSuffix(arg2.BestKill);
			_viewModel.DataString4 = arg2.BestNum.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/oneminute.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite4 = sprite;
			});
		}
		_viewModel.ShowShow = _viewModel.BestItemShow1 || _viewModel.BestItemShow2 || _viewModel.BestItemShow3 || _viewModel.BestItemShow4;
		_showActiveChip.Time = (_viewModel.ShowShow ? 10000 : 0);
	}

	private void SetBiochemicalBestData(BiochemicalBestData arg1, BiochemicalBestData arg2)
	{
		if (arg2 == null)
		{
			return;
		}
		_viewModel.BestItemShow1 = arg2.BestHumanSpecified && arg2.Damage >= 1000;
		if (_viewModel.BestItemShow1)
		{
			_viewModel.PlayerNameString1 = StripLengthWithSuffix(arg2.BestHuman);
			_viewModel.DataString1 = (arg2.Damage / 1000).ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/besthumanity.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite1 = sprite;
			});
		}
		_viewModel.BestItemShow2 = arg2.BestZombieSpecified;
		if (_viewModel.BestItemShow2)
		{
			_viewModel.PlayerNameString2 = StripLengthWithSuffix(arg2.BestZombie);
			_viewModel.DataString2 = arg2.InfectionNum.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/bestdoun.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite2 = sprite;
			});
		}
		_viewModel.BestItemShow3 = false;
		_viewModel.BestItemShow4 = false;
		_viewModel.ShowShow = _viewModel.BestItemShow1 || _viewModel.BestItemShow2 || _viewModel.BestItemShow3 || _viewModel.BestItemShow4;
		_showActiveChip.Time = (_viewModel.ShowShow ? 10000 : 0);
	}

	protected virtual void SetLastMvpData(LastMvpData arg1, LastMvpData arg2)
	{
		if (arg2 == null)
		{
			return;
		}
		_viewModel.BestItemShow1 = arg2.KillDataSpecified;
		if (_viewModel.BestItemShow1)
		{
			_viewModel.PlayerNameString1 = StripLengthWithSuffix(arg2.KillPlayerName);
			_viewModel.DataString1 = arg2.KillData.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/bestkill.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite1 = sprite;
			});
		}
		_viewModel.BestItemShow2 = arg2.DamageDataSpecified;
		if (_viewModel.BestItemShow2)
		{
			_viewModel.PlayerNameString2 = StripLengthWithSuffix(arg2.DamagePlayerName);
			_viewModel.DataString2 = arg2.DamageData.ToString();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/bestplayer/bestdamage.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite2 = sprite;
			});
		}
		_viewModel.BestItemShow3 = arg2.ReliveDataSpecified;
		if (_viewModel.BestItemShow3)
		{
			_viewModel.PlayerNameString3 = StripLengthWithSuffix(arg2.RelivePlayerName);
			_viewModel.DataString3 = arg2.ReliveData.ToString();
			base.Loader.RetriveSprite("ui/bigheadmodel", "Assets/Res/Assets/ui/GameGUIRes/bigheadModel/bestplayer/bestwet.png", delegate(Sprite sprite)
			{
				_viewModel.BestItemSprite3 = sprite;
			});
		}
		_viewModel.BestItemShow4 = false;
		_viewModel.ShowShow = _viewModel.BestItemShow1 || _viewModel.BestItemShow2 || _viewModel.BestItemShow3 || _viewModel.BestItemShow4;
		_showActiveChip.Time = (_viewModel.ShowShow ? 10000 : 0);
	}

	private void InitChips()
	{
		_showActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _showActiveChip.Update(_timeComponent);
	}
}
