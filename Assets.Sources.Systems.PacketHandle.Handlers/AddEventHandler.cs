using Assets.Generated.Table;
using Assets.Sources.Modules.SceneObject;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using SSJJNetworking.Server;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AddEventHandler : ApcPacketHandler<APC>
{
	private PlayerContext _playerContext;

	public AddEventHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 37;
	}

	public override void Handle(APC data)
	{
		if (!_playerContext.isMyPlayer)
		{
			return;
		}
		int id = data.Id;
		if (id == 17)
		{
			SprayEventEntityData sprayEventEntityData = ((IPacketBodyParser<SprayEventEntityData>)new ApcBodyParser<SprayEventEntityData>()).Parse(data.Content, data.Content.Length);
			bool isMyself = sprayEventEntityData.PlayerName == _playerContext.myPlayerEntity.basicInfo.PlayerName;
			if (sprayEventEntityData.IsAdd)
			{
				Vector3 inv = new Vector3(sprayEventEntityData.X, sprayEventEntityData.Y, sprayEventEntityData.Z);
				inv = VectorCoordConverter.SsjjToUnity(inv);
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Shoot, isMyself, SoundResourceUtility.GetCommonSoundUrl("spray_fire"), inv, GameSoundManager.Config.EnvironmentVolume, 10000);
				BaseAsyncManager.Instance.StartCoRoutine(SceneObjectFactory.Instance.CraeteSpary(sprayEventEntityData));
			}
			else
			{
				SceneObjectFactory.Instance.RemoveSpary(sprayEventEntityData);
			}
		}
	}
}
