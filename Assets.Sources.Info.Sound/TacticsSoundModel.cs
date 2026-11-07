using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJNetworking.BattleServer;

namespace Assets.Sources.Info.Sound;

public class TacticsSoundModel
{
	private List<TacticsSoundInfo> _tacticsSoundList;

	private int _goldExploadeUiStartIndex;

	private int _goldExploadeUiLength;

	public int InitRule;

	public bool IsWoman;

	private int voiceburstinterval = 6000;

	private int threevoiceinterval = 24000;

	private static TacticsSoundModel _instance;

	public int TacticsStartIndex;

	public const int TacticalsouneType = 0;

	public const int PlayersoundType = 2;

	public const int ExpressionType = 1;

	private List<int> _sendTimes = new List<int>();

	public static TacticsSoundModel Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new TacticsSoundModel();
			}
			return _instance;
		}
	}

	public int TacticsSoundListLength => _tacticsSoundList.Count;

	public int GoldExploadeUIStartIndex => _goldExploadeUiStartIndex;

	public int GoldExploadeUILength => _goldExploadeUiLength;

	public TacticsSoundModel()
	{
		_tacticsSoundList = new List<TacticsSoundInfo>();
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsBattleRoyaleMode(raceType))
		{
			voiceburstinterval = 3000;
			threevoiceinterval = 12000;
		}
		if (raceType == 134)
		{
			voiceburstinterval = 500;
			threevoiceinterval = 2000;
		}
	}

	public void AddSoundList(int initRule, bool isWoman, int team)
	{
		_tacticsSoundList.Clear();
		AddCommonSound(isWoman);
		if (RuleUtilty.IsExplode(initRule) || 39 == initRule)
		{
			AddExploadeSound(isWoman, team);
			if (27 == initRule)
			{
				_goldExploadeUiStartIndex = _tacticsSoundList.Count;
				AddGoldExploadeSound(isWoman);
				_goldExploadeUiLength = _tacticsSoundList.Count - _goldExploadeUiStartIndex;
			}
		}
		else if (RuleUtilty.IsBattleRoyaleMode(initRule) || 134 == initRule)
		{
			AddBattleRoyaleModeSound(isWoman);
		}
		else if (RuleUtilty.IsPve(initRule))
		{
			AddPveModelSound(isWoman);
		}
		else if (RuleUtilty.IsAvatarUltimateChallenge())
		{
			AddUlitmateSound(isWoman);
		}
	}

	private void AddBattleRoyaleModeSound(bool isWoman)
	{
		int count = _tacticsSoundList.Count;
		TacticsStartIndex = 3;
		if (isWoman)
		{
			AddSound(count++, "1、" + ScriptLocalization.Get("TacticssoundCoverme"), "sound/tacticswoman/Coverme.mp3", ScriptLocalization.Get("TacticssoundCoverme"));
			AddSound(count++, "2、" + ScriptLocalization.Get("TacticssoundFollowme"), "sound/tacticswoman/Followme.mp3", ScriptLocalization.Get("TacticssoundFollowme"));
			AddSound(count++, "3、" + ScriptLocalization.Get("TacticssoundNeedbackup"), "sound/tacticswoman/Needbackup.mp3", ScriptLocalization.Get("TacticssoundNeedbackup"));
			AddSound(count++, "4、" + ScriptLocalization.Get("TacticssoundInamoment"), "sound/tacticswoman/Inamoment.mp3", ScriptLocalization.Get("TacticssoundInamoment"));
			AddSound(count++, "5、" + ScriptLocalization.Get("TacticssoundSectorclera"), "sound/tacticswoman/sectorclear.mp3", ScriptLocalization.Get("TacticssoundSectorclera"));
			AddSound(count++, "6、" + ScriptLocalization.Get("TacticssoundEnemyspotted"), "sound/tacticswoman/enemyspotted.mp3", ScriptLocalization.Get("TacticssoundEnemyspotted"));
			AddSound(count++, "1、" + ScriptLocalization.Get("TacticssoundGoodjob"), "sound/tacticswoman/Goodjob.mp3", ScriptLocalization.Get("TacticssoundGoodjob"));
			AddSound(count++, "2、" + ScriptLocalization.Get("TacticssoundNeedclip"), "sound/tacticswoman/needclip.mp3", ScriptLocalization.Get("TacticssoundNeedclip"));
			AddSound(count++, "3、" + ScriptLocalization.Get("TacticssoundNeedweapon"), "sound/tacticswoman/Needweapon.mp3", ScriptLocalization.Get("TacticssoundNeedweapon"));
			AddSound(count++, "4、" + ScriptLocalization.Get("TacticssoundPleaseSaveMe"), "sound/ulitmateSound/PleaseSaveMe.mp3", ScriptLocalization.Get("TacticssoundPleaseSaveMe"));
			AddSound(count++, "5、" + ScriptLocalization.Get("TacticssoundThanks"), "sound/tacticswoman/thanks.mp3", ScriptLocalization.Get("TacticssoundThanks"));
			AddSound(count++, "6、" + ScriptLocalization.Get("TacticssoundNegative"), "sound/tacticswoman/negative.mp3", ScriptLocalization.Get("TacticssoundNegative"));
			AddSound(count++, "1、" + ScriptLocalization.Get("TacticssoundHeading"), "sound/tacticswoman/Heading.mp3", ScriptLocalization.Get("TacticssoundHeading"));
			AddSound(count++, "2、" + ScriptLocalization.Get("TacticssoundTeamfallback"), "sound/tacticswoman/Teamfallback.mp3", ScriptLocalization.Get("TacticssoundTeamfallback"));
			AddSound(count++, "3、" + ScriptLocalization.Get("Tacticssoundseparately"), "sound/tacticswoman/separately.mp3", ScriptLocalization.Get("Tacticssoundseparately"));
			AddSound(count++, "4、" + ScriptLocalization.Get("TacticssoundSticktogether"), "sound/tacticswoman/Sticktogether.mp3", ScriptLocalization.Get("TacticssoundSticktogether"));
			AddSound(count++, "5、" + ScriptLocalization.Get("TacticssoundStormfront"), "sound/tacticswoman/stormfront.mp3", ScriptLocalization.Get("TacticssoundStormfront"));
			AddSound(count++, "6、" + ScriptLocalization.Get("TacticssoundHoldposition"), "sound/tacticswoman/Holdposition.mp3", ScriptLocalization.Get("TacticssoundHoldposition"));
		}
		else
		{
			AddSound(count++, "1、" + ScriptLocalization.Get("TacticssoundCoverme"), "sound/tactics/ulitmateSound/Coverme.mp3", ScriptLocalization.Get("TacticssoundCoverme"));
			AddSound(count++, "2、" + ScriptLocalization.Get("TacticssoundFollowme"), "sound/tactics/ulitmateSound/Followme.mp3", ScriptLocalization.Get("TacticssoundFollowme"));
			AddSound(count++, "3、" + ScriptLocalization.Get("TacticssoundNeedbackup"), "sound/tactics/ulitmateSound/Needbackup.mp3", ScriptLocalization.Get("TacticssoundNeedbackup"));
			AddSound(count++, "4、" + ScriptLocalization.Get("TacticssoundInamoment"), "sound/tactics/ulitmateSound/Inamoment.mp3", ScriptLocalization.Get("TacticssoundInamoment"));
			AddSound(count++, "5、" + ScriptLocalization.Get("TacticssoundSectorclera"), "sound/tactics/ulitmateSound/Sectorclera.mp3", ScriptLocalization.Get("TacticssoundSectorclera"));
			AddSound(count++, "6、" + ScriptLocalization.Get("TacticssoundEnemyspotted"), "sound/tactics/ulitmateSound/Enemyspotted.mp3", ScriptLocalization.Get("TacticssoundEnemyspotted"));
			AddSound(count++, "1、" + ScriptLocalization.Get("TacticssoundGoodjob"), "sound/tactics/ulitmateSound/Goodjob.mp3", ScriptLocalization.Get("TacticssoundGoodjob"));
			AddSound(count++, "2、" + ScriptLocalization.Get("TacticssoundNeedclip"), "sound/tactics/needclip.mp3", ScriptLocalization.Get("TacticssoundNeedclip"));
			AddSound(count++, "3、" + ScriptLocalization.Get("TacticssoundNeedweapon"), "sound/tactics/ulitmateSound/Needweapon.mp3", ScriptLocalization.Get("TacticssoundNeedweapon"));
			AddSound(count++, "4、" + ScriptLocalization.Get("TacticssoundPleaseSaveMe"), "sound/ulitmateSound/PleaseSaveMe.mp3", ScriptLocalization.Get("TacticssoundPleaseSaveMe"));
			AddSound(count++, "5、" + ScriptLocalization.Get("TacticssoundThanks"), "sound/tactics/thanks.mp3", ScriptLocalization.Get("TacticssoundThanks"));
			AddSound(count++, "6、" + ScriptLocalization.Get("TacticssoundNegative"), "sound/tactics/negative.mp3", ScriptLocalization.Get("TacticssoundNegative"));
			AddSound(count++, "1、" + ScriptLocalization.Get("TacticssoundHeading"), "sound/tactics/ulitmateSound/Heading.mp3", ScriptLocalization.Get("TacticssoundHeading"));
			AddSound(count++, "2、" + ScriptLocalization.Get("TacticssoundTeamfallback"), "sound/tactics/ulitmateSound/Teamfallback.mp3", ScriptLocalization.Get("TacticssoundTeamfallback"));
			AddSound(count++, "3、" + ScriptLocalization.Get("Tacticssoundseparately"), "sound/tactics/ulitmateSound/separately.mp3", ScriptLocalization.Get("Tacticssoundseparately"));
			AddSound(count++, "4、" + ScriptLocalization.Get("TacticssoundSticktogether"), "sound/tactics/ulitmateSound/Sticktogether.mp3", ScriptLocalization.Get("TacticssoundSticktogether"));
			AddSound(count++, "5、" + ScriptLocalization.Get("TacticssoundStormfront"), "sound/tactics/stormfront.mp3", ScriptLocalization.Get("TacticssoundStormfront"));
			AddSound(count++, "6、" + ScriptLocalization.Get("TacticssoundHoldposition"), "sound/tactics/ulitmateSound/Holdposition.mp3", ScriptLocalization.Get("TacticssoundHoldposition"));
		}
	}

	private void AddUlitmateSound(bool isWoman)
	{
		int count = _tacticsSoundList.Count;
		TacticsStartIndex = 3;
		if (isWoman)
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundCopythatType"), "sound/tacticswoman/fireinthehole.mp3", ScriptLocalization.Get("TacticssoundCopythat"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTurndownType"), "sound/tacticswoman/flashbang.mp3", ScriptLocalization.Get("TacticssoundTurndown"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundAirdropType"), "sound/tacticswoman/flashbang.mp3", ScriptLocalization.Get("TacticssoundAirdrop"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTakecoverType"), "sound/tacticswoman/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundTakecover"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedweaponType"), "sound/tacticswoman/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundNeedweapon"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedarmorType"), "sound/tacticswoman/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundNeedarmor"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedmedicineType"), "sound/tacticswoman/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundNeedmedicine"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundEnemyspotted3Type"), "sound/tactics/ulitmateSound/fireinthehole.mp3", ScriptLocalization.Get("TacticssoundEnemyspotted"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundCoverme2Type"), "sound/ulitmateSound/flashbang.mp3", ScriptLocalization.Get("TacticssoundCoverme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFollowmeType"), "sound/ulitmateSound/flashbang.mp3", ScriptLocalization.Get("TacticssoundFollowme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedbackupType"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundNeedbackup"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundInamomentType"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundInamoment"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundseparatelyType"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("Tacticssoundseparately"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSectorclera7Type"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundSectorclera"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGogogoType"), "sound/ulitmateSound/Gogogo.mp3", ScriptLocalization.Get("TacticssoundGogogo"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHeadingType"), "sound/ulitmateSound/Heading.mp3", ScriptLocalization.Get("TacticssoundHeading"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundattackType"), "sound/ulitmateSound/attack.mp3", ScriptLocalization.Get("Tacticssoundattack"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHoldpositionType"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundHoldposition"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTeamfallbackType"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundTeamfallback"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSticktogetherType"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundSticktogether"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGoodjob7Type"), "sound/ulitmateSound/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundGoodjob"));
		}
		else
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundCopythatType"), "sound/tactics/ulitmateSound/Copythat.mp3", ScriptLocalization.Get("TacticssoundCopythat"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTurndownType"), "sound/tactics/ulitmateSound/Turndown.mp3", ScriptLocalization.Get("TacticssoundTurndown"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundAirdropType"), "sound/ulitmateSound/Airdrop.mp3", ScriptLocalization.Get("TacticssoundAirdrop"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTakecoverType"), "sound/tactics/ulitmateSound/Takecover.mp3", ScriptLocalization.Get("TacticssoundTakecover"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedweaponType"), "sound/tactics/ulitmateSound/Needweapon.mp3", ScriptLocalization.Get("TacticssoundNeedweapon"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedarmorType"), "sound/tactics/ulitmateSound/Needarmor.mp3", ScriptLocalization.Get("TacticssoundNeedarmor"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedmedicineType"), "sound/tactics/ulitmateSound/Needmedicine.mp3", ScriptLocalization.Get("TacticssoundNeedmedicine"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundEnemyspotted1Type"), "sound/tactics/ulitmateSound/Enemyspotted.mp3", ScriptLocalization.Get("TacticssoundEnemyspotted"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundCoverme2Type"), "sound/tactics/ulitmateSound/Coverme.mp3", ScriptLocalization.Get("TacticssoundCoverme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFollowmeType"), "sound/tactics/ulitmateSound/Followme.mp3", ScriptLocalization.Get("TacticssoundFollowme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedbackupType"), "sound/tactics/ulitmateSound/Needbackup.mp3", ScriptLocalization.Get("TacticssoundNeedbackup"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundInamomentType"), "sound/tactics/ulitmateSound/Inamoment.mp3", ScriptLocalization.Get("TacticssoundInamoment"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundseparatelyType"), "sound/tactics/ulitmateSound/separately.mp3", ScriptLocalization.Get("Tacticssoundseparately"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSectorclera7Type"), "sound/tactics/ulitmateSound/Sectorclera.mp3", ScriptLocalization.Get("TacticssoundSectorclera"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGogogoType"), "sound/tactics/ulitmateSound/Gogogo.mp3", ScriptLocalization.Get("TacticssoundGogogo"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHeadingType"), "sound/tactics/ulitmateSound/Heading.mp3", ScriptLocalization.Get("TacticssoundHeading"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundattackType"), "sound/tactics/ulitmateSound/attack.mp3", ScriptLocalization.Get("Tacticssoundattack"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHoldpositionType"), "sound/tactics/ulitmateSound/Holdposition.mp3", ScriptLocalization.Get("TacticssoundHoldposition"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTeamfallbackType"), "sound/tactics/ulitmateSound/Teamfallback.mp3", ScriptLocalization.Get("TacticssoundTeamfallback"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSticktogetherType"), "sound/tactics/ulitmateSound/Sticktogether.mp3", ScriptLocalization.Get("TacticssoundSticktogether"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGoodjob7Type"), "sound/tactics/ulitmateSound/Goodjob.mp3", ScriptLocalization.Get("TacticssoundGoodjob"));
		}
		AddSound(24, ScriptLocalization.Get("TacticssoundPleaseSaveMe"), "sound/ulitmateSound/PleaseSaveMe.mp3", ScriptLocalization.Get("TacticssoundPleaseSaveMe"));
	}

	private void AddCommonSound(bool isWoman)
	{
		int count = _tacticsSoundList.Count;
		if (isWoman)
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundFireinthehole"), "sound/tacticswoman/fireinthehole.mp3", ScriptLocalization.Get("TacticssoundFireinthehole"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFlashbang"), "sound/tacticswoman/flashbang.mp3", ScriptLocalization.Get("TacticssoundFlashbang"));
			AddSound(count, ScriptLocalization.Get("TacticssoundSmoke"), "sound/tacticswoman/smokeFamale.mp3", ScriptLocalization.Get("TacticssoundSmoke"));
		}
		else
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundFireinthehole"), "sound/tactics/fireinthehole.mp3", ScriptLocalization.Get("TacticssoundFireinthehole"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFlashbang"), "sound/tactics/flashbang.mp3", ScriptLocalization.Get("TacticssoundFlashbang"));
			AddSound(count, ScriptLocalization.Get("TacticssoundSmoke"), "sound/tactics/smokeMale.mp3", ScriptLocalization.Get("TacticssoundSmoke"));
		}
	}

	private void AddExploadeSound(bool isWoman, int team)
	{
		int count = _tacticsSoundList.Count;
		if (isWoman)
		{
			TacticsStartIndex = 3;
			AddSound(count++, ScriptLocalization.Get("TacticssoundRogerType"), "sound/tacticswoman/roger.mp3", ScriptLocalization.Get("TacticssoundRoger"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNegativeType"), "sound/tacticswoman/negative.mp3", ScriptLocalization.Get("TacticssoundNegative"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundEnemyspottedType"), "sound/tacticswoman/enemyspotted.mp3", ScriptLocalization.Get("TacticssoundEnemyspotted"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSectorcleraType"), "sound/tacticswoman/sectorclear.mp3", ScriptLocalization.Get("TacticssoundSectorclera"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFindthec4Type"), "sound/tacticswoman/findtheC4.mp3", ScriptLocalization.Get("TacticssoundFindthec4"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundDismantlec4Type"), "sound/tacticswoman/dismantleC4.mp3", ScriptLocalization.Get("TacticssoundDismantlec4"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNiceType"), "sound/tacticswoman/nice.mp3", ScriptLocalization.Get("TacticssoundNice"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundCovermeType"), "sound/tacticswoman/coverme.mp3", ScriptLocalization.Get("TacticssoundCoverme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFollowmeType"), "sound/tacticswoman/followme.mp3", ScriptLocalization.Get("TacticssoundFollowme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedbackupType"), "sound/tacticswoman/needbackup.mp3", ScriptLocalization.Get("TacticssoundNeedbackup"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundInamomentType"), "sound/tacticswoman/inamoment.mp3", ScriptLocalization.Get("TacticssoundInamoment"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundStormfrontType"), "sound/tacticswoman/stormfront.mp3", ScriptLocalization.Get("TacticssoundStormfront"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGogogoType"), "sound/tacticswoman/gogogo.mp3", ScriptLocalization.Get("TacticssoundGogogo"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHeadingtoaType"), "sound/tacticswoman/headingtoa.mp3", ScriptLocalization.Get("TacticssoundHeadingtoa"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHeadingtobType"), "sound/tacticswoman/headingtob.mp3", ScriptLocalization.Get("TacticssoundHeadingtob"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHoldpositionType"), "sound/tacticswoman/holdposition.mp3", ScriptLocalization.Get("TacticssoundHoldposition"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTeamfallbackType"), "sound/tacticswoman/teamfallback.mp3", ScriptLocalization.Get("TacticssoundTeamfallback"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSticktogetherType"), "sound/tacticswoman/sticktogether.mp3", ScriptLocalization.Get("TacticssoundSticktogether"));
		}
		else
		{
			TacticsStartIndex = 3;
			AddSound(count++, ScriptLocalization.Get("TacticssoundRogerType"), "sound/tactics/roger.mp3", ScriptLocalization.Get("TacticssoundRoger"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNegativeType"), "sound/tactics/negative.mp3", ScriptLocalization.Get("TacticssoundNegative"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundEnemyspottedType"), "sound/tactics/enemyspotted.mp3", ScriptLocalization.Get("TacticssoundEnemyspotted"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSectorcleraType"), "sound/tactics/sectorclear.mp3", ScriptLocalization.Get("TacticssoundSectorclera"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFindthec4Type"), "sound/tactics/findtheC4.mp3", ScriptLocalization.Get("TacticssoundFindthec4"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundDismantlec4Type"), "sound/tactics/dismantleC4.mp3", ScriptLocalization.Get("TacticssoundDismantlec4"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNiceType"), "sound/tactics/nice.mp3", ScriptLocalization.Get("TacticssoundNice"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundCovermeType"), "sound/tactics/coverme.mp3", ScriptLocalization.Get("TacticssoundCoverme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundFollowmeType"), "sound/tactics/followme.mp3", ScriptLocalization.Get("TacticssoundFollowme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedbackupType"), "sound/tactics/needbackup.mp3", ScriptLocalization.Get("TacticssoundNeedbackup"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundInamomentType"), "sound/tactics/inamoment.mp3", ScriptLocalization.Get("TacticssoundInamoment"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundStormfrontType"), "sound/tactics/stormfront.mp3", ScriptLocalization.Get("TacticssoundStormfront"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGogogoType"), "sound/tactics/gogogo.mp3", ScriptLocalization.Get("TacticssoundGogogo"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHeadingtoaType"), "sound/tactics/headingtoa.mp3", ScriptLocalization.Get("TacticssoundHeadingtoa"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHeadingtobType"), "sound/tactics/headingtob.mp3", ScriptLocalization.Get("TacticssoundHeadingtob"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundHoldpositionType"), "sound/tactics/holdposition.mp3", ScriptLocalization.Get("TacticssoundHoldposition"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundTeamfallbackType"), "sound/tactics/teamfallback.mp3", ScriptLocalization.Get("TacticssoundTeamfallback"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundSticktogetherType"), "sound/tactics/sticktogether.mp3", ScriptLocalization.Get("TacticssoundSticktogether"));
		}
	}

	private void AddGoldExploadeSound(bool isWoman)
	{
		int count = _tacticsSoundList.Count;
		if (isWoman)
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundGiveweapom1"), "sound/tacticswoman/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom1"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGiveweapom2"), "sound/tacticswoman/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom2"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGiveweapom3"), "sound/tacticswoman/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom3"));
			AddSound(count, ScriptLocalization.Get("TacticssoundGiveweapom4"), "sound/tacticswoman/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom4"));
		}
		else
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundGiveweapom1"), "sound/tactics/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom1"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGiveweapom2"), "sound/tactics/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom2"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundGiveweapom3"), "sound/tactics/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom3"));
			AddSound(count, ScriptLocalization.Get("TacticssoundGiveweapom4"), "sound/tactics/needbackup.mp3", ScriptLocalization.Get("TacticssoundGiveweapom4"));
		}
	}

	private void AddPveModelSound(bool isWoman)
	{
		int count = _tacticsSoundList.Count;
		TacticsStartIndex = 3;
		if (isWoman)
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundGoodjob"), "sound/tacticswoman/goodjob.mp3", ScriptLocalization.Get("TacticssoundGoodjob"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundPvefollowme"), "sound/tacticswoman/pvefollowme.mp3", ScriptLocalization.Get("TacticssoundPvefollowme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundUnderstand"), "sound/tacticswoman/understand.mp3", ScriptLocalization.Get("TacticssoundUnderstand"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedclip"), "sound/tacticswoman/needclip.mp3", ScriptLocalization.Get("TacticssoundNeedclip"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedhp"), "sound/tacticswoman/needhp.mp3", ScriptLocalization.Get("TacticssoundNeedhp"));
			AddSound(count, ScriptLocalization.Get("TacticssoundThanks"), "sound/tacticswoman/thanks.mp3", ScriptLocalization.Get("TacticssoundThanks"));
		}
		else
		{
			AddSound(count++, ScriptLocalization.Get("TacticssoundGoodjob"), "sound/tactics/goodjob.mp3", ScriptLocalization.Get("TacticssoundGoodjob"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundPvefollowme"), "sound/tactics/pvefollowme.mp3", ScriptLocalization.Get("TacticssoundPvefollowme"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundUnderstand"), "sound/tactics/understand.mp3", ScriptLocalization.Get("TacticssoundUnderstand"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedclip"), "sound/tactics/needclip.mp3", ScriptLocalization.Get("TacticssoundNeedclip"));
			AddSound(count++, ScriptLocalization.Get("TacticssoundNeedhp"), "sound/tactics/needhp.mp3", ScriptLocalization.Get("TacticssoundNeedhp"));
			AddSound(count, ScriptLocalization.Get("TacticssoundThanks"), "sound/tactics/thanks.mp3", ScriptLocalization.Get("TacticssoundThanks"));
		}
	}

	private void AddSound(int index, string tacticsSoundText, string url, string chattingGuiText)
	{
		TacticsSoundInfo tacticsSoundInfo = new TacticsSoundInfo();
		tacticsSoundInfo.Index = index;
		tacticsSoundInfo.TacticsSoundText = tacticsSoundText;
		tacticsSoundInfo.Url = url;
		tacticsSoundInfo.ChattingGuiText = chattingGuiText;
		_tacticsSoundList.Add(tacticsSoundInfo);
	}

	public bool HasSound(int tacticsType, int diff)
	{
		switch (tacticsType)
		{
		case 0:
			if ((diff >= 1) & (diff <= Instance.TacticsSoundListLength - 3))
			{
				return true;
			}
			break;
		case 2:
		{
			if (Contexts.sharedInstance.battleRoom.playerInfo.PersonalizedDic.TryGetValue(2, out var value) && diff >= 1 && diff <= value.Count && value[diff - 1] != null)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	public bool SendSound(int tacticsType, int index)
	{
		TimeComponent time = Contexts.sharedInstance.time.time;
		if ((_sendTimes.Count > 0 && time.ClientRealTime - _sendTimes[_sendTimes.Count - 1] < voiceburstinterval) || (_sendTimes.Count >= 3 && time.ClientRealTime - _sendTimes[_sendTimes.Count - 3] < threevoiceinterval))
		{
			Contexts.sharedInstance.message.messageRemindData.SetMessage(ScriptLocalization.Get("Waittacticssound"));
			NotifyManager.ForceInvoke(38);
			return false;
		}
		if (_sendTimes.Count > 0 && time.ClientRealTime - _sendTimes[0] >= 24000)
		{
			_sendTimes.Clear();
		}
		_sendTimes.Add(time.ClientRealTime);
		IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
		switch (tacticsType)
		{
		case 0:
		{
			TacticsSoundData tacticsSoundData = new TacticsSoundData();
			tacticsSoundData.SoundId = index + Instance.TacticsStartIndex;
			server.SendTcpMessage(5, tacticsSoundData);
			break;
		}
		case 2:
		{
			PersonalityData personalityData = new PersonalityData();
			personalityData.Type = 2;
			personalityData.Id = index;
			server.SendTcpMessage(30, personalityData);
			break;
		}
		}
		return true;
	}

	public string GetUrlByIndex(int index)
	{
		if (index < 0 || index > _tacticsSoundList.Count - 1)
		{
			return "";
		}
		return _tacticsSoundList[index].Url;
	}

	public string GetTacticsSoundTextByIndex(int index)
	{
		if (index < 0 || index > _tacticsSoundList.Count - 1)
		{
			return "";
		}
		return _tacticsSoundList[index].TacticsSoundText;
	}

	public string GetChattingGuiTextByIndex(int index)
	{
		if (index < 0 || index > _tacticsSoundList.Count - 1)
		{
			return "";
		}
		return _tacticsSoundList[index].ChattingGuiText;
	}

	public int GetIndexBytacticsSoundText(string tacticsSoundText)
	{
		int count = _tacticsSoundList.Count;
		for (int i = 0; i < count; i++)
		{
			if (_tacticsSoundList[i].TacticsSoundText == tacticsSoundText)
			{
				return _tacticsSoundList[i].Index;
			}
		}
		return 0;
	}
}
