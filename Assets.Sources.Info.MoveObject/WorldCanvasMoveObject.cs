using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.MoveObject;

public abstract class WorldCanvasMoveObject : AbstractMoveObjectInfo
{
	private Canvas _worldCanvas;

	public override void RenderEntity(SceneObjectEntity entity)
	{
		if (!IsHide)
		{
			GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
			if (gameObject.IsActiveSelf() == IsHide)
			{
				gameObject.SetObjectActive(!IsHide);
				SetParticleScale(gameObject);
			}
			VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
			Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles);
			gameObject.transform.position = dest;
			gameObject.transform.localEulerAngles = localEulerAngles;
			gameObject.transform.localScale = entity.scale.Scale;
			BindCanvas(entity, gameObject, addraycaster: false);
			if ((bool)_worldCanvas)
			{
				RenderCanvas(entity, gameObject, _worldCanvas);
			}
		}
	}

	protected virtual void RenderCanvas(SceneObjectEntity entity, GameObject gameObject, Canvas canvas)
	{
	}

	protected virtual void InitCanvasUi(SceneObjectEntity entity, Canvas canvas)
	{
	}

	protected virtual bool IsShow(SceneObjectEntity entity)
	{
		return true;
	}

	protected void BindCanvas(SceneObjectEntity entity, GameObject gameObject, bool addraycaster)
	{
		if ((bool)_worldCanvas)
		{
			return;
		}
		GameObject gameObject2 = gameObject.FindForeachByName("Canvas");
		if (_worldCanvas == null && gameObject2 == null)
		{
			gameObject2 = new GameObject("Canvas");
			_worldCanvas = gameObject2.AddComponent<Canvas>();
			_worldCanvas.worldCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;
			CanvasScaler canvasScaler = gameObject2.AddComponent<CanvasScaler>();
			canvasScaler.dynamicPixelsPerUnit = 1f;
			canvasScaler.referencePixelsPerUnit = 100f;
			if (addraycaster)
			{
				GraphicRaycaster graphicRaycaster = gameObject2.AddComponent<GraphicRaycaster>();
				graphicRaycaster.ignoreReversedGraphics = true;
				graphicRaycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;
			}
			gameObject.AddChild(gameObject2);
			InitCanvasUi(entity, _worldCanvas);
		}
		else if ((bool)gameObject2 && _worldCanvas == null)
		{
			_worldCanvas = gameObject2.GetComponent<Canvas>();
			InitCanvasUi(entity, _worldCanvas);
		}
	}
}
