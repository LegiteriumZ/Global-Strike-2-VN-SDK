using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJBase.Logger;
using SSJJBase.Manager;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class DefaultSceneBuffEffectRender : AbstractSceneBuffEffectRender
{
	private bool _isParticle;

	private bool _isCanRotate = true;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		SceneBuffEffectData sceneBuffEffectData = ParticleManager.Instance().GetSceneBuffEffectData(((SceneObjectEntity)entity).sceneBuff.Data.BufName);
		_isCanRotate = true;
		if (sceneBuffEffectData != null)
		{
			_isParticle = true;
			if (!sceneBuffEffectData.CanChangeRotation)
			{
				_isCanRotate = false;
			}
		}
		if (!_isParticle)
		{
			CommonParticleResConfig defaultParticleResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultParticleResConfig(((SceneObjectEntity)entity).sceneBuff.Data.BufName);
			if (defaultParticleResConfig != null && defaultParticleResConfig.Type.Equals("scenebuff"))
			{
				this.Info("Use Default CommonResParticle : " + ((SceneObjectEntity)entity).sceneBuff.Data.BufName);
				_isParticle = true;
			}
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetRotation(SceneObjectEntity target)
	{
		if (_isCanRotate)
		{
			return base.GetRotation(target);
		}
		return Vector3.zero;
	}
}
