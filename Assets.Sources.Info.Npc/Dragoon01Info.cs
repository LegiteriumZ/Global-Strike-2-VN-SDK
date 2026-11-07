using UnityEngine;

namespace Assets.Sources.Info.Npc;

public class Dragoon01Info : AbstractBattlePetInfo
{
	private GameObject _gameObject;

	public override void RenderEntity(SceneObjectEntity npcEntity)
	{
		base.RenderEntity(npcEntity);
		bool flag = (npcEntity.npc.Current.EffectLevel & 1) > 0;
		GameObject gameObject = npcEntity.unityObjects.LoadResults["NpcModel"].GameObject;
		if (_gameObject == null)
		{
			_gameObject = gameObject.GetComponentInChildren<SkinnedMeshRenderer>(includeInactive: true).gameObject;
		}
		if (_gameObject.IsActiveSelf() == flag)
		{
			_gameObject.SetObjectActive(!flag);
			if (flag)
			{
				gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			}
			else
			{
				gameObject.transform.localScale = Vector3.one;
			}
		}
	}
}
