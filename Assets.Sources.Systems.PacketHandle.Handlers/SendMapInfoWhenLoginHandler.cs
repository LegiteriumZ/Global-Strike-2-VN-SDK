using NetData;
using data;
using physics;
using physics.configData;
using physics.data;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class SendMapInfoWhenLoginHandler : ApcPacketHandler<SceneMapInfoData>
{
	private BattleRoomContext _battleRoomContext;

	public SendMapInfoWhenLoginHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 111;
	}

	public override void Handle(SceneMapInfoData mapInfo)
	{
		if (!_battleRoomContext.hasPyEngine || _battleRoomContext.pyEngine.PyEngine == null)
		{
			return;
		}
		IPyEngine pyEngine = _battleRoomContext.pyEngine.PyEngine;
		SceneMoveData obj = pyEngine.GetWorld().GetSceneMoveData() as SceneMoveData;
		obj.worldGravity = mapInfo.WorldGravity;
		obj.humanityJumpVelocity = mapInfo.HumanityJumpVelocity;
		obj.dounJumpVelocity = mapInfo.DounJumpVelocity;
		obj.heroJumpVelocity = mapInfo.HeroJumpVelocity;
		obj.jumpDamage = mapInfo.JumpDamage;
		obj.isWeightlessness = mapInfo.IsWeightlessness;
		IPyClipMap clipMap = pyEngine.GetWorld().GetClipMap();
		foreach (NetData.SceneThrustAreaData thrust in mapInfo.ThrustList)
		{
			CThrustArea cThrustArea = new CThrustArea();
			cThrustArea.PraseConfig(new physics.configData.SceneThrustAreaData
			{
				position = new float[3] { thrust.PosX, thrust.PosY, thrust.PosZ },
				direction = new float[3] { thrust.DirectionX, thrust.DirectionY, thrust.DirectionZ },
				height = thrust.Height,
				moveflag = thrust.Moveflag,
				radius = thrust.Radius,
				speed = thrust.Speed
			});
			clipMap.GetThrustAreaList().Add(cThrustArea);
			clipMap.SetNumThrustArea(clipMap.GetNumThrustArea() + 1);
		}
		foreach (NetData.SceneMoveLadderData moveLadder in mapInfo.MoveLadderList)
		{
			CMoveLadders cMoveLadders = new CMoveLadders();
			cMoveLadders.Prase(new physics.configData.SceneMoveLadderData
			{
				position0 = new float[3] { moveLadder.PosX0, moveLadder.PosY0, moveLadder.PosZ0 },
				position1 = new float[3] { moveLadder.PosX1, moveLadder.PosY1, moveLadder.PosZ1 },
				position2 = new float[3] { moveLadder.PosX2, moveLadder.PosY2, moveLadder.PosZ2 },
				position3 = new float[3] { moveLadder.PosX3, moveLadder.PosY3, moveLadder.PosZ3 },
				speed = moveLadder.Speed
			});
			clipMap.GetMoveLadderList().Add(cMoveLadders);
			clipMap.SetNumMoveLadders(clipMap.GetNumMoveLadders() + 1);
		}
	}
}
