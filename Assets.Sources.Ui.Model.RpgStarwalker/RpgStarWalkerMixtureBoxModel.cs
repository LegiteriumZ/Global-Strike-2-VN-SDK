using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgStarwalker;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.RpgStarwalker;

[GameUiTest]
public class RpgStarWalkerMixtureBoxModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private RpgStarWalkerMixtureBoxViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private const int HEIGHT = 50;

	private const int WIDTH = 154;

	private const int MARGIN_H = 154;

	private const int MARGIN_W = 154;

	private Transform container;

	private HeJiTabKeyData hejiData;

	private bool _show;

	protected override IUiViewModel ViewModel => _viewModel;

	public void updateData(Transform trans, int index, HeJiTabKeyData data)
	{
		SetGameRuleContext(Contexts.sharedInstance.gameRule);
		container = trans;
		hejiData = data;
	}

	public void hide()
	{
		_show = false;
	}

	public void show()
	{
		_show = true;
	}

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
		_viewModel = new RpgStarWalkerMixtureBoxViewModel();
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
		_viewModel.RpgStarWalkerMixtureBoxObj.transform.localScale = Vector3.one;
		_viewModel.Visible(_show);
		_viewModel.RpgStarWalkerMixtureBoxObj.transform.SetParent(container);
		_viewModel.MixtureNameString = hejiData.Name;
		_viewModel.MixtureDescString = hejiData.Desc;
		this.GetLoader().RetriveSprite("ui/rpgstarwalkermodel", "Assets/Res/Assets/ui/GameGUIRes/rpgStarWalkerModel/hejiIcon/" + hejiData.Id + ".png", delegate(Sprite sprite)
		{
			_viewModel.MixtureIconImage.sprite = sprite;
		});
		this.GetLoader().RetriveSprite("ui/rpgstarwalkermodel", "Assets/Res/Assets/ui/GameGUIRes/rpgStarWalkerModel/hejiSlotIcon/chip_grade_" + hejiData.Quality + ".png", delegate(Sprite sprite)
		{
			_viewModel.MixtureSlotImage.sprite = sprite;
		});
		base.DoSubscribe();
	}

	private void updateIcon(GameObject obj, string url)
	{
		if (!(obj == null))
		{
			obj.GetComponent<Image>();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
