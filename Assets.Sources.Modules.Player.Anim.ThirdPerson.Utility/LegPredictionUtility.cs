using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player.Anims;
using SSJJAnim.AnimState;
using SSJJAnim.CareerAnim;
using SSJJBase.Manager;
using SSJJUserCmd;
using share.constant;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.Utility;

public class LegPredictionUtility
{
	public static void CommonResetLegInfo(LegAnimComponent legComp, ILegAnimStateInfo legInfo, ICareerInfo careerInfo, IEntitsWeaponInfo weaponInfo)
	{
		if (legInfo != null)
		{
			legComp.LegsAnimInfo = legInfo;
			legComp.ScaledEclipsedTime = 0;
			ICareerAnimInfo careerAnimInfo = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(careerInfo);
			if (careerAnimInfo != null)
			{
				legComp.RemainTime = careerAnimInfo.GetLegsAnimDuration(weaponInfo, legComp.LegsAnimInfo.StateId);
			}
			else
			{
				legComp.RemainTime = 0;
			}
		}
	}

	public static void DuckPredication(PlayerEntity myPlayer, ILegAnimStateInfo legInfo, LegAnimComponent animComp)
	{
		int duckState = myPlayer.move.DuckState;
		ILegAnimStateInfo legAnimStateInfo = null;
		if (duckState != 3)
		{
			if (legInfo.StateId == 7)
			{
				legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(8);
				CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
			}
			else if (legInfo.StateId == 3 || legInfo.StateId == 1)
			{
				legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(9);
				CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
			}
			else if (legInfo.StateId == 4 || legInfo.StateId == 2)
			{
				legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(10);
				CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
			}
		}
		else if (legInfo.StateId == 8)
		{
			legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(7);
			CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
		}
		else if (legInfo.StateId == 9)
		{
			legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(3);
			CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
		}
		else if (legInfo.StateId == 10)
		{
			legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(4);
			CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
		}
	}

	private static bool IsRunning(PlayerEntity playerEntity, IUserCmd cmd)
	{
		if (!playerEntity.HasStatus(PlayerInfoStatusConstant.NOWALK.ID) && ((uint)cmd.Buttons & 0x10u) != 0)
		{
			return false;
		}
		if (playerEntity.move.Velocity2D > 310)
		{
			return true;
		}
		return false;
	}

	public static void CommonLegPredication(PlayerEntity myPlayer, LegAnimComponent animComp, IUserCmd cmd)
	{
		bool flag = (cmd.Buttons & 2) > 0;
		ILegAnimStateInfo legAnimStateInfo = null;
		int stateId = animComp.LegsAnimInfo.StateId;
		if (stateId <= 327)
		{
			if (stateId <= 11)
			{
				if ((uint)(stateId - 5) <= 1u || stateId == 11)
				{
					return;
				}
			}
			else
			{
				switch (stateId)
				{
				default:
					switch (stateId)
					{
					case 213:
					case 214:
					case 215:
					case 219:
					case 220:
					case 221:
					case 225:
					case 226:
					case 227:
					case 303:
					case 305:
					case 307:
					case 309:
					case 311:
					case 312:
					case 318:
					case 319:
					case 320:
					case 321:
					case 322:
					case 323:
					case 326:
					case 327:
						return;
					}
					break;
				case 28:
				case 29:
				case 30:
				case 31:
				case 32:
				case 33:
				case 34:
				case 35:
				case 36:
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
				case 42:
				case 43:
				case 44:
				case 46:
				case 47:
				case 48:
				case 55:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
				case 64:
				case 65:
				case 66:
				case 67:
				case 69:
				case 70:
				case 71:
				case 72:
				case 73:
				case 80:
				case 81:
				case 86:
				case 87:
				case 88:
				case 94:
				case 96:
				case 104:
				case 106:
				case 117:
				case 122:
				case 123:
				case 124:
				case 125:
				case 126:
				case 132:
				case 133:
				case 134:
				case 135:
				case 136:
				case 137:
				case 142:
				case 143:
				case 144:
				case 148:
				case 149:
				case 150:
				case 151:
				case 153:
				case 155:
				case 160:
				case 161:
				case 162:
				case 163:
				case 167:
				case 168:
				case 169:
				case 170:
				case 171:
				case 172:
				case 173:
				case 174:
				case 175:
				case 176:
				case 177:
				case 178:
				case 185:
				case 194:
				case 196:
				case 198:
				case 199:
				case 200:
				case 201:
				case 202:
					break;
				case 27:
				case 45:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 56:
				case 57:
				case 58:
				case 68:
				case 74:
				case 75:
				case 76:
				case 77:
				case 78:
				case 79:
				case 82:
				case 83:
				case 84:
				case 85:
				case 89:
				case 90:
				case 91:
				case 92:
				case 93:
				case 95:
				case 97:
				case 98:
				case 99:
				case 100:
				case 101:
				case 102:
				case 103:
				case 105:
				case 107:
				case 108:
				case 109:
				case 110:
				case 111:
				case 112:
				case 113:
				case 114:
				case 115:
				case 116:
				case 118:
				case 119:
				case 120:
				case 121:
				case 127:
				case 128:
				case 129:
				case 130:
				case 131:
				case 138:
				case 139:
				case 140:
				case 141:
				case 145:
				case 146:
				case 147:
				case 152:
				case 154:
				case 156:
				case 157:
				case 158:
				case 159:
				case 164:
				case 165:
				case 166:
				case 179:
				case 180:
				case 181:
				case 182:
				case 183:
				case 184:
				case 186:
				case 187:
				case 188:
				case 189:
				case 190:
				case 191:
				case 192:
				case 193:
				case 195:
				case 197:
				case 203:
				case 204:
				case 205:
					return;
				}
			}
		}
		else
		{
			switch (stateId)
			{
			case 336:
			case 337:
			case 340:
			case 353:
			case 354:
			case 357:
			case 370:
			case 372:
				return;
			}
		}
		if (myPlayer.move.Moving)
		{
			if (myPlayer.move.DuckState == 0)
			{
				if (flag)
				{
					if (animComp.LegsAnimInfo.StateId != 10)
					{
						legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(10);
						CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
					}
				}
				else if (animComp.LegsAnimInfo.StateId != 9)
				{
					legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(9);
					CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
				}
			}
			else if (flag)
			{
				if (IsRunning(myPlayer, cmd))
				{
					if (animComp.LegsAnimInfo.StateId != 2)
					{
						if (!myPlayer.IsActThirdMove())
						{
							legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(2);
							CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
						}
						else
						{
							legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(1);
							CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
						}
					}
				}
				else if (animComp.LegsAnimInfo.StateId != 4)
				{
					if (!myPlayer.IsActThirdMove())
					{
						legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(4);
						CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
					}
					else
					{
						legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(3);
						CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
					}
				}
			}
			else if (IsRunning(myPlayer, cmd))
			{
				if (animComp.LegsAnimInfo.StateId != 1)
				{
					legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(1);
					CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
				}
			}
			else if (animComp.LegsAnimInfo.StateId != 3)
			{
				legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(3);
				CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
			}
		}
		else if (myPlayer.move.DuckState == 0)
		{
			if (animComp.LegsAnimInfo.StateId != 8)
			{
				legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(8);
				CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
			}
		}
		else if (animComp.LegsAnimInfo.StateId != 7)
		{
			legAnimStateInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(7);
			CommonResetLegInfo(animComp, legAnimStateInfo, myPlayer.basicInfo.CareerInfo, myPlayer.currentWeapon.WeaponInfo);
		}
	}
}
