using System.Collections;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Framework;
using SSJJBase.Thread;
using UnityEngine;
using share.constant;

namespace Assets.Tests.PlayMode.Player.Anim;

public class PlayerAnimTest
{
	private Contexts _contexts;

	private IGameModule _testModule;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
		_testModule = new PlayerAnimTestModule(_contexts);
		GameTestHelper.AddMainCamera();
	}

	public void Disopose()
	{
		GameTestHelper.Cleanup(_contexts);
	}

	public IEnumerator TestWuqi01Bone()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testModule);
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, 100, "renzhe", "ak47", Vector3.zero);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		myPlayerEntity.isThirdPersonView = true;
		myPlayerEntity.isFirstPersonView = false;
		myPlayerEntity.skill.Info.ThirdMode = true;
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.RPG_using_role1002.ID] = new PlayerInfoComponent.StatusDes();
		myPlayerEntity.skill.Status[PlayerInfoStatusConstant.RPG_using_role1002.ID].Number = 1;
		while (!myPlayerEntity.hasThirdPersonUnityObjects)
		{
			yield return null;
		}
		Transform bone = myPlayerEntity.thirdPersonUnityObjects.Animator.GetBone("wuqi1");
		_ = bone.localPosition;
		_ = bone.localRotation;
		IEnumerator anim1 = PlayerEntityTestUtility.PlayTorseAnim(myPlayerEntity, 153);
		BaseAsyncManager.Instance.StartCoRoutine(anim1);
		yield return new WaitForSeconds(5f);
		BaseAsyncManager.Instance.StopCoRoutine(anim1);
		IEnumerator anim2 = PlayerEntityTestUtility.PlayTorseAnim(myPlayerEntity, 151);
		BaseAsyncManager.Instance.StartCoRoutine(anim2);
		yield return new WaitForSeconds(2f);
		BaseAsyncManager.Instance.StopCoRoutine(anim2);
	}

	public IEnumerator TestMech()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testModule);
		PlayerEntity myPlayerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, 100, "mechnear2", "mechnear2", Vector3.zero);
		myPlayerEntity.isMyPlayer = true;
		myPlayerEntity.isCameraOwner = true;
		myPlayerEntity.isThirdPersonView = true;
		myPlayerEntity.isFirstPersonView = false;
		myPlayerEntity.skill.Info.ThirdMode = true;
		while (!myPlayerEntity.hasThirdPersonUnityObjects)
		{
			yield return null;
		}
		IEnumerator anim1 = PlayerEntityTestUtility.PlayTorseAnim(myPlayerEntity, 50);
		BaseAsyncManager.Instance.StartCoRoutine(anim1);
		yield return new WaitForSeconds(5f);
		BaseAsyncManager.Instance.StopCoRoutine(anim1);
	}
}
