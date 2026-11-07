using Assets.Generated.Table;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PeekabooLikesCountHnadler : ApcPacketHandler<PeekabooGetLikesData>
{
	private GameRuleContext _gmGameRuleContext;

	public PeekabooLikesCountHnadler(Contexts contexts)
	{
		_gmGameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 81;
	}

	public override void Handle(PeekabooGetLikesData data)
	{
		_gmGameRuleContext.peekabooLikes.likesCountChange = true;
		_gmGameRuleContext.peekabooLikes.LikesCount = data.LikesCount;
		AssetInfo soundUrl = SoundResourceUtility.GetSoundUrl(25, "likes");
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, soundUrl, GameSoundManager.Config.AsideVolume);
	}
}
