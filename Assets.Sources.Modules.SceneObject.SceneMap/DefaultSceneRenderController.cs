using SSJJSceneLoader;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class DefaultSceneRenderController : ISceneRenderController
{
	private WorldCameraContext _worldCameraContext;

	public DefaultSceneRenderController(WorldCameraContext worldCameraContext)
	{
		_worldCameraContext = worldCameraContext;
	}

	public bool IsRenderEnabled()
	{
		if (_worldCameraContext.hasCameraEffect && _worldCameraContext.cameraEffect.HideScene)
		{
			return false;
		}
		return true;
	}
}
