using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3VariantGrowUpModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetPlayerContext
{
	private Biochemical3VariantGrowUpViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new Biochemical3VariantGrowUpViewModel();
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
		SimpleNotify.Add(GetAddHp, SetAddHp);
	}

	private void SetAddHp(int arg1, int arg2)
	{
		_viewModel.AddHpString = arg1.ToString();
	}

	private int GetAddHp(int arg1)
	{
		return _gameRuleContext.bioNewVariantsGrowUp.LvUpHp;
	}

	private void SetLevel(int arg1, int arg2)
	{
		_viewModel.LevelString = arg1.ToString();
	}

	private int GetLevel(int arg1)
	{
		return _gameRuleContext.bioNewVariantsGrowUp.Lv;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.ShowShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && !myPlayerEntity.IsDead() && PlayerCareerConstantUtility.IsDoun(_playerContext.myPlayerEntity.GetCareer()))
		{
			return true;
		}
		return false;
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
