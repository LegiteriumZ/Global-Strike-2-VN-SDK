using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgBuffMessageHandler : ApcPacketHandler<BuffInfo>
{
	private PlayerContext _playerContext;

	private PlayerEntity _player;

	public AcgBuffMessageHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 1100;
	}

	public override void Handle(BuffInfo data)
	{
		_player = _playerContext.GetEntityWithEntityId(data.PlayerId);
		if (_player == null || !_player.hasBuff)
		{
			return;
		}
		if (data.Active)
		{
			if (!_player.buff.AcgBuffs.Contains(data.BuffId))
			{
				_player.buff.AcgBuffs.Add(data.BuffId);
			}
			if (data.PlayerId == _playerContext.cameraOwnerEntity.basicInfo.Current.Id)
			{
				NotifyManager.ForceInvoke(101);
				NotifyManager.ForceInvokeGroupEvent(105, 104);
			}
			else if (_player.basicInfo.Current.Team == _playerContext.cameraOwnerEntity.basicInfo.Current.Team)
			{
				NotifyManager.ForceInvokeGroupEvent(105, 104);
			}
			else
			{
				NotifyManager.ForceInvoke(106);
			}
		}
		else
		{
			_player.buff.AcgRemoveIndex = _player.buff.AcgBuffs.IndexOf(data.BuffId);
			_player.buff.AcgBuffs.Remove(data.BuffId);
			if (data.PlayerId == _playerContext.cameraOwnerEntity.basicInfo.Current.Id)
			{
				NotifyManager.ForceInvoke(102);
			}
			else if (_player.basicInfo.Current.Team == _playerContext.cameraOwnerEntity.basicInfo.Current.Team)
			{
				NotifyManager.ForceInvokeGroupEvent(105, 105);
			}
			else
			{
				NotifyManager.ForceInvoke(107);
			}
		}
	}
}
