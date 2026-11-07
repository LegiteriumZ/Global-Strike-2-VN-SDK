using NetData;

namespace Assets.Sources.Free.Scene;

public class SkyBoxHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 46;
	}

	public void Handle(SimpleProto simpleUI)
	{
		int num = simpleUI.Ins[0];
		SceneObjectEntity sceneMapEntity = Contexts.sharedInstance.sceneObject.sceneMapEntity;
		if (!sceneMapEntity.hasSkybox)
		{
			sceneMapEntity.AddSkybox(num);
		}
		sceneMapEntity.skybox.SkyboxId = num;
	}
}
