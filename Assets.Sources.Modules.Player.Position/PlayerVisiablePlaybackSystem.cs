using Assets.Sources.Framework;
using Assets.Sources.Utils.Ui;
using Entitas;
using SSJJMath;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Position;

public class PlayerVisiablePlaybackSystem : IPlaybackSystem
{
	private Camera _camera;

	private CPlane[] _cameraPlanes;

	private readonly IGroup<PlayerEntity> _group;

	private readonly IGroup<SceneObjectEntity> _sceneGroup;

	private const int NearDistance = 360000;

	public PlayerVisiablePlaybackSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Visiable, PlayerMatcher.Fpos).NoneOf(PlayerMatcher.Destroy));
		_sceneGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.Position, SceneObjectMatcher.Visiable).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		if (_camera == null && Contexts.sharedInstance.worldCamera.hasUnityObjects)
		{
			_camera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;
			_cameraPlanes = new CPlane[4];
			for (int i = 0; i < _cameraPlanes.Length; i++)
			{
				_cameraPlanes[i] = new CPlane();
			}
		}
		if (_camera == null)
		{
			return;
		}
		Vector3 cameraPos = VectorCoordConverter.UnityToSsjj(_camera.transform.position);
		Matrix4x4 projectionMatrix = GeometryUtilityUser.GetProjectionMatrix(0.01f, _camera.farClipPlane, _camera.fieldOfView, _camera.aspect);
		GeometryUtilityUser.CalculateFrustumPlanes(_camera, projectionMatrix, cameraPos, ref _cameraPlanes);
		foreach (PlayerEntity item in _group)
		{
			if (item.hasHitBox)
			{
				item.visiable.IsVisiable = InScreenUtils.InScreen(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()), item.hitBox.HitPreliminaryGeo, _cameraPlanes);
				item.visiable.IsNear = item.visiable.IsVisiable;
			}
			else
			{
				VectorCoordConverter.SsjjToUnity(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()), out var dest);
				item.visiable.IsVisiable = InScreenUtils.InScreen(dest, _camera) > 0f;
				item.visiable.IsNear = Vector3.SqrMagnitude(_camera.transform.position - dest) < 360000f;
			}
		}
		foreach (SceneObjectEntity item2 in _sceneGroup)
		{
			Vector3 vector = VectorCoordConverter.SsjjToUnity(item2.position.Origin);
			item2.visiable.IsVisiable = InScreenUtils.InScreen(vector, _camera) > 0f;
			item2.visiable.IsNear = Vector3.SqrMagnitude(_camera.transform.position - vector) < 360000f;
		}
	}
}
