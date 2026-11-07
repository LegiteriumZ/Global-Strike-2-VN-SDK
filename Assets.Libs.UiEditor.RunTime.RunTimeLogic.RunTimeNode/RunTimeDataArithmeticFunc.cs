using System;
using Assets.SSJJUIEditor.RunTime.Binding;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJUIEditor.RunTime;

namespace Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;

public class RunTimeDataArithmeticFunc : SingletonInstance<RunTimeDataArithmeticFunc>, IRunTimeDataArithmeticFunc
{
	public void Init(string method, string inputs, RunTimeDataArithmeticFuncNamager runTimeDataArithmeticFuncNamager)
	{
		if (method.Trim().Equals("GetConstTrue", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetConstTrue;
		}
		else if (method.Trim().Equals("GetConstNo", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetConstNo;
		}
		else if (method.Trim().Equals("GetConstData", StringComparison.CurrentCultureIgnoreCase))
		{
			float a19 = float.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetFloatValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetConstData(a19);
		}
		else if (method.Trim().Equals("GetConstStr", StringComparison.CurrentCultureIgnoreCase))
		{
			string a18 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetStringValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetConstStr(a18);
		}
		else if (method.Trim().Equals("GetFrameImageStr", StringComparison.CurrentCultureIgnoreCase))
		{
			string a17 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetStringValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetFrameImageStr(a17);
		}
		else if (method.Trim().Equals("GetClientTime", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetClientTime;
		}
		else if (method.Trim().Equals("GetServerTime", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetServerTime;
		}
		else if (method.Trim().Equals("GetUiProgress", StringComparison.CurrentCultureIgnoreCase))
		{
			string a16 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetFloatValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetUiProgress(a16);
		}
		else if (method.Trim().Equals("GetUiPositionX", StringComparison.CurrentCultureIgnoreCase))
		{
			string a15 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetFloatValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetUiPositionX(a15);
		}
		else if (method.Trim().Equals("GetUiPositionY", StringComparison.CurrentCultureIgnoreCase))
		{
			string a14 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetFloatValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetUiPositionY(a14);
		}
		else if (method.Trim().Equals("GetUiPositionZ", StringComparison.CurrentCultureIgnoreCase))
		{
			string a13 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetFloatValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetUiPositionZ(a13);
		}
		else if (method.Trim().Equals("GetMpData", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetMpData;
		}
		else if (method.Trim().Equals("GetMaxMpData", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.GetMaxMpData;
		}
		else if (method.Trim().Equals("GetKill", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetKill;
		}
		else if (method.Trim().Equals("GetPower", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetPower;
		}
		else if (method.Trim().Equals("GetMaxPower", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetMaxPower;
		}
		else if (method.Trim().Equals("GetMaxPower2", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetMaxPower2;
		}
		else if (method.Trim().Equals("GetPower2", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetPower2;
		}
		else if (method.Trim().Equals("GetClip", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetClip;
		}
		else if (method.Trim().Equals("GetClip2", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetClip2;
		}
		else if (method.Trim().Equals("GetCarryClip", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetCarryClip;
		}
		else if (method.Trim().Equals("GetCarryClip2", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetCarryClip2;
		}
		else if (method.Trim().Equals("EffectLevel", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.EffectLevel;
		}
		else if (method.Trim().Equals("GetRpgMaxPower", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetRpgMaxPower;
		}
		else if (method.Trim().Equals("GetWeaponTimer1", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetLongValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetWeaponTimer1;
		}
		else if (method.Trim().Equals("GetNextSkillTimer", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetLongValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetNextSkillTimer;
		}
		else if (method.Trim().Equals("GetWeaponFlag", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetWeaponFlag;
		}
		else if (method.Trim().Equals("GetIcon1", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetIcon1;
		}
		else if (method.Trim().Equals("GetMaxIcon1", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetMaxIcon1;
		}
		else if (method.Trim().Equals("GetIcon2", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetIcon2;
		}
		else if (method.Trim().Equals("GetMaxIcon2", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetMaxIcon2;
		}
		else if (method.Trim().Equals("GetNextAttackTimer", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetNextAttackTimer;
		}
		else if (method.Trim().Equals("GetNextSecondaryAttackTimer", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetNextSecondaryAttackTimer;
		}
		else if (method.Trim().Equals("GetWeaponCd", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetWeaponCd;
		}
		else if (method.Trim().Equals("GetWeaponFov", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetWeaponFov;
		}
		else if (method.Trim().Equals("ViewAnimId", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.ViewAnimId;
		}
		else if (method.Trim().Equals("ViewAnimCurrentTime", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.ViewAnimCurrentTime;
		}
		else if (method.Trim().Equals("ViewAnimTime", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.ViewAnimTime;
		}
		else if (method.Trim().Equals("TorsoAnimId", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.TorsoAnimId;
		}
		else if (method.Trim().Equals("LegAnimId", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.LegAnimId;
		}
		else if (method.Trim().Equals("TorsoAnimCurrentTime", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.TorsoAnimCurrentTime;
		}
		else if (method.Trim().Equals("LegAnimCurrentTime", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.LegAnimCurrentTime;
		}
		else if (method.Trim().Equals("GetWeaponState", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.GetWeaponState;
		}
		else if (method.Trim().Equals("GetWeaponOwnerId", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.GetWeaponOwnerId;
		}
		else if (method.Trim().Equals("GetPlayerId", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.GetPlayerId;
		}
		else if (method.Trim().Equals("GetPlayerHp", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetIntValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.GetPlayerHp;
		}
		else if (method.Trim().Equals("HasStatus", StringComparison.CurrentCultureIgnoreCase))
		{
			int a12 = int.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.HasStatus(a12);
		}
		else if (method.Trim().Equals("getStatusNum", StringComparison.CurrentCultureIgnoreCase))
		{
			int a11 = int.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetIntValue = () => BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.getStatusNum(a11);
		}
		else if (method.Trim().Equals("getStatusScale", StringComparison.CurrentCultureIgnoreCase))
		{
			int a10 = int.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetFloatValue = () => BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.getStatusScale(a10);
		}
		else if (method.Trim().Equals("HasPlayerStateFlag", StringComparison.CurrentCultureIgnoreCase))
		{
			int a9 = int.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.HasPlayerStateFlag(a9);
		}
		else if (method.Trim().Equals("IsPve", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsPve;
		}
		else if (method.Trim().Equals("IsGeneralPve", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsGeneralPve;
		}
		else if (method.Trim().Equals("IsOldPve", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsOldPve;
		}
		else if (method.Trim().Equals("IsRpg", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsRpg;
		}
		else if (method.Trim().Equals("IsBio", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsBio;
		}
		else if (method.Trim().Equals("IsBigHead", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsBigHead;
		}
		else if (method.Trim().Equals("IsCompetitive", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsCompetitive;
		}
		else if (method.Trim().Equals("IsBlade", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsBlade;
		}
		else if (method.Trim().Equals("IsKnife", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsKnife;
		}
		else if (method.Trim().Equals("IsNotExplodeOrTeam", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsNotExplodeOrTeam;
		}
		else if (method.Trim().Equals("IsExplode", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsExplode;
		}
		else if (method.Trim().Equals("IsGroup", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsGroup;
		}
		else if (method.Trim().Equals("IsRule", StringComparison.CurrentCultureIgnoreCase))
		{
			string a8 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsRule(a8);
		}
		else if (method.Trim().Equals("IsNotRule", StringComparison.CurrentCultureIgnoreCase))
		{
			string a7 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.contextDataProvider.IsNotRule(a7);
		}
		else if (method.Trim().Equals("IsHoldWeapon", StringComparison.CurrentCultureIgnoreCase))
		{
			string a6 = inputs.Split('|')[0];
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.weaponDataProvider.IsHoldWeapon(a6);
		}
		else if (method.Trim().Equals("GetSpecalMode", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.GetSpecalMode;
		}
		else if (method.Trim().Equals("IsRightFiring", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.IsRightFiring;
		}
		else if (method.Trim().Equals("IsLeftFiring", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.IsLeftFiring;
		}
		else if (method.Trim().Equals("GetEventParticle", StringComparison.CurrentCultureIgnoreCase))
		{
			int a5 = int.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.GetEventParticle(a5);
		}
		else if (method.Trim().Equals("GetSameLevelEventParticle", StringComparison.CurrentCultureIgnoreCase))
		{
			int a4 = int.Parse(inputs.Split('|')[0]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.playerDataProvider.GetSameLevelEventParticle(a4);
		}
		else if (method.Trim().Equals("KeyCodeInput", StringComparison.CurrentCultureIgnoreCase))
		{
			int a3 = int.Parse(inputs.Split('|')[0]);
			int b3 = int.Parse(inputs.Split('|')[1]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.KeyCodeInput(a3, b3);
		}
		else if (method.Trim().Equals("KeyCodeStayInput", StringComparison.CurrentCultureIgnoreCase))
		{
			int a2 = int.Parse(inputs.Split('|')[0]);
			int b2 = int.Parse(inputs.Split('|')[1]);
			int c = int.Parse(inputs.Split('|')[2]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.KeyCodeStayInput(a2, b2, c);
		}
		else if (method.Trim().Equals("KeyCodeExit", StringComparison.CurrentCultureIgnoreCase))
		{
			int a = int.Parse(inputs.Split('|')[0]);
			int b = int.Parse(inputs.Split('|')[1]);
			runTimeDataArithmeticFuncNamager.GetBoolValue = () => BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.KeyCodeExit(a, b);
		}
		else if (method.Trim().Equals("UiLeftClickListener", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValueIndex = BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.UiLeftClickListener;
		}
		else if (method.Trim().Equals("UiRightClickListener", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValueIndex = BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.UiRightClickListener;
		}
		else if (method.Trim().Equals("UiMoveInListener", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.UiMoveInListener;
		}
		else if (method.Trim().Equals("UiMoveOutListener", StringComparison.CurrentCultureIgnoreCase))
		{
			runTimeDataArithmeticFuncNamager.GetBoolValue = BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.UiMoveOutListener;
		}
		else if (!AssignModeDelegate(this, method.Trim(), runTimeDataArithmeticFuncNamager) && !AssignWeaponDelegate(this, method.Trim(), runTimeDataArithmeticFuncNamager))
		{
			this.LogError("NoFoundMethod " + method);
		}
	}

	public bool AssignWeaponDelegate(RunTimeDataArithmeticFunc func, string method, RunTimeDataArithmeticFuncNamager runTimeDataArithmeticFuncNamager)
	{
		for (int i = 0; i < BattleSingletonInstance<DataProviderManager>.Instance.WeaponExtraDefineProviders.Count; i++)
		{
			IWeaponExtraDefineProvider weaponExtraDefineProvider = BattleSingletonInstance<DataProviderManager>.Instance.WeaponExtraDefineProviders[i];
			if (!weaponExtraDefineProvider.KeyInfo.Equals(BattleSingletonInstance<DataProviderManager>.Instance.GetWeaponName(), StringComparison.CurrentCultureIgnoreCase))
			{
				continue;
			}
			if (weaponExtraDefineProvider is break_star_machinegun_legend1_WeaponExtraDefineProvider)
			{
				break_star_machinegun_legend1_WeaponExtraDefineProvider break_star_machinegun_legend1_WeaponExtraDefineProvider = weaponExtraDefineProvider as break_star_machinegun_legend1_WeaponExtraDefineProvider;
				if (method.Equals("isShow"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = break_star_machinegun_legend1_WeaponExtraDefineProvider.isShow;
				}
				if (method.Equals("showImage"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = break_star_machinegun_legend1_WeaponExtraDefineProvider.showImage;
				}
				return true;
			}
			if (weaponExtraDefineProvider is break_star_machinegun_legend2_WeaponExtraDefineProvider)
			{
				break_star_machinegun_legend2_WeaponExtraDefineProvider break_star_machinegun_legend2_WeaponExtraDefineProvider = weaponExtraDefineProvider as break_star_machinegun_legend2_WeaponExtraDefineProvider;
				if (method.Equals("showImage"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = break_star_machinegun_legend2_WeaponExtraDefineProvider.showImage;
				}
				if (method.Equals("isShow"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = break_star_machinegun_legend2_WeaponExtraDefineProvider.isShow;
				}
				return true;
			}
			if (weaponExtraDefineProvider is carrot_one_WeaponExtraDefineProvider)
			{
				carrot_one_WeaponExtraDefineProvider carrot_one_WeaponExtraDefineProvider = weaponExtraDefineProvider as carrot_one_WeaponExtraDefineProvider;
				if (method.Equals("getProgress"))
				{
					runTimeDataArithmeticFuncNamager.GetFloatValue = carrot_one_WeaponExtraDefineProvider.getProgress;
				}
				if (method.Equals("getProgress1"))
				{
					runTimeDataArithmeticFuncNamager.GetFloatValue = carrot_one_WeaponExtraDefineProvider.getProgress1;
				}
				if (method.Equals("showImage"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = carrot_one_WeaponExtraDefineProvider.showImage;
				}
				return true;
			}
			if (weaponExtraDefineProvider is feather_bow_WeaponExtraDefineProvider)
			{
				feather_bow_WeaponExtraDefineProvider feather_bow_WeaponExtraDefineProvider = weaponExtraDefineProvider as feather_bow_WeaponExtraDefineProvider;
				if (method.Equals("getProgress"))
				{
					runTimeDataArithmeticFuncNamager.GetFloatValue = feather_bow_WeaponExtraDefineProvider.getProgress;
				}
				if (method.Equals("isShow"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = feather_bow_WeaponExtraDefineProvider.isShow;
				}
				return true;
			}
			if (weaponExtraDefineProvider is gaia_sniper_WeaponExtraDefineProvider)
			{
				gaia_sniper_WeaponExtraDefineProvider gaia_sniper_WeaponExtraDefineProvider = weaponExtraDefineProvider as gaia_sniper_WeaponExtraDefineProvider;
				if (method.Equals("updateSkillEShow"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = gaia_sniper_WeaponExtraDefineProvider.updateSkillEShow;
				}
				return true;
			}
			if (weaponExtraDefineProvider is inflatable_hammer_WeaponExtraDefineProvider)
			{
				inflatable_hammer_WeaponExtraDefineProvider inflatable_hammer_WeaponExtraDefineProvider = weaponExtraDefineProvider as inflatable_hammer_WeaponExtraDefineProvider;
				if (method.Equals("getInflatableHammerScale"))
				{
					runTimeDataArithmeticFuncNamager.GetFloatValue = inflatable_hammer_WeaponExtraDefineProvider.getInflatableHammerScale;
				}
				return true;
			}
			if (weaponExtraDefineProvider is jump_hammer_WeaponExtraDefineProvider)
			{
				jump_hammer_WeaponExtraDefineProvider jump_hammer_WeaponExtraDefineProvider = weaponExtraDefineProvider as jump_hammer_WeaponExtraDefineProvider;
				if (method.Equals("isShow"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = jump_hammer_WeaponExtraDefineProvider.isShow;
				}
				if (method.Equals("showImage"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = jump_hammer_WeaponExtraDefineProvider.showImage;
				}
				return true;
			}
			if (weaponExtraDefineProvider is maroon_WeaponExtraDefineProvider)
			{
				maroon_WeaponExtraDefineProvider maroon_WeaponExtraDefineProvider = weaponExtraDefineProvider as maroon_WeaponExtraDefineProvider;
				if (method.Equals("updateImgVisible"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = maroon_WeaponExtraDefineProvider.updateImgVisible;
				}
				if (method.Equals("updateFlashImg"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = maroon_WeaponExtraDefineProvider.updateFlashImg;
				}
				return true;
			}
			if (weaponExtraDefineProvider is rainbow_pistol_WeaponExtraDefineProvider)
			{
				rainbow_pistol_WeaponExtraDefineProvider rainbow_pistol_WeaponExtraDefineProvider = weaponExtraDefineProvider as rainbow_pistol_WeaponExtraDefineProvider;
				if (method.Equals("updateAutoHitUrl"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = rainbow_pistol_WeaponExtraDefineProvider.updateAutoHitUrl;
				}
				return true;
			}
			if (weaponExtraDefineProvider is rpk_domination_WeaponExtraDefineProvider)
			{
				rpk_domination_WeaponExtraDefineProvider rpk_domination_WeaponExtraDefineProvider = weaponExtraDefineProvider as rpk_domination_WeaponExtraDefineProvider;
				if (method.Equals("updateSkillENum"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = rpk_domination_WeaponExtraDefineProvider.updateSkillENum;
				}
				if (method.Equals("updateLeft0Num"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = rpk_domination_WeaponExtraDefineProvider.updateLeft0Num;
				}
				if (method.Equals("updateLeft1Num"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = rpk_domination_WeaponExtraDefineProvider.updateLeft1Num;
				}
				if (method.Equals("updateRight0Num"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = rpk_domination_WeaponExtraDefineProvider.updateRight0Num;
				}
				if (method.Equals("updateRight1Num"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = rpk_domination_WeaponExtraDefineProvider.updateRight1Num;
				}
				return true;
			}
			if (weaponExtraDefineProvider is spirits_sword1_WeaponExtraDefineProvider)
			{
				spirits_sword1_WeaponExtraDefineProvider spirits_sword1_WeaponExtraDefineProvider = weaponExtraDefineProvider as spirits_sword1_WeaponExtraDefineProvider;
				if (method.Equals("updateImgVisible"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = spirits_sword1_WeaponExtraDefineProvider.updateImgVisible;
				}
				if (method.Equals("updateFlashImg"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = spirits_sword1_WeaponExtraDefineProvider.updateFlashImg;
				}
				return true;
			}
			if (weaponExtraDefineProvider is spirits_sword2_WeaponExtraDefineProvider)
			{
				spirits_sword2_WeaponExtraDefineProvider spirits_sword2_WeaponExtraDefineProvider = weaponExtraDefineProvider as spirits_sword2_WeaponExtraDefineProvider;
				if (method.Equals("updateImgVisible"))
				{
					runTimeDataArithmeticFuncNamager.GetBoolValue = spirits_sword2_WeaponExtraDefineProvider.updateImgVisible;
				}
				if (method.Equals("updateFlashImg"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = spirits_sword2_WeaponExtraDefineProvider.updateFlashImg;
				}
				return true;
			}
			if (weaponExtraDefineProvider is yuetu_WeaponExtraDefineProvider)
			{
				yuetu_WeaponExtraDefineProvider yuetu_WeaponExtraDefineProvider = weaponExtraDefineProvider as yuetu_WeaponExtraDefineProvider;
				if (method.Equals("updateCountProgress"))
				{
					runTimeDataArithmeticFuncNamager.GetFloatValue = yuetu_WeaponExtraDefineProvider.updateCountProgress;
				}
				if (method.Equals("updateTimeProgress"))
				{
					runTimeDataArithmeticFuncNamager.GetFloatValue = yuetu_WeaponExtraDefineProvider.updateTimeProgress;
				}
				if (method.Equals("updateTxtCount"))
				{
					runTimeDataArithmeticFuncNamager.GetStringValue = yuetu_WeaponExtraDefineProvider.updateTxtCount;
				}
				return true;
			}
		}
		return false;
	}

	public bool AssignModeDelegate(RunTimeDataArithmeticFunc func, string method, RunTimeDataArithmeticFuncNamager runTimeDataArithmeticFuncNamager)
	{
		for (int i = 0; i < BattleSingletonInstance<DataProviderManager>.Instance.ModeProviders.Count; i++)
		{
			IModeExtraDataProvider modeExtraDataProvider = BattleSingletonInstance<DataProviderManager>.Instance.ModeProviders[i];
			if (!modeExtraDataProvider.KeyInfo.Equals(BattleSingletonInstance<DataProviderManager>.Instance.GetAssetInfo().BundleName.Info, StringComparison.CurrentCultureIgnoreCase))
			{
				continue;
			}
			foreach (IModuleProvider provider in (modeExtraDataProvider as AbstractModeExtraDataProvider).Providers)
			{
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelTopShowInfoProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IAllRoundSinglesModelTopShowInfoProvider allRoundSinglesModelTopShowInfoProvider = provider as IAllRoundSinglesModelTopShowInfoProvider;
					if (method.Equals("SetCampCTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampCTWinCount;
					}
					if (method.Equals("SetCampCTKillCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampCTKillCount;
					}
					if (method.Equals("GetModeUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = allRoundSinglesModelTopShowInfoProvider.GetModeUrl;
					}
					if (method.Equals("SetCampTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampTWinCount;
					}
					if (method.Equals("SetCampTKillCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampTKillCount;
					}
					if (method.Equals("SetCountDownMinuteTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCountDownMinuteTime;
					}
					if (method.Equals("SetCountDownSecondTimeGe"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCountDownSecondTimeGe;
					}
					if (method.Equals("SetCountDownSecondTimeShi"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCountDownSecondTimeShi;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelbattletipProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IAllRoundSinglesModelbattletipProvider allRoundSinglesModelbattletipProvider = provider as IAllRoundSinglesModelbattletipProvider;
					if (method.Equals("IsShowCountDown"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelbattletipProvider.IsShowCountDown;
					}
					if (method.Equals("SetCountDown"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelbattletipProvider.SetCountDown;
					}
					if (method.Equals("IsShowLoseHp"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelbattletipProvider.IsShowLoseHp;
					}
					if (method.Equals("IsShowWait"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelbattletipProvider.IsShowWait;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelSelectModeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IAllRoundSinglesModelSelectModeProvider allRoundSinglesModelSelectModeProvider = provider as IAllRoundSinglesModelSelectModeProvider;
					if (method.Equals("GetCountDown"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.GetCountDown;
					}
					if (method.Equals("IsSelect1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect1;
					}
					if (method.Equals("Select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select1;
					}
					if (method.Equals("IsWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsWin;
					}
					if (method.Equals("IsSelect4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect4;
					}
					if (method.Equals("Select4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select4;
					}
					if (method.Equals("IsSelect0"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect0;
					}
					if (method.Equals("Select0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select0;
					}
					if (method.Equals("IsSelect2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect2;
					}
					if (method.Equals("Select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select2;
					}
					if (method.Equals("Confirm"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Confirm;
					}
					if (method.Equals("IsSelect3"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect3;
					}
					if (method.Equals("Select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select3;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsShow;
					}
					if (method.Equals("IsSelect5"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect5;
					}
					if (method.Equals("Select5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select5;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelCurRoundResoultProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IAllRoundSinglesModelCurRoundResoultProvider allRoundSinglesModelCurRoundResoultProvider = provider as IAllRoundSinglesModelCurRoundResoultProvider;
					if (method.Equals("SetCampCTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelCurRoundResoultProvider.SetCampCTWinCount;
					}
					if (method.Equals("SetCampTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelCurRoundResoultProvider.SetCampTWinCount;
					}
					if (method.Equals("GetWinScoreUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = allRoundSinglesModelCurRoundResoultProvider.GetWinScoreUrl;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelCurRoundResoultProvider.IsShow;
					}
					if (method.Equals("IsWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelCurRoundResoultProvider.IsWin;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2BuffProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigHeadKnife2ModelBigHeadKnife2BuffProvider ibigHeadKnife2ModelBigHeadKnife2BuffProvider = provider as IbigHeadKnife2ModelBigHeadKnife2BuffProvider;
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadKnife2ModelBigHeadKnife2BuffProvider.SetProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider ibigHeadKnife2ModelBigHeadKnife2SkillMessageProvider = provider as IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider;
					if (method.Equals("tipsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadKnife2ModelBigHeadKnife2SkillMessageProvider.tipsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider = provider as IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider;
					if (method.Equals("spriteShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.spriteShow;
					}
					if (method.Equals("changeSpritePic"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.changeSpritePic;
					}
					if (method.Equals("setMaskPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.setMaskPercent;
					}
					if (method.Equals("cdShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.cdShow;
					}
					if (method.Equals("updateCd"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.updateCd;
					}
					if (method.Equals("updateSkillPower"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.updateSkillPower;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2WeaponProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigHeadKnife2ModelBigHeadKnife2WeaponProvider ibigHeadKnife2ModelBigHeadKnife2WeaponProvider = provider as IbigHeadKnife2ModelBigHeadKnife2WeaponProvider;
					if (method.Equals("SetCountTime"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigHeadKnife2ModelBigHeadKnife2WeaponProvider.SetCountTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigheadModelshadowDemonSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigheadModelshadowDemonSkillProvider ibigheadModelshadowDemonSkillProvider = provider as IbigheadModelshadowDemonSkillProvider;
					if (method.Equals("isHasSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isHasSkill;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigheadModelshadowDemonSkillProvider.isShow;
					}
					if (method.Equals("isShowEffect"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isShowEffect;
					}
					if (method.Equals("getEffectUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigheadModelshadowDemonSkillProvider.getEffectUrl;
					}
					if (method.Equals("isShowMask"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isShowMask;
					}
					if (method.Equals("getMaskProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibigheadModelshadowDemonSkillProvider.getMaskProgress;
					}
					if (method.Equals("isShowTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isShowTime;
					}
					if (method.Equals("getTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibigheadModelshadowDemonSkillProvider.getTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigheadModelHeroSelectProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigheadModelHeroSelectProvider ibigheadModelHeroSelectProvider = provider as IbigheadModelHeroSelectProvider;
					if (method.Equals("NoHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSelectProvider.NoHero;
					}
					if (method.Equals("SetHero"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigheadModelHeroSelectProvider.SetHero;
					}
					if (method.Equals("SeleHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSelectProvider.SeleHero;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigheadModelHeroSelectProvider.IsShow;
					}
					if (method.Equals("Select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.Select1;
					}
					if (method.Equals("Select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.Select2;
					}
					if (method.Equals("Select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.Select3;
					}
					if (method.Equals("HideUI"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.HideUI;
					}
					if (method.Equals("GetTimeout"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigheadModelHeroSelectProvider.GetTimeout;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigheadModelHeroSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigheadModelHeroSkillProvider ibigheadModelHeroSkillProvider = provider as IbigheadModelHeroSkillProvider;
					if (method.Equals("IsHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigheadModelHeroSkillProvider.IsHero;
					}
					if (method.Equals("Exists"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSkillProvider.Exists;
					}
					if (method.Equals("GetSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSkillProvider.GetSkill;
					}
					if (method.Equals("SetSkillIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigheadModelHeroSkillProvider.SetSkillIcon;
					}
					if (method.Equals("GetSkillTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibigheadModelHeroSkillProvider.GetSkillTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadP3ModelBigHeadP3SkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbigHeadP3ModelBigHeadP3SkillProvider ibigHeadP3ModelBigHeadP3SkillProvider = provider as IbigHeadP3ModelBigHeadP3SkillProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigHeadP3ModelBigHeadP3SkillProvider.changeImage;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadP3ModelBigHeadP3SkillProvider.isShow;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadP3ModelBigHeadP3SkillProvider.setProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider ibioEvolutionChallengeModelbioEvolutionChallengeMessageProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioEvolutionChallengeModelbioEvolutionChallengeMessageProvider.isShowMessage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider ibioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider = provider as IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider;
					if (method.Equals("getAddLevel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider.getAddLevel;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider ibioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider;
					if (method.Equals("getAddLevel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider.getAddLevel;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.isShow;
					}
					if (method.Equals("isShowDeathArua"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.isShowDeathArua;
					}
					if (method.Equals("isShowPandoraArua"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.isShowPandoraArua;
					}
					if (method.Equals("getNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.getNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.isShow;
					}
					if (method.Equals("getSkillTypeFUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getSkillTypeFUrl;
					}
					if (method.Equals("isBackShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.isBackShow;
					}
					if (method.Equals("getSkillTypeFBackUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getSkillTypeFBackUrl;
					}
					if (method.Equals("getSkillTypeNoKeyUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getSkillTypeNoKeyUrl;
					}
					if (method.Equals("getWaitProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getWaitProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isShow;
					}
					if (method.Equals("isBackShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isBackShow;
					}
					if (method.Equals("getSkillTypeFBackUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getSkillTypeFBackUrl;
					}
					if (method.Equals("isShowSkillTypeF"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isShowSkillTypeF;
					}
					if (method.Equals("getSkillTypeFUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getSkillTypeFUrl;
					}
					if (method.Equals("isShowSkillTypeNoKey"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isShowSkillTypeNoKey;
					}
					if (method.Equals("getSkillTypeNoKeyUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getSkillTypeNoKeyUrl;
					}
					if (method.Equals("getWaitProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getWaitProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider;
					if (method.Equals("isSelect"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.isSelect;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.isShow;
					}
					if (method.Equals("select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.select1;
					}
					if (method.Equals("select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.select2;
					}
					if (method.Equals("select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.select3;
					}
					if (method.Equals("getTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.getTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionModelBioEvolutionDamageBufferProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioEvolutionModelBioEvolutionDamageBufferProvider ibioEvolutionModelBioEvolutionDamageBufferProvider = provider as IbioEvolutionModelBioEvolutionDamageBufferProvider;
					if (method.Equals("getBufferUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionModelBioEvolutionDamageBufferProvider.getBufferUrl;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionModelBioEvolutionDamageBufferProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelshadowDemonSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioModelshadowDemonSkillProvider ibioModelshadowDemonSkillProvider = provider as IbioModelshadowDemonSkillProvider;
					if (method.Equals("isHasSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isHasSkill;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelshadowDemonSkillProvider.isShow;
					}
					if (method.Equals("isShowEffect"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isShowEffect;
					}
					if (method.Equals("getEffectUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioModelshadowDemonSkillProvider.getEffectUrl;
					}
					if (method.Equals("isShowMask"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isShowMask;
					}
					if (method.Equals("getMaskProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioModelshadowDemonSkillProvider.getMaskProgress;
					}
					if (method.Equals("isShowTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isShowTime;
					}
					if (method.Equals("getTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioModelshadowDemonSkillProvider.getTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelHeroSelectProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioModelHeroSelectProvider ibioModelHeroSelectProvider = provider as IbioModelHeroSelectProvider;
					if (method.Equals("NoHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSelectProvider.NoHero;
					}
					if (method.Equals("SetHero"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioModelHeroSelectProvider.SetHero;
					}
					if (method.Equals("SeleHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSelectProvider.SeleHero;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelHeroSelectProvider.IsShow;
					}
					if (method.Equals("Select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.Select1;
					}
					if (method.Equals("Select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.Select2;
					}
					if (method.Equals("Select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.Select3;
					}
					if (method.Equals("HideUI"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.HideUI;
					}
					if (method.Equals("GetTimeout"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioModelHeroSelectProvider.GetTimeout;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelHeroSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioModelHeroSkillProvider ibioModelHeroSkillProvider = provider as IbioModelHeroSkillProvider;
					if (method.Equals("IsHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelHeroSkillProvider.IsHero;
					}
					if (method.Equals("Exists"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSkillProvider.Exists;
					}
					if (method.Equals("GetSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSkillProvider.GetSkill;
					}
					if (method.Equals("SetSkillIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioModelHeroSkillProvider.SetSkillIcon;
					}
					if (method.Equals("GetSkillTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioModelHeroSkillProvider.GetSkillTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelMaolinProgressProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioModelMaolinProgressProvider ibioModelMaolinProgressProvider = provider as IbioModelMaolinProgressProvider;
					if (method.Equals("getPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelMaolinProgressProvider.getPercent;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelMaolinProgressProvider.isShow;
					}
					if (method.Equals("isLightShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelMaolinProgressProvider.isLightShow;
					}
					if (method.Equals("getLightEffectAlpha"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelMaolinProgressProvider.getLightEffectAlpha;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseSelectPlayerUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioUnionBaseSelectPlayerUIProvider ibioUnionBaseSelectPlayerUIProvider = provider as IbioUnionBaseSelectPlayerUIProvider;
					if (method.Equals("checkHeadCanShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectPlayerUIProvider.checkHeadCanShowByIndex;
					}
					if (method.Equals("checKeyInputByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectPlayerUIProvider.checKeyInputByIndex;
					}
					if (method.Equals("updateHeadIconByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioUnionBaseSelectPlayerUIProvider.updateHeadIconByIndex;
					}
					if (method.Equals("inputHandleByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioUnionBaseSelectPlayerUIProvider.inputHandleByIndex;
					}
					if (method.Equals("checkLockShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectPlayerUIProvider.checkLockShowByIndex;
					}
					if (method.Equals("checkLeftArrowIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectPlayerUIProvider.checkLeftArrowIsShow;
					}
					if (method.Equals("leftArrowHandle"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectPlayerUIProvider.leftArrowHandle;
					}
					if (method.Equals("checkRightArrowIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectPlayerUIProvider.checkRightArrowIsShow;
					}
					if (method.Equals("rightArrowHandle"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectPlayerUIProvider.rightArrowHandle;
					}
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectPlayerUIProvider.checkRootShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseSelectTeamUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioUnionBaseSelectTeamUIProvider ibioUnionBaseSelectTeamUIProvider = provider as IbioUnionBaseSelectTeamUIProvider;
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectTeamUIProvider.checkRootShow;
					}
					if (method.Equals("clickHandleByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioUnionBaseSelectTeamUIProvider.clickHandleByIndex;
					}
					if (method.Equals("checkOverShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectTeamUIProvider.checkOverShow;
					}
					if (method.Equals("mouseOver0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOver0;
					}
					if (method.Equals("mouseOut0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOut0;
					}
					if (method.Equals("mouseOver1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOver1;
					}
					if (method.Equals("mouseOut1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOut1;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseSoulUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioUnionBaseSoulUIProvider ibioUnionBaseSoulUIProvider = provider as IbioUnionBaseSoulUIProvider;
					if (method.Equals("checkInViewtShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSoulUIProvider.checkInViewtShow;
					}
					if (method.Equals("checkOutViewtShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSoulUIProvider.checkOutViewtShow;
					}
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSoulUIProvider.checkRootShow;
					}
					if (method.Equals("updateTimeCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSoulUIProvider.updateTimeCount;
					}
					if (method.Equals("updateCareerImg"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioUnionBaseSoulUIProvider.updateCareerImg;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseWaitPlayerUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbioUnionBaseWaitPlayerUIProvider ibioUnionBaseWaitPlayerUIProvider = provider as IbioUnionBaseWaitPlayerUIProvider;
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseWaitPlayerUIProvider.checkRootShow;
					}
					if (method.Equals("updateWaitPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseWaitPlayerUIProvider.updateWaitPlayerCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelWaitPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelWaitPlayerProvider ibladefightModelWaitPlayerProvider = provider as IbladefightModelWaitPlayerProvider;
					if (method.Equals("getCurrentPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getCurrentPlayerCount;
					}
					if (method.Equals("isShowTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelWaitPlayerProvider.isShowTime;
					}
					if (method.Equals("getCurrentTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getCurrentTime;
					}
					if (method.Equals("getMaxPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getMaxPlayerCount;
					}
					if (method.Equals("getMaxTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getMaxTime;
					}
					if (method.Equals("isWaitGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelWaitPlayerProvider.isWaitGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelfogAreaTimeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelfogAreaTimeProvider ibladefightModelfogAreaTimeProvider = provider as IbladefightModelfogAreaTimeProvider;
					if (method.Equals("getMinute"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelfogAreaTimeProvider.getMinute;
					}
					if (method.Equals("getSecond"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelfogAreaTimeProvider.getSecond;
					}
					if (method.Equals("isGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelfogAreaTimeProvider.isGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelSurplusPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelSurplusPlayerProvider ibladefightModelSurplusPlayerProvider = provider as IbladefightModelSurplusPlayerProvider;
					if (method.Equals("getSurplusCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelSurplusPlayerProvider.getSurplusCount;
					}
					if (method.Equals("isGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelSurplusPlayerProvider.isGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelMessageProvider ibladefightModelMessageProvider = provider as IbladefightModelMessageProvider;
					if (method.Equals("isFogAreaRefresh"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isFogAreaRefresh;
					}
					if (method.Equals("isWaitRealStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isWaitRealStart;
					}
					if (method.Equals("getWaitRealStartTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelMessageProvider.getWaitRealStartTime;
					}
					if (method.Equals("isSafeAreaRefresh"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isSafeAreaRefresh;
					}
					if (method.Equals("isObserve"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isObserve;
					}
					if (method.Equals("isGetEnergyPack"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isGetEnergyPack;
					}
					if (method.Equals("isTargetGetEnergyPack"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isTargetGetEnergyPack;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelReliveProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelReliveProvider ibladefightModelReliveProvider = provider as IbladefightModelReliveProvider;
					if (method.Equals("isShowReliveCount1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelReliveProvider.isShowReliveCount1;
					}
					if (method.Equals("getReliveCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelReliveProvider.getReliveCount;
					}
					if (method.Equals("isGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelReliveProvider.isGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelReliveBagPickingProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelReliveBagPickingProvider ibladefightModelReliveBagPickingProvider = provider as IbladefightModelReliveBagPickingProvider;
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelReliveBagPickingProvider.getProgress;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelReliveBagPickingProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelGameOverProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladefightModelGameOverProvider ibladefightModelGameOverProvider = provider as IbladefightModelGameOverProvider;
					if (method.Equals("getDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getDamage;
					}
					if (method.Equals("getKillNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getKillNum;
					}
					if (method.Equals("isWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelGameOverProvider.isWin;
					}
					if (method.Equals("getRanking"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getRanking;
					}
					if (method.Equals("getReturnLobbyTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getReturnLobbyTime;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelGameOverProvider.isShow;
					}
					if (method.Equals("isReturnLobby"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelGameOverProvider.isReturnLobby;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladeStrongholdNewModelstateProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladeStrongholdNewModelstateProvider ibladeStrongholdNewModelstateProvider = provider as IbladeStrongholdNewModelstateProvider;
					if (method.Equals("showTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibladeStrongholdNewModelstateProvider.showTime;
					}
					if (method.Equals("showclock"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibladeStrongholdNewModelstateProvider.showclock;
					}
					if (method.Equals("updateTeamNum1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamNum1;
					}
					if (method.Equals("updateTeamNum2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamNum2;
					}
					if (method.Equals("updateCtScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateCtScore;
					}
					if (method.Equals("updateTeamProgress1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamProgress1;
					}
					if (method.Equals("updateTeamProgress2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamProgress2;
					}
					if (method.Equals("updateTScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTScore;
					}
					if (method.Equals("showhong"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelstateProvider.showhong;
					}
					if (method.Equals("getProgress1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.getProgress1;
					}
					if (method.Equals("showlan"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelstateProvider.showlan;
					}
					if (method.Equals("getProgress2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.getProgress2;
					}
					if (method.Equals("updateWinScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateWinScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladeStrongholdNewModelMessageUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IbladeStrongholdNewModelMessageUIProvider ibladeStrongholdNewModelMessageUIProvider = provider as IbladeStrongholdNewModelMessageUIProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibladeStrongholdNewModelMessageUIProvider.changeImage;
					}
					if (method.Equals("showOccup"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.showOccup;
					}
					if (method.Equals("showOccupProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelMessageUIProvider.showOccupProgress;
					}
					if (method.Equals("showVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.showVisible;
					}
					if (method.Equals("showTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.showTime;
					}
					if (method.Equals("IsshowNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.IsshowNum;
					}
					if (method.Equals("showNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelMessageUIProvider.showNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IBroadSwordModelPowerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IBroadSwordModelPowerProvider broadSwordModelPowerProvider = provider as IBroadSwordModelPowerProvider;
					if (method.Equals("IsLiuGuangShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelPowerProvider.IsLiuGuangShow;
					}
					if (method.Equals("GetLiuGuangPosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelPowerProvider.GetLiuGuangPosX;
					}
					if (method.Equals("IsBottomShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelPowerProvider.IsBottomShow;
					}
					if (method.Equals("GetPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelPowerProvider.GetPercent;
					}
					if (method.Equals("IsRedShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelPowerProvider.IsRedShow;
					}
					if (method.Equals("UpdateRedImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = broadSwordModelPowerProvider.UpdateRedImage;
					}
					if (method.Equals("UpdateRedPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelPowerProvider.UpdateRedPercent;
					}
					if (method.Equals("IsYellowShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = broadSwordModelPowerProvider.IsYellowShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IBroadSwordModelmessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IBroadSwordModelmessageProvider broadSwordModelmessageProvider = provider as IBroadSwordModelmessageProvider;
					if (method.Equals("IsEShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsEShow;
					}
					if (method.Equals("IsFinalComingShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsFinalComingShow;
					}
					if (method.Equals("IsLevelUpShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsLevelUpShow;
					}
					if (method.Equals("IsStrengthenShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsStrengthenShow;
					}
					if (method.Equals("IsFinalComingCalShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsFinalComingCalShow;
					}
					if (method.Equals("IsWaitPlayerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsWaitPlayerShow;
					}
					if (method.Equals("GetFinalComingTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelmessageProvider.GetFinalComingTime;
					}
					if (method.Equals("GetWaitPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelmessageProvider.GetWaitPlayerCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonSkatePressGuiProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonSkatePressGuiProvider icommonSkatePressGuiProvider = provider as IcommonSkatePressGuiProvider;
					if (method.Equals("getVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonSkatePressGuiProvider.getVisible;
					}
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonSkatePressGuiProvider.getProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonPlayerExpressionProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonPlayerExpressionProvider icommonPlayerExpressionProvider = provider as IcommonPlayerExpressionProvider;
					if (method.Equals("hasSelectItem1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem1;
					}
					if (method.Equals("getItem1Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem1Url;
					}
					if (method.Equals("selectItem1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem1;
					}
					if (method.Equals("mouseLeftClick"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.mouseLeftClick;
					}
					if (method.Equals("mouseRightClick"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.mouseRightClick;
					}
					if (method.Equals("hasSelectItem2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem2;
					}
					if (method.Equals("getItem2Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem2Url;
					}
					if (method.Equals("selectItem2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem2;
					}
					if (method.Equals("hasSelectItem3"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem3;
					}
					if (method.Equals("getItem3Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem3Url;
					}
					if (method.Equals("selectItem3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem3;
					}
					if (method.Equals("hasSelectItem4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem4;
					}
					if (method.Equals("getItem4Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem4Url;
					}
					if (method.Equals("selectItem4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem4;
					}
					if (method.Equals("hasSelectItem5"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem5;
					}
					if (method.Equals("getItem5Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem5Url;
					}
					if (method.Equals("selectItem5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem5;
					}
					if (method.Equals("hasTacticsSound"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasTacticsSound;
					}
					if (method.Equals("selectItem0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem0;
					}
					if (method.Equals("isItem1Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem1Selected;
					}
					if (method.Equals("isItem2Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem2Selected;
					}
					if (method.Equals("isItem3Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem3Selected;
					}
					if (method.Equals("isItem4Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem4Selected;
					}
					if (method.Equals("isItem5Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem5Selected;
					}
					if (method.Equals("getGUIVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.getGUIVisible;
					}
					if (method.Equals("hideGUI"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.hideGUI;
					}
					if (method.Equals("useItem1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem1;
					}
					if (method.Equals("useItem2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem2;
					}
					if (method.Equals("useItem3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem3;
					}
					if (method.Equals("useItem4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem4;
					}
					if (method.Equals("useItem5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem5;
					}
					if (method.Equals("useItem6"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem6;
					}
					if (method.Equals("useItem7"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem7;
					}
					if (method.Equals("useItem8"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem8;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonSelfUseExpressionProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonSelfUseExpressionProvider icommonSelfUseExpressionProvider = provider as IcommonSelfUseExpressionProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonSelfUseExpressionProvider.isShow;
					}
					if (method.Equals("getExpressionUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonSelfUseExpressionProvider.getExpressionUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonVideoHelpProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonVideoHelpProvider icommonVideoHelpProvider = provider as IcommonVideoHelpProvider;
					if (method.Equals("isCrimialSuspectDead"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoHelpProvider.isCrimialSuspectDead;
					}
					if (method.Equals("isCrimialSuspectOut"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoHelpProvider.isCrimialSuspectOut;
					}
					if (method.Equals("getCurrentSnapshotLength"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.getCurrentSnapshotLength;
					}
					if (method.Equals("selectSnapshotIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.selectSnapshotIndex;
					}
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.getProgress;
					}
					if (method.Equals("isVideo"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoHelpProvider.isVideo;
					}
					if (method.Equals("isSelectVideoSpeed"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = icommonVideoHelpProvider.isSelectVideoSpeed;
					}
					if (method.Equals("getStopOrContinue"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonVideoHelpProvider.getStopOrContinue;
					}
					if (method.Equals("getTotalSnapshotLength"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.getTotalSnapshotLength;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonOctopusPositionSetProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonOctopusPositionSetProvider icommonOctopusPositionSetProvider = provider as IcommonOctopusPositionSetProvider;
					if (method.Equals("setImageY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setImageY;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setProgress;
					}
					if (method.Equals("getVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonOctopusPositionSetProvider.getVisible;
					}
					if (method.Equals("setShowX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setShowX;
					}
					if (method.Equals("setShowY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setShowY;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonVideoMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonVideoMessageProvider icommonVideoMessageProvider = provider as IcommonVideoMessageProvider;
					if (method.Equals("isVideo"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoMessageProvider.isVideo;
					}
					if (method.Equals("isCrimialSuspectDead"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoMessageProvider.isCrimialSuspectDead;
					}
					if (method.Equals("isCrimialSuspectOut"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoMessageProvider.isCrimialSuspectOut;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonStateProgressProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonStateProgressProvider icommonStateProgressProvider = provider as IcommonStateProgressProvider;
					if (method.Equals("SetDes"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonStateProgressProvider.SetDes;
					}
					if (method.Equals("SetPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonStateProgressProvider.SetPlayerName;
					}
					if (method.Equals("GetProgresPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonStateProgressProvider.GetProgresPercent;
					}
					if (method.Equals("GetShinePos"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonStateProgressProvider.GetShinePos;
					}
					if (method.Equals("IsProgressShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonStateProgressProvider.IsProgressShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonChallengeAffixProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonChallengeAffixProvider icommonChallengeAffixProvider = provider as IcommonChallengeAffixProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonChallengeAffixProvider.changeImage;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonChallengeAffixProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonTipsMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonTipsMessageProvider icommonTipsMessageProvider = provider as IcommonTipsMessageProvider;
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonTipsMessageProvider.SetImage;
					}
					if (method.Equals("SetMessagePosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetMessagePosY;
					}
					if (method.Equals("SetYPos"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetYPos;
					}
					if (method.Equals("SetXPos"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetXPos;
					}
					if (method.Equals("SetNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetNumber;
					}
					if (method.Equals("IsShowNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonTipsMessageProvider.IsShowNumber;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonTipsMessageProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonPlayerInfoSkillMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonPlayerInfoSkillMessageProvider icommonPlayerInfoSkillMessageProvider = provider as IcommonPlayerInfoSkillMessageProvider;
					if (method.Equals("SetMessagePosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetMessagePosX;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoSkillMessageProvider.SetImage;
					}
					if (method.Equals("SetMessagePosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetMessagePosY;
					}
					if (method.Equals("SetPBackPosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBackPosX;
					}
					if (method.Equals("SetPBackImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoSkillMessageProvider.SetPBackImage;
					}
					if (method.Equals("SetPBackPosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBackPosY;
					}
					if (method.Equals("SetPBarPosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBarPosX;
					}
					if (method.Equals("SetPBarImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoSkillMessageProvider.SetPBarImage;
					}
					if (method.Equals("SetPBarPosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBarPosY;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetProgress;
					}
					if (method.Equals("IsProgressShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerInfoSkillMessageProvider.IsProgressShow;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerInfoSkillMessageProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonPlayerInfoMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonPlayerInfoMessageProvider icommonPlayerInfoMessageProvider = provider as IcommonPlayerInfoMessageProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerInfoMessageProvider.IsShow;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoMessageProvider.SetImage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonRandomKingTipProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonRandomKingTipProvider icommonRandomKingTipProvider = provider as IcommonRandomKingTipProvider;
					if (method.Equals("getVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = icommonRandomKingTipProvider.getVisible;
					}
					if (method.Equals("showString"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = icommonRandomKingTipProvider.showString;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonNonstopdanceSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonNonstopdanceSkillProvider icommonNonstopdanceSkillProvider = provider as IcommonNonstopdanceSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonNonstopdanceSkillProvider.isShow;
					}
					if (method.Equals("showImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = icommonNonstopdanceSkillProvider.showImage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonHypertechSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonHypertechSkillProvider icommonHypertechSkillProvider = provider as IcommonHypertechSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonHypertechSkillProvider.isShow;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonHypertechSkillProvider.setProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonGameUITipsProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonGameUITipsProvider icommonGameUITipsProvider = provider as IcommonGameUITipsProvider;
					if (method.Equals("ShowBackUI"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonGameUITipsProvider.ShowBackUI;
					}
					if (method.Equals("ShowProgressUI"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonGameUITipsProvider.ShowProgressUI;
					}
					if (method.Equals("ShowProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonGameUITipsProvider.ShowProgress;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonGameUITipsProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonbioReliveEProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonbioReliveEProvider icommonbioReliveEProvider = provider as IcommonbioReliveEProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonbioReliveEProvider.isShow;
					}
					if (method.Equals("showTip"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonbioReliveEProvider.showTip;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonDragonAuraSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonDragonAuraSkillProvider icommonDragonAuraSkillProvider = provider as IcommonDragonAuraSkillProvider;
					if (method.Equals("GetPercentage"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonDragonAuraSkillProvider.GetPercentage;
					}
					if (method.Equals("GetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonDragonAuraSkillProvider.GetProgress;
					}
					if (method.Equals("ShowUI"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonDragonAuraSkillProvider.ShowUI;
					}
					if (method.Equals("GetAlpha"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = icommonDragonAuraSkillProvider.GetAlpha;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonKickVoteUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IcommonKickVoteUIProvider icommonKickVoteUIProvider = provider as IcommonKickVoteUIProvider;
					if (method.Equals("GetAgree"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetAgree;
					}
					if (method.Equals("isResult"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonKickVoteUIProvider.isResult;
					}
					if (method.Equals("GetName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetName;
					}
					if (method.Equals("GetReason"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetReason;
					}
					if (method.Equals("GetRejest"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetRejest;
					}
					if (method.Equals("KickVoteShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonKickVoteUIProvider.KickVoteShow;
					}
					if (method.Equals("Agree"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonKickVoteUIProvider.Agree;
					}
					if (method.Equals("Disagree"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonKickVoteUIProvider.Disagree;
					}
					if (method.Equals("getTimerText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.getTimerText;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelTopScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelTopScoreBoardProvider competeKingModelTopScoreBoardProvider = provider as ICompeteKingModelTopScoreBoardProvider;
					if (method.Equals("SetTeamNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelTopScoreBoardProvider.SetTeamNumber;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelTopScoreBoardProvider.SetRoundTime;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = competeKingModelTopScoreBoardProvider.SetProgressBar;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelBottomScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelBottomScoreBoardProvider competeKingModelBottomScoreBoardProvider = provider as ICompeteKingModelBottomScoreBoardProvider;
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelBottomScoreBoardProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelRoundReviewProvider competeKingModelRoundReviewProvider = provider as ICompeteKingModelRoundReviewProvider;
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = competeKingModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetFlag"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelRoundReviewProvider.SetFlag;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = competeKingModelRoundReviewProvider.SetScore;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelRoundReviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelBagPreviewProvider competeKingModelBagPreviewProvider = provider as ICompeteKingModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelEndTimerProvider competeKingModelEndTimerProvider = provider as ICompeteKingModelEndTimerProvider;
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelEndTimerProvider.SetTime;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelEndTimerProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelRandomEffectProvider competeKingModelRandomEffectProvider = provider as ICompeteKingModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ICompeteKingModelStartTimerProvider competeKingModelStartTimerProvider = provider as ICompeteKingModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IDimensionalFissureModelKuangLuanProgressUiProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IDimensionalFissureModelKuangLuanProgressUiProvider dimensionalFissureModelKuangLuanProgressUiProvider = provider as IDimensionalFissureModelKuangLuanProgressUiProvider;
					if (method.Equals("SetDerangement"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = dimensionalFissureModelKuangLuanProgressUiProvider.SetDerangement;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IexplodewdModelExplodeWdGameOverProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IexplodewdModelExplodeWdGameOverProvider iexplodewdModelExplodeWdGameOverProvider = provider as IexplodewdModelExplodeWdGameOverProvider;
					if (method.Equals("isGameOver"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameOverProvider.isGameOver;
					}
					if (method.Equals("getGameOverUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iexplodewdModelExplodeWdGameOverProvider.getGameOverUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IexplodewdModelExplodeWdSurplusExplodeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IexplodewdModelExplodeWdSurplusExplodeProvider iexplodewdModelExplodeWdSurplusExplodeProvider = provider as IexplodewdModelExplodeWdSurplusExplodeProvider;
					if (method.Equals("getBranchUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iexplodewdModelExplodeWdSurplusExplodeProvider.getBranchUrl;
					}
					if (method.Equals("getNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iexplodewdModelExplodeWdSurplusExplodeProvider.getNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IexplodewdModelExplodeWdGameTipsProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IexplodewdModelExplodeWdGameTipsProvider iexplodewdModelExplodeWdGameTipsProvider = provider as IexplodewdModelExplodeWdGameTipsProvider;
					if (method.Equals("showGetC4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showGetC4;
					}
					if (method.Equals("showUseC4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showUseC4;
					}
					if (method.Equals("showLevelGame"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showLevelGame;
					}
					if (method.Equals("showFindBranch"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showFindBranch;
					}
					if (method.Equals("getBranchUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iexplodewdModelExplodeWdGameTipsProvider.getBranchUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelTimerProvider ifreeRpg_107000ModelTimerProvider = provider as IfreeRpg_107000ModelTimerProvider;
					if (method.Equals("RefreshMinute"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTimerProvider.RefreshMinute;
					}
					if (method.Equals("SetPlayerNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTimerProvider.SetPlayerNumber;
					}
					if (method.Equals("RefreshSecond"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTimerProvider.RefreshSecond;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelTaskInfoProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelTaskInfoProvider ifreeRpg_107000ModelTaskInfoProvider = provider as IfreeRpg_107000ModelTaskInfoProvider;
					if (method.Equals("IsShow1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsShow1;
					}
					if (method.Equals("IsShow2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsShow2;
					}
					if (method.Equals("RefreshTaskOne"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTaskInfoProvider.RefreshTaskOne;
					}
					if (method.Equals("RefreshTaskTwo"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTaskInfoProvider.RefreshTaskTwo;
					}
					if (method.Equals("IsType1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsType1;
					}
					if (method.Equals("IsTaskInfoShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsTaskInfoShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelChooseModeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelChooseModeProvider ifreeRpg_107000ModelChooseModeProvider = provider as IfreeRpg_107000ModelChooseModeProvider;
					if (method.Equals("IsShowChooseMode"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelChooseModeProvider.IsShowChooseMode;
					}
					if (method.Equals("GoNewModel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelChooseModeProvider.GoNewModel;
					}
					if (method.Equals("CancelGoMode"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelChooseModeProvider.CancelGoMode;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelCanSelectModeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelCanSelectModeProvider ifreeRpg_107000ModelCanSelectModeProvider = provider as IfreeRpg_107000ModelCanSelectModeProvider;
					if (method.Equals("IsShowCanSeletMode"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelCanSelectModeProvider.IsShowCanSeletMode;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelNotLeaveRoomProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelNotLeaveRoomProvider ifreeRpg_107000ModelNotLeaveRoomProvider = provider as IfreeRpg_107000ModelNotLeaveRoomProvider;
					if (method.Equals("RefreshMinute"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelNotLeaveRoomProvider.RefreshMinute;
					}
					if (method.Equals("RefreshSecond"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelNotLeaveRoomProvider.RefreshSecond;
					}
					if (method.Equals("IsShowNotLeaveRoom"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelNotLeaveRoomProvider.IsShowNotLeaveRoom;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelCanLightFireProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelCanLightFireProvider ifreeRpg_107000ModelCanLightFireProvider = provider as IfreeRpg_107000ModelCanLightFireProvider;
					if (method.Equals("SetExp1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelCanLightFireProvider.SetExp1;
					}
					if (method.Equals("SetExp2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelCanLightFireProvider.SetExp2;
					}
					if (method.Equals("SetExp3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelCanLightFireProvider.SetExp3;
					}
					if (method.Equals("IsShowCanLightFire"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelCanLightFireProvider.IsShowCanLightFire;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelExpProgressProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelExpProgressProvider ifreeRpg_107000ModelExpProgressProvider = provider as IfreeRpg_107000ModelExpProgressProvider;
					if (method.Equals("SwitchAni"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelExpProgressProvider.SwitchAni;
					}
					if (method.Equals("IsFire"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelExpProgressProvider.IsFire;
					}
					if (method.Equals("SetFirePercentText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelExpProgressProvider.SetFirePercentText;
					}
					if (method.Equals("SetFirePercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelExpProgressProvider.SetFirePercent;
					}
					if (method.Equals("IsShowExp"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelExpProgressProvider.IsShowExp;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelCanSelectSpecailPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelCanSelectSpecailPlayerProvider ifreeRpg_107000ModelCanSelectSpecailPlayerProvider = provider as IfreeRpg_107000ModelCanSelectSpecailPlayerProvider;
					if (method.Equals("IsShowSelectPlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelCanSelectSpecailPlayerProvider.IsShowSelectPlayer;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelFireStartProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelFireStartProvider ifreeRpg_107000ModelFireStartProvider = provider as IfreeRpg_107000ModelFireStartProvider;
					if (method.Equals("IsShowFireStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelFireStartProvider.IsShowFireStart;
					}
					if (method.Equals("SetPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelFireStartProvider.SetPlayerName;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelSpecailExpSetProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelSpecailExpSetProvider ifreeRpg_107000ModelSpecailExpSetProvider = provider as IfreeRpg_107000ModelSpecailExpSetProvider;
					if (method.Equals("IsShowExpSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSpecailExpSetProvider.IsShowExpSet;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelSelectPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelSelectPlayerProvider ifreeRpg_107000ModelSelectPlayerProvider = provider as IfreeRpg_107000ModelSelectPlayerProvider;
					if (method.Equals("IsShowChoosePlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ifreeRpg_107000ModelSelectPlayerProvider.IsShowChoosePlayer;
					}
					if (method.Equals("ClosePanel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.ClosePanel;
					}
					if (method.Equals("GetPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelSelectPlayerProvider.GetPlayerName;
					}
					if (method.Equals("IsShowSelectPlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsShowSelectPlayer;
					}
					if (method.Equals("IsSelect1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect1;
					}
					if (method.Equals("SelectPlayer1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer1;
					}
					if (method.Equals("IsSelect2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect2;
					}
					if (method.Equals("SelectPlayer2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer2;
					}
					if (method.Equals("IsSelect3"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect3;
					}
					if (method.Equals("SelectPlayer3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer3;
					}
					if (method.Equals("IsSelect4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect4;
					}
					if (method.Equals("SelectPlayer4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer4;
					}
					if (method.Equals("IsSelect5"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect5;
					}
					if (method.Equals("SelectPlayer5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer5;
					}
					if (method.Equals("IsSelect6"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect6;
					}
					if (method.Equals("SelectPlayer6"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer6;
					}
					if (method.Equals("IsSelect7"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect7;
					}
					if (method.Equals("SelectPlayer7"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer7;
					}
					if (method.Equals("IsSelect8"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect8;
					}
					if (method.Equals("SelectPlayer8"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer8;
					}
					if (method.Equals("IsSelect9"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect9;
					}
					if (method.Equals("SelectPlayer9"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer9;
					}
					if (method.Equals("IsSelect10"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect10;
					}
					if (method.Equals("SelectPlayer10"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer10;
					}
					if (method.Equals("IsSelect11"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect11;
					}
					if (method.Equals("SelectPlayer11"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer11;
					}
					if (method.Equals("IsSelect12"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect12;
					}
					if (method.Equals("SelectPlayer12"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer12;
					}
					if (method.Equals("IsSelect13"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect13;
					}
					if (method.Equals("SelectPlayer13"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer13;
					}
					if (method.Equals("IsSelect14"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect14;
					}
					if (method.Equals("SelectPlayer14"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer14;
					}
					if (method.Equals("IsSelect15"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect15;
					}
					if (method.Equals("SelectPlayer15"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer15;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelRankProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IfreeRpg_107000ModelRankProvider ifreeRpg_107000ModelRankProvider = provider as IfreeRpg_107000ModelRankProvider;
					if (method.Equals("GetAllDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetAllDamage;
					}
					if (method.Equals("GetRankDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelRankProvider.GetRankDamage;
					}
					if (method.Equals("GetRankName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelRankProvider.GetRankName;
					}
					if (method.Equals("IsRankShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ifreeRpg_107000ModelRankProvider.IsRankShow;
					}
					if (method.Equals("GetSecDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetSecDamage;
					}
					if (method.Equals("GetSelfName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetSelfName;
					}
					if (method.Equals("IsRankshow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelRankProvider.IsRankshow;
					}
					if (method.Equals("GetRankTitle"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelRankProvider.GetRankTitle;
					}
					if (method.Equals("GetRefreshTime"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetRefreshTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelRoundScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelRoundScoreBoardProvider igoldRankModelRoundScoreBoardProvider = provider as IgoldRankModelRoundScoreBoardProvider;
					if (method.Equals("SetBlueScoreShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelRoundScoreBoardProvider.SetBlueScoreShow;
					}
					if (method.Equals("SetRedScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelRoundScoreBoardProvider.SetRedScore;
					}
					if (method.Equals("SetRoundScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelRoundScoreBoardProvider.SetRoundScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelPlayerNumNotProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelPlayerNumNotProvider igoldRankModelPlayerNumNotProvider = provider as IgoldRankModelPlayerNumNotProvider;
					if (method.Equals("SetPlayerNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelPlayerNumNotProvider.SetPlayerNum;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelPlayerNumNotProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelScoreBoardProvider igoldRankModelScoreBoardProvider = provider as IgoldRankModelScoreBoardProvider;
					if (method.Equals("SetBlueTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelScoreBoardProvider.SetBlueTeamNum;
					}
					if (method.Equals("GetPrediction"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igoldRankModelScoreBoardProvider.GetPrediction;
					}
					if (method.Equals("SetRedTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelScoreBoardProvider.SetRedTeamNum;
					}
					if (method.Equals("SetHpNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelScoreBoardProvider.SetHpNum;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelScoreBoardProvider.SetProgressBar;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelScoreBoardProvider.SetRoundTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelStartTimerProvider igoldRankModelStartTimerProvider = provider as IgoldRankModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelEndTimerProvider igoldRankModelEndTimerProvider = provider as IgoldRankModelEndTimerProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelEndTimerProvider.IsShow;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelEndTimerProvider.SetTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelBagPreviewProvider igoldRankModelBagPreviewProvider = provider as IgoldRankModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igoldRankModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igoldRankModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelRoundReviewProvider igoldRankModelRoundReviewProvider = provider as IgoldRankModelRoundReviewProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelRoundReviewProvider.IsShow;
					}
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igoldRankModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelRoundReviewProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgoldRankModelRandomEffectProvider igoldRankModelRandomEffectProvider = provider as IgoldRankModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igoldRankModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelRoundScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelRoundScoreBoardProvider igunFightModelRoundScoreBoardProvider = provider as IgunFightModelRoundScoreBoardProvider;
					if (method.Equals("SetBlueScoreShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelRoundScoreBoardProvider.SetBlueScoreShow;
					}
					if (method.Equals("SetRedScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelRoundScoreBoardProvider.SetRedScore;
					}
					if (method.Equals("SetRoundScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelRoundScoreBoardProvider.SetRoundScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelPlayerNumNotProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelPlayerNumNotProvider igunFightModelPlayerNumNotProvider = provider as IgunFightModelPlayerNumNotProvider;
					if (method.Equals("SetPlayerNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelPlayerNumNotProvider.SetPlayerNum;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelPlayerNumNotProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelScoreBoardProvider igunFightModelScoreBoardProvider = provider as IgunFightModelScoreBoardProvider;
					if (method.Equals("SetBlueTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelScoreBoardProvider.SetBlueTeamNum;
					}
					if (method.Equals("GetPrediction"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igunFightModelScoreBoardProvider.GetPrediction;
					}
					if (method.Equals("SetRedTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelScoreBoardProvider.SetRedTeamNum;
					}
					if (method.Equals("SetHpNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelScoreBoardProvider.SetHpNum;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelScoreBoardProvider.SetProgressBar;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelScoreBoardProvider.SetRoundTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelStartTimerProvider igunFightModelStartTimerProvider = provider as IgunFightModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelEndTimerProvider igunFightModelEndTimerProvider = provider as IgunFightModelEndTimerProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelEndTimerProvider.IsShow;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelEndTimerProvider.SetTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelBagPreviewProvider igunFightModelBagPreviewProvider = provider as IgunFightModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igunFightModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igunFightModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelRoundReviewProvider igunFightModelRoundReviewProvider = provider as IgunFightModelRoundReviewProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelRoundReviewProvider.IsShow;
					}
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igunFightModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelRoundReviewProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IgunFightModelRandomEffectProvider igunFightModelRandomEffectProvider = provider as IgunFightModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igunFightModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IhighSpeedGroupModelHighSpeedGroupSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IhighSpeedGroupModelHighSpeedGroupSkillProvider ihighSpeedGroupModelHighSpeedGroupSkillProvider = provider as IhighSpeedGroupModelHighSpeedGroupSkillProvider;
					if (method.Equals("getSkillUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ihighSpeedGroupModelHighSpeedGroupSkillProvider.getSkillUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelRoundScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelRoundScoreBoardProvider iknifeFightModelRoundScoreBoardProvider = provider as IknifeFightModelRoundScoreBoardProvider;
					if (method.Equals("SetBlueScoreShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelRoundScoreBoardProvider.SetBlueScoreShow;
					}
					if (method.Equals("SetRedScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelRoundScoreBoardProvider.SetRedScore;
					}
					if (method.Equals("SetRoundScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelRoundScoreBoardProvider.SetRoundScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelPlayerNumNotProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelPlayerNumNotProvider iknifeFightModelPlayerNumNotProvider = provider as IknifeFightModelPlayerNumNotProvider;
					if (method.Equals("SetPlayerNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelPlayerNumNotProvider.SetPlayerNum;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelPlayerNumNotProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelScoreBoardProvider iknifeFightModelScoreBoardProvider = provider as IknifeFightModelScoreBoardProvider;
					if (method.Equals("SetBlueTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelScoreBoardProvider.SetBlueTeamNum;
					}
					if (method.Equals("GetPrediction"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iknifeFightModelScoreBoardProvider.GetPrediction;
					}
					if (method.Equals("SetRedTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelScoreBoardProvider.SetRedTeamNum;
					}
					if (method.Equals("SetHpNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelScoreBoardProvider.SetHpNum;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelScoreBoardProvider.SetProgressBar;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelScoreBoardProvider.SetRoundTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelStartTimerProvider iknifeFightModelStartTimerProvider = provider as IknifeFightModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelEndTimerProvider iknifeFightModelEndTimerProvider = provider as IknifeFightModelEndTimerProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelEndTimerProvider.IsShow;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelEndTimerProvider.SetTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelBagPreviewProvider iknifeFightModelBagPreviewProvider = provider as IknifeFightModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iknifeFightModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iknifeFightModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelRoundReviewProvider iknifeFightModelRoundReviewProvider = provider as IknifeFightModelRoundReviewProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelRoundReviewProvider.IsShow;
					}
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iknifeFightModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelRoundReviewProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IknifeFightModelRandomEffectProvider iknifeFightModelRandomEffectProvider = provider as IknifeFightModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iknifeFightModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelmechKingMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ImechKingModelmechKingMessageProvider imechKingModelmechKingMessageProvider = provider as ImechKingModelmechKingMessageProvider;
					if (method.Equals("isShowHuamn"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingMessageProvider.isShowHuamn;
					}
					if (method.Equals("isShowMech"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingMessageProvider.isShowMech;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelmechKingPromptProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ImechKingModelmechKingPromptProvider imechKingModelmechKingPromptProvider = provider as ImechKingModelmechKingPromptProvider;
					if (method.Equals("showWeapon"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingPromptProvider.showWeapon;
					}
					if (method.Equals("showStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingPromptProvider.showStart;
					}
					if (method.Equals("showNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingPromptProvider.showNumber;
					}
					if (method.Equals("setNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingPromptProvider.setNumber;
					}
					if (method.Equals("setStartNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingPromptProvider.setStartNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelReliveProcessProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ImechKingModelReliveProcessProvider imechKingModelReliveProcessProvider = provider as ImechKingModelReliveProcessProvider;
					if (method.Equals("showPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelReliveProcessProvider.showPoint;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelReliveProcessProvider.setProgress;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelReliveProcessProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelmechKingSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					ImechKingModelmechKingSkillProvider imechKingModelmechKingSkillProvider = provider as ImechKingModelmechKingSkillProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = imechKingModelmechKingSkillProvider.changeImage;
					}
					if (method.Equals("changeFImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = imechKingModelmechKingSkillProvider.changeFImage;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.setProgress;
					}
					if (method.Equals("setFlyProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.setFlyProgress;
					}
					if (method.Equals("setRotationProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.setRotationProgress;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingSkillProvider.isShow;
					}
					if (method.Equals("showExp"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showExp;
					}
					if (method.Equals("showMaxExp"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showMaxExp;
					}
					if (method.Equals("showLv"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showLv;
					}
					if (method.Equals("showNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooTeamScoreGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooTeamScoreGUIProvider ipeekabooModelPeekAbooTeamScoreGUIProvider = provider as IpeekabooModelPeekAbooTeamScoreGUIProvider;
					if (method.Equals("updateTextInfo"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooTeamScoreGUIProvider.updateTextInfo;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooLikesGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooLikesGUIProvider ipeekabooModelPeekAbooLikesGUIProvider = provider as IpeekabooModelPeekAbooLikesGUIProvider;
					if (method.Equals("checkLikesShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooLikesGUIProvider.checkLikesShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooStarsItemGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooStarsItemGUIProvider ipeekabooModelPeekAbooStarsItemGUIProvider = provider as IpeekabooModelPeekAbooStarsItemGUIProvider;
					if (method.Equals("updateConAddVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateConAddVisible;
					}
					if (method.Equals("updateConAddY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateConAddY;
					}
					if (method.Equals("updateItemEffectVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectVisible;
					}
					if (method.Equals("updateItemEffectSize"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectSize;
					}
					if (method.Equals("updateItemEffectX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectX;
					}
					if (method.Equals("updateItemEffectY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectY;
					}
					if (method.Equals("updateImgItemMoveVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgItemMoveVisible;
					}
					if (method.Equals("updateMoveX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateMoveX;
					}
					if (method.Equals("updateMoveY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateMoveY;
					}
					if (method.Equals("updateImgItemVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgItemVisible;
					}
					if (method.Equals("updateImgItem"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgItem;
					}
					if (method.Equals("updateImgLiveVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgLiveVisible;
					}
					if (method.Equals("updateStarProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateStarProgress;
					}
					if (method.Equals("updateAddStarCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateAddStarCount;
					}
					if (method.Equals("updateStarCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateStarCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooMessageGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooMessageGUIProvider ipeekabooModelPeekAbooMessageGUIProvider = provider as IpeekabooModelPeekAbooMessageGUIProvider;
					if (method.Equals("updateSelfMessageVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateSelfMessageVisible;
					}
					if (method.Equals("updateImgSpecialVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgSpecialVisible;
					}
					if (method.Equals("updateSpecialSize"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooMessageGUIProvider.updateSpecialSize;
					}
					if (method.Equals("updateImgSpecialX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgSpecialX;
					}
					if (method.Equals("updateImgSpecialY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgSpecialY;
					}
					if (method.Equals("updateImgStartGameVisile"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgStartGameVisile;
					}
					if (method.Equals("updateImgStartGame"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgStartGame;
					}
					if (method.Equals("updateTxtTimeRedVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeRedVisible;
					}
					if (method.Equals("updateTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTime;
					}
					if (method.Equals("updateTxtTimeX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeX;
					}
					if (method.Equals("updateTxtTimeY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeY;
					}
					if (method.Equals("updateTxtTimeVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeVisible;
					}
					if (method.Equals("updateTxtPlayerCountVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtPlayerCountVisible;
					}
					if (method.Equals("updateTxtWaitPlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtWaitPlayer;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooGameOverGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooGameOverGUIProvider ipeekabooModelPeekAbooGameOverGUIProvider = provider as IpeekabooModelPeekAbooGameOverGUIProvider;
					if (method.Equals("updateSurviveVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateSurviveVisible;
					}
					if (method.Equals("updateItemContainerVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateItemContainerVisible;
					}
					if (method.Equals("updateWinItemVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateWinItemVisible;
					}
					if (method.Equals("updateConWinX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateConWinX;
					}
					if (method.Equals("updateImgWinSrc"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateImgWinSrc;
					}
					if (method.Equals("updateImgItemVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateImgItemVisible;
					}
					if (method.Equals("updateImgItemSrcByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateImgItemSrcByIndex;
					}
					if (method.Equals("updateRootVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateRootVisible;
					}
					if (method.Equals("updateTxtNameVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateTxtNameVisible;
					}
					if (method.Equals("updateTxtNameByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateTxtNameByIndex;
					}
					if (method.Equals("updateSurviveCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateSurviveCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooByLikesGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooByLikesGUIProvider ipeekabooModelPeekAbooByLikesGUIProvider = provider as IpeekabooModelPeekAbooByLikesGUIProvider;
					if (method.Equals("updateImgVisibleByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgVisibleByIndex;
					}
					if (method.Equals("updateImgSrc"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgSrc;
					}
					if (method.Equals("updateImgSize"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgSize;
					}
					if (method.Equals("updateImgX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgX;
					}
					if (method.Equals("updateImgY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgY;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooHumanityBackGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooHumanityBackGUIProvider ipeekabooModelPeekAbooHumanityBackGUIProvider = provider as IpeekabooModelPeekAbooHumanityBackGUIProvider;
					if (method.Equals("updateRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooHumanityBackGUIProvider.updateRootShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooSceneItemControlStateGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IpeekabooModelPeekAbooSceneItemControlStateGUIProvider ipeekabooModelPeekAbooSceneItemControlStateGUIProvider = provider as IpeekabooModelPeekAbooSceneItemControlStateGUIProvider;
					if (method.Equals("updateTipShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateTipShow;
					}
					if (method.Equals("updateTipSrc"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateTipSrc;
					}
					if (method.Equals("updateEStarCountInfo"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateEStarCountInfo;
					}
					if (method.Equals("updateConEVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateConEVisible;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IprotectBigHeadModelProtectBigHeadCareerUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IprotectBigHeadModelProtectBigHeadCareerUIProvider iprotectBigHeadModelProtectBigHeadCareerUIProvider = provider as IprotectBigHeadModelProtectBigHeadCareerUIProvider;
					if (method.Equals("updateBarByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateBarByIndex;
					}
					if (method.Equals("updateHpByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateHpByIndex;
					}
					if (method.Equals("updateMaxHpByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateMaxHpByIndex;
					}
					if (method.Equals("updateCareerIconByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateCareerIconByIndex;
					}
					if (method.Equals("rootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iprotectBigHeadModelProtectBigHeadCareerUIProvider.rootShow;
					}
					if (method.Equals("updateNameByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateNameByIndex;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IprotectBigHeadModelProtectBigheadTipsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IprotectBigHeadModelProtectBigheadTipsUIProvider iprotectBigHeadModelProtectBigheadTipsUIProvider = provider as IprotectBigHeadModelProtectBigheadTipsUIProvider;
					if (method.Equals("tipShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iprotectBigHeadModelProtectBigheadTipsUIProvider.tipShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgArmamentModelRpgArmamentMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgArmamentModelRpgArmamentMessageProvider irpgArmamentModelRpgArmamentMessageProvider = provider as IrpgArmamentModelRpgArmamentMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgArmamentModelRpgArmamentMessageProvider.isShowMessage;
					}
					if (method.Equals("pickInfoShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgArmamentModelRpgArmamentMessageProvider.pickInfoShow;
					}
					if (method.Equals("pickInfoText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgArmamentModelRpgArmamentMessageProvider.pickInfoText;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgArmamentModelRpgArmamentMyPointProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgArmamentModelRpgArmamentMyPointProvider irpgArmamentModelRpgArmamentMyPointProvider = provider as IrpgArmamentModelRpgArmamentMyPointProvider;
					if (method.Equals("updateMaxPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgArmamentModelRpgArmamentMyPointProvider.updateMaxPoint;
					}
					if (method.Equals("updateMyPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgArmamentModelRpgArmamentMyPointProvider.updateMyPoint;
					}
					if (method.Equals("isShowMessae"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgArmamentModelRpgArmamentMyPointProvider.isShowMessae;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgBaseRunModelRpgBaseRunProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgBaseRunModelRpgBaseRunProgressUIProvider irpgBaseRunModelRpgBaseRunProgressUIProvider = provider as IrpgBaseRunModelRpgBaseRunProgressUIProvider;
					if (method.Equals("checkRpgBaseRunUIShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.checkRpgBaseRunUIShow;
					}
					if (method.Equals("getBoxNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.getBoxNum;
					}
					if (method.Equals("changeBoxImg"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.changeBoxImg;
					}
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.getProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgBaseRunModelRpgBaseRunTaskUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgBaseRunModelRpgBaseRunTaskUIProvider irpgBaseRunModelRpgBaseRunTaskUIProvider = provider as IrpgBaseRunModelRpgBaseRunTaskUIProvider;
					if (method.Equals("IsItemShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.IsItemShowByIndex;
					}
					if (method.Equals("checkTaskUIShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.checkTaskUIShow;
					}
					if (method.Equals("IsItemAddDiByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.IsItemAddDiByIndex;
					}
					if (method.Equals("updateTaskNameByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTaskNameByIndex;
					}
					if (method.Equals("updateAddNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateAddNum;
					}
					if (method.Equals("updateMulNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateMulNum;
					}
					if (method.Equals("updatePercentNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updatePercentNum;
					}
					if (method.Equals("updateTaskProgressByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTaskProgressByIndex;
					}
					if (method.Equals("updateTaskScoreByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTaskScoreByIndex;
					}
					if (method.Equals("updateTotalNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTotalNum;
					}
					if (method.Equals("updateLvl"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateLvl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgDanrenMineModelDamageCountProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgDanrenMineModelDamageCountProvider irpgDanrenMineModelDamageCountProvider = provider as IrpgDanrenMineModelDamageCountProvider;
					if (method.Equals("GetDamageCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgDanrenMineModelDamageCountProvider.GetDamageCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgHolidayModelskillProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgHolidayModelskillProvider irpgHolidayModelskillProvider = provider as IrpgHolidayModelskillProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgHolidayModelskillProvider.changeImage;
					}
					if (method.Equals("isShowSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgHolidayModelskillProvider.isShowSkill;
					}
					if (method.Equals("showNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgHolidayModelskillProvider.showNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgLootMineModelRpgLootMineMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgLootMineModelRpgLootMineMessageProvider irpgLootMineModelRpgLootMineMessageProvider = provider as IrpgLootMineModelRpgLootMineMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgLootMineModelRpgLootMineMessageProvider.isShowMessage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgLootModelPlayerGetFlagProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgLootModelPlayerGetFlagProvider irpgLootModelPlayerGetFlagProvider = provider as IrpgLootModelPlayerGetFlagProvider;
					if (method.Equals("getCurrent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgLootModelPlayerGetFlagProvider.getCurrent;
					}
					if (method.Equals("getMax"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgLootModelPlayerGetFlagProvider.getMax;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgLootModelMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgLootModelMessageProvider irpgLootModelMessageProvider = provider as IrpgLootModelMessageProvider;
					if (method.Equals("isShowNoOccupy"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgLootModelMessageProvider.isShowNoOccupy;
					}
					if (method.Equals("isShowGetMoreFlag"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgLootModelMessageProvider.isShowGetMoreFlag;
					}
					if (method.Equals("isShowGetFlagWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgLootModelMessageProvider.isShowGetFlagWin;
					}
					if (method.Equals("getFlagWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgLootModelMessageProvider.getFlagWinCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelrpgplayerbufferProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelrpgplayerbufferProvider irpgModelrpgplayerbufferProvider = provider as IrpgModelrpgplayerbufferProvider;
					if (method.Equals("IsBufferItemShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelrpgplayerbufferProvider.IsBufferItemShow;
					}
					if (method.Equals("RefreshBufferItemAlpha"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelrpgplayerbufferProvider.RefreshBufferItemAlpha;
					}
					if (method.Equals("RefreshBufferIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelrpgplayerbufferProvider.RefreshBufferIcon;
					}
					if (method.Equals("IsRpgBufferShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelrpgplayerbufferProvider.IsRpgBufferShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelSkatingMechaModelProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelSkatingMechaModelProvider irpgModelSkatingMechaModelProvider = provider as IrpgModelSkatingMechaModelProvider;
					if (method.Equals("SetFuelValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelSkatingMechaModelProvider.SetFuelValue;
					}
					if (method.Equals("IsSkatingMechaModelShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelSkatingMechaModelProvider.IsSkatingMechaModelShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelSkatingMechaModelInfoProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelSkatingMechaModelInfoProvider irpgModelSkatingMechaModelInfoProvider = provider as IrpgModelSkatingMechaModelInfoProvider;
					if (method.Equals("SetHpValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelSkatingMechaModelInfoProvider.SetHpValue;
					}
					if (method.Equals("SetRanliaoValue"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelSkatingMechaModelInfoProvider.SetRanliaoValue;
					}
					if (method.Equals("IsSkatingMechaModelShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelSkatingMechaModelInfoProvider.IsSkatingMechaModelShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelBlackScreenProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelBlackScreenProvider irpgModelBlackScreenProvider = provider as IrpgModelBlackScreenProvider;
					if (method.Equals("IsBlackScreenShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBlackScreenProvider.IsBlackScreenShow;
					}
					if (method.Equals("setBlackScreen"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBlackScreenProvider.setBlackScreen;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelRpgBuffsProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelRpgBuffsProvider irpgModelRpgBuffsProvider = provider as IrpgModelRpgBuffsProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelRpgBuffsProvider.IsShow;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelRpgBuffsProvider.SetImage;
					}
					if (method.Equals("IsTextShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelRpgBuffsProvider.IsTextShow;
					}
					if (method.Equals("SetText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelRpgBuffsProvider.SetText;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelGameUITipsTimeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelGameUITipsTimeProvider irpgModelGameUITipsTimeProvider = provider as IrpgModelGameUITipsTimeProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelGameUITipsTimeProvider.IsShow;
					}
					if (method.Equals("ShowBackUI"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelGameUITipsTimeProvider.ShowBackUI;
					}
					if (method.Equals("showNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelGameUITipsTimeProvider.showNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelNezhaNengliangProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelNezhaNengliangProvider irpgModelNezhaNengliangProvider = provider as IrpgModelNezhaNengliangProvider;
					if (method.Equals("isDou1Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDou1Show;
					}
					if (method.Equals("isDou2Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDou2Show;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isShow;
					}
					if (method.Equals("isDou3Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDou3Show;
					}
					if (method.Equals("isDouuse1Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDouuse1Show;
					}
					if (method.Equals("isDouuse2Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDouuse2Show;
					}
					if (method.Equals("isDouuse3Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDouuse3Show;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelBossDescribeProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelBossDescribeProvider irpgModelBossDescribeProvider = provider as IrpgModelBossDescribeProvider;
					if (method.Equals("getBossBaseY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getBossBaseY;
					}
					if (method.Equals("getBossName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getBossName;
					}
					if (method.Equals("getBossTitleUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getBossTitleUrl;
					}
					if (method.Equals("isShowBossType"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.isShowBossType;
					}
					if (method.Equals("getBossType"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getBossType;
					}
					if (method.Equals("getCritdefUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getCritdefUrl;
					}
					if (method.Equals("getCritrateUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getCritrateUrl;
					}
					if (method.Equals("getExtraordinaryCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelBossDescribeProvider.getExtraordinaryCount;
					}
					if (method.Equals("showExtraordinaryIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showExtraordinaryIcon;
					}
					if (method.Equals("getHpLeft"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getHpLeft;
					}
					if (method.Equals("showHpRight"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.showHpRight;
					}
					if (method.Equals("getHpRight"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getHpRight;
					}
					if (method.Equals("isShowHpType"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.isShowHpType;
					}
					if (method.Equals("getHpTypeUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getHpTypeUrl;
					}
					if (method.Equals("getHpTypeLockUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getHpTypeLockUrl;
					}
					if (method.Equals("getHpWordUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getHpWordUrl;
					}
					if (method.Equals("getHujiaUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getHujiaUrl;
					}
					if (method.Equals("getLichangUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getLichangUrl;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.isShow;
					}
					if (method.Equals("showSkillBack1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillBack1;
					}
					if (method.Equals("showSkillBack2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillBack2;
					}
					if (method.Equals("getSkillName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getSkillName;
					}
					if (method.Equals("showSkillPage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillPage;
					}
					if (method.Equals("getSkillPageY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelBossDescribeProvider.getSkillPageY;
					}
					if (method.Equals("getSkillTitle1"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getSkillTitle1;
					}
					if (method.Equals("showSkillTitle2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillTitle2;
					}
					if (method.Equals("getSkillTitle2"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getSkillTitle2;
					}
					if (method.Equals("getYangDunType"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getYangDunType;
					}
					if (method.Equals("showYangDun"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.showYangDun;
					}
					if (method.Equals("getYinDunType"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getYinDunType;
					}
					if (method.Equals("showYinDun"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.showYinDun;
					}
					if (method.Equals("getExtraordinaryValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getExtraordinaryValue;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelrpglongqibingbufferProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelrpglongqibingbufferProvider irpgModelrpglongqibingbufferProvider = provider as IrpgModelrpglongqibingbufferProvider;
					if (method.Equals("Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelrpglongqibingbufferProvider.Show;
					}
					if (method.Equals("GetLevel"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelrpglongqibingbufferProvider.GetLevel;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelextraordinaryProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelextraordinaryProvider irpgModelextraordinaryProvider = provider as IrpgModelextraordinaryProvider;
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelextraordinaryProvider.SetImage;
					}
					if (method.Equals("SetValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelextraordinaryProvider.SetValue;
					}
					if (method.Equals("SetShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelextraordinaryProvider.SetShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelETPowerProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgModelETPowerProvider irpgModelETPowerProvider = provider as IrpgModelETPowerProvider;
					if (method.Equals("SetShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelETPowerProvider.SetShow;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelETPowerProvider.SetImage;
					}
					if (method.Equals("SetValue"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelETPowerProvider.SetValue;
					}
					if (method.Equals("GetFrameShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelETPowerProvider.GetFrameShow;
					}
					if (method.Equals("GetNumShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelETPowerProvider.GetNumShow;
					}
					if (method.Equals("GetCDTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelETPowerProvider.GetCDTimer;
					}
					if (method.Equals("GetCDTimerDes"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelETPowerProvider.GetCDTimerDes;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgSplitSecondmessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgSplitSecondmessageProvider irpgSplitSecondmessageProvider = provider as IrpgSplitSecondmessageProvider;
					if (method.Equals("IsShowCancelCollsion"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgSplitSecondmessageProvider.IsShowCancelCollsion;
					}
					if (method.Equals("IsShowGetSpeed"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgSplitSecondmessageProvider.IsShowGetSpeed;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgSplitSecondariverPointProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgSplitSecondariverPointProvider irpgSplitSecondariverPointProvider = provider as IrpgSplitSecondariverPointProvider;
					if (method.Equals("GetFirstPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgSplitSecondariverPointProvider.GetFirstPoint;
					}
					if (method.Equals("GetAllPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgSplitSecondariverPointProvider.GetAllPoint;
					}
					if (method.Equals("GetRank"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgSplitSecondariverPointProvider.GetRank;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider;
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider.checkShow;
					}
					if (method.Equals("getProb"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider.getProb;
					}
					if (method.Equals("barShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider.barShowByIndex;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStarWalkerModelRpgStarWalkerProgressUIProvider irpgStarWalkerModelRpgStarWalkerProgressUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerProgressUIProvider;
					if (method.Equals("getIconBossY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getIconBossY;
					}
					if (method.Equals("getIconExitY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getIconExitY;
					}
					if (method.Equals("getNumInfection"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getNumInfection;
					}
					if (method.Equals("getInfectionRate"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getInfectionRate;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.checkShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerTargetUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStarWalkerModelRpgStarWalkerTargetUIProvider irpgStarWalkerModelRpgStarWalkerTargetUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerTargetUIProvider;
					if (method.Equals("getCurProtectNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerTargetUIProvider.getCurProtectNum;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTargetUIProvider.checkShow;
					}
					if (method.Equals("getTotalProtectNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerTargetUIProvider.getTotalProtectNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerTipsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStarWalkerModelRpgStarWalkerTipsUIProvider irpgStarWalkerModelRpgStarWalkerTipsUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerTipsUIProvider;
					if (method.Equals("infectionIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.infectionIsShow;
					}
					if (method.Equals("getNumInfection"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.getNumInfection;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.checkShow;
					}
					if (method.Equals("playerNameIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.playerNameIsShow;
					}
					if (method.Equals("getPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.getPlayerName;
					}
					if (method.Equals("tipShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.tipShowByIndex;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStralExpertModelRpgStralExpertMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStralExpertModelRpgStralExpertMessageProvider irpgStralExpertModelRpgStralExpertMessageProvider = provider as IrpgStralExpertModelRpgStralExpertMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgStralExpertModelRpgStralExpertMessageProvider.isShowMessage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStralExpertModelRpgStralExpertMaterialProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStralExpertModelRpgStralExpertMaterialProvider irpgStralExpertModelRpgStralExpertMaterialProvider = provider as IrpgStralExpertModelRpgStralExpertMaterialProvider;
					if (method.Equals("getCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgStralExpertModelRpgStralExpertMaterialProvider.getCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStralExpertModelRpgStralExpertSelfTeamProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgStralExpertModelRpgStralExpertSelfTeamProvider irpgStralExpertModelRpgStralExpertSelfTeamProvider = provider as IrpgStralExpertModelRpgStralExpertSelfTeamProvider;
					if (method.Equals("getTeamId"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStralExpertModelRpgStralExpertSelfTeamProvider.getTeamId;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTanlanModelRpgTanlanProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgTanlanModelRpgTanlanProgressUIProvider irpgTanlanModelRpgTanlanProgressUIProvider = provider as IrpgTanlanModelRpgTanlanProgressUIProvider;
					if (method.Equals("updateProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTanlanModelRpgTanlanProgressUIProvider.updateProgress;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanProgressUIProvider.checkShow;
					}
					if (method.Equals("updateIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgTanlanModelRpgTanlanProgressUIProvider.updateIcon;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTanlanModelRpgTanlanTargetUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgTanlanModelRpgTanlanTargetUIProvider irpgTanlanModelRpgTanlanTargetUIProvider = provider as IrpgTanlanModelRpgTanlanTargetUIProvider;
					if (method.Equals("updateCurNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTanlanModelRpgTanlanTargetUIProvider.updateCurNum;
					}
					if (method.Equals("isTimeTip"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanTargetUIProvider.isTimeTip;
					}
					if (method.Equals("updateLabel"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgTanlanModelRpgTanlanTargetUIProvider.updateLabel;
					}
					if (method.Equals("checkNumShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanTargetUIProvider.checkNumShow;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanTargetUIProvider.checkShow;
					}
					if (method.Equals("updateTotalNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTanlanModelRpgTanlanTargetUIProvider.updateTotalNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossBtnCsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgTreasureBossModelTreasureBossBtnCsUIProvider irpgTreasureBossModelTreasureBossBtnCsUIProvider = provider as IrpgTreasureBossModelTreasureBossBtnCsUIProvider;
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossBtnCsUIProvider.checkRootShow;
					}
					if (method.Equals("skillIsActive"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossBtnCsUIProvider.skillIsActive;
					}
					if (method.Equals("getSkillCd"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossBtnCsUIProvider.getSkillCd;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider irpgTreasureBossModelTreasureBossDayLightProgressUIProvider = provider as IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider;
					if (method.Equals("checkIsDay"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossDayLightProgressUIProvider.checkIsDay;
					}
					if (method.Equals("updateProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossDayLightProgressUIProvider.updateProgress;
					}
					if (method.Equals("getKeyCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossDayLightProgressUIProvider.getKeyCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossChuansongUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgTreasureBossModelTreasureBossChuansongUIProvider irpgTreasureBossModelTreasureBossChuansongUIProvider = provider as IrpgTreasureBossModelTreasureBossChuansongUIProvider;
					if (method.Equals("checkBtnShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.checkBtnShow;
					}
					if (method.Equals("updateBtnX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.updateBtnX;
					}
					if (method.Equals("updateBtnY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.updateBtnY;
					}
					if (method.Equals("btnIconClick"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.btnIconClick;
					}
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossChuansongUIProvider.checkRootShow;
					}
					if (method.Equals("hideView"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossChuansongUIProvider.hideView;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossTipsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(BattleSingletonInstance<DataProviderManager>.Instance.GetBindingName()))
				{
					IrpgTreasureBossModelTreasureBossTipsUIProvider irpgTreasureBossModelTreasureBossTipsUIProvider = provider as IrpgTreasureBossModelTreasureBossTipsUIProvider;
					if (method.Equals("tipShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgTreasureBossModelTreasureBossTipsUIProvider.tipShowByIndex;
					}
					if (method.Equals("tipBtnBIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossTipsUIProvider.tipBtnBIsShow;
					}
					if (method.Equals("tipEnterRoomIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossTipsUIProvider.tipEnterRoomIsShow;
					}
					if (method.Equals("updateCbtLvl"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossTipsUIProvider.updateCbtLvl;
					}
					if (method.Equals("updatePlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgTreasureBossModelTreasureBossTipsUIProvider.updatePlayerName;
					}
				}
			}
			return true;
		}
		return false;
	}

	public RunTimeDataArithmeticFuncNamager.GetFloat RunDefineEvent(string bundleName, string bindingObjName, string method, RunTimeDataArithmeticFuncNamager runTimeDataArithmeticFuncNamager)
	{
		for (int i = 0; i < BattleSingletonInstance<DataProviderManager>.Instance.ModeProviders.Count; i++)
		{
			IModeExtraDataProvider modeExtraDataProvider = BattleSingletonInstance<DataProviderManager>.Instance.ModeProviders[i];
			if (!modeExtraDataProvider.KeyInfo.Equals(bundleName, StringComparison.CurrentCultureIgnoreCase))
			{
				continue;
			}
			foreach (IModuleProvider provider in (modeExtraDataProvider as AbstractModeExtraDataProvider).Providers)
			{
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelTopShowInfoProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IAllRoundSinglesModelTopShowInfoProvider allRoundSinglesModelTopShowInfoProvider = provider as IAllRoundSinglesModelTopShowInfoProvider;
					if (method.Equals("SetCampCTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampCTWinCount;
					}
					if (method.Equals("SetCampCTKillCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampCTKillCount;
					}
					if (method.Equals("GetModeUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = allRoundSinglesModelTopShowInfoProvider.GetModeUrl;
					}
					if (method.Equals("SetCampTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampTWinCount;
					}
					if (method.Equals("SetCampTKillCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCampTKillCount;
					}
					if (method.Equals("SetCountDownMinuteTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCountDownMinuteTime;
					}
					if (method.Equals("SetCountDownSecondTimeGe"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCountDownSecondTimeGe;
					}
					if (method.Equals("SetCountDownSecondTimeShi"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelTopShowInfoProvider.SetCountDownSecondTimeShi;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelbattletipProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IAllRoundSinglesModelbattletipProvider allRoundSinglesModelbattletipProvider = provider as IAllRoundSinglesModelbattletipProvider;
					if (method.Equals("IsShowCountDown"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelbattletipProvider.IsShowCountDown;
					}
					if (method.Equals("SetCountDown"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelbattletipProvider.SetCountDown;
					}
					if (method.Equals("IsShowLoseHp"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelbattletipProvider.IsShowLoseHp;
					}
					if (method.Equals("IsShowWait"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelbattletipProvider.IsShowWait;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelSelectModeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IAllRoundSinglesModelSelectModeProvider allRoundSinglesModelSelectModeProvider = provider as IAllRoundSinglesModelSelectModeProvider;
					if (method.Equals("GetCountDown"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.GetCountDown;
					}
					if (method.Equals("IsSelect1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect1;
					}
					if (method.Equals("Select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select1;
					}
					if (method.Equals("IsWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsWin;
					}
					if (method.Equals("IsSelect4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect4;
					}
					if (method.Equals("Select4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select4;
					}
					if (method.Equals("IsSelect0"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect0;
					}
					if (method.Equals("Select0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select0;
					}
					if (method.Equals("IsSelect2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect2;
					}
					if (method.Equals("Select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select2;
					}
					if (method.Equals("Confirm"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Confirm;
					}
					if (method.Equals("IsSelect3"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect3;
					}
					if (method.Equals("Select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select3;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsShow;
					}
					if (method.Equals("IsSelect5"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelSelectModeProvider.IsSelect5;
					}
					if (method.Equals("Select5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelSelectModeProvider.Select5;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IAllRoundSinglesModelCurRoundResoultProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IAllRoundSinglesModelCurRoundResoultProvider allRoundSinglesModelCurRoundResoultProvider = provider as IAllRoundSinglesModelCurRoundResoultProvider;
					if (method.Equals("SetCampCTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelCurRoundResoultProvider.SetCampCTWinCount;
					}
					if (method.Equals("SetCampTWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = allRoundSinglesModelCurRoundResoultProvider.SetCampTWinCount;
					}
					if (method.Equals("GetWinScoreUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = allRoundSinglesModelCurRoundResoultProvider.GetWinScoreUrl;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelCurRoundResoultProvider.IsShow;
					}
					if (method.Equals("IsWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = allRoundSinglesModelCurRoundResoultProvider.IsWin;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2BuffProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigHeadKnife2ModelBigHeadKnife2BuffProvider ibigHeadKnife2ModelBigHeadKnife2BuffProvider = provider as IbigHeadKnife2ModelBigHeadKnife2BuffProvider;
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadKnife2ModelBigHeadKnife2BuffProvider.SetProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider ibigHeadKnife2ModelBigHeadKnife2SkillMessageProvider = provider as IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider;
					if (method.Equals("tipsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadKnife2ModelBigHeadKnife2SkillMessageProvider.tipsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider = provider as IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider;
					if (method.Equals("spriteShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.spriteShow;
					}
					if (method.Equals("changeSpritePic"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.changeSpritePic;
					}
					if (method.Equals("setMaskPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.setMaskPercent;
					}
					if (method.Equals("cdShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.cdShow;
					}
					if (method.Equals("updateCd"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.updateCd;
					}
					if (method.Equals("updateSkillPower"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigHeadKnife2ModelBigHeadKnife2SkillFItemProvider.updateSkillPower;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadKnife2ModelBigHeadKnife2WeaponProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigHeadKnife2ModelBigHeadKnife2WeaponProvider ibigHeadKnife2ModelBigHeadKnife2WeaponProvider = provider as IbigHeadKnife2ModelBigHeadKnife2WeaponProvider;
					if (method.Equals("SetCountTime"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigHeadKnife2ModelBigHeadKnife2WeaponProvider.SetCountTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigheadModelshadowDemonSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigheadModelshadowDemonSkillProvider ibigheadModelshadowDemonSkillProvider = provider as IbigheadModelshadowDemonSkillProvider;
					if (method.Equals("isHasSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isHasSkill;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigheadModelshadowDemonSkillProvider.isShow;
					}
					if (method.Equals("isShowEffect"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isShowEffect;
					}
					if (method.Equals("getEffectUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigheadModelshadowDemonSkillProvider.getEffectUrl;
					}
					if (method.Equals("isShowMask"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isShowMask;
					}
					if (method.Equals("getMaskProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibigheadModelshadowDemonSkillProvider.getMaskProgress;
					}
					if (method.Equals("isShowTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelshadowDemonSkillProvider.isShowTime;
					}
					if (method.Equals("getTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibigheadModelshadowDemonSkillProvider.getTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigheadModelHeroSelectProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigheadModelHeroSelectProvider ibigheadModelHeroSelectProvider = provider as IbigheadModelHeroSelectProvider;
					if (method.Equals("NoHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSelectProvider.NoHero;
					}
					if (method.Equals("SetHero"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigheadModelHeroSelectProvider.SetHero;
					}
					if (method.Equals("SeleHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSelectProvider.SeleHero;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigheadModelHeroSelectProvider.IsShow;
					}
					if (method.Equals("Select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.Select1;
					}
					if (method.Equals("Select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.Select2;
					}
					if (method.Equals("Select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.Select3;
					}
					if (method.Equals("HideUI"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigheadModelHeroSelectProvider.HideUI;
					}
					if (method.Equals("GetTimeout"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigheadModelHeroSelectProvider.GetTimeout;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigheadModelHeroSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigheadModelHeroSkillProvider ibigheadModelHeroSkillProvider = provider as IbigheadModelHeroSkillProvider;
					if (method.Equals("IsHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigheadModelHeroSkillProvider.IsHero;
					}
					if (method.Equals("Exists"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSkillProvider.Exists;
					}
					if (method.Equals("GetSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibigheadModelHeroSkillProvider.GetSkill;
					}
					if (method.Equals("SetSkillIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibigheadModelHeroSkillProvider.SetSkillIcon;
					}
					if (method.Equals("GetSkillTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibigheadModelHeroSkillProvider.GetSkillTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbigHeadP3ModelBigHeadP3SkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbigHeadP3ModelBigHeadP3SkillProvider ibigHeadP3ModelBigHeadP3SkillProvider = provider as IbigHeadP3ModelBigHeadP3SkillProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibigHeadP3ModelBigHeadP3SkillProvider.changeImage;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibigHeadP3ModelBigHeadP3SkillProvider.isShow;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibigHeadP3ModelBigHeadP3SkillProvider.setProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider ibioEvolutionChallengeModelbioEvolutionChallengeMessageProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioEvolutionChallengeModelbioEvolutionChallengeMessageProvider.isShowMessage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider ibioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider = provider as IbioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider;
					if (method.Equals("getAddLevel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider.getAddLevel;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionModelChallengeSkillLevelProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider ibioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider;
					if (method.Equals("getAddLevel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider.getAddLevel;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillLevelProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.isShow;
					}
					if (method.Equals("isShowDeathArua"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.isShowDeathArua;
					}
					if (method.Equals("isShowPandoraArua"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.isShowPandoraArua;
					}
					if (method.Equals("getNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSkillAuraProvider.getNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.isShow;
					}
					if (method.Equals("getSkillTypeFUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getSkillTypeFUrl;
					}
					if (method.Equals("isBackShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.isBackShow;
					}
					if (method.Equals("getSkillTypeFBackUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getSkillTypeFBackUrl;
					}
					if (method.Equals("getSkillTypeNoKeyUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getSkillTypeNoKeyUrl;
					}
					if (method.Equals("getWaitProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeHunmanSkillProvider.getWaitProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isShow;
					}
					if (method.Equals("isBackShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isBackShow;
					}
					if (method.Equals("getSkillTypeFBackUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getSkillTypeFBackUrl;
					}
					if (method.Equals("isShowSkillTypeF"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isShowSkillTypeF;
					}
					if (method.Equals("getSkillTypeFUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getSkillTypeFUrl;
					}
					if (method.Equals("isShowSkillTypeNoKey"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.isShowSkillTypeNoKey;
					}
					if (method.Equals("getSkillTypeNoKeyUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getSkillTypeNoKeyUrl;
					}
					if (method.Equals("getWaitProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeHumanSkillProvider.getWaitProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider = provider as IbioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider;
					if (method.Equals("isSelect"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.isSelect;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.isShow;
					}
					if (method.Equals("select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.select1;
					}
					if (method.Equals("select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.select2;
					}
					if (method.Equals("select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.select3;
					}
					if (method.Equals("getTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioEvolutionChallengeModelbioEvolutionChallengeSelectHumanProvider.getTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioEvolutionModelBioEvolutionDamageBufferProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioEvolutionModelBioEvolutionDamageBufferProvider ibioEvolutionModelBioEvolutionDamageBufferProvider = provider as IbioEvolutionModelBioEvolutionDamageBufferProvider;
					if (method.Equals("getBufferUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioEvolutionModelBioEvolutionDamageBufferProvider.getBufferUrl;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioEvolutionModelBioEvolutionDamageBufferProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelshadowDemonSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioModelshadowDemonSkillProvider ibioModelshadowDemonSkillProvider = provider as IbioModelshadowDemonSkillProvider;
					if (method.Equals("isHasSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isHasSkill;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelshadowDemonSkillProvider.isShow;
					}
					if (method.Equals("isShowEffect"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isShowEffect;
					}
					if (method.Equals("getEffectUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioModelshadowDemonSkillProvider.getEffectUrl;
					}
					if (method.Equals("isShowMask"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isShowMask;
					}
					if (method.Equals("getMaskProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioModelshadowDemonSkillProvider.getMaskProgress;
					}
					if (method.Equals("isShowTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelshadowDemonSkillProvider.isShowTime;
					}
					if (method.Equals("getTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioModelshadowDemonSkillProvider.getTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelHeroSelectProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioModelHeroSelectProvider ibioModelHeroSelectProvider = provider as IbioModelHeroSelectProvider;
					if (method.Equals("NoHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSelectProvider.NoHero;
					}
					if (method.Equals("SetHero"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioModelHeroSelectProvider.SetHero;
					}
					if (method.Equals("SeleHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSelectProvider.SeleHero;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelHeroSelectProvider.IsShow;
					}
					if (method.Equals("Select1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.Select1;
					}
					if (method.Equals("Select2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.Select2;
					}
					if (method.Equals("Select3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.Select3;
					}
					if (method.Equals("HideUI"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelHeroSelectProvider.HideUI;
					}
					if (method.Equals("GetTimeout"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioModelHeroSelectProvider.GetTimeout;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelHeroSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioModelHeroSkillProvider ibioModelHeroSkillProvider = provider as IbioModelHeroSkillProvider;
					if (method.Equals("IsHero"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelHeroSkillProvider.IsHero;
					}
					if (method.Equals("Exists"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSkillProvider.Exists;
					}
					if (method.Equals("GetSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioModelHeroSkillProvider.GetSkill;
					}
					if (method.Equals("SetSkillIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioModelHeroSkillProvider.SetSkillIcon;
					}
					if (method.Equals("GetSkillTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioModelHeroSkillProvider.GetSkillTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioModelMaolinProgressProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioModelMaolinProgressProvider ibioModelMaolinProgressProvider = provider as IbioModelMaolinProgressProvider;
					if (method.Equals("getPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelMaolinProgressProvider.getPercent;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelMaolinProgressProvider.isShow;
					}
					if (method.Equals("isLightShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioModelMaolinProgressProvider.isLightShow;
					}
					if (method.Equals("getLightEffectAlpha"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioModelMaolinProgressProvider.getLightEffectAlpha;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseSelectPlayerUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioUnionBaseSelectPlayerUIProvider ibioUnionBaseSelectPlayerUIProvider = provider as IbioUnionBaseSelectPlayerUIProvider;
					if (method.Equals("checkHeadCanShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectPlayerUIProvider.checkHeadCanShowByIndex;
					}
					if (method.Equals("checKeyInputByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectPlayerUIProvider.checKeyInputByIndex;
					}
					if (method.Equals("updateHeadIconByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ibioUnionBaseSelectPlayerUIProvider.updateHeadIconByIndex;
					}
					if (method.Equals("inputHandleByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioUnionBaseSelectPlayerUIProvider.inputHandleByIndex;
					}
					if (method.Equals("checkLockShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectPlayerUIProvider.checkLockShowByIndex;
					}
					if (method.Equals("checkLeftArrowIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectPlayerUIProvider.checkLeftArrowIsShow;
					}
					if (method.Equals("leftArrowHandle"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectPlayerUIProvider.leftArrowHandle;
					}
					if (method.Equals("checkRightArrowIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectPlayerUIProvider.checkRightArrowIsShow;
					}
					if (method.Equals("rightArrowHandle"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectPlayerUIProvider.rightArrowHandle;
					}
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectPlayerUIProvider.checkRootShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseSelectTeamUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioUnionBaseSelectTeamUIProvider ibioUnionBaseSelectTeamUIProvider = provider as IbioUnionBaseSelectTeamUIProvider;
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSelectTeamUIProvider.checkRootShow;
					}
					if (method.Equals("clickHandleByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibioUnionBaseSelectTeamUIProvider.clickHandleByIndex;
					}
					if (method.Equals("checkOverShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibioUnionBaseSelectTeamUIProvider.checkOverShow;
					}
					if (method.Equals("mouseOver0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOver0;
					}
					if (method.Equals("mouseOut0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOut0;
					}
					if (method.Equals("mouseOver1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOver1;
					}
					if (method.Equals("mouseOut1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSelectTeamUIProvider.mouseOut1;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseSoulUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioUnionBaseSoulUIProvider ibioUnionBaseSoulUIProvider = provider as IbioUnionBaseSoulUIProvider;
					if (method.Equals("checkInViewtShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSoulUIProvider.checkInViewtShow;
					}
					if (method.Equals("checkOutViewtShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSoulUIProvider.checkOutViewtShow;
					}
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseSoulUIProvider.checkRootShow;
					}
					if (method.Equals("updateTimeCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseSoulUIProvider.updateTimeCount;
					}
					if (method.Equals("updateCareerImg"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibioUnionBaseSoulUIProvider.updateCareerImg;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbioUnionBaseWaitPlayerUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbioUnionBaseWaitPlayerUIProvider ibioUnionBaseWaitPlayerUIProvider = provider as IbioUnionBaseWaitPlayerUIProvider;
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibioUnionBaseWaitPlayerUIProvider.checkRootShow;
					}
					if (method.Equals("updateWaitPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibioUnionBaseWaitPlayerUIProvider.updateWaitPlayerCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelWaitPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelWaitPlayerProvider ibladefightModelWaitPlayerProvider = provider as IbladefightModelWaitPlayerProvider;
					if (method.Equals("getCurrentPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getCurrentPlayerCount;
					}
					if (method.Equals("isShowTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelWaitPlayerProvider.isShowTime;
					}
					if (method.Equals("getCurrentTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getCurrentTime;
					}
					if (method.Equals("getMaxPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getMaxPlayerCount;
					}
					if (method.Equals("getMaxTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelWaitPlayerProvider.getMaxTime;
					}
					if (method.Equals("isWaitGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelWaitPlayerProvider.isWaitGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelfogAreaTimeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelfogAreaTimeProvider ibladefightModelfogAreaTimeProvider = provider as IbladefightModelfogAreaTimeProvider;
					if (method.Equals("getMinute"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelfogAreaTimeProvider.getMinute;
					}
					if (method.Equals("getSecond"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelfogAreaTimeProvider.getSecond;
					}
					if (method.Equals("isGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelfogAreaTimeProvider.isGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelSurplusPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelSurplusPlayerProvider ibladefightModelSurplusPlayerProvider = provider as IbladefightModelSurplusPlayerProvider;
					if (method.Equals("getSurplusCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelSurplusPlayerProvider.getSurplusCount;
					}
					if (method.Equals("isGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelSurplusPlayerProvider.isGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelMessageProvider ibladefightModelMessageProvider = provider as IbladefightModelMessageProvider;
					if (method.Equals("isFogAreaRefresh"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isFogAreaRefresh;
					}
					if (method.Equals("isWaitRealStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isWaitRealStart;
					}
					if (method.Equals("getWaitRealStartTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelMessageProvider.getWaitRealStartTime;
					}
					if (method.Equals("isSafeAreaRefresh"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isSafeAreaRefresh;
					}
					if (method.Equals("isObserve"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isObserve;
					}
					if (method.Equals("isGetEnergyPack"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isGetEnergyPack;
					}
					if (method.Equals("isTargetGetEnergyPack"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelMessageProvider.isTargetGetEnergyPack;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelReliveProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelReliveProvider ibladefightModelReliveProvider = provider as IbladefightModelReliveProvider;
					if (method.Equals("isShowReliveCount1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelReliveProvider.isShowReliveCount1;
					}
					if (method.Equals("getReliveCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelReliveProvider.getReliveCount;
					}
					if (method.Equals("isGameStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelReliveProvider.isGameStart;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelReliveBagPickingProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelReliveBagPickingProvider ibladefightModelReliveBagPickingProvider = provider as IbladefightModelReliveBagPickingProvider;
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelReliveBagPickingProvider.getProgress;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelReliveBagPickingProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladefightModelGameOverProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladefightModelGameOverProvider ibladefightModelGameOverProvider = provider as IbladefightModelGameOverProvider;
					if (method.Equals("getDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getDamage;
					}
					if (method.Equals("getKillNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getKillNum;
					}
					if (method.Equals("isWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelGameOverProvider.isWin;
					}
					if (method.Equals("getRanking"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getRanking;
					}
					if (method.Equals("getReturnLobbyTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladefightModelGameOverProvider.getReturnLobbyTime;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelGameOverProvider.isShow;
					}
					if (method.Equals("isReturnLobby"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladefightModelGameOverProvider.isReturnLobby;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladeStrongholdNewModelstateProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladeStrongholdNewModelstateProvider ibladeStrongholdNewModelstateProvider = provider as IbladeStrongholdNewModelstateProvider;
					if (method.Equals("showTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ibladeStrongholdNewModelstateProvider.showTime;
					}
					if (method.Equals("showclock"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ibladeStrongholdNewModelstateProvider.showclock;
					}
					if (method.Equals("updateTeamNum1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamNum1;
					}
					if (method.Equals("updateTeamNum2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamNum2;
					}
					if (method.Equals("updateCtScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateCtScore;
					}
					if (method.Equals("updateTeamProgress1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamProgress1;
					}
					if (method.Equals("updateTeamProgress2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTeamProgress2;
					}
					if (method.Equals("updateTScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateTScore;
					}
					if (method.Equals("showhong"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelstateProvider.showhong;
					}
					if (method.Equals("getProgress1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.getProgress1;
					}
					if (method.Equals("showlan"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelstateProvider.showlan;
					}
					if (method.Equals("getProgress2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.getProgress2;
					}
					if (method.Equals("updateWinScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelstateProvider.updateWinScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IbladeStrongholdNewModelMessageUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IbladeStrongholdNewModelMessageUIProvider ibladeStrongholdNewModelMessageUIProvider = provider as IbladeStrongholdNewModelMessageUIProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ibladeStrongholdNewModelMessageUIProvider.changeImage;
					}
					if (method.Equals("showOccup"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.showOccup;
					}
					if (method.Equals("showOccupProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelMessageUIProvider.showOccupProgress;
					}
					if (method.Equals("showVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.showVisible;
					}
					if (method.Equals("showTime"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.showTime;
					}
					if (method.Equals("IsshowNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ibladeStrongholdNewModelMessageUIProvider.IsshowNum;
					}
					if (method.Equals("showNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ibladeStrongholdNewModelMessageUIProvider.showNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IBroadSwordModelPowerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IBroadSwordModelPowerProvider broadSwordModelPowerProvider = provider as IBroadSwordModelPowerProvider;
					if (method.Equals("IsLiuGuangShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelPowerProvider.IsLiuGuangShow;
					}
					if (method.Equals("GetLiuGuangPosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelPowerProvider.GetLiuGuangPosX;
					}
					if (method.Equals("IsBottomShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelPowerProvider.IsBottomShow;
					}
					if (method.Equals("GetPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelPowerProvider.GetPercent;
					}
					if (method.Equals("IsRedShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelPowerProvider.IsRedShow;
					}
					if (method.Equals("UpdateRedImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = broadSwordModelPowerProvider.UpdateRedImage;
					}
					if (method.Equals("UpdateRedPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelPowerProvider.UpdateRedPercent;
					}
					if (method.Equals("IsYellowShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = broadSwordModelPowerProvider.IsYellowShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IBroadSwordModelmessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IBroadSwordModelmessageProvider broadSwordModelmessageProvider = provider as IBroadSwordModelmessageProvider;
					if (method.Equals("IsEShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsEShow;
					}
					if (method.Equals("IsFinalComingShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsFinalComingShow;
					}
					if (method.Equals("IsLevelUpShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsLevelUpShow;
					}
					if (method.Equals("IsStrengthenShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsStrengthenShow;
					}
					if (method.Equals("IsFinalComingCalShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsFinalComingCalShow;
					}
					if (method.Equals("IsWaitPlayerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = broadSwordModelmessageProvider.IsWaitPlayerShow;
					}
					if (method.Equals("GetFinalComingTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelmessageProvider.GetFinalComingTime;
					}
					if (method.Equals("GetWaitPlayerCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = broadSwordModelmessageProvider.GetWaitPlayerCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonSkatePressGuiProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonSkatePressGuiProvider icommonSkatePressGuiProvider = provider as IcommonSkatePressGuiProvider;
					if (method.Equals("getVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonSkatePressGuiProvider.getVisible;
					}
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonSkatePressGuiProvider.getProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonPlayerExpressionProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonPlayerExpressionProvider icommonPlayerExpressionProvider = provider as IcommonPlayerExpressionProvider;
					if (method.Equals("hasSelectItem1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem1;
					}
					if (method.Equals("getItem1Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem1Url;
					}
					if (method.Equals("selectItem1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem1;
					}
					if (method.Equals("mouseLeftClick"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.mouseLeftClick;
					}
					if (method.Equals("mouseRightClick"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.mouseRightClick;
					}
					if (method.Equals("hasSelectItem2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem2;
					}
					if (method.Equals("getItem2Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem2Url;
					}
					if (method.Equals("selectItem2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem2;
					}
					if (method.Equals("hasSelectItem3"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem3;
					}
					if (method.Equals("getItem3Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem3Url;
					}
					if (method.Equals("selectItem3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem3;
					}
					if (method.Equals("hasSelectItem4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem4;
					}
					if (method.Equals("getItem4Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem4Url;
					}
					if (method.Equals("selectItem4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem4;
					}
					if (method.Equals("hasSelectItem5"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasSelectItem5;
					}
					if (method.Equals("getItem5Url"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerExpressionProvider.getItem5Url;
					}
					if (method.Equals("selectItem5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem5;
					}
					if (method.Equals("hasTacticsSound"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.hasTacticsSound;
					}
					if (method.Equals("selectItem0"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.selectItem0;
					}
					if (method.Equals("isItem1Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem1Selected;
					}
					if (method.Equals("isItem2Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem2Selected;
					}
					if (method.Equals("isItem3Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem3Selected;
					}
					if (method.Equals("isItem4Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem4Selected;
					}
					if (method.Equals("isItem5Selected"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.isItem5Selected;
					}
					if (method.Equals("getGUIVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerExpressionProvider.getGUIVisible;
					}
					if (method.Equals("hideGUI"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.hideGUI;
					}
					if (method.Equals("useItem1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem1;
					}
					if (method.Equals("useItem2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem2;
					}
					if (method.Equals("useItem3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem3;
					}
					if (method.Equals("useItem4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem4;
					}
					if (method.Equals("useItem5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem5;
					}
					if (method.Equals("useItem6"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem6;
					}
					if (method.Equals("useItem7"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem7;
					}
					if (method.Equals("useItem8"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerExpressionProvider.useItem8;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonSelfUseExpressionProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonSelfUseExpressionProvider icommonSelfUseExpressionProvider = provider as IcommonSelfUseExpressionProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonSelfUseExpressionProvider.isShow;
					}
					if (method.Equals("getExpressionUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonSelfUseExpressionProvider.getExpressionUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonVideoHelpProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonVideoHelpProvider icommonVideoHelpProvider = provider as IcommonVideoHelpProvider;
					if (method.Equals("isCrimialSuspectDead"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoHelpProvider.isCrimialSuspectDead;
					}
					if (method.Equals("isCrimialSuspectOut"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoHelpProvider.isCrimialSuspectOut;
					}
					if (method.Equals("getCurrentSnapshotLength"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.getCurrentSnapshotLength;
					}
					if (method.Equals("selectSnapshotIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.selectSnapshotIndex;
					}
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.getProgress;
					}
					if (method.Equals("isVideo"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoHelpProvider.isVideo;
					}
					if (method.Equals("isSelectVideoSpeed"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = icommonVideoHelpProvider.isSelectVideoSpeed;
					}
					if (method.Equals("getStopOrContinue"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonVideoHelpProvider.getStopOrContinue;
					}
					if (method.Equals("getTotalSnapshotLength"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonVideoHelpProvider.getTotalSnapshotLength;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonOctopusPositionSetProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonOctopusPositionSetProvider icommonOctopusPositionSetProvider = provider as IcommonOctopusPositionSetProvider;
					if (method.Equals("setImageY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setImageY;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setProgress;
					}
					if (method.Equals("getVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonOctopusPositionSetProvider.getVisible;
					}
					if (method.Equals("setShowX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setShowX;
					}
					if (method.Equals("setShowY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonOctopusPositionSetProvider.setShowY;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonVideoMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonVideoMessageProvider icommonVideoMessageProvider = provider as IcommonVideoMessageProvider;
					if (method.Equals("isVideo"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoMessageProvider.isVideo;
					}
					if (method.Equals("isCrimialSuspectDead"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoMessageProvider.isCrimialSuspectDead;
					}
					if (method.Equals("isCrimialSuspectOut"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonVideoMessageProvider.isCrimialSuspectOut;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonStateProgressProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonStateProgressProvider icommonStateProgressProvider = provider as IcommonStateProgressProvider;
					if (method.Equals("SetDes"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonStateProgressProvider.SetDes;
					}
					if (method.Equals("SetPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonStateProgressProvider.SetPlayerName;
					}
					if (method.Equals("GetProgresPercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonStateProgressProvider.GetProgresPercent;
					}
					if (method.Equals("GetShinePos"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonStateProgressProvider.GetShinePos;
					}
					if (method.Equals("IsProgressShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonStateProgressProvider.IsProgressShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonChallengeAffixProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonChallengeAffixProvider icommonChallengeAffixProvider = provider as IcommonChallengeAffixProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonChallengeAffixProvider.changeImage;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonChallengeAffixProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonTipsMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonTipsMessageProvider icommonTipsMessageProvider = provider as IcommonTipsMessageProvider;
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonTipsMessageProvider.SetImage;
					}
					if (method.Equals("SetMessagePosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetMessagePosY;
					}
					if (method.Equals("SetYPos"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetYPos;
					}
					if (method.Equals("SetXPos"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetXPos;
					}
					if (method.Equals("SetNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonTipsMessageProvider.SetNumber;
					}
					if (method.Equals("IsShowNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonTipsMessageProvider.IsShowNumber;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonTipsMessageProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonPlayerInfoSkillMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonPlayerInfoSkillMessageProvider icommonPlayerInfoSkillMessageProvider = provider as IcommonPlayerInfoSkillMessageProvider;
					if (method.Equals("SetMessagePosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetMessagePosX;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoSkillMessageProvider.SetImage;
					}
					if (method.Equals("SetMessagePosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetMessagePosY;
					}
					if (method.Equals("SetPBackPosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBackPosX;
					}
					if (method.Equals("SetPBackImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoSkillMessageProvider.SetPBackImage;
					}
					if (method.Equals("SetPBackPosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBackPosY;
					}
					if (method.Equals("SetPBarPosX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBarPosX;
					}
					if (method.Equals("SetPBarImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoSkillMessageProvider.SetPBarImage;
					}
					if (method.Equals("SetPBarPosY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetPBarPosY;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonPlayerInfoSkillMessageProvider.SetProgress;
					}
					if (method.Equals("IsProgressShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerInfoSkillMessageProvider.IsProgressShow;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerInfoSkillMessageProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonPlayerInfoMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonPlayerInfoMessageProvider icommonPlayerInfoMessageProvider = provider as IcommonPlayerInfoMessageProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonPlayerInfoMessageProvider.IsShow;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonPlayerInfoMessageProvider.SetImage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonRandomKingTipProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonRandomKingTipProvider icommonRandomKingTipProvider = provider as IcommonRandomKingTipProvider;
					if (method.Equals("getVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = icommonRandomKingTipProvider.getVisible;
					}
					if (method.Equals("showString"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = icommonRandomKingTipProvider.showString;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonNonstopdanceSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonNonstopdanceSkillProvider icommonNonstopdanceSkillProvider = provider as IcommonNonstopdanceSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonNonstopdanceSkillProvider.isShow;
					}
					if (method.Equals("showImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = icommonNonstopdanceSkillProvider.showImage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonHypertechSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonHypertechSkillProvider icommonHypertechSkillProvider = provider as IcommonHypertechSkillProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonHypertechSkillProvider.isShow;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonHypertechSkillProvider.setProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonGameUITipsProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonGameUITipsProvider icommonGameUITipsProvider = provider as IcommonGameUITipsProvider;
					if (method.Equals("ShowBackUI"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonGameUITipsProvider.ShowBackUI;
					}
					if (method.Equals("ShowProgressUI"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonGameUITipsProvider.ShowProgressUI;
					}
					if (method.Equals("ShowProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonGameUITipsProvider.ShowProgress;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonGameUITipsProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonbioReliveEProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonbioReliveEProvider icommonbioReliveEProvider = provider as IcommonbioReliveEProvider;
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonbioReliveEProvider.isShow;
					}
					if (method.Equals("showTip"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonbioReliveEProvider.showTip;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonDragonAuraSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonDragonAuraSkillProvider icommonDragonAuraSkillProvider = provider as IcommonDragonAuraSkillProvider;
					if (method.Equals("GetPercentage"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonDragonAuraSkillProvider.GetPercentage;
					}
					if (method.Equals("GetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonDragonAuraSkillProvider.GetProgress;
					}
					if (method.Equals("ShowUI"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonDragonAuraSkillProvider.ShowUI;
					}
					if (method.Equals("GetAlpha"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = icommonDragonAuraSkillProvider.GetAlpha;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IcommonKickVoteUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IcommonKickVoteUIProvider icommonKickVoteUIProvider = provider as IcommonKickVoteUIProvider;
					if (method.Equals("GetAgree"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetAgree;
					}
					if (method.Equals("isResult"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonKickVoteUIProvider.isResult;
					}
					if (method.Equals("GetName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetName;
					}
					if (method.Equals("GetReason"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetReason;
					}
					if (method.Equals("GetRejest"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.GetRejest;
					}
					if (method.Equals("KickVoteShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = icommonKickVoteUIProvider.KickVoteShow;
					}
					if (method.Equals("Agree"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonKickVoteUIProvider.Agree;
					}
					if (method.Equals("Disagree"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = icommonKickVoteUIProvider.Disagree;
					}
					if (method.Equals("getTimerText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = icommonKickVoteUIProvider.getTimerText;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelTopScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelTopScoreBoardProvider competeKingModelTopScoreBoardProvider = provider as ICompeteKingModelTopScoreBoardProvider;
					if (method.Equals("SetTeamNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelTopScoreBoardProvider.SetTeamNumber;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelTopScoreBoardProvider.SetRoundTime;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = competeKingModelTopScoreBoardProvider.SetProgressBar;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelBottomScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelBottomScoreBoardProvider competeKingModelBottomScoreBoardProvider = provider as ICompeteKingModelBottomScoreBoardProvider;
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelBottomScoreBoardProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelRoundReviewProvider competeKingModelRoundReviewProvider = provider as ICompeteKingModelRoundReviewProvider;
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = competeKingModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetFlag"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelRoundReviewProvider.SetFlag;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = competeKingModelRoundReviewProvider.SetScore;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelRoundReviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelBagPreviewProvider competeKingModelBagPreviewProvider = provider as ICompeteKingModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelEndTimerProvider competeKingModelEndTimerProvider = provider as ICompeteKingModelEndTimerProvider;
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelEndTimerProvider.SetTime;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelEndTimerProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelRandomEffectProvider competeKingModelRandomEffectProvider = provider as ICompeteKingModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = competeKingModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = competeKingModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ICompeteKingModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ICompeteKingModelStartTimerProvider competeKingModelStartTimerProvider = provider as ICompeteKingModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = competeKingModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = competeKingModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IDimensionalFissureModelKuangLuanProgressUiProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IDimensionalFissureModelKuangLuanProgressUiProvider dimensionalFissureModelKuangLuanProgressUiProvider = provider as IDimensionalFissureModelKuangLuanProgressUiProvider;
					if (method.Equals("SetDerangement"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = dimensionalFissureModelKuangLuanProgressUiProvider.SetDerangement;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IexplodewdModelExplodeWdGameOverProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IexplodewdModelExplodeWdGameOverProvider iexplodewdModelExplodeWdGameOverProvider = provider as IexplodewdModelExplodeWdGameOverProvider;
					if (method.Equals("isGameOver"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameOverProvider.isGameOver;
					}
					if (method.Equals("getGameOverUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iexplodewdModelExplodeWdGameOverProvider.getGameOverUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IexplodewdModelExplodeWdSurplusExplodeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IexplodewdModelExplodeWdSurplusExplodeProvider iexplodewdModelExplodeWdSurplusExplodeProvider = provider as IexplodewdModelExplodeWdSurplusExplodeProvider;
					if (method.Equals("getBranchUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iexplodewdModelExplodeWdSurplusExplodeProvider.getBranchUrl;
					}
					if (method.Equals("getNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iexplodewdModelExplodeWdSurplusExplodeProvider.getNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IexplodewdModelExplodeWdGameTipsProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IexplodewdModelExplodeWdGameTipsProvider iexplodewdModelExplodeWdGameTipsProvider = provider as IexplodewdModelExplodeWdGameTipsProvider;
					if (method.Equals("showGetC4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showGetC4;
					}
					if (method.Equals("showUseC4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showUseC4;
					}
					if (method.Equals("showLevelGame"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showLevelGame;
					}
					if (method.Equals("showFindBranch"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iexplodewdModelExplodeWdGameTipsProvider.showFindBranch;
					}
					if (method.Equals("getBranchUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iexplodewdModelExplodeWdGameTipsProvider.getBranchUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelTimerProvider ifreeRpg_107000ModelTimerProvider = provider as IfreeRpg_107000ModelTimerProvider;
					if (method.Equals("RefreshMinute"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTimerProvider.RefreshMinute;
					}
					if (method.Equals("SetPlayerNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTimerProvider.SetPlayerNumber;
					}
					if (method.Equals("RefreshSecond"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTimerProvider.RefreshSecond;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelTaskInfoProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelTaskInfoProvider ifreeRpg_107000ModelTaskInfoProvider = provider as IfreeRpg_107000ModelTaskInfoProvider;
					if (method.Equals("IsShow1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsShow1;
					}
					if (method.Equals("IsShow2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsShow2;
					}
					if (method.Equals("RefreshTaskOne"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTaskInfoProvider.RefreshTaskOne;
					}
					if (method.Equals("RefreshTaskTwo"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelTaskInfoProvider.RefreshTaskTwo;
					}
					if (method.Equals("IsType1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsType1;
					}
					if (method.Equals("IsTaskInfoShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelTaskInfoProvider.IsTaskInfoShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelChooseModeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelChooseModeProvider ifreeRpg_107000ModelChooseModeProvider = provider as IfreeRpg_107000ModelChooseModeProvider;
					if (method.Equals("IsShowChooseMode"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelChooseModeProvider.IsShowChooseMode;
					}
					if (method.Equals("GoNewModel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelChooseModeProvider.GoNewModel;
					}
					if (method.Equals("CancelGoMode"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelChooseModeProvider.CancelGoMode;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelCanSelectModeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelCanSelectModeProvider ifreeRpg_107000ModelCanSelectModeProvider = provider as IfreeRpg_107000ModelCanSelectModeProvider;
					if (method.Equals("IsShowCanSeletMode"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelCanSelectModeProvider.IsShowCanSeletMode;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelNotLeaveRoomProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelNotLeaveRoomProvider ifreeRpg_107000ModelNotLeaveRoomProvider = provider as IfreeRpg_107000ModelNotLeaveRoomProvider;
					if (method.Equals("RefreshMinute"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelNotLeaveRoomProvider.RefreshMinute;
					}
					if (method.Equals("RefreshSecond"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelNotLeaveRoomProvider.RefreshSecond;
					}
					if (method.Equals("IsShowNotLeaveRoom"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelNotLeaveRoomProvider.IsShowNotLeaveRoom;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelCanLightFireProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelCanLightFireProvider ifreeRpg_107000ModelCanLightFireProvider = provider as IfreeRpg_107000ModelCanLightFireProvider;
					if (method.Equals("SetExp1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelCanLightFireProvider.SetExp1;
					}
					if (method.Equals("SetExp2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelCanLightFireProvider.SetExp2;
					}
					if (method.Equals("SetExp3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelCanLightFireProvider.SetExp3;
					}
					if (method.Equals("IsShowCanLightFire"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelCanLightFireProvider.IsShowCanLightFire;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelExpProgressProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelExpProgressProvider ifreeRpg_107000ModelExpProgressProvider = provider as IfreeRpg_107000ModelExpProgressProvider;
					if (method.Equals("SwitchAni"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelExpProgressProvider.SwitchAni;
					}
					if (method.Equals("IsFire"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelExpProgressProvider.IsFire;
					}
					if (method.Equals("SetFirePercentText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelExpProgressProvider.SetFirePercentText;
					}
					if (method.Equals("SetFirePercent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelExpProgressProvider.SetFirePercent;
					}
					if (method.Equals("IsShowExp"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelExpProgressProvider.IsShowExp;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelCanSelectSpecailPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelCanSelectSpecailPlayerProvider ifreeRpg_107000ModelCanSelectSpecailPlayerProvider = provider as IfreeRpg_107000ModelCanSelectSpecailPlayerProvider;
					if (method.Equals("IsShowSelectPlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelCanSelectSpecailPlayerProvider.IsShowSelectPlayer;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelFireStartProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelFireStartProvider ifreeRpg_107000ModelFireStartProvider = provider as IfreeRpg_107000ModelFireStartProvider;
					if (method.Equals("IsShowFireStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelFireStartProvider.IsShowFireStart;
					}
					if (method.Equals("SetPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelFireStartProvider.SetPlayerName;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelSpecailExpSetProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelSpecailExpSetProvider ifreeRpg_107000ModelSpecailExpSetProvider = provider as IfreeRpg_107000ModelSpecailExpSetProvider;
					if (method.Equals("IsShowExpSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSpecailExpSetProvider.IsShowExpSet;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelSelectPlayerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelSelectPlayerProvider ifreeRpg_107000ModelSelectPlayerProvider = provider as IfreeRpg_107000ModelSelectPlayerProvider;
					if (method.Equals("IsShowChoosePlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ifreeRpg_107000ModelSelectPlayerProvider.IsShowChoosePlayer;
					}
					if (method.Equals("ClosePanel"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.ClosePanel;
					}
					if (method.Equals("GetPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelSelectPlayerProvider.GetPlayerName;
					}
					if (method.Equals("IsShowSelectPlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsShowSelectPlayer;
					}
					if (method.Equals("IsSelect1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect1;
					}
					if (method.Equals("SelectPlayer1"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer1;
					}
					if (method.Equals("IsSelect2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect2;
					}
					if (method.Equals("SelectPlayer2"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer2;
					}
					if (method.Equals("IsSelect3"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect3;
					}
					if (method.Equals("SelectPlayer3"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer3;
					}
					if (method.Equals("IsSelect4"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect4;
					}
					if (method.Equals("SelectPlayer4"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer4;
					}
					if (method.Equals("IsSelect5"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect5;
					}
					if (method.Equals("SelectPlayer5"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer5;
					}
					if (method.Equals("IsSelect6"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect6;
					}
					if (method.Equals("SelectPlayer6"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer6;
					}
					if (method.Equals("IsSelect7"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect7;
					}
					if (method.Equals("SelectPlayer7"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer7;
					}
					if (method.Equals("IsSelect8"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect8;
					}
					if (method.Equals("SelectPlayer8"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer8;
					}
					if (method.Equals("IsSelect9"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect9;
					}
					if (method.Equals("SelectPlayer9"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer9;
					}
					if (method.Equals("IsSelect10"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect10;
					}
					if (method.Equals("SelectPlayer10"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer10;
					}
					if (method.Equals("IsSelect11"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect11;
					}
					if (method.Equals("SelectPlayer11"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer11;
					}
					if (method.Equals("IsSelect12"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect12;
					}
					if (method.Equals("SelectPlayer12"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer12;
					}
					if (method.Equals("IsSelect13"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect13;
					}
					if (method.Equals("SelectPlayer13"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer13;
					}
					if (method.Equals("IsSelect14"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect14;
					}
					if (method.Equals("SelectPlayer14"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer14;
					}
					if (method.Equals("IsSelect15"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelSelectPlayerProvider.IsSelect15;
					}
					if (method.Equals("SelectPlayer15"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ifreeRpg_107000ModelSelectPlayerProvider.SelectPlayer15;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IfreeRpg_107000ModelRankProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IfreeRpg_107000ModelRankProvider ifreeRpg_107000ModelRankProvider = provider as IfreeRpg_107000ModelRankProvider;
					if (method.Equals("GetAllDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetAllDamage;
					}
					if (method.Equals("GetRankDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelRankProvider.GetRankDamage;
					}
					if (method.Equals("GetRankName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelRankProvider.GetRankName;
					}
					if (method.Equals("IsRankShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ifreeRpg_107000ModelRankProvider.IsRankShow;
					}
					if (method.Equals("GetSecDamage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetSecDamage;
					}
					if (method.Equals("GetSelfName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetSelfName;
					}
					if (method.Equals("IsRankshow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ifreeRpg_107000ModelRankProvider.IsRankshow;
					}
					if (method.Equals("GetRankTitle"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ifreeRpg_107000ModelRankProvider.GetRankTitle;
					}
					if (method.Equals("GetRefreshTime"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ifreeRpg_107000ModelRankProvider.GetRefreshTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelRoundScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelRoundScoreBoardProvider igoldRankModelRoundScoreBoardProvider = provider as IgoldRankModelRoundScoreBoardProvider;
					if (method.Equals("SetBlueScoreShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelRoundScoreBoardProvider.SetBlueScoreShow;
					}
					if (method.Equals("SetRedScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelRoundScoreBoardProvider.SetRedScore;
					}
					if (method.Equals("SetRoundScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelRoundScoreBoardProvider.SetRoundScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelPlayerNumNotProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelPlayerNumNotProvider igoldRankModelPlayerNumNotProvider = provider as IgoldRankModelPlayerNumNotProvider;
					if (method.Equals("SetPlayerNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelPlayerNumNotProvider.SetPlayerNum;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelPlayerNumNotProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelScoreBoardProvider igoldRankModelScoreBoardProvider = provider as IgoldRankModelScoreBoardProvider;
					if (method.Equals("SetBlueTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelScoreBoardProvider.SetBlueTeamNum;
					}
					if (method.Equals("GetPrediction"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igoldRankModelScoreBoardProvider.GetPrediction;
					}
					if (method.Equals("SetRedTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelScoreBoardProvider.SetRedTeamNum;
					}
					if (method.Equals("SetHpNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelScoreBoardProvider.SetHpNum;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelScoreBoardProvider.SetProgressBar;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelScoreBoardProvider.SetRoundTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelStartTimerProvider igoldRankModelStartTimerProvider = provider as IgoldRankModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelEndTimerProvider igoldRankModelEndTimerProvider = provider as IgoldRankModelEndTimerProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelEndTimerProvider.IsShow;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igoldRankModelEndTimerProvider.SetTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelBagPreviewProvider igoldRankModelBagPreviewProvider = provider as IgoldRankModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igoldRankModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igoldRankModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelRoundReviewProvider igoldRankModelRoundReviewProvider = provider as IgoldRankModelRoundReviewProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelRoundReviewProvider.IsShow;
					}
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igoldRankModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igoldRankModelRoundReviewProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgoldRankModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgoldRankModelRandomEffectProvider igoldRankModelRandomEffectProvider = provider as IgoldRankModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igoldRankModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igoldRankModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igoldRankModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelRoundScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelRoundScoreBoardProvider igunFightModelRoundScoreBoardProvider = provider as IgunFightModelRoundScoreBoardProvider;
					if (method.Equals("SetBlueScoreShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelRoundScoreBoardProvider.SetBlueScoreShow;
					}
					if (method.Equals("SetRedScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelRoundScoreBoardProvider.SetRedScore;
					}
					if (method.Equals("SetRoundScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelRoundScoreBoardProvider.SetRoundScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelPlayerNumNotProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelPlayerNumNotProvider igunFightModelPlayerNumNotProvider = provider as IgunFightModelPlayerNumNotProvider;
					if (method.Equals("SetPlayerNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelPlayerNumNotProvider.SetPlayerNum;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelPlayerNumNotProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelScoreBoardProvider igunFightModelScoreBoardProvider = provider as IgunFightModelScoreBoardProvider;
					if (method.Equals("SetBlueTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelScoreBoardProvider.SetBlueTeamNum;
					}
					if (method.Equals("GetPrediction"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igunFightModelScoreBoardProvider.GetPrediction;
					}
					if (method.Equals("SetRedTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelScoreBoardProvider.SetRedTeamNum;
					}
					if (method.Equals("SetHpNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelScoreBoardProvider.SetHpNum;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelScoreBoardProvider.SetProgressBar;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelScoreBoardProvider.SetRoundTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelStartTimerProvider igunFightModelStartTimerProvider = provider as IgunFightModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelEndTimerProvider igunFightModelEndTimerProvider = provider as IgunFightModelEndTimerProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelEndTimerProvider.IsShow;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = igunFightModelEndTimerProvider.SetTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelBagPreviewProvider igunFightModelBagPreviewProvider = provider as IgunFightModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igunFightModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igunFightModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelRoundReviewProvider igunFightModelRoundReviewProvider = provider as IgunFightModelRoundReviewProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelRoundReviewProvider.IsShow;
					}
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = igunFightModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = igunFightModelRoundReviewProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IgunFightModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IgunFightModelRandomEffectProvider igunFightModelRandomEffectProvider = provider as IgunFightModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = igunFightModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = igunFightModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = igunFightModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IhighSpeedGroupModelHighSpeedGroupSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IhighSpeedGroupModelHighSpeedGroupSkillProvider ihighSpeedGroupModelHighSpeedGroupSkillProvider = provider as IhighSpeedGroupModelHighSpeedGroupSkillProvider;
					if (method.Equals("getSkillUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ihighSpeedGroupModelHighSpeedGroupSkillProvider.getSkillUrl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelRoundScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelRoundScoreBoardProvider iknifeFightModelRoundScoreBoardProvider = provider as IknifeFightModelRoundScoreBoardProvider;
					if (method.Equals("SetBlueScoreShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelRoundScoreBoardProvider.SetBlueScoreShow;
					}
					if (method.Equals("SetRedScore"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelRoundScoreBoardProvider.SetRedScore;
					}
					if (method.Equals("SetRoundScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelRoundScoreBoardProvider.SetRoundScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelPlayerNumNotProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelPlayerNumNotProvider iknifeFightModelPlayerNumNotProvider = provider as IknifeFightModelPlayerNumNotProvider;
					if (method.Equals("SetPlayerNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelPlayerNumNotProvider.SetPlayerNum;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelPlayerNumNotProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelScoreBoardProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelScoreBoardProvider iknifeFightModelScoreBoardProvider = provider as IknifeFightModelScoreBoardProvider;
					if (method.Equals("SetBlueTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelScoreBoardProvider.SetBlueTeamNum;
					}
					if (method.Equals("GetPrediction"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iknifeFightModelScoreBoardProvider.GetPrediction;
					}
					if (method.Equals("SetRedTeamNum"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelScoreBoardProvider.SetRedTeamNum;
					}
					if (method.Equals("SetHpNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelScoreBoardProvider.SetHpNum;
					}
					if (method.Equals("SetProgressBar"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelScoreBoardProvider.SetProgressBar;
					}
					if (method.Equals("SetRoundTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelScoreBoardProvider.SetRoundTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelStartTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelStartTimerProvider iknifeFightModelStartTimerProvider = provider as IknifeFightModelStartTimerProvider;
					if (method.Equals("SetStartTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelStartTimerProvider.SetStartTimer;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelStartTimerProvider.IsShow;
					}
					if (method.Equals("IsMessageShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelStartTimerProvider.IsMessageShow;
					}
					if (method.Equals("IsTimerShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelStartTimerProvider.IsTimerShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelEndTimerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelEndTimerProvider iknifeFightModelEndTimerProvider = provider as IknifeFightModelEndTimerProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelEndTimerProvider.IsShow;
					}
					if (method.Equals("SetProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelEndTimerProvider.SetProgress;
					}
					if (method.Equals("SetTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = iknifeFightModelEndTimerProvider.SetTime;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelBagPreviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelBagPreviewProvider iknifeFightModelBagPreviewProvider = provider as IknifeFightModelBagPreviewProvider;
					if (method.Equals("IsShowView"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelBagPreviewProvider.IsShowView;
					}
					if (method.Equals("SetWeaponView"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iknifeFightModelBagPreviewProvider.SetWeaponView;
					}
					if (method.Equals("SetWeaponName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iknifeFightModelBagPreviewProvider.SetWeaponName;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelBagPreviewProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelRoundReviewProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelRoundReviewProvider iknifeFightModelRoundReviewProvider = provider as IknifeFightModelRoundReviewProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelRoundReviewProvider.IsShow;
					}
					if (method.Equals("SetMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = iknifeFightModelRoundReviewProvider.SetMessage;
					}
					if (method.Equals("SetScore"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iknifeFightModelRoundReviewProvider.SetScore;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IknifeFightModelRandomEffectProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IknifeFightModelRandomEffectProvider iknifeFightModelRandomEffectProvider = provider as IknifeFightModelRandomEffectProvider;
					if (method.Equals("CanSet"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = iknifeFightModelRandomEffectProvider.CanSet;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iknifeFightModelRandomEffectProvider.SetImage;
					}
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iknifeFightModelRandomEffectProvider.IsShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelmechKingMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ImechKingModelmechKingMessageProvider imechKingModelmechKingMessageProvider = provider as ImechKingModelmechKingMessageProvider;
					if (method.Equals("isShowHuamn"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingMessageProvider.isShowHuamn;
					}
					if (method.Equals("isShowMech"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingMessageProvider.isShowMech;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelmechKingPromptProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ImechKingModelmechKingPromptProvider imechKingModelmechKingPromptProvider = provider as ImechKingModelmechKingPromptProvider;
					if (method.Equals("showWeapon"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingPromptProvider.showWeapon;
					}
					if (method.Equals("showStart"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingPromptProvider.showStart;
					}
					if (method.Equals("showNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingPromptProvider.showNumber;
					}
					if (method.Equals("setNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingPromptProvider.setNumber;
					}
					if (method.Equals("setStartNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingPromptProvider.setStartNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelReliveProcessProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ImechKingModelReliveProcessProvider imechKingModelReliveProcessProvider = provider as ImechKingModelReliveProcessProvider;
					if (method.Equals("showPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelReliveProcessProvider.showPoint;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelReliveProcessProvider.setProgress;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelReliveProcessProvider.isShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<ImechKingModelmechKingSkillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					ImechKingModelmechKingSkillProvider imechKingModelmechKingSkillProvider = provider as ImechKingModelmechKingSkillProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = imechKingModelmechKingSkillProvider.changeImage;
					}
					if (method.Equals("changeFImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = imechKingModelmechKingSkillProvider.changeFImage;
					}
					if (method.Equals("setProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.setProgress;
					}
					if (method.Equals("setFlyProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.setFlyProgress;
					}
					if (method.Equals("setRotationProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.setRotationProgress;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = imechKingModelmechKingSkillProvider.isShow;
					}
					if (method.Equals("showExp"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showExp;
					}
					if (method.Equals("showMaxExp"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showMaxExp;
					}
					if (method.Equals("showLv"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showLv;
					}
					if (method.Equals("showNumber"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = imechKingModelmechKingSkillProvider.showNumber;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooTeamScoreGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooTeamScoreGUIProvider ipeekabooModelPeekAbooTeamScoreGUIProvider = provider as IpeekabooModelPeekAbooTeamScoreGUIProvider;
					if (method.Equals("updateTextInfo"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooTeamScoreGUIProvider.updateTextInfo;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooLikesGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooLikesGUIProvider ipeekabooModelPeekAbooLikesGUIProvider = provider as IpeekabooModelPeekAbooLikesGUIProvider;
					if (method.Equals("checkLikesShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooLikesGUIProvider.checkLikesShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooStarsItemGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooStarsItemGUIProvider ipeekabooModelPeekAbooStarsItemGUIProvider = provider as IpeekabooModelPeekAbooStarsItemGUIProvider;
					if (method.Equals("updateConAddVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateConAddVisible;
					}
					if (method.Equals("updateConAddY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateConAddY;
					}
					if (method.Equals("updateItemEffectVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectVisible;
					}
					if (method.Equals("updateItemEffectSize"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectSize;
					}
					if (method.Equals("updateItemEffectX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectX;
					}
					if (method.Equals("updateItemEffectY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateItemEffectY;
					}
					if (method.Equals("updateImgItemMoveVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgItemMoveVisible;
					}
					if (method.Equals("updateMoveX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateMoveX;
					}
					if (method.Equals("updateMoveY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateMoveY;
					}
					if (method.Equals("updateImgItemVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgItemVisible;
					}
					if (method.Equals("updateImgItem"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgItem;
					}
					if (method.Equals("updateImgLiveVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateImgLiveVisible;
					}
					if (method.Equals("updateStarProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateStarProgress;
					}
					if (method.Equals("updateAddStarCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateAddStarCount;
					}
					if (method.Equals("updateStarCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooStarsItemGUIProvider.updateStarCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooMessageGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooMessageGUIProvider ipeekabooModelPeekAbooMessageGUIProvider = provider as IpeekabooModelPeekAbooMessageGUIProvider;
					if (method.Equals("updateSelfMessageVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateSelfMessageVisible;
					}
					if (method.Equals("updateImgSpecialVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgSpecialVisible;
					}
					if (method.Equals("updateSpecialSize"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooMessageGUIProvider.updateSpecialSize;
					}
					if (method.Equals("updateImgSpecialX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgSpecialX;
					}
					if (method.Equals("updateImgSpecialY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgSpecialY;
					}
					if (method.Equals("updateImgStartGameVisile"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgStartGameVisile;
					}
					if (method.Equals("updateImgStartGame"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooMessageGUIProvider.updateImgStartGame;
					}
					if (method.Equals("updateTxtTimeRedVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeRedVisible;
					}
					if (method.Equals("updateTime"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTime;
					}
					if (method.Equals("updateTxtTimeX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeX;
					}
					if (method.Equals("updateTxtTimeY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeY;
					}
					if (method.Equals("updateTxtTimeVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtTimeVisible;
					}
					if (method.Equals("updateTxtPlayerCountVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtPlayerCountVisible;
					}
					if (method.Equals("updateTxtWaitPlayer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooMessageGUIProvider.updateTxtWaitPlayer;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooGameOverGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooGameOverGUIProvider ipeekabooModelPeekAbooGameOverGUIProvider = provider as IpeekabooModelPeekAbooGameOverGUIProvider;
					if (method.Equals("updateSurviveVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateSurviveVisible;
					}
					if (method.Equals("updateItemContainerVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateItemContainerVisible;
					}
					if (method.Equals("updateWinItemVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateWinItemVisible;
					}
					if (method.Equals("updateConWinX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateConWinX;
					}
					if (method.Equals("updateImgWinSrc"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateImgWinSrc;
					}
					if (method.Equals("updateImgItemVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateImgItemVisible;
					}
					if (method.Equals("updateImgItemSrcByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateImgItemSrcByIndex;
					}
					if (method.Equals("updateRootVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateRootVisible;
					}
					if (method.Equals("updateTxtNameVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateTxtNameVisible;
					}
					if (method.Equals("updateTxtNameByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooGameOverGUIProvider.updateTxtNameByIndex;
					}
					if (method.Equals("updateSurviveCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = ipeekabooModelPeekAbooGameOverGUIProvider.updateSurviveCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooByLikesGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooByLikesGUIProvider ipeekabooModelPeekAbooByLikesGUIProvider = provider as IpeekabooModelPeekAbooByLikesGUIProvider;
					if (method.Equals("updateImgVisibleByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgVisibleByIndex;
					}
					if (method.Equals("updateImgSrc"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgSrc;
					}
					if (method.Equals("updateImgSize"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgSize;
					}
					if (method.Equals("updateImgX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgX;
					}
					if (method.Equals("updateImgY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = ipeekabooModelPeekAbooByLikesGUIProvider.updateImgY;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooHumanityBackGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooHumanityBackGUIProvider ipeekabooModelPeekAbooHumanityBackGUIProvider = provider as IpeekabooModelPeekAbooHumanityBackGUIProvider;
					if (method.Equals("updateRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooHumanityBackGUIProvider.updateRootShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IpeekabooModelPeekAbooSceneItemControlStateGUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IpeekabooModelPeekAbooSceneItemControlStateGUIProvider ipeekabooModelPeekAbooSceneItemControlStateGUIProvider = provider as IpeekabooModelPeekAbooSceneItemControlStateGUIProvider;
					if (method.Equals("updateTipShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateTipShow;
					}
					if (method.Equals("updateTipSrc"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateTipSrc;
					}
					if (method.Equals("updateEStarCountInfo"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateEStarCountInfo;
					}
					if (method.Equals("updateConEVisible"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = ipeekabooModelPeekAbooSceneItemControlStateGUIProvider.updateConEVisible;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IprotectBigHeadModelProtectBigHeadCareerUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IprotectBigHeadModelProtectBigHeadCareerUIProvider iprotectBigHeadModelProtectBigHeadCareerUIProvider = provider as IprotectBigHeadModelProtectBigHeadCareerUIProvider;
					if (method.Equals("updateBarByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateBarByIndex;
					}
					if (method.Equals("updateHpByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateHpByIndex;
					}
					if (method.Equals("updateMaxHpByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateMaxHpByIndex;
					}
					if (method.Equals("updateCareerIconByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateCareerIconByIndex;
					}
					if (method.Equals("rootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iprotectBigHeadModelProtectBigHeadCareerUIProvider.rootShow;
					}
					if (method.Equals("updateNameByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = iprotectBigHeadModelProtectBigHeadCareerUIProvider.updateNameByIndex;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IprotectBigHeadModelProtectBigheadTipsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IprotectBigHeadModelProtectBigheadTipsUIProvider iprotectBigHeadModelProtectBigheadTipsUIProvider = provider as IprotectBigHeadModelProtectBigheadTipsUIProvider;
					if (method.Equals("tipShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = iprotectBigHeadModelProtectBigheadTipsUIProvider.tipShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgArmamentModelRpgArmamentMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgArmamentModelRpgArmamentMessageProvider irpgArmamentModelRpgArmamentMessageProvider = provider as IrpgArmamentModelRpgArmamentMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgArmamentModelRpgArmamentMessageProvider.isShowMessage;
					}
					if (method.Equals("pickInfoShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgArmamentModelRpgArmamentMessageProvider.pickInfoShow;
					}
					if (method.Equals("pickInfoText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgArmamentModelRpgArmamentMessageProvider.pickInfoText;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgArmamentModelRpgArmamentMyPointProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgArmamentModelRpgArmamentMyPointProvider irpgArmamentModelRpgArmamentMyPointProvider = provider as IrpgArmamentModelRpgArmamentMyPointProvider;
					if (method.Equals("updateMaxPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgArmamentModelRpgArmamentMyPointProvider.updateMaxPoint;
					}
					if (method.Equals("updateMyPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgArmamentModelRpgArmamentMyPointProvider.updateMyPoint;
					}
					if (method.Equals("isShowMessae"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgArmamentModelRpgArmamentMyPointProvider.isShowMessae;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgBaseRunModelRpgBaseRunProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgBaseRunModelRpgBaseRunProgressUIProvider irpgBaseRunModelRpgBaseRunProgressUIProvider = provider as IrpgBaseRunModelRpgBaseRunProgressUIProvider;
					if (method.Equals("checkRpgBaseRunUIShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.checkRpgBaseRunUIShow;
					}
					if (method.Equals("getBoxNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.getBoxNum;
					}
					if (method.Equals("changeBoxImg"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.changeBoxImg;
					}
					if (method.Equals("getProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunProgressUIProvider.getProgress;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgBaseRunModelRpgBaseRunTaskUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgBaseRunModelRpgBaseRunTaskUIProvider irpgBaseRunModelRpgBaseRunTaskUIProvider = provider as IrpgBaseRunModelRpgBaseRunTaskUIProvider;
					if (method.Equals("IsItemShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.IsItemShowByIndex;
					}
					if (method.Equals("checkTaskUIShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.checkTaskUIShow;
					}
					if (method.Equals("IsItemAddDiByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.IsItemAddDiByIndex;
					}
					if (method.Equals("updateTaskNameByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTaskNameByIndex;
					}
					if (method.Equals("updateAddNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateAddNum;
					}
					if (method.Equals("updateMulNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateMulNum;
					}
					if (method.Equals("updatePercentNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updatePercentNum;
					}
					if (method.Equals("updateTaskProgressByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTaskProgressByIndex;
					}
					if (method.Equals("updateTaskScoreByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTaskScoreByIndex;
					}
					if (method.Equals("updateTotalNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateTotalNum;
					}
					if (method.Equals("updateLvl"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgBaseRunModelRpgBaseRunTaskUIProvider.updateLvl;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgDanrenMineModelDamageCountProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgDanrenMineModelDamageCountProvider irpgDanrenMineModelDamageCountProvider = provider as IrpgDanrenMineModelDamageCountProvider;
					if (method.Equals("GetDamageCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgDanrenMineModelDamageCountProvider.GetDamageCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgHolidayModelskillProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgHolidayModelskillProvider irpgHolidayModelskillProvider = provider as IrpgHolidayModelskillProvider;
					if (method.Equals("changeImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgHolidayModelskillProvider.changeImage;
					}
					if (method.Equals("isShowSkill"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgHolidayModelskillProvider.isShowSkill;
					}
					if (method.Equals("showNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgHolidayModelskillProvider.showNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgLootMineModelRpgLootMineMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgLootMineModelRpgLootMineMessageProvider irpgLootMineModelRpgLootMineMessageProvider = provider as IrpgLootMineModelRpgLootMineMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgLootMineModelRpgLootMineMessageProvider.isShowMessage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgLootModelPlayerGetFlagProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgLootModelPlayerGetFlagProvider irpgLootModelPlayerGetFlagProvider = provider as IrpgLootModelPlayerGetFlagProvider;
					if (method.Equals("getCurrent"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgLootModelPlayerGetFlagProvider.getCurrent;
					}
					if (method.Equals("getMax"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgLootModelPlayerGetFlagProvider.getMax;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgLootModelMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgLootModelMessageProvider irpgLootModelMessageProvider = provider as IrpgLootModelMessageProvider;
					if (method.Equals("isShowNoOccupy"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgLootModelMessageProvider.isShowNoOccupy;
					}
					if (method.Equals("isShowGetMoreFlag"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgLootModelMessageProvider.isShowGetMoreFlag;
					}
					if (method.Equals("isShowGetFlagWin"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgLootModelMessageProvider.isShowGetFlagWin;
					}
					if (method.Equals("getFlagWinCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgLootModelMessageProvider.getFlagWinCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelrpgplayerbufferProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelrpgplayerbufferProvider irpgModelrpgplayerbufferProvider = provider as IrpgModelrpgplayerbufferProvider;
					if (method.Equals("IsBufferItemShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelrpgplayerbufferProvider.IsBufferItemShow;
					}
					if (method.Equals("RefreshBufferItemAlpha"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelrpgplayerbufferProvider.RefreshBufferItemAlpha;
					}
					if (method.Equals("RefreshBufferIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelrpgplayerbufferProvider.RefreshBufferIcon;
					}
					if (method.Equals("IsRpgBufferShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelrpgplayerbufferProvider.IsRpgBufferShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelSkatingMechaModelProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelSkatingMechaModelProvider irpgModelSkatingMechaModelProvider = provider as IrpgModelSkatingMechaModelProvider;
					if (method.Equals("SetFuelValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelSkatingMechaModelProvider.SetFuelValue;
					}
					if (method.Equals("IsSkatingMechaModelShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelSkatingMechaModelProvider.IsSkatingMechaModelShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelSkatingMechaModelInfoProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelSkatingMechaModelInfoProvider irpgModelSkatingMechaModelInfoProvider = provider as IrpgModelSkatingMechaModelInfoProvider;
					if (method.Equals("SetHpValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelSkatingMechaModelInfoProvider.SetHpValue;
					}
					if (method.Equals("SetRanliaoValue"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelSkatingMechaModelInfoProvider.SetRanliaoValue;
					}
					if (method.Equals("IsSkatingMechaModelShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelSkatingMechaModelInfoProvider.IsSkatingMechaModelShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelBlackScreenProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelBlackScreenProvider irpgModelBlackScreenProvider = provider as IrpgModelBlackScreenProvider;
					if (method.Equals("IsBlackScreenShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBlackScreenProvider.IsBlackScreenShow;
					}
					if (method.Equals("setBlackScreen"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBlackScreenProvider.setBlackScreen;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelRpgBuffsProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelRpgBuffsProvider irpgModelRpgBuffsProvider = provider as IrpgModelRpgBuffsProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelRpgBuffsProvider.IsShow;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelRpgBuffsProvider.SetImage;
					}
					if (method.Equals("IsTextShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelRpgBuffsProvider.IsTextShow;
					}
					if (method.Equals("SetText"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelRpgBuffsProvider.SetText;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelGameUITipsTimeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelGameUITipsTimeProvider irpgModelGameUITipsTimeProvider = provider as IrpgModelGameUITipsTimeProvider;
					if (method.Equals("IsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelGameUITipsTimeProvider.IsShow;
					}
					if (method.Equals("ShowBackUI"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelGameUITipsTimeProvider.ShowBackUI;
					}
					if (method.Equals("showNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelGameUITipsTimeProvider.showNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelNezhaNengliangProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelNezhaNengliangProvider irpgModelNezhaNengliangProvider = provider as IrpgModelNezhaNengliangProvider;
					if (method.Equals("isDou1Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDou1Show;
					}
					if (method.Equals("isDou2Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDou2Show;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isShow;
					}
					if (method.Equals("isDou3Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDou3Show;
					}
					if (method.Equals("isDouuse1Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDouuse1Show;
					}
					if (method.Equals("isDouuse2Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDouuse2Show;
					}
					if (method.Equals("isDouuse3Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelNezhaNengliangProvider.isDouuse3Show;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelBossDescribeProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelBossDescribeProvider irpgModelBossDescribeProvider = provider as IrpgModelBossDescribeProvider;
					if (method.Equals("getBossBaseY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getBossBaseY;
					}
					if (method.Equals("getBossName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getBossName;
					}
					if (method.Equals("getBossTitleUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getBossTitleUrl;
					}
					if (method.Equals("isShowBossType"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.isShowBossType;
					}
					if (method.Equals("getBossType"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getBossType;
					}
					if (method.Equals("getCritdefUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getCritdefUrl;
					}
					if (method.Equals("getCritrateUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getCritrateUrl;
					}
					if (method.Equals("getExtraordinaryCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelBossDescribeProvider.getExtraordinaryCount;
					}
					if (method.Equals("showExtraordinaryIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showExtraordinaryIcon;
					}
					if (method.Equals("getHpLeft"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getHpLeft;
					}
					if (method.Equals("showHpRight"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.showHpRight;
					}
					if (method.Equals("getHpRight"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getHpRight;
					}
					if (method.Equals("isShowHpType"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.isShowHpType;
					}
					if (method.Equals("getHpTypeUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getHpTypeUrl;
					}
					if (method.Equals("getHpTypeLockUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getHpTypeLockUrl;
					}
					if (method.Equals("getHpWordUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getHpWordUrl;
					}
					if (method.Equals("getHujiaUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getHujiaUrl;
					}
					if (method.Equals("getLichangUrl"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getLichangUrl;
					}
					if (method.Equals("isShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.isShow;
					}
					if (method.Equals("showSkillBack1"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillBack1;
					}
					if (method.Equals("showSkillBack2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillBack2;
					}
					if (method.Equals("getSkillName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getSkillName;
					}
					if (method.Equals("showSkillPage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillPage;
					}
					if (method.Equals("getSkillPageY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelBossDescribeProvider.getSkillPageY;
					}
					if (method.Equals("getSkillTitle1"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getSkillTitle1;
					}
					if (method.Equals("showSkillTitle2"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelBossDescribeProvider.showSkillTitle2;
					}
					if (method.Equals("getSkillTitle2"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelBossDescribeProvider.getSkillTitle2;
					}
					if (method.Equals("getYangDunType"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getYangDunType;
					}
					if (method.Equals("showYangDun"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.showYangDun;
					}
					if (method.Equals("getYinDunType"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgModelBossDescribeProvider.getYinDunType;
					}
					if (method.Equals("showYinDun"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgModelBossDescribeProvider.showYinDun;
					}
					if (method.Equals("getExtraordinaryValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgModelBossDescribeProvider.getExtraordinaryValue;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelrpglongqibingbufferProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelrpglongqibingbufferProvider irpgModelrpglongqibingbufferProvider = provider as IrpgModelrpglongqibingbufferProvider;
					if (method.Equals("Show"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelrpglongqibingbufferProvider.Show;
					}
					if (method.Equals("GetLevel"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelrpglongqibingbufferProvider.GetLevel;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelextraordinaryProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelextraordinaryProvider irpgModelextraordinaryProvider = provider as IrpgModelextraordinaryProvider;
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelextraordinaryProvider.SetImage;
					}
					if (method.Equals("SetValue"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelextraordinaryProvider.SetValue;
					}
					if (method.Equals("SetShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelextraordinaryProvider.SetShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgModelETPowerProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgModelETPowerProvider irpgModelETPowerProvider = provider as IrpgModelETPowerProvider;
					if (method.Equals("SetShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelETPowerProvider.SetShow;
					}
					if (method.Equals("SetImage"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelETPowerProvider.SetImage;
					}
					if (method.Equals("SetValue"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelETPowerProvider.SetValue;
					}
					if (method.Equals("GetFrameShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelETPowerProvider.GetFrameShow;
					}
					if (method.Equals("GetNumShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgModelETPowerProvider.GetNumShow;
					}
					if (method.Equals("GetCDTimer"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgModelETPowerProvider.GetCDTimer;
					}
					if (method.Equals("GetCDTimerDes"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValueIndex = irpgModelETPowerProvider.GetCDTimerDes;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgSplitSecondmessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgSplitSecondmessageProvider irpgSplitSecondmessageProvider = provider as IrpgSplitSecondmessageProvider;
					if (method.Equals("IsShowCancelCollsion"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgSplitSecondmessageProvider.IsShowCancelCollsion;
					}
					if (method.Equals("IsShowGetSpeed"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgSplitSecondmessageProvider.IsShowGetSpeed;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgSplitSecondariverPointProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgSplitSecondariverPointProvider irpgSplitSecondariverPointProvider = provider as IrpgSplitSecondariverPointProvider;
					if (method.Equals("GetFirstPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgSplitSecondariverPointProvider.GetFirstPoint;
					}
					if (method.Equals("GetAllPoint"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgSplitSecondariverPointProvider.GetAllPoint;
					}
					if (method.Equals("GetRank"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgSplitSecondariverPointProvider.GetRank;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerBoxProbUIProvider;
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider.checkShow;
					}
					if (method.Equals("getProb"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider.getProb;
					}
					if (method.Equals("barShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgStarWalkerModelRpgStarWalkerBoxProbUIProvider.barShowByIndex;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStarWalkerModelRpgStarWalkerProgressUIProvider irpgStarWalkerModelRpgStarWalkerProgressUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerProgressUIProvider;
					if (method.Equals("getIconBossY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getIconBossY;
					}
					if (method.Equals("getIconExitY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getIconExitY;
					}
					if (method.Equals("getNumInfection"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getNumInfection;
					}
					if (method.Equals("getInfectionRate"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.getInfectionRate;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerProgressUIProvider.checkShow;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerTargetUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStarWalkerModelRpgStarWalkerTargetUIProvider irpgStarWalkerModelRpgStarWalkerTargetUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerTargetUIProvider;
					if (method.Equals("getCurProtectNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerTargetUIProvider.getCurProtectNum;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTargetUIProvider.checkShow;
					}
					if (method.Equals("getTotalProtectNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerTargetUIProvider.getTotalProtectNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStarWalkerModelRpgStarWalkerTipsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStarWalkerModelRpgStarWalkerTipsUIProvider irpgStarWalkerModelRpgStarWalkerTipsUIProvider = provider as IrpgStarWalkerModelRpgStarWalkerTipsUIProvider;
					if (method.Equals("infectionIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.infectionIsShow;
					}
					if (method.Equals("getNumInfection"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.getNumInfection;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.checkShow;
					}
					if (method.Equals("playerNameIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.playerNameIsShow;
					}
					if (method.Equals("getPlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.getPlayerName;
					}
					if (method.Equals("tipShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgStarWalkerModelRpgStarWalkerTipsUIProvider.tipShowByIndex;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStralExpertModelRpgStralExpertMessageProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStralExpertModelRpgStralExpertMessageProvider irpgStralExpertModelRpgStralExpertMessageProvider = provider as IrpgStralExpertModelRpgStralExpertMessageProvider;
					if (method.Equals("isShowMessage"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgStralExpertModelRpgStralExpertMessageProvider.isShowMessage;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStralExpertModelRpgStralExpertMaterialProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStralExpertModelRpgStralExpertMaterialProvider irpgStralExpertModelRpgStralExpertMaterialProvider = provider as IrpgStralExpertModelRpgStralExpertMaterialProvider;
					if (method.Equals("getCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgStralExpertModelRpgStralExpertMaterialProvider.getCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgStralExpertModelRpgStralExpertSelfTeamProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgStralExpertModelRpgStralExpertSelfTeamProvider irpgStralExpertModelRpgStralExpertSelfTeamProvider = provider as IrpgStralExpertModelRpgStralExpertSelfTeamProvider;
					if (method.Equals("getTeamId"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgStralExpertModelRpgStralExpertSelfTeamProvider.getTeamId;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTanlanModelRpgTanlanProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgTanlanModelRpgTanlanProgressUIProvider irpgTanlanModelRpgTanlanProgressUIProvider = provider as IrpgTanlanModelRpgTanlanProgressUIProvider;
					if (method.Equals("updateProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTanlanModelRpgTanlanProgressUIProvider.updateProgress;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanProgressUIProvider.checkShow;
					}
					if (method.Equals("updateIcon"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgTanlanModelRpgTanlanProgressUIProvider.updateIcon;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTanlanModelRpgTanlanTargetUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgTanlanModelRpgTanlanTargetUIProvider irpgTanlanModelRpgTanlanTargetUIProvider = provider as IrpgTanlanModelRpgTanlanTargetUIProvider;
					if (method.Equals("updateCurNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTanlanModelRpgTanlanTargetUIProvider.updateCurNum;
					}
					if (method.Equals("isTimeTip"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanTargetUIProvider.isTimeTip;
					}
					if (method.Equals("updateLabel"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgTanlanModelRpgTanlanTargetUIProvider.updateLabel;
					}
					if (method.Equals("checkNumShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanTargetUIProvider.checkNumShow;
					}
					if (method.Equals("checkShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTanlanModelRpgTanlanTargetUIProvider.checkShow;
					}
					if (method.Equals("updateTotalNum"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTanlanModelRpgTanlanTargetUIProvider.updateTotalNum;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossBtnCsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgTreasureBossModelTreasureBossBtnCsUIProvider irpgTreasureBossModelTreasureBossBtnCsUIProvider = provider as IrpgTreasureBossModelTreasureBossBtnCsUIProvider;
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossBtnCsUIProvider.checkRootShow;
					}
					if (method.Equals("skillIsActive"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossBtnCsUIProvider.skillIsActive;
					}
					if (method.Equals("getSkillCd"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossBtnCsUIProvider.getSkillCd;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider irpgTreasureBossModelTreasureBossDayLightProgressUIProvider = provider as IrpgTreasureBossModelTreasureBossDayLightProgressUIProvider;
					if (method.Equals("checkIsDay"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossDayLightProgressUIProvider.checkIsDay;
					}
					if (method.Equals("updateProgress"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossDayLightProgressUIProvider.updateProgress;
					}
					if (method.Equals("getKeyCount"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossDayLightProgressUIProvider.getKeyCount;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossChuansongUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgTreasureBossModelTreasureBossChuansongUIProvider irpgTreasureBossModelTreasureBossChuansongUIProvider = provider as IrpgTreasureBossModelTreasureBossChuansongUIProvider;
					if (method.Equals("checkBtnShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.checkBtnShow;
					}
					if (method.Equals("updateBtnX"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.updateBtnX;
					}
					if (method.Equals("updateBtnY"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.updateBtnY;
					}
					if (method.Equals("btnIconClick"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValueIndex = irpgTreasureBossModelTreasureBossChuansongUIProvider.btnIconClick;
					}
					if (method.Equals("checkRootShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossChuansongUIProvider.checkRootShow;
					}
					if (method.Equals("hideView"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossChuansongUIProvider.hideView;
					}
				}
				if (BattleSingletonInstance<DataProviderManager>.Instance.ImplementsInterface<IrpgTreasureBossModelTreasureBossTipsUIProvider>(provider.GetType()) && provider.GetType().Name.Contains(bindingObjName))
				{
					IrpgTreasureBossModelTreasureBossTipsUIProvider irpgTreasureBossModelTreasureBossTipsUIProvider = provider as IrpgTreasureBossModelTreasureBossTipsUIProvider;
					if (method.Equals("tipShowByIndex"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValueIndex = irpgTreasureBossModelTreasureBossTipsUIProvider.tipShowByIndex;
					}
					if (method.Equals("tipBtnBIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossTipsUIProvider.tipBtnBIsShow;
					}
					if (method.Equals("tipEnterRoomIsShow"))
					{
						runTimeDataArithmeticFuncNamager.GetBoolValue = irpgTreasureBossModelTreasureBossTipsUIProvider.tipEnterRoomIsShow;
					}
					if (method.Equals("updateCbtLvl"))
					{
						runTimeDataArithmeticFuncNamager.GetFloatValue = irpgTreasureBossModelTreasureBossTipsUIProvider.updateCbtLvl;
					}
					if (method.Equals("updatePlayerName"))
					{
						runTimeDataArithmeticFuncNamager.GetStringValue = irpgTreasureBossModelTreasureBossTipsUIProvider.updatePlayerName;
					}
				}
			}
		}
		return runTimeDataArithmeticFuncNamager.GetFloatValue;
	}
}
