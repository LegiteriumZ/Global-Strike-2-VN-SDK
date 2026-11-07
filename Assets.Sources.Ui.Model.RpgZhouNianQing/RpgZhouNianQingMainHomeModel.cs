using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgZhouNianQing;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.RpgZhouNianQing;

[GameUiTest]
public class RpgZhouNianQingMainHomeModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetSceneObjectContext
{
	private RpgZhouNianQingMainHomeViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private SceneObjectContext _sceneObjectContext;

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
		_viewModel = new RpgZhouNianQingMainHomeViewModel();
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
		SimpleNotify.Add(GetFlag, SetFlag);
		SimpleNotify.Add(GetHpProgress, SetHpProgress);
	}

	private void SetHpProgress(float arg1, int arg2)
	{
		_viewModel.ProgressFillamount = arg1;
		_viewModel.PercentString = (arg1 * 100f).ToString("F0");
	}

	private float GetHpProgress(int arg1)
	{
		SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.AttackId);
		if (entityWithEntityId != null && entityWithEntityId.hasPveTower)
		{
			if (entityWithEntityId.pveTower.Data.MaxHp <= 0)
			{
				return 0f;
			}
			return (float)entityWithEntityId.pveTower.Data.Hp / (float)entityWithEntityId.pveTower.Data.MaxHp;
		}
		return 0f;
	}

	private void SetFlag(int arg1, int arg2)
	{
		_viewModel.ShowShow = arg1 == 1;
	}

	private int GetFlag(int arg1)
	{
		SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(_gameRuleContext.hpProgressData.AttackId);
		if (entityWithEntityId != null && entityWithEntityId.hasPveTower)
		{
			return entityWithEntityId.pveTower.Data.Flag;
		}
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetSceneObjectContext(SceneObjectContext context)
	{
		_sceneObjectContext = context;
	}
}
