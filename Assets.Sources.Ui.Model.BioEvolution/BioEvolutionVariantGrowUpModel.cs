using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioEvolution;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.BioEvolution;

[GameUiTest]
public class BioEvolutionVariantGrowUpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetPlayerContext, ISetMessageContext
{
	private BioEvolutionVariantGrowUpViewModel _viewModel;

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
		_viewModel = new BioEvolutionVariantGrowUpViewModel();
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
		NotifyManager.MakeTempNotify(GetLevel, SetLevel);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		_viewModel.LevelFillamount1 = 0f;
	}

	private void SetLevel(int arg1, int arg2)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return;
		}
		if (PlayerCareerConstantUtility.IsHumanity(myPlayerEntity.GetCareer()) || PlayerCareerConstantUtility.IsHero(myPlayerEntity.GetCareer()))
		{
			_viewModel.AngleString = StringCache.IntToString(0);
			_viewModel.HpString = StringCache.IntToString(0);
			_viewModel.JumpString = StringCache.IntToString(0);
			_viewModel.LevelFillamount1 = 0f;
			return;
		}
		if (PlayerCareerConstantUtility.IsEmpress(myPlayerEntity.GetCareer()))
		{
			_viewModel.AngleString = StringCache.IntToString(_messageContext.bioMessageData.AngleLv);
			_viewModel.HpString = StringCache.IntToString(_messageContext.bioMessageData.FrientAttack);
			_viewModel.JumpString = StringCache.IntToString(_messageContext.bioMessageData.EliteAttack);
		}
		else
		{
			_viewModel.AngleString = StringCache.IntToString(_messageContext.bioMessageData.AngleLv);
			_viewModel.HpString = StringCache.IntToString(_messageContext.bioMessageData.FrientAttack);
			_viewModel.JumpString = StringCache.IntToString(_messageContext.bioMessageData.EliteAttack);
		}
		_viewModel.LevelFillamount1 = (float)arg2 / 10f;
	}

	private int GetLevel()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && (PlayerCareerConstantUtility.IsHumanity(myPlayerEntity.GetCareer()) || PlayerCareerConstantUtility.IsHero(myPlayerEntity.GetCareer())))
		{
			return 0;
		}
		return _messageContext.bioMessageData.AngleLv;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private bool GetVisible()
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
		if (PlayerCareerConstantUtility.IsHumanity(myPlayerEntity.GetCareer()) || PlayerCareerConstantUtility.IsHero(myPlayerEntity.GetCareer()))
		{
			return false;
		}
		if (!_messageContext.bioMessageData.AngleShow)
		{
			return false;
		}
		return true;
	}
}
