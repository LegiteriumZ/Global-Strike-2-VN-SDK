using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Utils.Pool;
using Entitas;

namespace Assets.Sources.Systems.UserCommand;

public class CreateUserCommandSystem : IExecuteSystem, ISystem
{
	private readonly UserCommandContext _userCommandContext;

	private readonly BattleRoomContext _battleGameContext;

	private readonly PlayerContext _playerContext;

	public CreateUserCommandSystem(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
		_battleGameContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void Execute()
	{
		if (_battleGameContext.gameState.State == BattleGameState.Gaming && _playerContext.myPlayerEntity != null && _userCommandContext.commands.getCurrentCmd() == null)
		{
			_userCommandContext.commands.setCurrentCmd(UserCmdFactory.Instance().GetOrCreate());
		}
	}
}
