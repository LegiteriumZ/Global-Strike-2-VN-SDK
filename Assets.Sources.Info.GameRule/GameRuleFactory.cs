using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.GameRule;

public class GameRuleFactory
{
	private static GameRuleFactory _instance;

	private GoldExplodeGameRule _goldExplode = new GoldExplodeGameRule();

	private ExplodeGameRule _explode = new ExplodeGameRule();

	private MadExplodeGameRule _madExplodeRule = new MadExplodeGameRule();

	private DefaultGameRule _defaultRule = new DefaultGameRule();

	private FinalBioGameRule _finalBioRule = new FinalBioGameRule();

	private FinalBio3GameRule _finalBio3Rule = new FinalBio3GameRule();

	private SuperBioGameRule _superBioRule = new SuperBioGameRule();

	private MadFinalBioGameRule _madFinalBioRule = new MadFinalBioGameRule();

	private BiochemicalGameRule _biochemicalRule = new BiochemicalGameRule();

	private Biochemical3GameRule _biochemical3Rule = new Biochemical3GameRule();

	private MadBiochemicalGameRule _madBiochemicalRule = new MadBiochemicalGameRule();

	private BigHeadGameRule _bigHeadRule = new BigHeadGameRule();

	private GroupGameRule _groupRule = new GroupGameRule();

	private MadGroupGameRule _madGroupRule = new MadGroupGameRule();

	private RpgGameRule _rpgRule = new RpgGameRule();

	private PersonalGameRule _personalRule = new PersonalGameRule();

	private UnlimitReliveGameRule _unlimitReliveRule = new UnlimitReliveGameRule();

	private WeaponMasterGameRule _weaponMasterRule = new WeaponMasterGameRule();

	private DeathMatchGameRule _deathMatchRule = new DeathMatchGameRule();

	private FreeCommonGameRule _freeRule = new FreeCommonGameRule();

	private FlyKnifeGameRule _flyKnifeRule = new FlyKnifeGameRule();

	private RpgMinerGameRule _rpgMinerRule = new RpgMinerGameRule();

	private RpgGroupGameRule _rpgGroupRule = new RpgGroupGameRule();

	private RpgKillGodGameRule _rpgKillGodRule = new RpgKillGodGameRule();

	private BladeGameRule _bladeRule = new BladeGameRule();

	private BroadSwordGameRule _broadSwordRule = new BroadSwordGameRule();

	private MadBladeGameRule _madBladeRule = new MadBladeGameRule();

	private HighGroupGameRule _highGroupGameRule = new HighGroupGameRule();

	private BioUnionBaseGameRule _bioUnionBaseGameRule = new BioUnionBaseGameRule();

	private MechwarriorGameRule _mechwarriorRule = new MechwarriorGameRule();

	private RpgKillOtherGameRule _rpgKillOtherRule = new RpgKillOtherGameRule();

	private RpgSurvivalPvpGameRule _rpgSurvivalPvpRule = new RpgSurvivalPvpGameRule();

	private RpgTeamRaceGameRule _rpgTeamRaceRule = new RpgTeamRaceGameRule();

	private RpgZhouNianQingGameRule _rpgZhouNianQingRule = new RpgZhouNianQingGameRule();

	private RpgGuozhan2GameRule _rpgGuozhan2GameRule = new RpgGuozhan2GameRule();

	public static GameRuleFactory Instance => _instance ?? (_instance = new GameRuleFactory());

	public IGameRule GetGameRule(int ruleId)
	{
		switch (ruleId)
		{
		case 29:
			return _mechwarriorRule;
		case 15006:
			return _rpgSurvivalPvpRule;
		default:
			if (RuleUtilty.IsTeamRace(ruleId))
			{
				return _rpgTeamRaceRule;
			}
			if (RuleUtilty.IsRpgSpecailMode(ruleId))
			{
				if (ruleId >= 110003 && ruleId <= 110012)
				{
					return _rpgGuozhan2GameRule;
				}
				return _rpgZhouNianQingRule;
			}
			switch (ruleId)
			{
			case 15005:
				return _rpgKillOtherRule;
			case 15004:
				return _rpgKillGodRule;
			case 15002:
				return _rpgMinerRule;
			case 15000:
			case 15007:
			case 15012:
			case 15013:
			case 15014:
				return _rpgGroupRule;
			default:
				if (RuleUtilty.IsRpg(ruleId))
				{
					return _rpgRule;
				}
				if (ruleId == 2)
				{
					return _explode;
				}
				if (RuleUtilty.IsExplode(ruleId) && ruleId != 66)
				{
					return _goldExplode;
				}
				switch (ruleId)
				{
				case 117:
				case 119:
				case 122:
					return _biochemical3Rule;
				case 118:
					return _finalBio3Rule;
				case 14:
					return _finalBioRule;
				case 16:
					return _superBioRule;
				case 68:
					return _madFinalBioRule;
				case 69:
					return _madBiochemicalRule;
				default:
					if (RuleUtilty.IsBioMode(ruleId))
					{
						return _biochemicalRule;
					}
					if (RuleUtilty.IsBioUnion(ruleId))
					{
						return _bioUnionBaseGameRule;
					}
					if (RuleUtilty.IsBigHeadModel(ruleId))
					{
						return _bigHeadRule;
					}
					switch (ruleId)
					{
					case 5:
						return _personalRule;
					case 3:
					case 4:
					case 10:
					case 21:
					case 24:
					case 32:
					case 2003:
						return _groupRule;
					case 67:
						return _madGroupRule;
					case 63:
						return _unlimitReliveRule;
					case 64:
						return _weaponMasterRule;
					case 12:
						return _deathMatchRule;
					case 70:
					case 111:
					case 115:
					case 116:
					case 127:
						return _freeRule;
					case 100:
						return _freeRule;
					case 66:
						return _madExplodeRule;
					case 15:
						return _bladeRule;
					case 123:
						return _broadSwordRule;
					case 65:
						return _madBladeRule;
					case 74:
						return _flyKnifeRule;
					case 91:
						return _highGroupGameRule;
					default:
						return _defaultRule;
					}
				}
			}
		}
	}
}
