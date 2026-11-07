using System.Collections.Generic;
using Assets.Scripts.Utility.Sound;
using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class AutoVoiceInfoHandler : ApcPacketHandler<AllPlayerAutoVoiceInfoData>
{
	public AutoVoiceInfoHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 263;
	}

	public override void Handle(AllPlayerAutoVoiceInfoData data)
	{
		for (int i = 0; i < data.AllPlayerVoiceInfoList.Count; i++)
		{
			Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
			for (int j = 0; j < data.AllPlayerVoiceInfoList[i].CareerAutoVoiceInfoList.Count; j++)
			{
				OneCareerAutoVoiceInfoData oneCareerAutoVoiceInfoData = data.AllPlayerVoiceInfoList[i].CareerAutoVoiceInfoList[j];
				List<int> list = new List<int>();
				for (int k = 0; k < oneCareerAutoVoiceInfoData.ResIdList.Count; k++)
				{
					list.Add(oneCareerAutoVoiceInfoData.ResIdList[k]);
				}
				dictionary[oneCareerAutoVoiceInfoData.Career] = list;
			}
			MonoBehaviourSingleton<AutoSoundManager>.Instance.SetPlayerAutoSoundInfo(data.AllPlayerVoiceInfoList[i].Cid, dictionary);
		}
	}
}
