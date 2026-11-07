using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class TrickDaggerSkillModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetPlayerBagContext, ISetMessageContext
{
	private TrickDaggerSkillViewModel _viewModel;

	private WeaponContext _weaponContext;

	private PlayerBagContext _bagContext;

	private MessageContext _messageContext;

	public static int COMPONENT1_EXIST = 2;

	public static int COMPONENT2_EXIST = 4;

	public static int COMPONENT3_EXIST = 8;

	public static int COMPONENT4_EXIST = 16;

	public static float POWER_1 = 10000f;

	public static float POWER_2 = 10000f;

	public static float POWER_3 = 15000f;

	public static float POWER_4 = 20000f;

	public static float POWER_5 = 20000f;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerBagContext(PlayerBagContext context)
	{
		_bagContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new TrickDaggerSkillViewModel();
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
		if (RuleUtilty.IsKnife(UiIEventCondition.Get_uiRoomData_RaceType()) && UiIEventCondition.Get_weaponState_EffectLevel() > COMPONENT1_EXIST)
		{
			_viewModel.SkillbgShow = true;
		}
		else
		{
			_viewModel.SkillbgShow = false;
		}
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunPower, SetDunPower, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(Get_SimpleWeapon, Set_SimpleWeapon, null, initinvoke: true);
	}

	private string Get_SimpleWeapon()
	{
		if (_messageContext.hasSimpleWeapon && _messageContext.simpleWeapon.stringData != null)
		{
			return _messageContext.simpleWeapon.stringData[0];
		}
		return "";
	}

	private void Set_SimpleWeapon(string arg1, string arg2)
	{
		if (arg2 != "")
		{
			_viewModel.SkillbgShow = true;
			_viewModel.WeaponNameString = LanguageUtils.GetWeaponCnName(arg2);
		}
		else
		{
			_viewModel.SkillbgShow = false;
		}
	}

	private void SetDunPower(float arg1, float arg2)
	{
		_viewModel.PowerString = arg2.ToString();
	}

	private float GetDunPower()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		return currentWeaponEntity.power.Power2;
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		if (arg2 == 0f)
		{
			_viewModel.RightBottomShow = false;
			return;
		}
		_viewModel.RightBottomShow = true;
		_viewModel.DunProgressFillamount = arg2;
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		return currentWeaponEntity.power.Power2 switch
		{
			1 => (float)currentWeaponEntity.power.Power / POWER_1, 
			2 => (float)currentWeaponEntity.power.Power / POWER_2, 
			3 => (float)currentWeaponEntity.power.Power / POWER_3, 
			4 => (float)currentWeaponEntity.power.Power / POWER_4, 
			5 => (float)currentWeaponEntity.power.Power / POWER_5, 
			_ => (float)currentWeaponEntity.power.Power / POWER_1, 
		};
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
