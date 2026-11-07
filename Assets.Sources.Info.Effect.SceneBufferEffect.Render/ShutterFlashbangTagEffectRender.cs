using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using Assets.Sources.Utils.Ui;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class ShutterFlashbangTagEffectRender : AbstractSceneBuffEffectRender
{
	private Transform _point;

	private UnityEngine.Camera _mainCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;

	private PlayerContext _playerContext;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_playerContext = Contexts.sharedInstance.player;
		_point = effectGameObject.transform.Find("Canvas/Point");
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (!Entity.HasSceneBuff)
		{
			return;
		}
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(Entity.SceneBuff.Data.AttachPlayerId);
		if (entityWithEntityId != null)
		{
			float num = PlayerCareerConstantUtility.GetHeight(entityWithEntityId.GetCareer(), entityWithEntityId.GetScale());
			float num2 = 60f;
			Vector3 vector = VectorCoordConverter.SsjjToUnity(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z)) + new Vector3(0f, num + num2, 0f);
			if (InScreenUtils.InScreen(vector, _mainCamera) > 0f)
			{
				Vector3 localPosition = (Vector3)RectTransformUtility.WorldToScreenPoint(_mainCamera, vector) - new Vector3(Screen.width, Screen.height) / 2f;
				_point.localPosition = localPosition;
			}
			else
			{
				_point.localPosition = -new Vector3(Screen.width, Screen.height);
			}
		}
	}
}
