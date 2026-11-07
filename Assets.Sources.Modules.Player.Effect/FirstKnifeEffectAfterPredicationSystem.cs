using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.Utils;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

internal class FirstKnifeEffectAfterPredicationSystem : IAfterPredicationSystem
{
	private readonly IGroup<PlayerEntity> _firstGroup;

	private readonly WeaponContext _weaponContext;

	private readonly Dictionary<GameObject, AbstractKnifeEffectMb[]> _knifeEffectMbs;

	public FirstKnifeEffectAfterPredicationSystem(Contexts contexts)
	{
		_firstGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ViewAnim, PlayerMatcher.Fpos, PlayerMatcher.Orientation, PlayerMatcher.PunchSmooth, PlayerMatcher.CurrentWeapon, PlayerMatcher.FirstPersonUnityObjects));
		_weaponContext = contexts.weapon;
		_knifeEffectMbs = new Dictionary<GameObject, AbstractKnifeEffectMb[]>();
	}

	public void OnAfterPredication()
	{
		foreach (PlayerEntity item in _firstGroup)
		{
			if (!(item.firstPersonUnityObjects.KnifeEffectGameObject != null))
			{
				continue;
			}
			GameObject knifeEffectGameObject = item.firstPersonUnityObjects.KnifeEffectGameObject;
			int stateId = item.viewAnim.ViewAnimInfo.StateId;
			int rightCurrentTime = item.viewAnim.RightCurrentTime;
			Vector3 src = default(Vector3);
			src.x = item.GetCompenstatePos(item.fpos.Change.GetPosIndex()).x;
			src.y = item.GetCompenstatePos(item.fpos.Change.GetPosIndex()).y;
			src.z = item.GetCompenstatePos(item.fpos.Change.GetPosIndex()).z + item.move.ViewHeightBase + item.move.ViewHeightBase * item.GetScale() + item.viewHeight.ViewHeightSmoothRemain;
			VectorCoordConverter.SsjjToUnity(src, out var dest);
			knifeEffectGameObject.transform.position = dest;
			if (!_knifeEffectMbs.TryGetValue(knifeEffectGameObject, out var value))
			{
				value = knifeEffectGameObject.GetComponentsInChildren<AbstractKnifeEffectMb>();
				_knifeEffectMbs.Add(knifeEffectGameObject, value);
			}
			int wolfClawDoubleLevel = WolfClawConfig.GetWolfClawDoubleLevel(_weaponContext.currentWeaponEntity);
			AbstractKnifeEffectMb[] array = value;
			foreach (AbstractKnifeEffectMb abstractKnifeEffectMb in array)
			{
				KnifeAttackConfig config = abstractKnifeEffectMb.config;
				if (config == null)
				{
					continue;
				}
				if (config.FullEnable(stateId, wolfClawDoubleLevel, item.GetCurrentWeaponLevel(), rightCurrentTime, item.GetCurrentWeaponEffectLevel()))
				{
					if (abstractKnifeEffectMb is KnifeAttackModelEffect)
					{
						abstractKnifeEffectMb.Play();
					}
					if (abstractKnifeEffectMb is KnifeAttackParticleEffect)
					{
						abstractKnifeEffectMb.Play();
					}
				}
				else if (!config.CheckAnimEnable(stateId))
				{
					if (abstractKnifeEffectMb is KnifeAttackModelEffect)
					{
						abstractKnifeEffectMb.Stop();
					}
					if (abstractKnifeEffectMb is KnifeAttackParticleEffect)
					{
						abstractKnifeEffectMb.Stop();
					}
				}
			}
		}
	}
}
