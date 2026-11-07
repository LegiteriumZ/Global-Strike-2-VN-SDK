using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.Ui;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class DistanceShowEffectRender : AbstractSceneBuffEffectRender
{
	private PlayerContext _playerContext;

	private Text _textMesh;

	private Transform _point;

	private UnityEngine.Camera _mainCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_playerContext = Contexts.sharedInstance.player;
		_point = effectGameObject.transform.Find("ScreenSpace/DistanceText");
		_textMesh = effectGameObject.transform.Find("ScreenSpace/DistanceText").GetComponent<Text>();
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		base.Render(frameTime, battleRoom);
		if (Entity.HasSceneBuff)
		{
			Vector3 vector = VectorCoordConverter.SsjjToUnity(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z));
			if (InScreenUtils.InScreen(vector, _mainCamera) > 0f && _playerContext.cameraOwnerEntity.basicInfo.Current.Team == 1)
			{
				Vector3 localPosition = (Vector3)RectTransformUtility.WorldToScreenPoint(_mainCamera, vector) - new Vector3(Screen.width, Screen.height) / 2f;
				_point.localPosition = localPosition;
				_textMesh.text = $"[{StringCache.IntToString(GetDistance(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z)))}m]";
			}
			else
			{
				_point.localPosition = -new Vector3(Screen.width, Screen.height);
			}
		}
	}

	protected int GetDistance(Vector3 position)
	{
		return (int)(Vector3.Distance(Contexts.sharedInstance.player.myPlayerEntity.GetCompenstatePos(Contexts.sharedInstance.player.myPlayerEntity.fpos.Change.GetPosIndex()), position) * 0.01f);
	}
}
