using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3HumanityGrowUpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetPlayerContext
{
	private Biochemical3HumanityGrowUpViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

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
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical3HumanityGrowUpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetLevel, SetLevel);
		SimpleNotify.Add(GetAddAttack, SetAddAttack);
	}

	private void SetAddAttack(int arg1, int arg2)
	{
		_viewModel.AddAttackString = arg1.ToString();
	}

	private int GetAddAttack(int arg1)
	{
		return 100 + _gameRuleContext.humanityGrowUp.GrowUpLevel * 10;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.ShowShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return false;
		}
		if (myPlayerEntity.IsDead())
		{
			return false;
		}
		if (!PlayerCareerConstantUtility.IsHumanity(myPlayerEntity.GetCareer()))
		{
			return false;
		}
		if (_battleRoomContext.sectionTime.Passed < 15000)
		{
			return false;
		}
		return true;
	}

	private void SetLevel(int arg1, int arg2)
	{
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetLevelShow(i + 1, i < arg1);
		}
		_viewModel.HeroChangeShow = arg1 >= 10;
	}

	private int GetLevel(int arg1)
	{
		return _gameRuleContext.humanityGrowUp.GrowUpLevel;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
