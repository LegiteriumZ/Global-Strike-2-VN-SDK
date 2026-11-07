using System.Collections;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Tests.PlayMode.Scene;

public class SceneTests
{
	private Contexts _contexts;

	private TestSceneModule _testSceneModule;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
		_testSceneModule = new TestSceneModule(_contexts);
	}

	public void Disopose()
	{
		GameTestHelper.Cleanup(_contexts);
	}

	private IEnumerator TestMap(int mapId, Vector3 pos)
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _testSceneModule);
		yield return GameTestHelper.InitWorld(_contexts, new RoomData
		{
			RaceType = 3,
			SceneId = mapId
		});
		PlayerEntity playerEntity = PlayerEntityTestUtility.CreateEntity(_contexts.player, 100, "type2", "ak47", pos);
		playerEntity.isMyPlayer = true;
		playerEntity.isCameraOwner = true;
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestBsp()
	{
		yield return TestMap(12, VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f)));
	}

	public IEnumerator TestSce104()
	{
		yield return TestMap(39, VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f)));
	}

	public IEnumerator TestSce106()
	{
		yield return TestMap(500, VectorCoordConverter.UnityToSsjj(new Vector3(-1346f, 100f, 2029f)));
	}
}
