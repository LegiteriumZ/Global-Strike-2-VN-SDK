using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Message.Common;

public class ResetDamageCountSystem : IMessageResetSystem, IEntityPreDestroySystem
{
	private MessageContext _messageContext;

	private PlayerContext _playerContext;

	private bool _lastIsDead;

	public ResetDamageCountSystem(Contexts contexts)
	{
		_messageContext = contexts.message;
		_playerContext = contexts.player;
	}

	public void OnEntityPreDestroy()
	{
		if (_playerContext.isMyPlayer)
		{
			bool flag = _playerContext.myPlayerEntity.IsDead();
			if (_lastIsDead && !flag)
			{
				_messageContext.damageCountData.DamageDataList.Clear();
			}
			_lastIsDead = flag;
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}
}
