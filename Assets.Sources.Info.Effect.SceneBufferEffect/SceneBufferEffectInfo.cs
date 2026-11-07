using System;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;
using Assets.Sources.Info.Res;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJAsset.Asset;
using SSJJBase.Manager;

namespace Assets.Sources.Info.Effect.SceneBufferEffect;

public class SceneBufferEffectInfo : AbstractSceneBufferEffectInfo
{
	public override string BuffName => "";

	public override AssetInfo GetEffectAssetInfo(string bufname, bool isParticle)
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null && !string.IsNullOrEmpty(bufname) && myPlayerEntity.hasBasicInfo && bufname.Equals("BLACK_HOLE_GRENADE_YANWU", StringComparison.CurrentCultureIgnoreCase) && (PlayerCareerConstantUtility.IsDoun(myPlayerEntity.GetCareer()) || PlayerCareerConstantUtility.IsEmpress(myPlayerEntity.GetCareer())))
		{
			bufname += "_1";
		}
		SceneBuffEffectData sceneBuffEffectData = ParticleManager.Instance().GetSceneBuffEffectData(bufname);
		if (sceneBuffEffectData == null)
		{
			CommonParticleResConfig defaultParticleResConfig = BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultParticleResConfig(bufname);
			if (defaultParticleResConfig != null && defaultParticleResConfig.Type == "scenebuff")
			{
				return defaultParticleResConfig.Info;
			}
			return default(AssetInfo);
		}
		if (isParticle)
		{
			return sceneBuffEffectData.ParticleAssetInfo;
		}
		return sceneBuffEffectData.AssetInfo;
	}

	protected override string GetPrefabName()
	{
		throw new NotImplementedException();
	}

	public override Type GetRenderType()
	{
		return typeof(DefaultSceneBuffEffectRender);
	}
}
