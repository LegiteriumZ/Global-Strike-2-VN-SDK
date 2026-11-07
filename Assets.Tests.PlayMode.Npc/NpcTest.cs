using System.Collections;
using System.IO;
using System.Linq;
using Assets.Sources.Info.Career;
using Assets.Sources.Particle;
using Assets.Sources.Utils.ComponentInit;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Tests.PlayMode.Npc;

public class NpcTest
{
	private Contexts _contexts;

	private static int _ownerCid = 99;

	private static int _npcEntityId = 100;

	private NpcTestModule _npcTestModule;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
		_npcTestModule = new NpcTestModule(_contexts);
		GameTestHelper.AddMainCamera();
	}

	public void Dispose()
	{
		GameTestHelper.Cleanup(_contexts);
	}

	public IEnumerator TestLoadNpc()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _npcTestModule);
		SceneObjectContext sceneObject = _contexts.sceneObject;
		PlayerEntity playerEntity = _contexts.player.CreateEntity();
		PlayerEntityUtility.AddBasicInfo(playerEntity);
		PlayerEntityUtility.AddSkill(playerEntity);
		PlayerEntityData current = new PlayerEntityData
		{
			CharacterId = _ownerCid,
			PlayerName = "测试角色名"
		};
		playerEntity.isCameraOwner = true;
		playerEntity.basicInfo.Current = current;
		playerEntity.basicInfo.CareerInfo = new DefaultCareerInfo("type2");
		string[] array = (from x in Directory.GetDirectories("Assets/Res/Assets/npc")
			select new DirectoryInfo(x).Name).ToArray();
		foreach (string npcName in array)
		{
			BaseAsyncManager.Instance.StartCoRoutine(LoadSingleNpc(sceneObject, npcName));
		}
		yield return new WaitForSeconds(5f);
	}

	public IEnumerator TestNpcEffectPlay()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _npcTestModule);
		SceneObjectContext sceneObject = _contexts.sceneObject;
		SceneObjectEntity npcEntity = CreateNpcEntity(sceneObject, "dragoon01");
		while (!npcEntity.hasNpcUnityObjects)
		{
			yield return null;
		}
		NpcEntityData npcData = npcEntity.npcBasicInfo.Current;
		for (int j = 1; j < 5; j++)
		{
			npcData.EffectLevel = 1 << j - 1;
			yield return new WaitForSeconds(1f);
		}
		npcData.EffectLevel = 0;
		for (int j = 1; j < 5; j++)
		{
			npcData.EffectLevel |= 1 << j - 1;
			yield return new WaitForSeconds(1f);
		}
	}

	public IEnumerator TestChicken()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _npcTestModule);
		SceneObjectContext sceneObject = _contexts.sceneObject;
		SceneObjectEntity npcEntity = CreateNpcEntity(sceneObject, "turkey");
		while (!npcEntity.hasChickenUnityObjects)
		{
			yield return null;
		}
		NpcEntityData npcData = npcEntity.npcBasicInfo.Current;
		npcData.SkillEffectData = 3;
		for (int i = 0; i < 10; i++)
		{
			npcData.EffectData = 10 - i;
			yield return new WaitForSeconds(0.1f);
		}
		npcData.SkillEffectData = 0;
		yield return new WaitForSeconds(2f);
	}

	public IEnumerator TestNpcStatusEffect()
	{
		yield return GameTestHelper.InitTestGameController(_contexts, _npcTestModule);
		SceneObjectContext sceneObjectContext = _contexts.sceneObject;
		SceneObjectEntity npcEntity = CreateNpcEntity(sceneObjectContext, "dragoon01");
		while (!npcEntity.hasNpcUnityObjects)
		{
			yield return null;
		}
		SceneObjectEntity loadConfigEntity = sceneObjectContext.CreateEntity();
		LoadRequests loadRequests = new LoadRequests();
		string[] skills = (from x in Directory.GetDirectories("Assets/Res/Assets/skill")
			select new DirectoryInfo(x).Name).ToArray();
		string[] array = skills;
		foreach (string skill in array)
		{
			ParticleManager.InitSkillParticleXmlLoadRequests(loadRequests, skill);
		}
		loadConfigEntity.AddLoadUnityObjects(loadRequests, null);
		while (!loadConfigEntity.hasUnityObjects)
		{
			yield return null;
		}
		array = skills;
		foreach (string skill2 in array)
		{
			ParticleManager.InitSkillParticleXmlLoadResults(loadConfigEntity.unityObjects.LoadResults, skill2);
		}
		NpcEntityData npcData = npcEntity.npcBasicInfo.Current;
		int[] testStatus = new int[2] { 0, 1 };
		int[] array2 = testStatus;
		foreach (int num in array2)
		{
			npcData.SkillEffectLevel = 1 << num;
			yield return new WaitForSeconds(1f);
		}
		npcData.SkillEffectLevel = 0f;
		array2 = testStatus;
		foreach (int num2 in array2)
		{
			npcData.SkillEffectLevel = (int)npcData.SkillEffectLevel | (1 << num2);
			yield return new WaitForSeconds(1f);
		}
		npcEntity.isDestroy = true;
		yield return new WaitForSeconds(2f);
	}

	private IEnumerator LoadSingleNpc(SceneObjectContext sceneObjectContext, string npcName)
	{
		SceneObjectEntity sceneObjectEntity = CreateNpcEntity(sceneObjectContext, npcName);
		NpcEntityData npcData = sceneObjectEntity.npcBasicInfo.Current;
		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);
		while (true)
		{
			if (Random.Range(0, 5) == 0)
			{
				x = Random.Range(-1f, 1f);
				y = Random.Range(-1f, 1f);
			}
			Vector3 vector = new Vector3(x, y, 0f).normalized * Time.deltaTime * 200f;
			npcData.X += vector.x;
			npcData.Y += vector.y;
			yield return null;
		}
	}

	private static SceneObjectEntity CreateNpcEntity(SceneObjectContext sceneObjectContext, string career)
	{
		SceneObjectEntity sceneObjectEntity = sceneObjectContext.CreateEntity();
		NpcEntityData npcEntityData = new NpcEntityData
		{
			Id = _npcEntityId++,
			Career = career,
			Cid = _ownerCid,
			Anim = 1
		};
		sceneObjectEntity.AddEntityId(npcEntityData.Id);
		sceneObjectEntity.AddNpcBasicInfo(npcEntityData, npcEntityData);
		sceneObjectEntity.AddNpcAnim(null, 0);
		sceneObjectEntity.AddPosition(new Vector3(0f, 0f, 0f));
		sceneObjectEntity.AddRotation(new Vector3(0f, 0f, 0f));
		return sceneObjectEntity;
	}
}
