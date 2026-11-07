using NetData;
using SSJJBase.Utility;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SceneEffectDataHandler : ApcPacketHandler<SceneXMLFile>
{
	private BattleRoomContext _battleRoomContext;

	public SceneEffectDataHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 125;
	}

	public override void Handle(SceneXMLFile data)
	{
		string sceneEffectXml = ZipUtility.Decompress(data.Data);
		_battleRoomContext.mapInfo.SceneEffectXml = sceneEffectXml;
	}
}
