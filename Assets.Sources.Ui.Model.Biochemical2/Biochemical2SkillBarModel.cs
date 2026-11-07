using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical2;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Biochemical2;

[GameUiTest]
public class Biochemical2SkillBarModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetBattleRoomContext
{
	private Biochemical2SkillBarViewModel _viewModel;

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical2SkillBarViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bio2SkillLvUpData_SkillCount, SetSkillCount, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPassiveSkillCount, SetPassiveSkillCount, null, initinvoke: true);
	}

	private bool GetVisible()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && !myPlayerEntity.IsDead())
		{
			return !_battleRoomContext.roomData.IsObserver;
		}
		return false;
	}

	private void SetVisible(bool ov, bool nv)
	{
		_viewModel.ShowShow = nv;
	}

	private void SetSkillCount(int ov, int nv)
	{
		if (nv > 0)
		{
			_viewModel.SkillItemShow = true;
			_viewModel.GainPointString = nv.ToString();
		}
		else
		{
			_viewModel.SkillItemShow = false;
		}
	}

	private float GetPercent()
	{
		if (UiIEventCondition.Get_bio2SkillLvUpData_LvUpExp() <= 0)
		{
			return 0f;
		}
		return (float)UiIEventCondition.Get_bio2SkillLvUpData_Exp() / (float)UiIEventCondition.Get_bio2SkillLvUpData_LvUpExp();
	}

	private void SetPercent(float ov, float nv)
	{
		_viewModel.ProgressFillamount = nv;
	}

	private int GetPassiveSkillCount()
	{
		if (!_playerContext.isMyPlayer)
		{
			return 0;
		}
		return _playerContext.myPlayerEntity.passiveSkillGroup.allPassiveSkills.Count;
	}

	private void SetPassiveSkillCount(int ov, int nv)
	{
		_viewModel.SkillPointString = nv.ToString();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
