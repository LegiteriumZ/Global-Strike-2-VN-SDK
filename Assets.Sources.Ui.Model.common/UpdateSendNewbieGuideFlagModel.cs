using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;

namespace Assets.Sources.Ui.Model.Common;

public class UpdateSendNewbieGuideFlagModel : IPlaybackSystem
{
	private BattleServerContext _battleServerContext;

	public void OnPlayback()
	{
		if (_battleServerContext == null)
		{
			_battleServerContext = Contexts.sharedInstance.battleServer;
		}
		SendNewbieGuideFlag();
	}

	private void SendNewbieGuideFlag()
	{
		NewbieGuideStruct newbieGuideData_NewbieGuideModel = UiIEventCondition.Get_newbieGuideData_NewbieGuideModel();
		if (newbieGuideData_NewbieGuideModel.NewbieGuideFlagChanged)
		{
			ProtoIntData protoIntData = new ProtoIntData();
			protoIntData.Data = newbieGuideData_NewbieGuideModel.NewbieGuideFlag;
			_battleServerContext.battleServer.Server.SendTcpMessage(6, protoIntData);
			newbieGuideData_NewbieGuideModel.NewbieGuideFlagChanged = false;
		}
		if (newbieGuideData_NewbieGuideModel.SendBagChanged)
		{
			_battleServerContext.battleServer.Server.SendTcpMessage(10);
			newbieGuideData_NewbieGuideModel.SendBagChanged = false;
		}
	}
}
