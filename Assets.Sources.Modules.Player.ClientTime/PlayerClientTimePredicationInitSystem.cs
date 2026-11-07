using Assets.Sources.Components.Player;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.ClientTime;

public class PlayerClientTimePredicationInitSystem : PredicationInitSystemBase<ClientTimeComponent>
{
	private readonly PlayerContext _playerContext;

	public override ClientTimeComponent CurrentComponent => _playerContext.predictionEntity.clientTime;

	public PlayerClientTimePredicationInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override void GetComponentFromSnapshot(ClientTimeComponent comp)
	{
		comp.ClientTime = _playerContext.predictionEntity.basicInfo.Current.ClientTime;
	}
}
