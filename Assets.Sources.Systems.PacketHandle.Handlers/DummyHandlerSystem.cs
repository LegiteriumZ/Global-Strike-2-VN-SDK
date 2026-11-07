using Entitas;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class DummyHandlerSystem : IInitializeSystem, ISystem
{
	public DummyHandlerSystem(Contexts contexts)
	{
	}

	public void Initialize()
	{
	}

	private void OnGameServerSetupCallback(GameServerSetupData data)
	{
		this.Debug("OnGameServerSetupCallback");
	}

	private void OnShowHpTypeCallback(ShowHpType data)
	{
		this.Debug("OnShowHpTypeCallback");
	}

	private void OnPveMessageCallback(PveMessageData data)
	{
		this.Debug("OnPveMessageCallback");
	}

	private void OnPlayerLoginCallback(PlayerLoginData data)
	{
		this.Debug("OnPlayerLoginCallback");
	}

	private void OnObserverInfoCallback(ObserverInfoData data)
	{
		this.Debug("OnObserverInfoCallback");
	}

	private void OnResetYawCallback(ResetYawData data)
	{
		this.Debug("OnResetYawCallback");
	}

	private void OnNewWeaponListCallback(OnGameinitData data)
	{
		this.Debug("OnNewWeaponListCallback");
	}

	private void OnNewPlayerListCallback(OnGameinitData data)
	{
		this.Debug("OnNewPlayerListCallback");
	}
}
