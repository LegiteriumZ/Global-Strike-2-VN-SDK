using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class LightmapChangeHandler : ApcPacketHandler<LightMapMessageData>
{
	public LightmapChangeHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 610;
	}

	public override void Handle(LightMapMessageData data)
	{
		SceneObjectEntity sceneMapEntity = Contexts.sharedInstance.sceneObject.sceneMapEntity;
		if (sceneMapEntity.hasLightMapChange && (float)data.From == sceneMapEntity.lightMapChange.From && (float)data.To == sceneMapEntity.lightMapChange.To)
		{
			_ = (float)data.Time;
			_ = sceneMapEntity.lightMapChange.Duration;
		}
		sceneMapEntity.ReplaceLightMapChange(data.From, data.To, data.Time, Contexts.sharedInstance.time.time.ClientRealTime, data.Mode);
		if (!sceneMapEntity.hasSkyBoxChangeObjects)
		{
			sceneMapEntity.ReplaceSkyBoxChangeObjects(0f, 0f, 0);
		}
		sceneMapEntity.ReplaceSkyBoxChange(data.From, data.To, data.Time, Contexts.sharedInstance.time.time.ClientRealTime, data.Mode);
	}
}
