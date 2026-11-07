using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.CameraEffect;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.CameraEffect.Render;

public class CameraEffectRender : ICameraEffectRender
{
	public void Init(ISceneObjectEntity entity, GameObject effectObj)
	{
		effectObj.transform.Find("GameObject/Canvas/NameText").GetComponent<Text>().text = (entity as SceneObjectEntity).cameraObject.Current.PlayerName;
	}

	public bool Render(int frameTime, ISceneObjectEntity entity)
	{
		return true;
	}
}
