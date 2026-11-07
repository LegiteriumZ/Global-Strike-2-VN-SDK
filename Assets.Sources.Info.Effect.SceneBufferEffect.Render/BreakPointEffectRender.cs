using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Config;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.SceneObject;
using Assets.Sources.Utils.Ui;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class BreakPointEffectRender : AbstractSceneBuffEffectRender
{
	private PlayerContext _playerContext;

	private Text _textMesh;

	private Transform _point;

	private UnityEngine.Camera _mainCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_playerContext = Contexts.sharedInstance.player;
		_point = effectGameObject.transform.Find("Canvas/Point");
		_textMesh = effectGameObject.transform.Find("Canvas/Point/DistanceText").GetComponent<Text>();
		if (entity.HasSceneBuff)
		{
			effectGameObject.transform.Find("GameObject/0/sprite").localScale = Vector3.one * entity.SceneBuff.Data.Radius / 64f * 2f;
			if (entity.SceneBuff.Data.Lv == 1)
			{
				_point.GetComponent<Image>().sprite = _point.GetComponent<SpriteList>().Sprites[1];
			}
			else
			{
				_point.GetComponent<Image>().sprite = _point.GetComponent<SpriteList>().Sprites[0];
			}
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (!Entity.HasSceneBuff)
		{
			return;
		}
		Vector3 vector = VectorCoordConverter.SsjjToUnity(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z)) + new Vector3(0f, 300f, 0f);
		if (InScreenUtils.InScreen(vector, _mainCamera) > 0f)
		{
			Vector3 localPosition = (Vector3)RectTransformUtility.WorldToScreenPoint(_mainCamera, vector) - new Vector3(Screen.width, Screen.height) / 2f;
			_point.localPosition = localPosition;
			if (GameSetting.Config.SuggestFlag == 1)
			{
				_textMesh.text = StringCache.IntToString(GetDistance(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z)));
			}
			else
			{
				_textMesh.text = "";
			}
		}
		else
		{
			_point.localPosition = -new Vector3(Screen.width, Screen.height);
		}
	}

	public override bool InBreakPoint()
	{
		if (!UiIEventCondition.Get_c4Message_HasC4())
		{
			return false;
		}
		if (SceneObjectEntityUtility.InSceneBuffRadius(_playerContext.myPlayerEntity, Entity))
		{
			return true;
		}
		return false;
	}

	protected int GetDistance(Vector3 position)
	{
		return (int)(Vector3.Distance(Contexts.sharedInstance.player.myPlayerEntity.GetCompenstatePos(Contexts.sharedInstance.player.myPlayerEntity.fpos.Change.GetPosIndex()), position) * 0.01f);
	}
}
