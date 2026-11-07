using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlaySoundHandler : ApcPacketHandler<PlayerSoundData>
{
	private GameRuleContext _gameRuleContext;

	public PlaySoundHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 228;
	}

	public override void Handle(PlayerSoundData data)
	{
		if (_gameRuleContext.currentRule.Rule.IsAcg())
		{
			if (data.SoundType == 1)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, isMyself: true, new AssetInfo("sound/player", "Assets/Res/Assets/" + data.SoundUrl), GameSoundManager.Config.WeaponVolume);
			}
			else if (data.SoundType == 2)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Scene, isMyself: true, new AssetInfo("sound/player", "Assets/Res/Assets/" + data.SoundUrl), GameSoundManager.Config.EnvironmentVolume);
			}
		}
		else if (data.SoundType == 3)
		{
			if (data != null && !string.IsNullOrEmpty(data.SoundUrl))
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSoundBG(SoundSystemTable.SoundSubtype.BG, isMyself: true, new AssetInfo("sound/bgm", "Assets/Res/Assets/" + data.SoundUrl), GameSoundManager.Config.AsideVolume, 0, loop: false, 0);
			}
		}
		else if (data != null && !string.IsNullOrEmpty(data.SoundUrl))
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Other, isMyself: true, new AssetInfo("sound/player", "Assets/Res/Assets/" + data.SoundUrl), GameSoundManager.Config.AsideVolume);
		}
	}
}
