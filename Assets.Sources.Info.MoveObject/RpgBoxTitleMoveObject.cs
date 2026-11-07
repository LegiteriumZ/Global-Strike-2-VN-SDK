using System.Collections;
using Assets.Sources.Free.Const;
using Assets.Sources.Utils.AssetManager;
using Res.Assets.Scripts.ExImage;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.MoveObject;

public class RpgBoxTitleMoveObject : WorldCanvasMoveObject
{
	private ProtectImage _titleImage;

	private AssetInfo _humanAssetInfo = new AssetInfo("effect/freerpg_105006mode", "Assets/Res/Assets/effect/freeRpg_105006Mode/buff/humanity.png");

	private AssetInfo _boAssetInfo = new AssetInfo("effect/freerpg_105006mode", "Assets/Res/Assets/effect/freeRpg_105006Mode/buff/bio.png");

	private Material _uiMaterial;

	private IEnumerator _task;

	private Vector2 _defaultSize = new Vector2(25.6f, 6.4f);

	protected override void InitCanvasUi(SceneObjectEntity entity, Canvas canvas)
	{
		if ((bool)canvas && _titleImage == null)
		{
			GameObject gameObject = canvas.FindForeachByName("title");
			if (gameObject == null)
			{
				gameObject = new GameObject("title");
				_titleImage = gameObject.AddComponent<ProtectImage>();
				_uiMaterial = new Material(Shader.Find("Game/UI/UIOverLay"));
				_titleImage.material = _uiMaterial;
				canvas.gameObject.AddChild(gameObject);
				_titleImage.raycastTarget = false;
				_titleImage.rectTransform.anchoredPosition = new Vector2(0f, 100f);
				_titleImage.rectTransform.sizeDelta = _defaultSize;
			}
			else
			{
				_titleImage = gameObject.GetComponent<ProtectImage>();
			}
		}
		if ((bool)_titleImage)
		{
			if (entity.moveObject.Current.Team == 100)
			{
				_task = SetSprite(_boAssetInfo);
			}
			else
			{
				_task = SetSprite(_humanAssetInfo);
			}
			BaseAsyncManager.Instance.StartCoRoutine(_task);
		}
	}

	private IEnumerator SetSprite(AssetInfo assetInfo)
	{
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetInfo, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetInfo))
		{
			yield return null;
		}
		Texture2D texture2D = SingletonInstance<AssetPool>.Instance.GetOrNull(assetInfo) as Texture2D;
		if (texture2D != null)
		{
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
			_titleImage.sprite = sprite;
		}
		else
		{
			this.LogErrorFormat("Load {0} Failed", assetInfo);
		}
	}

	protected override void RenderCanvas(SceneObjectEntity entity, GameObject gameObject, Canvas canvas)
	{
		base.RenderCanvas(entity, gameObject, canvas);
		if ((bool)_titleImage && _titleImage.sprite != null)
		{
			if (IsShow(entity))
			{
				_titleImage.enabled = true;
				UnityEngine.Camera main = UnityEngine.Camera.main;
				_titleImage.transform.forward = (_titleImage.transform.position - main.transform.position).normalized;
				float distanceScale = GetDistanceScale(main.transform.position, gameObject.transform.position, main.fieldOfView);
				_titleImage.rectTransform.sizeDelta = _defaultSize * distanceScale;
			}
			else
			{
				_titleImage.enabled = false;
			}
		}
	}

	protected override bool IsShow(SceneObjectEntity entity)
	{
		PlayerEntity cameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			int team = entity.moveObject.Current.Team;
			int team2 = cameraOwnerEntity.basicInfo.Current.Team;
			if (team == team2)
			{
				return true;
			}
			if (team != 100 && team2 != 100)
			{
				return true;
			}
		}
		return false;
	}

	private float GetDistanceScale(Vector3 cameraPosition, Vector3 position, float fov)
	{
		float num = (position - cameraPosition).magnitude / 200f;
		if (fov.SimpleEqual(40f))
		{
			num *= FOVConstant.AWP_FOV1_SCALE_Result;
		}
		else if (fov.SimpleEqual(10f))
		{
			num *= FOVConstant.AWP_FOV2_SCALE_Result;
		}
		else if (fov.SimpleEqual(55f))
		{
			num *= FOVConstant.AUG_FOV1_SCALE_Result;
		}
		return num;
	}
}
