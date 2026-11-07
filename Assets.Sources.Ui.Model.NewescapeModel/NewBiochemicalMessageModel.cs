using Assets.Sources.Constant.Career;
using Assets.Sources.Ui.Model.Biochemical;
using NetData;

namespace Assets.Sources.Ui.Model.NewescapeModel;

public class NewBiochemicalMessageModel : BiochemicalMessageModel
{
	protected override void UpdateImage(BioMessageType messageType)
	{
		_refreshMessage = false;
		switch (messageType)
		{
		case BioMessageType.AMMUNITIONREFRESH:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref BiochemicalMessageModel._ammunitionRefreshAsset);
			break;
		case BioMessageType.HEROKILL:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref BiochemicalMessageModel._heroKillAsset);
			break;
		case BioMessageType.RESURRECTION:
			_messageImageActiveChip.Time = 3000;
			SetMessageImage(ref BiochemicalMessageModel._resurrectionAsset);
			break;
		case BioMessageType.USESKILL:
			_messageImageActiveChip.Time = 1000;
			SetMessageImage(ref BiochemicalMessageModel._useSkillAsset);
			_refreshMessage = true;
			break;
		case BioMessageType.KILLHERO:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._killheroAsset);
			break;
		case BioMessageType.SUCCESSFULINFECTION:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._successfulinfectionAsset);
			break;
		case BioMessageType.CHANGFAILED:
		{
			PlayerEntityData playerEntityData = ((_playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.hasBasicInfo) ? _playerContext.myPlayerEntity.basicInfo.Current : null);
			if (playerEntityData != null)
			{
				if (PlayerCareerConstantUtility.IsHumanity(playerEntityData.Career))
				{
					SetSelfMessageImage(ref BiochemicalMessageModel._biochemicalserumsuccessAsset);
				}
				else
				{
					SetSelfMessageImage(ref BiochemicalMessageModel._biochemicalserumfailAsset);
				}
				_selfMessageImageActiveChip.Time = 3000;
			}
			break;
		}
		case BioMessageType.DISARM:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._disarmAsset);
			break;
		case BioMessageType.WARRANTDECELERATE:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._warrantAsset);
			break;
		case BioMessageType.KNIFEKILL:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._knifekillAsset);
			break;
		case BioMessageType.INSANEFULINFECTION:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._insanefulinfectionAsset);
			break;
		case BioMessageType.METALMANSKILLHIT:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._metalmanskillhitAsset);
			break;
		case BioMessageType.PERTRIFIEDSKILLHIT:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._petrifiedskillhitAsset);
			break;
		case BioMessageType.TWINESSKILLHIT:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._twineskillhitAsset);
			break;
		case BioMessageType.HELPKILL:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._helpKillAsset);
			break;
		case BioMessageType.KNIFEKILLLEVELDOWN:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._knifeKillLevelDownAsset);
			break;
		case BioMessageType.LEVELDOWN:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._levelDownAsset);
			break;
		case BioMessageType.PANDORACANNOTUSEMIWU:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._CannotUseMiwuAsset);
			break;
		case BioMessageType.PANDORAUSEMIWU:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._UseMiwuAsset);
			break;
		case BioMessageType.GETENCOURAGESUCCESS:
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref BiochemicalMessageModel._getEncourageSuccessAsset);
			break;
		}
	}
}
