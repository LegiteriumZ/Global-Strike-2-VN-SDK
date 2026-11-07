using Assets.Scripts.Utility.ParticleSize;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.ParticleLod;

public class ParticleLodPlaybackSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private int _frameCount;

	private Camera _camera;

	private float _allowMinLodDistance = 1150f;

	private float _allSizeScaleDistance = 2.1f;

	private float _sizeUnitScaleDistance = 4.5f;

	private bool _init;

	public ParticleLodPlaybackSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.ParticleLod).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		if (!GameController.Instance.IsOpenLod)
		{
			return;
		}
		Init();
		bool uiCross_AwpVisible = UiIEventCondition.Get_uiCross_AwpVisible();
		foreach (SceneObjectEntity item in _group)
		{
			for (int i = 0; i < item.particleLod.SizeUnits.Count; i++)
			{
				RefreshParticleLod(item.particleLod.SizeUnits[i] as ParticleSizeUnit, uiCross_AwpVisible, _frameCount);
			}
		}
		_frameCount++;
	}

	private void RefreshParticleLod(ParticleSizeUnit unit, bool isHasFov, int frameCount)
	{
		if (_camera == null || unit == null || unit.FireEffect != null || frameCount % 20 != unit.FrameOffSet)
		{
			return;
		}
		float num = Vector3.Magnitude(_camera.transform.position - unit.transform.position);
		bool isAllowLod = num > _allowMinLodDistance;
		if (CheckCanSee(unit.Size, num, _allSizeScaleDistance, isHasFov, isAllowLod))
		{
			unit.IsAllSee = true;
			for (int i = 0; i < unit.Sizes.Count; i++)
			{
				bool isSee = CheckCanSee(unit.Sizes[i].Size, num, _sizeUnitScaleDistance, isHasFov, isAllowLod);
				unit.SeeUnitCheck(i, isSee);
			}
		}
		else
		{
			unit.AllUnSee();
		}
	}

	private bool CheckCanSee(float size, float distance, float scale, bool isHasFov, bool isAllowLod)
	{
		if (isHasFov)
		{
			return true;
		}
		if (!isAllowLod)
		{
			return true;
		}
		if (distance > scale * size)
		{
			return false;
		}
		return true;
	}

	private void Init()
	{
		if (!_init)
		{
			_init = true;
			_camera = Camera.main;
		}
	}
}
