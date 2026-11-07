using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioEvolution;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BioEvolution;

[GameUiTest]
public class BioEvolutionHuManGrowUpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetPlayerContext, ISetMessageContext
{
	private BioEvolutionHuManGrowUpViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioEvolutionHuManGrowUpViewModel();
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
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetLevel, SetLevel);
		_viewModel.LevelFillamount1 = 0f;
	}

	private void SetLevel(int arg1, int arg2)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && PlayerCareerConstantUtility.IsHumanity(myPlayerEntity.GetCareer()))
		{
			_viewModel.BasicsString = StringCache.IntToString(_messageContext.bioMessageData.GlobalAttack);
			_viewModel.UnityString = StringCache.IntToString(_messageContext.bioMessageData.FrientAttack);
			_viewModel.EliteString = StringCache.IntToString(_messageContext.bioMessageData.EliteAttack);
			_viewModel.LevelFillamount1 = (float)arg1 / 20f;
		}
	}

	private int GetLevel(int arg1)
	{
		return _messageContext.bioMessageData.MoralLv;
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
		if (!_messageContext.bioMessageData.MoralShow)
		{
			return false;
		}
		return true;
	}
}
