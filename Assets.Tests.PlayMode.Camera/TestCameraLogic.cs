using System;
using System.Collections;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Utils;
using NetData;
using SSJJAnim.AnimState;
using SSJJBase.Thread;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;
using share.constant;

namespace Assets.Tests.PlayMode.Camera;

public class TestCameraLogic
{
	private Contexts _contexts;

	private int _entityId = 100;

	private TestCameraModule _testCameraModule;

	private RoomData _iceRoomData;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
		_testCameraModule = new TestCameraModule(_contexts);
		_iceRoomData = new RoomData
		{
			RaceType = 3,
			SceneId = 12
		};
	}

	public void Dispose()
	{
		GameTestHelper.Cleanup(_contexts);
	}

	public IEnumerator TestNormalCamera()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 pos = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f));
		PlayerEntity playerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", pos);
		playerEntity.isCameraOwner = true;
		playerEntity.isMyPlayer = true;
		playerEntity.isFirstPersonView = true;
		BaseAsyncManager.Instance.StartCoRoutine(PlayerEntityTestUtility.MoveRandomly(playerEntity));
		yield return new WaitForSeconds(10f);
	}

	public IEnumerator TestDeadCamera()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 pos = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", pos);
		myPlayerEntity.isCameraOwner = true;
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isFirstPersonView = true;
		yield return new WaitForSeconds(2f);
		myPlayerEntity.basicInfo.Current.IsDead = true;
		myPlayerEntity.ReplaceDeadCamera(pos + VectorCoordConverter.UnityToSsjj(new Vector3(500f, 75f, -1000f)));
		myPlayerEntity.legAnim.LegsAnimInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(11);
		yield return new WaitForSeconds(2f);
		myPlayerEntity.basicInfo.Current.IsDead = false;
		myPlayerEntity.legAnim.LegsAnimInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(1);
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestControlByEntity()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, new RoomData
		{
			RaceType = 3,
			SceneId = 31
		});
		Vector3 pos = VectorCoordConverter.UnityToSsjj(new Vector3(-4018f, 1407f, 4656f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", pos);
		myPlayerEntity.isCameraOwner = true;
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isFirstPersonView = true;
		yield return new WaitForSeconds(2f);
		SceneObjectEntity controlEntity = _contexts.sceneObject.CreateEntity();
		controlEntity.AddEntityId(_entityId++);
		controlEntity.AddPosition(pos + new Vector3(0f, 0f, 200f));
		myPlayerEntity.basicInfo.Current.ControlEntityId = controlEntity.entityId.Value;
		IEnumerator cor = RandomMoveUAV(controlEntity);
		BaseAsyncManager.Instance.StartCoRoutine(cor);
		yield return new WaitForSeconds(10f);
		BaseAsyncManager.Instance.StopCoRoutine(cor);
		controlEntity.Destroy();
		myPlayerEntity.basicInfo.Current.ControlEntityId = 0;
		yield return new WaitForSeconds(2f);
	}

	private IEnumerator RandomMoveUAV(SceneObjectEntity entity)
	{
		UnityEngine.Random.InitState(DateTime.UtcNow.Millisecond);
		Vector3 dir = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), 0f).normalized;
		while (true)
		{
			if (UnityEngine.Random.Range(0, 50) == 0)
			{
				dir = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), 0f).normalized;
			}
			Vector3 moveOffset = dir * Time.deltaTime * 500f;
			TraceResult ret = default(TraceResult);
			Vector3 origin = PyEngineUtility.TraceCamreaEndPos(entity.position.Origin, moveOffset, ref ret);
			entity.position.Origin = origin;
			yield return null;
		}
	}

	public IEnumerator TestObserver()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 vector = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", vector);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		for (int i = 0; i < 5; i++)
		{
			PlayerEntity myPlayerEntity2 = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", vector + new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), 0f));
			BaseAsyncManager.Instance.StartCoRoutine(PlayerEntityTestUtility.MoveRandomly(myPlayerEntity2));
		}
		yield return new WaitForSeconds(2f);
		myPlayerEntity.isCameraOwner = false;
		_contexts.player.GetEntityWithEntityId(_entityId - 1).isCameraOwner = true;
		yield return new WaitForSeconds(5f);
		_contexts.battleRoom.gameStateEntity.isObserverFirstMode = true;
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestCameraEffect()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 pos = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "longyin", "ak47", pos);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		PlotCameraInfoData plotCameraInfoData = new PlotCameraInfoData();
		plotCameraInfoData.PlotName = "role1002";
		plotCameraInfoData.Kind = PlotCameraKind.SELF;
		plotCameraInfoData.StartTime = _contexts.time.time.RenderTime;
		myPlayerEntity.basicInfo.Current.PlotCameraInfoData = plotCameraInfoData;
		yield return new WaitForSeconds(5f);
		myPlayerEntity.basicInfo.Current.PlotCameraInfoData = null;
		yield return new WaitForSeconds(1f);
	}

	public IEnumerator TestSpecialStatus()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 pos = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", pos);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		yield return new WaitForSeconds(2f);
		myPlayerEntity.GetPlayerInfo().InChaos = true;
		yield return new WaitForSeconds(5f);
		myPlayerEntity.GetPlayerInfo().InChaos = false;
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestParasitic()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 vector = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", vector);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		PlayerEntity otherPlayer = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", vector + new Vector3(200f, 0f, 0f));
		yield return new WaitForSeconds(2f);
		myPlayerEntity.GetPlayerInfo().ParasiticId = otherPlayer.entityId.Value;
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.THIRD_CAMERA_BACKDIS.ID] = new PlayerInfoComponent.StatusDes();
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.THIRD_CAMERA_HEIGHT.ID] = new PlayerInfoComponent.StatusDes();
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.THIRD_CAMERA_BACKDIS.ID].Number = -300;
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.THIRD_CAMERA_HEIGHT.ID].Number = 150;
		yield return new WaitForSeconds(2f);
		myPlayerEntity.GetPlayerInfo().ParasiticId = 0;
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestXpSkill()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, _iceRoomData);
		Vector3 pos = VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 75f, 2029f));
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, _entityId++, "type2", "ak47", pos);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		BaseAsyncManager.Instance.StartCoRoutine(PlayerEntityTestUtility.MoveRandomly(myPlayerEntity));
		yield return new WaitForSeconds(2f);
		myPlayerEntity.GetPlayerInfo().InXPSkill = true;
		yield return new WaitForSeconds(5f);
		myPlayerEntity.GetPlayerInfo().InXPSkill = false;
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.SKY_DEAGLE_SKILL_SHIFANGSHIJIAO.ID].Number = 1;
		yield return new WaitForSeconds(5f);
		myPlayerEntity.skill.Status.Remove(PlayerInfoStatusConstant.SKY_DEAGLE_SKILL_SHIFANGSHIJIAO.ID);
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestG18MetalStorm()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testCameraModule);
		yield return GameTestHelper.InitWorld(_contexts, new RoomData
		{
			RaceType = 3,
			SceneId = 100001
		});
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(pos: new Vector3(7873.37f, 1388.4f, 520f), playerContext: _contexts.player, entityId: _entityId++, careerName: "type2", weaponName: "ak47");
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		PlayerEntityTestUtility.SetRotation(myPlayerEntity, 90f, 0f);
		BaseAsyncManager.Instance.StartCoRoutine(PlayerEntityTestUtility.MoveRandomly(myPlayerEntity));
		yield return new WaitForSeconds(2f);
		myPlayerEntity.GetPlayerInfo().ThirdMode = true;
		yield return new WaitForSeconds(5f);
	}
}
