using NetData;
using SSJJMath;

namespace Assets.Sources.Free.Scene;

public class SceneLightHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 47;
	}

	public void Handle(SimpleProto simpleUI)
	{
		float num = simpleUI.Fs[0];
		float num2 = simpleUI.Fs[1];
		float num3 = simpleUI.Fs[2];
		int newMode = simpleUI.Ins[0];
		SceneObjectEntity sceneMapEntity = Contexts.sharedInstance.sceneObject.sceneMapEntity;
		if (!sceneMapEntity.hasLightMapChange || !num.SimpleEqual(sceneMapEntity.lightMapChange.From) || !num2.SimpleEqual(sceneMapEntity.lightMapChange.To) || !num3.SimpleEqual(sceneMapEntity.lightMapChange.Duration))
		{
			sceneMapEntity.ReplaceLightMapChange(num, num2, num3, Contexts.sharedInstance.time.time.ClientRealTime, newMode);
		}
	}
}
