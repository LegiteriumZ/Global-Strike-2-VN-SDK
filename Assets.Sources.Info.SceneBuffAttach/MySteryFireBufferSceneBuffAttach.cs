using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface.SceneBuffAttach;
using Assets.Sources.Constant;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.SceneBuffAttach;

public class MySteryFireBufferSceneBuffAttach : ISceneBuffAttach
{
	private Text _nameTextTran;

	public float ScreenScale;

	private Vector3 _lastNamePos;

	public void Init()
	{
		ScreenScale = FaceToCamera.GetScreenScale();
	}

	public void Render(int frameTime, SceneObjectEntity entity, SceneObjectEntity attachedEntity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		if (_nameTextTran == null)
		{
			_nameTextTran = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		}
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		dest += new Vector3(0f, 950f, 0f);
		Vector3 vector = (Vector3)RectTransformUtility.WorldToScreenPoint(UnityEngine.Camera.main, dest) - new Vector3(Screen.width, Screen.height) / 2f;
		SetPosition(newPos: new Vector3((int)vector.x, (int)vector.y, (int)vector.z) / ScreenScale, tran: _nameTextTran.transform, lastPos: ref _lastNamePos);
		_nameTextTran.text = Contexts.sharedInstance.gameRule.mystery.StartFireName;
	}

	public void SetPosition(Transform tran, ref Vector3 lastPos, Vector3 newPos)
	{
		if (lastPos != newPos)
		{
			tran.localPosition = newPos;
			lastPos = newPos;
		}
	}

	public AssetInfo GetEffectAssetInfo()
	{
		return AssetBundleNameConstant.GetSceneEffectPrefabAssetInfo("MySteryFireBuffer");
	}

	public ISceneBuffAttach Clone()
	{
		return new MySteryFireBufferSceneBuffAttach();
	}
}
