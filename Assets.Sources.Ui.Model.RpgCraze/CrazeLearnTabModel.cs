using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgCraze;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.RpgCraze;

[GameUiTest]
public class CrazeLearnTabModel : AbstractModel, IPlaybackSystem, ISetBattleServerContext, ISetBattleRoomContext, ISetGameRuleContext, IKeyboardResponder
{
	private BattleServerContext _battleServerContext;

	private CrazeLearnTabViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private readonly List<Image> _skillImages = new List<Image>();

	private readonly List<Text> _skillLvs = new List<Text>();

	private readonly AssetInfo[] _bgImageInfos = new AssetInfo[5]
	{
		new AssetInfo("ui/rpgcrazemode", "bg_gray"),
		new AssetInfo("ui/rpgcrazemode", "bg_green"),
		new AssetInfo("ui/rpgcrazemode", "bg_purple"),
		new AssetInfo("ui/rpgcrazemode", "bg_yellow"),
		new AssetInfo("ui/rpgcrazemode", "bg_red")
	};

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CrazeLearnTabViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null)
		{
			_ = _viewModel.IsInited;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		InitPanel();
		NotifyManager.MakeNotify(80, UiIEventCondition.Get_Craze_SkillLearn, UpdatePanel);
	}

	private void InitPanel()
	{
		_viewModel.ShowShow = false;
		Transform transform = _viewModel.ImageBGObj.transform;
		for (int j = 0; j < transform.childCount; j++)
		{
			Transform child = transform.GetChild(j);
			for (int k = 0; k < child.childCount; k++)
			{
				Transform child2 = child.GetChild(k);
				_skillImages.Add(child2.GetComponent<Image>());
				_skillLvs.Add(child2.GetChild(0).GetComponent<Text>());
			}
		}
		for (int l = 0; l < _skillImages.Count; l++)
		{
			int i1 = l;
			base.Loader.RetriveSprite(_bgImageInfos[0].BundleName, _bgImageInfos[0].AssetName, delegate(Sprite sprite)
			{
				_skillImages[i1].sprite = sprite;
			});
			_skillLvs[l].text = "0";
		}
	}

	private void UpdatePanel(bool arg1, bool arg2)
	{
		List<int> skillLearnList = _gameRuleContext.craze.SkillLearnList;
		for (int j = 0; j < _skillImages.Count; j++)
		{
			int num = 0;
			int num2 = 0;
			if (skillLearnList.Count > j)
			{
				num2 = skillLearnList[j];
				_skillLvs[j].text = StringCache.IntToString(num2);
			}
			if (num2 > 0 && num2 < 4)
			{
				num = 1;
			}
			else if (num2 > 3 && num2 < 6)
			{
				num = 2;
			}
			else if (num2 > 5 && num2 < 11)
			{
				num = 3;
			}
			else if (num2 > 10)
			{
				num = 4;
			}
			int i1 = j;
			base.Loader.RetriveSprite(_bgImageInfos[num].BundleName, _bgImageInfos[num].AssetName, delegate(Sprite sprite)
			{
				_skillImages[i1].sprite = sprite;
			});
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Tab && !_viewModel.ShowShow)
		{
			_battleServerContext.battleServer.Server.SendTcpMessage(36);
			_viewModel.ShowShow = true;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.Tab)
		{
			_viewModel.ShowShow = false;
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}
}
